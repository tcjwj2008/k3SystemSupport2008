using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using YXK3FZ.ComClass;
using YXK3FZ.DataClass;
using System.Data.OleDb;
using System.Data.SqlClient;

using System.IO;   //特別引用流 System.IO
using System.Collections;
using Excel = Microsoft.Office.Interop.Excel;
using System.Reflection;
using YXK3FZ.RYGYL.RP.from;

namespace YXK3FZ.RYGYL.RP.from
{
    public partial class FRMRSJYB : Form
    {

        //基础成员变量
        DataSet ds = new DataSet(); 

        DataSet dsMoney = new DataSet();

        DataSet dsDayHeadNum = new DataSet(); //当天屠宰头数

        DataBase db = new DataBase();

        string sSPConn = string.Empty; //食品连接字符串
        string sRYConn = string.Empty; //肉业连接字符串

        DataBase dbSP;
        DataBase dbRY;

        CommonUse commUse = new CommonUse();
        int Ftype = 0;


        public FRMRSJYB()
        {
            InitializeComponent();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 获取EXCEL表格第一个文件名称
        /// </summary>
        /// <param name="filepath"></param>
        /// <param name="numberSheetID"></param>
        /// <returns></returns>
        public string GetFirstSheetNameFromExcelFileName(string filepath, int numberSheetID)
        {
            if (!System.IO.File.Exists(filepath))
            {
                return "This file is on the sky??";
            }
            if (numberSheetID <= 1) { numberSheetID = 1; }
            try
            {
                Microsoft.Office.Interop.Excel.Application obj = default(Microsoft.Office.Interop.Excel.Application);
                Microsoft.Office.Interop.Excel.Workbook objWB = default(Microsoft.Office.Interop.Excel.Workbook);
                string strFirstSheetName = null;

                obj = (Microsoft.Office.Interop.Excel.Application)Microsoft.VisualBasic.Interaction.CreateObject("Excel.Application", string.Empty);
                objWB = obj.Workbooks.Open(filepath, Type.Missing, Type.Missing,
                        Type.Missing, Type.Missing, Type.Missing, Type.Missing,
                        Type.Missing, Type.Missing, Type.Missing, Type.Missing,
                        Type.Missing, Type.Missing, Type.Missing, Type.Missing);

                strFirstSheetName = ((Microsoft.Office.Interop.Excel.Worksheet)objWB.Worksheets[1]).Name;

                objWB.Close(Type.Missing, Type.Missing, Type.Missing);
                objWB = null;
                obj.Quit();
                obj = null;
                return strFirstSheetName;
            }
            catch (Exception Err)
            {
                return Err.Message;
            }
        }

        /// <summary>
        /// 绑定报表数据
        /// </summary>
        /// <param name="fileName"></param>
        private void bind(string fileName)
        {
            //this.dataGridView3.DataSource = null;

            string strConn = "Provider=Microsoft.ACE.OLEDB.12.0;" + "Data Source=" + fileName + ";" + "Extended Properties=Excel 8.0;";
            OleDbConnection Excel_conn = new OleDbConnection(strConn);

            //读取Sheet1数据
            string SheetName = "";
            SheetName = GetFirstSheetNameFromExcelFileName(fileName, 1);
            string strExcel = string.Format("select * from [{0}" + "$]  ", SheetName);
            OleDbDataAdapter da = new OleDbDataAdapter(strExcel, strConn);

            //读取Sheet2数据
            string sMySql = "SELECT * FROM  [Sheet2$] where 1=2";//
            OleDbDataAdapter da2 = new OleDbDataAdapter(sMySql, strConn);


            try
            {

                da.Fill(ds);
                ///this.dataGridView2Price.DataSource = ds.Tables[0];
                this.dataGridView3.DataSource = ds.Tables[0];
                da2.Fill(dsDayHeadNum); //填充数据集              

            }

            catch (Exception err)
            {
                MessageBox.Show("操作失败！" + err.ToString());

            }

        }

        /// <summary>
        /// 读取EXCEL
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripLabel1_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 1;
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            string excelFileName = "";
            openFileDialog1.FileName = "";
            //openFileDialog1.Filter = "EXCEL文件(*.xls,*.xlsx)|*.xls,*.xlsx";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                excelFileName = openFileDialog1.FileName;
                bind(excelFileName);
            }
        }
        /// <summary>
        /// 手动导入成本
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripLabel2_Click(object sender, EventArgs e)
        {
            WaitFormService.CreateWaitForm();
            WaitFormService.SetWaitFormCaption("数据正在处理......");

            this.label2.Text = " 正在读取表格数据......";
            List<string> strSqls = new List<string>();
            if (this.dataGridView3.RowCount == 0)
            {
                this.label2.Text = "没有读取到成本数据!";
                return;
               
            }

            string sSQL = string.Empty;

            //清空临时数据
            strSqls.Add("  DELETE yx_rs_ysprice_CHECK WHERE FuserName='" + PropertyClass.OperatorName + "'");
            strSqls.Add("  DELETE yx_rs_DayHeadNum_Check WHERE FuserName='" + PropertyClass.OperatorName + "'");

            sSQL += " DELETE yx_rs_ysprice_CHECK WHERE FuserName='" + PropertyClass.OperatorName + "'";
            sSQL += " DELETE yx_rs_DayHeadNum_Check WHERE FuserName='" + PropertyClass.OperatorName + "'";

            DataRow dr = null;
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {

                dr = ds.Tables[0].Rows[i];
                strSqls.Add(" INSERT INTO yx_rs_ysprice_CHECK(Fnumber,Fprice,FDATE,FuserName)  VALUES  ( '" + dr["编码"].ToString() + "'," + dr["成本单价"].ToString() + ",'" + dr["日期"].ToString() + "','" + PropertyClass.OperatorName + "') ");
                sSQL += " INSERT INTO yx_rs_ysprice_CHECK(Fnumber,Fprice,FDATE,FuserName)  VALUES  ( '" + dr["编码"].ToString() + "'," + dr["成本单价"].ToString() + ",'" + dr["日期"].ToString() + "','" + PropertyClass.OperatorName + "') ";

            }

            //处理当天屠宰头数

            for (int i = 0; i < dsDayHeadNum.Tables[0].Rows.Count; i++)
            {
                dr = dsDayHeadNum.Tables[0].Rows[i];
                strSqls.Add(" INSERT INTO yx_rs_DayHeadNum_Check(FDATE,FDayHeadNum,FuserName)  VALUES  ( '" + dr["日期"].ToString() + "'," + dr["当天屠宰头数"].ToString() + ",'" + PropertyClass.OperatorName + "') ");
                sSQL += "  INSERT INTO yx_rs_DayHeadNum_Check(FDATE,FDayHeadNum,FuserName)  VALUES  ( '" + dr["日期"].ToString() + "'," + dr["当天屠宰头数"].ToString() + ",'" + PropertyClass.OperatorName + "')";
            }


            if (!db.ExecDataBySqls(strSqls))
            {
                this.label2.Text = " 读取表格数据失败!";
                WaitFormService.CloseWaitForm();
                MessageBox.Show("保存失败！", "软件提示");
                return;
            }



            SqlParameter param = new SqlParameter("@FuserName", SqlDbType.VarChar);
            param.Value = PropertyClass.OperatorName;
            //创建泛型
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(param);
            //把泛型中的元素复制到数组中
            SqlParameter[] inputParameters = parameters.ToArray();
            //存储过程 
            DataRow drc = null;
            drc = db.GetDataTable("sp_checkToyx_rs_ysprice ", inputParameters).Rows[0];
            if (drc["isok"].ToString() == "-1")
            {
                //this.toolStripStatusLabel1.Text = " 表格数据检查失败!";
                WaitFormService.CloseWaitForm();
                MessageBox.Show("保存失败:" + drc["msg"].ToString(), "软件提示");
                return;
            }

            this.label2.Text = " 开始写入K3......";

            SqlParameter param2 = new SqlParameter("@FuserName", SqlDbType.VarChar);
            param2.Value = PropertyClass.OperatorName;
            //创建泛型
            List<SqlParameter> parameters2 = new List<SqlParameter>();
            parameters2.Add(param2);
            //把泛型中的元素复制到数组中
            SqlParameter[] inputParameters2 = parameters2.ToArray();
            try
            {
                db.GetProcRow("sp_insertToyx_rs_ysprice", inputParameters2);
                this.label2.Text = " 表格数据导入成功!";
                WaitFormService.CloseWaitForm();
                MessageBox.Show("成功导入K3!", "软件提示");
                this.dataGridView1.DataSource = null;

            }
            catch (Exception ex)
            {
                this.label2.Text = " 表格数据导入失败!";
                WaitFormService.CloseWaitForm();
                MessageBox.Show("导入K3失败!" + ex.ToString(), "软件提示");

            }


        }
        /// <summary>
        /// 成本查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {

