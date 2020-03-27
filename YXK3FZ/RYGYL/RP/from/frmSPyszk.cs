using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
//using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Office.Interop.Excel;
using YXK3FZ.ComClass;
using YXK3FZ.DataClass;
using System.Data.SqlClient;
using Excel = Microsoft.Office.Interop.Excel;
using System.Reflection;
using System.IO;   //特別引用流 System.IO
using System.Data.OleDb;
using System.Runtime.InteropServices;
using System.Collections;

namespace YXK3FZ.RP.from
{
    public partial class frmSPyszk : Form
    {
       DataSet ds = new DataSet();//excel
       DataBase db = new DataBase(PropertyClass.con_yxsp);
       CommonUse commUse = new CommonUse();
			 string ZtRyconstring = null;

        public frmSPyszk()
        {
            InitializeComponent();
						//ds = db.GetDataSet("SELECT Fdbstr  FROM YXERP.dbo.YXZTLIST WHERE ID=1", "con");
						//DataRow dr = ds.Tables[0].Rows[0];
						//ZtRyconstring = dr["Fdbstr"].ToString(); //获取K3账套连接字符串
						//db = new DataBase(ZtRyconstring);
        }

        private void frmSPyszk_Load(object sender, EventArgs e)
        {
            commUse.CortrolButtonEnabled(button1, this);
            commUse.CortrolButtonEnabled(button2, this);
            commUse.CortrolButtonEnabled(button3, this);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            WaitFormService.CreateWaitForm();
            WaitFormService.SetWaitFormCaption(" 正在计算，请稍候......");
            //string datestr = "";
            //datestr = this.dateTimePicker1.Value.ToShortDateString();
            
            //SqlParameter param1 = new SqlParameter("@BegDate", SqlDbType.VarChar);
            //param1.Value = this.dateTimePicker1.Value.ToShortDateString();

            //SqlParameter param2 = new SqlParameter("@EndDate", SqlDbType.VarChar);
            //param2.Value = this.dateTimePicker2.Value.ToShortDateString();
            ////创建泛型
            //List<SqlParameter> parameters2 = new List<SqlParameter>();
            //parameters2.Add(param1);
            //parameters2.Add(param2);
            ////把泛型中的元素复制到数组中
            //SqlParameter[] inputParameters2 = parameters2.ToArray();
            try
            {
              // this.dataGridView1.DataSource=db.GetDataTable("cdproc", inputParameters2);
               // ds = db.GetDataSet("SELECT Fdbstr    FROM dbo.YXZTLIST WHERE ID=1", "con");
               // string MyConn = ds.Tables[0].Rows[0]["Fdbstr"].ToString();
              string MyConn = "Data Source=188.188.1.4;Initial Catalog=AIS_YXSP2;User ID=sa;Password=Asd123;Connect Timeout=0";
							//MyConn = ZtRyconstring;
                SqlDataAdapter SelectAdapter = new SqlDataAdapter();
               
                SqlConnection MyConnection = new SqlConnection(MyConn);
                SqlCommand MyCommand = new SqlCommand("cdproc", MyConnection);
                MyCommand.CommandType = CommandType.StoredProcedure;
                MyCommand.Parameters.Add("@BegDate", SqlDbType.VarChar);
                MyCommand.Parameters.Add("@EndDate", SqlDbType.VarChar);
                MyCommand.Parameters["@BegDate"].Value = this.dateTimePicker1.Value.ToShortDateString();
                MyCommand.Parameters["@EndDate"].Value = this.dateTimePicker2.Value.ToShortDateString();
              
                MyConnection.Open();
                SelectAdapter.MissingSchemaAction = MissingSchemaAction.AddWithKey;
               
                SelectAdapter.SelectCommand = MyCommand;
                SelectAdapter.SelectCommand.CommandTimeout = 500;
                //SelectAdapter.SelectCommand.ExecuteNonQuery();
                MyConnection.Close();
                
                SelectAdapter.Fill(ds);
                this.dataGridView1.DataSource=ds.Tables[0];




            }
            catch (Exception ex)
            {
                WaitFormService.CloseWaitForm();
                MessageBox.Show("查询失败!" + ex.ToString(), "软件提示");
                return;

            }
            WaitFormService.CloseWaitForm();
            //MessageBox.Show("计算完成!", "软件提示");





        }

