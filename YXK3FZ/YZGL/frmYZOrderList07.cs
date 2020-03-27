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
	public partial class frmYZOrderList07 : Form
	{
		DataBase k3db = null;

		public frmYZOrderList07()
		{
			InitializeComponent();
			k3db = new DataBase(YXK3FZ.DataClass.DataBase.m_Connstr);
		}

		CommonUse commUse = new CommonUse();
		private void frmYZOrderList07_Load(object sender, EventArgs e)
		{
			LoadPower();//加载权限

			if (bSEL)
			{
				InitCobDate();//加载参数
				getDate(string.Empty);//获取数据
			}
			else
			{
				button1.Enabled = false;
				button2.Enabled = false;
			}

			txtFDate1.ShowCheckBox = true;
			txtFDate2.ShowCheckBox = true;

			txtFDate1.Checked = false;
			txtFDate2.Checked = false;
		}

		bool bSEL = false; //查询权限
		private void LoadPower()
		{
			commUse.CortrolButtonEnabled(button1, this);
			commUse.CortrolButtonEnabled(btnADD, this);
			commUse.CortrolButtonEnabled(tsbtnEdit, this);
			commUse.CortrolButtonEnabled(btnDelete, this);
			commUse.CortrolButtonEnabled(btnCheck, this);
			commUse.CortrolButtonEnabled(btnHcheck, this);
			commUse.CortrolButtonEnabled(btnExport, this);
			commUse.CortrolButtonEnabled(btnConfirmer, this);
			bSEL = button1.Enabled;

		}

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

		private void getDate(string sSQLWH) //加载数据
		{
			string sSQL = string.Empty;

			sSQL += "  SELECT  b1.FName FClassName,b2.FShortName FBoatName,FRunTimeByDay=CAST( FRunTimeByHour/8 as decimal(18,4)), ";

			sSQL += " FStateDesc=CASE WHEN FState='0' THEN '未审核' WHEN FState='1' THEN '已审核'  ELSE '已确认' END, ";
			sSQL += "  t.* FROM TAB07 t ";//存在地磅字段，无需添加0422
			sSQL += " INNER JOIN YZ_BaseEntry b1 ON t.FClassID=b1.FID AND b1.FUID=1 ";
			sSQL += " INNER JOIN YZ_BaseEntry b2 ON t.FBoatID=b2.FID AND b2.FUID=2 ";
			sSQL += " where 1>0 ";
			if (sSQLWH != string.Empty)
			{
				sSQL += sSQLWH; //查询条件
			}
			sSQL += " ORDER BY FDate";

			DataTable dttSQL = k3db.GetDataTable(sSQL, "A");
			bdsMaster.DataSource = dttSQL;

			sSQL = string.Empty;

			sSQL += " SELECT FDate,  b2.FShortName FBoatName,FRunTimeByDay=CAST( SUM(FRunTimeByHour)/24 as decimal(18,4)),  ";
			sSQL += " SUM(FRunTimeByHour) FRunTimeByHour,  ";
			sSQL += " SUM(FDownTimeByHour) FDownTimeByHour,  ";
			sSQL += " SUM(FAmountOfFinish) FAmountOfFinish , ";
			sSQL += " SUM(FDALL) FDALL,";

			sSQL += "  SUM(FWater) FWater, ";
			sSQL += "  CAST( ( SUM(FPWater)/count(*) ) as decimal(18,2)) FPWater, ";
			sSQL += "  SUM(FCar) FCar, ";
			sSQL += "  CAST( ( SUM(FPCar)/count(*) ) as decimal(18,2)) FPCar,	 ";
			sSQL += "  SUM(FGL) FGL, ";
			sSQL += "  CAST( ( SUM(FPGL)/count(*) ) as decimal(18,2)) FPGL, ";

			sSQL += "  SUM(FStoreWater) FStoreWater, ";
			sSQL += "   CAST( ( SUM(FPStoreWater)/count(*) ) as decimal(18,2)) FPStoreWater,	 ";
			sSQL += "  sum(FStoreTC) FStoreTC, ";
			sSQL += "  CAST( ( SUM(FPStoreTC)/count(*) ) as decimal(18,2)) FPStoreTC, ";
			sSQL += "  sum(FStoreYK) FStoreYK, ";
			sSQL += "   CAST( ( SUM(FPStoreYK)/count(*) ) as decimal(18,2)) FPStoreYK, ";
			sSQL += "  sum(FStorePK) FStorePK, ";
			sSQL += "   CAST( ( SUM(FPStorePK)/count(*) ) as decimal(18,2)) FPStorePK, ";

			sSQL += "  SUM(FCommWater) FCommWater, ";
			sSQL += "  CAST( ( SUM(FPCommWater)/count(*) ) as decimal(18,2)) FPCommWater, ";
			sSQL += "  sum(FCommJX) FCommJX, ";
			sSQL += "   CAST( ( SUM(FPCommJX)/count(*) ) as decimal(18,2)) FPCommJX, ";
			sSQL += "  sum(FCommSW) FCommSW, ";
			sSQL += "   CAST( ( SUM(FPCommSW)/count(*) ) as decimal(18,2)) FPCommSW, ";
			sSQL += "  sum(FCommPD) FCommPD, ";
			sSQL += "   CAST( ( SUM(FPCommPD)/count(*) ) as decimal(18,2)) FPCommPD, ";


			sSQL += "  sum(FAQK) FAQK, ";
			sSQL += "   CAST( ( SUM(FPAQK)/count(*) ) as decimal(18,2)) FPAQK,";
		

			sSQL += "  sum(FXFB) FXFB, ";
			sSQL += "  sum(FDRS) FDRS, ";
			sSQL += "  sum(FBMLD) FBMLD, ";
			sSQL += "  sum(FDZP) FDZP, ";
			sSQL += "  sum(FDBPD) FDBPD, ";//增加地磅字段0422
			sSQL += "  sum(FGT) FGT, ";



			sSQL += "  sum(FCommSS) FCommSS, ";
			sSQL += "   CAST( ( SUM(FPCommSS)/count(*) ) as decimal(18,2)) FPCommSS";

			sSQL += " FROM TAB07 t  ";
			sSQL += " INNER JOIN YZ_BaseEntry b2 ON t.FBoatID=b2.FID AND b2.FUID=2  ";
			sSQL += " Where 1>0 ";
			if (sSQLWH2 != string.Empty)
			{
				sSQL += sSQLWH2; //查询条件
			}
			sSQL += " GROUP BY FDate,b2.FShortName  ";
			sSQL += " ORDER BY FDate  ";
			DataTable dttSQL2 = k3db.GetDataTable(sSQL, "A");


			//计算合计行
			DataRow dtr = dttSQL2.NewRow();
			dtr["FDate"] = "合计";
			dtr["FRunTimeByDay"] = dttSQL2.Compute("Sum(FRunTimeByDay)", "");
			dtr["FRunTimeByHour"] = dttSQL2.Compute("Sum(FRunTimeByHour)", "");
			dtr["FDownTimeByHour"] = dttSQL2.Compute("Sum(FDownTimeByHour)", "");
			dtr["FAmountOfFinish"] = dttSQL2.Compute("Sum(FAmountOfFinish)", "");
			dtr["FDALL"] = dttSQL2.Compute("Sum(FDALL)", "");

			dtr["FWater"] = dttSQL2.Compute("Sum(FWater)", "");
			dtr["FPWater"] = dttSQL2.Compute("Sum(FPWater)", "");
			dtr["FCar"] = dttSQL2.Compute("Sum(FCar)", "");
			dtr["FPCar"] = dttSQL2.Compute("Sum(FPCar)", "");
			dtr["FGL"] = dttSQL2.Compute("Sum(FGL)", "");
			dtr["FPGL"] = dttSQL2.Compute("Sum(FPGL)", "");

			dtr["FStoreWater"] = dttSQL2.Compute("Sum(FStoreWater)", "");
			dtr["FPStoreWater"] = dttSQL2.Compute("Sum(FPStoreWater)", "");
			dtr["FStoreTC"] = dttSQL2.Compute("Sum(FStoreTC)", "");
			dtr["FPStoreTC"] = dttSQL2.Compute("Sum(FPStoreTC)", "");
			dtr["FStoreYK"] = dttSQL2.Compute("Sum(FStoreYK)", "");
			dtr["FPStoreYK"] = dttSQL2.Compute("Sum(FPStoreYK)", "");
			dtr["FStorePK"] = dttSQL2.Compute("Sum(FStorePK)", "");
			dtr["FPStorePK"] = dttSQL2.Compute("Sum(FPStorePK)", "");

			dtr["FCommWater"] = dttSQL2.Compute("Sum(FCommWater)", "");
			dtr["FPCommWater"] = dttSQL2.Compute("Sum(FPCommWater)", "");
			dtr["FCommJX"] = dttSQL2.Compute("Sum(FCommJX)", "");
			dtr["FPCommJX"] = dttSQL2.Compute("Sum(FPCommJX)", "");
			dtr["FCommSW"] = dttSQL2.Compute("Sum(FCommSW)", "");
			dtr["FPCommSW"] = dttSQL2.Compute("Sum(FPCommSW)", "");
			dtr["FCommPD"] = dttSQL2.Compute("Sum(FCommPD)", "");
			dtr["FPCommPD"] = dttSQL2.Compute("Sum(FPCommPD)", "");


			dtr["FAQK"] = dttSQL2.Compute("Sum(FAQK)", "");
			dtr["FPAQK"] = dttSQL2.Compute("Sum(FPAQK)", "");

			dtr["FXFB"] = dttSQL2.Compute("Sum(FXFB)", "");
			dtr["FDRS"] = dttSQL2.Compute("Sum(FDRS)", "");
			dtr["FBMLD"] = dttSQL2.Compute("Sum(FBMLD)", "");
			dtr["FDZP"] = dttSQL2.Compute("Sum(FDZP)", "");
			dtr["FDBPD"] = dttSQL2.Compute("Sum(FDBPD)", "");//增加地磅计数合计行0422
			dtr["FGT"] = dttSQL2.Compute("Sum(FGT)", "");


			dtr["FCommSS"] = dttSQL2.Compute("Sum(FCommSS)", "");
			dtr["FPCommSS"] = dttSQL2.Compute("Sum(FPCommSS)", "");

			dttSQL2.Rows.Add(dtr);


			bdsMaster2.DataSource = dttSQL2;


		}

		/// <summary>
		/// 判断单据状态,如果已审核，无法操作
		/// </summary>
		/// <param name="sType"></param>
		/// <param name="sID"></param>
		private bool getBillState(string sType)
		{
			if (bdsMaster.Current != null)
			{
				string sSQL = string.Empty;
				sSQL = " SELECT FState,  FStateDesc=CASE WHEN FState='0' THEN '未审核' WHEN FState='1' THEN '已审核'  ELSE '已确认' END ";
				sSQL += " FROM TAB07 where ID='" + ((DataRowView)bdsMaster.Current).Row["ID"] + "'";
				DataTable dttSQL = k3db.GetDataTable(sSQL, "A");
				if (dttSQL.Rows.Count == 0)
				{
					MessageBox.Show("当前单据不存在...");
					return false;
				}

				if (sType == "修改" || sType == "删除" || sType == "审核")
				{
					if (Convert.ToInt32(dttSQL.Rows[0]["FState"].ToString()) > 0)
					{
						MessageBox.Show("单据" + dttSQL.Rows[0]["FStateDesc"].ToString() + "，无法" + sType + "...");
						return false;
					}
				}
				else if (sType == "确认" || sType == "反审核")
				{
					if (Convert.ToInt32(dttSQL.Rows[0]["FState"].ToString()) > 1)
					{
						MessageBox.Show("单据" + dttSQL.Rows[0]["FStateDesc"].ToString() + "，无法" + sType + "...");
						return false;
					}
					else if (Convert.ToInt32(dttSQL.Rows[0]["FState"].ToString()) < 1)
					{
						MessageBox.Show("单据" + dttSQL.Rows[0]["FStateDesc"].ToString() + "，无法" + sType + "...");
						return false;
					}

				}

			}

			return true;

		}



		/// <summary>
		/// 查看数据
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnSel_Click(object sender, EventArgs e)
		{
			if (bdsMaster.Current != null)
			{
				frmYZOrder07 frmYZOrder07 = new frmYZOrder07("SEL", ((DataRowView)bdsMaster.Current).Row["ID"].ToString());
				frmYZOrder07.Text = frmYZOrder07.Text;
				frmYZOrder07.Show();

			}

		}

		/// <summary>
		/// 新增数据
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnADD_Click(object sender, EventArgs e)
		{
			frmYZOrder07 frmYZOrder07 = new frmYZOrder07("ADD", "");
			frmYZOrder07.Text = frmYZOrder07.Text;
			frmYZOrder07.Show();
		}
		/// <summary>
		/// 修改数据
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void tsbtnEdit_Click(object sender, EventArgs e)
		{
			if (bdsMaster.Current != null)
			{
				if (getBillState("修改"))
				{
					frmYZOrder07 frmYZOrder07 = new frmYZOrder07("EDIT", ((DataRowView)bdsMaster.Current).Row["ID"].ToString());
					frmYZOrder07.Text = frmYZOrder07.Text;
					frmYZOrder07.Show();
				}

			}
		}

		/// <summary>
		/// 删除数据
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnDelete_Click(object sender, EventArgs e)
		{
			if (bdsMaster.Current != null)
			{

				if (MessageBox.Show("确定要删除当前单据吗？", "系统提示", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
				{

					if (getBillState("删除"))
					{
						string sSQL = string.Empty;
						sSQL = " delete from  TAB07 where ID='" + ((DataRowView)bdsMaster.Current).Row["ID"] + "'";
						if (k3db.ExecDataBySql(sSQL) > 0)
						{
							MessageBox.Show("数据删除成功...");
							button1_Click(null, null);//按条件查询数据
							return;
						}
					}

				}



			}
		}
	/// <summary>
	/// 审核单据
	/// </summary>
	/// <param name="sender"></param>
	/// <param name="e"></param>
		private void btnCheck_Click(object sender, EventArgs e)
		{
			if (bdsMaster.Current != null)
			{
				if (getBillState("审核"))
				{
					string sSQL = string.Empty;
					sSQL = " update TAB07 set FState=1,FCheckUser='" + PropertyClass.OperatorName + "',FCheckDate='" + k3db.GetCurrentDate() + "' where ID='" + ((DataRowView)bdsMaster.Current).Row["ID"] + "'";
					if (k3db.ExecDataBySql(sSQL) > 0)
					{
						MessageBox.Show("数据审核成功...");
						button1_Click(null, null);//按条件查询数据
						return;
					}
				}

			}
		}
		//反审核
		private void btnHcheck_Click(object sender, EventArgs e)
		{
			if (bdsMaster.Current != null)
			{
				if (getBillState("反审核"))
				{
					string sSQL = string.Empty;
					sSQL = " update TAB07 set FState=0,FCheckUser=NULL,FCheckDate=NULL where ID='" + ((DataRowView)bdsMaster.Current).Row["ID"] + "'";
					if (k3db.ExecDataBySql(sSQL) > 0)
					{
						MessageBox.Show("数据反审核成功...");
						button1_Click(null, null);//按条件查询数据
						return;
					}
				}

			}
		}
		//导出
		private void btnExport_Click(object sender, EventArgs e)
		{
			if (bdsMaster.Count > 0)
			{
				string sfilename = this.Text;
				ComClass.CommExcel.ExportExcel(sfilename, dataGridView1, true);

			}
		}
		//退出
		private void btnClose_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		//查询
		string sSQLWH2 = string.Empty;
		private void button1_Click(object sender, EventArgs e)
		{
			string sSQLWH = string.Empty;
			sSQLWH2 = string.Empty;

			if (cobFClassID.SelectedIndex != -1)
			{
				sSQLWH += " and t.FClassID='" + cobFClassID.SelectedValue + "'";
			}
			if (cobFBoatID.SelectedIndex != -1)
			{
				sSQLWH += " and t.FBoatID='" + cobFBoatID.SelectedValue + "'";
				sSQLWH2 += " and t.FBoatID='" + cobFBoatID.SelectedValue + "'";
			}

			if (txtFDate1.Checked == true && txtFDate2.Checked == true)
			{
				sSQLWH += " and t.FDate between '" + txtFDate1.Text + "' and  '" + txtFDate2.Text + "'";
				sSQLWH2 += " and t.FDate between '" + txtFDate1.Text + "' and  '" + txtFDate2.Text + "'";
			}
			else
			{
				if (txtFDate1.Checked == true)
				{
					sSQLWH += " and t.FDate >= '" + txtFDate1.Text + "' ";
					sSQLWH2 += " and t.FDate between '" + txtFDate1.Text + "' and  '" + txtFDate2.Text + "'";
				}
				else if (txtFDate1.Checked == true)
				{
					sSQLWH += " and t.FDate <= '" + txtFDate2.Text + "' ";
					sSQLWH2 += " and t.FDate between '" + txtFDate1.Text + "' and  '" + txtFDate2.Text + "'";
				}
			}

			getDate(sSQLWH);


		}
		//取消
		private void button2_Click(object sender, EventArgs e)
		{
			cobFBoatID.SelectedIndex = -1;
			cobFClassID.SelectedIndex = -1;
			txtFDate1.Checked = false;
			txtFDate2.Checked = false;

			getDate(string.Empty);
		}

		private void 查看ToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (bdsMaster2.Count > 0)
			{
				string sfilename = this.Text + "按日期汇总导出";
				ComClass.CommExcel.ExportExcel(sfilename, dataGridView2, true);
			}
		}

		private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
		{
			btnSel_Click(null, null);
		}

		private void btnSave_Click(object sender, EventArgs e)
		{

		}


	}
}
