﻿using System;
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
	public partial class frmYZOrderList02 : Form
	{
		DataBase k3db = null;

		public frmYZOrderList02()
		{
			InitializeComponent();
			k3db = new DataBase(YXK3FZ.DataClass.DataBase.m_Connstr);
		}

		CommonUse commUse = new CommonUse();
		private void frmYZOrderList02_Load(object sender, EventArgs e)
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

			//sSQL += " FPerConsumption=CAST( ((FConsumptionByTon*1000)/FAmountOfFinish) as decimal(18,2)), ";
			//sSQL += " FPerConsumption2=CAST( ((FConsumptionByTon2*1000)/FAmountOfFinish) as decimal(18,2)), ";

			sSQL += " FPerConsumption=case when FAmountOfFinish=0 then 0 else   CAST( ((FConsumptionByTon*1000)/FAmountOfFinish) as decimal(18,2)) end, ";
			sSQL += " FPerConsumption2=case when FAmountOfFinish=0 then 0 else   CAST( ((FConsumptionByTon2*1000)/FAmountOfFinish) as decimal(18,2)) end, ";
		

			sSQL += " FStateDesc=CASE WHEN FState='0' THEN '未审核' WHEN FState='1' THEN '已审核'  ELSE '已确认' END, ";
			sSQL += "  t.* FROM TAB02 t ";
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

			//sSQL += " SUM(FAmountOfFinish) FAmountOfFinish,  ";  //油料加工量(吨)
			//sSQL += " SUM(FAmountOfFinish2) FAmountOfFinish2,  "; //蒸汽量(吨)
			//sSQL += " SUM(FConsumptionByTon) FConsumptionByTon,  ";
			//sSQL += " FPerConsumption=CAST( SUM(((FConsumptionByTon*1000)/FAmountOfFinish)) as decimal(18,2)),  ";	
			//sSQL += " SUM(FConsumptionByTon2)*1000/sum(FAmountOfFinish) FConsumptionByTon2,  ";
			//sSQL += " FPerConsumption2=CAST( SUM(((FConsumptionByTon2*1000)/FAmountOfFinish)) as decimal(18,2)),  ";

			sSQL += " SUM(FAmountOfFinish) FAmountOfFinish,   ";   //油料加工量(吨)
			sSQL += " SUM(FAmountOfFinish2) FAmountOfFinish2,   ";  //蒸汽量(吨)
			sSQL += " cast(SUM(FConsumptionByTon) as decimal(18,2)) FConsumptionByTon,   ";

			//sSQL += " FPerConsumption=CAST( SUM(FConsumptionByTon)*1000/SUM(FAmountOfFinish) as decimal(18,2)),    ";
			sSQL += " FPerConsumption=CAST( SUM( case when FAmountOfFinish=0 then 0 else  ((FConsumptionByTon*1000)/FAmountOfFinish) end) as decimal(18,2)),  ";

			sSQL += " SUM(FConsumptionByTon2) FConsumptionByTon2,  ";
			//sSQL += " FPerConsumption2=CAST( SUM(FConsumptionByTon2)*1000/SUM(FAmountOfFinish) as decimal(18,2)),   ";
			sSQL += " FPerConsumption2=CAST( SUM( case when FAmountOfFinish=0 then 0 else  ((FConsumptionByTon2*1000)/FAmountOfFinish) end) as decimal(18,2)),  ";


			sSQL += " SUM(FEmployeeNum) FEmployeeNum,  ";
			sSQL += " SUM(FIllDeviceNum) FIllDeviceNum,  ";
			sSQL += " SUM(FServiceDevice) FServiceDevice  ";
			sSQL += " FROM TAB02 t  ";
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
			dtr["FConsumptionByTon"] = dttSQL2.Compute("Sum(FConsumptionByTon)", "");
			dtr["FPerConsumption"] = dttSQL2.Compute("Sum(FPerConsumption)", "");

			dtr["FAmountOfFinish2"] = dttSQL2.Compute("Sum(FAmountOfFinish2)", "");
			dtr["FConsumptionByTon2"] = dttSQL2.Compute("Sum(FConsumptionByTon2)", "");
			dtr["FPerConsumption2"] = dttSQL2.Compute("Sum(FPerConsumption2)", "");

			dtr["FEmployeeNum"] = dttSQL2.Compute("Sum(FEmployeeNum)", "");
			dtr["FIllDeviceNum"] = dttSQL2.Compute("Sum(FIllDeviceNum)", "");
			dtr["FServiceDevice"] = dttSQL2.Compute("Sum(FServiceDevice)", "");

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
				sSQL += " FROM TAB02 where ID='" + ((DataRowView)bdsMaster.Current).Row["ID"] + "'";
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



		//查看
		private void btnSel_Click(object sender, EventArgs e)
		{
			if (bdsMaster.Current != null)
			{
				frmYZOrder02 frmYZOrder02 = new frmYZOrder02("SEL", ((DataRowView)bdsMaster.Current).Row["ID"].ToString());
				frmYZOrder02.Text = frmYZOrder02.Text;
				frmYZOrder02.Show();

			}

		}

		//新增
		private void btnADD_Click(object sender, EventArgs e)
		{
			frmYZOrder02 frmYZOrder02 = new frmYZOrder02("ADD", "");
			frmYZOrder02.Text = frmYZOrder02.Text;
			frmYZOrder02.Show();
		}
		//修改
		private void tsbtnEdit_Click(object sender, EventArgs e)
		{
			if (bdsMaster.Current != null)
			{
				if (getBillState("修改"))
				{
					frmYZOrder02 frmYZOrder02 = new frmYZOrder02("EDIT", ((DataRowView)bdsMaster.Current).Row["ID"].ToString());
					frmYZOrder02.Text = frmYZOrder02.Text;
					frmYZOrder02.Show();
				}

			}
		}

		//删除
		private void btnDelete_Click(object sender, EventArgs e)
		{
			if (bdsMaster.Current != null)
			{

				if (MessageBox.Show("确定要删除当前单据吗？", "系统提示", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
				{

					if (getBillState("删除"))
					{
						string sSQL = string.Empty;
						sSQL = " delete from  TAB02 where ID='" + ((DataRowView)bdsMaster.Current).Row["ID"] + "'";
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
		//审核
		private void btnCheck_Click(object sender, EventArgs e)
		{
			if (bdsMaster.Current != null)
			{
				if (getBillState("审核"))
				{
					string sSQL = string.Empty;
					sSQL = " update TAB02 set FState=1,FCheckUser='" + PropertyClass.OperatorName + "',FCheckDate='" + k3db.GetCurrentDate() + "' where ID='" + ((DataRowView)bdsMaster.Current).Row["ID"] + "'";
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
					sSQL = " update TAB02 set FState=0,FCheckUser=NULL,FCheckDate=NULL where ID='" + ((DataRowView)bdsMaster.Current).Row["ID"] + "'";
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




	}
}
