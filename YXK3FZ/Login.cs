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
using YXK3FZ.Properties;
using YXK3FZ.ComClass;

namespace YXK3FZ
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void picQuit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void picReset_Click(object sender, EventArgs e)
        {
            txtCode.Text = "";
            txtPwd.Text = "";
        }

        private void txtCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtPwd.Focus();
            }
        }

        private void txtPwd_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                picLogin_Click(sender, e);
            }
        }

        private void picLogin_Click(object sender, EventArgs e)
        {

             DataBase db = new DataBase();
            SqlDataReader sdr = null;
            
            this.errInfo.Clear();

            if (String.IsNullOrEmpty(this.txtCode.Text.Trim()))
            {
                try
                {
                    this.errInfo.SetError(this.txtCode, "用户编码不能为空！");
                    return;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "软件提示");
                    throw ex;
                }
                finally
                {

                }
            }

            if (String.IsNullOrEmpty(this.txtPwd.Text.Trim()))
            {
                try
                {
                    this.errInfo.SetError(this.txtPwd, "用户密码不能为空！");
                    return;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "软件提示");
                    throw ex;
                }
                finally
                {

                }
            }

            string strSql = "select * from k3_2Operator where  OperatorName= '" + txtCode.Text.Trim() + "'  " +
                            " and PassWord = '" + txtPwd.Text.Trim() + "'";

            try
            {
                sdr = db.GetDataReader(strSql);
                sdr.Read();
                if (sdr.HasRows)
                {
                   // AppMain AppForm = new AppMain();
                    mainForm mainForm = new mainForm();

                    this.Hide();
                   // PropertyClass.UserID = sdr["id"].ToString();
                    PropertyClass.OperatorID = (int)sdr["UserID"];
                    PropertyClass.OperatorName = sdr["OperatorName"].ToString();
                    PropertyClass.PassWord = sdr["PassWord"].ToString();
                    PropertyClass.IsAdmin = sdr["IsAdmin"].ToString();
                    mainForm .Show();
                }
                else
                {
                    MessageBox.Show("用户编码或用户密码不正确！", "软件提示");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "软件提示");
                throw ex;
            }
            finally
            {
                sdr.Close();
            }

        

        }
    }
}
