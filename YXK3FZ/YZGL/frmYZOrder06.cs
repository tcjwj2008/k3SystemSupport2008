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
    public partial class frmYZOrder06 : Form
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

						public frmYZOrder06(string sMasterState, string sID)
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

				sSQL += " SELECT  b1.FName FClassName,b2.FShortName FBoatName,FRunTimeByDay=CAST( FRunTimeByHour/8 as decimal(18,4)), ";

				sSQL += " FStateDesc=CASE WHEN FState='0' THEN '未审核' WHEN FState='1' THEN '已审核'  ELSE '已确认' END, ";
				sSQL += "  t.* FROM TAB06 t ";
				sSQL += " INNER JOIN YZ_BaseEntry b1 ON t.FClassID=b1.FID AND b1.FUID=1 ";
				sSQL += " INNER JOIN YZ_BaseEntry b2 ON t.FBoatID=b2.FID AND b2.FUID=2 ";
				sSQL += " Where t.ID='" + sID + "'";
				DataTable dttSQL = k3db.GetDataTable(sSQL, "A");
				if (dttSQL.Rows.Count > 0)
				{
					cobFClassID.SelectedValue = dttSQL.Rows[0]["FClassID"].ToString();
					cobFBoatID.SelectedValue = dttSQL.Rows[0]["FBoatID"].ToString();
					txtFDate.Text = dttSQL.Rows[0]["FDate"].ToString();
					txtFRunTimeByDay.Text = dttSQL.Rows[0]["FRunTimeByDay"].ToString();

					edtFRunTimeByHour.Text = dttSQL.Rows[0]["FRunTimeByHour"].ToString();
					edtFDownTimeByHour.Text = dttSQL.Rows[0]["FDownTimeByHour"].ToString();
					edtFAmountOfFinish.Text = dttSQL.Rows[0]["FAmountOfFinish"].ToString();

					txtFZC_CJ.Text = dttSQL.Rows[0]["FZC_CJ"].ToString();
					txtFZC_GL.Text = dttSQL.Rows[0]["FZC_GL"].ToString();
					txtFZC_TC.Text = dttSQL.Rows[0]["FZC_TC"].ToString();
					txtFZC_YK.Text = dttSQL.Rows[0]["FZC_YK"].ToString();
					txtFZC_PK.Text = dttSQL.Rows[0]["FZC_PK"].ToString();

					edtFGZ_CJ.Text = dttSQL.Rows[0]["FGZ_CJ"].ToString();
					edtFGZ_GL.Text = dttSQL.Rows[0]["FGZ_GL"].ToString();
					edtFGZ_TC.Text = dttSQL.Rows[0]["FGZ_TC"].ToString();
					edtFGZ_YK.Text = dttSQL.Rows[0]["FGZ_YK"].ToString();
					edtFGZ_PK.Text = dttSQL.Rows[0]["FGZ_PK"].ToString();
					edtFGZ_SW.Text = dttSQL.Rows[0]["FGZ_SW"].ToString();
					edtFGZ_PD.Text = dttSQL.Rows[0]["FGZ_PD"].ToString();
					edtFGZ_JX.Text = dttSQL.Rows[0]["FGZ_JX"].ToString();
					edtFGZ_QT.Text = dttSQL.Rows[0]["FGZ_QT"].ToString();

					edtFSB_CJ.Text = dttSQL.Rows[0]["FSB_CJ"].ToString();
					edtFSB_GL.Text = dttSQL.Rows[0]["FSB_GL"].ToString();
					edtFSB_TC.Text = dttSQL.Rows[0]["FSB_TC"].ToString();
					edtFSB_YK.Text = dttSQL.Rows[0]["FSB_YK"].ToString();
					edtFSB_PK.Text = dttSQL.Rows[0]["FSB_PK"].ToString();
					edtFSB_SW.Text = dttSQL.Rows[0]["FSB_SW"].ToString();
					edtFSB_PD.Text = dttSQL.Rows[0]["FSB_PD"].ToString();
					edtFSB_JX.Text = dttSQL.Rows[0]["FSB_JX"].ToString();
					edtFSB_QT.Text = dttSQL.Rows[0]["FSB_QT"].ToString();


					edtFEmployeeNum.Text = dttSQL.Rows[0]["FEmployeeNum"].ToString();
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
				DataTable dttSQL01 = k3db.GetDataTable(sSQL, "01");
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
				if (edtFRunTimeByHour.Text == string.Empty)
				{
					MessageBox.Show("加工时间(小时)不能为空");
					edtFRunTimeByHour.Focus();
					return;
				}
				if (edtFDownTimeByHour.Text == string.Empty)
				{
					MessageBox.Show("停机时间(小时)不能为空");
					edtFDownTimeByHour.Focus();
					return;
				}


				decimal dFRunTimeByHour = Convert.ToDecimal(edtFRunTimeByHour.Text.Trim());
				decimal dFDownTimeByHour = Convert.ToDecimal(edtFDownTimeByHour.Text.Trim());
				decimal dResult = 0;

				if (dFDownTimeByHour == 0) //如果停机时间为0
				{
					dResult = 100;
				}
				else
				{
					if (dFRunTimeByHour == 0) //如果开工时间为0
					{
						dResult = 0;
					}
					else
					{
						dResult = (dFRunTimeByHour - dFDownTimeByHour) * 100 / dFRunTimeByHour;
					}
				}

				txtFZC_CJ.Text = dResult.ToString("0.00");
				txtFZC_GL.Text = dResult.ToString("0.00");
				txtFZC_TC.Text = dResult.ToString("0.00");
				txtFZC_YK.Text = dResult.ToString("0.00");
				txtFZC_PK.Text = dResult.ToString("0.00");

				if (edtFAmountOfFinish.Text == string.Empty)
				{
					MessageBox.Show("油料加工量(吨)不能为空");
					edtFAmountOfFinish.Focus();
					return;
				}


				if (edtFGZ_CJ.Text == string.Empty)
				{
					MessageBox.Show("工作票-车间(张)不能为空");
					edtFGZ_CJ.Focus();
					return;
				}
				if (edtFGZ_GL.Text == string.Empty)
				{
					MessageBox.Show("工作票-锅炉(张)不能为空");
					edtFGZ_GL.Focus();
					return;
				}
				if (edtFGZ_TC.Text == string.Empty)
				{
					MessageBox.Show("工作票-筒仓(张)不能为空");
					edtFGZ_TC.Focus();
					return;
				}
				if (edtFGZ_YK.Text == string.Empty)
				{
					MessageBox.Show("工作票-油库(张)不能为空");
					edtFGZ_YK.Focus();
					return;
				}
				if (edtFGZ_PK.Text == string.Empty)
				{
					MessageBox.Show("工作票-粕库(张)不能为空");
					edtFGZ_PK.Focus();
					return;
				}
				if (edtFGZ_SW.Text == string.Empty)
				{
					MessageBox.Show("工作票-水务(张)不能为空");
					edtFGZ_SW.Focus();
					return;
				}
				if (edtFGZ_PD.Text == string.Empty)
				{
					MessageBox.Show("工作票-配电(张)不能为空");
					edtFGZ_PD.Focus();
					return;
				}
				if (edtFGZ_JX.Text == string.Empty)
				{
					MessageBox.Show("工作票-机修(张)不能为空");
					edtFGZ_JX.Focus();
					return;
				}
				if (edtFGZ_QT.Text == string.Empty)
				{
					MessageBox.Show("工作票-其它(张)不能为空");
					edtFGZ_QT.Focus();
					return;
				}

				if (txtFZC_CJ.Text == string.Empty)
				{
					MessageBox.Show("正常运行率-车间(%)不能为空");
					txtFZC_CJ.Focus();
					return;
				}
				if (txtFZC_GL.Text == string.Empty)
				{
					MessageBox.Show("正常运行率-锅炉(%)不能为空");
					txtFZC_GL.Focus();
					return;
				}
				if (txtFZC_TC.Text == string.Empty)
				{
					MessageBox.Show("正常运行率-筒仓(%)不能为空");
					txtFZC_TC.Focus();
					return;
				}
				if (txtFZC_YK.Text == string.Empty)
				{
					MessageBox.Show("正常运行率-油库(%)不能为空");
					txtFZC_YK.Focus();
					return;
				}
				if (txtFZC_PK.Text == string.Empty)
				{
					MessageBox.Show("正常运行率-粕库(%)不能为空");
					txtFZC_PK.Focus();
					return;
				}


				if (edtFSB_CJ.Text == string.Empty)
				{
					MessageBox.Show("维修设备-车间(小时)不能为空");
					edtFSB_CJ.Focus();
					return;
				}
				if (edtFSB_GL.Text == string.Empty)
				{
					MessageBox.Show("维修设备-锅炉(小时)不能为空");
					edtFSB_GL.Focus();
					return;
				}
				if (edtFSB_TC.Text == string.Empty)
				{
					MessageBox.Show("维修设备-筒仓(小时)不能为空");
					edtFSB_TC.Focus();
					return;
				}
				if (edtFSB_YK.Text == string.Empty)
				{
					MessageBox.Show("维修设备-油库(小时)不能为空");
					edtFSB_YK.Focus();
					return;
				}
				if (edtFSB_PK.Text == string.Empty)
				{
					MessageBox.Show("维修设备-粕库(小时)不能为空");
					edtFSB_PK.Focus();
					return;
				}
				if (edtFSB_SW.Text == string.Empty)
				{
					MessageBox.Show("维修设备-水务(小时)不能为空");
					edtFSB_SW.Focus();
					return;
				}
				if (edtFSB_PD.Text == string.Empty)
				{
					MessageBox.Show("维修设备-配电(小时)不能为空");
					edtFSB_PD.Focus();
					return;
				}
				if (edtFSB_JX.Text == string.Empty)
				{
					MessageBox.Show("维修设备-机修(小时)不能为空");
					edtFSB_JX.Focus();
					return;
				}
				if (edtFSB_QT.Text == string.Empty)
				{
					MessageBox.Show("维修设备-其它(小时)不能为空");
					edtFSB_QT.Focus();
					return;
				}




				if (edtFEmployeeNum.Text == string.Empty)
				{
					MessageBox.Show("在岗人员(个)不能为空");
					edtFEmployeeNum.Focus();
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

				sSQL = " select * from TAB06 where FClassID='" + cobFClassID.SelectedValue + "' ";
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
					sSQL = " INSERT INTO TAB06 ";
					sSQL += " ( ";
					sSQL += " FClassID, FBoatID ,FDate,FRunTimeByHour	,FDownTimeByHour,FAmountOfFinish	, ";
					sSQL += " FGZ_CJ,FGZ_GL,FGZ_TC,FGZ_YK,FGZ_PK,FGZ_SW,FGZ_PD,FGZ_JX,FGZ_QT, ";
					sSQL += " FZC_CJ,FZC_GL,FZC_TC,FZC_YK,FZC_PK, ";
					sSQL += " FSB_CJ,FSB_GL,FSB_TC,FSB_YK,FSB_PK,FSB_SW,FSB_PD,FSB_JX,FSB_QT,";
					sSQL += " FEmployeeNum	,FRemark,FNewUser	,FNewDate	,FState	 ";
					sSQL += " )  ";
					sSQL += " VALUES  ";
					sSQL += " (@FClassID, @FBoatID ,@FDate,@FRunTimeByHour	,@FDownTimeByHour	,	@FAmountOfFinish	, ";
					sSQL += " @FGZ_CJ,@FGZ_GL,@FGZ_TC,@FGZ_YK,@FGZ_PK,@FGZ_SW,@FGZ_PD,@FGZ_JX,@FGZ_QT, ";
					sSQL += " @FZC_CJ,@FZC_GL,@FZC_TC,@FZC_YK,@FZC_PK, ";
					sSQL += " @FSB_CJ,@FSB_GL,@FSB_TC,@FSB_YK,@FSB_PK,@FSB_SW,@FSB_PD,@FSB_JX,@FSB_QT,";
					sSQL += " @FEmployeeNum	,@FRemark,	@FNewUser	,@FNewDate	,@FState	)";

					SqlParameter[] par = new SqlParameter[] 
                 {
                     new SqlParameter("@FClassID", cobFClassID.SelectedValue),
                     new SqlParameter("@FBoatID",cobFBoatID.SelectedValue),
										 new SqlParameter("@FDate",Convert.ToDateTime(txtFDate.Text).ToString("yyyy-MM-dd")),
										 new SqlParameter("@FRunTimeByHour",edtFRunTimeByHour.Text.Trim()),
										 new SqlParameter("@FDownTimeByHour",edtFDownTimeByHour.Text.Trim()),
										 new SqlParameter("@FAmountOfFinish",edtFAmountOfFinish.Text.Trim()),

										 new SqlParameter("@FGZ_CJ",edtFGZ_CJ.Text.Trim()), 
                     new SqlParameter("@FGZ_GL",edtFGZ_GL.Text.Trim()), 
                     new SqlParameter("@FGZ_TC",edtFGZ_TC.Text.Trim()), 
                     new SqlParameter("@FGZ_YK",edtFGZ_YK.Text.Trim()), 
                     new SqlParameter("@FGZ_PK",edtFGZ_PK.Text.Trim()), 
                     new SqlParameter("@FGZ_SW",edtFGZ_SW.Text.Trim()), 
                     new SqlParameter("@FGZ_PD",edtFGZ_PD.Text.Trim()), 
                     new SqlParameter("@FGZ_JX",edtFGZ_JX.Text.Trim()), 
                     new SqlParameter("@FGZ_QT",edtFGZ_QT.Text.Trim()),

                     new SqlParameter("@FZC_CJ",txtFZC_CJ.Text.Trim()), 
                     new SqlParameter("@FZC_GL",txtFZC_GL.Text.Trim()), 
                     new SqlParameter("@FZC_TC",txtFZC_TC.Text.Trim()), 
                     new SqlParameter("@FZC_YK",txtFZC_YK.Text.Trim()), 
                     new SqlParameter("@FZC_PK",txtFZC_PK.Text.Trim()),  

                     new SqlParameter("@FSB_CJ",edtFSB_CJ.Text.Trim()), 
                     new SqlParameter("@FSB_GL",edtFSB_GL.Text.Trim()), 
                     new SqlParameter("@FSB_TC",edtFSB_TC.Text.Trim()), 
                     new SqlParameter("@FSB_YK",edtFSB_YK.Text.Trim()), 
                     new SqlParameter("@FSB_PK",edtFSB_PK.Text.Trim()), 
                     new SqlParameter("@FSB_SW",edtFSB_SW.Text.Trim()), 
                     new SqlParameter("@FSB_PD",edtFSB_PD.Text.Trim()), 
                     new SqlParameter("@FSB_JX",edtFSB_JX.Text.Trim()), 
                     new SqlParameter("@FSB_QT",edtFSB_QT.Text.Trim()), 

									
										 new SqlParameter("@FEmployeeNum",edtFEmployeeNum.Text.Trim()),
									
										 new SqlParameter("@FRemark",edtFRemark.Text.Trim()),
										 new SqlParameter("@FNewUser",txtFNewUser.Text.Trim()),
										 new SqlParameter("@FNewDate",db.GetCurrentDate()),
										 new SqlParameter("@FState","0")

                 };

					if (SqlHelper.ExecuteNonQuery(YXK3FZ.DataClass.DataBase.m_Connstr, sSQL, par) > 0)
					{
						//获取当前的保存内码
						sSQL = "select ID FROM TAB06 WHERE FClassID=@FClassID and FBoatID=@FBoatID and  FDate=@FDate ";
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
					sSQL = " update TAB06 set FRunTimeByHour=@FRunTimeByHour	,FDownTimeByHour=@FDownTimeByHour,FAmountOfFinish=@FAmountOfFinish, ";

					sSQL += " FGZ_CJ=@FGZ_CJ, ";
					sSQL += " FGZ_GL=@FGZ_GL, ";
					sSQL += " FGZ_TC=@FGZ_TC, ";
					sSQL += " FGZ_YK=@FGZ_YK, ";
					sSQL += " FGZ_PK=@FGZ_PK, ";
					sSQL += " FGZ_SW=@FGZ_SW, ";
					sSQL += " FGZ_PD=@FGZ_PD, ";
					sSQL += " FGZ_JX=@FGZ_JX, ";
					sSQL += " FGZ_QT=@FGZ_QT, ";
					sSQL += " FZC_CJ=@FZC_CJ, ";
					sSQL += " FZC_GL=@FZC_GL, ";
					sSQL += " FZC_TC=@FZC_TC, ";
					sSQL += " FZC_YK=@FZC_YK, ";
					sSQL += " FZC_PK=@FZC_PK, ";
					sSQL += " FSB_CJ=@FSB_CJ, ";
					sSQL += " FSB_GL=@FSB_GL, ";
					sSQL += " FSB_TC=@FSB_TC, ";
					sSQL += " FSB_YK=@FSB_YK, ";
					sSQL += " FSB_PK=@FSB_PK, ";
					sSQL += " FSB_SW=@FSB_SW, ";
					sSQL += " FSB_PD=@FSB_PD, ";
					sSQL += " FSB_JX=@FSB_JX, ";
					sSQL += " FSB_QT=@FSB_QT, ";

					sSQL += " FEmployeeNum=@FEmployeeNum	,FRemark=@FRemark,FNewDate=@FNewDate where ID=@ID	 ";
					SqlParameter[] par = new SqlParameter[] 
                 {
                     new SqlParameter("@ID", sCurrentID),                    
										 new SqlParameter("@FRunTimeByHour",edtFRunTimeByHour.Text.Trim()),
										 new SqlParameter("@FDownTimeByHour",edtFDownTimeByHour.Text.Trim()),
										 new SqlParameter("@FAmountOfFinish",edtFAmountOfFinish.Text.Trim()),

										  new SqlParameter("@FGZ_CJ",edtFGZ_CJ.Text.Trim()), 
                     new SqlParameter("@FGZ_GL",edtFGZ_GL.Text.Trim()), 
                     new SqlParameter("@FGZ_TC",edtFGZ_TC.Text.Trim()), 
                     new SqlParameter("@FGZ_YK",edtFGZ_YK.Text.Trim()), 
                     new SqlParameter("@FGZ_PK",edtFGZ_PK.Text.Trim()), 
                     new SqlParameter("@FGZ_SW",edtFGZ_SW.Text.Trim()), 
                     new SqlParameter("@FGZ_PD",edtFGZ_PD.Text.Trim()), 
                     new SqlParameter("@FGZ_JX",edtFGZ_JX.Text.Trim()), 
                     new SqlParameter("@FGZ_QT",edtFGZ_QT.Text.Trim()),

                     new SqlParameter("@FZC_CJ",txtFZC_CJ.Text.Trim()), 
                     new SqlParameter("@FZC_GL",txtFZC_GL.Text.Trim()), 
                     new SqlParameter("@FZC_TC",txtFZC_TC.Text.Trim()), 
                     new SqlParameter("@FZC_YK",txtFZC_YK.Text.Trim()), 
                     new SqlParameter("@FZC_PK",txtFZC_PK.Text.Trim()),  

                     new SqlParameter("@FSB_CJ",edtFSB_CJ.Text.Trim()), 
                     new SqlParameter("@FSB_GL",edtFSB_GL.Text.Trim()), 
                     new SqlParameter("@FSB_TC",edtFSB_TC.Text.Trim()), 
                     new SqlParameter("@FSB_YK",edtFSB_YK.Text.Trim()), 
                     new SqlParameter("@FSB_PK",edtFSB_PK.Text.Trim()), 
                     new SqlParameter("@FSB_SW",edtFSB_SW.Text.Trim()), 
                     new SqlParameter("@FSB_PD",edtFSB_PD.Text.Trim()), 
                     new SqlParameter("@FSB_JX",edtFSB_JX.Text.Trim()), 
                     new SqlParameter("@FSB_QT",edtFSB_QT.Text.Trim()), 

										
										 new SqlParameter("@FEmployeeNum",edtFEmployeeNum.Text.Trim()),
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
