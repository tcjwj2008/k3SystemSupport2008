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
	public partial class frmOA_YZ01 : Form
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


		public frmOA_YZ01()
		{
			InitializeComponent();
			YZConnstring = db.GetSingleObject("SELECT Fdbstr FROM YXZTLIST WHERE ID=12").ToString();
			k3db = new DataBase(YZConnstring);
		}

		private void frmOA_YZ01_Load(object sender, EventArgs e)
		{
			txtFDate1.ShowCheckBox = true;
			txtFDate2.ShowCheckBox = true;

			txtFDate1.Checked = false;
			txtFDate2.Checked = false;
		}

		//加载列表数据
		private void getDate(string Q, string sSQLWH)
		{


		}

		private void button1_Click(object sender, EventArgs e) //查询
		{
			string sSQL = string.Empty;
			sSQL += " SELECT b.sqrq 开票日期,b.kaipiaodw 开票名称,c.hetonghao 合同号,b.fapiaohm 发票号码,d.selectname 商品名称,  ";
			sSQL += " c.shuliang2 数量,c.danjia 单价,convert(varchar,convert(money,c.jinen2),1)  金额,CASE WHEN b.fapiaolx=0 THEN '专票' ELSE '普票' END 税票,b.bz 备注    ";
			sSQL += " FROM workflow_requestbase a ";
			sSQL += " INNER JOIN formtable_main_97 b ON b.requestId = a.requestid ";
			sSQL += " INNER JOIN formtable_main_97_dt1 c ON b.id=c.mainid ";
			sSQL += " INNER JOIN workflow_SelectItem d ON c.shangpinmc=d.selectvalue AND d.fieldid=8324 ";
			sSQL += " Where 1=1 ";

			if (txtkaipiaodw.Text != string.Empty)
			{
				sSQL += " and  b.kaipiaodw like '%" + txtkaipiaodw.Text.Trim() + "%' ";
			}

			if (txthetonghao.Text != string.Empty)
			{
				sSQL += " and  c.hetonghao like '%" + txthetonghao.Text.Trim() + "%' ";
			}

			if (txtfapiaohm.Text != string.Empty)
			{
				sSQL += " and  b.fapiaohm like '%" + txtfapiaohm.Text.Trim() + "%' ";
			}

			if (txtselectname.Text != string.Empty)
			{
				sSQL += " and  d.selectname like '%" + txtselectname.Text.Trim() + "%' ";
			}


			if (txtFDate1.Checked == true && txtFDate2.Checked == true)
			{
				sSQL += " and b.sqrq between '" + txtFDate1.Text + "' and  '" + txtFDate2.Text + "'";				
			}
			else
			{
				if (txtFDate1.Checked == true)
				{
					sSQL += " and b.sqrq >= '" + txtFDate1.Text + "' ";					
				}
				else if (txtFDate1.Checked == true)
				{
					sSQL += " and b.sqrq <= '" + txtFDate2.Text + "' ";
					
				}
			}

			sSQL += "order by b.sqrq ";

			bdsMaster.DataSource = k3db.GetDataSet(sSQL, "sel").Tables[0].DefaultView;
		}

		private void button2_Click(object sender, EventArgs e)
		{
			txtfapiaohm.Text = string.Empty;
			txthetonghao.Text = string.Empty;
			txtselectname.Text = string.Empty;
			txtkaipiaodw.Text = string.Empty;
			txtFDate1.Checked = false;
			txtFDate2.Checked = false;
		}

		private void button3_Click(object sender, EventArgs e)
		{
			if (bdsMaster.Count > 0)
			{
				string sfilename = "数据导出";
				ComClass.CommExcel.ExportExcel(sfilename, dataGridView1, true);
			}
		}

		private void dgvDetail_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e) //显示序号
		{
			SolidBrush b = new SolidBrush(this.dataGridView1.RowHeadersDefaultCellStyle.ForeColor);
			e.Graphics.DrawString((e.RowIndex + 1).ToString(System.Globalization.CultureInfo.CurrentUICulture), this.dataGridView1.DefaultCellStyle.Font, b, e.RowBounds.Location.X + 20, e.RowBounds.Location.Y + 4);

		}




	}
}
