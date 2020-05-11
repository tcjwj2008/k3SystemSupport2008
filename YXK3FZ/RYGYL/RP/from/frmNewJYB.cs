using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace YXK3FZ.RYGYL.RP.from
{
    public partial class frmNewJYB : Form
    {
        public frmNewJYB()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            //if (this.button1.Enabled == false)
            //{
            //    MessageBox.Show("没有权限");
            //    return;

            //}
            //string name0 = this.dataGridView1.Columns[e.ColumnIndex].Name;
            ////string name1=this.dataGridView1.Columns[this.dataGridView1.CurrentCell.ColumnIndex].Name;

            //if ((this.dataGridView1.Rows.Count >= 1 && Ftype == 0) && (name0 == "成本"))
            //{

            //    frmRSYJBMX frmRSYJBMX = new frmRSYJBMX();
            //    frmRSYJBMX.fdate = this.dataGridView1[0, e.RowIndex].Value.ToString();
            //    frmRSYJBMX.fdepnum = this.dataGridView1[1, e.RowIndex].Value.ToString();
            //    frmRSYJBMX.Show();
            //}

            ////添加收入的明细核对值

            //if ((this.dataGridView1.Rows.Count >= 1 && Ftype == 0) && (name0 == "收入"))
            //{

            //    //frmStoreAvenue frmStoreAvenue = new frmStoreAvenue();
            //    //frmStoreAvenue.fdate = this.dataGridView1[0, e.RowIndex].Value.ToString();
            //    //frmStoreAvenue.fdepnum = this.dataGridView1[1, e.RowIndex].Value.ToString();
            //    //frmStoreAvenue.Show();
            //}


            ////添加头数 数量的明细核对值

            //if ((this.dataGridView1.Rows.Count >= 1 && Ftype == 0) && (name0 == "头数"))
            //{

            //    //frmStoreTS frmStoreTS = new frmStoreTS();
            //    //frmStoreTS.fdate = this.dataGridView1[0, e.RowIndex].Value.ToString();
            //    //frmStoreTS.fdepnum = this.dataGridView1[1, e.RowIndex].Value.ToString();
            //    //frmStoreTS.Show();
            //}



            ////添加头数 数量的明细核对值

            //if ((this.dataGridView1.Rows.Count >= 1 && Ftype == 0) && (name0 == "数量"))
            //{
            //    //frmStoreWeight frmStoreTS = new frmStoreWeight();
            //    //frmStoreTS.fdate = this.dataGridView1[0, e.RowIndex].Value.ToString();
            //    //frmStoreTS.fdepnum = this.dataGridView1[1, e.RowIndex].Value.ToString();
            //    //frmStoreTS.Show();
            //}
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //splitContainer5Data.Panel1Collapsed = true;
            //if (splitContainer5Data.Panel2Collapsed == true)
            //{
            //    splitContainer5Data.Panel2Collapsed = false;
            //}

            //Ftype = 1;
            //WaitFormService.CreateWaitForm();
            //WaitFormService.SetWaitFormCaption("数据正在处理......");

            ////this.toolStripStatusLabel1.Text = " 正在读取表格数据......";

            //SqlParameter param1 = new SqlParameter("@BegDate", SqlDbType.DateTime);
            //param1.Value = this.dateTimePicker1.Value;
            //SqlParameter param2 = new SqlParameter("@EndDate", SqlDbType.DateTime);
            //param1.Value = this.dateTimePicker1.Value;
            //param2.Value = this.dateTimePicker2.Value;
            ////创建泛型
            //List<SqlParameter> parameters = new List<SqlParameter>();
            //parameters.Add(param1);
            //parameters.Add(param2);
            ////把泛型中的元素复制到数组中
            //SqlParameter[] inputParameters = parameters.ToArray();
            //try
            //{
            //    ds = db.GetProcDataSet("sp_sel_yx_rs_ysprice", inputParameters);
            //    this.dataGridView2Price.DataSource = ds.Tables[0];

            //    //this.toolStripStatusLabel1.Text = " 读取成本数据完成.";
            //    WaitFormService.CloseWaitForm();
            //}
            //catch (Exception err)
            //{
            //    WaitFormService.CloseWaitForm();
            //    MessageBox.Show("操作失败！" + err.ToString());
            //    //this.toolStripStatusLabel1.Text = " 读取成本数据失败.";

            //}

        }
    }
}
