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
	public partial class frmYZOrderList04 : Form
	{

		DataBase k3db = null;

		public frmYZOrderList04()
		{
			InitializeComponent();
			k3db = new DataBase(YXK3FZ.DataClass.DataBase.m_Connstr);

		}

		CommonUse commUse = new CommonUse();
		private void frmYZOrderList04_Load(object sender, EventArgs e)
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
			sSQL += "  t.* FROM TAB04 t ";
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
			sSQL += " SUM(FAmountOfFinish) FAmountOfFinish,  ";

			sSQL += " cast((sum(FZC_CJ)/COUNT(*)) as decimal(18,2)) FZC_CJ, ";
			sSQL += " cast((sum(FZC_GL)/COUNT(*))  as decimal(18,2)) FZC_GL, ";
			sSQL += " cast((sum(FZC_TC)/COUNT(*))  as decimal(18,2)) FZC_TC, ";
			sSQL += " cast((sum(FZC_YK)/COUNT(*))  as decimal(18,2)) FZC_YK, ";
			sSQL += " cast((sum(FZC_PK)/COUNT(*))  as decimal(18,2)) FZC_PK, ";

			sSQL += " sum(FGZ_CJ) FGZ_CJ, ";
			sSQL += " sum(FGZ_GL) FGZ_GL, ";
			sSQL += " sum(FGZ_TC) FGZ_TC, ";
			sSQL += " sum(FGZ_YK) FGZ_YK, ";
			sSQL += " sum(FGZ_PK) FGZ_PK, ";
			sSQL += " sum(FGZ_SW) FGZ_SW, ";
			sSQL += " sum(FGZ_PD) FGZ_PD, ";
			sSQL += " sum(FGZ_JX) FGZ_JX, ";
			sSQL += " sum(FGZ_QT) FGZ_QT, ";

			sSQL += " sum(FSB_CJ) FSB_CJ, ";
			sSQL += " sum(FSB_GL) FSB_GL, ";
			sSQL += " sum(FSB_TC) FSB_TC, ";
			sSQL += " sum(FSB_YK) FSB_YK, ";
			sSQL += " sum(FSB_PK) FSB_PK, ";
			sSQL += " sum(FSB_SW) FSB_SW, ";
			sSQL += " sum(FSB_PD) FSB_PD, ";
			sSQL += " sum(FSB_JX) FSB_JX, ";
			sSQL += " sum(FSB_QT) FSB_QT, ";
			
			sSQL += " SUM(FEmployeeNum) FEmployeeNum  ";

			sSQL += " FROM TAB04 t  ";
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

			dtr["FZC_CJ"] = dttSQL2.Compute("Sum(FZC_CJ)", "");
			dtr["FZC_GL"] = dttSQL2.Compute("Sum(FZC_GL)", "");
			dtr["FZC_TC"] = dttSQL2.Compute("Sum(FZC_TC)", "");
			dtr["FZC_YK"] = dttSQL2.Compute("Sum(FZC_YK)", "");
			dtr["FZC_PK"] = dttSQL2.Compute("Sum(FZC_PK)", "");

			dtr["FGZ_CJ"] = dttSQL2.Compute("Sum(FGZ_CJ)", "");
			dtr["FGZ_GL"] = dttSQL2.Compute("Sum(FGZ_GL)", "");
			dtr["FGZ_TC"] = dttSQL2.Compute("Sum(FGZ_TC)", "");
			dtr["FGZ_YK"] = dttSQL2.Compute("Sum(FGZ_YK)", "");
			dtr["FGZ_PK"] = dttSQL2.Compute("Sum(FGZ_PK)", "");
			dtr["FGZ_SW"] = dttSQL2.Compute("Sum(FGZ_SW)", "");
			dtr["FGZ_PD"] = dttSQL2.Compute("Sum(FGZ_PD)", "");
			dtr["FGZ_JX"] = dttSQL2.Compute("Sum(FGZ_JX)", "");
			dtr["FGZ_QT"] = dttSQL2.Compute("Sum(FGZ_QT)", "");

			dtr["FSB_CJ"] = dttSQL2.Compute("Sum(FSB_CJ)", "");
			dtr["FSB_GL"] = dttSQL2.Compute("Sum(FSB_GL)", "");
			dtr["FSB_TC"] = dttSQL2.Compute("Sum(FSB_TC)", "");
			dtr["FSB_YK"] = dttSQL2.Compute("Sum(FSB_YK)", "");
			dtr["FSB_PK"] = dttSQL2.Compute("Sum(FSB_PK)", "");
			dtr["FSB_SW"] = dttSQL2.Compute("Sum(FSB_SW)", "");
			dtr["FSB_PD"] = dttSQL2.Compute("Sum(FSB_PD)", "");
			dtr["FSB_JX"] = dttSQL2.Compute("Sum(FSB_JX)", "");
			dtr["FSB_QT"] = dttSQL2.Compute("Sum(FSB_QT)", "");


			dtr["FEmployeeNum"] = dttSQL2.Compute("Sum(FEmployeeNum)", "");

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
				sSQL += " FROM TAB04 where ID='" + ((DataRowView)bdsMaster.Current).Row["ID"] + "'";
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
				frmYZOrder04 frmYZOrder04 = new frmYZOrder04("SEL", ((DataRowView)bdsMaster.Current).Row["ID"].ToString());
				frmYZOrder04.Text = frmYZOrder04.Text;
				frmYZOrder04.Show();

			}

		}

		//新增
		private void btnADD_Click(object sender, EventArgs e)
		{
			frmYZOrder04 frmYZOrder04 = new frmYZOrder04("ADD", "");
			frmYZOrder04.Text = frmYZOrder04.Text;
			frmYZOrder04.Show();
		}
		//修改
		private void tsbtnEdit_Click(object sender, EventArgs e)
		{
			if (bdsMaster.Current != null)
			{
				if (getBillState("修改"))
				{
					frmYZOrder04 frmYZOrder04 = new frmYZOrder04("EDIT", ((DataRowView)bdsMaster.Current).Row["ID"].ToString());
					frmYZOrder04.Text = frmYZOrder04.Text;
					frmYZOrder04.Show();
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
						sSQL = " delete from  TAB04 where ID='" + ((DataRowView)bdsMaster.Current).Row["ID"] + "'";
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
					sSQL = " update TAB04 set FState=1,FCheckUser='" + PropertyClass.OperatorName + "',FCheckDate='" + k3db.GetCurrentDate() + "' where ID='" + ((DataRowView)bdsMaster.Current).Row["ID"] + "'";
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
					sSQL = " update TAB04 set FState=0,FCheckUser=NULL,FCheckDate=NULL where ID='" + ((DataRowView)bdsMaster.Current).Row["ID"] + "'";
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
