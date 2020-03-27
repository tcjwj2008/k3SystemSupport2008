using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using YXK3FZ.ComClass;
using YXK3FZ.DataClass;
using System.Data.OleDb;
using System.Data.SqlClient;

using System.IO;   //特別引用流 System.IO
using System.Collections;
using Excel = Microsoft.Office.Interop.Excel;
using System.Reflection;

namespace YXK3FZ.RP.from
{
	public partial class frmNewRSjy : Form
	{

		DataSet ds = new DataSet();//excel

		DataSet dsMoney = new DataSet();

		DataSet dsDayHeadNum = new DataSet(); //当天屠宰头数


		// DataBase db = new DataBase(PropertyClass.con_yxsp);
		DataBase db = new DataBase();

		string sSPConn = string.Empty; //食品连接字符串
		string sRYConn = string.Empty; //肉业连接字符串

		DataBase dbSP;
		DataBase dbRY;

		CommonUse commUse = new CommonUse();
		int Ftype = 0;



		public frmNewRSjy()
		{
			InitializeComponent();

			splitContainer5Data.Panel2Collapsed = true;

		}

		private void frmNewRSjy_Load(object sender, EventArgs e)
		{
			DataTable dttSP = db.GetDataTable(" SELECT Fdbstr FROM YXZTLIST WHERE ID=1 ", "SP");
			DataTable dttRY = db.GetDataTable(" SELECT Fdbstr FROM YXZTLIST WHERE ID=2 ", "RY");
			if (dttSP.Rows.Count > 0)
			{
				sSPConn = dttSP.Rows[0][0].ToString();
			}
			if (dttRY.Rows.Count > 0)
			{
				sRYConn = dttRY.Rows[0][0].ToString();
			}

			dbSP = new DataBase(sSPConn);
			dbRY = new DataBase(sRYConn);
		}

		private void button1_Click(object sender, EventArgs e) //成本查询
		{
			splitContainer5Data.Panel1Collapsed = true;
			if (splitContainer5Data.Panel2Collapsed == true)
			{
				splitContainer5Data.Panel2Collapsed = false;
			}

			Ftype = 1;
			WaitFormService.CreateWaitForm();
			WaitFormService.SetWaitFormCaption("数据正在处理......");

			//this.toolStripStatusLabel1.Text = " 正在读取表格数据......";

			SqlParameter param1 = new SqlParameter("@BegDate", SqlDbType.DateTime);
			param1.Value = this.dateTimePicker1.Value;
			SqlParameter param2 = new SqlParameter("@EndDate", SqlDbType.DateTime);
			param1.Value = this.dateTimePicker1.Value;
			param2.Value = this.dateTimePicker2.Value;
			//创建泛型
			List<SqlParameter> parameters = new List<SqlParameter>();
			parameters.Add(param1);
			parameters.Add(param2);
			//把泛型中的元素复制到数组中
			SqlParameter[] inputParameters = parameters.ToArray();
			try
			{
				ds = db.GetProcDataSet("sp_sel_yx_rs_ysprice", inputParameters);
				this.dataGridView2Price.DataSource = ds.Tables[0];

				//this.toolStripStatusLabel1.Text = " 读取成本数据完成.";
				WaitFormService.CloseWaitForm();
			}
			catch (Exception err)
			{
				WaitFormService.CloseWaitForm();
				MessageBox.Show("操作失败！" + err.ToString());
				//this.toolStripStatusLabel1.Text = " 读取成本数据失败.";

			}

		}


