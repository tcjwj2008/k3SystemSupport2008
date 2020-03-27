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

namespace YXK3FZ.RYGYL
{
    public partial class frm_yx_ywyjswcb : Form
    {

        CommonUse commUse = new CommonUse();
        DataTable dt = new DataTable();
        DataBase k3db = null;
        DataBase db = new DataBase();
        DataSet ds = new DataSet();
        DataSet dsbb = new DataSet();
        string conSp;
        public frm_yx_ywyjswcb()
        {
            InitializeComponent();
        }

        private void frm_yx_ywyjswcb_Load(object sender, EventArgs e)
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
            dsbb = k3db.GetProcDataSet("sp_yx_getEmpjsbb", inputParameters);
            this.dgvjs.DataSource = dsbb.Tables[0];
            string str = "";
            string dstr = "";
            string estr = "";
            DataTable dt = this.dsbb.Tables[0];
          //你好，今日总头数283头。其中门店87头，完成率58%（陈金镖49.5头，完成率55%。张友金37.5头，完成率63%），批发196头，完成率85%（吴加婴62头，完成率100%。吴成鸿57.5头，完成率102%。李国纯43头，完成率66%。吴春节33.5头，完成率69%）。					


            if (dt.Rows.Count > 0)
            {
              for (int i = 0; i < dt.Rows.Count; i++)
              {
                  if (dt.Rows[i]["业务员"].ToString() != "合计")
                  {
                      estr = estr + dt.Rows[i]["业务员"].ToString() + dt.Rows[i]["今日头数"].ToString() + "头，完成率" + dt.Rows[i]["销量完成率"].ToString() + "。";
                  }
                  if (dt.Rows[i]["业务员"].ToString()== "合计")
                  {
                      estr =  dt.Rows[i]["部门"].ToString() + dt.Rows[i]["今日头数"].ToString() + "头，完成率" + dt.Rows[i]["销量完成率"].ToString() + "(" + estr + ")"; ;
                      str = str + estr;
                      estr = "";
                  }
                  
                  if (dt.Rows[i]["部门"].ToString() == "总合计")
                  {
                      str = "你好，今日总头数" + dt.Rows[i]["今日头数"].ToString() + "头。其中" + str;
                  }
                
                
                
             }
           }


            rtbMsg.Text=str;






        }
    }
}
