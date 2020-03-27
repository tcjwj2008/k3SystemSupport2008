using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using YXK3FZ.DataClass;
using YXK3FZ.ComClass;
using System.Data.OleDb;
using System.Data.SqlClient;
using CrystalDecisions.Shared; //TableLogOnInfo
using CrystalDecisions.CrystalReports.Engine; //ReportDocument

namespace YXK3FZ.RYGYL
{
    public partial class frm_spOrderPlan : Form
    {
        CommonUse commUse = new CommonUse();
        DataTable dt = new DataTable();
        DataBase k3db = null;
        DataBase db = new DataBase();
        DataSet ds = new DataSet();
        DataSet dsbb = new DataSet();
        string conSp;
        public frm_spOrderPlan()
        {
            InitializeComponent();
        }

        private void frm_spOrderPlan_Load(object sender, EventArgs e)
        {
            ds = db.GetDataSet("SELECT Fdbstr    FROM dbo.YXZTLIST WHERE ID=1", "con");
            DataRow dr = ds.Tables[0].Rows[0];
            conSp = dr["Fdbstr"].ToString();
            k3db = new DataBase(conSp);
            commUse.CortrolButtonEnabled(btnSel, this);

						string sSQL = string.Empty;
						sSQL = " SELECT FName FROM SP_BaseEntry WHERE FUID=1 ";
						DataTable dttSQL= k3db.GetDataTable(sSQL, "aa");
						cobMarket.DataSource = dttSQL;
						cobMarket.DisplayMember = "FName";
						cobMarket.ValueMember = "FName";
						cobMarket.SelectedIndex = -1;

						ckSelect.Checked = false;
						cobMarket.Enabled = false;


        }

        private void btnSel_Click(object sender, EventArgs e)
        {

            SqlParameter param1 = new SqlParameter("@fPdate", SqlDbType.VarChar);
            param1.Value=this.dateTimePicker1.Value.ToString("yyyy-MM-dd");
            SqlParameter param2 = new SqlParameter("@Fcarnum", SqlDbType.VarChar);
						if (ckSelect.Checked)
						{
							param2.Value = cobMarket.Text;
						}
						else
						{
							param2.Value = string.Empty;
						}


            //创建泛型
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(param1);
            parameters.Add(param2);
       
            //把泛型中的元素复制到数组中
            SqlParameter[] inputParameters = parameters.ToArray();


           dsbb = k3db.GetProcDataSet("yx_sp_sporderplanSel", inputParameters);
           dt = dsbb.Tables[0];

            string strReportPath = Application.StartupPath;

            strReportPath += @"\RPT\食品销售计划表.rpt";

            //ReportDocument对象加载rpt文件并绑定到数据源dt
            //明细
            ReportDocument reportDoc = new ReportDocument();
            reportDoc.Load(strReportPath);
            reportDoc.SetDataSource(dt.DefaultView); //DataView是接口IEnumerable的实现子类,此处使用了“接口”的多态特性
            crystalReportViewer1.ReportSource = reportDoc;
        }

        private void btnOut_Click(object sender, EventArgs e)
        {
            commUse.Excelout(dsbb);
        }

				private void ckSelect_CheckedChanged(object sender, EventArgs e)
				{
					if (ckSelect.Checked)
					{
						cobMarket.Enabled = true;
					}
					else
					{
						cobMarket.Enabled = false;
						cobMarket.SelectedIndex = -1;
					}
				}

    }
}