		private void button2_Click(object sender, EventArgs e) //经营表查询
		{
			Ftype = 0;

			splitContainer5Data.Panel2Collapsed = true;
			if (splitContainer5Data.Panel1Collapsed == true)
			{
				splitContainer5Data.Panel1Collapsed = false;
			}

			WaitFormService.CreateWaitForm();
			WaitFormService.SetWaitFormCaption("数据正在处理......");

			//this.toolStripStatusLabel1.Text = " 正在读取表格数据......";

			SqlParameter param1 = new SqlParameter("@BegDate", SqlDbType.VarChar);
			param1.Value = this.dateTimePicker1.Value.ToShortDateString();
			SqlParameter param2 = new SqlParameter("@EndDate", SqlDbType.VarChar);
			param2.Value = this.dateTimePicker2.Value.ToShortDateString(); ;
			SqlParameter param3 = new SqlParameter("@fdepnumber", SqlDbType.VarChar);
			param3.Value = this.textBox1.Text.Trim();

			SqlParameter param4 = new SqlParameter("@fType", SqlDbType.VarChar);
			param4.Value = "1";
			if (PropertyClass.OperatorName == "李桂炫") //如果不是李桂炫
			{
				param4.Value = "0";
			}

			//创建泛型
			List<SqlParameter> parameters = new List<SqlParameter>();
			parameters.Add(param1);
			parameters.Add(param2);
			parameters.Add(param3);
			parameters.Add(param4);

			//把泛型中的元素复制到数组中
			SqlParameter[] inputParameters = parameters.ToArray();
			try
			{
				ds = db.GetProcDataSet("sp_sel_rsjyb_New", inputParameters);
				this.dataGridView1.DataSource = ds.Tables[0];

				//加载回款信息
				if (dateTimePicker1.Text == dateTimePicker2.Text)
				{
					dsMoney = db.GetProcDataSet("sp_sel_rsjyb_Money", inputParameters);
					this.dataGridView2.DataSource = dsMoney.Tables[0];

					for (int i = 0; i < this.dataGridView2.Columns.Count; i++)
					{
						if (i > 2)
							this.dataGridView2.Columns[i].Width = 150;
					}
				}


					//for (int i = 0; i < dataGridView1.Columns.Count; i++)
					//{
					//  if (dataGridView1.Columns[i].HeaderText == "当天屠宰头数" || dataGridView1.Columns[i].HeaderText == "当月屠宰头数")
					//  {
					//    dataGridView1.Columns[i].Visible = false; //隐藏当列
					//  }
					//}


					//this.toolStripStatusLabel1.Text = " 读取经营数据完成.";
					WaitFormService.CloseWaitForm();

				if (PropertyClass.OperatorName != string.Empty) //如果不是李桂炫，不显示回款信息
				{

					List<string> sDate = new List<string>();
					DateTime dt1 = Convert.ToDateTime(dateTimePicker1.Text);
					DateTime dt2 = Convert.ToDateTime(dateTimePicker2.Text);

					while (dt1 <= dt2)
					{
						sDate.Add(dt1.ToString("yyyy-MM-dd"));
						dt1 = dt1.AddDays(1);
					}

					string sSQL = string.Empty;
					sSQL += " SELECT FNumber,FName FROM dbo.t_Department  ";
					sSQL += " WHERE 1=1 ";
					if (textBox1.Text != string.Empty)
					{
						sSQL += " And FNumber ='" + textBox1.Text.Trim() + "' ";
					}
					else
					{
						sSQL += " And FNumber IN('10.11','10.12','10.13','10.14','10.15','10.16','10.17','10.19') ";
					}
					sSQL += " ORDER BY FNumber ";
					DataTable dDepart = dbRY.GetDataTable(sSQL, "A");

					DataTable dt = new DataTable(); //自定义表
					dt.Columns.Add("日期");
					dt.Columns.Add("部门代码");
					dt.Columns.Add("部门名称");

					foreach (string s in sDate)
					{
						for (int i = 0; i < dDepart.Rows.Count; i++)
						{
							DataRow dtr = dt.NewRow();
							dtr["日期"] = s;
							dtr["部门代码"] = dDepart.Rows[i]["FNumber"];
							dtr["部门名称"] = dDepart.Rows[i]["FName"];
							dt.Rows.Add(dtr);
						}
						DataRow dtr2 = dt.NewRow();
						dtr2["日期"] = s;
						dtr2["部门代码"] = "本日小计";
						dtr2["部门名称"] = "本日小计";
						dt.Rows.Add(dtr2);

					}

				}

			}
			catch (Exception err)
			{
				WaitFormService.CloseWaitForm();
				MessageBox.Show("操作失败！" + err.ToString());
				//this.toolStripStatusLabel1.Text = " 读取经营数据失败.";

			}





		}

