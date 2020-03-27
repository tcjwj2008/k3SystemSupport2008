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
    public partial class frmYZOrder05 : Form
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
						public frmYZOrder05(string sMasterState, string sID)
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
				sSQL += "  t.* FROM TAB05 t ";
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

					txtFWater.Text = dttSQL.Rows[0]["FWater"].ToString();
					txtFPWater.Text = dttSQL.Rows[0]["FPWater"].ToString();
					edtFCar.Text = dttSQL.Rows[0]["FCar"].ToString();
					txtFPCar.Text = dttSQL.Rows[0]["FPCar"].ToString();
					edtFGL.Text = dttSQL.Rows[0]["FGL"].ToString();
					txtFPGL.Text = dttSQL.Rows[0]["FPGL"].ToString();

					txtFStoreWater.Text = dttSQL.Rows[0]["FStoreWater"].ToString();
					txtFPStoreWater.Text = dttSQL.Rows[0]["FPStoreWater"].ToString();
					edtFStoreTC.Text = dttSQL.Rows[0]["FStoreTC"].ToString();
					txtFPStoreTC.Text = dttSQL.Rows[0]["FPStoreTC"].ToString();
					edtFStoreYK.Text = dttSQL.Rows[0]["FStoreYK"].ToString();
					txtFPStoreYK.Text = dttSQL.Rows[0]["FPStoreYK"].ToString();
					edtFStorePK.Text = dttSQL.Rows[0]["FStorePK"].ToString();
					txtFPStorePK.Text = dttSQL.Rows[0]["FPStorePK"].ToString();

					txtFCommWater.Text = dttSQL.Rows[0]["FCommWater"].ToString();
					txtFPCommWater.Text = dttSQL.Rows[0]["FPCommWater"].ToString();
					edtFCommJX.Text = dttSQL.Rows[0]["FCommJX"].ToString();
					txtFPCommJX.Text = dttSQL.Rows[0]["FPCommJX"].ToString();
					edtFCommSW.Text = dttSQL.Rows[0]["FCommSW"].ToString();
					txtFPCommSW.Text = dttSQL.Rows[0]["FPCommSW"].ToString();
					edtFCommPD.Text = dttSQL.Rows[0]["FCommPD"].ToString();
					txtFPCommPD.Text = dttSQL.Rows[0]["FPCommPD"].ToString();
					edtFCommSS.Text = dttSQL.Rows[0]["FCommSS"].ToString();
					txtFPCommSS.Text = dttSQL.Rows[0]["FPCommSS"].ToString();


				
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
				if (edtFAmountOfFinish.Text == string.Empty)
				{
					MessageBox.Show("油料加工量(吨)不能为空");
					edtFAmountOfFinish.Focus();
					return;
				}
				//

				if (edtFCar.Text == string.Empty)
				{
					MessageBox.Show("车间-耗量(吨)不能为空");
					edtFCar.Focus();
					return;
				}
				if (edtFGL.Text == string.Empty)
				{
					MessageBox.Show("锅炉-耗量(吨)不能为空");
					edtFGL.Focus();
					return;
				}

				if (edtFStoreTC.Text == string.Empty)
				{
					MessageBox.Show("仓储筒仓-耗量(吨)不能为空");
					edtFStoreTC.Focus();
					return;
				}
				if (edtFStoreYK.Text == string.Empty)
				{
					MessageBox.Show("仓储油库-耗量(吨)不能为空");
					edtFStoreYK.Focus();
					return;
				}
				if (edtFStorePK.Text == string.Empty)
				{
					MessageBox.Show("仓储粕库-耗量(吨)不能为空");
					edtFStorePK.Focus();
					return;
				}



				if (edtFCommJX.Text == string.Empty)
				{
					MessageBox.Show("工程机修-耗量(吨)不能为空");
					edtFCommJX.Focus();
					return;
				}
				if (edtFCommSW.Text == string.Empty)
				{
					MessageBox.Show("工程水务-耗量(吨)不能为空");
					edtFCommSW.Focus();
					return;
				}
				if (edtFCommPD.Text == string.Empty)
				{
					MessageBox.Show("工程配电-耗量(吨)不能为空");
					edtFCommPD.Focus();
					return;
				}
				if (edtFCommSS.Text == string.Empty)
				{
					MessageBox.Show("公共设施-耗量(吨)不能为空");
					edtFCommSS.Focus();
					return;
				}

				if (edtFRemark.Text == string.Empty)
				{
					MessageBox.Show("备注不能为空");
					edtFRemark.Focus();
					return;
				}

				//F45+F47+F49+F57+F65

				double F42 = Convert.ToDouble(edtFAmountOfFinish.Text);

			
				//double F44 = Convert.ToDouble(txtFPWater.Text);			
				//double F46 = Convert.ToDouble(txtFPCar.Text);				
				//double F48 = Convert.ToDouble(txtFPGL.Text);				
				//double F50 = Convert.ToDouble(txtFPStoreWater.Text);				
				//double F52 = Convert.ToDouble(txtFPStoreTC.Text);				
				//double F54 = Convert.ToDouble(txtFPStoreYK.Text);			
				//double F56 = Convert.ToDouble(txtFPStorePK.Text);				
				//double F58 = Convert.ToDouble(txtFPCommWater.Text);			
				//double F60 = Convert.ToDouble(txtFPCommJX.Text);				
				//double F62 = Convert.ToDouble(txtFPCommSW.Text);				
				//double F64 = Convert.ToDouble(txtFPCommPD.Text);				
				//double F66 = Convert.ToDouble(txtFPCommSS.Text);


				double F45 = Convert.ToDouble(edtFCar.Text);
				double F47 = Convert.ToDouble(edtFGL.Text);

		//	string a=	Math.Round(F45, 2).ToString();


				if (F42 == 0)
				{
					txtFPCar.Text = "0";
					txtFPGL.Text = "0";
				}
				else
				{
					txtFPCar.Text = Math.Round((F45 * 1000 / F42), 2).ToString();
					txtFPGL.Text = Math.Round((F47 * 1000 / F42), 2).ToString();
				}

			
				double F51 = Convert.ToDouble(edtFStoreTC.Text);
				double F53 = Convert.ToDouble(edtFStoreYK.Text);
				double F55 = Convert.ToDouble(edtFStorePK.Text);

				txtFStoreWater.Text = 	Math.Round((F51 + F53 + F55),2).ToString();
				double F49 = Convert.ToDouble(txtFStoreWater.Text);

				if (F42 == 0)
				{
					txtFPStoreWater.Text = "0";
					txtFPStoreTC.Text = "0";
					txtFPStoreYK.Text = "0";
					txtFPStorePK.Text = "0";
				}
				else
				{
					txtFPStoreWater.Text = Math.Round((F49 * 1000 / F42), 2).ToString();
					txtFPStoreTC.Text = Math.Round((F51 * 1000 / F42), 2).ToString();
					txtFPStoreYK.Text = Math.Round((F53 * 1000 / F42), 2).ToString();
					txtFPStorePK.Text = Math.Round((F55 * 1000 / F42), 2).ToString();
				}

			

				double F59 = Convert.ToDouble(edtFCommJX.Text);
				double F61 = Convert.ToDouble(edtFCommSW.Text);
				double F63 = Convert.ToDouble(edtFCommPD.Text);
				double F65 = Convert.ToDouble(edtFCommSS.Text);

				txtFCommWater.Text = 	Math.Round((F59 + F61 + F63),2).ToString();
				double F57 = Convert.ToDouble(txtFCommWater.Text);

				if (F42 == 0)
				{
					txtFPCommWater.Text = "0";
					txtFPCommJX.Text = "0";
					txtFPCommSW.Text = "0";
					txtFPCommPD.Text = "0";
					txtFPCommSS.Text = "0";
				}
				else
				{
					txtFPCommWater.Text = Math.Round((F57 * 1000 / F42), 2).ToString();
					txtFPCommJX.Text = Math.Round((F59 * 1000 / F42), 2).ToString();
					txtFPCommSW.Text = Math.Round((F61 * 1000 / F42), 2).ToString();
					txtFPCommPD.Text = Math.Round((F63 * 1000 / F42), 2).ToString();
					txtFPCommSS.Text = Math.Round((F65 * 1000 / F42), 2).ToString();
				}


				txtFWater.Text = 	Math.Round((F45 + F47 + F49 + F57 + F65),2).ToString();
				double F43 = Convert.ToDouble(txtFWater.Text);

				if (F42 == 0)
				{
					txtFPWater.Text = "0";
				}
				else
				{
					txtFPWater.Text = Math.Round((F43 * 1000 / F42), 2).ToString();
				}


			


				#endregion

				#region 查重判断

				sSQL = " select * from TAB05 where FClassID='" + cobFClassID.SelectedValue + "' ";
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
					sSQL = " INSERT INTO TAB05 ";
					sSQL += " ( ";
					sSQL += " FClassID, FBoatID ,FDate,FRunTimeByHour	,FDownTimeByHour,FAmountOfFinish	, ";
					sSQL += " FWater,FPWater,FCar,FPCar,FGL,FPGL,	 ";
					sSQL += " FStoreWater,FPStoreWater,FStoreTC,FPStoreTC,FStoreYK,FPStoreYK,FStorePK,FPStorePK,	 ";
					sSQL += " FCommWater,FPCommWater,FCommJX,FPCommJX,FCommSW,FPCommSW,FCommPD,FPCommPD,	 ";
					sSQL += " FCommSS,FPCommSS,	 ";
					sSQL += " FRemark,FNewUser	,FNewDate	,FState	 ";
					sSQL += " )  ";
					sSQL += " VALUES  ";
					sSQL += " (@FClassID, @FBoatID ,@FDate,@FRunTimeByHour	,@FDownTimeByHour	,	@FAmountOfFinish	, ";
					sSQL += " @FWater,@FPWater,@FCar,@FPCar,@FGL,@FPGL,	 ";
					sSQL += " @FStoreWater,@FPStoreWater,@FStoreTC,@FPStoreTC,@FStoreYK,@FPStoreYK,@FStorePK,@FPStorePK,	 ";
					sSQL += " @FCommWater,@FPCommWater,@FCommJX,@FPCommJX,@FCommSW,@FPCommSW,@FCommPD,@FPCommPD,	 ";
					sSQL += " @FCommSS,@FPCommSS,	 ";
					sSQL += " @FRemark,	@FNewUser	,@FNewDate	,@FState	)";

					SqlParameter[] par = new SqlParameter[] 
                 {
                     new SqlParameter("@FClassID", cobFClassID.SelectedValue),
                     new SqlParameter("@FBoatID",cobFBoatID.SelectedValue),
										 new SqlParameter("@FDate",Convert.ToDateTime(txtFDate.Text).ToString("yyyy-MM-dd")),
										 new SqlParameter("@FRunTimeByHour",edtFRunTimeByHour.Text.Trim()),
										 new SqlParameter("@FDownTimeByHour",edtFDownTimeByHour.Text.Trim()),
										 new SqlParameter("@FAmountOfFinish",edtFAmountOfFinish.Text.Trim()),

										 new SqlParameter("@FWater",txtFWater.Text.Trim()),
										 new SqlParameter("@FPWater",txtFPWater.Text.Trim()),
										 new SqlParameter("@FCar",edtFCar.Text.Trim()),
										 new SqlParameter("@FPCar",txtFPCar.Text.Trim()),
										 new SqlParameter("@FGL",edtFGL.Text.Trim()),
										 new SqlParameter("@FPGL",txtFPGL.Text.Trim()),

										 new SqlParameter("@FStoreWater",txtFStoreWater.Text.Trim()),
										 new SqlParameter("@FPStoreWater",txtFPStoreWater.Text.Trim()),
										 new SqlParameter("@FStoreTC",edtFStoreTC.Text.Trim()),
										 new SqlParameter("@FPStoreTC",txtFPStoreTC.Text.Trim()),
										 new SqlParameter("@FStoreYK",edtFStoreYK.Text.Trim()),
										 new SqlParameter("@FPStoreYK",txtFPStoreYK.Text.Trim()),
										 new SqlParameter("@FStorePK",edtFStorePK.Text.Trim()),
										 new SqlParameter("@FPStorePK",txtFPStorePK.Text.Trim()),

										 new SqlParameter("@FCommWater",txtFCommWater.Text.Trim()),
										 new SqlParameter("@FPCommWater",txtFPCommWater.Text.Trim()),
										 new SqlParameter("@FCommJX",edtFCommJX.Text.Trim()),
										 new SqlParameter("@FPCommJX",txtFPCommJX.Text.Trim()),
										 new SqlParameter("@FCommSW",edtFCommSW.Text.Trim()),
										 new SqlParameter("@FPCommSW",txtFPCommSW.Text.Trim()),
										 new SqlParameter("@FCommPD",edtFCommPD.Text.Trim()),
										 new SqlParameter("@FPCommPD",txtFPCommPD.Text.Trim()),
										 new SqlParameter("@FCommSS",edtFCommSS.Text.Trim()),
										 new SqlParameter("@FPCommSS",txtFPCommSS.Text.Trim()),									
										
									
										 new SqlParameter("@FRemark",edtFRemark.Text.Trim()),
										 new SqlParameter("@FNewUser",txtFNewUser.Text.Trim()),
										 new SqlParameter("@FNewDate",db.GetCurrentDate()),
										 new SqlParameter("@FState","0")

                 };

					if (SqlHelper.ExecuteNonQuery(YXK3FZ.DataClass.DataBase.m_Connstr, sSQL, par) > 0)
					{
						//获取当前的保存内码
						sSQL = "select ID FROM TAB05 WHERE FClassID=@FClassID and FBoatID=@FBoatID and  FDate=@FDate ";
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
					sSQL = " update TAB05 set FRunTimeByHour=@FRunTimeByHour	,FDownTimeByHour=@FDownTimeByHour,FAmountOfFinish=@FAmountOfFinish, ";

					sSQL += " FWater=@FWater,FPWater=@FPWater,FCar=@FCar,FPCar=@FPCar,FGL=@FGL,FPGL=@FPGL,	 ";
					sSQL += " FStoreWater=@FStoreWater,FPStoreWater=@FPStoreWater,FStoreTC=@FStoreTC,FPStoreTC=@FPStoreTC,FStoreYK=@FStoreYK,FPStoreYK=@FPStoreYK,FStorePK=@FStorePK,FPStorePK=@FPStorePK,	 ";
					sSQL += " FCommWater=@FCommWater,FPCommWater=@FPCommWater,FCommJX=@FCommJX,FPCommJX=@FPCommJX,FCommSW=@FCommSW,FPCommSW=@FPCommSW,FCommPD=@FCommPD,FPCommPD=@FPCommPD,	 ";
					sSQL += " FCommSS=@FCommSS,FPCommSS=@FPCommSS,	 ";

					sSQL += " FRemark=@FRemark,FNewDate=@FNewDate where ID=@ID	 ";
					SqlParameter[] par = new SqlParameter[] 
                 {
                     new SqlParameter("@ID", sCurrentID),                    
										 new SqlParameter("@FRunTimeByHour",edtFRunTimeByHour.Text.Trim()),
										 new SqlParameter("@FDownTimeByHour",edtFDownTimeByHour.Text.Trim()),
										 new SqlParameter("@FAmountOfFinish",edtFAmountOfFinish.Text.Trim()),

										 	 new SqlParameter("@FWater",txtFWater.Text.Trim()),
										 new SqlParameter("@FPWater",txtFPWater.Text.Trim()),
										 new SqlParameter("@FCar",edtFCar.Text.Trim()),
										 new SqlParameter("@FPCar",txtFPCar.Text.Trim()),
										 new SqlParameter("@FGL",edtFGL.Text.Trim()),
										 new SqlParameter("@FPGL",txtFPGL.Text.Trim()),

										 new SqlParameter("@FStoreWater",txtFStoreWater.Text.Trim()),
										 new SqlParameter("@FPStoreWater",txtFPStoreWater.Text.Trim()),
										 new SqlParameter("@FStoreTC",edtFStoreTC.Text.Trim()),
										 new SqlParameter("@FPStoreTC",txtFPStoreTC.Text.Trim()),
										 new SqlParameter("@FStoreYK",edtFStoreYK.Text.Trim()),
										 new SqlParameter("@FPStoreYK",txtFPStoreYK.Text.Trim()),
										 new SqlParameter("@FStorePK",edtFStorePK.Text.Trim()),
										 new SqlParameter("@FPStorePK",txtFPStorePK.Text.Trim()),

										 new SqlParameter("@FCommWater",txtFCommWater.Text.Trim()),
										 new SqlParameter("@FPCommWater",txtFPCommWater.Text.Trim()),
										 new SqlParameter("@FCommJX",edtFCommJX.Text.Trim()),
										 new SqlParameter("@FPCommJX",txtFPCommJX.Text.Trim()),
										 new SqlParameter("@FCommSW",edtFCommSW.Text.Trim()),
										 new SqlParameter("@FPCommSW",txtFPCommSW.Text.Trim()),
										 new SqlParameter("@FCommPD",edtFCommPD.Text.Trim()),
										 new SqlParameter("@FPCommPD",txtFPCommPD.Text.Trim()),
										 new SqlParameter("@FCommSS",edtFCommSS.Text.Trim()),
										 new SqlParameter("@FPCommSS",txtFPCommSS.Text.Trim()),
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
