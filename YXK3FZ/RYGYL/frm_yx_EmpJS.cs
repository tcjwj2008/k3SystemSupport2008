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
   
    public partial class frm_yx_EmpJS : Form
    {
        DataBase db = new DataBase();
        DataBase k3db = null;
        DataSet ds = null;
        DataSet dsDgv = null;
        CommonUse commUse = new CommonUse();
        string Ftye;// SEL ADD EDIT
        int Fyear;
        int  Fmonth;
        string conSp = "";
        
        public frm_yx_EmpJS()
        {
            InitializeComponent();
            ds = db.GetDataSet("SELECT Fdbstr    FROM dbo.YXZTLIST WHERE ID=1", "con");
            DataRow dr = ds.Tables[0].Rows[0];
            conSp = dr["Fdbstr"].ToString();
        }

        private void frm_yx_EmpJS_Load(object sender, EventArgs e)
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
          this.Ftye = "Sel";
          load_stause(this.Ftye);



           
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

            Fyear = this.dateTimePicker1.Value.Year;
            Fmonth = this.dateTimePicker1.Value.Month;
            if (type == "Sel")
            {
                
               
                this.Text = "业务员基数__查看";
                SqlParameter param1 = new SqlParameter("@Fyear", SqlDbType.Int);
                param1.Value = Fyear;
                SqlParameter param2 = new SqlParameter("@Fmonth", SqlDbType.Int);
                param2.Value = Fmonth;


                //创建泛型
                List<SqlParameter> parameters = new List<SqlParameter>();
                parameters.Add(param1);
                parameters.Add(param2);
                //把泛型中的元素复制到数组中
                SqlParameter[] inputParameters = parameters.ToArray();


                dsDgv = k3db.GetProcDataSet("yx_sp_GetEmpJS", inputParameters);
                this.dgvJS.DataSource = dsDgv.Tables[0];

                this.dgvJS.ReadOnly = true;
                this.dgvJS.Columns["Fempid"].Visible =false;
            
            
            }
            if (type == "EDIT")
            {
                this.Text = "业务员基数__编辑";
                this.dgvJS.ReadOnly = false;

                this.dgvJS.Columns["年份"].ReadOnly = true;
                this.dgvJS.Columns["月份"].ReadOnly = true;
                this.dgvJS.Columns["业务员代码"].ReadOnly = true;
                this.dgvJS.Columns["业务员"].ReadOnly = true;
               // this.dgvJS.Columns["基数"].ReadOnly = true;


            }

        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (this.dgvJS.Rows.Count>0)
            {
                this.Ftye = "EDIT";
                this.load_stause(this.Ftye);
            }



        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (this.Ftye!="EDIT")
            {
                return;
            }
            this.dgvJS.EndEdit();
            List<string> Insertsql = new List<string>();

            Fyear = this.dateTimePicker1.Value.Year;
            Fmonth = this.dateTimePicker1.Value.Month;
            Insertsql.Add(" DELETE  yx_empjs WHERE Fyear=" + Fyear.ToString() + " AND fmonth=" + Fmonth.ToString());
            
            for (int i = 0; i < this.dgvJS.Rows.Count; i++)
            {
                string fjsqty = "0";
                if (this.dgvJS["基数", i].Value.ToString().Trim() != "")
                { 
                    fjsqty = this.dgvJS["基数", i].Value.ToString().Trim();
                    try
                    {
                        Convert.ToSingle(fjsqty);
                    }
                    catch
                    {
                        MessageBox.Show("输入非数字！");
                        return;
                    }


                }


                Insertsql.Add(" INSERT INTO  yx_empjs (Fyear,Fmonth,Fempid,Fempname,FjsQty,Fuser,Fdate) VALUES(" + this.dgvJS["年份", i].Value.ToString() + "," +
                                            this.dgvJS["月份", i].Value.ToString() + "," + this.dgvJS["Fempid", i].Value.ToString() + ",'" + this.dgvJS["业务员", i].Value.ToString() +
                                            "'," + fjsqty + ",'" + PropertyClass.OperatorName + "','" + DateTime.Now.ToString() + "')");


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
                this.Ftye = "SEL";
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
