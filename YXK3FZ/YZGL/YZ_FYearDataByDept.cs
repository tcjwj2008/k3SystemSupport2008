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
	public partial class YZ_FYearDataByDept : Form
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

		public YZ_FYearDataByDept()
		{
			InitializeComponent();

			SetTextBoxState("SEL");
			//db = new DataBase(YXK3FZ.DataClass.DataBase.m_Connstr);
			YZConnstring = db.GetSingleObject("SELECT Fdbstr FROM YXZTLIST WHERE ID=5").ToString();
			k3db = new DataBase(YZConnstring);
			LoadData(); //加载数据

		}


		private void LoadData()
		{
			string sSQL = string.Empty;
			sSQL = "SELECT 车间 FROM YZ_YearDataByDeptSource WHERE 车间 <> '' ORDER BY 序号 ";

			DataTable dttSQL1 = k3db.GetDataTable(sSQL, "A1");

			DataTable dttSQL1Q = dttSQL1.Copy();

			cobFProject.DataSource = dttSQL1;
			cobFProject.ValueMember = "车间";
			cobFProject.DisplayMember = "车间";
			cobFProject.SelectedIndex = -1;

			cobFProjectQ.DataSource = dttSQL1Q;
			cobFProjectQ.ValueMember = "车间";
			cobFProjectQ.DisplayMember = "车间";
			cobFProjectQ.SelectedIndex = -1;

		}

		private void SetTextBoxState(string sMasterState)
		{
			// string MasterState = "SEL";//类型 判断窗体是新增还是编辑状态 ADD EDIT SEL
			if (sMasterState == "SEL")
			{
				LabTishi.Text = "状态提示：查看";
				foreach (Control c in splitContainer1.Panel1.Controls)
				{
					if (c is TextBox)
					{
						((TextBox)c).ReadOnly = true;
					}
					if (c is ComboBox)
					{
						((ComboBox)c).Enabled = false;
					}

				}
			}
			else
			{
				if (sMasterState == "ADD")
				{
					LabTishi.Text = "状态提示：新增";
				}
				else if (sMasterState == "EDIT")
				{
					LabTishi.Text = "状态提示：编辑";

				}

				foreach (Control c in splitContainer1.Panel1.Controls)
				{
					if (c is TextBox)
					{
						if (((TextBox)c).Name.Substring(0, 3) == "txt")
						{
							((TextBox)c).ReadOnly = true;
						}
						else if (((TextBox)c).Name.Substring(0, 3) == "edt")
						{
							((TextBox)c).ReadOnly = false;
						}

					}

					if (c is ComboBox)
					{
						((ComboBox)c).Enabled = true;
					}
				}
			}
		}

		private void SetFieldValue(int FID)
		{
			string sSQL = string.Empty;
			sSQL = " SELECT * FROM YZ_YearDataByDept e ";
			sSQL += " Where e.FID=@FID ";

			SqlParameter[] par = new SqlParameter[] {
			       new SqlParameter("@FID", FID)
			    };

			DataTable dttSQL = SqlHelper.ExecuteDataTable(YZConnstring, sSQL, par);

			if (dttSQL.Rows.Count > 0)
			{
				edtFYear.Text = dttSQL.Rows[0]["年份"].ToString();
				cobFProject.Text = dttSQL.Rows[0]["考核部门"].ToString();
				edtZB.Text = dttSQL.Rows[0]["指标"].ToString();
			
				edtFText.Text = dttSQL.Rows[0]["备注"].ToString();


			}
			else
			{
				edtFYear.Text = string.Empty;
				cobFProject.SelectedIndex = -1;
				edtZB.Text = string.Empty;
			
				edtFText.Text = string.Empty;


			}

		}

		//加载列表数据
		private void getDate(string Q, string sSQLWH)
		{
			string sSQL = string.Empty;
			sSQL = " SELECT E.* FROM YZ_YearDataByDept e ";
			sSQL += " Where 1=1 ";
			if (Q != string.Empty) //如果是查询
			{
				sSQL += sSQLWH;
			}
			sSQL += " Order by 年份, E.序号 ";
			bdsMaster.DataSource = k3db.GetDataSet(sSQL, "sel").Tables[0].DefaultView;

		}

		private void YZ_FYearDataByDept_Load(object sender, EventArgs e)
		{
			getDate(string.Empty, string.Empty);
		}

		private void dgvDetail_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e) //显示序号
		{
			SolidBrush b = new SolidBrush(this.dataGridView1.RowHeadersDefaultCellStyle.ForeColor);
			e.Graphics.DrawString((e.RowIndex + 1).ToString(System.Globalization.CultureInfo.CurrentUICulture), this.dataGridView1.DefaultCellStyle.Font, b, e.RowBounds.Location.X + 20, e.RowBounds.Location.Y + 4);

		}

		//新增
		private void btnADD_Click(object sender, EventArgs e)
		{
			if (MasterState == "ADD" || MasterState == "EDIT") //如果当前状态非查看状态
			{
				MessageBox.Show("当前状态为编辑状态");
				return;
			}
			else
			{
				cobFProject.SelectedIndex = -1;

				edtFText.Text = string.Empty;
				edtFYear.Text = string.Empty;
				
				edtZB.Text = string.Empty;


				MasterState = "ADD";
				SetTextBoxState(MasterState);
				bdsMaster.AddNew();
				edtFYear.Focus();


			}

		}

		//修改
		private void tsbtnEdit_Click(object sender, EventArgs e)
		{
			if (bdsMaster.Current == null)
				return;

			if (MasterState == "ADD" || MasterState == "EDIT") //如果当前状态非查看状态
			{
				MessageBox.Show("当前状态为编辑状态");
				return;
			}
			else
			{
				int FID = Convert.ToInt32(((DataRowView)bdsMaster.Current).Row["FID"]);
				FEditID = FID;
				SetFieldValue(FID);
				MasterState = "EDIT";
				SetTextBoxState(MasterState);

			}



		}

		private void btnSave_Click(object sender, EventArgs e)
		{
			if (MasterState == "SEL") //
			{
				MessageBox.Show("查看状态，无法保存");
				return;
			}

			//必填判断

			if (edtFYear.Text == string.Empty)
			{
				MessageBox.Show("年份不能为空");
				edtFYear.Focus();
				return;
			}

			if (cobFProject.SelectedIndex == -1)
			{
				MessageBox.Show("考核部门不能为空");
				cobFProject.Focus();
				return;
			}

			if (edtZB.Text == string.Empty)
			{
				MessageBox.Show("指标不能为空");
				edtZB.Focus();
				return;
			}

			//查重
			string sSQL = string.Empty;
			int FID = 0;


			if (MasterState == "ADD")
			{
				sSQL = " SELECT count(*) from YZ_YearDataByDept where 年份=@年份 and 考核部门=@考核部门   ";

				SqlParameter[] par = new SqlParameter[] 
			           {
			              new SqlParameter("@年份", edtFYear.Text.Trim()),								
										new SqlParameter("@考核部门", cobFProject.Text)
			               
			           };
				if (SqlHelper.Exists(YZConnstring, sSQL, par))
				{
					MessageBox.Show("存在相同的数据，无法保存");
					return;
				}
			}
			else if (MasterState == "EDIT")
			{
				FID = Convert.ToInt32(((DataRowView)bdsMaster.Current).Row["FID"]);
				sSQL = " SELECT count(*) from YZ_YearDataByDept where 年份=@年份 and 考核部门=@考核部门 and FID<>@FID    ";

				SqlParameter[] par = new SqlParameter[] 
			          {
			             new SqlParameter("@年份", edtFYear.Text.Trim()),								
										new SqlParameter("@考核部门", cobFProject.Text),
			             new SqlParameter("@FID", FID)
			           };
				if (SqlHelper.Exists(YZConnstring, sSQL, par))
				{
					MessageBox.Show("存在相同的数据，无法保存");
					return;
				}
			}

			SqlParameter param1 = new SqlParameter("@年份", edtFYear.Text.Trim());
		
			SqlParameter param3 = new SqlParameter("@考核部门", cobFProject.Text);
			SqlParameter param4 = new SqlParameter("@指标", edtZB.Text.Trim());		
			SqlParameter param6 = new SqlParameter("@备注", edtFText.Text.Trim());
			SqlParameter param8 = new SqlParameter("@FID", FID);
	
			if (edtZB.Text == string.Empty)
				param4.Value = DBNull.Value;

	


			//创建泛型
			List<SqlParameter> parameters2 = new List<SqlParameter>();
			parameters2.Add(param1);
		
			parameters2.Add(param3);
			parameters2.Add(param4);		
			parameters2.Add(param6);
			parameters2.Add(param8);


			if (MasterState == "ADD")
			{
				sSQL = " insert into YZ_YearDataByDept(年份,考核部门,指标,备注) values (@年份,@考核部门,@指标,@备注) ";

				if (SqlHelper.ExecuteNonQuery(YZConnstring, sSQL, parameters2.ToArray()) > 0)
				{
					MasterState = "SEL";
					SetTextBoxState(MasterState);
					getDate("Q", sSQLWH);

				}

			}
			else if (MasterState == "EDIT")
			{
				sSQL = " update YZ_YearDataByDept set 年份=@年份,考核部门=@考核部门,指标=@指标,备注=@备注  where FID=@FID";

				if (SqlHelper.ExecuteNonQuery(YZConnstring, sSQL, parameters2.ToArray()) > 0)
				{
					MasterState = "SEL";
					SetTextBoxState(MasterState);
					getDate("Q", sSQLWH);


					int index = bdsMaster.Find("FID", FEditID);//按CompanyName查找IBM
					if (index != -1)
					{
						bdsMaster.Position = index;//定位BindingSource
					}

				}

			}




		}

		private void bdsMaster_CurrentChanged(object sender, EventArgs e)
		{
			if (bdsMaster.Current == null)
				return;

			if (MasterState != "ADD")
			{
				int FID = Convert.ToInt32(((DataRowView)bdsMaster.Current).Row["FID"]);
				MasterState = "SEL";
				SetTextBoxState(MasterState);
				SetFieldValue(FID);
			}
			else
			{




			}





			//if (MasterState == "SEL") //如果当前状态为查看状态
			//{
			//    SetFieldValue(FID);
			//}
			//else //非查看状态
			//{
			//    if (MessageBox.Show("当前数据处于编辑状态，确定要离开？", "软件提示", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
			//    {
			//        MasterState = "SEL";
			//        SetTextBoxState(MasterState);
			//        SetFieldValue(FID);
			//    }
			//    else
			//    {
			//        MessageBox.Show("do it"+FEditID);
			//    }                
			//}





		}

		//删除
		private void btnDelete_Click(object sender, EventArgs e)
		{
			if (bdsMaster.Current == null)
				return;

			if (MasterState == "ADD" || MasterState == "EDIT") //如果当前状态非查看状态
			{
				MessageBox.Show("当前状态为编辑状态");
				return;
			}

			if (MessageBox.Show("确定要删除当前数据？", "软件提示", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
			{
				int FID = Convert.ToInt32(((DataRowView)bdsMaster.Current).Row["FID"]);
				string sSQL = string.Empty;
				sSQL = "DELETE from YZ_YearDataByDept where  FID=@FID  ";

				SqlParameter[] par = new SqlParameter[] 
                {                 
                  new SqlParameter("@FID", FID)
                 };

				if (SqlHelper.ExecuteNonQuery(YZConnstring, sSQL, par) > 0)
				{
					getDate("Q", sSQLWH);
				}
			}

		}

		private void btnClose_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void button1_Click(object sender, EventArgs e)
		{
			sSQLWH = string.Empty;

			if (cobFProjectQ.SelectedIndex != -1)
			{
				sSQLWH += " AND 考核部门='" + cobFProjectQ.Text + "' ";
			}
			if (edtFYearQ.Text != string.Empty)
			{
				sSQLWH += " AND 年份='" + edtFYearQ.Text + "' ";
			}

			getDate("Q", sSQLWH);
		}

		private void button2_Click(object sender, EventArgs e)
		{
			cobFProjectQ.SelectedIndex = -1;
			edtFYearQ.Text = string.Empty;

			sSQLWH = string.Empty;
		}


	}
}
