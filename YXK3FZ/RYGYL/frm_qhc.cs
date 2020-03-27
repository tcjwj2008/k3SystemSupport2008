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

namespace YXK3FZ.RYGYL
{
	public partial class frm_qhc : Form
	{
		    private delegate void MyHandler();
        private frmWaiting frmwaiting = null;

				private string ZtRyconstring = "Data Source=188.188.1.10;Initial Catalog=pig1028;User ID=sa;Password=123456";


				System.Data.DataTable dttResult = new System.Data.DataTable(); 

        DataSet ds = new DataSet();//excel
				DataBase db = new DataBase(PropertyClass.con_ry);

       // DataBase db2 = new DataBase(PropertyClass.con_yxsp);
        CommonUse commUse = new CommonUse();

				public frm_qhc()
        {
            InitializeComponent();
        }

        private void ShowfrmWaiting()
        {
            frmwaiting = new frmWaiting();

            frmwaiting.ShowDialog();

           
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

					if (this.dataGridView1.RowCount == 0)
					{
						return;
					}

            WaitFormService.CreateWaitForm();
            WaitFormService.SetWaitFormCaption("数据正在处理......");

            this.toolStripStatusLabel1.Text = " 正在读取表格数据......";

				
						System.Data.DataTable myDT = new System.Data.DataTable();

						myDT.Columns.Add("DataTime", Type.GetType("System.DateTime")); //称重时间
						myDT.Columns.Add("Level_ID", Type.GetType("System.Int32"));
						myDT.Columns.Add("Weight", Type.GetType("System.Decimal")); //重量
						myDT.Columns.Add("Remark", Type.GetType("System.String"));
						myDT.Columns.Add("Level_Code", Type.GetType("System.Int32")); //等级
						myDT.Columns.Add("SubWeight", Type.GetType("System.Decimal")); //扣重
						myDT.Columns.Add("IsTransfer", Type.GetType("System.Int32"));
						myDT.Columns.Add("ShortCut", Type.GetType("System.String"));
						myDT.Columns.Add("Discount", Type.GetType("System.Decimal"));
						myDT.Columns.Add("Sequence", Type.GetType("System.Int32")); //序列号
						myDT.Columns.Add("IdentifyNum", Type.GetType("System.String")); //刺青号
						myDT.Columns.Add("IP", Type.GetType("System.String"));  //188.188.2.112
						myDT.Columns.Add("Mac", Type.GetType("System.String")); //31366888860116
						myDT.Columns.Add("IsExport", Type.GetType("System.Int32")); //1

						DataRow dtr = null;

						string sBeginTime = dttResult.Rows[0]["称重时间"].ToString().Trim();
						string sEndTime = string.Empty;

						for (int i = 0; i < dttResult.Rows.Count; i++)
						{
							dtr = myDT.NewRow();
							dtr["DataTime"] = Convert.ToDateTime(dttResult.Rows[i]["称重时间"]);
							//dtr["DataTime"] = "2017-11-01";
							dtr["Level_ID"] = DBNull.Value;
							dtr["Weight"] = Convert.ToDecimal(dttResult.Rows[i]["重量"]);
							dtr["Remark"] = DBNull.Value;
							dtr["Level_Code"] = dttResult.Rows[i]["修整后等级"];
							dtr["SubWeight"] = 0;
							dtr["IsTransfer"] = 0;
							dtr["ShortCut"] = DBNull.Value;
							dtr["Discount"] = DBNull.Value;
							dtr["Sequence"] = dttResult.Rows[i]["编号"];
							dtr["IdentifyNum"] = dttResult.Rows[i]["刺青号"].ToString().PadLeft(2,'0');
							dtr["IP"] = "188.188.2.112";
							dtr["Mac"] = "31366888860116";
							dtr["IsExport"] = 1;

							sEndTime = dttResult.Rows[i]["称重时间"].ToString().Trim();

							myDT.Rows.Add(dtr);

						}



						SqlHelper.ExecuteNonQuery(ZtRyconstring, "DELETE from Weight where DataTime >='" + sBeginTime + "' and DataTime <='" + sEndTime + "'");
						SqlBulkCopyLib.SqlBulkCopyByDatatable(ZtRyconstring, "Weight", myDT);

						WaitFormService.CloseWaitForm();
						MessageBox.Show("数据导入成功!", "软件提示");

						

               
           }      
	}
}
