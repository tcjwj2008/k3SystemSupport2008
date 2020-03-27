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
	public partial class frmYZProject : Form
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


		public frmYZProject()
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
			sSQL = "SELECT  FID,FName FROM YZ_project where FType=1";

			DataTable dttSQL1 = k3db.GetDataTable("SELECT  FID,FName FROM YZ_project where FType=1", "A1");
			DataTable dttSQL2 = k3db.GetDataTable("SELECT  FID,FName FROM YZ_project where FType=2", "A2");
			DataTable dttSQL3 = k3db.GetDataTable("SELECT  FID,FName FROM YZ_project where FType=3", "A3");

			DataTable dttSQL1Q = dttSQL1.Copy();
			DataTable dttSQL2Q = dttSQL2.Copy();
			DataTable dttSQL3Q = dttSQL3.Copy();


			cobFPID1.DataSource = dttSQL1;
			cobFPID1.ValueMember = "FID";
			cobFPID1.DisplayMember = "FName";
			cobFPID1.SelectedIndex = -1;

			cobFPID2.DataSource = dttSQL2;
			cobFPID2.ValueMember = "FID";
			cobFPID2.DisplayMember = "FName";
			cobFPID2.SelectedIndex = -1;

			cobFPID3.DataSource = dttSQL3;
			cobFPID3.ValueMember = "FID";
			cobFPID3.DisplayMember = "FName";
			cobFPID3.SelectedIndex = -1;


			//查询

			cobFPID1Q.DataSource = dttSQL1Q;
			cobFPID1Q.ValueMember = "FID";
			cobFPID1Q.DisplayMember = "FName";
			cobFPID1Q.SelectedIndex = -1;

			cobFPID2Q.DataSource = dttSQL2Q;
			cobFPID2Q.ValueMember = "FID";
			cobFPID2Q.DisplayMember = "FName";
			cobFPID2Q.SelectedIndex = -1;

			cobFPID3Q.DataSource = dttSQL3Q;
			cobFPID3Q.ValueMember = "FID";
			cobFPID3Q.DisplayMember = "FName";
			cobFPID3Q.SelectedIndex = -1;




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
					edtFCode.ReadOnly = true; //代码不修改
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
			sSQL = " SELECT E.*,FPID1Desc=p1.Fname,FPID2Desc=p2.Fname,FPID3Desc=p3.Fname FROM YZ_projectList e ";
			sSQL += " left join YZ_project P1 on e.FPID1=P1.FID ";
			sSQL += " left join YZ_project P2 on e.FPID2=P2.FID ";
			sSQL += " left join YZ_project P3 on e.FPID3=P3.FID ";
			sSQL += " Where e.FID=@FID ";

			SqlParameter[] par = new SqlParameter[] {
			       new SqlParameter("@FID", FID)
			    };

			DataTable dttSQL = SqlHelper.ExecuteDataTable(YZConnstring, sSQL, par);

			if (dttSQL.Rows.Count > 0)
			{
				cobFPID1.SelectedValue = dttSQL.Rows[0]["FPID1"];
				cobFPID2.SelectedValue = dttSQL.Rows[0]["FPID2"];
				cobFPID3.SelectedValue = dttSQL.Rows[0]["FPID3"];
				edtFText.Text = dttSQL.Rows[0]["FText"].ToString();
				edtFOrderID.Text = dttSQL.Rows[0]["FOrderID"].ToString();
				edtFCode.Text = dttSQL.Rows[0]["FCode"].ToString(); 

			}
			else
			{
				cobFPID1.SelectedIndex = -1;
				cobFPID2.SelectedIndex = -1;
				cobFPID3.SelectedIndex = -1;
				edtFText.Text = string.Empty;
				edtFOrderID.Text = string.Empty;
				edtFCode.Text = string.Empty;

			}

		}


		//加载列表数据
		private void getDate(string Q, string sSQLWH)
		{			
			string sSQL = string.Empty;
			sSQL = " SELECT E.*,FPID1Desc=p1.Fname,FPID2Desc=p2.Fname,FPID3Desc=p3.Fname FROM YZ_projectList e ";
			sSQL += " left join YZ_project P1 on e.FPID1=P1.FID ";
			sSQL += " left join YZ_project P2 on e.FPID2=P2.FID ";
			sSQL += " left join YZ_project P3 on e.FPID3=P3.FID ";
			sSQL += " Where 1=1 ";
			if (Q != string.Empty) //如果是查询
			{
				sSQL += sSQLWH;
			}
			sSQL += " Order by E.FOrderID ";
			bdsMaster.DataSource = k3db.GetDataSet(sSQL, "sel").Tables[0].DefaultView;

		}

		private void frmYZProject_Load(object sender, EventArgs e)
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
				cobFPID1.SelectedIndex = -1;
				cobFPID2.SelectedIndex = -1;
				cobFPID3.SelectedIndex = -1;
				edtFText.Text = string.Empty;
				edtFOrderID.Text = string.Empty;
				edtFCode.Text = string.Empty;
			

				MasterState = "ADD";
				SetTextBoxState(MasterState);
				bdsMaster.AddNew();
				edtFCode.Focus();


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

			if (edtFCode.Text== string.Empty)
			{
				MessageBox.Show("代码不能为空");
				edtFCode.Focus();
				return;
			}

			if (cobFPID1.SelectedIndex==-1)
			{
				MessageBox.Show("环节不能为空");
				cobFPID1.Focus();
				return;
			}

			if (cobFPID2.SelectedIndex == -1)
			{
				MessageBox.Show("项目不能为空");
				cobFPID2.Focus();
				return;
			}

			if (cobFPID3.SelectedIndex == -1)
			{
				MessageBox.Show("小项不能为空");
				cobFPID3.Focus();
				return;
			}


			if (edtFOrderID.Text ==string.Empty)
			{
				MessageBox.Show("排序不能为空");
				edtFOrderID.Focus();
				return;
			}

			//查重
			string sSQL = string.Empty;






			if (MasterState == "ADD")
			{
				sSQL = " SELECT count(*) from YZ_ProjectList where FPID1=@FPID1 and FPID2=@FPID2 and FPID3=@FPID3  ";

				SqlParameter[] par = new SqlParameter[] 
			           {
			              new SqlParameter("@FPID1", cobFPID1.SelectedValue),
									  new SqlParameter("@FPID2", cobFPID2.SelectedValue),
										new SqlParameter("@FPID3", cobFPID3.SelectedValue)
			               
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
				sSQL = " SELECT count(*) from YZ_ProjectList where FPID1=@FPID1 and FPID2=@FPID2 and FPID3=@FPID3 and FID<>@FID    ";

				SqlParameter[] par = new SqlParameter[] 
			          {
			              new SqlParameter("@FPID1", cobFPID1.SelectedValue),
									  new SqlParameter("@FPID2", cobFPID2.SelectedValue),
										new SqlParameter("@FPID3", cobFPID3.SelectedValue),
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
				sSQL = " insert into YZ_ProjectList(FPID1,FPID2,FPID3,FText,FOrderID,FCode) values (@FPID1,@FPID2,@FPID3,@FText,@FOrderID,@FCode) ";
				SqlParameter[] par = new SqlParameter[] 
			          {
			            new SqlParameter("@FPID1", cobFPID1.SelectedValue),
									  new SqlParameter("@FPID2", cobFPID2.SelectedValue),
										new SqlParameter("@FPID3", cobFPID3.SelectedValue),
										new SqlParameter("@FOrderID", edtFOrderID.Text.Trim()),
											new SqlParameter("@FCode", edtFCode.Text.Trim()),
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
				sSQL = " update YZ_ProjectList set FPID1=@FPID1,FPID2=@FPID2,FPID3=@FPID3,FText=@FText,FOrderID=@FOrderID  where FID=@FID";
				SqlParameter[] par = new SqlParameter[] 
			          {
			            new SqlParameter("@FID", FEditID),
			          new SqlParameter("@FPID1", cobFPID1.SelectedValue),
									  new SqlParameter("@FPID2", cobFPID2.SelectedValue),
										new SqlParameter("@FPID3", cobFPID3.SelectedValue),
										new SqlParameter("@FOrderID", edtFOrderID.Text.Trim()),
										//	new SqlParameter("@FCode", edtFCode.Text.Trim()),
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


		//清空
		private void button2_Click(object sender, EventArgs e)
		{
			cobFPID1Q.SelectedIndex = -1;
			cobFPID2Q.SelectedIndex = -1;
			cobFPID3Q.SelectedIndex = -1;

			sSQLWH = string.Empty;

		}

		//查询
		private void button1_Click(object sender, EventArgs e)
		{
			 sSQLWH = string.Empty;

			if (cobFPID1Q.SelectedIndex!= -1)
			{
				sSQLWH += " AND FPID1='"+cobFPID1Q.SelectedValue+"' ";
			}
			if (cobFPID2Q.SelectedIndex != -1)
			{
				sSQLWH += " AND FPID2='" + cobFPID2Q.SelectedValue + "' ";
			}

			if (cobFPID3Q.SelectedIndex != -1)
			{
				sSQLWH += " AND FPID3='" + cobFPID3Q.SelectedValue + "' ";
			}

			getDate("Q", sSQLWH);


		}

		private void btnClose_Click(object sender, EventArgs e)
		{
			this.Close();
		}




	}
}
