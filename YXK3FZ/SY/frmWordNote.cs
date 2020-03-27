using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
//using System.Linq;
using System.Text;
using System.Windows.Forms;
using YXK3FZ.ComClass;
using YXK3FZ.DataClass;
namespace YXK3FZ.SY
{
    public partial class frmWordNote : Form
    {

        public  string k3constr;
        string  ztID;
        //string fzconstr;
        CommonUse commUse = new CommonUse();
        DataSet ds = new DataSet();//excel
        DataBase db = new DataBase();

        
        public frmWordNote()
        {
            InitializeComponent();
        }

    

        private void frmWordNote_Load(object sender, EventArgs e)
        {


					commUse.CortrolButtonEnabled(btnBak, this);
					commUse.CortrolButtonEnabled(button1, this);


            //去除委托
            this.comboBox1.SelectedIndexChanged -= new EventHandler(comboBox1_SelectedIndexChanged);  
           //绑定数据
            this.comboBox1.DataSource =db.GetDataTable("  SELECT ID,FName FROM dbo.YXZTLIST WHERE ftype='K3'  ORDER BY Forderid  ", "tab");
            comboBox1.DisplayMember = "FName";//显示内容
            comboBox1.ValueMember = "ID";//选项对应的value

            //添加委托 
            this.comboBox1.SelectedIndexChanged += new EventHandler(comboBox1_SelectedIndexChanged);
            this.comboBox1.DisplayMember = "DisplayColumn";

            //初始为第一个帐套
            ds = db.GetDataSet("SELECT FName,Fdbstr    FROM dbo.YXZTLIST WHERE ID=1" , "con");
            DataRow dr = ds.Tables[0].Rows[0];
            this.label1.Text = dr["FName"].ToString() + "-账套日志管理";
            k3constr = dr["Fdbstr"].ToString();
            ztID = this.comboBox1.SelectedValue.ToString();

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {//帐套选择后改变标题和链接
            ds = db.GetDataSet("SELECT FName,Fdbstr    FROM dbo.YXZTLIST WHERE ID=" + this.comboBox1.SelectedValue.ToString(), "con");
            DataRow dr = ds.Tables[0].Rows[0];
            this.label1.Text = dr["FName"].ToString() + "-账套日志管理";
            k3constr = dr["Fdbstr"].ToString();
            ztID = this.comboBox1.SelectedValue.ToString();


        }

        private void btnBak_Click(object sender, EventArgs e)
        {
          
                DataBase db2 = new DataBase(k3constr);
                string sqlstr1;
                string sqlstr2;

                sqlstr1 = "  INSERT INTO YXERP.dbo.k3_Log   SELECT " + ztID + ", t1.FLogID,t1.FDate,u.FName  username,t2.FFunctionName ,t1.FStatement," +
                            " t1.FDescription ,FMachineName ,FIPAddress  FROM t_Log T1 INNER JOIN t_LogFunction t2  ON t1.FFunctionID = t2.FFunctionID "+
                             " LEFT  JOIN t_User u ON t1.FUserID = U.FUserID   ";
                sqlstr2="  DELETE t_Log    ";
                WaitFormService.CreateWaitForm();
                WaitFormService.SetWaitFormCaption(" 正在备份，请稍候......"); 
              try
                {
                    db2.ExecDataBySql(sqlstr1);

                    db2.ExecDataBySql(sqlstr2);
                
                }
              catch (Exception ex)
              {
                  WaitFormService.CloseWaitForm();
                  MessageBox.Show("备份失败!" + ex.ToString(), "软件提示");
                  return;

              }

              WaitFormService.CloseWaitForm();
              MessageBox.Show("备份成功!", "软件提示");





        }

        private void button1_Click(object sender, EventArgs e)
        {

            string sqlstr;
            sqlstr = "  SELECT fdate AS 时间,FUsername 操作人,FFunctionName 模块,FDescription 操作,FMachineName 机器名,FIPAddress 地址 FROM  k3_Log "+
                    " WHERE ztid=" + ztID + "  AND fdate BETWEEN '" + this.dateTimePicker1.Value.ToShortDateString() + "  00:00:00' AND '" + this.dateTimePicker2.Value.ToShortDateString() + " 23:59:59' " +
                   " AND FUsername LIKE '%" + this.textBox1.Text + "%' AND FFunctionName LIKE '%" + this.textBox2.Text + "%' AND FDescription LIKE '%" + this.textBox3.Text + "%'        ";

            ds = db.GetDataSet(sqlstr,"sel");
            this.dataGridView1.DataSource=ds.Tables[0];


        }
    }
}
