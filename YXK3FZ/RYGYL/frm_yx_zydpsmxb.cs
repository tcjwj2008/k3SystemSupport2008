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
    public partial class frm_yx_zydpsmxb : Form
    {
        CommonUse commUse = new CommonUse();
        DataTable dt = new DataTable();
        DataBase k3db = null;
        DataBase db = new DataBase();
        DataSet ds = new DataSet();
        DataSet dsbb = new DataSet();
        string conSp;
        public frm_yx_zydpsmxb()
        {
            InitializeComponent();
        }

        private void frm_yx_zydpsmxb_Load(object sender, EventArgs e)
        {
            ds = db.GetDataSet("SELECT Fdbstr    FROM dbo.YXZTLIST WHERE ID=1", "con");
            DataRow dr = ds.Tables[0].Rows[0];
            conSp = dr["Fdbstr"].ToString();
            k3db = new DataBase(conSp);
            commUse.CortrolButtonEnabled(btnSel, this);
            commUse.CortrolButtonEnabled(btnOut, this);
            
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
            try
            {
                dsbb = k3db.GetProcDataSet("sp_yx_Getzydpsmxb", inputParameters);
            }
            catch {
                MessageBox.Show("没有本日数据或计算错误！");
                return;
            
            }
            this.dgvbb.DataSource = dsbb.Tables[0];
            this.dgvbb.Columns["id"].Visible = false;
            this.dgvbb.Columns["FcurID"].Visible = false;
            dgvbb.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dgvbb.ColumnHeadersHeight =120;
            for (int i = 0; i < this.dgvbb.ColumnCount; i++)
            { 
              if (i>5)
              {
                  this.dgvbb.Columns[i].Width =30;
              
              
              }
            
            
            }


        }

        private void btnOut_Click(object sender, EventArgs e)
        {
            if (dsbb.Tables[0].Rows.Count>0)
            {
                commUse.DataGridViewToExcel(dgvbb);
            }
        }
    }
}