		private void button3_Click(object sender, EventArgs e) //导入成本
		{
			WaitFormService.CreateWaitForm();
			WaitFormService.SetWaitFormCaption("数据正在处理......");

			//this.toolStripStatusLabel1.Text = " 正在读取表格数据......";
			List<string> strSqls = new List<string>();
			if (this.dataGridView2Price.RowCount == 0)
			{
				return;
			}

			string sSQL = string.Empty;

			//清空临时数据
			strSqls.Add("  DELETE yx_rs_ysprice_CHECK WHERE FuserName='" + PropertyClass.OperatorName + "'");
			strSqls.Add("  DELETE yx_rs_DayHeadNum_Check WHERE FuserName='" + PropertyClass.OperatorName + "'");

			sSQL += " DELETE yx_rs_ysprice_CHECK WHERE FuserName='" + PropertyClass.OperatorName + "'";
			sSQL += " DELETE yx_rs_DayHeadNum_Check WHERE FuserName='" + PropertyClass.OperatorName + "'";

			DataRow dr = null;
			for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
			{

				dr = ds.Tables[0].Rows[i];
				strSqls.Add(" INSERT INTO yx_rs_ysprice_CHECK(Fnumber,Fprice,FDATE,FuserName)  VALUES  ( '" + dr["编码"].ToString() + "'," + dr["成本单价"].ToString() + ",'" + dr["日期"].ToString() + "','" + PropertyClass.OperatorName + "') ");
				sSQL += " INSERT INTO yx_rs_ysprice_CHECK(Fnumber,Fprice,FDATE,FuserName)  VALUES  ( '" + dr["编码"].ToString() + "'," + dr["成本单价"].ToString() + ",'" + dr["日期"].ToString() + "','" + PropertyClass.OperatorName + "') ";

			}

			//处理当天屠宰头数

			for (int i = 0; i < dsDayHeadNum.Tables[0].Rows.Count; i++)
			{
				dr = dsDayHeadNum.Tables[0].Rows[i];
				strSqls.Add(" INSERT INTO yx_rs_DayHeadNum_Check(FDATE,FDayHeadNum,FuserName)  VALUES  ( '" + dr["日期"].ToString() + "'," + dr["当天屠宰头数"].ToString() + ",'" + PropertyClass.OperatorName + "') ");
				sSQL += "  INSERT INTO yx_rs_DayHeadNum_Check(FDATE,FDayHeadNum,FuserName)  VALUES  ( '" + dr["日期"].ToString() + "'," + dr["当天屠宰头数"].ToString() + ",'" + PropertyClass.OperatorName + "')";
			}




			if (!db.ExecDataBySqls(strSqls))
			{
				//this.toolStripStatusLabel1.Text = " 读取表格数据失败!";
				WaitFormService.CloseWaitForm();
				MessageBox.Show("保存失败！", "软件提示");
				return;
			}

			//MessageBox.Show("读取成功！", "软件提示");
			//this.toolStripStatusLabel1.Text = " 开始检查数据......";

			SqlParameter param = new SqlParameter("@FuserName", SqlDbType.VarChar);
			param.Value = PropertyClass.OperatorName;
			//创建泛型
			List<SqlParameter> parameters = new List<SqlParameter>();
			parameters.Add(param);
			//把泛型中的元素复制到数组中
			SqlParameter[] inputParameters = parameters.ToArray();
			//存储过程 
			DataRow drc = null;
			drc = db.GetDataTable("sp_checkToyx_rs_ysprice ", inputParameters).Rows[0];
			if (drc["isok"].ToString() == "-1")
			{
				//this.toolStripStatusLabel1.Text = " 表格数据检查失败!";
				WaitFormService.CloseWaitForm();
				MessageBox.Show("保存失败:" + drc["msg"].ToString(), "软件提示");
				return;
			}

			//this.toolStripStatusLabel1.Text = " 开始写入K3......";

			SqlParameter param2 = new SqlParameter("@FuserName", SqlDbType.VarChar);
			param2.Value = PropertyClass.OperatorName;
			//创建泛型
			List<SqlParameter> parameters2 = new List<SqlParameter>();
			parameters2.Add(param2);
			//把泛型中的元素复制到数组中
			SqlParameter[] inputParameters2 = parameters2.ToArray();
			try
			{
				db.GetProcRow("sp_insertToyx_rs_ysprice", inputParameters2);
				//this.toolStripStatusLabel1.Text = " 表格数据导入成功!";
				WaitFormService.CloseWaitForm();
				MessageBox.Show("成功导入K3!", "软件提示");
				this.dataGridView1.DataSource = null;

			}
			catch (Exception ex)
			{
				//this.toolStripStatusLabel1.Text = " 表格数据导入失败!";
				WaitFormService.CloseWaitForm();
				MessageBox.Show("导入K3失败!" + ex.ToString(), "软件提示");

			}




		}

