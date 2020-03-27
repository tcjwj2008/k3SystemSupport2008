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
    public partial class frm_YX_ICitemSet : Form
    {
        DataBase  db =new DataBase ();
       // DataBase k3db = null;
        DataSet ds = null;
        CommonUse commUse = new CommonUse();
        string conRY = "";
       string  Fitemid="0";
       string ftype;

        public frm_YX_ICitemSet()
        {
            InitializeComponent();
            ds = db.GetDataSet("SELECT Fdbstr    FROM dbo.YXZTLIST WHERE ID=2", "con");
            DataRow dr = ds.Tables[0].Rows[0];
            conRY = dr["Fdbstr"].ToString();
           // k3db = new DataBase(conRY);




        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            this.ftype = "EDIT";
            this.txtFnumber.ReadOnly = true;
            DataBase k3db = new DataBase(conRY);
            string selsql = "SELECT fitemid, Fnumber 产品代码,fname  产品名称,isnull(Fmodel,'') 规格,FUnitName 单位,FConversion 换算率 FROM  yx_icitem "+
                            "WHERE fnumber+fname LIKE '%"+this.textBox1.Text.Trim()+"%'";

            DataSet dsSel = k3db.GetDataSet(selsql,"Sel");
            this.dataGridView1.DataSource = dsSel.Tables[0];
            this.dataGridView1.Columns[0].Visible = false;
        

        }

  

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridView1_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {//显示序号
            SolidBrush b = new SolidBrush(this.dataGridView1.RowHeadersDefaultCellStyle.ForeColor);
            e.Graphics.DrawString((e.RowIndex + 1).ToString(System.Globalization.CultureInfo.CurrentUICulture), this.dataGridView1.DefaultCellStyle.Font, b, e.RowBounds.Location.X + 20, e.RowBounds.Location.Y + 4);
        

        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
             if (e.RowIndex > -1 && e.ColumnIndex > -1)
            {


                if (this.ftype == "EDIT")
                {
                    Fitemid = this.dataGridView1.CurrentRow.Cells[0].Value.ToString();
                    this.txtFnumber.Text = this.dataGridView1.CurrentRow.Cells[1].Value.ToString();
                    this.txtFname.Text = this.dataGridView1.CurrentRow.Cells[2].Value.ToString();
                    this.txtFmodel.Text = this.dataGridView1.CurrentRow.Cells[3].Value.ToString();
                    this.txtFunitName.Text = this.dataGridView1.CurrentRow.Cells[4].Value.ToString();
                    this.txtFConversion.Text = this.dataGridView1.CurrentRow.Cells[5].Value.ToString();
                }
                if (this.ftype == "ADD")
                {
                    Fitemid = this.dataGridView1.CurrentRow.Cells[0].Value.ToString();
                    this.txtFnumber.Text = this.dataGridView1.CurrentRow.Cells[1].Value.ToString();
                    this.txtFname.Text = this.dataGridView1.CurrentRow.Cells[2].Value.ToString();
                    this.txtFmodel.Text = this.dataGridView1.CurrentRow.Cells[3].Value.ToString();
                    this.txtFunitName.Text ="头";
                    this.txtFConversion.Text ="";

                }
            }
       

        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            this.ftype = "ADD";
            this.textBox1.Text = "";
            Fitemid ="0";
            this.txtFnumber.Text = "";
            this.txtFname.Text = "";
            this.txtFmodel.Text = "";
            this.txtFunitName.Text = "";
            this.txtFConversion.Text = "";
            this.txtFnumber.ReadOnly = false;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
           if (this.Fitemid=="0")
           {
               MessageBox.Show("没有该产品！");
               return;
           
           }
          //  this.txtFConversion.Text.Trim()
           try
           {
               float f = float.Parse(this.txtFConversion.Text.Trim());
           }
           catch
           {
               MessageBox.Show("换算率是非法字符！");
               return;
           }



           string sqlstr="";
            if (this.ftype == "ADD")
            {
                sqlstr = "INSERT INTO dbo.yx_icitem VALUES  (" + this.Fitemid + ",'" + this.txtFnumber.Text.Trim() +
                        "','"+this.txtFname.Text.Trim()+"','"+this.txtFmodel.Text.Trim()+"','头',"+this.txtFConversion.Text.Trim()+")";
            }

            if (this.ftype == "EDIT")
            {
                sqlstr = "UPDATE dbo.yx_icitem SET FConversion=" + this.txtFConversion.Text.Trim() + "  WHERE Fitemid=" + this.Fitemid;
            
            }
            DataBase k3db = new DataBase(conRY);
            try
            {
                k3db.ExecDataBySql(sqlstr);
                MessageBox.Show("保存成功");
                this.ftype = "EDIT";
                btnSelect_Click(this, e);
            }
            catch (Exception Err)
            {
               MessageBox.Show( Err.Message);
               this.ftype = "EDIT";
               return;
            }
         

        }

       



        private void txtFnumber_TextChanged(object sender, EventArgs e)
        {//输入时显示产品

            if ( this.ftype == "ADD")
            {


                DataBase k3db = new DataBase(conRY);
                string selsql = "SELECT fitemid, Fnumber 产品代码,fname  产品名称,fmodel 规格 FROM  t_icitem " +
                                "WHERE  fitemid not in (select  fitemid from yx_icitem) and  fnumber+fname LIKE '%" + this.txtFnumber.Text.Trim() + "%'";

                DataSet dsSel = k3db.GetDataSet(selsql, "Sel");
								this.Fitemid = dsSel.Tables[0].Rows[0][0].ToString();
                this.dataGridView1.DataSource = dsSel.Tables[0];
                this.dataGridView1.Columns[0].Visible = false;
								
            }





        }

        private void frm_YX_ICitemSet_Load(object sender, EventArgs e)
        {
            this.ftype = "EDIT";
            commUse.CortrolButtonEnabled(btnSave, this);
            commUse.CortrolButtonEnabled(btnSelect, this);
            commUse.CortrolButtonEnabled(BtnAdd, this);

        }

     

    }
}
