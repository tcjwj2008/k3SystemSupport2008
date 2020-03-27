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

namespace YXK3FZ.YZGL
{
	public partial class YZ_FBoatJXKH_ByProjet : Form
	{

		DataBase db = new DataBase();
		DataSet ds = null;
		DataBase k3db = null;
		CommonUse commUse = new CommonUse();
		DataBase K3YZDB = null;

		string ordertablename = "YZ_Base";
		string entrytablename = "YZ_BaseEntry";

		string fnamenum = "";

		string YZConnstring = string.Empty;  //油脂数据库连接字符串
		string sSQLWH = string.Empty; //查询字符串

		int FEditID = 0; //修改时的编号

		public YZ_FBoatJXKH_ByProjet()
		{
			InitializeComponent();
			YZConnstring = db.GetSingleObject("SELECT Fdbstr FROM YXZTLIST WHERE ID=5").ToString();

			k3db = new DataBase(YZConnstring);


			LoadData(); //加载数据
		}

		private void LoadData()
		{
			string sSQL = string.Empty;


			DataTable dttSQL1 = k3db.GetDataTable("SELECT FItemID, FName FROM dbo.t_Item WHERE FItemClassID=3002 ", "A1");			

			cobFBoatID.DataSource = dttSQL1;
			cobFBoatID.ValueMember = "FItemID";
			cobFBoatID.DisplayMember = "FName";
			cobFBoatID.SelectedIndex = -1;		


		}

		private void YZ_FBoatJXKH_ByProjet_Load(object sender, EventArgs e)
		{

		}

		private void btnFind_Click(object sender, EventArgs e)
		{
			if (cobFBoatID.Text == string.Empty)
			{
				MessageBox.Show("查询船次不能为空");
				return;
			}

			getData(); //查询数据
		}

		private void dgvDetail_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e) //显示序号
		{
			SolidBrush b = new SolidBrush(this.dataGridView1.RowHeadersDefaultCellStyle.ForeColor);
			e.Graphics.DrawString((e.RowIndex + 1).ToString(System.Globalization.CultureInfo.CurrentUICulture), this.dataGridView1.DefaultCellStyle.Font, b, e.RowBounds.Location.X + 20, e.RowBounds.Location.Y + 4);

		}


		private void getData()
		{
			DataBase db = new DataBase();

			WaitFormService.CreateWaitForm();
			WaitFormService.SetWaitFormCaption(" 正在查询，请稍候......");


			SqlParameter param1 = new SqlParameter("@FBoatID", SqlDbType.Int);  //船次ID
			param1.Value = this.cobFBoatID.SelectedValue;

			SqlParameter param2 = new SqlParameter("@FBoatName", SqlDbType.VarChar); //船次名称
			param2.Value = this.cobFBoatID.Text;

			

			//创建泛型
			List<SqlParameter> parameters2 = new List<SqlParameter>();
			parameters2.Add(param1);
			parameters2.Add(param2);
			

			//把泛型中的元素复制到数组中
			SqlParameter[] inputParameters2 = parameters2.ToArray();
			try
			{
				DataTable dt01 = k3db.GetDataTable("sp_YZ_JXKHSelectByProject_czq", inputParameters2);

				bdsMaster.DataSource = dt01;

			}
			catch (Exception ex)
			{
				WaitFormService.CloseWaitForm();
				MessageBox.Show("查询失败!" + ex.ToString(), "软件提示");
				return;

			}
			WaitFormService.CloseWaitForm();


		}

		private void btnEXCEL_Click(object sender, EventArgs e)
		{
			if (bdsMaster.Count > 0)
			{
				string sfilename = "数据导出";
				ComClass.CommExcel.ExportExcel(sfilename, dataGridView1, true);
			}
		}


	}
}
