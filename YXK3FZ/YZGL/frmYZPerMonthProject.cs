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
	public partial class frmYZPerMonthProject : Form
	{

		DataBase db = new DataBase();
		DataSet ds = null;
		DataBase k3db = null;
		CommonUse commUse = new CommonUse();

		string ordertablename = "YZ_Base";
		string entrytablename = "YZ_BaseEntry";

		string fnamenum = "";

		int FEditID = 0; //修改时的编号


		string MasterState = "SEL";//类型 判断窗体是新增还是编辑状态 ADD EDIT SEL

		public frmYZPerMonthProject()
		{
			InitializeComponent();
			SetTextBoxState("SEL");
			k3db = new DataBase(YXK3FZ.DataClass.DataBase.m_Connstr);
		}

		//加载列表数据
		private void getDate(int FYear)
		{

			DataBase db = new DataBase();

			WaitFormService.CreateWaitForm();
			WaitFormService.SetWaitFormCaption(" 正在查询，请稍候......");


			SqlParameter param1 = new SqlParameter("@FYear", SqlDbType.Int);
			param1.Value = FYear;

		
			

			//创建泛型
			List<SqlParameter> parameters2 = new List<SqlParameter>();
			parameters2.Add(param1);
		

			//把泛型中的元素复制到数组中
			SqlParameter[] inputParameters2 = parameters2.ToArray();
			try
			{
				bdsMaster.DataSource = db.GetDataTable("sp_YZPerMonthProject_Select", inputParameters2);

			}
			catch (Exception ex)
			{
				WaitFormService.CloseWaitForm();
				MessageBox.Show("查询失败!" + ex.ToString(), "软件提示");
				return;

			}
			WaitFormService.CloseWaitForm();
			


		}





		private void frmYZPerMonthProject_Load(object sender, EventArgs e)
		{
			commUse.CortrolButtonEnabled(btnADD, this);
			commUse.CortrolButtonEnabled(tsbtnEdit, this);
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
				edtFYear.Text = string.Empty;
				edtFMonth.Text = string.Empty;
				edtFMonthDay.Text = string.Empty;

				edtFServicePlan.Text = string.Empty;
				txtFServiceReal.Text = string.Empty;
				edtFActivePlan.Text = string.Empty;
				edtFActiveReal.Text = string.Empty;
				edtFWorkPlan.Text = string.Empty;
				txtFWorkReal.Text = string.Empty;

				txtFWork.Text = string.Empty;
				txtFDown.Text = string.Empty;
				txtFAmount.Text = string.Empty;


				edtFNote.Text = string.Empty;
			

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

		//保存
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

			if (edtFMonth.Text == string.Empty)
			{
				MessageBox.Show("月份不能为空");
				edtFMonth.Focus();
				return;
			}

			if (edtFMonthDay.Text == string.Empty)
			{
				MessageBox.Show("日历天数不能为空");
				edtFMonthDay.Focus();
				return;
			}

			//edtFServicePlan 维修计划天数
			//edtFActivePlan 活动计划天数
			//edtFWorkPlan 加工计划天数
			if (edtFServicePlan.Text == string.Empty)
			{
				MessageBox.Show("维修计划天数不能为空");
				edtFServicePlan.Focus();
				return;
			}

			if (edtFActivePlan.Text == string.Empty)
			{
				MessageBox.Show("活动计划天数不能为空");
				edtFActivePlan.Focus();
				return;
			}

			if (edtFActiveReal.Text == string.Empty)
			{
				MessageBox.Show("活动实际天数不能为空");
				edtFActiveReal.Focus();
				return;
			}

			

			if (edtFWorkPlan.Text == string.Empty)
			{
				MessageBox.Show("加工计划天数不能为空");
				edtFWorkPlan.Focus();
				return;
			}

			//查重
			string sSQL = string.Empty;

			if (MasterState == "ADD")
			{
				sSQL = " SELECT count(*) from t_YZPerMonthProject where FYear=@FYear and FMonth=@FMonth  ";

				SqlParameter[] par = new SqlParameter[] 
			           {
			              new SqlParameter("@FYear", edtFYear.Text.Trim()),
										 new SqlParameter("@FMonth", edtFMonth.Text.Trim())
			               
			           };
				if (SqlHelper.Exists(YXK3FZ.DataClass.DataBase.m_Connstr, sSQL, par))
				{
					MessageBox.Show("存在相同的年、月份参数，无法保存");
					return;
				}
			}

			if (MasterState == "ADD")
			{
				sSQL = " insert into t_YZPerMonthProject(FYear, FMonth, FMonthDay, FDate,  FServicePlan, FActivePlan,FActiveReal,  FWorkPlan, FNote ) values (@FYear, @FMonth, @FMonthDay, @FDate,  @FServicePlan, @FActivePlan,@FActiveReal,  @FWorkPlan, @FNote) ";
				SqlParameter[] par = new SqlParameter[] 
			          {
			           new SqlParameter("@FYear", edtFYear.Text.Trim()),
			           new SqlParameter("@FMonth", edtFMonth.Text.Trim()),
			           new SqlParameter("@FMonthDay", edtFMonthDay.Text.Trim()),
			           new SqlParameter("@FDate", edtFYear.Text.Trim()+"-"+edtFMonth.Text.Trim()),
			           new SqlParameter("@FServicePlan", edtFServicePlan.Text.Trim()),
                 new SqlParameter("@FActivePlan", edtFActivePlan.Text.Trim()),
								 new SqlParameter("@FActiveReal", edtFActiveReal.Text.Trim()),
			           new SqlParameter("@FWorkPlan", edtFWorkPlan.Text.Trim()),		         

			           new SqlParameter("@FNote", edtFNote.Text.Trim())              
                   
			           };

				if (SqlHelper.ExecuteNonQuery(YXK3FZ.DataClass.DataBase.m_Connstr, sSQL, par) > 0)
				{
					MasterState = "SEL";
					SetTextBoxState(MasterState);
					getDate(Convert.ToInt32(edtFYearQ.Text) );

				}

			}
			else if (MasterState == "EDIT")
			{
				sSQL = " update t_YZPerMonthProject set FServicePlan=@FServicePlan,FActivePlan=@FActivePlan,FActiveReal=@FActiveReal, FWorkPlan=@FWorkPlan where FID=@FID";
				SqlParameter[] par = new SqlParameter[] 
			          {
			            new SqlParameter("@FID", FEditID),
								 //new SqlParameter("@FYear", edtFYear.Text.Trim()),
								 //new SqlParameter("@FMonth", edtFMonth.Text.Trim()),
								 //new SqlParameter("@FMonthDay", edtFMonthDay.Text.Trim()),
								 //new SqlParameter("@FDate", edtFYear.Text.Trim()+"-"+edtFMonth.Text.Trim()),
			           new SqlParameter("@FServicePlan", edtFServicePlan.Text.Trim()),
                 new SqlParameter("@FActivePlan", edtFActivePlan.Text.Trim()),
								 new SqlParameter("@FActiveReal", edtFActiveReal.Text.Trim()),
			           new SqlParameter("@FWorkPlan", edtFWorkPlan.Text.Trim()),		         

			           new SqlParameter("@FNote", edtFNote.Text.Trim())                      
                   
			           };
				if (SqlHelper.ExecuteNonQuery(YXK3FZ.DataClass.DataBase.m_Connstr, sSQL, par) > 0)
				{
					MasterState = "SEL";
					SetTextBoxState(MasterState);
					getDate(Convert.ToInt32(edtFYearQ.Text));


					int index = bdsMaster.Find("FID", FEditID);//按CompanyName查找IBM
					if (index != -1)
					{
						bdsMaster.Position = index;//定位BindingSource
					}

				}

			}





		}

		private void SetFieldValue(int FID)
		{
			string sSQL = string.Empty;
			sSQL = " SELECT *,0 FServiceReal,0 FActiveReal,0 FWorkReal, 0 FWork,0 FDown,0 FAmount FROM t_YZPerMonthProject e ";
			sSQL += " Where e.FID=@FID ";

			SqlParameter[] par = new SqlParameter[] {
			       new SqlParameter("@FID", FID)
			    };

			DataTable dttSQL = SqlHelper.ExecuteDataTable(YXK3FZ.DataClass.DataBase.m_Connstr, sSQL, par);

			if (dttSQL.Rows.Count > 0)
			{
				edtFYear.Text = dttSQL.Rows[0]["FYear"].ToString();
				edtFMonth.Text = dttSQL.Rows[0]["FMonth"].ToString();
				edtFMonthDay.Text = dttSQL.Rows[0]["FMonthDay"].ToString();

				edtFServicePlan.Text = dttSQL.Rows[0]["FServicePlan"].ToString();
				txtFServiceReal.Text = dttSQL.Rows[0]["FServiceReal"].ToString();
				edtFActivePlan.Text = dttSQL.Rows[0]["FActivePlan"].ToString();
				edtFActiveReal.Text = dttSQL.Rows[0]["FActiveReal"].ToString();
				edtFWorkPlan.Text = dttSQL.Rows[0]["FWorkPlan"].ToString();
				txtFWorkReal.Text = dttSQL.Rows[0]["FWorkReal"].ToString();

				txtFWork.Text = dttSQL.Rows[0]["FWork"].ToString();
				txtFDown.Text = dttSQL.Rows[0]["FDown"].ToString();
				txtFAmount.Text = dttSQL.Rows[0]["FAmount"].ToString();


				edtFNote.Text = dttSQL.Rows[0]["FNote"].ToString();

				
			}
			else
			{
				edtFYear.Text = string.Empty;
				edtFMonth.Text = string.Empty;
				edtFMonthDay.Text = string.Empty;

				edtFServicePlan.Text = string.Empty;
				txtFServiceReal.Text = string.Empty;
				edtFActivePlan.Text = string.Empty;
				edtFActiveReal.Text = string.Empty;
				edtFWorkPlan.Text = string.Empty;
				txtFWorkReal.Text = string.Empty;

				txtFWork.Text = string.Empty;
				txtFDown.Text = string.Empty;
				txtFAmount.Text = string.Empty;


				edtFNote.Text = string.Empty;

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


				txtFServiceReal.Text = ((DataRowView)bdsMaster.Current).Row["FServiceReal"].ToString();
				txtFWorkReal.Text = ((DataRowView)bdsMaster.Current).Row["FWorkReal"].ToString();
				txtFWork.Text = ((DataRowView)bdsMaster.Current).Row["FWork"].ToString();
				txtFDown.Text = ((DataRowView)bdsMaster.Current).Row["FDown"].ToString();
				txtFAmount.Text = ((DataRowView)bdsMaster.Current).Row["FAmount"].ToString();




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

		private void SetTextBoxState(string sMasterState)
		{
			// string MasterState = "SEL";//类型 判断窗体是新增还是编辑状态 ADD EDIT SEL
			if (sMasterState == "SEL")
			{
				LabTishi.Text = "状态提示：查看";
				foreach (Control c in tableLayoutPanel1.Controls)
				{
					if (c is TextBox)
					{
						((TextBox)c).ReadOnly = true;
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

					edtFYear.ReadOnly = true;
					edtFMonth.ReadOnly = true;
					edtFMonthDay.ReadOnly = true;
				}

				foreach (Control c in tableLayoutPanel1.Controls)
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
				}
			}
		}


		private void textBox_KeyPress(object sender, KeyPressEventArgs e)
		{
			// 允许输入:数字、退格键(8)、全选(1)、复制(3)、粘贴(22)
			if (!Char.IsDigit(e.KeyChar) && e.KeyChar != 8 &&
			e.KeyChar != 1 && e.KeyChar != 3 && e.KeyChar != 22)
			{
				e.Handled = true;
			}
		}

		private void dataGridView1_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
		{
			SolidBrush b = new SolidBrush(this.dataGridView1.RowHeadersDefaultCellStyle.ForeColor);
			e.Graphics.DrawString((e.RowIndex + 1).ToString(System.Globalization.CultureInfo.CurrentUICulture), this.dataGridView1.DefaultCellStyle.Font, b, e.RowBounds.Location.X + 20, e.RowBounds.Location.Y + 4);

		}

		private void button1_Click(object sender, EventArgs e) //查询
		{
			if (edtFYearQ.Text != string.Empty)
			{
				getDate(Convert.ToInt32(edtFYearQ.Text));
			}
			else
			{
				getDate(-1);
			}
		}

		private void button2_Click(object sender, EventArgs e)
		{
			if(dataGridView1.Rows.Count >0)
			CommExcel.ExportExcel(this.Text+"导出", dataGridView1, true);
		}



		
	}
}
