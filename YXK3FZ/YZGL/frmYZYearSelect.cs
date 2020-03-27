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
	public partial class frmYZYearSelect : Form
	{

		DataBase db = new DataBase();
		DataSet ds = null;
		DataBase k3db = null;
		CommonUse commUse = new CommonUse();

		public frmYZYearSelect()
		{
			InitializeComponent();
		}

		private void getData(int FYear)
		{
			DataBase db = new DataBase();

			WaitFormService.CreateWaitForm();
			WaitFormService.SetWaitFormCaption(" 正在查询，请稍候......");


			SqlParameter param1 = new SqlParameter("@FYear", SqlDbType.Int);
			param1.Value = this.txtFDate1.Text.Trim();		

			//创建泛型
			List<SqlParameter> parameters2 = new List<SqlParameter>();
			parameters2.Add(param1);
		
			//把泛型中的元素复制到数组中
			SqlParameter[] inputParameters2 = parameters2.ToArray();
			try
			{
				DataTable dt01 = db.GetDataTable("sp_YZYearSelect01", inputParameters2);
				DataTable dt02 = db.GetDataTable("sp_YZYearSelect02", inputParameters2);


				object G43 = dt01.Rows[0]["FField06"];	


				DataRow[] dtr = dt02.Select("FID=2");
				object O44 = dtr[0]["FField07"];
				object K44 = dtr[0]["FField03"];
				object N44 = dtr[0]["FField06"];

				object oResult = (Convert.ToDecimal(G43) - Convert.ToDecimal(O44)) * Convert.ToDecimal(K44);

				dt02.Rows[1]["FField08"] = oResult;


				DataTable dt03 = dt01.Copy();//复制表1结构1000000/24

				object M6 = 35000;
				string sSQL = "SELECT FBlastCapacity FROM t_YZParameter WHERE FYear='"+txtFDate1.Text.Trim()+"'";
				
				M6 =db.GetSingleObject(sSQL);

				object FField01 = Convert.ToDecimal(N44) / Convert.ToDecimal(G43) * 1000000 / 24 / Convert.ToDecimal(M6);
				object FField02 = Convert.ToDecimal(N44) / Convert.ToDecimal(G43);

				dt03.Rows[0]["FField01"] = Convert.ToDecimal(FField01).ToString("0.00");
				dt03.Rows[0]["FField02"] = Convert.ToDecimal(FField02).ToString("0.00");


				bdsMaster01.DataSource = dt01;
				bdsMaster02.DataSource = dt02;
				bdsMaster03.DataSource = dt03;

			}
			catch (Exception ex)
			{
				WaitFormService.CloseWaitForm();
				MessageBox.Show("查询失败!" + ex.ToString(), "软件提示");
				return;

			}
			WaitFormService.CloseWaitForm();

		}

		private void frmYZYearSelect_Load(object sender, EventArgs e)
		{

		}


		private void button1_Click(object sender, EventArgs e) //查询
		{
			if (txtFDate1.Text == string.Empty)
			{
				MessageBox.Show("查询年度不能为空");
				return;
			}

			getData(Convert.ToInt32(txtFDate1.Text.Trim()));
		}

		private void button2_Click(object sender, EventArgs e) //导出
		{
			string sFileName = tabControl1.SelectedTab.Text + "数据导出";

			if (tabControl1.SelectedTab.Text == "加工控制")
			{
				if (dataGridView1.Rows.Count > 0)
				{
					CommExcel.ExportExcel(sFileName, dataGridView1, true);
				}
			}
			else if (tabControl1.SelectedTab.Text == "排放控制")
			{
				if (dataGridView2.Rows.Count > 0)
				{
					CommExcel.ExportExcel(sFileName, dataGridView2, true);
				}
			}
			else if (tabControl1.SelectedTab.Text == "持续生产")
			{
				if (dataGridView3.Rows.Count > 0)
				{
					CommExcel.ExportExcel(sFileName, dataGridView3, true);
				}
			}
		}

		


	}
}
