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
	public partial class frmYZParameterSet : Form
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

		public frmYZParameterSet()
		{
			InitializeComponent();
			SetTextBoxState("SEL");
			k3db = new DataBase(YXK3FZ.DataClass.DataBase.m_Connstr);
		}



		private void frmYZParameterSet_Load(object sender, EventArgs e)
		{
			commUse.CortrolButtonEnabled(btnADD, this);
			commUse.CortrolButtonEnabled(tsbtnEdit, this);

			getDate(string.Empty, string.Empty);
		}


		//加载列表数据
		private void getDate(string Q, string sSQLWH)
		{
			string sSQL = string.Empty;
			sSQL = " SELECT * FROM t_YZParameter e ";		
			sSQL += " Where 1=1 ";
			if (Q != string.Empty) //如果是查询
			{
				sSQL += sSQLWH;
			}
			sSQL += " Order by E.FID ";
			bdsMaster.DataSource = k3db.GetDataSet(sSQL, "sel").Tables[0].DefaultView;
		}


		private void dgvDetail_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e) //显示序号
		{
			SolidBrush b = new SolidBrush(this.dgvDetail.RowHeadersDefaultCellStyle.ForeColor);
			e.Graphics.DrawString((e.RowIndex + 1).ToString(System.Globalization.CultureInfo.CurrentUICulture), this.dgvDetail.DefaultCellStyle.Font, b, e.RowBounds.Location.X + 20, e.RowBounds.Location.Y + 4);

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
				edtFYearTime.Text = string.Empty;
				edtFHourTime.Text = string.Empty;
				edtFDownTime.Text = string.Empty;
				edtFOilNum.Text = string.Empty;

				edtFSO2ByYear.Text = string.Empty;
				txtFSO2ByDay.Text = string.Empty;
				txtFSO2ByStere.Text = string.Empty;
				edtFSO2Num.Text = string.Empty;

				edtFNOXByYear.Text = string.Empty;
				txtFNOXByDay.Text = string.Empty;
				txtFNOXByStere.Text = string.Empty;
				edtFNOXNum.Text = string.Empty;

				edtFSmokeByYear.Text = string.Empty;
				txtFSmokeByDay.Text = string.Empty;
				txtFSmokeByStere.Text = string.Empty;
				edtFSmokeNum.Text = string.Empty;

				edtFSO2Num.Text = "40000";
				edtFNOXNum.Text = "40000";
				edtFSmokeNum.Text = "45000";
				edtFBlastCapacity.Text = "35000";
				
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
				MessageBox.Show("参数年份不能为空");
				edtFYear.Focus();
				return;
			}
			if (edtFYearTime.Text == string.Empty)
			{
				MessageBox.Show("加工时间(天/年)不能为空");
				edtFYearTime.Focus();
				return;
			}
			if (edtFHourTime.Text == string.Empty)
			{
				MessageBox.Show("加工时间(小时/年)不能为空");
				edtFHourTime.Focus();
				return;
			}
			if (edtFDownTime.Text == string.Empty)
			{
				MessageBox.Show("停机时间(小时/年)不能为空");
				edtFDownTime.Focus();
				return;
			}
			if (edtFOilNum.Text == string.Empty)
			{
				MessageBox.Show("油料加工量(吨/年)不能为空");
				edtFOilNum.Focus();
				return;
			}

			if (edtFSO2ByYear.Text == string.Empty)
			{
				MessageBox.Show("二氧化硫(公斤/年)不能为空");
				edtFSO2ByYear.Focus();
				return;
			}
			if (edtFSO2Num.Text == string.Empty)
			{
				MessageBox.Show("二氧化硫折算浓度系数)不能为空");
				edtFSO2Num.Focus();
				return;
			}

			if (edtFNOXByYear.Text == string.Empty)
			{
				MessageBox.Show("氮氧化物(公斤/年)不能为空");
				edtFNOXByYear.Focus();
				return;
			}
			if (edtFNOXNum.Text == string.Empty)
			{
				MessageBox.Show("氮氧化物折算浓度系数)不能为空");
				edtFNOXNum.Focus();
				return;
			}

			if (edtFSmokeByYear.Text == string.Empty)
			{
				MessageBox.Show("烟尘(公斤/年)不能为空");
				edtFSmokeByYear.Focus();
				return;
			}
			if (edtFSmokeNum.Text == string.Empty)
			{
				MessageBox.Show("烟尘折算浓度系数)不能为空");
				edtFSmokeNum.Focus();
				return;
			}

			if (edtFBlastCapacity.Text == string.Empty)
			{
				MessageBox.Show("风量计数备注(m³/h))不能为空");
				edtFBlastCapacity.Focus();
				return;
			}

			//计算特殊字段
			decimal dFSO2 = Convert.ToDecimal(edtFSO2ByYear.Text.Trim()) / Convert.ToDecimal(edtFYearTime.Text.Trim());
			decimal dFNOX = Convert.ToDecimal(edtFNOXByYear.Text.Trim()) / Convert.ToDecimal(edtFYearTime.Text.Trim());
			decimal dFSmoke = Convert.ToDecimal(edtFSmokeByYear.Text.Trim()) / Convert.ToDecimal(edtFYearTime.Text.Trim());

			decimal dFSO2ByStere = 1000000 * (Convert.ToDecimal(edtFSO2ByYear.Text.Trim()) / Convert.ToDecimal(edtFYearTime.Text.Trim())) / 24 / Convert.ToDecimal(edtFSO2Num.Text.Trim());
			decimal dFNOXByStere = 1000000 * (Convert.ToDecimal(edtFNOXByYear.Text.Trim()) / Convert.ToDecimal(edtFYearTime.Text.Trim())) / 24 / Convert.ToDecimal(edtFNOXNum.Text.Trim());
			decimal dFSmokeByStere = 1000000 * (Convert.ToDecimal(edtFSmokeByYear.Text.Trim()) / Convert.ToDecimal(edtFYearTime.Text.Trim())) / 24 / Convert.ToDecimal(edtFSmokeNum.Text.Trim());

			txtFSO2ByDay.Text = dFSO2.ToString("0.00");
			txtFSO2ByStere.Text = dFSO2ByStere.ToString("0.00");

			txtFNOXByDay.Text = dFNOX.ToString("0.00");
			txtFNOXByStere.Text = dFNOXByStere.ToString("0.00");

			txtFSmokeByDay.Text = dFSmoke.ToString("0.00");
			txtFSmokeByStere.Text = dFSmokeByStere.ToString("0.00");



			//查重
			string sSQL = string.Empty;

			if (MasterState == "ADD")
			{
				sSQL = " SELECT count(*) from t_YZParameter where FYear=@FYear  ";

				SqlParameter[] par = new SqlParameter[] 
			           {
			              new SqlParameter("@FYear", edtFYear.Text.Trim())
			               
			           };
				if (SqlHelper.Exists(YXK3FZ.DataClass.DataBase.m_Connstr, sSQL, par))
				{
					MessageBox.Show("存在相同的年份参数，无法保存");
					return;
				}
			}
			else if (MasterState == "EDIT")
			{
				int FID = Convert.ToInt32(((DataRowView)bdsMaster.Current).Row["FID"]);
				sSQL = " SELECT count(*) from t_YZParameter where FYear=@FYear and FID<>@FID    ";

				SqlParameter[] par = new SqlParameter[] 
			          {
			            new SqlParameter("@FYear", edtFYear.Text.Trim()),
			            new SqlParameter("@FID", FID)
			           };
				if (SqlHelper.Exists(YXK3FZ.DataClass.DataBase.m_Connstr, sSQL, par))
				{
					MessageBox.Show("存在相同的年份参数，无法保存");
					return;
				}
			}

			if (MasterState == "ADD")
			{
				sSQL = " insert into t_YZParameter(FYear,FYearTime,FHourTime,FDownTime,FOilNum,FSO2ByYear,FSO2ByDay,FSO2ByStere,FSO2Num,FNOXByYear,FNOXByDay,FNOXByStere,FNOXNum,FSmokeByYear,FSmokeByDay,FSmokeByStere,FSmokeNum,FBlastCapacity) values (@FYear,@FYearTime,@FHourTime,@FDownTime,@FOilNum,@FSO2ByYear,@FSO2ByDay,@FSO2ByStere,@FSO2Num,@FNOXByYear,@FNOXByDay,@FNOXByStere,@FNOXNum,@FSmokeByYear,@FSmokeByDay,@FSmokeByStere,@FSmokeNum,@FBlastCapacity) ";
				SqlParameter[] par = new SqlParameter[] 
			          {
			           new SqlParameter("@FYear", edtFYear.Text.Trim()),
			           new SqlParameter("@FYearTime", edtFYearTime.Text.Trim()),
			           new SqlParameter("@FHourTime", edtFHourTime.Text.Trim()),
			           new SqlParameter("@FDownTime", edtFDownTime.Text.Trim()),
			           new SqlParameter("@FOilNum", edtFOilNum.Text.Trim()),

			           new SqlParameter("@FSO2ByYear", edtFSO2ByYear.Text.Trim()),
			           new SqlParameter("@FSO2ByDay", txtFSO2ByDay.Text.Trim()),
			           new SqlParameter("@FSO2ByStere", txtFSO2ByStere.Text.Trim()),
			           new SqlParameter("@FSO2Num", edtFSO2Num.Text.Trim()),

			           new SqlParameter("@FNOXByYear", edtFNOXByYear.Text.Trim()),
			           new SqlParameter("@FNOXByDay", txtFNOXByDay.Text.Trim()),
			           new SqlParameter("@FNOXByStere", txtFNOXByStere.Text.Trim()),
			           new SqlParameter("@FNOXNum", edtFNOXNum.Text.Trim()),

			           new SqlParameter("@FSmokeByYear", edtFSmokeByYear.Text.Trim()),
			           new SqlParameter("@FSmokeByDay", txtFSmokeByDay.Text.Trim()),
			           new SqlParameter("@FSmokeByStere", txtFSmokeByStere.Text.Trim()),
			           new SqlParameter("@FSmokeNum", edtFSmokeNum.Text.Trim()),

			           new SqlParameter("@FBlastCapacity", edtFBlastCapacity.Text.Trim())              
                   
			           };

				if (SqlHelper.ExecuteNonQuery(YXK3FZ.DataClass.DataBase.m_Connstr, sSQL, par) > 0)
				{
					MasterState = "SEL";
					SetTextBoxState(MasterState);
					getDate(string.Empty, string.Empty);				

				}

			}
			else if (MasterState == "EDIT")
			{
				sSQL = " update t_YZParameter set FYear=@FYear,FYearTime=@FYearTime,FHourTime=@FHourTime,FDownTime=@FDownTime,FOilNum=@FOilNum,FSO2ByYear=@FSO2ByYear,FSO2ByDay=@FSO2ByDay,FSO2ByStere=@FSO2ByStere,FSO2Num=@FSO2Num,FNOXByYear=@FNOXByYear,FNOXByDay=@FNOXByDay,FNOXByStere=@FNOXByStere,FNOXNum=@FNOXNum,FSmokeByYear=@FSmokeByYear,FSmokeByDay=@FSmokeByDay,FSmokeByStere=@FSmokeByStere,FSmokeNum=@FSmokeNum,FBlastCapacity=@FBlastCapacity where FID=@FID";
				SqlParameter[] par = new SqlParameter[] 
			          {
			            new SqlParameter("@FID", FEditID),
			           new SqlParameter("@FYear", edtFYear.Text.Trim()),
			           new SqlParameter("@FYearTime", edtFYearTime.Text.Trim()),
			           new SqlParameter("@FHourTime", edtFHourTime.Text.Trim()),
			           new SqlParameter("@FDownTime", edtFDownTime.Text.Trim()),
			           new SqlParameter("@FOilNum", edtFOilNum.Text.Trim()),

			           new SqlParameter("@FSO2ByYear", edtFSO2ByYear.Text.Trim()),
			           new SqlParameter("@FSO2ByDay", txtFSO2ByDay.Text.Trim()),
			           new SqlParameter("@FSO2ByStere", txtFSO2ByStere.Text.Trim()),
			           new SqlParameter("@FSO2Num", edtFSO2Num.Text.Trim()),

			           new SqlParameter("@FNOXByYear", edtFNOXByYear.Text.Trim()),
			           new SqlParameter("@FNOXByDay", txtFNOXByDay.Text.Trim()),
			           new SqlParameter("@FNOXByStere", txtFNOXByStere.Text.Trim()),
			           new SqlParameter("@FNOXNum", edtFNOXNum.Text.Trim()),

			           new SqlParameter("@FSmokeByYear", edtFSmokeByYear.Text.Trim()),
			           new SqlParameter("@FSmokeByDay", txtFSmokeByDay.Text.Trim()),
			           new SqlParameter("@FSmokeByStere", txtFSmokeByStere.Text.Trim()),
			           new SqlParameter("@FSmokeNum", edtFSmokeNum.Text.Trim()),

			           new SqlParameter("@FBlastCapacity", edtFBlastCapacity.Text.Trim())                
                   
			           };
				if (SqlHelper.ExecuteNonQuery(YXK3FZ.DataClass.DataBase.m_Connstr, sSQL, par) > 0)
				{
					MasterState = "SEL";
					SetTextBoxState(MasterState);
					getDate(string.Empty, string.Empty);


					int index = bdsMaster.Find("FID", FEditID);//按CompanyName查找IBM
					if (index != -1)
					{
						bdsMaster.Position = index;//定位BindingSource
					}

				}

			}






		}

		
		//退出
		private void btnClose_Click(object sender, EventArgs e)
		{
			if (MessageBox.Show("确定要退出吗？", "软件提示", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
			{
				this.Close();
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

		private void SetFieldValue(int FID)
		{
			string sSQL = string.Empty;
			sSQL = " SELECT * FROM t_YZParameter e ";		
			sSQL += " Where e.FID=@FID ";

			SqlParameter[] par = new SqlParameter[] {
			       new SqlParameter("@FID", FID)
			    };

			DataTable dttSQL = SqlHelper.ExecuteDataTable(YXK3FZ.DataClass.DataBase.m_Connstr, sSQL, par);

			if (dttSQL.Rows.Count > 0)
			{

				edtFYear.Text = dttSQL.Rows[0]["FYear"].ToString();
				edtFYearTime.Text = dttSQL.Rows[0]["FYearTime"].ToString();
				edtFHourTime.Text = dttSQL.Rows[0]["FHourTime"].ToString();
				edtFDownTime.Text = dttSQL.Rows[0]["FDownTime"].ToString();
				edtFOilNum.Text = dttSQL.Rows[0]["FOilNum"].ToString();

				edtFSO2ByYear.Text = dttSQL.Rows[0]["FSO2ByYear"].ToString();
				txtFSO2ByDay.Text = dttSQL.Rows[0]["FSO2ByDay"].ToString();
				txtFSO2ByStere.Text = dttSQL.Rows[0]["FSO2ByStere"].ToString();
				edtFSO2Num.Text = dttSQL.Rows[0]["FSO2Num"].ToString();

				edtFNOXByYear.Text = dttSQL.Rows[0]["FNOXByYear"].ToString();
				txtFNOXByDay.Text = dttSQL.Rows[0]["FNOXByDay"].ToString();
				txtFNOXByStere.Text = dttSQL.Rows[0]["FNOXByStere"].ToString();
				edtFNOXNum.Text = dttSQL.Rows[0]["FNOXNum"].ToString();

				edtFSmokeByYear.Text = dttSQL.Rows[0]["FSmokeByYear"].ToString();
				txtFSmokeByDay.Text = dttSQL.Rows[0]["FSmokeByDay"].ToString();
				txtFSmokeByStere.Text = dttSQL.Rows[0]["FSmokeByStere"].ToString();
				edtFSmokeNum.Text = dttSQL.Rows[0]["FSmokeNum"].ToString();

				edtFBlastCapacity.Text = dttSQL.Rows[0]["FBlastCapacity"].ToString();
			}
			else
			{
				edtFYear.Text = string.Empty;
				edtFYearTime.Text = string.Empty;
				edtFHourTime.Text = string.Empty;
				edtFDownTime.Text = string.Empty;
				edtFOilNum.Text = string.Empty;

				edtFSO2ByYear.Text = string.Empty;
				txtFSO2ByDay.Text = string.Empty;
				txtFSO2ByStere.Text = string.Empty;
				edtFSO2Num.Text = string.Empty;
			

				edtFNOXByYear.Text = string.Empty;
				txtFNOXByDay.Text = string.Empty;
				txtFNOXByStere.Text = string.Empty;
				edtFNOXNum.Text = string.Empty;
			

				edtFSmokeByYear.Text = string.Empty;
				txtFSmokeByDay.Text = string.Empty;
				txtFSmokeByStere.Text = string.Empty;
				edtFSmokeNum.Text = string.Empty;
				
			
				edtFBlastCapacity.Text = string.Empty;

			}

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



	}
}