		private void button4_Click(object sender, EventArgs e) //读取EXCEL
		{
			OpenFileDialog openFileDialog1 = new OpenFileDialog();
			string excelFileName = "";
			openFileDialog1.FileName = "";
			//openFileDialog1.Filter = "EXCEL文件(*.xls,*.xlsx)|*.xls,*.xlsx";
			if (openFileDialog1.ShowDialog() == DialogResult.OK)
			{


				excelFileName = openFileDialog1.FileName;

				bind(excelFileName);


			}
		}

		private void bind(string fileName)
		{

			// string strConn = "Provider=Microsoft.Jet.OLEDB.4.0;" + "Data Source=" + fileName + ";" + "Extended Properties=Excel 8.0;";

			string strConn = "Provider=Microsoft.ACE.OLEDB.12.0;" + "Data Source=" + fileName + ";" + "Extended Properties=Excel 8.0;";
			OleDbConnection Excel_conn = new OleDbConnection(strConn);

			//读取Sheet1数据
			string SheetName = "";
			SheetName = GetFirstSheetNameFromExcelFileName(fileName, 1);
			string strExcel = string.Format("select * from [{0}" + "$]  ", SheetName);
			OleDbDataAdapter da = new OleDbDataAdapter(strExcel, strConn);


			//读取Sheet2数据
			string sMySql = "SELECT * FROM  [Sheet2$]";//
			OleDbDataAdapter da2 = new OleDbDataAdapter(sMySql, strConn);


			try
			{

				da.Fill(ds);
				this.dataGridView2Price.DataSource = ds.Tables[0];

				da2.Fill(dsDayHeadNum); //填充数据集              

			}

			catch (Exception err)
			{
				MessageBox.Show("操作失败！" + err.ToString());

			}

		}

		public string GetFirstSheetNameFromExcelFileName(string filepath, int numberSheetID)
		{
			if (!System.IO.File.Exists(filepath))
			{
				return "This file is on the sky??";
			}
			if (numberSheetID <= 1) { numberSheetID = 1; }
			try
			{
				Microsoft.Office.Interop.Excel.Application obj = default(Microsoft.Office.Interop.Excel.Application);
				Microsoft.Office.Interop.Excel.Workbook objWB = default(Microsoft.Office.Interop.Excel.Workbook);
				string strFirstSheetName = null;

				obj = (Microsoft.Office.Interop.Excel.Application)Microsoft.VisualBasic.Interaction.CreateObject("Excel.Application", string.Empty);
				objWB = obj.Workbooks.Open(filepath, Type.Missing, Type.Missing,
						Type.Missing, Type.Missing, Type.Missing, Type.Missing,
						Type.Missing, Type.Missing, Type.Missing, Type.Missing,
						Type.Missing, Type.Missing, Type.Missing, Type.Missing);

				strFirstSheetName = ((Microsoft.Office.Interop.Excel.Worksheet)objWB.Worksheets[1]).Name;

				objWB.Close(Type.Missing, Type.Missing, Type.Missing);
				objWB = null;
				obj.Quit();
				obj = null;
				return strFirstSheetName;
			}
			catch (Exception Err)
			{
				return Err.Message;
			}
		}

