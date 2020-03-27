using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
//using System.Linq;
using System.Text;
using System.Windows.Forms;
using YXK3FZ.ComClass;
using YXK3FZ.DataClass;
using System.Data.OleDb;
using System.Data.SqlClient;

using Excel = Microsoft.Office.Interop.Excel;
using System.Reflection;

namespace YXK3FZ.SP
{
    public partial class frmBTpsyeb02 : Form
    {
        CommonUse commUse = new CommonUse();
        DataTable dt = new DataTable();
        DataBase db = new DataBase();



				public frmBTpsyeb02()
        {
            InitializeComponent();
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
						//string strCondition = null;
						//strCondition = " SELECT * FROM BTSKBM WHERE fdate='"+this.dateTimePicker1.Value.ToShortDateString()+
						//"' AND 收银员 LIKE '%" + this.textBox1.Text.Trim() + "%' ORDER BY 市场";
						//dt = db.GetDataTable(strCondition,"exceltab");
						//if (this.radioButton1.Checked == true)
						//{
						//    crystalReportViewer1.ReportSource = commUse.CrystalReports("btpfsk.rpt", strCondition, "BTSKBM");
						//}
						//if (this.radioButton2.Checked == true)
						//{
						//    crystalReportViewer1.ReportSource = commUse.CrystalReports("Btsk_d.rpt", strCondition, "BTSKBM");
						//}
        }

        private void frmBTpfsk_Load(object sender, EventArgs e)
        {
           
           
           
        }

				private void dgvDetail_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e) //显示序号
				{
					SolidBrush b = new SolidBrush(this.dataGridView1.RowHeadersDefaultCellStyle.ForeColor);
					e.Graphics.DrawString((e.RowIndex + 1).ToString(System.Globalization.CultureInfo.CurrentUICulture), this.dataGridView1.DefaultCellStyle.Font, b, e.RowBounds.Location.X + 20, e.RowBounds.Location.Y + 4);

				}

        private void btnJS_Click(object sender, EventArgs e)
        {
          
            DataBase db = new DataBase();

            WaitFormService.CreateWaitForm();
            WaitFormService.SetWaitFormCaption(" 正在计算，请稍候......");
            string datestr = "";
            datestr = this.dateTimePicker1.Value.ToShortDateString();

            SqlParameter param2 = new SqlParameter("@date", SqlDbType.VarChar);
            param2.Value = datestr;
            //创建泛型
            List<SqlParameter> parameters2 = new List<SqlParameter>();
            parameters2.Add(param2);
            //把泛型中的元素复制到数组中
            SqlParameter[] inputParameters2 = parameters2.ToArray();
            try
            {
                db.GetProcRow("spk3_2_BTSKBM", inputParameters2);
               

            }
            catch (Exception ex)
            {
                WaitFormService.CloseWaitForm();
                MessageBox.Show("计算失败!" + ex.ToString(), "软件提示");
                return;

            }
            WaitFormService.CloseWaitForm();

						string sSQL = string.Empty;
					//新做法，调用存储过程

						//sSQL += " SELECT 市场,g.FNumber K3代码,g.FName 客户名称,前日累欠 ,礼券,现金收款, ";
						//sSQL += " 银行存款,[余额(不含当天销售)], ";
						//sSQL += " 重量1 一级白条重量,	金额1 一级白条金额, ";
						//sSQL += " 重量2 二级白条重量,	金额2 二级白条金额, ";
						//sSQL += " 重量3 三级白条重量,	金额3 三级白条金额, ";
						//sSQL += " 重量4 四级白条重量,	金额4 四级白条金额, ";
						//sSQL += " 重量5 五级白条重量,	金额5 五级白条金额, ";
						//sSQL += " 折让金额,当日应付, ";
						//sSQL += " p.FSumFamout 次日配送金额, ";
						//sSQL += " b.FXYMoney 信用额度, ";
						//sSQL += " (ISNULL(当日应付,0)- ISNULL(b.FXYMoney,0))+  ISNULL(p.FSumFamout,0) 余额 ";
						//sSQL += " FROM BTSKBM M  ";
						//sSQL += " LEFT JOIN AIS_YXSP2.dbo.t_Organization g ON m.内码=g.FItemID ";
						//sSQL += " LEFT JOIN AIS_YXSP2.dbo.t_SPXYBase b     ON m.内码=b.FInterID ";
						//sSQL += " LEFT JOIN  ";
						//sSQL += " ( ";
						//sSQL += " SELECT fcurID,FSumFamout FROM AIS_YXSP2.dbo.yx_order WHERE Fpdate='" + Convert.ToDateTime(this.dateTimePicker1.Text).AddDays(1) + "' ";
						//sSQL += " ) p ON m.内码=p.fcurID ";
						//sSQL += " WHERE fdate='"+Convert.ToDateTime(this.dateTimePicker1.Text)+"'";
						//sSQL += " order by (ISNULL(当日应付,0)- ISNULL(b.FXYMoney,0))+  ISNULL(p.FSumFamout,0)";
						//dt = db.GetDataTable(sSQL, "exceltab");

					 //创建泛型
            List<SqlParameter> parameters = new List<SqlParameter>();
						SqlParameter param1 = new SqlParameter("@fdate", SqlDbType.VarChar);
						param1.Value = this.dateTimePicker1.Text;
            parameters.Add(param1);
					   //把泛型中的元素复制到数组中
            SqlParameter[] inputParameters = parameters.ToArray();
						dt = SqlHelper.ExecuteDataTableByProduce(db.Conn.ConnectionString, "sp_xysp_btps_czq", inputParameters);

						bdsMaster.DataSource = dt;
					

        }


