using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using YXK3FZ.DataClass;
using YXK3FZ.ComClass;
using Excel = Microsoft.Office.Interop.Excel;
using System.Reflection;
using System.IO;   //特別引用流 System.IO
using System.Data.OleDb;
using System.Runtime.InteropServices;
using System.Collections;

namespace YXK3FZ.RP.from
{
    public partial class frmDzpYsTJ_test : Form
    {

        DataBase db = new DataBase();
        DataBase k3db = null;
        DataTable dt = null;
        DataSet ds = null;
        CommonUse commUse = new CommonUse();
        string year;
        string month;
        string fcur;
        public frmDzpYsTJ_test()
        {
            InitializeComponent();
        }
        private int _DB_ID = 4; //修改CZQ 2015-09-16
        public int DB_ID
        {
            get { return _DB_ID; }
            set { _DB_ID = value; }
        }

        private void frmDzpYsTJ_test_Load(object sender, EventArgs e)
        {
            //窗体加载
            commUse.CortrolButtonEnabled(btnSelect, this);
            commUse.CortrolButtonEnabled(btnSelMX, this);
            //get con
            if (DB_ID == 4) //修改CZQ 2015-09-16
            {
                ds = db.GetDataSet("SELECT Fdbstr    FROM dbo.YXZTLIST WHERE ID=4", "con");
            }
            else if (DB_ID == 7)
            {
                ds = db.GetDataSet("SELECT Fdbstr    FROM dbo.YXZTLIST WHERE ID=7", "con");
            }
            else if (DB_ID == 17)
            {
                ds = db.GetDataSet("SELECT Fdbstr    FROM dbo.YXZTLIST WHERE ID=17", "con");
            }
            else if (DB_ID == 2)
            {
                ds = db.GetDataSet("SELECT Fdbstr    FROM dbo.YXZTLIST WHERE ID=2", "con");
            }
            string dzpcon = ds.Tables[0].Rows[0]["Fdbstr"].ToString();
            k3db = new DataBase(dzpcon);
            this.txtYear.Text = DateTime.Now.Year.ToString();
            this.txtMonth.Text = DateTime.Now.Month.ToString();
            this.radioButton1.Checked = false;
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            //select 
            if (this.txtYear.Text == "" || this.txtMonth.Text == "")
            {
                MessageBox.Show("请输入查询年份和期间！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);

                return;

            }
            try { int.Parse(this.txtYear.Text.Trim()); int.Parse(this.txtMonth.Text.Trim()); }
            catch
            {
                MessageBox.Show("输入非数字！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);

                return;
            }
            year = this.txtYear.Text.Trim(); ;
            month = this.txtMonth.Text.Trim();
            try
            {
                fcur = this.txtFcur.Text.Trim();
            }
            catch
            {
                fcur = "";
            }

            WaitFormService.CreateWaitForm();
            WaitFormService.SetWaitFormCaption(" 正在查询，请稍候......");
            SqlParameter param1 = new SqlParameter("@year", SqlDbType.VarChar);
            param1.Value = this.txtYear.Text.Trim();
            SqlParameter param2 = new SqlParameter("@month", SqlDbType.VarChar);
            param2.Value = this.txtMonth.Text.Trim();
            SqlParameter param3 = new SqlParameter("@fcur", SqlDbType.VarChar);
            param3.Value = fcur;
            SqlParameter param4 = new SqlParameter("@isALL", SqlDbType.Int);
            if (this.radioButton1.Checked == true)//
            {
                param4.Value = 1;
            }
            else
            {
                param4.Value = 0;
            }
            //片区
            SqlParameter param5 = new SqlParameter("@pq", SqlDbType.VarChar);
            param5.Value = this.txtPq.Text.Trim();

            //创建泛型
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(param1);
            parameters.Add(param2);
            parameters.Add(param3);
            parameters.Add(param4);
            parameters.Add(param5);
            //把泛型中的元素复制到数组中
            SqlParameter[] inputParameters = parameters.ToArray();
            try
            {
                dt = k3db.GetDataTable("sp_DzpYsTJ_test", inputParameters);

                this.dataGridView1.DataSource = dt;
                this.dataGridView1.Columns[0].ReadOnly = false;
                //this.dataGridView1.Columns[0].Visible = false;
                WaitFormService.CloseWaitForm();
            }
            catch (Exception ex)
            {
                WaitFormService.CloseWaitForm();
                MessageBox.Show("查询失败!" + ex.ToString(), "软件提示");
                return;


            }
        }

        private void dataGridView1_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            //显示序号
            SolidBrush b = new SolidBrush(this.dataGridView1.RowHeadersDefaultCellStyle.ForeColor);
            e.Graphics.DrawString((e.RowIndex + 1).ToString(System.Globalization.CultureInfo.CurrentUICulture), this.dataGridView1.DefaultCellStyle.Font, b, e.RowBounds.Location.X + 20, e.RowBounds.Location.Y + 4);



        }

        private void dataGridView1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            //双击

            //if (this.dataGridView1.Rows.Count >= 1)
            //{

            //    frmDzpYsmx_test frmDzpYsmx_test = new frmDzpYsmx_test();
            //    frmDzpYsmx_test.DB_ID = this.DB_ID;  //修改CZQ 2015-09-16
            //    if (DB_ID == 7)
            //    {
            //        frmDzpYsmx_test.Text += "Demo1";
            //    }

            //    frmDzpYsmx_test.txtYear.Text = this.year;
            //    frmDzpYsmx_test.txtMonth.Text = this.month;
            //    frmDzpYsmx_test.txtFcurnumber.Text = this.dataGridView1[1, e.RowIndex].Value.ToString();
            //    frmDzpYsmx_test.Show();
            //}
        }

