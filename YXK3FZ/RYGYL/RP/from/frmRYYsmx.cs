using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CrystalDecisions.Shared; //TableLogOnInfo
using CrystalDecisions.CrystalReports.Engine; //ReportDocument
using System.Data.SqlClient;
using YXK3FZ.DataClass;
using YXK3FZ.ComClass;

namespace YXK3FZ.RP.from
{
    public partial class frmRYYsmx : Form
    {
        DataBase db = new DataBase();
        DataBase k3db = null;
        DataSet ds = null;
        CommonUse commUse = new CommonUse();

				public frmRYYsmx()
        {
            InitializeComponent();
        }

        private int _DB_ID = 2;
        public int DB_ID
        {
            get { return _DB_ID; }
            set { _DB_ID = value; }
        }

        private void frmDzpYsmx_Load(object sender, EventArgs e)
        {
            
            //ds = db.GetDataSet("SELECT Fdbstr    FROM dbo.YXZTLIST WHERE ID=4", "con");

            if (DB_ID == 4)
            {
                ds = db.GetDataSet("SELECT Fdbstr    FROM dbo.YXZTLIST WHERE ID=4", "con");
            }
            else if (DB_ID == 7)
            {
                ds = db.GetDataSet("SELECT Fdbstr    FROM dbo.YXZTLIST WHERE ID=7", "con");
            }
						else if (DB_ID == 2)
						{
							ds = db.GetDataSet("SELECT Fdbstr    FROM dbo.YXZTLIST WHERE ID=2", "con");
						}

            string dzpcon = ds.Tables[0].Rows[0]["Fdbstr"].ToString();
            k3db = new DataBase(dzpcon);
            
            //权限控制
            commUse.CortrolButtonEnabled(btnSelect, this);
          

            //判断是否为主窗体双击打开
            if (this.txtFcurnumber.Text != "")
            {
                this.btnSelect_Click(null, null);
            }
            else
            {
                this.txtYear.Text = DateTime.Now.Year.ToString();
                this.txtMonth.Text = DateTime.Now.Month.ToString();
            
            }

        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
          //MessageBox.Show("shuangji");
            if (this.txtYear.Text.Trim()=="" ||this.txtMonth.Text.Trim()=="" ||this.txtFcurnumber.Text.Trim()=="" )
            {
                MessageBox.Show("请输入查询年份和期间以及客户代码！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);

                return;
            
            }
            ds = k3db.GetDataSet("SELECT fitemid FROM  t_Organization WHERE FNumber='" + this.txtFcurnumber.Text.Trim() + "'", "cur");
            if (ds.Tables[0].Rows.Count!=1)
            {
            MessageBox.Show("请输入准确并且存在的客户代码！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);

                return;
            }





            string strReportPath = Application.StartupPath;
            // Application.StartupPath.Substring(0, Application.StartupPath.Substring(0,
            // Application.StartupPath.LastIndexOf("\\")).LastIndexOf("\\"));
            //strReportPath += @"\RP\RPT\" + strReportFileName;
            strReportPath += @"\RPT\dzpyxtj.rpt" ;

            //得到dt数据源
            SqlParameter param1 = new SqlParameter("@year", SqlDbType.VarChar);
            param1.Value =this.txtYear.Text.Trim();
            SqlParameter param2 = new SqlParameter("@month", SqlDbType.VarChar);
            param2.Value = this.txtMonth.Text.Trim();
            SqlParameter param3 = new SqlParameter("@fcurnumber", SqlDbType.VarChar);
            param3.Value = this.txtFcurnumber.Text.Trim();
            //创建泛型
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(param1);
            parameters.Add(param2);
            parameters.Add(param3);
            //把泛型中的元素复制到数组中
            SqlParameter[] inputParameters = parameters.ToArray();

            DataTable dt = k3db.GetDataTable("sp_DzpYsTJ_one", inputParameters);


            //ReportDocument对象加载rpt文件并绑定到数据源dt
            //明细
            ReportDocument reportDoc = new ReportDocument();
            reportDoc.Load(strReportPath);
            reportDoc.SetDataSource(dt.DefaultView); //DataView是接口IEnumerable的实现子类,此处使用了“接口”的多态特性
           // crystalReportViewer1.ReportSource = reportDoc;
            //对账单
            string strReportPath2 = Application.StartupPath;
            strReportPath2 += @"\RPT\dzpysdzd.rpt";
            //dzpysdzd.rpt
            //SELECT '林水凉' AS 客户名称, 'AAAA' 片区  '2014-9' AS 期间,'2014-09-30 '截止日期,-4037.35 期初余额,0 本期借方,10000	本期贷方,-6549.3 期末余额
            

            string Sqlstr = " select '" + dt.Rows[0]["客户名称"].ToString()+"' AS 客户名称, '"+
                              dt.Rows[0]["片区"].ToString() +"' 片区,'"+
                              dt.Rows[0]["年份"].ToString()+"-"+dt.Rows[0]["期间"].ToString()+"' AS 期间,'"+
                               dt.Rows[0]["年份"].ToString()+"-"+dt.Rows[0]["期间"].ToString()+"-"+dt.Rows[dt.Rows.Count-2]["日期"].ToString()+"' as 截止日期,"+
                                dt.Rows[dt.Rows.Count-1]["期初余额"].ToString()+"  as 期初余额,"+
                                dt.Rows[dt.Rows.Count-1]["出货"].ToString()+"-("+ dt.Rows[dt.Rows.Count-1]["退货"].ToString()+")  as 本期借方,"+
                                dt.Rows[dt.Rows.Count-1]["回款"].ToString().Trim()+" as 本期贷方,"+
                               dt.Rows[dt.Rows.Count - 1]["期末余额"].ToString() + " as  期末余额 ";
                              // "  0 as  期末余额 ";

            DataTable dtdzd = k3db.GetDataTable(Sqlstr,"tab");

                ReportDocument reportDoc2 = new ReportDocument();
            reportDoc2.Load(strReportPath2);
            reportDoc2.SetDataSource(dtdzd.DefaultView); //DataView是接口IEnumerable的实现子类,此处使用了“接口”的多态特性
            crystalReportViewer2.ReportSource = reportDoc2;


        }
    }
}