				private void btnFind_Click(object sender, EventArgs e)
				{
					string sSQL = string.Empty;

					sSQL += " SELECT 市场,g.FNumber K3代码,g.FName 客户名称,前日累欠 ,礼券,现金收款, ";
					sSQL += " 银行存款,[余额(不含当天销售)], ";
					sSQL += " 重量1 一级白条重量,	金额1 一级白条金额, ";
					sSQL += " 重量2 二级白条重量,	金额2 二级白条金额, ";
					sSQL += " 重量3 三级白条重量,	金额3 三级白条金额, ";
					sSQL += " 重量4 四级白条重量,	金额4 四级白条金额, ";
					sSQL += " 重量5 五级白条重量,	金额5 五级白条金额, ";
					sSQL += " 折让金额,当日应付, ";
					sSQL += " p.FSumFamout 次日配送金额, ";
					sSQL += " b.FXYMoney 信用额度, ";
					sSQL += " (ISNULL(当日应付,0)- ISNULL(b.FXYMoney,0))+  ISNULL(p.FSumFamout,0) 余额 ";
					sSQL += " FROM BTSKBM M  ";
					sSQL += " LEFT JOIN AIS_YXSP2.dbo.t_Organization g ON m.内码=g.FItemID ";
					sSQL += " LEFT JOIN AIS_YXSP2.dbo.t_SPXYBase b     ON m.内码=b.FInterID ";
					sSQL += " LEFT JOIN  ";
					sSQL += " ( ";
					sSQL += " SELECT fcurID,FSumFamout FROM AIS_YXSP2.dbo.yx_order WHERE Fpdate='" + Convert.ToDateTime(this.dateTimePicker1.Text).AddDays(1) + "' ";
					sSQL += " ) p ON m.内码=p.fcurID ";
					sSQL += " WHERE fdate='" + Convert.ToDateTime(this.dateTimePicker1.Text) + "'";
					sSQL += " order by (ISNULL(当日应付,0)- ISNULL(b.FXYMoney,0))+  ISNULL(p.FSumFamout,0)";
					dt = db.GetDataTable(sSQL, "exceltab");

					bdsMaster.DataSource = dt;
				}

				private void btnExcel_Click(object sender, EventArgs e)
				{
					if (bdsMaster.Count == 0)
					{
						MessageBox.Show("无数据，无法导出");
						return;
					}
					string sFileName =this.dateTimePicker1.Text+"白条配送余额表导出";
					ComClass.CommExcel.ExportExcel(sFileName, dataGridView1, true);
				}

       

				

      
    }
}
