using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
//using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using YXK3FZ.DataClass;
using YXK3FZ.ComClass;


namespace YXK3FZ.SO
{
    public partial class frmSelectDataDialog : Form
    {
        string ztcon;//帐套的链接
        DataBase db = new DataBase();
        DataBase K3db = null;
        DataSet ds = null;
        string type;//查询类型 Icitem 物料 emp 职员  --sup 供应商 --Cust 客户
        public string frmName;//调用窗体的名字
        public frmSeorderPlanEdit frmSeorderPlanEdit;//调用窗体1
        public int M_int_CurrentRow;//调用窗体datagridview的行
        

        //不同的查询语句
        string sqlstr;
        string wherestr;
        string strSup = " SELECT FItemID, FNumber 代码,FName 名称,FAddress 地址 FROM dbo.t_Supplier WHERE FDeleted=0    ";
        string strCus = " SELECT FItemID, FNumber 代码,FName 名称,FAddress 地址 FROM dbo.t_Organization WHERE FDeleted=0  ";
        string strEmp = " SELECT FItemID, FNumber 代码,FName 名称,FAddress 地址 FROM dbo.t_Emp WHERE FDeleted=0  ";
        string strIcitem = " SELECT FItemID ,fnumber  代码,FName 名称,fmodel 规格型号,FUnitID FKUnitID,funitname k3单位,FSecUnitname 辅助单位,FSecCoefficient 换算率 FROM dbo.rysp_icitem  where Fdelete=0  ";
        
        public frmSelectDataDialog(string Ftype,string Selstr)
        {
            InitializeComponent();
            this.type = Ftype;
            this.wherestr = Selstr;
            if (this.type == "Icitem") this.Text = "查询--产品";
            if (this.type == "Emp") this.Text = "查询--职员";
            if (this.type == "Sup") this.Text = "查询--供应商";
            if (this.type == "Cus") this.Text = "查询--客户";


        }

        private void frmSelectDataDialog_Load(object sender, EventArgs e)
        {
            //得到肉业链接
            ds = db.GetDataSet("SELECT Fdbstr    FROM dbo.YXZTLIST WHERE ID=2", "con");
            DataRow dr = ds.Tables[0].Rows[0];
            ztcon= dr["Fdbstr"].ToString();
            K3db = new DataBase(ztcon);
            //根据不同的类型调用不同的查询语句
            if (this.type == "Sup")
            {
                sqlstr = strSup;
               
            }
            if (this.type == "Cus")
            {
                sqlstr = strCus;

            }
            if (this.type == "Emp")
            {
                sqlstr = strEmp;

            }
            if (this.type == "Icitem")
            {
                sqlstr = strIcitem;
                K3db = db;

            }
            if (this.wherestr == "")
            {
                ds = K3db.GetDataSet(sqlstr + "  order by fnumber ", "tab");
                this.dataGridView1.DataSource = ds.Tables[0].DefaultView;
                this.dataGridView1.Columns[0].Visible = false;
              if (this.type == "Icitem")
            {//如果是查询产品 单位内码不显示
                this.dataGridView1.Columns[4].Visible = false;
            }

            }
            else
            {
                this.textBox1.Text = this.wherestr;
                this.btnSelect_Click(null,null);
            
            }
           

        }

        private void dataGridView1_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {//显示序号
            SolidBrush b = new SolidBrush(this.dataGridView1.RowHeadersDefaultCellStyle.ForeColor);
            e.Graphics.DrawString((e.RowIndex + 1).ToString(System.Globalization.CultureInfo.CurrentUICulture), this.dataGridView1.DefaultCellStyle.Font, b, e.RowBounds.Location.X + 20, e.RowBounds.Location.Y + 4);

        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {//双击选中时

            if (frmName == "frmSeorderPlanEdit"  && this.type=="Cus")
            {//如果调用该窗体的窗体是销售计划编辑并且查询的是客户
                frmSeorderPlanEdit.FCustID = this.dataGridView1[0, e.RowIndex].Value.ToString();//赋值
                frmSeorderPlanEdit.txtFCustNumber.Text = this.dataGridView1[1, e.RowIndex].Value.ToString();　//代码
                frmSeorderPlanEdit.txtFCustName.Text = this.dataGridView1[2, e.RowIndex].Value.ToString();//name
                frmSeorderPlanEdit.txtFCustAdder.Text = this.dataGridView1[3, e.RowIndex].Value.ToString();　//addeer
                this.Close();
            }
            if (frmName == "frmSeorderPlanEdit" && this.type == "Emp")
            {//如果调用该窗体的窗体是销售计划编辑并且查询的是业务员
                frmSeorderPlanEdit.FEmpID = this.dataGridView1[0, e.RowIndex].Value.ToString();//赋值
                frmSeorderPlanEdit.txtFEmpNumber.Text = this.dataGridView1[2, e.RowIndex].Value.ToString();　//代码
                this.Close();
            }
            if (frmName == "frmSeorderPlanEdit" && this.type == "Icitem")
            {//如果调用该窗体的窗体是销售计划编辑并且查询的是产品
                frmSeorderPlanEdit.dataGridView1["ColumnFitemID", M_int_CurrentRow].Value = this.dataGridView1[0, e.RowIndex].Value.ToString();// finterid
                frmSeorderPlanEdit.dataGridView1["ColumnFitemNnmber", M_int_CurrentRow].Value = this.dataGridView1[1, e.RowIndex].Value.ToString();//fnumber
                frmSeorderPlanEdit.dataGridView1["ColumnFitemName", M_int_CurrentRow].Value = this.dataGridView1[2, e.RowIndex].Value.ToString();//fname
                frmSeorderPlanEdit.dataGridView1["ColumnFmodel", M_int_CurrentRow].Value = this.dataGridView1[3, e.RowIndex].Value.ToString();//fmodel
                frmSeorderPlanEdit.dataGridView1["ColumnFKUnitID", M_int_CurrentRow].Value = this.dataGridView1[4, e.RowIndex].Value.ToString();//FKUnitID
                frmSeorderPlanEdit.dataGridView1["ColumnFKUnitName", M_int_CurrentRow].Value = this.dataGridView1[5, e.RowIndex].Value.ToString();//funitname
                frmSeorderPlanEdit.dataGridView1["ColumnFFUnitName", M_int_CurrentRow].Value = this.dataGridView1[6, e.RowIndex].Value.ToString();//FSecUnitname 
                frmSeorderPlanEdit.dataGridView1["ColumnFSecCoefficient", M_int_CurrentRow].Value = this.dataGridView1[7, e.RowIndex].Value.ToString();//FSecCoefficient
                this.Close();

            
            }






        }

        private void btnSelect_Click(object sender, EventArgs e)
        {

            ds = K3db.GetDataSet(sqlstr + " and fname+fnumber like '%"+this.textBox1.Text+"%' order by fnumber ", "tab");
            this.dataGridView1.DataSource = ds.Tables[0].DefaultView;
            this.dataGridView1.Columns[0].Visible = false;
            if (this.type == "Icitem")
            {//如果是查询产品 单位内码不显示
                this.dataGridView1.Columns[4].Visible = false;
            }


        }
    }
}