		/// <summary>
		/// 自动导入功能 从报表取数据
		/// 1.判断报表有没有对应日期的数据，若没有，提示先计算
		/// 2.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnAutoImport_Click(object sender, EventArgs e)
		{
			#region 判断
			string sSQL = string.Empty;
			string sFindDate = Convert.ToDateTime(dateTimePicker1.Text).ToString("yyyy-MM-dd");
			sSQL = " SELECT * FROM t_yxryCost WHERE FFDate='" + sFindDate + "'";
			DataTable dttCount = dbRY.GetDataTable(sSQL, "A");
			if (dttCount.Rows.Count == 0)
			{
				MessageBox.Show("日期：" + sFindDate + " 报表数据未生成，无法自动导入");
				return;
			}

			#endregion

			#region 处理临时表数据
			WaitFormService.CreateWaitForm();
			WaitFormService.SetWaitFormCaption("数据正在处理......");

			//this.toolStripStatusLabel1.Text = " 正在读取数据......";

			//执行读取报表数据
			SqlParameter param02 = new SqlParameter("@Fdate", SqlDbType.VarChar);
			param02.Value = sFindDate;
			SqlParameter param01 = new SqlParameter("@FuserName", SqlDbType.VarChar);
			param01.Value = PropertyClass.OperatorName;

			//创建泛型
			List<SqlParameter> parameters01 = new List<SqlParameter>();
			parameters01.Add(param02);
			parameters01.Add(param01);
			SqlParameter[] inputParameters01 = parameters01.ToArray();

			DataBase db2 = new DataBase();

			try
			{
				db2.GetProcRow("sp_yxryCostAutoImport_czq", inputParameters01);
				//this.toolStripStatusLabel1.Text = " 数据读取成功!";

			}
			catch (Exception ex)
			{
				//this.toolStripStatusLabel1.Text = " 数据读取失败!";
				WaitFormService.CloseWaitForm();
				MessageBox.Show("数据读取失败！", "软件提示");
				return;
			}

			#endregion

			#region 调用原来方法执行
			//this.toolStripStatusLabel1.Text = " 开始检查数据......";

			SqlParameter param = new SqlParameter("@FuserName", SqlDbType.VarChar);
			param.Value = PropertyClass.OperatorName;
			//创建泛型
			List<SqlParameter> parameters = new List<SqlParameter>();
			parameters.Add(param);
			//把泛型中的元素复制到数组中
			SqlParameter[] inputParameters = parameters.ToArray();
			//存储过程 
			DataRow drc = null;
			drc = db.GetDataTable("sp_checkToyx_rs_ysprice ", inputParameters).Rows[0];
			if (drc["isok"].ToString() == "-1")
			{
				//this.toolStripStatusLabel1.Text = " 表格数据检查失败!";
				WaitFormService.CloseWaitForm();
				MessageBox.Show("保存失败:" + drc["msg"].ToString(), "软件提示");
				return;
			}

			//this.toolStripStatusLabel1.Text = " 开始写入K3......";

			SqlParameter param2 = new SqlParameter("@FuserName", SqlDbType.VarChar);
			param2.Value = PropertyClass.OperatorName;
			//创建泛型
			List<SqlParameter> parameters2 = new List<SqlParameter>();
			parameters2.Add(param2);
			//把泛型中的元素复制到数组中
			SqlParameter[] inputParameters2 = parameters2.ToArray();
			try
			{
				db.GetProcRow("sp_insertToyx_rs_ysprice", inputParameters2);
				//this.toolStripStatusLabel1.Text = " 表格数据导入成功!";
				WaitFormService.CloseWaitForm();
				MessageBox.Show("成功导入K3!", "软件提示");
				this.dataGridView1.DataSource = null;

			}
			catch (Exception ex)
			{
				//this.toolStripStatusLabel1.Text = " 表格数据导入失败!";
				WaitFormService.CloseWaitForm();
				MessageBox.Show("导入K3失败!" + ex.ToString(), "软件提示");

			}

			#endregion

		}

		private void button5_Click(object sender, EventArgs e)
		{
			CommExcel.ExportExcel("", dataGridView1, true);
		}

	
	
	}



}
