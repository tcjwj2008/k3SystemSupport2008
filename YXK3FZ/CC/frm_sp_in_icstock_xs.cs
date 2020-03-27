using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
//using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Threading;
using Microsoft.Office.Interop.Excel;
using YXK3FZ.ComClass;
using YXK3FZ.DataClass;
namespace YXK3FZ.CC
{
    public partial class frm_sp_in_icstock_xs : Form
    {
        private delegate void MyHandler();
        private frmWaiting frmwaiting = null;

				System.Data.DataTable dttResult = new System.Data.DataTable(); 

        DataSet ds = new DataSet();//excel
        DataBase db = new DataBase(PropertyClass.con_yxsp);
       // DataBase db2 = new DataBase(PropertyClass.con_yxsp);
        CommonUse commUse = new CommonUse();
        public frm_sp_in_icstock_xs()
        {
            InitializeComponent();
        }

        private void ShowfrmWaiting()
        {
            frmwaiting = new frmWaiting();

            frmwaiting.ShowDialog();

            //frmwaiting = null;
        }

        public void ThreadFun()
        {
            this.BeginInvoke(new MyHandler(ShowfrmWaiting));
            Thread.Sleep(6000);
            this.Invoke(new MyHandler(frmwaiting.Close));
        }

        private void btnRead_Click(object sender, EventArgs e)
        {
            string excelFileName = "";
            openFileDialog1.FileName = "";
            //openFileDialog1.Filter = "EXCEL文件(*.xls,*.xlsx)|*.xls,*.xlsx";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                
                
                excelFileName = openFileDialog1.FileName;
               
                 //bind(excelFileName); 
               // ProgressbarEx.Progress.StartProgessBar(new ProgressbarEx.ShowProgess(bind(excelFileName)));

							//
								System.Data.DataTable dt = YXK3FZ.ComClass.NewNPOIExcelHelper.GetDataTable(excelFileName);

							
								this.dataGridView1.DataSource = dt;
								dttResult = dt;



             }
        }
        private void bind(string fileName)
        {

           // string strConn = "Provider=Microsoft.Jet.OLEDB.4.0;" + "Data Source=" + fileName + ";" + "Extended Properties=Excel 8.0;";
            string strConn = "Provider=Microsoft.ACE.OLEDB.12.0;" + "Data Source=" + fileName + ";" + "Extended Properties=Excel 8.0;";
           
            OleDbConnection Excel_conn = new OleDbConnection(strConn);
         
            string SheetName = "";
            
            SheetName = GetFirstSheetNameFromExcelFileName(fileName,1);

            string strExcel = string.Format("select * from [{0}" + "$] where 称重时间 is not null ", SheetName);

            OleDbDataAdapter da = new OleDbDataAdapter(strExcel, strConn);



           

            try
            {

                da.Fill(ds);
                this.dataGridView1.DataSource = ds.Tables[0]; 

            }

            catch (Exception err)
            {
                MessageBox.Show("操作失败！" + err.ToString());

            }

        }
          //获取excel的第一个sheet的名称
        public  string GetFirstSheetNameFromExcelFileName(string filepath, int numberSheetID)
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

        private void frm_sp_in_icstock_xs_Load(object sender, EventArgs e)
        {
           // CommonUse CommonUse = new CommonUse();
            commUse.CortrolButtonEnabled(btnRead, this);
            commUse.CortrolButtonEnabled(btnInput, this);
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            this.Close();
          
        }

       

