using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using YXK3FZ.ComClass;
using YXK3FZ.DataClass;

namespace YXK3FZ.RP.from
{
    public partial class frmSpZydNew : Form
    {

        DataSet ds = new DataSet();//excel
        DataSet ds2 = new DataSet();//excel
        // DataBase db = new DataBase(PropertyClass.con_yxsp);
        DataBase db = new DataBase();
        CommonUse commUse = new CommonUse();

        public frmSpZydNew()
        {
            InitializeComponent();
        }

           //成本查询
        private void button1_Click(object sender, EventArgs e)
        {           

            if (this.textBox1.Text.Trim() == "" || this.textBox2.Text.Trim() == "")
            {
                MessageBox.Show("请输入年月！");
                return;
            }
            WaitFormService.CreateWaitForm();
            WaitFormService.SetWaitFormCaption("数据正在处理......");
            this.toolStripStatusLabel1.Text = " 正在读取表格数据......";
            SqlParameter param1 = new SqlParameter("@fyear", SqlDbType.VarChar);
            param1.Value = this.textBox1.Text.Trim();
            SqlParameter param2 = new SqlParameter("@fmonth", SqlDbType.VarChar);
            param2.Value = this.textBox2.Text.Trim();

            //创建泛型
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(param1);
            parameters.Add(param2);

            //把泛型中的元素复制到数组中
            SqlParameter[] inputParameters = parameters.ToArray();
            try
            {
                ds = db.GetProcDataSet("sp_sel_monthCB", inputParameters);
                this.dataGridView1.DataSource = ds.Tables[0];

                this.toolStripStatusLabel1.Text = " 读取数据完成.";
                WaitFormService.CloseWaitForm();
            }
            catch (Exception err)
            {
                WaitFormService.CloseWaitForm();
                MessageBox.Show("操作失败！" + err.ToString());
                this.toolStripStatusLabel1.Text = " 读取数据失败.";

            }

        }

           //读取excel
        private void button3_Click(object sender, EventArgs e)
        {           

            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            string excelFileName = "";
            openFileDialog1.FileName = "";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                excelFileName = openFileDialog1.FileName;
                commUse.bind(excelFileName, this.dataGridView1, ds);
            }

        }
        //导入
        private void button2_Click(object sender, EventArgs e)
        {
            

            WaitFormService.CreateWaitForm();
            WaitFormService.SetWaitFormCaption("数据正在处理......");

            this.toolStripStatusLabel1.Text = " 正在读取表格数据......";
            List<string> strSqls = new List<string>();
            if (this.dataGridView1.RowCount == 0)
            {
                return;
            }
            strSqls.Add("  DELETE yx_sp_monthprice_CHECK WHERE FuserName='" + PropertyClass.OperatorName + "'");
            //string str;
            //str = "";

            DataRow dr = null;
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {

                dr = ds.Tables[0].Rows[i];
                strSqls.Add(" INSERT INTO yx_sp_monthprice_CHECK(Fnumber,fyear,fmonth,Fprice,FuserName)   VALUES  ( '" + dr["产品代码"].ToString() + "'," + dr["年份"].ToString() + "," + dr["月份"].ToString() + "," + dr["成本单价"].ToString() + ",'" + PropertyClass.OperatorName + "') ");
                // str = str + " INSERT INTO yx_rs_ysprice_CHECK  VALUES  ( '" + dr["编码"].ToString() + "'," + dr["成本单价"].ToString() + ",'" + dr["日期"].ToString() + "','" + PropertyClass.OperatorName + "') ";



            }





            if (!db.ExecDataBySqls(strSqls))
            {
                this.toolStripStatusLabel1.Text = " 读取表格数据失败!";
                WaitFormService.CloseWaitForm();
                MessageBox.Show("保存失败！", "软件提示");
                return;
            }

            //MessageBox.Show("读取成功！", "软件提示");
            this.toolStripStatusLabel1.Text = " 开始检查数据......";

            SqlParameter param = new SqlParameter("@FuserName", SqlDbType.VarChar);
            param.Value = PropertyClass.OperatorName;
            //创建泛型
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(param);
            //把泛型中的元素复制到数组中
            SqlParameter[] inputParameters = parameters.ToArray();
            //存储过程 
            DataRow drc = null;
            drc = db.GetDataTable("sp_checkToyx_sp_monthprice", inputParameters).Rows[0];
            if (drc["isok"].ToString() == "-1")
            {
                this.toolStripStatusLabel1.Text = " 表格数据检查失败!";
                WaitFormService.CloseWaitForm();
                MessageBox.Show("保存失败:" + drc["msg"].ToString(), "软件提示");
                return;
            }

            this.toolStripStatusLabel1.Text = " 开始写入K3......";

            SqlParameter param2 = new SqlParameter("@FuserName", SqlDbType.VarChar);
            param2.Value = PropertyClass.OperatorName;
            //创建泛型
            List<SqlParameter> parameters2 = new List<SqlParameter>();
            parameters2.Add(param2);
            //把泛型中的元素复制到数组中
            SqlParameter[] inputParameters2 = parameters2.ToArray();
            try
            {
                db.GetProcRow("sp_insertToyx_sp_monthprice", inputParameters2);
                this.toolStripStatusLabel1.Text = " 表格数据导入成功!";
                WaitFormService.CloseWaitForm();
                MessageBox.Show("成功导入K3!", "软件提示");
                this.dataGridView1.DataSource = null;

            }
            catch (Exception ex)
            {
                this.toolStripStatusLabel1.Text = " 表格数据导入失败!";
                WaitFormService.CloseWaitForm();
                MessageBox.Show("导入K3失败!" + ex.ToString(), "软件提示");

            }

        }

        private void button6_Click(object sender, EventArgs e)
        {
            commUse.Excelout(ds);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (this.textBox4.Text.Trim() == "" || this.textBox3.Text.Trim() == "")
            {
                MessageBox.Show("请输入年月！");
                return;
            }


            WaitFormService.CreateWaitForm();
            WaitFormService.SetWaitFormCaption("数据正在处理......");

            // this.toolStripStatusLabel1.Text = " 正在读取表格数据......";

            SqlParameter param1 = new SqlParameter("@fyear", SqlDbType.VarChar);
            param1.Value = this.textBox4.Text.Trim();
            SqlParameter param2 = new SqlParameter("@fmonth", SqlDbType.VarChar);
            param2.Value = this.textBox3.Text.Trim();


            //创建泛型
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(param1);
            parameters.Add(param2);


            //把泛型中的元素复制到数组中
            SqlParameter[] inputParameters = parameters.ToArray();
            try
            {
                ds2 = db.GetProcDataSet("sp_sel_spmdsyb_new", inputParameters);
                this.dataGridView2.DataSource = ds2.Tables[0];

                //this.toolStripStatusLabel1.Text = " 读取数据完成.";
                WaitFormService.CloseWaitForm();
            }
            catch (Exception err)
            {
                WaitFormService.CloseWaitForm();
                MessageBox.Show("操作失败！" + err.ToString());
                // this.toolStripStatusLabel1.Text = " 读取数据失败.";

            }

        }

        private void button5_Click(object sender, EventArgs e)
        {
            commUse.Excelout(ds2);
        }
    }
}
