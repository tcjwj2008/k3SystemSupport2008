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
using System.Data.OleDb;



namespace YXK3FZ.CW
{
    public partial class frmPriceMager : Form
    {
        public frmPriceMager()
        {
            InitializeComponent();
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            string sqlstr =" SELECT a.Fnumber as 产品代码,t.fname AS 产品名称,a.Fprice AS 单价 FROM dbo.R_S_price a "+
                           " INNER join AIS_YXSP2.dbo.t_icitem t ON a.fnumber=t.fnumber where 1=1  ";
            if (txtFnumber.Text.Trim()!="")
            {
                sqlstr = sqlstr + " AND t.fnumber LIKE '%" + txtFnumber.Text.Trim() + "%'  ";
            }

            if (txtFname.Text.Trim() != "")
            {
                sqlstr = sqlstr + " AND t.fname LIKE '%" + txtFname.Text.Trim() + "%'  ";
            }
            DataBase db = new DataBase();
            try
            {
                WaitFormService.CreateWaitForm();
                WaitFormService.SetWaitFormCaption("正在查询......");
                dgvPrice.DataSource = db.GetDataTable(sqlstr, "Price");
               
            }
            catch (Exception err)
            {
               
                MessageBox.Show("查询失败！" + err.ToString());
                return;
            }
            WaitFormService.CloseWaitForm();
  




        }

        private void dgvPrice_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            txtNumber.Text = dgvPrice.Rows[dgvPrice.CurrentRow.Index].Cells[0].Value.ToString();
            txtPrice.Text = dgvPrice.Rows[dgvPrice.CurrentRow.Index].Cells[2].Value.ToString();

        }

        private void btnSave_Click(object sender, EventArgs e)
        {//保存
            if (txtNumber.Text.Trim() == "")
            {
                MessageBox.Show("产品代码不能为空！" );
                return;
            }

            if (txtPrice.Text.Trim() == "")
            {
                MessageBox.Show("单价不能为空！");
                return;
            }
            
            float price;
            try
            {
                price =float.Parse(txtPrice.Text.Trim());
            }
            catch
            {
                MessageBox.Show("单价格式错误！");
                return;
            }
            if (price<=0)
            {
                MessageBox.Show("单价错误！");
                return;
            }
            DataBase db = new DataBase();
               SqlParameter param1 = new SqlParameter("@fnumber", SqlDbType.VarChar);
                param1.Value =txtNumber.Text.Trim();
              SqlParameter param2 = new SqlParameter("@Price", SqlDbType.Money);
                param2.Value =price;


                //创建泛型
                List<SqlParameter> parameters= new List<SqlParameter>();
                parameters.Add(param1);
                parameters.Add(param2);
                //把泛型中的元素复制到数组中
                SqlParameter[] inputParameters = parameters.ToArray();

                try
                {
                    db.GetProcRow("sp_up_insert_price", inputParameters);
                    this.btnSelect_Click(sender, e);
                    


                }
                catch {
                    MessageBox.Show("保存失败！");
                    return;
                }



        }

        private void btnInput_Click(object sender, EventArgs e)
        {
             string excelFileName = "";
            openFileDialog1.FileName = "";
            //openFileDialog1.Filter = "EXCEL文件(*.xls,*.xlsx)|*.xls,*.xlsx";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {

                WaitFormService.CreateWaitForm();
                WaitFormService.SetWaitFormCaption("数据正在处理......");
                excelFileName = openFileDialog1.FileName;
                string strConn = "Provider=Microsoft.Jet.OLEDB.4.0;" + "Data Source=" + excelFileName + ";" + "Extended Properties=Excel 8.0;";
                OleDbConnection Excel_conn = new OleDbConnection(strConn);

                string SheetName = "";

                SheetName = GetFirstSheetNameFromExcelFileName(excelFileName, 1);

                string strExcel = string.Format("select 产品代码,单价 from [{0}" + "$]  ", SheetName);

                OleDbDataAdapter da = new OleDbDataAdapter(strExcel, strConn);
                DataSet ds = new DataSet();//excel
                da.Fill(ds);
                //读取单价到表R_S_price_d 
                List<string> strSqls = new List<string>();
                strSqls.Add(" TRUNCATE  TABLE R_S_price_d  ");
                DataRow dr = null;
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                  dr = ds.Tables[0].Rows[i];
                  
                  strSqls.Add("   INSERT INTO R_S_price_d ('" + dr["产品代码"].ToString() + "'," + dr["单价"].ToString() + ")  ");
                }

                //更新单价
                // 
                strSqls.Add(" TRUNCATE  TABLE R_S_price  ");
               // strSqls.Add(" UPDATE R_S_price SET Fprice=d.Fprice FROM dbo.R_S_price a INNER JOIN dbo.R_S_price_d d ON a.Fnumber=d.Fnumber   ");
               // strSqls.Add(" DELETE R_S_price_d FROM dbo.R_S_price a INNER JOIN dbo.R_S_price_d d ON a.Fnumber=d.Fnumber  ");
                strSqls.Add("  INSERT INTO R_S_price(Fnumber,Fprice) SELECT Fnumber,Fprice FROM R_S_price_d  ");
                DataBase db = new DataBase();
                if (!db.ExecDataBySqls(strSqls))
                {
                  
                    WaitFormService.CloseWaitForm();
                    MessageBox.Show("更新单价失败！", "软件提示");
                    return;
                }

                WaitFormService.CloseWaitForm();
                MessageBox.Show("更新单价成功！", "软件提示");



            }
        }
        //获取excel的第一个sheet的名称
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

        private void btnUpdate_Click(object sender, EventArgs e)
        {

            WaitFormService.CreateWaitForm();
            WaitFormService.SetWaitFormCaption("数据正在更新......");
            DataBase db = new DataBase();
            SqlParameter param1 = new SqlParameter("@begdate", SqlDbType.DateTime);
            param1.Value =DateTime.Parse(this.dateTimePicker1.Value.ToShortDateString());
            SqlParameter param2 = new SqlParameter("@enddate", SqlDbType.DateTime);
            param2.Value = DateTime.Parse(this.dateTimePicker2.Value.ToShortDateString());


            //创建泛型
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(param1);
            parameters.Add(param2);
            //把泛型中的元素复制到数组中
            SqlParameter[] inputParameters = parameters.ToArray();

            try
            {
                db.GetProcRow("sp_update_price_spwuru_ryxsck", inputParameters);
                WaitFormService.CloseWaitForm();
                MessageBox.Show("更新单价成功！");


            }
            catch
            {
                WaitFormService.CloseWaitForm();
                MessageBox.Show("更新单价失败！");
                return;
            }
          


        }



    }
}
