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
using System.Data.SqlClient;

namespace YXK3FZ.CC
{
    public partial class frm_dzp_app_order : Form
    {

        System.Data.DataTable dttResult = new System.Data.DataTable();
        DataBase db = new DataBase(PropertyClass.con_yz);
        public frm_dzp_app_order()
        {
            InitializeComponent();
        }


        private void toolStripButton3_Click_1(object sender, EventArgs e)
        {
           this.Close(); //关闭按钮
        }
        /// <summary>
        /// 导入EXCEL文件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRead_Click(object sender, EventArgs e)
        {
            string excelFileName = "";
            openFileDialog1.FileName = "";
            //openFileDialog1.Filter = "EXCEL文件(*.xls,*.xlsx)|*.xls,*.xlsx";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                excelFileName = openFileDialog1.FileName;

                System.Data.DataTable dt = YXK3FZ.ComClass.NewNPOIExcelHelper.GetDataTable(excelFileName);
                this.dataGridView1.DataSource = dt;
                dttResult = dt;

            }
        }
        /// <summary>
        /// APP订单导入
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnInput_Click(object sender, EventArgs e)
        {
            WaitFormService.CreateWaitForm();
            WaitFormService.SetWaitFormCaption("数据正在处理......");
            this.toolStripStatusLabel1.Text = " 正在读取表格数据......";
            List<string> strSqls = new List<string>();
            if (this.dataGridView1.RowCount == 0)  //没有表格数据时直接退回
            {
                return;
            }
            strSqls.Add("  DELETE k3_2APPORDER WHERE FNAME='" + PropertyClass.OperatorName + "'");
            string str;
            str = "";

            DataRow dr = null;
            int k = 0;
            for (int i = 0; i < dttResult.Rows.Count; i++)
            {
                dr = dttResult.Rows[i];
                strSqls.Add(" INSERT INTO dbo.k3_2APPORDER([opener],[ordertime],[remarks],[state],[isread],[storeid],[storeno],[amount],[orderno] ,[productno] ,[productno1]  ,[num1]  ,[price1]  ,[amount1] ,[kind] ,[product] ,[spec] ,[cmoney] ,[cunit] ,[aigo] ,[remarks1] ,[fname]) VALUES  ( '" + dr["操作员"].ToString().Trim() + "','" + dr["订单时间"].ToString().Trim() + "','" + dr["主备注"].ToString().Trim() + "','" + dr["状态"].ToString().Trim() + "','" + dr["可读写"].ToString().Trim() + "'," + dr["门店内码"].ToString().Trim() + ",'" + dr["门店代码"].ToString().Trim() + "','" + dr["总金额"].ToString().Trim() + "','" + dr["订单号"].ToString().Trim() + "'," + dr["产品内码"].ToString().Trim() + ",'" + dr["产品代码"].ToString().Trim() + "','" + dr["数量"].ToString().Trim() + "','" + dr["单价"].ToString().Trim() + "','" + dr["金额"].ToString().Trim() + "'," + dr["分类"].ToString().Trim() + ",'" + dr["产品名称"].ToString().Trim() + "','" + dr["规格"].ToString().Trim() + "','" + dr["分录单价"].ToString().Trim() + "','" + dr["单位"].ToString().Trim() + "','" + dr["aigo"].ToString().Trim() + "','" + dr["分录备注"].ToString().Trim() + "','" + PropertyClass.OperatorName + "') ");


                                                            //str = str + " INSERT INTO dbo.k3_2APPORDER([opener],[ordertime],[remarks],[state],[isread],[storeid],[storeno],[amount],[orderno] ,[productno] ,[productno1]  ,[num1]  ,[price1]  ,[amount1] ,[kind] ,[product] ,[spec] ,[cmoney] ,[cunit] ,[agio] ,[remarks1]) VALUES  ( '" + dr["操作员"].ToString().Trim() + "','" + dr["订单时间"].ToString().Trim() + "','" + dr["主备注"].ToString().Trim() + "','" + dr["状态"].ToString().Trim() + "','" + dr["可读写"].ToString().Trim() + "'," + dr["门店内码"].ToString().Trim() + ",'" + dr["门店代码"].ToString().Trim() + "','" + dr["总金额"].ToString().Trim() + "','" + dr["订单号"].ToString().Trim() + "'," + dr["产品内码"].ToString().Trim() + ",'" + dr["产品代码"].ToString().Trim() + "','" + dr["数量"].ToString().Trim() + "','" + dr["单价"].ToString().Trim() + "','" + dr["金额"].ToString().Trim() + "'," + dr["分类"].ToString().Trim() + ",'" + dr["产品名称"].ToString().Trim() + "','" + dr["规格"].ToString().Trim() + "','" + dr["分录单价"].ToString().Trim() + "'," + dr["单位"].ToString().Trim() + "','" + dr["aigo"].ToString().Trim() + ",'" + dr["分录备注"].ToString().Trim() + "') ";
               
                k++;
            }


            if (!db.ExecDataBySqls(strSqls))
            {
                this.toolStripStatusLabel1.Text = " 读取表格数据失败!";
                WaitFormService.CloseWaitForm();
                MessageBox.Show("读取表格数据失败！" , "软件提示");
                return;
            }


            //MessageBox.Show("读取成功！", "软件提示");
            this.toolStripStatusLabel1.Text = " 开始检查数据......";

            SqlParameter param = new SqlParameter("@FNAME", SqlDbType.VarChar);
            param.Value = PropertyClass.OperatorName;
            //创建泛型
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(param);
            //把泛型中的元素复制到数组中
            SqlParameter[] inputParameters = parameters.ToArray();
            //存储过程 
            DataRow drc = null;
            drc = db.GetDataTable("sp_k3_2checkApp_qiu", inputParameters).Rows[0];
            if (drc["isok"].ToString() == "-1")
            {
                this.toolStripStatusLabel1.Text = " 表格数据检查失败!";
                WaitFormService.CloseWaitForm();
                MessageBox.Show("保存失败:" + drc["msg"].ToString(), "软件提示");
                return;
            }


            //return; //先直接返回。。。

            this.toolStripStatusLabel1.Text = " 开始写入K3......";

            int w = k / 50 + 1;//由于导入记录太多会超时 改为每次导入50条
            int f = 1;
            while (f <= w)
            {
                DataBase db2 = new DataBase(PropertyClass.con_yzyinxiang);
                SqlParameter param2 = new SqlParameter("@username", SqlDbType.VarChar);
                param2.Value = PropertyClass.OperatorName;
                //创建泛型
                List<SqlParameter> parameters2 = new List<SqlParameter>();
                parameters2.Add(param2);
                //把泛型中的元素复制到数组中
                SqlParameter[] inputParameters2 = parameters2.ToArray();
                try
                {
                    db2.GetProcRow("sp_k3_2APPORDER_QIU", inputParameters2);
                    this.toolStripStatusLabel1.Text = " 表格数据导入数据成功!";
                    // SetFormCaption
                    WaitFormService.SetWaitFormCaption("正在导入" + (f * 50).ToString() + "条记录后面的数据！");

                }
                catch (Exception ex)
                {
                    this.toolStripStatusLabel1.Text = " 表格数据导入失败!";
                    WaitFormService.CloseWaitForm();
                    MessageBox.Show("导入K3失败!" + ex.ToString(), "软件提示");
                    return;

                }



                f++;
            }
            WaitFormService.CloseWaitForm();
            MessageBox.Show("成功导入K3!", "软件提示");

           

        }
    }
}
