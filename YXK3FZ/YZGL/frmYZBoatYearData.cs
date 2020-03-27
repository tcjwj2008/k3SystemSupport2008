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
	public partial class frmYZBoatYearData : Form
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


		string MasterState = "SEL";//类型 判断窗体是新增还是编辑状态 ADD EDIT SEL


		public frmYZBoatYearData()
		{
			InitializeComponent();

			SetTextBoxState("SEL");
			//k3db = new DataBase(YXK3FZ.DataClass.DataBase.m_Connstr);
			YZConnstring = db.GetSingleObject("SELECT Fdbstr FROM YXZTLIST WHERE ID=5").ToString();

			k3db = new DataBase(YZConnstring);


			LoadData(); //加载数据

		}

		private void LoadData()
		{
			string sSQL = string.Empty;
			sSQL += "  SELECT E.FID, FName='['+p1.Fname+']-'+'['+p2.Fname+']-'+'['+p3.Fname+']' FROM YZ_projectList e  ";
			sSQL += "  left join YZ_project P1 on e.FPID1=P1.FID  ";
			sSQL += "  left join YZ_project P2 on e.FPID2=P2.FID  ";
			sSQL += "  left join YZ_project P3 on e.FPID3=P3.FID  ";
			sSQL += "   Where 1=1 ";

			//船次
			DataTable dttSQL1 = k3db.GetDataTable("SELECT FItemID, FName FROM dbo.t_Item WHERE FItemClassID=3002 ", "A1");
			
			//项目
			DataTable dttSQL2 = k3db.GetDataTable(sSQL, "A2");

			//部门
			DataTable dttSQL3 = k3db.GetDataTable("SELECT FItemID,FName FROM dbo.t_Department WHERE FNumber LIKE '3007.%' ORDER BY FNumber", "A1");

			DataTable dttSQL1Q = dttSQL1.Copy();
			DataTable dttSQL2Q = dttSQL2.Copy();
			DataTable dttSQL3Q = dttSQL3.Copy();



			cobFDepartID.DataSource = dttSQL3;
			cobFDepartID.ValueMember = "FItemID";
			cobFDepartID.DisplayMember = "FName";
			cobFDepartID.SelectedIndex = -1;

			cobFProjectID.DataSource = dttSQL2;
			cobFProjectID.ValueMember = "FID";
			cobFProjectID.DisplayMember = "FName";
			cobFProjectID.SelectedIndex = -1;

			cobFBoatID.DataSource = dttSQL1;
			cobFBoatID.ValueMember = "FItemID";
			cobFBoatID.DisplayMember = "FName";
			cobFBoatID.SelectedIndex = -1;




			//查询

			cobFDepartIDQ.DataSource = dttSQL3Q;
			cobFDepartIDQ.ValueMember = "FItemID";
			cobFDepartIDQ.DisplayMember = "FName";
			cobFDepartIDQ.SelectedIndex = -1;

			cobFProjectIDQ.DataSource = dttSQL2Q;
			cobFProjectIDQ.ValueMember = "FID";
			cobFProjectIDQ.DisplayMember = "FName";
			cobFProjectIDQ.SelectedIndex = -1;

			cobFBoatIDQ.DataSource = dttSQL1Q;
			cobFBoatIDQ.ValueMember = "FItemID";
			cobFBoatIDQ.DisplayMember = "FName";
			cobFBoatIDQ.SelectedIndex = -1;



		}

		private void SetFieldValue(int FID)
		{
			string sSQL = string.Empty;
			sSQL += " SELECT D.*,e.FCode,  FName='['+p1.Fname+']-'+'['+p2.Fname+']-'+'['+p3.Fname+']',FBoatName=t.FName,FDepartName=t2.FName  FROM YZ_BoatYearData d  ";
			sSQL += " INNER JOIN YZ_projectList e  ON d.FProjectID=e.FID  ";
			sSQL += " INNER JOIN dbo.t_Item t ON t.FItemID=d.FBoatID and FItemClassID=3002  "; //船次
			sSQL += " INNER JOIN dbo.t_Department t2 ON t2.FItemID=d.FDepID  "; //部门
			sSQL += " left join YZ_project P1 on e.FPID1=P1.FID    ";
			sSQL += " left join YZ_project P2 on e.FPID2=P2.FID  ";
			sSQL += " left join YZ_project P3 on e.FPID3=P3.FID  ";

			sSQL += " Where d.FID=@FID ";

			SqlParameter[] par = new SqlParameter[] {
			       new SqlParameter("@FID", FID)
			    };

			DataTable dttSQL = SqlHelper.ExecuteDataTable(YZConnstring, sSQL, par);

			if (dttSQL.Rows.Count > 0)
			{
				cobFBoatID.SelectedValue = dttSQL.Rows[0]["FBoatID"];
				cobFDepartID.SelectedValue = dttSQL.Rows[0]["FDepID"];
				cobFProjectID.SelectedValue = dttSQL.Rows[0]["FProjectID"];
				edtFValue.Text = dttSQL.Rows[0]["FValue"].ToString();

				edtFMoney.Text = dttSQL.Rows[0]["FMoney"].ToString();
				edtFText.Text = dttSQL.Rows[0]["FText"].ToString();



			}
			else
			{
				cobFBoatID.SelectedIndex = -1;
				cobFDepartID.SelectedIndex = -1;
				cobFProjectID.SelectedIndex = -1;
				edtFText.Text = string.Empty;
				edtFMoney.Text = string.Empty;
				edtFValue.Text = string.Empty;


			}

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
					if (c is DateTimePicker)
					{
						((DateTimePicker)c).Enabled = false;
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

					if (c is DateTimePicker)
					{
						((DateTimePicker)c).Enabled = true;
					}

				}
			}
		}

		//加载列表数据
		private void getDate(string Q, string sSQLWH)
		{
			string sSQL = string.Empty;
			sSQL += " SELECT D.*,e.FCode,  FName='['+p1.Fname+']-'+'['+p2.Fname+']-'+'['+p3.Fname+']',FBoatName=t.FName,FDepartName=t2.FName  FROM YZ_BoatYearData d  ";
			sSQL += " INNER JOIN YZ_projectList e  ON d.FProjectID=e.FID  ";
			sSQL += " INNER JOIN dbo.t_Item t ON t.FItemID=d.FBoatID and FItemClassID=3002  "; //船次
			sSQL += " INNER JOIN dbo.t_Department t2 ON t2.FItemID=d.FDepID  "; //部门
			sSQL += " left join YZ_project P1 on e.FPID1=P1.FID    ";
			sSQL += " left join YZ_project P2 on e.FPID2=P2.FID  ";
			sSQL += " left join YZ_project P3 on e.FPID3=P3.FID  ";
			sSQL += " Where 1=1 ";
			if (Q != string.Empty) //如果是查询
			{
				sSQL += sSQLWH;
			}
			sSQL += " Order by E.FCode ";
			bdsMaster.DataSource = k3db.GetDataSet(sSQL, "sel").Tables[0].DefaultView;

		}

		private void dgvDetail_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e) //显示序号
		{
			SolidBrush b = new SolidBrush(this.dataGridView1.RowHeadersDefaultCellStyle.ForeColor);
			e.Graphics.DrawString((e.RowIndex + 1).ToString(System.Globalization.CultureInfo.CurrentUICulture), this.dataGridView1.DefaultCellStyle.Font, b, e.RowBounds.Location.X + 20, e.RowBounds.Location.Y + 4);

		}
	
		private void frmYZBoatYearData_Load(object sender, EventArgs e)
		{
			getDate(string.Empty, string.Empty);
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
				cobFBoatID.SelectedValue = -1;
				cobFDepartID.SelectedIndex = -1;
				cobFProjectID.SelectedIndex = -1;
				edtFValue.Text = string.Empty;
				edtFText.Text = string.Empty;
				edtFMoney.Text = string.Empty;

				MasterState = "ADD";
				SetTextBoxState(MasterState);
				bdsMaster.AddNew();



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


			if (cobFBoatID.SelectedIndex == -1)
			{
				MessageBox.Show("船次不能为空");
				cobFBoatID.Focus();
				return;
			}

			if (cobFDepartID.SelectedIndex == -1)
			{
				MessageBox.Show("部门不能为空");
				cobFDepartID.Focus();
				return;
			}

			if (cobFProjectID.SelectedIndex == -1)
			{
				MessageBox.Show("项目不能为空");
				cobFProjectID.Focus();
				return;
			}

			if (edtFMoney.Text == string.Empty)
			{
				MessageBox.Show("金额不能为空");
				edtFMoney.Focus();
				return;
			}

			if (edtFValue.Text == string.Empty)
			{
				MessageBox.Show("耗用量不能为空");
				edtFValue.Focus();
				return;
			}

			//查重
			string sSQL = string.Empty;




			if (MasterState == "ADD")
			{
				sSQL = " SELECT count(*) from YZ_BoatYearData where FBoatID=@FBoatID and FDepID=@FDepID and FProjectID=@FProjectID  ";

				SqlParameter[] par = new SqlParameter[] 
			           {
			              new SqlParameter("@FBoatID",cobFBoatID.SelectedValue),
									  new SqlParameter("@FDepID", cobFDepartID.SelectedValue),
										new SqlParameter("@FProjectID", cobFProjectID.SelectedValue)
			               
			           };
				if (SqlHelper.Exists(YZConnstring, sSQL, par))
				{
					MessageBox.Show("存在相同的数据，无法保存");
					return;
				}
			}
			else if (MasterState == "EDIT")
			{
				int FID = Convert.ToInt32(((DataRowView)bdsMaster.Current).Row["FID"]);
				sSQL = " SELECT count(*) from YZ_BoatYearData where FBoatID=@FBoatID and FDepID=@FDepID and FProjectID=@FProjectID and FID<>@FID    ";

				SqlParameter[] par = new SqlParameter[] 
			          {
			              new SqlParameter("@FBoatID", cobFBoatID.SelectedValue),
									  new SqlParameter("@FDepID", cobFDepartID.SelectedValue),
										new SqlParameter("@FProjectID", cobFProjectID.SelectedValue),
			             new SqlParameter("@FID", FID)
			           };
				if (SqlHelper.Exists(YZConnstring, sSQL, par))
				{
					MessageBox.Show("存在相同的数据，无法保存");
					return;
				}
			}

			if (MasterState == "ADD")
			{
				sSQL = " insert into YZ_BoatYearData(FBoatID,FDepID,FProjectID,FValue,FMoney,FText) values (@FBoatID,@FDepID,@FProjectID,@FValue,@FMoney,@FText) ";
				SqlParameter[] par = new SqlParameter[] 
			          {
			               new SqlParameter("@FBoatID",cobFBoatID.SelectedValue),
									  new SqlParameter("@FDepID", cobFDepartID.SelectedValue),
										new SqlParameter("@FProjectID", cobFProjectID.SelectedValue),
										new SqlParameter("@FValue", edtFValue.Text.Trim()),
										new SqlParameter("@FMoney", edtFMoney.Text.Trim()),
			             new SqlParameter("@FText", edtFText.Text.Trim())              
                   
			           };

				if (SqlHelper.ExecuteNonQuery(YZConnstring, sSQL, par) > 0)
				{
					MasterState = "SEL";
					SetTextBoxState(MasterState);
					getDate("Q", sSQLWH);

				}

			}
			else if (MasterState == "EDIT")
			{
				sSQL = " update YZ_BoatYearData set FBoatID=@FBoatID,FDepID=@FDepID,FProjectID=@FProjectID,FValue=@FValue,FMoney=@FMoney,FText=@FText  where FID=@FID";
				SqlParameter[] par = new SqlParameter[] 
			          {
			            new SqlParameter("@FID", FEditID),
			          new SqlParameter("@FBoatID", cobFBoatID.SelectedValue),
									  new SqlParameter("@FDepID", cobFDepartID.SelectedValue),
										new SqlParameter("@FProjectID", cobFProjectID.SelectedValue),
										new SqlParameter("@FValue", edtFValue.Text.Trim()),
											new SqlParameter("@FMoney", edtFMoney.Text.Trim()),
			             new SqlParameter("@FText", edtFText.Text.Trim())                       
                   
			           };
				if (SqlHelper.ExecuteNonQuery(YZConnstring, sSQL, par) > 0)
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

		private void button1_Click(object sender, EventArgs e) //查询
		{
			sSQLWH = string.Empty;

			if (cobFBoatIDQ.SelectedIndex != -1)
			{
				sSQLWH += " AND d.FBoatID='" + cobFBoatIDQ.SelectedValue + "' ";
			}
			if (cobFDepartIDQ.SelectedIndex != -1)
			{
				sSQLWH += " AND d.FDepID='" + cobFDepartIDQ.SelectedValue + "' ";
			}

			if (cobFProjectIDQ.SelectedIndex != -1)
			{
				sSQLWH += " AND d.FProjectID='" + cobFProjectIDQ.SelectedValue + "' ";
			}

			getDate("Q", sSQLWH);
		}

		private void button2_Click(object sender, EventArgs e) //清空
		{
			cobFBoatIDQ.SelectedIndex = -1;
			cobFDepartIDQ.SelectedIndex = -1;
			cobFProjectIDQ.SelectedIndex = -1;

			sSQLWH = string.Empty;
		}

		private void btnClose_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		//删除
		private void btnDelete_Click(object sender, EventArgs e)
		{
			if (bdsMaster.Current == null)
				return;

			if (MessageBox.Show("确定要删除当前数据？", "软件提示", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
			{
				int FID = Convert.ToInt32(((DataRowView)bdsMaster.Current).Row["FID"]);
				string sSQL = string.Empty;
				sSQL = "DELETE from YZ_BoatYearData where  FID=@FID  ";

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




	}
}
