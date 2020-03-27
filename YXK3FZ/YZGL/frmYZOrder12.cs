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
    public partial class frmYZOrder12 : Form
    {
			DataBase db = new DataBase();
			DataSet ds = null;
			CommonUse commUse = new CommonUse();
			DataBase k3db = null;

			string sCurrentID = string.Empty; //当前编辑的内码
			string sCaption = string.Empty; //窗口标题

			string MasterState = "SEL";//类型 判断窗体是新增还是编辑状态 ADD EDIT SEL


						/// <summary>
			/// 窗口加载事件
			/// </summary>
			/// <param name="sMasterState">类型ADD EDIT</param>
			/// <param name="sID">内码ID</param>
			public frmYZOrder12(string sMasterState, string sID)
          {
              InitializeComponent();
							MasterState=sMasterState; //状态
							sCurrentID = sID;
							sCaption = this.Text;

							k3db = new DataBase(YXK3FZ.DataClass.DataBase.m_Connstr);

							InitCobDate();//加载参数
					    LoadPower(); //加载权限

							//MasterState = "SEL";

							SetButtonState(MasterState);
							SetTextState(MasterState);

							if (MasterState == "SEL" || MasterState == "EDIT")
							{
								LoadDate(sID);
								commUse.CortrolButtonEnabled(btnADD, this);
								commUse.CortrolButtonEnabled(btnEdit, this);
								if (txtFState.Text == "已审核" || txtFState.Text == "已确认")
								{
									btnEdit.Enabled = false;
								}
							}
							else if (MasterState == "ADD")
							{
								if (bADD)
								{
									btnADD_Click(null, null);
								}
								else
								{
									btnADD.Enabled = false;
									btnEdit.Enabled = false;
									btnSave.Enabled = false;
								}
							}

          }

				//加载权限
			bool bADD = false;
			private void LoadPower()
				{
					commUse.CortrolButtonEnabled(btnADD, this);
					bADD = btnADD.Enabled;
				}
		
			//控制按钮状态
			private void SetButtonState(string MasterState)
			{
				if (MasterState == "SEL") //查看状态
				{
					btnADD.Enabled = true;
					btnEdit.Enabled = true;
					btnSave.Enabled = false;
					this.Text = sCaption + "(-查看)";
				 
				}
				else if (MasterState == "ADD") //新增状态
				{
					btnADD.Enabled = false;
					btnEdit.Enabled = false;
					btnSave.Enabled = true;
					this.Text = sCaption + "(-新增)";
				}
				else if (MasterState == "EDIT")//修改状态
				{
					btnADD.Enabled = false;
					btnEdit.Enabled = false;
					btnSave.Enabled = true;
					this.Text = sCaption + "(-修改)";
				}
			}

			//控制文本框状态
			private void SetTextState(string MasterState)
			{
				if (MasterState == "SEL") //查看状态
				{
					foreach (Control c in tableLayoutPanel1.Controls)
					{
						if (c is TextBox)
						{
							((TextBox)c).ReadOnly = true;
						}
						else if (c is ComboBox)
						{
							((ComboBox)c).Enabled = false;
						}
						else if (c is DateTimePicker)
						{
							((DateTimePicker)c).Enabled = false;
						}
					}
				}
				else if (MasterState == "ADD") //新增状态
				{
					foreach (Control c in tableLayoutPanel1.Controls)
					{
						if (c is TextBox)
						{
							if (((TextBox)c).Name.Substring(0, 3) == "edt")
							{
								((TextBox)c).ReadOnly = false;
							}
						}
						else if (c is ComboBox)
						{
							((ComboBox)c).Enabled = true;
						}
						else if (c is DateTimePicker)
						{
							((DateTimePicker)c).Enabled = true;
						}
					}
				}
				else if (MasterState == "EDIT")//修改状态
				{
					foreach (Control c in tableLayoutPanel1.Controls)
					{
						if (c is TextBox)
						{
							if (((TextBox)c).Name.Substring(0, 3) == "edt")
							{
								((TextBox)c).ReadOnly = false;
							}
						}
						else if (c is ComboBox)
						{
							((ComboBox)c).Enabled = false;
						}
						else if (c is DateTimePicker)
						{
							((DateTimePicker)c).Enabled = false;
						}
					}
				}

			}

			//根据内码加载数据
			private void LoadDate(string sID)
			{
				string sSQL = string.Empty;

				sSQL += " SELECT  b1.FName FClassName,b2.FShortName FBoatName, ";
				sSQL += " FStateDesc=CASE WHEN FState='0' THEN '未审核' WHEN FState='1' THEN '已审核'  ELSE '已确认' END, ";
				sSQL += "  t.* FROM TAB12 t ";
				sSQL += " INNER JOIN YZ_BaseEntry b1 ON t.FClassID=b1.FID AND b1.FUID=1 ";
				sSQL += " INNER JOIN YZ_BaseEntry b2 ON t.FBoatID=b2.FID AND b2.FUID=2 ";
				sSQL += " Where t.ID='"+sID+"'";	
				DataTable dttSQL = k3db.GetDataTable(sSQL, "A");
				if (dttSQL.Rows.Count > 0)
				{
					cobFClassID.SelectedValue = dttSQL.Rows[0]["FClassID"].ToString();
					cobFBoatID.SelectedValue = dttSQL.Rows[0]["FBoatID"].ToString();
					txtFDate.Text = dttSQL.Rows[0]["FDate"].ToString();

					edtFField01.Text = dttSQL.Rows[0]["FField01"].ToString();
					edtFField02.Text = dttSQL.Rows[0]["FField02"].ToString();
					edtFField03.Text = dttSQL.Rows[0]["FField03"].ToString();
					edtFField04.Text = dttSQL.Rows[0]["FField04"].ToString();
					edtFField05.Text = dttSQL.Rows[0]["FField05"].ToString();
					edtFField06.Text = dttSQL.Rows[0]["FField06"].ToString();
					edtFField07.Text = dttSQL.Rows[0]["FField07"].ToString();
					edtFField08.Text = dttSQL.Rows[0]["FField08"].ToString();
					edtFField09.Text = dttSQL.Rows[0]["FField09"].ToString();
					edtFField10.Text = dttSQL.Rows[0]["FField10"].ToString();
					edtFField11.Text = dttSQL.Rows[0]["FField11"].ToString();
					edtFField12.Text = dttSQL.Rows[0]["FField12"].ToString();
					edtFField13.Text = dttSQL.Rows[0]["FField13"].ToString();

					edtFRemark.Text = dttSQL.Rows[0]["FRemark"].ToString();
					txtFNewUser.Text = dttSQL.Rows[0]["FNewUser"].ToString();
					txtFNewDate.Text = dttSQL.Rows[0]["FNewDate"].ToString();
					txtFCheckUser.Text = dttSQL.Rows[0]["FCheckUser"].ToString();
					txtFCheckDate.Text = dttSQL.Rows[0]["FCheckDate"].ToString();
					txtFState.Text = dttSQL.Rows[0]["FStateDesc"].ToString();
				}
				else
				{
					MessageBox.Show("传递的内码数据有误，无法加载数据...");
					return;
				}
				

			}

			

					/// <summary>
					/// 加载参数
					/// </summary>
			private void InitCobDate()
					{
						string sSQL = string.Empty;

						//加载参数数据
						sSQL = " SELECT FID,FName FROM YZ_BaseEntry WHERE FUID=1";					
						DataTable dttSQL01 = k3db.GetDataTable(sSQL,"01");
						cobFClassID.DataSource = dttSQL01;
						cobFClassID.ValueMember = "FID";
						cobFClassID.DisplayMember = "FName";
						cobFClassID.SelectedIndex = -1;

						sSQL = " SELECT FID,FName FROM YZ_BaseEntry WHERE FUID=2";						
						DataTable dttSQL02 = k3db.GetDataTable(sSQL, "02");
						cobFBoatID.DataSource = dttSQL02;
						cobFBoatID.ValueMember = "FID";
						cobFBoatID.DisplayMember = "FName";
						cobFBoatID.SelectedIndex = -1;

					
					}

			private void frmOrder_Load(object sender, EventArgs e)
			{
				//窗体加载

				//权限控制 
				//commUse.CortrolButtonEnabled(btnADD, this);
				//commUse.CortrolButtonEnabled(tsbtnEdit, this);
				//commUse.CortrolButtonEnabled(btnSave, this);
				//commUse.CortrolButtonEnabled(btnConfirmer, this);
				//commUse.CortrolButtonEnabled(btnHConfirmer, this);
				//commUse.CortrolButtonEnabled(btnCheck, this);
				//commUse.CortrolButtonEnabled(btnHcheck, this);       


			}

			/// <summary>
			/// 新增事件
			/// </summary>
			/// <param name="sender"></param>
			/// <param name="e"></param>
			private void btnADD_Click(object sender, EventArgs e)
			{

				MasterState = "ADD";
				SetButtonState(MasterState);
				SetTextState(MasterState);

				//cobFClassID.SelectedIndex = -1;
				//cobFBoatID.SelectedIndex = -1;
				//txtFRunTimeByDay.Text = string.Empty;
				//txtFRunTimeByHour.Text = string.Empty;
				//txtFDownTimeByHour.Text = string.Empty;
				//txtFAmountOfFinish.Text = string.Empty;
				//txtFConsumptionByTon.Text = string.Empty;
				//txtFPerConsumption.Text = string.Empty;
				//txtFEmployeeNum.Text = string.Empty;
				//txtFIllDeviceNum.Text = string.Empty;
				//txtFServiceDevice.Text = string.Empty;
				//txtFRemark.Text = string.Empty;

				txtFNewUser.Text = PropertyClass.OperatorName;
				txtFNewDate.Text = db.GetCurrentDate();//DateTime.Now.ToString("yyyy-MM-dd");
				txtFCheckUser.Text = string.Empty;
				txtFCheckDate.Text = string.Empty;

				txtFState.Text = "未审核";

			}
			/// <summary>
			/// 修改事件
			/// </summary>
			/// <param name="sender"></param>
			/// <param name="e"></param>
			private void tsbtnEdit_Click(object sender, EventArgs e)
			{
				MasterState = "EDIT";
				SetButtonState(MasterState);
				SetTextState(MasterState);

				LoadDate(sCurrentID);


			}
			/// <summary>
			/// 保存事件
			/// </summary>
			/// <param name="sender"></param>
			/// <param name="e"></param>
			private void btnSave_Click(object sender, EventArgs e)
			{
				string sSQL = string.Empty;

				#region 保存判断
				//保存判断
				if (cobFClassID.SelectedIndex == -1)
				{
					MessageBox.Show("班次不能为空");
					cobFClassID.Focus();
					return;
				}
				if (cobFBoatID.SelectedIndex == -1)
				{
					MessageBox.Show("船次不能为空");
					cobFBoatID.Focus();
					return;
				}

				if (edtFField01.Text==string.Empty)
				{
					MessageBox.Show("粕产量(吨)不能为空");
					edtFField01.Focus();
					return;
				}
				if (edtFField02.Text == string.Empty)
				{
					MessageBox.Show("考核水分(%)不能为空");
					edtFField02.Focus();
					return;
				}
				if (edtFField03.Text == string.Empty)
				{
					MessageBox.Show("平均水分(%)不能为空");
					edtFField03.Focus();
					return;
				}
				if (edtFField04.Text == string.Empty)
				{
					MessageBox.Show("合格率(%)不能为空");
					edtFField04.Focus();
					return;
				}
				if (edtFField05.Text == string.Empty)
				{
					MessageBox.Show("湿粕-平均残油(%)不能为空");
					edtFField05.Focus();
					return;
				}
				if (edtFField06.Text == string.Empty)
				{
					MessageBox.Show("湿粕残油-合格率(%)不能为空");
					edtFField06.Focus();
					return;
				}
				if (edtFField07.Text == string.Empty)
				{
					MessageBox.Show("粕残油-平均残油(%)不能为空");
					edtFField07.Focus();
					return;
				}
				if (edtFField08.Text == string.Empty)
				{
					MessageBox.Show("粕残油-合格率(%)不能为空");
					edtFField08.Focus();
					return;
				}
				if (edtFField09.Text == string.Empty)
				{
					MessageBox.Show("粕粗-平均粗蛋白(%)不能为空");
					edtFField09.Focus();
					return;
				}
				if (edtFField10.Text == string.Empty)
				{
					MessageBox.Show("粕粗蛋白-合格率(%)不能为空");
					edtFField10.Focus();
					return;
				}
				if (edtFField11.Text == string.Empty)
				{
					MessageBox.Show("加热试验-合格率(%)不能为空");
					edtFField11.Focus();
					return;
				}
				if (edtFField12.Text == string.Empty)
				{
					MessageBox.Show("平均蓝色增加值不能为空");
					edtFField12.Focus();
					return;
				}
				if (edtFField13.Text == string.Empty)
				{
					MessageBox.Show("蓝色值-合格率(%)不能为空");
					edtFField13.Focus();
					return;
				}

				if (edtFRemark.Text == string.Empty)
				{
					MessageBox.Show("备注不能为空");
					edtFRemark.Focus();
					return;
				}

				#endregion

				#region 查重判断

				sSQL = " select * from TAB12 where FClassID='" + cobFClassID.SelectedValue + "' ";
				sSQL += " and FBoatID='" + cobFBoatID.SelectedValue + "'";
				sSQL += " and FDate='" + txtFDate.Text + "'";
				if (MasterState == "EDIT") //修改要过滤自己
				{
					sSQL += " and ID <> '" + sCurrentID + "'";
				}

				DataTable dttSQL = k3db.GetDataTable(sSQL, "A");
				if (dttSQL.Rows.Count > 0)
				{
					MessageBox.Show("日期为" + txtFDate.Text + ",班次为" + cobFClassID.Text + ",船次" + cobFBoatID.Text + ",数据已保存");
					return;
				}


				#endregion

				#region 保存
				if (MasterState == "ADD") //新增保存
				{
					sSQL = " INSERT INTO TAB12 ";
					sSQL += " ( ";
					sSQL += " FClassID, FBoatID ,FDate, ";
					sSQL += " FField01,FField02,FField03,FField04,FField05,  ";
					sSQL += " FField06,FField07,FField08,FField09,FField10, ";
					sSQL += " FField11,FField12,FField13, ";
					sSQL += " FRemark,FNewUser	,FNewDate	,FState	 ";
					sSQL += " )  ";
					sSQL += " VALUES  ";
					sSQL += " (@FClassID, @FBoatID ,@FDate, ";
					sSQL += " @FField01,@FField02,@FField03,@FField04,@FField05,  ";
					sSQL += " @FField06,@FField07,@FField08,@FField09,@FField10, ";
					sSQL += " @FField11,@FField12,@FField13, ";
					sSQL += " @FRemark,	@FNewUser	,@FNewDate	,@FState	)";

					SqlParameter[] par = new SqlParameter[] 
                 {
                     new SqlParameter("@FClassID", cobFClassID.SelectedValue),
                     new SqlParameter("@FBoatID",cobFBoatID.SelectedValue),
										 new SqlParameter("@FDate",Convert.ToDateTime(txtFDate.Text).ToString("yyyy-MM-dd")),

										  new SqlParameter("@FField01",edtFField01.Text.Trim()),
										 new SqlParameter("@FField02",edtFField02.Text.Trim()),
										 new SqlParameter("@FField03",edtFField03.Text.Trim()),
										 new SqlParameter("@FField04",edtFField04.Text.Trim()),
										 new SqlParameter("@FField05",edtFField05.Text.Trim()),
										 new SqlParameter("@FField06",edtFField06.Text.Trim()),
										 new SqlParameter("@FField07",edtFField07.Text.Trim()),
										 new SqlParameter("@FField08",edtFField08.Text.Trim()),
										 new SqlParameter("@FField09",edtFField09.Text.Trim()),
										 new SqlParameter("@FField10",edtFField10.Text.Trim()),
										  new SqlParameter("@FField11",edtFField11.Text.Trim()),
											 new SqlParameter("@FField12",edtFField12.Text.Trim()),
											 new SqlParameter("@FField13",edtFField13.Text.Trim()),

										 new SqlParameter("@FRemark",edtFRemark.Text.Trim()),
										 new SqlParameter("@FNewUser",txtFNewUser.Text.Trim()),
										  new SqlParameter("@FNewDate",db.GetCurrentDate()),
										 new SqlParameter("@FState","0")

                 };

					if (SqlHelper.ExecuteNonQuery(YXK3FZ.DataClass.DataBase.m_Connstr, sSQL, par) > 0)
					{
						//获取当前的保存内码
						sSQL = "select ID FROM TAB12 WHERE FClassID=@FClassID and FBoatID=@FBoatID and  FDate=@FDate ";
						SqlParameter[] par2 = new SqlParameter[] 
                 {
                     new SqlParameter("@FClassID", cobFClassID.SelectedValue),
                     new SqlParameter("@FBoatID",cobFBoatID.SelectedValue),
										 new SqlParameter("@FDate",txtFDate.Text)
								 };
						sCurrentID = SqlHelper.ExecuteScalar(YXK3FZ.DataClass.DataBase.m_Connstr, sSQL, par2).ToString();
						LoadDate(sCurrentID);

						MasterState = "SEL";
						SetButtonState(MasterState);
						SetTextState(MasterState);

					}

				}
				else if (MasterState == "EDIT") //修改保存
				{
					sSQL = " update TAB12 set FField01=@FField01,FField02=@FField02,FField03=@FField03,FField04=@FField04, ";
					sSQL += " FField05=@FField05,FField06=@FField06,FField07=@FField07,FField08=@FField08, ";
					sSQL += " FField09=@FField09,FField10=@FField10,FField11=@FField11, ";
					sSQL += " FField12=@FField12,FField13=@FField13, ";
					sSQL += " FRemark=@FRemark,FNewDate=@FNewDate where ID=@ID	 ";
					SqlParameter[] par = new SqlParameter[] 
                 {
                     new SqlParameter("@ID", sCurrentID),                    
										 new SqlParameter("@FField01",edtFField01.Text.Trim()),
										 new SqlParameter("@FField02",edtFField02.Text.Trim()),
										 new SqlParameter("@FField03",edtFField03.Text.Trim()),
										 new SqlParameter("@FField04",edtFField04.Text.Trim()),
										 new SqlParameter("@FField05",edtFField05.Text.Trim()),
										 new SqlParameter("@FField06",edtFField06.Text.Trim()),
										 new SqlParameter("@FField07",edtFField07.Text.Trim()),
										 new SqlParameter("@FField08",edtFField08.Text.Trim()),
										 new SqlParameter("@FField09",edtFField09.Text.Trim()),
										 new SqlParameter("@FField10",edtFField10.Text.Trim()),
										  new SqlParameter("@FField11",edtFField11.Text.Trim()),
											 new SqlParameter("@FField12",edtFField12.Text.Trim()),
											 new SqlParameter("@FField13",edtFField13.Text.Trim()),
											  new SqlParameter("@FNewDate",db.GetCurrentDate()),
										 new SqlParameter("@FRemark",edtFRemark.Text.Trim())										

                 };

					if (SqlHelper.ExecuteNonQuery(YXK3FZ.DataClass.DataBase.m_Connstr, sSQL, par) > 0)
					{
						MasterState = "SEL";
						SetButtonState(MasterState);
						SetTextState(MasterState);
						LoadDate(sCurrentID);

					}

				}


				#endregion



			}

    
    }
}
