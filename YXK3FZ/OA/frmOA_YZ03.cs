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

namespace YXK3FZ.OA
{
	public partial class frmOA_YZ03 : Form
	{
		DataBase db = new DataBase();
		DataSet ds = null;
		DataBase k3db = null;
		CommonUse commUse = new CommonUse();

		string ordertablename = "YZ_Base";
		string entrytablename = "YZ_BaseEntry";

		string fnamenum = "";

		int FEditID = 0; //修改时的编号

		string YZConnstring = string.Empty;  //油脂数据库连接字符串

		string sSQLWH = string.Empty; //查询字符串


		string MasterState = "SEL";//类型 判断窗体是新增还是编辑状态 ADD EDIT SEL

		public frmOA_YZ03()
		{
			InitializeComponent();
		
			YZConnstring = db.GetSingleObject("SELECT Fdbstr FROM YXZTLIST WHERE ID=5").ToString();
			k3db = new DataBase(YZConnstring);
		}

		private void getData()  //查询数据
		{
			DataBase db = new DataBase();

			WaitFormService.CreateWaitForm();
			WaitFormService.SetWaitFormCaption(" 正在查询，请稍候......");

			SqlParameter param1 = new SqlParameter("@FSubContractNumber", txtSubContractNumber.Text.Trim());  //副合同号	
			SqlParameter param2 = new SqlParameter("@FCustomer", txtCustomer.Text.Trim()); //客户名称
			SqlParameter param3 = new SqlParameter("@FItem", txtItem.Text.Trim()); //商品名称



			//创建泛型
			List<SqlParameter> parameters2 = new List<SqlParameter>();
			parameters2.Add(param1);
			parameters2.Add(param2);
			parameters2.Add(param3);


			//把泛型中的元素复制到数组中
			SqlParameter[] inputParameters2 = parameters2.ToArray();
			try
			{
				DataTable dt01 = k3db.GetDataTable("sp_YZ_SubContractSelect_czq", inputParameters2);

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

		private void button1_Click(object sender, EventArgs e) //查询
		{
			getData(); //查询数据
		}

		private void button2_Click(object sender, EventArgs e) //清除
		{
			txtCustomer.Text = string.Empty;
			txtItem.Text = string.Empty;
			txtSubContractNumber.Text = string.Empty;
		}

		private void button3_Click(object sender, EventArgs e) //导出
		{
			if (bdsMaster.Count > 0)
			{
				string sfilename = this.Text+ "数据导出";
				ComClass.CommExcel.ExportExcel(sfilename, dataGridView1, true);
			}
		}

		private void dgvDetail_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e) //显示序号
		{
			SolidBrush b = new SolidBrush(this.dataGridView1.RowHeadersDefaultCellStyle.ForeColor);
			e.Graphics.DrawString((e.RowIndex + 1).ToString(System.Globalization.CultureInfo.CurrentUICulture), this.dataGridView1.DefaultCellStyle.Font, b, e.RowBounds.Location.X + 20, e.RowBounds.Location.Y + 4);

		}
	}
}
