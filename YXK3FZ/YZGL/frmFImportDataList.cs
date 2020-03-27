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

	public partial class frmFImportDataList : Form
	{

		DataBase db = new DataBase();
		DataSet ds = null;
		DataBase k3db = null;
		CommonUse commUse = new CommonUse();

		System.Windows.Forms.DataGridViewCellStyle dgvCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();

		DataTable dttTemp; //保存导入的表

		public frmFImportDataList()
		{
			InitializeComponent();
			//rbByHour.Checked = true;
			txtFDate1.ShowCheckBox = true;
			txtFDate2.ShowCheckBox = true;

			k3db = new DataBase(YXK3FZ.DataClass.DataBase.m_Connstr);
		}

		private void rbByHour_CheckedChanged(object sender, EventArgs e) //按每时
		{
			if (rbByHour.Checked)
			{
				lblTitle.Text = "查询时间";
				txtFDate1.CustomFormat = "yyyy-MM-dd HH";
				txtFDate2.CustomFormat = "yyyy-MM-dd HH";
				dgvCellStyle1.Format = "yyyy-MM-dd HH";
				colFDateTime.DefaultCellStyle = dgvCellStyle1;
				button1_Click(null, null);
			}
		}

		private void rbByDay_CheckedChanged(object sender, EventArgs e)//按每天
		{
			if (rbByDay.Checked)
			{
				lblTitle.Text = "查询日期";
				txtFDate1.CustomFormat = "yyyy-MM-dd";
				txtFDate2.CustomFormat = "yyyy-MM-dd";
				dgvCellStyle1.Format = "yyyy-MM-dd";
				colFDateTime.DefaultCellStyle = dgvCellStyle1;
				button1_Click(null, null);
			}
		}

		private void rbByMonth_CheckedChanged(object sender, EventArgs e)//按每月
		{
			if (rbByMonth.Checked)
			{
				lblTitle.Text = "查询月份";
				txtFDate1.CustomFormat = "yyyy-MM";
				txtFDate2.CustomFormat = "yyyy-MM";
				dgvCellStyle1.Format = "yyyy-MM";
				colFDateTime.DefaultCellStyle = dgvCellStyle1;
				button1_Click(null, null);
			}
		}

		private void rbByYear_CheckedChanged(object sender, EventArgs e)//按每年
		{
			if (rbByYear.Checked)
			{
				lblTitle.Text = "查询年份";
				txtFDate1.CustomFormat = "yyyy";
				txtFDate2.CustomFormat = "yyyy";
				dgvCellStyle1.Format = "";
				colFDateTime.DefaultCellStyle = dgvCellStyle1;
				button1_Click(null, null);
			}
		}


		//得到表结构
		private  DataTable getDataStru()
		{
			string sSQL = " SELECT * from t_YZ_ImportData where 1<0 ";
			DataSet ds2 = k3db.GetDataSet(sSQL, "sel");
			return ds2.Tables[0];
		}

		private void button3_Click(object sender, EventArgs e) //读取EXCEL
		{
			string excelFileName = "";
			openFileDialog1.FileName = "";
			//openFileDialog1.Filter = "EXCEL文件(*.xls,*.xlsx)|*.xls,*.xlsx";
			if (openFileDialog1.ShowDialog() == DialogResult.OK)
			{
				excelFileName = openFileDialog1.FileName;

				

				//System.Data.DataTable dt = YXK3FZ.ComClass.NewNPOIExcelHelper.GetDataTable(excelFileName);

				System.Data.DataTable dt = YXK3FZ.ComClass.CommOfficeExcel.GetDataFromExcelByCom(true, excelFileName);


				dttTemp = getDataStru(); //临时表，装载导入的数据
				DataRow dtr;

		

				dt.Rows[0].Delete();//删除第一行表头数据

				int i = 0; //计时器


				foreach (DataRow dtr2 in dt.Rows)
				{
					if (i < 24)
					{
						dtr = dttTemp.NewRow();

						dtr["FName"] = dtr2[0];
						dtr["FDateTime"] = Convert.ToDateTime(dtr2[1] + ":00").ToString("yyyy-MM-dd HH:mm");

						dtr["AvgSO2"] = (dtr2[2].ToString()!=string.Empty)? dtr2[2]:0;
						dtr["DischargeSO2"] = (dtr2[3].ToString() != string.Empty) ? dtr2[3] : 0;
						dtr["AvgSO2ZSND"] = (dtr2[4].ToString() != string.Empty) ? dtr2[4] : 0;
						dtr["DischargeSO2ZSND"] = (dtr2[5].ToString() != string.Empty) ? dtr2[5] : 0;

						dtr["AvgNOX"] = (dtr2[6].ToString() != string.Empty) ? dtr2[6] : 0;
						dtr["DischargeNOX"] = (dtr2[7].ToString() != string.Empty) ? dtr2[7] : 0;
						dtr["AvgNOXZSND"] = (dtr2[8].ToString() != string.Empty) ? dtr2[8] : 0;
						dtr["DischargeNOXZSND"] = (dtr2[9].ToString() != string.Empty) ? dtr2[9] : 0;

						dtr["AvgSMOKE"] = (dtr2[10].ToString() != string.Empty) ? dtr2[10] : 0;
						dtr["DischargeSMOKE"] = (dtr2[11].ToString() != string.Empty) ? dtr2[11] : 0;
						dtr["AvgSMOKEZSND"] = (dtr2[12].ToString() != string.Empty) ? dtr2[12] : 0;
						dtr["DischargeSMOKEZSND"] = (dtr2[13].ToString() != string.Empty) ? dtr2[13] : 0;

						dtr["AvgO2"] = (dtr2[14].ToString() != string.Empty) ? dtr2[14] : 0;

						dtr["AvgFlow"] = (dtr2[15].ToString() != string.Empty) ? dtr2[15] : 0;
						dtr["SumFlow"] = (dtr2[16].ToString() != string.Empty) ? dtr2[16] : 0;

						dtr["FYear"] = Convert.ToDateTime(dtr2[1] + ":00").Year;
						dtr["FMonth"] = Convert.ToDateTime(dtr2[1] + ":00").Month;
						dtr["FDate"] = Convert.ToDateTime(dtr2[1] + ":00").ToString("yyyy-MM-dd");

						dttTemp.Rows.Add(dtr);
						i++;
					}
				}


				bdsFind.DataSource = dttTemp;



			}

		}


		private void btnImport_Click(object sender, EventArgs e) //导入数据
		{

			WaitFormService.CreateWaitForm();
			WaitFormService.SetWaitFormCaption("数据正在处理......");

			
			List<string> strSqls = new List<string>();
			if (this.dataGridView1.RowCount == 0)
			{
				return;
			}
			strSqls.Add("  DELETE t_YZ_ImportData WHERE FDate='" + dttTemp.Rows[0]["FDate"] + "'"); //删除要导入的日期的时间
			string str;
			str = "";

			DataRow dr = null;

			int k = 0;
			for (int i = 0; i < dttTemp.Rows.Count; i++)
			{

				dr = dttTemp.Rows[i];
				strSqls.Add(" INSERT INTO [YXERP].[dbo].[t_YZ_ImportData] ([FName],[FDateTime],[AvgSO2] ,[DischargeSO2] ,[AvgSO2ZSND] ,[DischargeSO2ZSND] ,[AvgNOX] ,[DischargeNOX],[AvgNOXZSND],[DischargeNOXZSND],[AvgSMOKE],[DischargeSMOKE],[AvgSMOKEZSND],[DischargeSMOKEZSND],[AvgO2],[AvgFlow],[SumFlow],[FYear],[FMonth],[FDate])   VALUES  ( '" + dr["FName"] + "','" + dr["FDateTime"]
										+ "','" + dr["AvgSO2"] + "'," + dr["DischargeSO2"] + ",'" + dr["AvgSO2ZSND"] + "'," + dr["DischargeSO2ZSND"] + ",'" + dr["AvgNOX"] + "'," + dr["DischargeNOX"] + ",'" + dr["AvgNOXZSND"] + "'," + dr["DischargeNOXZSND"] + ",'" + dr["AvgSMOKE"] + "'," + dr["DischargeSMOKE"] + ",'" + dr["AvgSMOKEZSND"] + "'," + dr["DischargeSMOKEZSND"] + "," + dr["AvgO2"] + "," + dr["AvgFlow"] + "," + dr["SumFlow"] + "," + dr["FYear"] + "," + dr["FMonth"] + ",'" + dr["FDate"] + "') ");


		
				k++;
			}

			if (!db.ExecDataBySqls(strSqls))
			{
				
				WaitFormService.CloseWaitForm();
				MessageBox.Show("保存失败！", "软件提示");
				return;
			}

			
			WaitFormService.CloseWaitForm();
			MessageBox.Show("数据导入成功", "软件提示");


		}

		private void button1_Click(object sender, EventArgs e) //查询
		{
			int FType = 0;

			if (rbByHour.Checked)   //小时
			{
				FType = 1;
			}
			else if (rbByDay.Checked) //每天
			{
				FType = 2;
			}
			else if (rbByMonth.Checked)  //每月
			{
				FType = 3;
			}
			else if (rbByYear.Checked)  //每年
			{
				FType = 4;
			}
		
			DataBase db = new DataBase();

			WaitFormService.CreateWaitForm();
			WaitFormService.SetWaitFormCaption(" 正在查询，请稍候......");


			SqlParameter param1 = new SqlParameter("@FType", SqlDbType.Int);
			param1.Value = FType;	

			SqlParameter param2 = new SqlParameter("@FDate1", SqlDbType.VarChar);
			param2.Value = txtFDate1.Text;

			SqlParameter param3 = new SqlParameter("@FDate2", SqlDbType.VarChar);
			param3.Value = txtFDate2.Text;

			//创建泛型
			List<SqlParameter> parameters2 = new List<SqlParameter>();
			parameters2.Add(param1);
			parameters2.Add(param2);
			parameters2.Add(param3);

			//把泛型中的元素复制到数组中
			SqlParameter[] inputParameters2 = parameters2.ToArray();
			try
			{
				bdsFind.DataSource = db.GetDataTable("sp_YZ_ImportData_Select", inputParameters2);			

			}
			catch (Exception ex)
			{
				WaitFormService.CloseWaitForm();
				MessageBox.Show("查询失败!" + ex.ToString(), "软件提示");
				return;

			}
			WaitFormService.CloseWaitForm();
			





		}

		private void button2_Click(object sender, EventArgs e) //取消
		{
			if (bdsFind.Count == 0)
			{
				MessageBox.Show("无数据，无法导出");
				return;
			}
			string sFileName = string.Empty;

			if (rbByHour.Checked)   //小时
			{
				sFileName = "按小时导出";
			}
			else if (rbByDay.Checked) //每天
			{
				sFileName = "按每天导出";
			}
			else if (rbByMonth.Checked)  //每月
			{
				sFileName = "按每月导出";
			}
			else if (rbByYear.Checked)  //每年
			{
				sFileName = "按每年导出";
			}

			CommExcel.ExportExcel(sFileName, dataGridView1, true);


		}

		private void dataGridView1_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
		{
			SolidBrush b = new SolidBrush(this.dataGridView1.RowHeadersDefaultCellStyle.ForeColor);
			e.Graphics.DrawString((e.RowIndex + 1).ToString(System.Globalization.CultureInfo.CurrentUICulture), this.dataGridView1.DefaultCellStyle.Font, b, e.RowBounds.Location.X + 20, e.RowBounds.Location.Y + 4);

		}

		private void frmFImportDataList_Load(object sender, EventArgs e)
		{
			commUse.CortrolButtonEnabled(button3, this);
			commUse.CortrolButtonEnabled(btnImport, this);
		}

		


	}
}