        private void button2_Click(object sender, EventArgs e)
        {

					CommExcel.ExportExcel("", dataGridView1, true);

					return;
					


            SaveFileDialog saveFileDialog = new SaveFileDialog();

            //  ToExcel2(dataGridView1, saveFileDialog);


            saveFileDialog.Filter = "Execl files (*.xls)|*.xls";
            saveFileDialog.FilterIndex = 0;
            saveFileDialog.RestoreDirectory = true;
            saveFileDialog.CreatePrompt = true;
            saveFileDialog.Title = "Export Excel File";
            saveFileDialog.ShowDialog();
            if (saveFileDialog.FileName == "")
                return;
            System.Data.DataTable Table = ds.Tables[0];
            string ExcelFilePath = saveFileDialog.FileName;

            WaitFormService.CreateWaitForm();
            WaitFormService.SetWaitFormCaption(" 正在导出，请稍候......");
            try
            {

                if ((Table.TableName.Trim().Length == 0) || (Table.TableName.ToLower() == "table"))
                {
                    Table.TableName = "Sheet1";
                }

                //数据表的列数
                int ColCount = Table.Columns.Count;

                //用于记数，实例化参数时的序号
                int i = 0;

                //创建参数
                OleDbParameter[] para = new OleDbParameter[ColCount];

                //创建表结构的SQL语句
                string TableStructStr = @"Create Table " + Table.TableName + "(";

                //连接字符串
                string connString = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + ExcelFilePath + ";Extended Properties=Excel 8.0;";
                OleDbConnection objConn = new OleDbConnection(connString);

                //创建表结构
                OleDbCommand objCmd = new OleDbCommand();

                //数据类型集合
                ArrayList DataTypeList = new ArrayList();
                DataTypeList.Add("System.Decimal");
                DataTypeList.Add("System.Double");
                DataTypeList.Add("System.Int16");
                DataTypeList.Add("System.Int32");
                DataTypeList.Add("System.Int64");
                DataTypeList.Add("System.Single");

                //遍历数据表的所有列，用于创建表结构
                foreach (DataColumn col in Table.Columns)
                {
                    //如果列属于数字列，则设置该列的数据类型为double
                    if (DataTypeList.IndexOf(col.DataType.ToString()) >= 0)
                    {
                        para[i] = new OleDbParameter("@" + col.ColumnName, OleDbType.Double);
                        objCmd.Parameters.Add(para[i]);

                        //如果是最后一列
                        if (i + 1 == ColCount)
                        {
                            TableStructStr += col.ColumnName + " double)";
                        }
                        else
                        {
                            TableStructStr += col.ColumnName + " double,";
                        }
                    }
                    else
                    {
                        para[i] = new OleDbParameter("@" + col.ColumnName, OleDbType.VarChar);
                        objCmd.Parameters.Add(para[i]);

                        //如果是最后一列
                        if (i + 1 == ColCount)
                        {
                            TableStructStr += col.ColumnName + " varchar)";
                        }
                        else
                        {
                            TableStructStr += col.ColumnName + " varchar,";
                        }
                    }
                    i++;
                }

                //创建Excel文件及文件结构
                try
                {
                    objCmd.Connection = objConn;
                    objCmd.CommandText = TableStructStr;

                    if (objConn.State == ConnectionState.Closed)
                    {
                        objConn.Open();
                    }
                    objCmd.ExecuteNonQuery();
                }
                catch (Exception exp)
                {
                    throw exp;
                }

                //插入记录的SQL语句
                string InsertSql_1 = "Insert into " + Table.TableName + " (";
                string InsertSql_2 = " Values (";
                string InsertSql = "";

                //遍历所有列，用于插入记录，在此创建插入记录的SQL语句
                for (int colID = 0; colID < ColCount; colID++)
                {
                    if (colID + 1 == ColCount)  //最后一列
                    {
                        InsertSql_1 += Table.Columns[colID].ColumnName + ")";
                        InsertSql_2 += "@" + Table.Columns[colID].ColumnName + ")";
                    }
                    else
                    {
                        InsertSql_1 += Table.Columns[colID].ColumnName + ",";
                        InsertSql_2 += "@" + Table.Columns[colID].ColumnName + ",";
                    }
                }

                InsertSql = InsertSql_1 + InsertSql_2;

                //遍历数据表的所有数据行
                for (int rowID = 0; rowID < Table.Rows.Count; rowID++)
                {
                    for (int colID = 0; colID < ColCount; colID++)
                    {
                        if (para[colID].DbType == DbType.Double && Table.Rows[rowID][colID].ToString().Trim() == "")
                        {
                            para[colID].Value = 0;
                        }
                        else
                        {
                            para[colID].Value = Table.Rows[rowID][colID].ToString().Trim();
                        }
                    }
                    try
                    {
                        objCmd.CommandText = InsertSql;
                        objCmd.ExecuteNonQuery();
                    }
                    catch (Exception exp)
                    {
                        string str = exp.Message;
                    }
                }
                try
                {
                    if (objConn.State == ConnectionState.Open)
                    {
                        objConn.Close();

                    }
                }
                catch (Exception exp)
                {
                    WaitFormService.CloseWaitForm();
                    throw exp;
                }
                WaitFormService.CloseWaitForm();
                MessageBox.Show("导出完成!", "软件提示");



            }
            catch
            {
                WaitFormService.CloseWaitForm();
                MessageBox.Show("导出失败!", "软件提示");


            }










          //////////////////方法2

          //  SaveFileDialog saveFileDialog = new SaveFileDialog();

          ////  ToExcel2(dataGridView1, saveFileDialog);


          //  saveFileDialog.Filter = "Execl files (*.xls)|*.xls";
          //  saveFileDialog.FilterIndex = 0;
          //  saveFileDialog.RestoreDirectory = true;
          //  saveFileDialog.CreatePrompt = true;
          //  saveFileDialog.Title = "Export Excel File";
          //  saveFileDialog.ShowDialog();
          //  if (saveFileDialog.FileName == "")
          //      return;
          //  Stream myStream;
          //  myStream = saveFileDialog.OpenFile();
          //  StreamWriter sw = new StreamWriter(myStream, System.Text.Encoding.GetEncoding(-0));
          //  string str = "";
          //  WaitFormService.CreateWaitForm();
          //  WaitFormService.SetWaitFormCaption(" 正在导出，请稍候......");
          //  try
          //  {
          //      //寫dataGridView1表標題
          //      for (int i = 0; i < dataGridView1.ColumnCount; i++)
          //      {
          //          if (i > 0)
          //          {
          //              str += "\t";
          //          }
          //          str += dataGridView1.Columns[i].HeaderText.Trim();
          //      }
          //      sw.WriteLine(str);

          //      //寫dataGridView1表內容
          //      for (int j = 0; j < dataGridView1.Rows.Count; j++)
          //      {
          //          string tempStr = "";
          //          for (int k = 0; k < dataGridView1.Columns.Count; k++)
          //          {
          //              if (k > 0)
          //              {
          //                  tempStr += "\t";
          //              }
          //              //tempStr += dataGridView1.Rows[j].Cells[k].Value.ToString().Trim() ;
          //              tempStr += dataGridView1.Rows[j].Cells[k].Value;

          //              //要增加對含數字的文字類，如身份証號
          //              //.........欠對身份証號處理，以免在EXCEL打開時被自動轉數字
          //          }
          //          sw.WriteLine(tempStr);
          //      }
          //      sw.Close();
          //      myStream.Close();
          //  }

          //  catch (Exception ex)
          //  {

          //      WaitFormService.CloseWaitForm();
          //      MessageBox.Show("导出失败!" + ex.ToString(), "软件提示");


          //  }
          //  finally
          //  {
          //      sw.Close();
          //      myStream.Close();
          //  }

          //  WaitFormService.CloseWaitForm();
          //  MessageBox.Show("导出完成!", "软件提示");




            //////////////////方法1
            
            
            //System.Data.DataTable dt = ds.Tables[0];
            
            //if (dt.Rows.Count == 0)
            //{
            //    return;

            //}

            //string localFilePath = String.Empty;
            ////设置文件类型  
            ////saveFileDialog1.Filter = " xls files(*.xls)|*.txt|All files(*.*)|*.*";
            ////设置文件名称：
            //saveFileDialog1.FileName =  DateTime.Now.ToString("yyyyMMdd") + "-" + "食品应收帐款表.xls";
            ////点了保存按钮进入  
            //if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            //{
            //    WaitFormService.CreateWaitForm();
            //    WaitFormService.SetWaitFormCaption(" 正在导出，请稍候......");
            //    try
            //    {
            //        //获得文件路径  
            //        localFilePath = saveFileDialog1.FileName.ToString();
            //        //string wordPath = Application.StartupPath + "\\btsk.xls"; //定义模板的路径
            //        Excel.Application app = new Excel.Application();//添加一个 Excle应用对象
            //        //打开工作簿，可见很多参数，第一个就是我们模板的路径

            //        //Excel._Workbook wbook = app.Workbooks.Open(null, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value);
            //       // Excel.Application.Workbooks.Add(true);
            //        Microsoft.Office.Interop.Excel.Workbooks workbooks = app.Workbooks;
            //        Microsoft.Office.Interop.Excel.Workbook workbook = workbooks.Add(Microsoft.Office.Interop.Excel.XlWBATemplate.xlWBATWorksheet);
            //        Microsoft.Office.Interop.Excel.Worksheet worksheet = (Microsoft.Office.Interop.Excel.Worksheet)workbook.Worksheets[1];


            //        Excel._Worksheet oSheet = (Excel._Worksheet)workbook.Worksheets[1];//创建一张sheet表

            //        int rowIndex=1;
            //        int colIndex=0;

            //         foreach(DataColumn col in dt.Columns)
            //       {
            //        colIndex++;
            //        oSheet.Cells[1, colIndex] = col.ColumnName;                
            //       }
            //           foreach(DataRow row in dt.Rows)
            //      {
            //         rowIndex++;
            //         colIndex=0;
            //         foreach(DataColumn col in dt.Columns)
            //        {
            //        colIndex++;
            //        oSheet.Cells[rowIndex, colIndex] = row[col.ColumnName].ToString();
            //       }
            //      }


            //        app.Application.DisplayAlerts = false;
            //        oSheet.SaveAs(localFilePath, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value);//文件保存


            //        //打开后就要关闭。O(∩_∩)O~

            //        app.Workbooks.Close();
            //        //同样不要忘记结束进程
            //        System.Runtime.InteropServices.Marshal.ReleaseComObject(oSheet);
            //        System.Runtime.InteropServices.Marshal.ReleaseComObject(app);
            //        GC.Collect();//强制对所有代进行即时垃圾回收
            //        WaitFormService.CloseWaitForm();
            //        MessageBox.Show("导出完成!", "软件提示");

            //    }
            //    catch (Exception ex)
            //    {
            //        WaitFormService.CloseWaitForm();
            //        MessageBox.Show("导出失败!" + ex.ToString(), "软件提示");
            //        return;


            //    }

            //}






        }