            this.tabControl1.SelectedIndex = 1;
            Ftype = 1;
            WaitFormService.CreateWaitForm();
            WaitFormService.SetWaitFormCaption("数据正在处理......");
            this.label2.Text = " 正在读取表格数据......";
            SqlParameter param1 = new SqlParameter("@BegDate", SqlDbType.DateTime);
            param1.Value = this.dateTimePicker1.Value;
            SqlParameter param2 = new SqlParameter("@EndDate", SqlDbType.DateTime);
            param2.Value = this.dateTimePicker1.Value;       
            //创建泛型
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(param1);
            parameters.Add(param2);
            //把泛型中的元素复制到数组中
            SqlParameter[] inputParameters = parameters.ToArray();
            try
            {
                ds = db.GetProcDataSet("sp_sel_yx_rs_ysprice", inputParameters);
                this.dataGridView2Price.DataSource = ds.Tables[0];
                this.label2.Text = " 读取成本数据完成.";
                WaitFormService.CloseWaitForm();
            }
            catch (Exception err)
            {
                WaitFormService.CloseWaitForm();
                MessageBox.Show("操作失败！" + err.ToString());
                this.label2.Text = " 读取成本数据失败.";

            }

        }




        /// <summary>
        /// 计算
        /// </summary>
        /// <param name="sSQL1">食品</param>
        /// <param name="sSQL2">肉业</param>
        /// <returns></returns>
        private decimal CalculatePrice(string sSQL1, string sSQL2)
        {
            if (sSQL2 != string.Empty && sSQL1 != string.Empty)
            {
                DataTable dttSP = dbSP.GetDataTable(sSQL1, "A");
                DataTable dttRY = dbRY.GetDataTable(sSQL2, "B");
                decimal A = 0;
                decimal B = 0;
                if (dttSP.Rows.Count > 0)
                {
                    A = Convert.ToDecimal(dttSP.Rows[0][0]);
                }
                if (dttRY.Rows.Count > 0)
                {
                    B = Convert.ToDecimal(dttRY.Rows[0][0]);
                }

                return A + B;
            }
            else
            {
                if (sSQL1 != string.Empty && sSQL2 == string.Empty)
                {
                    DataTable dttSP = dbSP.GetDataTable(sSQL1, "A");
                    decimal A = 0;
                    if (dttSP.Rows.Count > 0)
                    {
                        A = Convert.ToDecimal(dttSP.Rows[0][0]);
                    }
                    return A;
                }
                else if (sSQL2 != string.Empty && sSQL1 == string.Empty)
                {
                    DataTable dttRY = dbRY.GetDataTable(sSQL2, "B");
                    decimal B = 0;
                    if (dttRY.Rows.Count > 0)
                    {
                        B = Convert.ToDecimal(dttRY.Rows[0][0]);
                    }
                    return B;
                }
                else
                {
                    return 0;
                }
            }

        }




        /// <summary>
        /// 回款数查询
        /// </summary>
        /// <param name="dt"></param>
        private void NewMethod(DataTable dt)
        {
            string sDate = string.Empty;
            string sDepartCode = string.Empty;
            string sDepartName = string.Empty;

            string sText = string.Empty;  //短信内容
            string sDepartText = string.Empty; //具体部门短信
            string sSQL = string.Empty;  //查询语句
            string sSQL2 = string.Empty;  //查询语句

            decimal dDepartMoney = 0; //具体部门的金额
            decimal dALLMoney = 0;    //所有部门的金额  
            decimal dMoney = 0;

            decimal dMonthMoney = 0; //本月累计金额

            string sb = string.Empty;

            if (dt.Rows.Count > 0)
            {
                sDate = dt.Rows[0]["日期"].ToString();
                sDepartCode = dt.Rows[0]["部门代码"].ToString();
                sDepartName = dt.Rows[0]["部门名称"].ToString();

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    sDate = dt.Rows[i]["日期"].ToString();
                    sDepartCode = dt.Rows[i]["部门代码"].ToString();
                    sDepartName = dt.Rows[i]["部门名称"].ToString();

                    sSQL = string.Empty; //清空
                    sSQL2 = string.Empty; //清空


                    //查门店管理部门店经营日报表
                    if (sDepartCode == "10.11") // 部门代码:10.11
                    {
                        sSQL = "  SELECT CAST( (ISNULL(SUM(R.FSubAllBankAmount),0)+ISNULL(SUM(x.FSubSJAmount),0))/10000 as decimal(18,2) ) FROM t_SubCustomSell R  ";
                        sSQL += " LEFT JOIN t_SubCustomSellMX X ON R.FID=X.FID ";
                        sSQL += " WHERE r.FDate='" + sDate + "' ";
                        //单个语句有存在，则只计算单个语句－门店管理部的经营金额
                        dDepartMoney = CalculatePrice(sSQL, string.Empty);
                        //合计到所有部门金额中去
                        dALLMoney = dALLMoney + dDepartMoney;
                        sDepartName = sDepartName + "" + dDepartMoney + "万元。";
                        sText = sText + sDepartName;

                    }
                    //白条批发部
                    else if (sDepartCode == "10.12") // 部门代码:10.12
                    {
                        sSQL = "  SELECT CAST(ISNULL(SUM(FAmount),0)/10000 AS DECIMAL(18,2)) FROM t_RP_NewReceiveBill r WHERE FFincDate='" + sDate + "' ";
                        sSQL += " and FBillType=1000 ";
                        sSQL += " AND FExplanation not like '%礼券%'";
                        sSQL += " AND isnull(FAccountID,'')<>''";
                        sSQL += " AND EXISTS(SELECT * FROM t_Department WHERE r.FDepartment=FItemID AND FItemID<>0 and FNumber= '10.12') ";

                        sSQL2 = "  SELECT CAST(ISNULL(SUM(FAmount),0)/10000 AS DECIMAL(18,2)) FROM t_RP_NewReceiveBill r WHERE FFincDate='" + sDate + "' ";
                        sSQL2 += " and FBillType=0 ";
                        sSQL2 += " AND isnull(FAccountID,'')<>''";
                        sSQL2 += " AND EXISTS(SELECT * FROM t_Department WHERE r.FDepartment=FItemID AND FItemID<>0 and FNumber= '10.12') ";


                        dDepartMoney = CalculatePrice(sSQL, sSQL) + CalculatePrice(sSQL2, sSQL2);
                        dALLMoney = dALLMoney + dDepartMoney;

                        sDepartName = sDepartName + "" + dDepartMoney + "万元。";
                        sText = sText + sDepartName;

                    }
                    //加盟开发部
                    else if (sDepartCode == "10.13") // 部门代码:10.13
                    {
                        sSQL = "  SELECT CAST(ISNULL(SUM(FAmount),0)/10000 AS DECIMAL(18,2)) FROM t_RP_NewReceiveBill r WHERE FFincDate='" + sDate + "' ";
                        sSQL += " and FBillType=1000 ";
                        sSQL += " AND FExplanation not like '%礼券%'";
                        sSQL += " AND isnull(FAccountID,'')<>''";
                        sSQL += " AND EXISTS(SELECT * FROM t_Department WHERE r.FDepartment=FItemID AND FItemID<>0 and FNumber= '10.13') ";


                        sSQL2 = "  SELECT CAST(ISNULL(SUM(FAmount),0)/10000 AS DECIMAL(18,2)) FROM t_RP_NewReceiveBill r WHERE FFincDate='" + sDate + "' ";
                        sSQL2 += " and FBillType=0 ";
                        sSQL2 += " AND isnull(FAccountID,'')<>''";
                        sSQL2 += " AND EXISTS(SELECT * FROM t_Department WHERE r.FDepartment=FItemID AND FItemID<>0 and FNumber= '10.13') ";

                        dDepartMoney = CalculatePrice(sSQL, sSQL) + CalculatePrice(sSQL2, sSQL2);
                        dALLMoney = dALLMoney + dDepartMoney;

                        sDepartName = sDepartName + "" + dDepartMoney + "万元。";
                        sText = sText + sDepartName;
                    }
                    //冻品销售部
                    else if (sDepartCode == "10.14") // 部门代码:10.14
                    {
                        //TODO...
                        sSQL = "  SELECT CAST(ISNULL(SUM(FAmount),0)/10000 AS DECIMAL(18,2)) FROM t_RP_NewReceiveBill r WHERE FFincDate='" + sDate + "' ";
                        sSQL += " and FBillType=1000 ";
                        sSQL += " AND isnull(FAccountID,'')<>''";
                        sSQL += " AND EXISTS(SELECT * FROM t_Department WHERE r.FDepartment=FItemID AND FItemID<>0 and FNumber= '10.14') ";


                        sSQL2 = "  SELECT CAST(ISNULL(SUM(FAmount),0)/10000 AS DECIMAL(18,2)) FROM t_RP_NewReceiveBill r WHERE FFincDate='" + sDate + "' ";
                        sSQL2 += " and FBillType=0 ";
                        sSQL2 += " AND isnull(FAccountID,'')<>''";
                        sSQL2 += " AND EXISTS(SELECT * FROM t_Department WHERE r.FDepartment=FItemID AND FItemID<>0 and FNumber= '10.14') ";

                        dDepartMoney = CalculatePrice(sSQL, sSQL) + CalculatePrice(sSQL2, sSQL2);
                        dALLMoney = dALLMoney + dDepartMoney;
                        sDepartName = sDepartName + "" + dDepartMoney + "万元。";
                        sText = sText + sDepartName;
                    }
                    //厦门办室处
                    else if (sDepartCode == "10.15") // 部门代码:10.15
                    {
                        sSQL = "  SELECT CAST(ISNULL(SUM(FAmount),0)/10000 AS DECIMAL(18,2)) FROM t_RP_NewReceiveBill r WHERE FFincDate='" + sDate + "' ";
                        sSQL += " and FBillType=1000 ";
                        sSQL += " AND isnull(FAccountID,'')<>''";
                        sSQL += " AND EXISTS(SELECT * FROM t_Department WHERE r.FDepartment=FItemID AND FItemID<>0 and FNumber= '10.15') ";


                        sSQL2 = "  SELECT CAST(ISNULL(SUM(FAmount),0)/10000 AS DECIMAL(18,2)) FROM t_RP_NewReceiveBill r WHERE FFincDate='" + sDate + "' ";
                        sSQL2 += " and FBillType=0 ";
                        sSQL2 += " AND isnull(FAccountID,'')<>''";
                        sSQL2 += " AND EXISTS(SELECT * FROM t_Department WHERE r.FDepartment=FItemID AND FItemID<>0 and FNumber= '10.15') ";

                        dDepartMoney = CalculatePrice(sSQL, sSQL) + CalculatePrice(sSQL2, sSQL2);
                        dALLMoney = dALLMoney + dDepartMoney;

                        sDepartName = sDepartName + "" + dDepartMoney + "万元。";
                        sText = sText + sDepartName;
                    }
                    //福州办事处
                    else if (sDepartCode == "10.16") // 部门代码:10.16
                    {
                        sSQL = "  SELECT CAST(ISNULL(SUM(FAmount),0)/10000 AS DECIMAL(18,2)) FROM t_RP_NewReceiveBill r WHERE FFincDate='" + sDate + "' ";
                        sSQL += " and FBillType=1000 ";
                        sSQL += " AND isnull(FAccountID,'')<>''";
                        sSQL += " AND EXISTS(SELECT * FROM t_Department WHERE r.FDepartment=FItemID AND FItemID<>0 and FNumber= '10.16') ";

                        sSQL2 = "  SELECT CAST(ISNULL(SUM(FAmount),0)/10000 AS DECIMAL(18,2)) FROM t_RP_NewReceiveBill r WHERE FFincDate='" + sDate + "' ";
                        sSQL2 += " and FBillType=0 ";
                        sSQL2 += " AND isnull(FAccountID,'')<>''";
                        sSQL2 += " AND EXISTS(SELECT * FROM t_Department WHERE r.FDepartment=FItemID AND FItemID<>0 and FNumber= '10.16') ";

                        dDepartMoney = CalculatePrice(string.Empty, sSQL) + CalculatePrice(string.Empty, sSQL2);
                        dALLMoney = dALLMoney + dDepartMoney;
                        sDepartName = sDepartName + "" + dDepartMoney + "万元。";
                        sText = sText + sDepartName;
                    }
                    //驻外办事处
                    else if (sDepartCode == "10.17") // 部门代码:10.17
                    {
                        sSQL = "  SELECT CAST(ISNULL(SUM(FAmount),0)/10000 AS DECIMAL(18,2)) FROM t_RP_NewReceiveBill r WHERE FFincDate='" + sDate + "' ";
                        sSQL += " and FBillType=1000 ";
                        sSQL += " AND isnull(FAccountID,'')<>''";
                        sSQL += " AND EXISTS(SELECT * FROM t_Department WHERE r.FDepartment=FItemID AND FItemID<>0 and FNumber= '10.17') ";


                        sSQL2 = "  SELECT CAST(ISNULL(SUM(FAmount),0)/10000 AS DECIMAL(18,2)) FROM t_RP_NewReceiveBill r WHERE FFincDate='" + sDate + "' ";
                        sSQL2 += " and FBillType=0 ";
                        sSQL2 += " AND isnull(FAccountID,'')<>''";
                        sSQL2 += " AND EXISTS(SELECT * FROM t_Department WHERE r.FDepartment=FItemID AND FItemID<>0 and FNumber= '10.17') ";

                        dDepartMoney = CalculatePrice(sSQL, sSQL) + CalculatePrice(sSQL2, sSQL2);
                        dALLMoney = dALLMoney + dDepartMoney;

                        sDepartName = sDepartName + "" + dDepartMoney + "万元。";
                        sText = sText + sDepartName;
                    }
                    //华南办事处
                    else if (sDepartCode == "10.18") // 部门代码:10.18
                    {
                        sSQL = "  SELECT CAST(ISNULL(SUM(FAmount),0)/10000 AS DECIMAL(18,2)) FROM t_RP_NewReceiveBill r WHERE FFincDate='" + sDate + "' ";
                        sSQL += " and FBillType=1000 ";
                        sSQL += " AND isnull(FAccountID,'')<>''";
                        sSQL += " AND EXISTS(SELECT * FROM t_Department WHERE r.FDepartment=FItemID AND FItemID<>0 and FNumber= '10.18') ";
                        dDepartMoney = CalculatePrice(sSQL, sSQL);
                        dALLMoney = dALLMoney + dDepartMoney;
                        sDepartName = sDepartName + "" + dDepartMoney + "万元。";
                        sText = sText + sDepartName;
                    }
                    //小副产品
                    else if (sDepartCode == "10.19") // 部门代码:10.19
                    {
                        //TODO...
                        sSQL = "  SELECT CAST(ISNULL(SUM(FAmount),0)/10000 AS DECIMAL(18,2)) FROM t_RP_NewReceiveBill r WHERE FFincDate='" + sDate + "' ";
                        sSQL += " and FBillType=1000 ";
                        sSQL += " AND isnull(FAccountID,'')<>''";
                        sSQL += " AND EXISTS(SELECT * FROM t_Department WHERE r.FDepartment=FItemID AND FItemID<>0 and FNumber= '10.19') ";


                        sSQL2 = "  SELECT CAST(ISNULL(SUM(FAmount),0)/10000 AS DECIMAL(18,2)) FROM t_RP_NewReceiveBill r WHERE FFincDate='" + sDate + "' ";
                        sSQL2 += " and FBillType=0 ";
                        sSQL2 += " AND isnull(FAccountID,'')<>''";
                        sSQL2 += " AND EXISTS(SELECT * FROM t_Department WHERE r.FDepartment=FItemID AND FItemID<>0 and FNumber= '10.19') ";

                        dDepartMoney = CalculatePrice(sSQL, sSQL) + CalculatePrice(sSQL2, sSQL2);
                        dALLMoney = dALLMoney + dDepartMoney;

                        sDepartName = sDepartName + "" + dDepartMoney + "万元。";
                        sText = sText + sDepartName;
                    }


//加入10.20   2020-05-20


                    //综合经营部
                    else if (sDepartCode == "10.20") // 部门代码:10.20
                    {
                        //TODO...
                        sSQL = "  SELECT CAST(ISNULL(SUM(FAmount),0)/10000 AS DECIMAL(18,2)) FROM t_RP_NewReceiveBill r WHERE FFincDate='" + sDate + "' ";
                        sSQL += " and FBillType=1000 ";
                        sSQL += " AND isnull(FAccountID,'')<>''";
                        sSQL += " AND EXISTS(SELECT * FROM t_Department WHERE r.FDepartment=FItemID AND FItemID<>0 and FNumber= '10.20') ";


                        sSQL2 = "  SELECT CAST(ISNULL(SUM(FAmount),0)/10000 AS DECIMAL(18,2)) FROM t_RP_NewReceiveBill r WHERE FFincDate='" + sDate + "' ";
                        sSQL2 += " and FBillType=0 ";
                        sSQL2 += " AND isnull(FAccountID,'')<>''";
                        sSQL2 += " AND EXISTS(SELECT * FROM t_Department WHERE r.FDepartment=FItemID AND FItemID<>0 and FNumber= '10.20') ";

                        dDepartMoney = CalculatePrice(sSQL, sSQL) + CalculatePrice(sSQL2, sSQL2);
                        dALLMoney = dALLMoney + dDepartMoney;

                        sDepartName = sDepartName + "" + dDepartMoney + "万元。";
                        sText = sText + sDepartName;
                    }



                    //综合经营部
                    else if (sDepartCode == "10.21") // 部门代码:10.20
                    {
                        //TODO...
                        sSQL = "  SELECT CAST(ISNULL(SUM(FAmount),0)/10000 AS DECIMAL(18,2)) FROM t_RP_NewReceiveBill r WHERE FFincDate='" + sDate + "' ";
                        sSQL += " and FBillType=1000 ";
                        sSQL += " AND isnull(FAccountID,'')<>''";
                        sSQL += " AND EXISTS(SELECT * FROM t_Department WHERE r.FDepartment=FItemID AND FItemID<>0 and FNumber= '10.21') ";


                        sSQL2 = "  SELECT CAST(ISNULL(SUM(FAmount),0)/10000 AS DECIMAL(18,2)) FROM t_RP_NewReceiveBill r WHERE FFincDate='" + sDate + "' ";
                        sSQL2 += " and FBillType=0 ";
                        sSQL2 += " AND isnull(FAccountID,'')<>''";
                        sSQL2 += " AND EXISTS(SELECT * FROM t_Department WHERE r.FDepartment=FItemID AND FItemID<>0 and FNumber= '10.21') ";

                        dDepartMoney = CalculatePrice(sSQL, sSQL) + CalculatePrice(sSQL2, sSQL2);
                        dALLMoney = dALLMoney + dDepartMoney;

                        sDepartName = sDepartName + "" + dDepartMoney + "万元。";
                        sText = sText + sDepartName;
                    }





                    if (sDepartCode == "本日小计")
                    {
                        sb += sDate + "肉品产业营销部回款情况：" + sText + "合计:" + dALLMoney + "万元。" + "\r\n";

                        dMoney = dMoney + dALLMoney;

                        sText = string.Empty;
                        dALLMoney = 0;
                        dDepartMoney = 0;
                    }

                }

                this.textBox3.Text = sb.ToString() + "总合计：" + dMoney + "万元。";

                string sDate1 = string.Empty;
                string sDate2 = string.Empty;

                sDate2 = Convert.ToDateTime(dateTimePicker1.Text).ToString("yyyy-MM-dd");
                sDate1 = Convert.ToDateTime(dateTimePicker1.Text).ToString("yyyy-MM") + "-01";



                this.textBox3.Text = this.textBox3.Text + "本月累计回款金额：" + getCurrentMonthMoney(sDate1, sDate2) + "万元。";
                //本月累计回款方法
                //getCurrentMonthMoney
            }
        }



        /// <summary>
        /// 本月累计回款
        /// </summary>
        /// <param name="sDate"></param>
        /// <param name="sDate2"></param>
        /// <returns></returns>
        private decimal getCurrentMonthMoney(string sDate, string sDate2)
        {
            decimal dMonthMoney = 0; //本月累计金额

            string sSQL = string.Empty;  //食品查询语句
            string sSQL2 = string.Empty;  //肉业查询语句

            sSQL = "  SELECT CAST( (ISNULL(SUM(R.FSubAllBankAmount),0)+ISNULL(SUM(x.FSubSJAmount),0))/10000 as decimal(18,2) ) FROM t_SubCustomSell R  ";
            sSQL += " LEFT JOIN t_SubCustomSellMX X ON R.FID=X.FID ";
            sSQL += " WHERE r.FDate>='" + sDate + "' and r.FDate<='" + sDate2 + "' ";
            dMonthMoney += CalculatePrice(sSQL, string.Empty);

            sSQL = "  SELECT CAST(ISNULL(SUM(FAmount),0)/10000 AS DECIMAL(18,2)) FROM t_RP_NewReceiveBill r WHERE FFincDate>='" + sDate + "' and FFincDate<='" + sDate2 + "'  ";
            sSQL += " and FBillType=1000 ";
            sSQL += " AND FExplanation not like '%礼券%'";
            sSQL += " AND isnull(FAccountID,'')<>''";
            sSQL += " AND EXISTS(SELECT * FROM t_Department WHERE r.FDepartment=FItemID AND FItemID<>0 and FNumber= '10.12') ";

            sSQL2 = "  SELECT CAST(ISNULL(SUM(FAmount),0)/10000 AS DECIMAL(18,2)) FROM t_RP_NewReceiveBill r WHERE FFincDate>='" + sDate + "' and FFincDate<='" + sDate2 + "'  ";
            sSQL2 += " and FBillType=0 ";
            sSQL2 += " AND isnull(FAccountID,'')<>''";
            sSQL2 += " AND EXISTS(SELECT * FROM t_Department WHERE r.FDepartment=FItemID AND FItemID<>0 and FNumber= '10.12') ";

            dMonthMoney += CalculatePrice(sSQL, sSQL) + CalculatePrice(sSQL2, sSQL2);

            sSQL = "  SELECT CAST(ISNULL(SUM(FAmount),0)/10000 AS DECIMAL(18,2)) FROM t_RP_NewReceiveBill r WHERE FFincDate>='" + sDate + "' and FFincDate<='" + sDate2 + "'   ";
            sSQL += " and FBillType=1000 ";
            sSQL += " AND FExplanation not like '%礼券%'";
            sSQL += " AND isnull(FAccountID,'')<>''";
            sSQL += " AND EXISTS(SELECT * FROM t_Department WHERE r.FDepartment=FItemID AND FItemID<>0 and FNumber= '10.13') ";

            sSQL2 = "  SELECT CAST(ISNULL(SUM(FAmount),0)/10000 AS DECIMAL(18,2)) FROM t_RP_NewReceiveBill r WHERE FFincDate>='" + sDate + "'  and FFincDate<='" + sDate2 + "'  ";
            sSQL2 += " and FBillType=0 ";
            sSQL2 += " AND isnull(FAccountID,'')<>''";
            sSQL2 += " AND EXISTS(SELECT * FROM t_Department WHERE r.FDepartment=FItemID AND FItemID<>0 and FNumber= '10.13') ";

            dMonthMoney += CalculatePrice(sSQL, sSQL) + CalculatePrice(sSQL2, sSQL2);



            sSQL = "  SELECT CAST(ISNULL(SUM(FAmount),0)/10000 AS DECIMAL(18,2)) FROM t_RP_NewReceiveBill r WHERE FFincDate>='" + sDate + "'  and FFincDate<='" + sDate2 + "'  ";
            sSQL += " and FBillType=1000 ";
            sSQL += " AND isnull(FAccountID,'')<>''";
            sSQL += " AND EXISTS(SELECT * FROM t_Department WHERE r.FDepartment=FItemID AND FItemID<>0 and FNumber= '10.14') ";


            sSQL2 = "  SELECT CAST(ISNULL(SUM(FAmount),0)/10000 AS DECIMAL(18,2)) FROM t_RP_NewReceiveBill r WHERE FFincDate>='" + sDate + "'  and FFincDate<='" + sDate2 + "'  ";
            sSQL2 += " and FBillType=0 ";
            sSQL2 += " AND isnull(FAccountID,'')<>''";
            sSQL2 += " AND EXISTS(SELECT * FROM t_Department WHERE r.FDepartment=FItemID AND FItemID<>0 and FNumber= '10.14') ";

            dMonthMoney += CalculatePrice(sSQL, sSQL) + CalculatePrice(sSQL2, sSQL2);



            sSQL = "  SELECT CAST(ISNULL(SUM(FAmount),0)/10000 AS DECIMAL(18,2)) FROM t_RP_NewReceiveBill r WHERE FFincDate>='" + sDate + "'  and FFincDate<='" + sDate2 + "'  ";
            sSQL += " and FBillType=1000 ";
            sSQL += " AND isnull(FAccountID,'')<>''";
            sSQL += " AND EXISTS(SELECT * FROM t_Department WHERE r.FDepartment=FItemID AND FItemID<>0 and FNumber= '10.15') ";


            sSQL2 = "  SELECT CAST(ISNULL(SUM(FAmount),0)/10000 AS DECIMAL(18,2)) FROM t_RP_NewReceiveBill r WHERE FFincDate>='" + sDate + "'  and FFincDate<='" + sDate2 + "'  ";
            sSQL2 += " and FBillType=0 ";
            sSQL2 += " AND isnull(FAccountID,'')<>''";
            sSQL2 += " AND EXISTS(SELECT * FROM t_Department WHERE r.FDepartment=FItemID AND FItemID<>0 and FNumber= '10.15') ";

            dMonthMoney += CalculatePrice(sSQL, sSQL) + CalculatePrice(sSQL2, sSQL2);


            sSQL = "  SELECT CAST(ISNULL(SUM(FAmount),0)/10000 AS DECIMAL(18,2)) FROM t_RP_NewReceiveBill r WHERE FFincDate>='" + sDate + "'  and FFincDate<='" + sDate2 + "'  ";
            sSQL += " and FBillType=1000 ";
            sSQL += " AND isnull(FAccountID,'')<>''";
            sSQL += " AND EXISTS(SELECT * FROM t_Department WHERE r.FDepartment=FItemID AND FItemID<>0 and FNumber= '10.16') ";

            sSQL2 = "  SELECT CAST(ISNULL(SUM(FAmount),0)/10000 AS DECIMAL(18,2)) FROM t_RP_NewReceiveBill r WHERE FFincDate>='" + sDate + "'  and FFincDate<='" + sDate2 + "'  ";
            sSQL2 += " and FBillType=0 ";
            sSQL2 += " AND isnull(FAccountID,'')<>''";
            sSQL2 += " AND EXISTS(SELECT * FROM t_Department WHERE r.FDepartment=FItemID AND FItemID<>0 and FNumber= '10.16') ";

            dMonthMoney += CalculatePrice(string.Empty, sSQL) + CalculatePrice(string.Empty, sSQL2);


            sSQL = "  SELECT CAST(ISNULL(SUM(FAmount),0)/10000 AS DECIMAL(18,2)) FROM t_RP_NewReceiveBill r WHERE FFincDate>='" + sDate + "'  and FFincDate<='" + sDate2 + "'  ";
            sSQL += " and FBillType=1000 ";
            sSQL += " AND isnull(FAccountID,'')<>''";
            sSQL += " AND EXISTS(SELECT * FROM t_Department WHERE r.FDepartment=FItemID AND FItemID<>0 and FNumber= '10.17') ";


            sSQL2 = "  SELECT CAST(ISNULL(SUM(FAmount),0)/10000 AS DECIMAL(18,2)) FROM t_RP_NewReceiveBill r WHERE FFincDate>='" + sDate + "'  and FFincDate<='" + sDate2 + "'  ";
            sSQL2 += " and FBillType=0 ";
            sSQL2 += " AND isnull(FAccountID,'')<>''";
            sSQL2 += " AND EXISTS(SELECT * FROM t_Department WHERE r.FDepartment=FItemID AND FItemID<>0 and FNumber= '10.17') ";

            dMonthMoney += CalculatePrice(sSQL, sSQL) + CalculatePrice(sSQL2, sSQL2);


            sSQL = "  SELECT CAST(ISNULL(SUM(FAmount),0)/10000 AS DECIMAL(18,2)) FROM t_RP_NewReceiveBill r WHERE FFincDate>='" + sDate + "'  and FFincDate<='" + sDate2 + "'  ";
            sSQL += " and FBillType=1000 ";
            sSQL += " AND isnull(FAccountID,'')<>''";
            sSQL += " AND EXISTS(SELECT * FROM t_Department WHERE r.FDepartment=FItemID AND FItemID<>0 and FNumber= '10.18') ";
            dMonthMoney += CalculatePrice(sSQL, sSQL);


            sSQL = "  SELECT CAST(ISNULL(SUM(FAmount),0)/10000 AS DECIMAL(18,2)) FROM t_RP_NewReceiveBill r WHERE FFincDate>='" + sDate + "'  and FFincDate<='" + sDate2 + "'  ";
            sSQL += " and FBillType=1000 ";
            sSQL += " AND isnull(FAccountID,'')<>''";
            sSQL += " AND EXISTS(SELECT * FROM t_Department WHERE r.FDepartment=FItemID AND FItemID<>0 and FNumber= '10.19') ";


            sSQL2 = "  SELECT CAST(ISNULL(SUM(FAmount),0)/10000 AS DECIMAL(18,2)) FROM t_RP_NewReceiveBill r WHERE FFincDate>='" + sDate + "'  and FFincDate<='" + sDate2 + "'  ";
            sSQL2 += " and FBillType=0 ";
            sSQL2 += " AND isnull(FAccountID,'')<>''";
            sSQL2 += " AND EXISTS(SELECT * FROM t_Department WHERE r.FDepartment=FItemID AND FItemID<>0 and FNumber= '10.19') ";

            dMonthMoney += CalculatePrice(sSQL, sSQL) + CalculatePrice(sSQL2, sSQL2);




            sSQL = "  SELECT CAST(ISNULL(SUM(FAmount),0)/10000 AS DECIMAL(18,2)) FROM t_RP_NewReceiveBill r WHERE FFincDate>='" + sDate + "'  and FFincDate<='" + sDate2 + "'  ";
            sSQL += " and FBillType=1000 ";
            sSQL += " AND isnull(FAccountID,'')<>''";
            sSQL += " AND EXISTS(SELECT * FROM t_Department WHERE r.FDepartment=FItemID AND FItemID<>0 and FNumber= '10.20') ";


            sSQL2 = "  SELECT CAST(ISNULL(SUM(FAmount),0)/10000 AS DECIMAL(18,2)) FROM t_RP_NewReceiveBill r WHERE FFincDate>='" + sDate + "'  and FFincDate<='" + sDate2 + "'  ";
            sSQL2 += " and FBillType=0 ";
            sSQL2 += " AND isnull(FAccountID,'')<>''";
            sSQL2 += " AND EXISTS(SELECT * FROM t_Department WHERE r.FDepartment=FItemID AND FItemID<>0 and FNumber= '10.20') ";

            dMonthMoney += CalculatePrice(sSQL, sSQL) + CalculatePrice(sSQL2, sSQL2);



            sSQL = "  SELECT CAST(ISNULL(SUM(FAmount),0)/10000 AS DECIMAL(18,2)) FROM t_RP_NewReceiveBill r WHERE FFincDate>='" + sDate + "'  and FFincDate<='" + sDate2 + "'  ";
            sSQL += " and FBillType=1000 ";
            sSQL += " AND isnull(FAccountID,'')<>''";
            sSQL += " AND EXISTS(SELECT * FROM t_Department WHERE r.FDepartment=FItemID AND FItemID<>0 and FNumber= '10.21') ";


            sSQL2 = "  SELECT CAST(ISNULL(SUM(FAmount),0)/10000 AS DECIMAL(18,2)) FROM t_RP_NewReceiveBill r WHERE FFincDate>='" + sDate + "'  and FFincDate<='" + sDate2 + "'  ";
            sSQL2 += " and FBillType=0 ";
            sSQL2 += " AND isnull(FAccountID,'')<>''";
            sSQL2 += " AND EXISTS(SELECT * FROM t_Department WHERE r.FDepartment=FItemID AND FItemID<>0 and FNumber= '10.21') ";

            dMonthMoney += CalculatePrice(sSQL, sSQL) + CalculatePrice(sSQL2, sSQL2);




            return dMonthMoney;
        }
        /// <summary>
        /// 经营表查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            this.tabControl1.SelectedIndex = 0;
            Ftype = 0;
            WaitFormService.CreateWaitForm();
            WaitFormService.SetWaitFormCaption("数据正在处理......");
            this.label2.Text = " 正在读取表格数据......";
            SqlParameter param1 = new SqlParameter("@BegDate", SqlDbType.VarChar);
            param1.Value = this.dateTimePicker1.Value.ToShortDateString();
            SqlParameter param2 = new SqlParameter("@EndDate", SqlDbType.VarChar);
            param2.Value = this.dateTimePicker1.Value.ToShortDateString(); 
            SqlParameter param3 = new SqlParameter("@fdepnumber", SqlDbType.VarChar);
            param3.Value = "";
            SqlParameter param4 = new SqlParameter("@fType", SqlDbType.VarChar);
            param4.Value = "1";
            if (PropertyClass.OperatorName == "李桂炫") //如果不是李桂炫
            {
                param4.Value = "0";
            }

            //创建泛型
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(param1);
            parameters.Add(param2);
            parameters.Add(param3);
            parameters.Add(param4);

            //把泛型中的元素复制到数组中
            SqlParameter[] inputParameters = parameters.ToArray();
            try
            {
                ds = db.GetProcDataSet("sp_sel_rsjyb_New_qiu", inputParameters);
                this.dataGridView1.DataSource = ds.Tables[0];


                //dsMoney = db.GetProcDataSet("sp_sel_rsjyb_Money_qiu", inputParameters);
                //this.dataGridView2.DataSource = dsMoney.Tables[0];

                //for (int i = 0; i < this.dataGridView2.Columns.Count; i++)
                //{
                //    if (i > 2)
                //        this.dataGridView2.Columns[i].Width = 150;
                //}

                
                    this.label2.Text = " 读取经营数据完成.";
                WaitFormService.CloseWaitForm();
           

            }
            catch (Exception err)
            {
                WaitFormService.CloseWaitForm();
                MessageBox.Show("操作失败！" + err.ToString());
                this.label2.Text = " 读取经营数据失败.";

            }

        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void BOTTOMLAY_Paint(object sender, PaintEventArgs e)
        {

        }

        private void topLAY_Paint(object sender, PaintEventArgs e)
        {

        }

        private void BOTTOM2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void midlay_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void toolStripSeparator1_Click(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// 读取EXCEL
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            string excelFileName = "";
            openFileDialog1.FileName = "";
            //openFileDialog1.Filter = "EXCEL文件(*.xls,*.xlsx)|*.xls,*.xlsx";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                excelFileName = openFileDialog1.FileName;
                bind(excelFileName);
            }
        }
        /// <summary>
        /// 手动导入每日成本
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripButton2_Click_1(object sender, EventArgs e)
        {
            WaitFormService.CreateWaitForm();
            WaitFormService.SetWaitFormCaption("数据正在处理......");

            this.label2.Text = " 正在读取表格数据......";
            List<string> strSqls = new List<string>();
            if (this.dataGridView2Price.RowCount == 0)
            {
                return;
            }

            string sSQL = string.Empty;

            //清空临时数据
            strSqls.Add("  DELETE yx_rs_ysprice_CHECK WHERE FuserName='" + PropertyClass.OperatorName + "'");
            strSqls.Add("  DELETE yx_rs_DayHeadNum_Check WHERE FuserName='" + PropertyClass.OperatorName + "'");

            sSQL += " DELETE yx_rs_ysprice_CHECK WHERE FuserName='" + PropertyClass.OperatorName + "'";
            sSQL += " DELETE yx_rs_DayHeadNum_Check WHERE FuserName='" + PropertyClass.OperatorName + "'";

            DataRow dr = null;
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {

                dr = ds.Tables[0].Rows[i];
                strSqls.Add(" INSERT INTO yx_rs_ysprice_CHECK(Fnumber,Fprice,FDATE,FuserName)  VALUES  ( '" + dr["编码"].ToString() + "'," + dr["成本单价"].ToString() + ",'" + dr["日期"].ToString() + "','" + PropertyClass.OperatorName + "') ");
                sSQL += " INSERT INTO yx_rs_ysprice_CHECK(Fnumber,Fprice,FDATE,FuserName)  VALUES  ( '" + dr["编码"].ToString() + "'," + dr["成本单价"].ToString() + ",'" + dr["日期"].ToString() + "','" + PropertyClass.OperatorName + "') ";

            }

            //处理当天屠宰头数

            for (int i = 0; i < dsDayHeadNum.Tables[0].Rows.Count; i++)
            {
                dr = dsDayHeadNum.Tables[0].Rows[i];
                strSqls.Add(" INSERT INTO yx_rs_DayHeadNum_Check(FDATE,FDayHeadNum,FuserName)  VALUES  ( '" + dr["日期"].ToString() + "'," + dr["当天屠宰头数"].ToString() + ",'" + PropertyClass.OperatorName + "') ");
                sSQL += "  INSERT INTO yx_rs_DayHeadNum_Check(FDATE,FDayHeadNum,FuserName)  VALUES  ( '" + dr["日期"].ToString() + "'," + dr["当天屠宰头数"].ToString() + ",'" + PropertyClass.OperatorName + "')";
            }




            if (!db.ExecDataBySqls(strSqls))
            {
                this.label2.Text = " 读取表格数据失败!";
                WaitFormService.CloseWaitForm();
                MessageBox.Show("保存失败！", "软件提示");
                return;
            }



            SqlParameter param = new SqlParameter("@FuserName", SqlDbType.VarChar);
            param.Value = PropertyClass.OperatorName;
            //创建泛型
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(param);
            //把泛型中的元素复制到数组中
            SqlParameter[] inputParameters = parameters.ToArray();
            //存储过程 
            DataRow drc = null;
            drc = db.GetDataTable("sp_checkToyx_rs_ysprice ", inputParameters).Rows[0];
            if (drc["isok"].ToString() == "-1")
            {
                //this.toolStripStatusLabel1.Text = " 表格数据检查失败!";
                WaitFormService.CloseWaitForm();
                MessageBox.Show("保存失败:" + drc["msg"].ToString(), "软件提示");
                return;
            }

            this.label2.Text = " 开始写入K3......";

            SqlParameter param2 = new SqlParameter("@FuserName", SqlDbType.VarChar);
            param2.Value = PropertyClass.OperatorName;
            //创建泛型
            List<SqlParameter> parameters2 = new List<SqlParameter>();
            parameters2.Add(param2);
            //把泛型中的元素复制到数组中
            SqlParameter[] inputParameters2 = parameters2.ToArray();
            try
            {
                db.GetProcRow("sp_insertToyx_rs_ysprice", inputParameters2);
                //this.toolStripStatusLabel1.Text = " 表格数据导入成功!";
                WaitFormService.CloseWaitForm();
                MessageBox.Show("成功导入K3!", "软件提示");
                this.dataGridView1.DataSource = null;

            }
            catch (Exception ex)
            {
                //this.toolStripStatusLabel1.Text = " 表格数据导入失败!";
                WaitFormService.CloseWaitForm();
                MessageBox.Show("导入K3失败!" + ex.ToString(), "软件提示");

            }

        }

        private void toolStripSeparator2_Click(object sender, EventArgs e)
        {

        }

        private void toolStripSeparator3_Click(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// 自动导入每日成本
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            #region 判断
            string sSQL = string.Empty;
            string sFindDate = Convert.ToDateTime(dateTimePicker1.Text).ToString("yyyy-MM-dd");
            sSQL = " SELECT * FROM t_yxryCost WHERE FFDate='" + sFindDate + "'";
            DataTable dttCount = dbRY.GetDataTable(sSQL, "A");
            if (dttCount.Rows.Count == 0)
            {
                MessageBox.Show("日期：" + sFindDate + " 报表数据未生成，无法自动导入");
                return;
            }

            #endregion

            #region 处理临时表数据
            WaitFormService.CreateWaitForm();
            WaitFormService.SetWaitFormCaption("数据正在处理......");

            //this.toolStripStatusLabel1.Text = " 正在读取数据......";

            //执行读取报表数据
            SqlParameter param02 = new SqlParameter("@Fdate", SqlDbType.VarChar);
            param02.Value = sFindDate;
            SqlParameter param01 = new SqlParameter("@FuserName", SqlDbType.VarChar);
            param01.Value = PropertyClass.OperatorName;

            //创建泛型
            List<SqlParameter> parameters01 = new List<SqlParameter>();
            parameters01.Add(param02);
            parameters01.Add(param01);
            SqlParameter[] inputParameters01 = parameters01.ToArray();

            DataBase db2 = new DataBase();

            try
            {
                db2.GetProcRow("sp_yxryCostAutoImport_czq", inputParameters01);
                //this.toolStripStatusLabel1.Text = " 数据读取成功!";

            }
            catch (Exception ex)
            {
                //this.toolStripStatusLabel1.Text = " 数据读取失败!";
                WaitFormService.CloseWaitForm();
                MessageBox.Show("数据读取失败！", "软件提示");
                return;
            }

            #endregion

            #region 调用原来方法执行
            //this.toolStripStatusLabel1.Text = " 开始检查数据......";

            SqlParameter param = new SqlParameter("@FuserName", SqlDbType.VarChar);
            param.Value = PropertyClass.OperatorName;
            //创建泛型
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(param);
            //把泛型中的元素复制到数组中
            SqlParameter[] inputParameters = parameters.ToArray();
            //存储过程 
            DataRow drc = null;
            drc = db.GetDataTable("sp_checkToyx_rs_ysprice ", inputParameters).Rows[0];
            if (drc["isok"].ToString() == "-1")
            {
                //this.toolStripStatusLabel1.Text = " 表格数据检查失败!";
                WaitFormService.CloseWaitForm();
                MessageBox.Show("保存失败:" + drc["msg"].ToString(), "软件提示");
                return;
            }

            //this.toolStripStatusLabel1.Text = " 开始写入K3......";

            SqlParameter param2 = new SqlParameter("@FuserName", SqlDbType.VarChar);
            param2.Value = PropertyClass.OperatorName;
            //创建泛型
            List<SqlParameter> parameters2 = new List<SqlParameter>();
            parameters2.Add(param2);
            //把泛型中的元素复制到数组中
            SqlParameter[] inputParameters2 = parameters2.ToArray();
            try
            {
                db.GetProcRow("sp_insertToyx_rs_ysprice", inputParameters2);
                //this.toolStripStatusLabel1.Text = " 表格数据导入成功!";
                WaitFormService.CloseWaitForm();
                MessageBox.Show("成功导入K3!", "软件提示");
                this.dataGridView1.DataSource = null;

            }
            catch (Exception ex)
            {
                //this.toolStripStatusLabel1.Text = " 表格数据导入失败!";
                WaitFormService.CloseWaitForm();
                MessageBox.Show("导入K3失败!" + ex.ToString(), "软件提示");

            }

            #endregion
        }

        private void toolStripLabel3_Click(object sender, EventArgs e)
        {
            #region 判断
            string sSQL = string.Empty;
            string sFindDate = Convert.ToDateTime(dateTimePicker1.Text).ToString("yyyy-MM-dd");
            sSQL = " SELECT * FROM t_yxryCost WHERE FFDate='" + sFindDate + "'";
            DataTable dttCount = dbRY.GetDataTable(sSQL, "A");
            if (dttCount.Rows.Count == 0)
            {
                MessageBox.Show("日期：" + sFindDate + " 报表数据未生成，无法自动导入");
                return;
            }

            #endregion

            #region 处理临时表数据
            WaitFormService.CreateWaitForm();
            WaitFormService.SetWaitFormCaption("数据正在处理......");

            //this.toolStripStatusLabel1.Text = " 正在读取数据......";

            //执行读取报表数据
            SqlParameter param02 = new SqlParameter("@Fdate", SqlDbType.VarChar);
            param02.Value = sFindDate;
            SqlParameter param01 = new SqlParameter("@FuserName", SqlDbType.VarChar);
            param01.Value = PropertyClass.OperatorName;

            //创建泛型
            List<SqlParameter> parameters01 = new List<SqlParameter>();
            parameters01.Add(param02);
            parameters01.Add(param01);
            SqlParameter[] inputParameters01 = parameters01.ToArray();

            DataBase db2 = new DataBase();

            try
            {
                db2.GetProcRow("sp_yxryCostAutoImport_czq", inputParameters01);
                //this.toolStripStatusLabel1.Text = " 数据读取成功!";

            }
            catch (Exception ex)
            {
                //this.toolStripStatusLabel1.Text = " 数据读取失败!";
                WaitFormService.CloseWaitForm();
                MessageBox.Show("数据读取失败！", "软件提示");
                return;
            }

            #endregion

            #region 调用原来方法执行
            //this.toolStripStatusLabel1.Text = " 开始检查数据......";

            SqlParameter param = new SqlParameter("@FuserName", SqlDbType.VarChar);
            param.Value = PropertyClass.OperatorName;
            //创建泛型
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(param);
            //把泛型中的元素复制到数组中
            SqlParameter[] inputParameters = parameters.ToArray();
            //存储过程 
            DataRow drc = null;
            drc = db.GetDataTable("sp_checkToyx_rs_ysprice ", inputParameters).Rows[0];
            if (drc["isok"].ToString() == "-1")
            {
                //this.toolStripStatusLabel1.Text = " 表格数据检查失败!";
                WaitFormService.CloseWaitForm();
                MessageBox.Show("保存失败:" + drc["msg"].ToString(), "软件提示");
                return;
            }

            //this.toolStripStatusLabel1.Text = " 开始写入K3......";

            SqlParameter param2 = new SqlParameter("@FuserName", SqlDbType.VarChar);
            param2.Value = PropertyClass.OperatorName;
            //创建泛型
            List<SqlParameter> parameters2 = new List<SqlParameter>();
            parameters2.Add(param2);
            //把泛型中的元素复制到数组中
            SqlParameter[] inputParameters2 = parameters2.ToArray();
            try
            {
                db.GetProcRow("sp_insertToyx_rs_ysprice", inputParameters2);
                //this.toolStripStatusLabel1.Text = " 表格数据导入成功!";
                WaitFormService.CloseWaitForm();
                MessageBox.Show("成功导入K3!", "软件提示");
                this.dataGridView1.DataSource = null;

            }
            catch (Exception ex)
            {
                //this.toolStripStatusLabel1.Text = " 表格数据导入失败!";
                WaitFormService.CloseWaitForm();
                MessageBox.Show("导入K3失败!" + ex.ToString(), "软件提示");

            }

            #endregion
        }

        private void toolStripSeparator4_Click(object sender, EventArgs e)
        {

        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            CommExcel.ExportExcel("", dataGridView1, true);
        }

        private void toolStripLabel4_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 0;
            CommExcel.ExportExcel("", dataGridView1, true);
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            CommExcel.ExportExcel("", dataGridView2Price, true);
        }

        private void toolStripSeparator5_Click(object sender, EventArgs e)
        {

        }

        private void toolStripLabel5_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 1;
            CommExcel.ExportExcel("", dataGridView2Price, true);
        }

        private void toolStripSeparator6_Click(object sender, EventArgs e)
        {

        }

        private void toolStrip2_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void toolStripLabel6_Click(object sender, EventArgs e)
        {

        }

        private void splitContainer1_SplitterMoved(object sender, SplitterEventArgs e)
        {

        }

        private void splitContainer2_SplitterMoved(object sender, SplitterEventArgs e)
        {

        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void splitContainer3_SplitterMoved(object sender, SplitterEventArgs e)
        {

        }

        private void dataGridView2Price_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void panel6_Paint(object sender, PaintEventArgs e)
        {

        }

        private void midcontrol_Click(object sender, EventArgs e)
        {

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel7_Paint(object sender, PaintEventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel8_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel9_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void tabPage3_Click(object sender, EventArgs e)
        {

        }

        private void FRMRSJYB_Load(object sender, EventArgs e)
        {
            DataTable dttSP = db.GetDataTable(" SELECT Fdbstr FROM YXZTLIST WHERE ID=1 ", "SP");
            DataTable dttRY = db.GetDataTable(" SELECT Fdbstr FROM YXZTLIST WHERE ID=2 ", "RY");
            if (dttSP.Rows.Count > 0)
            {
                sSPConn = dttSP.Rows[0][0].ToString();
            }
            if (dttRY.Rows.Count > 0)
            {
                sRYConn = dttRY.Rows[0][0].ToString();
            }

            dbSP = new DataBase(sSPConn);
            dbRY = new DataBase(sRYConn);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.tabControl1.SelectedIndex = 0;
            Ftype = 0;
            WaitFormService.CreateWaitForm();
            WaitFormService.SetWaitFormCaption("数据正在处理......");
            this.label2.Text = " 正在读取表格数据......";
            SqlParameter param1 = new SqlParameter("@BegDate", SqlDbType.VarChar);
            param1.Value = this.dateTimePicker1.Value.ToShortDateString();
            SqlParameter param2 = new SqlParameter("@EndDate", SqlDbType.VarChar);
            param2.Value = this.dateTimePicker1.Value.ToShortDateString();
            SqlParameter param3 = new SqlParameter("@fdepnumber", SqlDbType.VarChar);
            param3.Value = "";
            SqlParameter param4 = new SqlParameter("@fType", SqlDbType.VarChar);
            param4.Value = "1";
            if (PropertyClass.OperatorName == "李桂炫") //如果不是李桂炫
            {
                param4.Value = "0";
            }

            //创建泛型
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(param1);
            parameters.Add(param2);
            parameters.Add(param3);
            parameters.Add(param4);

            //把泛型中的元素复制到数组中
            SqlParameter[] inputParameters = parameters.ToArray();
            try
            {
            


                dsMoney = db.GetProcDataSet("sp_sel_rsjyb_Money_qiu", inputParameters);
                this.dataGridView2.DataSource = dsMoney.Tables[0];

                for (int i = 0; i < this.dataGridView2.Columns.Count; i++)
                {
                    if (i > 2)
                        this.dataGridView2.Columns[i].Width = 150;
                }


                this.label2.Text = " 读取回款数据完成.";
                WaitFormService.CloseWaitForm();


            }
            catch (Exception err)
            {
                WaitFormService.CloseWaitForm();
                MessageBox.Show("操作失败！" + err.ToString());
                this.label2.Text = " 读取回款数据失败.";

            }




                List<string> sDate = new List<string>();
                DateTime dt1 = Convert.ToDateTime(dateTimePicker1.Text);
                DateTime dt2 = Convert.ToDateTime(dateTimePicker1.Text);

                while (dt1 <= dt2)
                {
                    sDate.Add(dt1.ToString("yyyy-MM-dd"));
                    dt1 = dt1.AddDays(1);
                }

                string sSQL = string.Empty;
                sSQL += " SELECT FNumber,FName FROM dbo.t_Department  ";
                sSQL += " WHERE 1=1 ";

                {
                    sSQL += " And FNumber IN('10.11','10.12','10.13','10.14','10.15','10.16','10.17','10.19','10.20','10.21') ";
                }
                sSQL += " ORDER BY FNumber ";
                DataTable dDepart = new DataTable();
                dDepart = dbRY.GetDataTable(sSQL, "A");

                DataTable dt = new DataTable(); //自定义表
                dt.Columns.Add("日期");
                dt.Columns.Add("部门代码");
                dt.Columns.Add("部门名称");

                foreach (string s in sDate)
                {
                    for (int i = 0; i < dDepart.Rows.Count; i++)
                    {
                        DataRow dtr = dt.NewRow();
                        dtr["日期"] = s;
                        dtr["部门代码"] = dDepart.Rows[i]["FNumber"];
                        dtr["部门名称"] = dDepart.Rows[i]["FName"];
                        dt.Rows.Add(dtr);
                    }
                    DataRow dtr2 = dt.NewRow();
                    dtr2["日期"] = s;
                    dtr2["部门代码"] = "本日小计";
                    dtr2["部门名称"] = "本日小计";
                    dt.Rows.Add(dtr2);

                }
                NewMethod(dt);

  
        }
        /// <summary>
        /// 双击表格事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridView1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (this.button1.Enabled == false)
            {
                MessageBox.Show("没有权限");
                return;

            }
            string name0 = this.dataGridView1.Columns[e.ColumnIndex].Name;

            if ((this.dataGridView1.Rows.Count >= 1 && Ftype == 0) && (name0 == "日期") && (name0 != "合计"))
            {

                this.textBox2.Text = this.dataGridView1[0, e.RowIndex].Value.ToString() + "" +
                                     this.dataGridView1[2, e.RowIndex].Value.ToString() + "经营情况:";

                if (this.dataGridView1[1, e.RowIndex].Value.ToString() == "10.12" || this.dataGridView1[1, e.RowIndex].Value.ToString() == "10.13" || this.dataGridView1[1, e.RowIndex].Value.ToString() == "10.11")
                {

                    if (this.dataGridView1[3, e.RowIndex].Value.ToString() != "")
                    {
                        this.textBox2.Text = this.textBox2.Text + "头数:" + Math.Round(double.Parse(this.dataGridView1[3, e.RowIndex].Value.ToString()), 0) + "头,";
                    }

                }

                this.textBox2.Text = this.textBox2.Text + "销量" +
                                 Math.Round(double.Parse(this.dataGridView1[4, e.RowIndex].Value.ToString()), 0) + "KG、收入:" +
                                 Math.Round(double.Parse(this.dataGridView1[5, e.RowIndex].Value.ToString()), 0) + "元、成本" +
                                 Math.Round(double.Parse(this.dataGridView1[6, e.RowIndex].Value.ToString()), 0) + "元、毛利" +
                                 Math.Round(double.Parse(this.dataGridView1[7, e.RowIndex].Value.ToString()), 0) + "元、本月累计数量" +
                                 Math.Round(double.Parse(this.dataGridView1[10, e.RowIndex].Value.ToString()), 0) + "元、本月累计收入" +
                                 Math.Round(double.Parse(this.dataGridView1[11, e.RowIndex].Value.ToString()), 0) + "元、本月累计毛利" +
                                 Math.Round(double.Parse(this.dataGridView1[13, e.RowIndex].Value.ToString()), 0) + "元、";
                if (this.dataGridView1[1, e.RowIndex].Value.ToString() == "10.12" || this.dataGridView1[1, e.RowIndex].Value.ToString() == "10.13" || this.dataGridView1[1, e.RowIndex].Value.ToString() == "10.11")
                {
                    if (this.dataGridView1[8, e.RowIndex].Value.ToString() != "")
                    {
                        this.textBox2.Text = this.textBox2.Text + "单头毛利:" +
                                                 Math.Round(double.Parse(this.dataGridView1[8, e.RowIndex].Value.ToString()), 0) + "元、";
                    }
                }


                if (this.dataGridView1[9, e.RowIndex].Value.ToString() != "")
                {
                    this.textBox2.Text = this.textBox2.Text + "当天屠宰:" +
                                                                                Math.Round(double.Parse(this.dataGridView1[9, e.RowIndex].Value.ToString()), 0) + "头、";
                }
                string sSQL = " SELECT  ISNULL(SUM(ISNULL(FDayHeadNum,0)),0) AS TotalCount FROM  yx_rs_DayHeadNum where FDate<='" + this.dataGridView1[0, e.RowIndex].Value.ToString() + "'  and  SUBSTRING(CONVERT(VARCHAR(12),fDate,23),1,7) ='" + this.dataGridView1[0, e.RowIndex].Value.ToString().Substring(0, 7) + "' ";
                DataTable dttTemp = db.GetDataTable(sSQL, "aa");

                if (dttTemp.Rows[0][0].ToString() != "")
                {
                    this.textBox2.Text = this.textBox2.Text + "当月累计屠宰头数:" +
                                                     Math.Round(double.Parse(dttTemp.Rows[0][0].ToString()), 0) + "头。";
                }
           

            }


            //if ((this.dataGridView1.Rows.Count >= 1 && Ftype == 0) && (name0 == "成本"))
            //{
            //    if ((this.dataGridView1[1, e.RowIndex].Value.ToString() != "10.11"))
            //    {
            //        frmJYBMX frmJYBMX = new frmJYBMX();
            //        frmJYBMX.fdate = this.dataGridView1[0, e.RowIndex].Value.ToString();
            //        frmJYBMX.fdepnum = this.dataGridView1[1, e.RowIndex].Value.ToString();
            //        frmJYBMX.Show();
            //    }
            //}



            //门店头数
            if ((this.dataGridView1.Rows.Count >= 1 && Ftype == 0) && (name0 == "头数"))
            {
                if (this.dataGridView1[1, e.RowIndex].Value.ToString() == "10.11")
                {
                    frmmdts frmmdts = new frmmdts();
                    frmmdts.fdate = this.dataGridView1[0, e.RowIndex].Value.ToString();
                    frmmdts.fdepnum = this.dataGridView1[1, e.RowIndex].Value.ToString();
                    frmmdts.Show();
                }
                else
                {
                    frmJYBMX frmJYBMX = new frmJYBMX();
                    frmJYBMX.fdate = this.dataGridView1[0, e.RowIndex].Value.ToString();
                    frmJYBMX.fdepnum = this.dataGridView1[1, e.RowIndex].Value.ToString();
                    frmJYBMX.Show();
                }


            }
            //门店数量
            if ((this.dataGridView1.Rows.Count >= 1 && Ftype == 0) && (name0 == "数量"))
            {
                if (this.dataGridView1[1, e.RowIndex].Value.ToString() == "10.11")
                {
                    frmmdsl frmmdsl = new frmmdsl();
                    frmmdsl.fdate = this.dataGridView1[0, e.RowIndex].Value.ToString();
                    frmmdsl.fdepnum = this.dataGridView1[1, e.RowIndex].Value.ToString();
                    frmmdsl.Show();
                }
                else
                {
                    frmJYBMX frmJYBMX = new frmJYBMX();
                    frmJYBMX.fdate = this.dataGridView1[0, e.RowIndex].Value.ToString();
                    frmJYBMX.fdepnum = this.dataGridView1[1, e.RowIndex].Value.ToString();
                    frmJYBMX.Show();
                }
            }


            //门店收入
            if ((this.dataGridView1.Rows.Count >= 1 && Ftype == 0) && (name0 == "收入"))
            {
                if (this.dataGridView1[1, e.RowIndex].Value.ToString() == "10.11")
                {
                    frmmdsr frmmdsr = new frmmdsr();
                    frmmdsr.fdate = this.dataGridView1[0, e.RowIndex].Value.ToString();
                    frmmdsr.fdepnum = this.dataGridView1[1, e.RowIndex].Value.ToString();
                    frmmdsr.Show();
                }
                else
                {
                    frmJYBMX frmJYBMX = new frmJYBMX();
                    frmJYBMX.fdate = this.dataGridView1[0, e.RowIndex].Value.ToString();
                    frmJYBMX.fdepnum = this.dataGridView1[1, e.RowIndex].Value.ToString();
                    frmJYBMX.Show();
                }
            }

            //门店成本
            if ((this.dataGridView1.Rows.Count >= 1 && Ftype == 0) && (name0 == "成本"))
            {
                if (this.dataGridView1[1, e.RowIndex].Value.ToString() == "10.11")
                {
                    frmmdcb frmmdcb = new frmmdcb();
                    frmmdcb.fdate = this.dataGridView1[0, e.RowIndex].Value.ToString();
                    frmmdcb.fdepnum = this.dataGridView1[1, e.RowIndex].Value.ToString();
                    frmmdcb.Show();
                }
                else
                {
                    frmJYBMX frmJYBMX = new frmJYBMX();
                    frmJYBMX.fdate = this.dataGridView1[0, e.RowIndex].Value.ToString();
                    frmJYBMX.fdepnum = this.dataGridView1[1, e.RowIndex].Value.ToString();
                    frmJYBMX.Show();
                }
            }


        }
        /// <summary>
        /// 双击回款明细过程
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridView2_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

            this.tabControl1.SelectedIndex = 3;
            Ftype = 1;
            WaitFormService.CreateWaitForm();
            WaitFormService.SetWaitFormCaption("数据正在处理......");           

            SqlParameter param1 = new SqlParameter("@BegDate", SqlDbType.DateTime);
            param1.Value = this.dateTimePicker1.Value;
            SqlParameter param2 = new SqlParameter("@EndDate", SqlDbType.DateTime);
            //param1.Value = this.dateTimePicker1.Value;
            param2.Value = this.dateTimePicker2.Value;
            //创建泛型
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(param1);
            parameters.Add(param2);
            //把泛型中的元素复制到数组中
            SqlParameter[] inputParameters = parameters.ToArray();
            try
            {
                ds = db.GetProcDataSet("sp_sel_yx_rs_ysprice", inputParameters);
                this.dataGridView4.DataSource = ds.Tables[0];
             
                WaitFormService.CloseWaitForm();
            }
            catch (Exception err)
            {
                WaitFormService.CloseWaitForm();
                MessageBox.Show("操作失败！" + err.ToString());             

            }
        }

        private void toolStripLabel6_Click_1(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 3;
            CommExcel.ExportExcel("", this.dataGridView4, true);
        }
    }
}
