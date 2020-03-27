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
    public partial class frm_yx_btpfjbmx : Form
    {
        CommonUse commUse = new CommonUse();
        DataTable dt = new DataTable();
        DataBase k3db = null;
        DataBase db = new DataBase();
        DataSet ds = new DataSet();
        DataSet dsbb = new DataSet();
        string conSp;
        public frm_yx_btpfjbmx()
        {
            InitializeComponent();
        }

        private void frm_yx_btpfjbmx_Load(object sender, EventArgs e)
        {
            ds = db.GetDataSet("SELECT Fdbstr    FROM dbo.YXZTLIST WHERE ID=1", "con");
            DataRow dr = ds.Tables[0].Rows[0];
            conSp = dr["Fdbstr"].ToString();
            k3db = new DataBase(conSp);
            commUse.CortrolButtonEnabled(btnSel, this);
        }

        private void btnSel_Click(object sender, EventArgs e)
        {

            SqlParameter param1 = new SqlParameter("@fPdate", SqlDbType.VarChar);
            param1.Value = this.dateTimePicker1.Value.ToString("yyyy-MM-dd");
         


            //创建泛型
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(param1);
          

            //把泛型中的元素复制到数组中
            SqlParameter[] inputParameters = parameters.ToArray();


            dsbb = k3db.GetProcDataSet("sp_yx_btpfjbmx", inputParameters);
            dt = dsbb.Tables[0];

            string strReportPath = Application.StartupPath;

            strReportPath += @"\RPT\白条批发部级别明细.rpt";

            //ReportDocument对象加载rpt文件并绑定到数据源dt
            //明细
            ReportDocument reportDoc = new ReportDocument();
            reportDoc.Load(strReportPath);
            reportDoc.SetDataSource(dt.DefaultView); //DataView是接口IEnumerable的实现子类,此处使用了“接口”的多态特性
            crystalReportViewer1.ReportSource = reportDoc;
        }
    }
}
