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
namespace YXK3FZ.DZPGL
{
    public partial class frm_DZPKJ_orderMary : Form
    {

        CommonUse commUse = new CommonUse();
        DataTable dt = new DataTable();
        DataBase k3db = null;
        DataBase db = new DataBase();
        DataSet ds = new DataSet();
        string conRY;
        public frm_DZPKJ_orderMary()
        {
            InitializeComponent();
            this.Tag = "116";
        }

        private void frm_ry_orderMary_Load(object sender, EventArgs e)
        {
            //ds = db.GetDataSet("SELECT Fdbstr    FROM dbo.YXZTLIST WHERE ID=2", "con");
            //DataRow dr = ds.Tables[0].Rows[0];
            //conRY = dr["Fdbstr"].ToString();
            k3db = new DataBase(DataBase.m_Connstr);
            commUse.CortrolButtonEnabled(btnSel, this);
      
        }

        private void btnSel_Click(object sender, EventArgs e)
        {
            SqlParameter param1 = new SqlParameter("@pdate1", SqlDbType.VarChar);
            param1.Value = this.dateTimePicker1.Value.ToString("yyyy-MM-dd");

            SqlParameter param2 = new SqlParameter("@pdate2", SqlDbType.VarChar);
            param2.Value = this.dateTimePicker2.Value.ToString("yyyy-MM-dd");

            SqlParameter param3 = new SqlParameter("@fcur", SqlDbType.VarChar);
            param3.Value =this.txtFcur.Text.Trim();


            //创建泛型
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(param1);
            parameters.Add(param2);
            parameters.Add(param3);
            //把泛型中的元素复制到数组中
            SqlParameter[] inputParameters = parameters.ToArray();


            DataTable dt = k3db.GetDataTable("sp_yx_DZPbbPrint", inputParameters);
            string strReportPath = Application.StartupPath;

            strReportPath += @"\RPT\筐具出入库订单打印.rpt";

            //ReportDocument对象加载rpt文件并绑定到数据源dt
            //明细
            ReportDocument reportDoc = new ReportDocument();
            reportDoc.Load(strReportPath);
            reportDoc.SetDataSource(dt.DefaultView); //DataView是接口IEnumerable的实现子类,此处使用了“接口”的多态特性
            crystalReportViewer1.ReportSource = reportDoc;

        }



    }
}
