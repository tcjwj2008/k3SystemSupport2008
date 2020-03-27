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
    public partial class frmSaleConvert : Form
    {

        public  string k3constr;
				public string DBStr;
        string  ztID;
        CommonUse commUse = new CommonUse();
        DataSet ds = new DataSet();//excel
        DataBase db = new DataBase();
			
				public frmSaleConvert()
        {
            InitializeComponent();       }



				private void frmSaleConvert_Load(object sender, EventArgs e)
        {
					//去除委托
					this.comboBox1.SelectedIndexChanged -= new EventHandler(comboBox1_SelectedIndexChanged);
					//绑定数据
					this.comboBox1.DataSource = db.GetDataTable("  SELECT ID,FName FROM dbo.YXZTLIST WHERE ftype='K3'  ORDER BY Forderid  ", "tab");
					comboBox1.DisplayMember = "FName";//显示内容
					comboBox1.ValueMember = "ID";//选项对应的value

					//添加委托 
					this.comboBox1.SelectedIndexChanged += new EventHandler(comboBox1_SelectedIndexChanged);
					this.comboBox1.DisplayMember = "DisplayColumn";

					//初始为第一个帐套
					ds = db.GetDataSet("SELECT FName,Fdbstr    FROM dbo.YXZTLIST WHERE ID=1", "con");
					DataRow dr = ds.Tables[0].Rows[0];			
					k3constr = dr["Fdbstr"].ToString();
					//DBStr = dr["FDbName"].ToString();
					ztID = this.comboBox1.SelectedValue.ToString();
				

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {//帐套选择后改变标题和链接
					ds = db.GetDataSet("SELECT FName,Fdbstr    FROM dbo.YXZTLIST WHERE ID=" + this.comboBox1.SelectedValue.ToString(), "con");
					DataRow dr = ds.Tables[0].Rows[0];
					//this.label1.Text = dr["FName"].ToString() + "-账套日志管理";
					k3constr = dr["Fdbstr"].ToString();
					//DBStr = dr["FDbName"].ToString();
					ztID = this.comboBox1.SelectedValue.ToString();

        }

        private void btnBak_Click(object sender, EventArgs e)
        {
          






        }



				private void button1_Click_1(object sender, EventArgs e)
				{
						string sqlstr1;
						string sqlstr2;		
						DataBase db2 = new DataBase(k3constr);
			

						int LISTCOUNT = listBox1.Lines.Length;
						for (int i = 0; i <= LISTCOUNT - 1; i++)
						{

								string FGroupID = listBox1.Lines[i].ToString();
								sqlstr1 = @"exec ICSale_fgc  '" + FGroupID + @"'";
							
								try
								{
									db2.ExecDataBySql(sqlstr1);


								}
								catch (Exception ex)
								{
									//WaitFormService.CloseWaitForm();
									MessageBox.Show("反钩稽失败!" + ex.ToString(), "软件提示");
									return;

								}

								WaitFormService.CloseWaitForm();
								MessageBox.Show("反钩稽成功!", "软件提示");


						}


			





				}
		}
}
