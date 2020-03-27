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


namespace YXK3FZ.RP.from
{
    public partial class frmRSYJBMX : Form
    {
      public   string fdate;
      public   string fdepnum;

      DataSet ds = new DataSet();//excel
      // DataBase db = new DataBase(PropertyClass.con_yxsp);
      DataBase db = new DataBase();
        
        
        
        public frmRSYJBMX()
        {
            InitializeComponent();
        }

        private void frmRSYJBMX_Load(object sender, EventArgs e)
        {
            this.toolStripLabel1.Text = "部门：" + fdepnum;
            this.toolStripLabel2.Text = "日期：" + fdate;

            SqlParameter param1 = new SqlParameter("@FDate", SqlDbType.VarChar);
            param1.Value = fdate;
          
            SqlParameter param3 = new SqlParameter("@fdepnumber", SqlDbType.VarChar);
            param3.Value = fdepnum;

            //创建泛型
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(param1); 
            parameters.Add(param3);

            //把泛型中的元素复制到数组中
            SqlParameter[] inputParameters = parameters.ToArray();
            try
            {
                ds = db.GetProcDataSet("sp_sel_rsjybmx", inputParameters);
                this.dataGridView1.DataSource = ds.Tables[0];             
            
            }
            catch (Exception err)
            {
             
                MessageBox.Show("操作失败！" + err.ToString());            

            }



        }

        private void toolStripButton1_Click(object sender, EventArgs e)
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
        }
    }
}
