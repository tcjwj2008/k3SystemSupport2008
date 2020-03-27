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
    public partial class frmIcitemSet : Form
    {

        DataBase db = new DataBase();
        CommonUse commUse = new CommonUse();
        SqlDataAdapter sda = null;
        DataTable dt = null;
        string SqlStr = "   SELECT  FItemID ,fnumber 产品代码,fname 产品名称,fmodel 规格型号,funitname AS 单位,FSecUnitname	辅助单位,FSecCoefficient 辅助单位换算率" +
                                  " FROM rysp_icitem WHERE fdelete=0  ";
        //
        public frmIcitemSet()
        {
            InitializeComponent();
        }

        private void frmIcitemSet_Load(object sender, EventArgs e)
        {
            //先读取未同步的物料到本数据库
            try
            { db.RunProc("update_rysp_icitem"); }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "软件提示");
                throw ex;
            }
            //
            sda = new SqlDataAdapter(SqlStr + "  ORDER BY FNUMBER ", db.Conn);
            SqlCommandBuilder scb = new SqlCommandBuilder(sda);

            dt = new DataTable();
            sda.Fill(dt);



           // dt = db.GetDataTable(SqlStr+"  ORDER BY FNUMBER ", "t_icitem");
            this.bindingSource1.DataSource= dt;
            this.dataGridView1.DataSource = this.bindingSource1;
            this.dataGridView1.Columns[0].Visible = false;
            this.dataGridView1.Columns[1].ReadOnly = true;
            this.dataGridView1.Columns[2].ReadOnly = true;
            this.dataGridView1.Columns[3].ReadOnly = true;
            this.dataGridView1.Columns[4].ReadOnly = true;
           

        }

        private void dataGridView1_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {//显示序号
            SolidBrush b = new SolidBrush(this.dataGridView1.RowHeadersDefaultCellStyle.ForeColor);
            e.Graphics.DrawString((e.RowIndex + 1).ToString(System.Globalization.CultureInfo.CurrentUICulture), this.dataGridView1.DefaultCellStyle.Font, b, e.RowBounds.Location.X + 20, e.RowBounds.Location.Y + 4);
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            this.dataGridView1.EndEdit(); //当前单元格结束编辑
            this.bindingSource1.EndEdit(); //将挂起的更改应用于基础数据源。

            sda.Update(dt); //根据多态性可知，所有DbDataAdapter的非空子类引用都可以调用“Update(DataTable dataTable)”方法
                               
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {//过滤
            sda = new SqlDataAdapter(SqlStr + "  AND  fnumber+fname LIKE '%"+this.toolStripTextBox1.Text +"%'    ORDER BY FNUMBER ", db.Conn);
            SqlCommandBuilder scb = new SqlCommandBuilder(sda);

            dt = new DataTable();
            sda.Fill(dt);



            // dt = db.GetDataTable(SqlStr+"  ORDER BY FNUMBER ", "t_icitem");
            this.bindingSource1.DataSource = dt;
            this.dataGridView1.DataSource = this.bindingSource1;
            this.dataGridView1.Columns[0].Visible = false;
            this.dataGridView1.Columns[1].ReadOnly = true;
            this.dataGridView1.Columns[2].ReadOnly = true;
            this.dataGridView1.Columns[3].ReadOnly = true;
            this.dataGridView1.Columns[4].ReadOnly = true;




        }
    }
}