        private void btnSelMX_Click(object sender, EventArgs e)
        {
            if (this.dataGridView1.Rows.Count >= 1)
            {

                frmDzpYsmx frmDzpYsmx = new frmDzpYsmx();
                frmDzpYsmx.DB_ID = this.DB_ID; //修改CZQ 2015-09-16
                if (DB_ID == 7)
                {
                    frmDzpYsmx.Text += "Demo1";
                }
                frmDzpYsmx.txtYear.Text = this.year;
                frmDzpYsmx.txtMonth.Text = this.month;
                frmDzpYsmx.txtFcurnumber.Text = this.dataGridView1[1, this.dataGridView1.CurrentCell.RowIndex].Value.ToString();
                frmDzpYsmx.Show();
            }

        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            //导出

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
            System.Data.DataTable Table = dt;
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

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                if
           ((dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.GetType() == typeof(decimal) ||
              dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.GetType() == typeof(double) ||
               dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.GetType() == typeof(int)))
                {
                    if
                      (Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value) == 0)
                    {
                        e.Value = "";
                    }
                }
            }
        }

        private void 打印ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            List<String> Fcu = new List<string>();
            if (this.dataGridView1.Rows.Count >= 1)
            {
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    if (Convert.ToBoolean(dataGridView1.Rows[i].Cells[0].Value) == true && dataGridView1.Rows[i].Cells[3].Value.ToString() != "0")
                    {
                        Fcu.Add(dataGridView1.Rows[i].Cells[3].Value.ToString());
                    }
                }
            }
            if (Fcu.Count == 0)
            {
                MessageBox.Show("没有选择要打印的行");
                return;
            }

            frmDzpYsmx_test frmDzpYsmx_test = new frmDzpYsmx_test();
            frmDzpYsmx_test.DB_ID = this.DB_ID;  //修改CZQ 2015-09-16
            if (DB_ID == 7)
            {
                frmDzpYsmx_test.Text += "Demo1";
            }

            frmDzpYsmx_test.txtYear.Text = this.year;
            frmDzpYsmx_test.txtMonth.Text = this.month;
            frmDzpYsmx_test.txtFcurnumber.Text = Fcu[0];
            frmDzpYsmx_test.Show();
            frmDzpYsmx_test.Fcu = Fcu;
        }
    }
}
