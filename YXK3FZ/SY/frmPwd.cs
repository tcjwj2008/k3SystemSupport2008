using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
//using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using YXK3FZ.ComClass;
using YXK3FZ.DataClass;

namespace YXK3FZ.SY
{
    public partial class frmPwd : Form
    {
        DataBase db = new DataBase();
        int UserID;
        public frmPwd()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (String.IsNullOrEmpty(this.txtPwd.Text))
            {
                MessageBox.Show("密码不许为空！", "软件提示");
                this.txtPwd.Focus();
                return;
            }

            if (String.IsNullOrEmpty(this.txtRpwd.Text))
            {
                MessageBox.Show("确认密码不许为空！", "软件提示");
                this.txtRpwd.Focus();
                return;
            }

            if (this.txtPwd.Text != this.txtRpwd.Text)
            {
                MessageBox.Show("两次输入的密码不相同！", "软件提示");
                this.txtRpwd.Focus();
                return;
            }
            string strCode = null;
           


            strCode = " UPDATE  dbo.k3_2Operator SET [PassWord]='" + string.Format(this.txtPwd.Text) +
                       "'  WHERE  USERID="+this.UserID.ToString();
          

           

            if (db.ExecDataBySql(strCode) > 0)
            {
                MessageBox.Show("修改密码成功！", "软件提示");
                return;
            }
            else
            {
                MessageBox.Show("修改密码失败！", "软件提示");
                return;
            }


        }

        private void frmPwd_Load(object sender, EventArgs e)
        {
            this.txtName.Text = PropertyClass.OperatorName;
            this.UserID = PropertyClass.OperatorID;
        }
    }
}
