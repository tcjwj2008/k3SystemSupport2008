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
	public partial class frmOA_YZ02 : Form
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

		public frmOA_YZ02()
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
			sSQL = " SELECT * FROM YZ_SubContract e ";
			sSQL += " Where e.FID=@FID ";

			SqlParameter[] par = new SqlParameter[] {
			       new SqlParameter("@FID", FID)
			    };

			DataTable dttSQL = SqlHelper.ExecuteDataTable(YZConnstring, sSQL, par);

			if (dttSQL.Rows.Count > 0)
			{
				edtFSubContractNumber.Text = dttSQL.Rows[0]["FSubContractNumber"].ToString();
				txtFHXState.Text = dttSQL.Rows[0]["FHXState"].ToString();
				cobFFPState.Text = dttSQL.Rows[0]["FFPState"].ToString();
				edtFDJMoney.Text = dttSQL.Rows[0]["FDJMoney"].ToString();
				edtFHKMoney.Text = dttSQL.Rows[0]["FHKMoney"].ToString();
				edtFTKMoney.Text = dttSQL.Rows[0]["FTKMoney"].ToString();
				edtFText.Text = dttSQL.Rows[0]["FText"].ToString();
			}
			else
			{
				edtFSubContractNumber.Text = string.Empty;
				txtFHXState.Text = string.Empty;
				cobFFPState.SelectedIndex = -1;		
				edtFDJMoney.Text = string.Empty;
				edtFHKMoney.Text = string.Empty;
				edtFTKMoney.Text = string.Empty;
				edtFText.Text = string.Empty;

			}

		}

		//加载列表数据
		private void getDate(string Q, string sSQLWH)
		{
			string sSQL = string.Empty;
			sSQL = " SELECT E.* FROM YZ_SubContract e ";
			sSQL += " Where 1=1 ";
			if (Q != string.Empty) //如果是查询
			{
				sSQL += sSQLWH;
			}
			else
			{
				sSQL += " and FHXState='否' ";  //默认取未核销
			}
			sSQL += " Order by FSubContractNumber ";
			bdsMaster.DataSource = k3db.GetDataSet(sSQL, "sel").Tables[0].DefaultView;

		}

		private void frmOA_YZ02_Load(object sender, EventArgs e)
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
				edtFSubContractNumber.Text = string.Empty;
				txtFHXState.Text = string.Empty;
				cobFFPState.SelectedIndex = -1;
				edtFDJMoney.Text = string.Empty;
				edtFHKMoney.Text = string.Empty;
				edtFTKMoney.Text = string.Empty;
				edtFText.Text = string.Empty;

				MasterState = "ADD";
				SetTextBoxState(MasterState);
				bdsMaster.AddNew();
				edtFSubContractNumber.Focus();

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

				if (txtFHXState.Text == "是")
				{
					MessageBox.Show("当前副合同编号已核销，无法修改");
					return;
				}
			
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

			if (edtFSubContractNumber.Text == string.Empty)
			{
				MessageBox.Show("副合同号不能为空");
				edtFSubContractNumber.Focus();
				return;
			}

			if (cobFFPState.SelectedIndex == -1)
			{
				MessageBox.Show("开票状态不能为空");
				cobFFPState.Focus();
				return;
			}

			if (edtFDJMoney.Text == string.Empty)
			{
				MessageBox.Show("定金不能为空");
				edtFDJMoney.Focus();
				return;
			}

			if (edtFHKMoney.Text == string.Empty)
			{
				MessageBox.Show("货款不能为空");
				edtFHKMoney.Focus();
				return;
			}

			if (edtFTKMoney.Text == string.Empty)
			{
				MessageBox.Show("退款不能为空");
				edtFTKMoney.Focus();
				return;
			}

			//查重
			string sSQL = string.Empty;
			int FID =0;


			if (MasterState == "ADD")
			{
				sSQL = " SELECT count(*) from YZ_SubContract where FSubContractNumber=@FSubContractNumber   ";

				SqlParameter[] par = new SqlParameter[] 
			           {
			              new SqlParameter("@FSubContractNumber", edtFSubContractNumber.Text.Trim())								
										
			               
			           };
				if (SqlHelper.Exists(YZConnstring, sSQL, par))
				{
					MessageBox.Show("存在相同的副合同编号数据，无法保存");
					return;
				}
			}
			else if (MasterState == "EDIT")
			{
				 FID = Convert.ToInt32(((DataRowView)bdsMaster.Current).Row["FID"]);
				sSQL = " SELECT count(*) from YZ_SubContract where FSubContractNumber=@FSubContractNumber and FID<>@FID    ";

				SqlParameter[] par = new SqlParameter[] 
			          {
			             new SqlParameter("@FSubContractNumber", edtFSubContractNumber.Text.Trim()),						
			             new SqlParameter("@FID", FID)
			           };
				if (SqlHelper.Exists(YZConnstring, sSQL, par))
				{
					MessageBox.Show("存在相同的副合同编号数据，无法保存");
					return;
				}
			}

			SqlParameter param1 = new SqlParameter("@FSubContractNumber", edtFSubContractNumber.Text.Trim());
			SqlParameter param2 = new SqlParameter("@FHXState", txtFHXState.Text.Trim());
			SqlParameter param3 = new SqlParameter("@FFPState", cobFFPState.Text);
			SqlParameter param4 = new SqlParameter("@FDJMoney", edtFDJMoney.Text.Trim());
			SqlParameter param5 = new SqlParameter("@FHKMoney", edtFHKMoney.Text.Trim());
			SqlParameter param7 = new SqlParameter("@FTKMoney", edtFTKMoney.Text.Trim());
			SqlParameter param6 = new SqlParameter("@FText", edtFText.Text.Trim());
			SqlParameter param8 = new SqlParameter("@FID", FID);

			if (MasterState == "ADD")
			{
				param2.Value = "否"; //新增状态 :核销状态＝否
			}
			else
			{
				
			}

			//创建泛型
			List<SqlParameter> parameters2 = new List<SqlParameter>();
			parameters2.Add(param1);
			parameters2.Add(param2);
			parameters2.Add(param3);
			parameters2.Add(param4);
			parameters2.Add(param5);
			parameters2.Add(param6);
			parameters2.Add(param7);
			parameters2.Add(param8);


			if (MasterState == "ADD")
			{
				sSQL = " insert into YZ_SubContract(FSubContractNumber,FHXState,FFPState,FDJMoney,FHKMoney,FTKMoney,FText) values (@FSubContractNumber,@FHXState,@FFPState,@FDJMoney,@FHKMoney,@FTKMoney,@FText) ";

				if (SqlHelper.ExecuteNonQuery(YZConnstring, sSQL, parameters2.ToArray()) > 0)
				{
					MasterState = "SEL";
					SetTextBoxState(MasterState);
					getDate("Q", sSQLWH);

				}

			}
			else if (MasterState == "EDIT")
			{
				sSQL = " update YZ_SubContract set FSubContractNumber=@FSubContractNumber,FHXState=@FHXState,FFPState=@FFPState,FDJMoney=@FDJMoney,FHKMoney=@FHKMoney,FTKMoney=@FTKMoney,FText=@FText  where FID=@FID";

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
			edtFSubContractNumber.Text = string.Empty;
			txtFHXState.Text = string.Empty;
			cobFFPState.SelectedIndex = -1;
			edtFDJMoney.Text = string.Empty;
			edtFHKMoney.Text = string.Empty;
			edtFTKMoney.Text = string.Empty;
			edtFText.Text = string.Empty;

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

		//删除:如果已核销，提示无法删除
		private void btnDelete_Click(object sender, EventArgs e)
		{
			if (bdsMaster.Current == null)
				return;

			if (MasterState == "ADD" || MasterState == "EDIT") //如果当前状态非查看状态
			{
				MessageBox.Show("当前状态为编辑状态");
				return;
			}

			int FID = Convert.ToInt32(((DataRowView)bdsMaster.Current).Row["FID"]);
			string sSQL = string.Empty;

			SetFieldValue(FID);

			if (txtFHXState.Text == "是")
			{
				MessageBox.Show("当前副合同编号已核销，无法删除");
				return;
			}
			


			if (MessageBox.Show("确定要删除当前数据？", "软件提示", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
			{

				sSQL = "DELETE from YZ_SubContract where  FID=@FID  ";

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

		
			if (edtFSubContractNumberQ.Text != string.Empty)
			{
				sSQLWH += " AND FSubContractNumber='" + edtFSubContractNumberQ.Text + "' ";
			}
			if (cobFFPStateQ.SelectedIndex != -1)
			{
				sSQLWH += " AND FFPState='" + cobFFPStateQ.Text + "' ";
			}
			if (cobFHXStateQ.SelectedIndex != -1)
			{
				sSQLWH += " AND FHXState='" + cobFHXStateQ.Text + "' ";
			}

			getDate("Q", sSQLWH);
		}

		private void button2_Click(object sender, EventArgs e)
		{
			cobFFPStateQ.SelectedIndex = -1;
			edtFSubContractNumberQ.Text = string.Empty;
			cobFHXStateQ.SelectedIndex = -1;

			sSQLWH = string.Empty;
			getDate("", string.Empty);
		}

		private void btnConfirmer_Click(object sender, EventArgs e) //核销
		{
			if (bdsMaster.Current == null)
				return;

			if (MasterState == "ADD" || MasterState == "EDIT") //如果当前状态非查看状态
			{
				MessageBox.Show("当前状态为编辑状态");
				return;
			}

			int FID = Convert.ToInt32(((DataRowView)bdsMaster.Current).Row["FID"]);
			string sSQL = string.Empty;

			SetFieldValue(FID);

			if (txtFHXState.Text == "是")
			{
				MessageBox.Show("当前副合同编号已核销");
				return;
			}

			if (MessageBox.Show("确定要核销当前数据？", "软件提示", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
			{
				sSQL = "update   YZ_SubContract set FHXState='是' where  FID=@FID  ";

				SqlParameter[] par = new SqlParameter[] 
                {                 
                  new SqlParameter("@FID", FID)
                 };

				if (SqlHelper.ExecuteNonQuery(YZConnstring, sSQL, par) > 0)
				{
					SetFieldValue(FID);
				}
			}


		}

		private void btnHConfirmer_Click(object sender, EventArgs e)//反核销
		{
			if (bdsMaster.Current == null)
				return;

			if (MasterState == "ADD" || MasterState == "EDIT") //如果当前状态非查看状态
			{
				MessageBox.Show("当前状态为编辑状态");
				return;
			}

			int FID = Convert.ToInt32(((DataRowView)bdsMaster.Current).Row["FID"]);
			string sSQL = string.Empty;

			SetFieldValue(FID);

			if (txtFHXState.Text == "否")
			{
				MessageBox.Show("当前副合同编号未核销");
				return;
			}

			if (MessageBox.Show("确定要反核销当前数据？", "软件提示", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
			{

				sSQL = "update   YZ_SubContract set FHXState='否' where  FID=@FID  ";

				SqlParameter[] par = new SqlParameter[] 
                {                 
                  new SqlParameter("@FID", FID)
                 };

				if (SqlHelper.ExecuteNonQuery(YZConnstring, sSQL, par) > 0)
				{
					SetFieldValue(FID);
					
				}
			}

		}

	}
}