    private void button3_Click(object sender, EventArgs e)
        {
            string strfilter = " select * from gp_vw_custom where 1=1 AND F门店名称+F门店编码 LIKE '%"+
                this.textBox1.Text.Trim() + "%' AND F客户名称+F客户编码 LIKE '%" + this.textBox2.Text.Trim() + "%' ";

          ds = db.GetDataSet(strfilter, "tab");
          this.dataGridView1.DataSource = ds.Tables[0];


        }

        private void button4_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();

            //  ToExcel2(dataGridView1, saveFileDialog);


            saveFileDialog.Filter = "Execl files (*.xls)|*.xls";
            saveFileDialog.FilterIndex = 0;
            saveFileDialog.RestoreDirectory = true;
            saveFileDialog.CreatePrompt = true;
            saveFileDialog.Title = "Export Excel File";
            saveFileDialog.ShowDialog();
            if (saveFileDialog.FileName == "")
                return; 
           System.Data.DataTable Table=ds.Tables[0];
           string ExcelFilePath = saveFileDialog.FileName;

           WaitFormService.CreateWaitForm();
           WaitFormService.SetWaitFormCaption(" 正在导出，请稍候......");
           try
           {

               if ((Table.TableName.Trim().Length == 0) || (Table.TableName.ToLower() == "table"))
               {
                   Table.TableName = "Sheet1";
               }

               //数据表的列数
               int ColCount = Table.Columns.Count;

               //用于记数，实例化参数时的序号
               int i = 0;

               //创建参数
               OleDbParameter[] para = new OleDbParameter[ColCount];

               //创建表结构的SQL语句
               string TableStructStr = @"Create Table " + Table.TableName + "(";

               //连接字符串
               string connString = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + ExcelFilePath + ";Extended Properties=Excel 8.0;";
               OleDbConnection objConn = new OleDbConnection(connString);

               //创建表结构
               OleDbCommand objCmd = new OleDbCommand();

               //数据类型集合
               ArrayList DataTypeList = new ArrayList();
               DataTypeList.Add("System.Decimal");
               DataTypeList.Add("System.Double");
               DataTypeList.Add("System.Int16");
               DataTypeList.Add("System.Int32");
               DataTypeList.Add("System.Int64");
               DataTypeList.Add("System.Single");

               //遍历数据表的所有列，用于创建表结构
               foreach (DataColumn col in Table.Columns)
               {
                   //如果列属于数字列，则设置该列的数据类型为double
                   if (DataTypeList.IndexOf(col.DataType.ToString()) >= 0)
                   {
                       para[i] = new OleDbParameter("@" + col.ColumnName, OleDbType.Double);
                       objCmd.Parameters.Add(para[i]);

                       //如果是最后一列
                       if (i + 1 == ColCount)
                       {
                           TableStructStr += col.ColumnName + " double)";
                       }
                       else
                       {
                           TableStructStr += col.ColumnName + " double,";
                       }
                   }
                   else
                   {
                       para[i] = new OleDbParameter("@" + col.ColumnName, OleDbType.VarChar);
                       objCmd.Parameters.Add(para[i]);

                       //如果是最后一列
                       if (i + 1 == ColCount)
                       {
                           TableStructStr += col.ColumnName + " varchar)";
                       }
                       else
                       {
                           TableStructStr += col.ColumnName + " varchar,";
                       }
                   }
                   i++;
               }

               //创建Excel文件及文件结构
               try
               {
                   objCmd.Connection = objConn;
                   objCmd.CommandText = TableStructStr;

                   if (objConn.State == ConnectionState.Closed)
                   {
                       objConn.Open();
                   }
                   objCmd.ExecuteNonQuery();
               }
               catch (Exception exp)
               {
                   throw exp;
               }

               //插入记录的SQL语句
               string InsertSql_1 = "Insert into " + Table.TableName + " (";
               string InsertSql_2 = " Values (";
               string InsertSql = "";

               //遍历所有列，用于插入记录，在此创建插入记录的SQL语句
               for (int colID = 0; colID < ColCount; colID++)
               {
                   if (colID + 1 == ColCount)  //最后一列
                   {
                       InsertSql_1 += Table.Columns[colID].ColumnName + ")";
                       InsertSql_2 += "@" + Table.Columns[colID].ColumnName + ")";
                   }
                   else
                   {
                       InsertSql_1 += Table.Columns[colID].ColumnName + ",";
                       InsertSql_2 += "@" + Table.Columns[colID].ColumnName + ",";
                   }
               }

               InsertSql = InsertSql_1 + InsertSql_2;

               //遍历数据表的所有数据行
               for (int rowID = 0; rowID < Table.Rows.Count; rowID++)
               {
                   for (int colID = 0; colID < ColCount; colID++)
                   {
                       if (para[colID].DbType == DbType.Double && Table.Rows[rowID][colID].ToString().Trim() == "")
                       {
                           para[colID].Value = 0;
                       }
                       else
                       {
                           para[colID].Value = Table.Rows[rowID][colID].ToString().Trim();
                       }
                   }
                   try
                   {
                       objCmd.CommandText = InsertSql;
                       objCmd.ExecuteNonQuery();
                   }
                   catch (Exception exp)
                   {
                       string str = exp.Message;
                   }
               }
               try
               {
                   if (objConn.State == ConnectionState.Open)
                   {
                       objConn.Close();

                   }
               }
               catch (Exception exp)
               {
                   WaitFormService.CloseWaitForm();
                   throw exp;
               }
               WaitFormService.CloseWaitForm();
               MessageBox.Show("导出完成!", "软件提示");



           }
           catch
           {
               WaitFormService.CloseWaitForm();
               MessageBox.Show("导出失败!", "软件提示");
           
           
           }

        }
  
   
       


        

    }
}
