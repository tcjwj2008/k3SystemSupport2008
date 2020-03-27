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
    public partial class frm_yx_WhiteList : Form
    {
        string type;
        string tablename;
        string  ftype;//按客户2还是部门1
        string ZtRyconstring;
        DataBase db = new DataBase();
       DataBase k3Wdb = null;
       DataBase k3Sdb = null;
       DataBase k3Udb = null;
        DataSet dsSel = null;
        DataSet dsWhile = null;
        CommonUse commUse = new CommonUse();
        public frm_yx_WhiteList(string type)
        {
            InitializeComponent();
            this.type = type;
            if (this.type == "W")
            {
                this.Tag = "96";//设置tag方便同一窗体设置不同权限
                this.Text = "信用白名单";
                this.groupBox2.Text = "信用白名单";
                this.tablename = "yx_WhileList";
            
            }
            if (this.type == "P")
            {
                this.Tag = "97";//设置tag方便同一窗体设置不同权限
                this.Text = "订单单价取向设置";
                this.groupBox2.Text = "单价取自食品账套";
                this.tablename = "yx_priceFromSp";

            }
            if (this.type == "U")
            {
                this.Tag = "98";//设置tag方便同一窗体设置不同权限
                this.Text = "唯一单位(头)设置";
                this.groupBox2.Text = "唯一单位（头）名单";
                this.tablename = "yx_funitTou";

            }
            if (this.type == "K")
            {
                this.Tag = "101";//设置tag方便同一窗体设置不同权限
                this.Text = "订单单价可修改设置";
                this.groupBox2.Text = "订单单价可修改名单";
                this.tablename = "yx_priceUpList";

            }
        }

        private void frm_yx_WhiteList_Load(object sender, EventArgs e)
        {
            commUse.CortrolButtonEnabled(button1, this);
            commUse.CortrolButtonEnabled(button2, this);
            commUse.CortrolButtonEnabled(button3, this);


            DataRow dr =db.GetDataSet("SELECT Fdbstr    FROM dbo.YXZTLIST WHERE ID=2", "con").Tables[0].Rows[0];
            ZtRyconstring = dr["Fdbstr"].ToString();
            k3Wdb = new DataBase(ZtRyconstring);
            k3Sdb = new DataBase(ZtRyconstring);
            k3Udb = new DataBase(ZtRyconstring);
            btnDep.Checked=true;
            ftype = "1";
            if (this.button3.Enabled==true)
            {

                dsWhile = k3Wdb.GetDataSet("SELECT fitemid,fnumber AS 代码,fname AS 名称  FROM " + this.tablename + " WHERE ftype=1 ORDER BY  fnumber ", "while");
          
            this.dgvWhite.DataSource = dsWhile.Tables[0];
            this.dgvWhite.Columns[0].Visible = false;
            }
        }

        private void btnDep_CheckedChanged(object sender, EventArgs e)
        {
            if (btnDep.Checked == true && this.button3.Enabled == true)
            {
                ftype = "1";
                dsWhile = k3Wdb.GetDataSet("SELECT fitemid,fnumber AS 代码,fname AS 名称  FROM " + this.tablename + " WHERE ftype=1 ORDER BY  fnumber ", "while");
                this.dgvWhite.DataSource = dsWhile.Tables[0];
                this.dgvWhite.Columns[0].Visible = false;
                this.txtSel.Text = "";
                this.dgvSel.DataSource = null;
            
            
            }

        }

        private void btnFcu_CheckedChanged(object sender, EventArgs e)
        {
            if (btnFcu.Checked == true && this.button3.Enabled == true)
            {
                ftype = "2";
                dsWhile = k3Wdb.GetDataSet("SELECT fitemid,fnumber AS 代码,fname AS 名称  FROM " + this.tablename + " WHERE ftype=2 ORDER BY  fnumber ", "while");
                this.dgvWhite.DataSource = dsWhile.Tables[0];
                this.dgvWhite.Columns[0].Visible = false;
                this.txtSel.Text = "";
                this.dgvSel.DataSource = null;


            }
        }

        private void txtSel_TextChanged(object sender, EventArgs e)
        {//文本改变时
            string selsql = "";
            if (this.button3.Enabled == true)
            {
                if (ftype == "1")//部门
                {
                    selsql = "SELECT fitemid,fnumber AS 代码,fname AS 名称  FROM dbo.t_Department " +
                             "  WHERE FItemID NOT IN (SELECT fitemid  FROM " + this.tablename + " WHERE ftype=1 )" +
                              " AND fnumber +fname LIKE '%" + txtSel.Text.Trim() + "%'";

                }
                if (ftype == "2")//客户
                {
                    selsql = "SELECT fitemid,fnumber AS 代码,fname AS 名称  FROM dbo.t_Organization " +
                             "  WHERE FItemID NOT IN (SELECT fitemid  FROM " + this.tablename + " WHERE ftype=2 )" +
                              " AND fnumber +fname LIKE '%" + txtSel.Text.Trim() + "%'";

                }

                this.dgvSel.DataSource = k3Sdb.GetDataSet(selsql, "sel").Tables[0];
                this.dgvSel.Columns[0].Visible = false;
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {//移入
            if (this.dgvSel.RowCount > 0)
            {
                //MessageBox.Show(this.dgvSel.CurrentRow.Cells[1].Value.ToString());
                string insertstr = " INSERT INTO " + this.tablename + "( Ftype, Fitemid,Fnumber, Fname,Fusername) VALUES (" + this.ftype
                      + "," + this.dgvSel.CurrentRow.Cells["fitemid"].Value.ToString() + ",'"
                      + this.dgvSel.CurrentRow.Cells[1].Value.ToString() + "','"
                      + this.dgvSel.CurrentRow.Cells[2].Value.ToString() + "','"+
                       PropertyClass.OperatorName + "') ";
                try
                {
                    k3Udb.ExecDataBySql(insertstr);
                    //更新两个dgv
                    afterUpdate();
                }
                catch {
                    MessageBox.Show("移入失败！请联系管理员处理");
                
                }
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //移出
            if (this.dgvWhite.RowCount > 0)
            {
                //MessageBox.Show(this.dgvSel.CurrentRow.Cells[1].Value.ToString());
                string deletestr = " DELETE  " + this.tablename + " WHERE ftype=" + this.ftype + " AND fitemid=" +
                                   this.dgvWhite.CurrentRow.Cells["fitemid"].Value.ToString();
                try
                {
                    k3Udb.ExecDataBySql(deletestr);
                    //更新两个dgv
                    afterUpdate();
                }
                catch
                {
                    MessageBox.Show("移出失败！请联系管理员处理");

                }
            }
        }

        public void afterUpdate()
        { //移入移出后更新两个表
            string selsql = "";
            if (ftype == "1")//部门
            {
                selsql = "SELECT fitemid,fnumber AS 代码,fname AS 名称  FROM dbo.t_Department " +
                         "  WHERE FItemID NOT IN (SELECT fitemid  FROM " + this.tablename + " WHERE ftype=1 )" +
                          " AND fnumber +fname LIKE '%" + txtSel.Text.Trim() + "%'";

            }
            if (ftype == "2")//客户
            {
                selsql = "SELECT fitemid,fnumber AS 代码,fname AS 名称  FROM dbo.t_Organization " +
                         "  WHERE FItemID NOT IN (SELECT fitemid  FROM " + this.tablename + " WHERE ftype=2 )" +
                          " AND fnumber +fname LIKE '%" + txtSel.Text.Trim() + "%'";

            }

            this.dgvSel.DataSource = k3Sdb.GetDataSet(selsql, "sel").Tables[0];
            this.dgvSel.Columns[0].Visible = false;
            dsWhile = k3Wdb.GetDataSet("SELECT fitemid,fnumber AS 代码,fname AS 名称  FROM " + this.tablename + " WHERE ftype=" + this.ftype + " ORDER BY  fnumber ", "while");
            this.dgvWhite.DataSource = dsWhile.Tables[0];
            this.dgvWhite.Columns[0].Visible = false;
              
        
        
        
        
        }

     
    }
}
