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

namespace YXK3FZ.RYGYL
{
    public partial class frm_yx_mdfpts : Form
    {
        DataBase db = new DataBase();
        DataBase k3db = null;
        DataSet ds = null;
        DataSet dsDgv = null;
        CommonUse commUse = new CommonUse();
        string Ftye;// SEL ADD EDIT
        string fdate;
        string conSp = "";
        
        public frm_yx_mdfpts()
        {
            InitializeComponent();
            ds = db.GetDataSet("SELECT Fdbstr    FROM dbo.YXZTLIST WHERE ID=1", "con");
            DataRow dr = ds.Tables[0].Rows[0];
            conSp = dr["Fdbstr"].ToString();

        }

        private void frm_yx_mdfpts_Load(object sender, EventArgs e)
        {

            commUse.CortrolButtonEnabled(btnSave, this);
            commUse.CortrolButtonEnabled(btnSel, this);
            commUse.CortrolButtonEnabled(btnEdit, this);
            k3db = new DataBase(conSp);

            if (this.btnSel.Enabled == true)
            {
                btnSel_Click(null, null);
            }
        }

        private void btnSel_Click(object sender, EventArgs e)
        {
            this.fdate = dateTimePicker1.Value.ToString("yyyy-MM-dd");
            this.Ftye = "Sel";
            this.load_stause(this.Ftye);

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            if (this.btnSel.Enabled == true)
            {
                btnSel_Click(null, null);
            }
        }

        public void load_stause(string type)
        {
            if (type == "Sel")
            {
                this.Text = "门店头数分配__查看";
                SqlParameter param1 = new SqlParameter("@Fdate", SqlDbType.VarChar);
                param1.Value = this.fdate;
                SqlParameter param2 = new SqlParameter("@Fher", SqlDbType.VarChar);
                param2.Value =this.txtFhzr.Text.Trim();
                SqlParameter param3 = new SqlParameter("@Fname", SqlDbType.VarChar);
                param3.Value =this.txtFname.Text.Trim();


                //创建泛型
                List<SqlParameter> parameters = new List<SqlParameter>();
                parameters.Add(param1);
                parameters.Add(param2);
                parameters.Add(param3);
                //把泛型中的元素复制到数组中
                SqlParameter[] inputParameters = parameters.ToArray();


                dsDgv = k3db.GetProcDataSet("yx_sp_Getmdfpts", inputParameters);
                this.dgvMft.DataSource = dsDgv.Tables[0];

                this.dgvMft.ReadOnly = true;
                this.dgvMft.Columns["Fmdid"].Visible = false;


            }
            if (type == "EDIT")
            {
                this.Text = "门店头数分配__编辑";
                this.dgvMft.ReadOnly = false;

                this.dgvMft.Columns["日期"].ReadOnly = true;
                this.dgvMft.Columns["门店代码"].ReadOnly = true;
                this.dgvMft.Columns["门店名称"].ReadOnly = true;
                this.dgvMft.Columns["门店负责人"].ReadOnly = true;


            }

        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (this.dgvMft.Rows.Count > 0)
            {
                this.Ftye = "EDIT";
                this.load_stause(this.Ftye);
            }

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (this.Ftye != "EDIT")
            {
                return;
            }
            this.dgvMft.EndEdit();
            this.fdate = dateTimePicker1.Value.ToString("yyyy-MM-dd");
            List<string> Insertsql = new List<string>();

            Insertsql.Add(" DELETE  yx_mdfpts WHERE fdate='" + this.fdate + "'");

            for (int i = 0; i < this.dgvMft.Rows.Count; i++)
            {
                string ffpqty = "0";
                if (this.dgvMft["分配头数", i].Value.ToString().Trim() != "")
                {
                    ffpqty = this.dgvMft["分配头数", i].Value.ToString().Trim();
                    try
                    {
                        Convert.ToSingle(ffpqty);
                    }
                    catch
                    {
                        MessageBox.Show("输入非数字！");
                        return;
                    }


                }
                Insertsql.Add("  INSERT INTO yx_mdfpts(Fdate,Fmdid,Fmdname,FfpQty,Fuser,Fbilldate) VALUES('" + this.fdate +
                           "'," + this.dgvMft["Fmdid", i].Value.ToString() + ",'" + this.dgvMft["门店名称", i].Value.ToString() +
                           "'," + this.dgvMft["分配头数", i].Value.ToString() + ",'" + PropertyClass.OperatorName + "','" + DateTime.Now.ToString() + "') ");

           }

            try
            {
                bool ok = k3db.ExecDataBySqls(Insertsql);
                if (ok == false)
                {
                    MessageBox.Show("保存失败！");
                    return;
                }
                MessageBox.Show("保存成功！");
                this.Ftye = "Sel";
                this.load_stause(this.Ftye);


            }
            catch
            {
                MessageBox.Show("保存失败！");
                return;
            }
           






        }




    }
}
