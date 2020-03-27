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
using CrystalDecisions.Shared; //TableLogOnInfo
using CrystalDecisions.CrystalReports.Engine; //ReportDocument
namespace YXK3FZ.RYGYL
{
    public partial class frm_rp_pdjy : Form
    {

        CommonUse commUse = new CommonUse();
        DataTable dt = new DataTable();
        DataBase k3db = null;
        DataBase db = new DataBase();
        DataSet ds = new DataSet();
        string conRY;
        public frm_rp_pdjy()
        {
           
            
            InitializeComponent();
        }
        private void frm_rp_pdjy_Load(object sender, EventArgs e)
        {
            ds = db.GetDataSet("SELECT Fdbstr    FROM dbo.YXZTLIST WHERE ID=2", "con");
            DataRow dr = ds.Tables[0].Rows[0];
            conRY = dr["Fdbstr"].ToString();
            k3db = new DataBase(conRY);
            commUse.CortrolButtonEnabled(btnSel, this);


        }
        private void btnSel_Click(object sender, EventArgs e)
        {
            int Fstatus = 1;
            if (this.checkBox1.Checked==true)
            {
                Fstatus = 0;
            }
           
            
            SqlParameter param2 = new SqlParameter("@fdate", SqlDbType.VarChar);
            param2.Value = this.dateTimePicker1.Value.ToString("yyyy-MM-dd");
            SqlParameter param3 = new SqlParameter("@Fstatus", SqlDbType.Int);
            param3.Value = Fstatus; 


            //创建泛型
            List<SqlParameter> parameters2 = new List<SqlParameter>();
            parameters2.Add(param2);
            parameters2.Add(param3);
            //把泛型中的元素复制到数组中
            SqlParameter[] inputParameters2 = parameters2.ToArray();


            DataTable dt = k3db.GetDataTable("sp_yx_pdjyb", inputParameters2);
            string strReportPath = Application.StartupPath;

            strReportPath += @"\RPT\yx_cr_pdjy.rpt";

            //ReportDocument对象加载rpt文件并绑定到数据源dt
            //明细
            ReportDocument reportDoc = new ReportDocument();
            reportDoc.Load(strReportPath);
            reportDoc.SetDataSource(dt.DefaultView); //DataView是接口IEnumerable的实现子类,此处使用了“接口”的多态特性
            crystalReportViewer1.ReportSource = reportDoc;



        }

     
    }
}
