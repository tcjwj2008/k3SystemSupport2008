using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using YXK3FZ.ComClass;
using System.Data.SqlClient;
using YXK3FZ.DataClass;

namespace YXK3FZ.SP
{
	public partial class frmBTpfmx02 : Form
	{
		DataBase db = new DataBase();
		DataSet ds = null;
		DataBase k3db = null;
		CommonUse commUse = new CommonUse();
		string ZtRyconstring = string.Empty; //获取K3账套连接字符串

		public frmBTpfmx02()
		{
			InitializeComponent();
			ds = db.GetDataSet("SELECT Fdbstr  FROM dbo.YXZTLIST WHERE ID=1", "con");
			DataRow dr = ds.Tables[0].Rows[0];
			ZtRyconstring = dr["Fdbstr"].ToString(); //获取K3账套连接字符串
			k3db = new DataBase(ZtRyconstring);    
		}

		private void btnFind_Click(object sender, EventArgs e)
		{
			SqlParameter param2 = new SqlParameter("@Fdate", SqlDbType.VarChar);
			param2.Value = this.dateTimePicker1.Text;

			DataTable dtt = SqlHelper.ExecuteDataTableByProduce(ZtRyconstring, "SP_xysp_btpfmx_czq", param2);
			bdsMaster.DataSource = dtt;
		}

		private void dgvDetail_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e) //显示序号
		{
			SolidBrush b = new SolidBrush(this.dataGridView1.RowHeadersDefaultCellStyle.ForeColor);
			e.Graphics.DrawString((e.RowIndex + 1).ToString(System.Globalization.CultureInfo.CurrentUICulture), this.dataGridView1.DefaultCellStyle.Font, b, e.RowBounds.Location.X + 20, e.RowBounds.Location.Y + 4);

		}

		private void btnExcel_Click(object sender, EventArgs e)
		{
			if (bdsMaster.Count == 0)
			{
				MessageBox.Show("无数据，无法导出");
				return;
			}
			string sFileName = "配送日期为"+this.dateTimePicker1.Text + "数据导出";
			ComClass.CommExcel.ExportExcel(sFileName, dataGridView1, true);
		}

		private void frmBTpfmx02_Load(object sender, EventArgs e)
		{
			dateTimePicker1.Text = Convert.ToDateTime(dateTimePicker1.Text).AddDays(1).ToString("yyyy-MM-dd");
		}

		private void dataGridView1_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
		{
			for (int i = 0; i < this.dataGridView1.Rows.Count; i++)
			{
				if (dataGridView1.Rows[i].Cells["市场"].Value.ToString() == "合计")
				{
					this.dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.LightBlue;
				}		


			}
		}


	}
}