        private void btnInput_Click(object sender, EventArgs e)
        {
            //Thread thdSub = new Thread(new ThreadStart(ThreadFun));
          //  thdSub.Start();

            WaitFormService.CreateWaitForm();
            WaitFormService.SetWaitFormCaption("数据正在处理......");

            this.toolStripStatusLabel1.Text = " 正在读取表格数据......";
            List<string> strSqls = new List<string>();
            if (this.dataGridView1.RowCount == 0)
            {
                return;
            }
            strSqls.Add("  DELETE k3_2inSalelibrary WHERE FNAME='" + PropertyClass.OperatorName + "'");
            string str;
            str = "";

            DataRow dr = null;

					

            int k = 0;
            for (int i = 0; i < dttResult.Rows.Count; i++)
            {

								//dr = dttResult.Rows[i];
								//strSqls.Add(" INSERT INTO dbo.k3_2inSalelibrary(Fbillno,Fdate,Fpax,FWeight,Frank,FNAME,FSTOCK,FTS,FName1) VALUES  ( '" + dr["单号"].ToString() + "','" + dr["称重时间"].ToString()
								//            + "','" + dr["批发行"].ToString() + "'," + dr["重量"].ToString() + ",'" + dr["等级"].ToString() + "','" + PropertyClass.OperatorName + "','" + dr["仓库"].ToString() + "'," + dr["头数"].ToString() + ",'" + dr["市场"].ToString() + "') ");


								////str = str + " INSERT INTO dbo.k3_2inSalelibrary VALUES  ( '" + dr["单号"].ToString() + "','" + dr["称重时间"].ToString()
								////             + "','" + dr["批发行"].ToString() + "'," + dr["重量"].ToString() + ",'" + dr["等级"].ToString() + "','" + PropertyClass.OperatorName + "','" + dr["仓库"].ToString() + "'," + dr["头数"].ToString() + ") ";

								//k++;

							dr = dttResult.Rows[i];
							strSqls.Add(" INSERT INTO dbo.k3_2inSalelibrary(Fbillno,Fdate,Fpax,FNumberC,FNumberM,FWeight,Frank,FNAME,FSTOCK,FTS,FName1) VALUES  ( '" + dr["单号"].ToString().Trim() + "','" + dr["称重时间"].ToString().Trim()
													+ "','" + dr["批发行"].ToString().Trim() + "','" + dr["客户代码"].ToString().Trim() + "','" + dr["物料代码"].ToString().Trim() + "'," + dr["重量"].ToString().Trim() + ",'" + dr["等级"].ToString().Trim() + "','" + PropertyClass.OperatorName + "','" + dr["仓库"].ToString().Trim() + "'," + dr["头数"].ToString().Trim() + ",'" + dr["市场"].ToString().Trim() + "') ");


							str = str + " INSERT INTO dbo.k3_2inSalelibrary(Fbillno,Fdate,Fpax,FNumberC,FNumberM,FWeight,Frank,FNAME,FSTOCK,FTS,FName1) VALUES  ( '" + dr["单号"].ToString().Trim() + "','" + dr["称重时间"].ToString().Trim()
													+ "','" + dr["批发行"].ToString().Trim() + "','" + dr["客户代码"].ToString().Trim() + "','" + dr["物料代码"].ToString().Trim() + "'," + dr["重量"].ToString().Trim() + ",'" + dr["等级"].ToString().Trim() + "','" + PropertyClass.OperatorName + "','" + dr["仓库"].ToString().Trim() + "'," + dr["头数"].ToString().Trim() + ",'" + dr["市场"].ToString().Trim() + "') ";
							k++;
            }


            if (!db.ExecDataBySqls(strSqls) )
            {
                this.toolStripStatusLabel1.Text = " 读取表格数据失败!";
                WaitFormService.CloseWaitForm();
                MessageBox.Show("保存失败！", "软件提示");
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
                drc = db.GetDataTable("sp_k3_2checkinSalelibrary", inputParameters).Rows[0];
                if (drc["isok"].ToString()=="-1")
                {
                    this.toolStripStatusLabel1.Text = " 表格数据检查失败!";
                    WaitFormService.CloseWaitForm();
                    MessageBox.Show("保存失败:" + drc["msg"].ToString(), "软件提示");
                    return;
                }

							//	return;

                this.toolStripStatusLabel1.Text = " 开始写入K3......";

                int w =k/ 50+1;//由于导入记录太多会超时 改为每次导入50条
                int f=1;
                while (f<=w)
                {
                    DataBase db2 = new DataBase(PropertyClass.con_yxsp);
                    SqlParameter param2 = new SqlParameter("@username", SqlDbType.VarChar);
                    param2.Value = PropertyClass.OperatorName;
                    //创建泛型
                    List<SqlParameter> parameters2 = new List<SqlParameter>();
                    parameters2.Add(param2);
                    //把泛型中的元素复制到数组中
                    SqlParameter[] inputParameters2 = parameters2.ToArray();
                    try
                    {
                        db2.GetProcRow("sp_k3_2insertSalelibrary", inputParameters2);
                        this.toolStripStatusLabel1.Text = " 表格数据导入前" + (f * 50).ToString() + "条记录的数据成功!";
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
