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
    public partial class OperatorForm : Form
    {
        DataBase db = new DataBase();
        CommonUse commUse = new CommonUse();
        
        public OperatorForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 设置文本是否可编辑
        /// </summary>
        private void TxtStatus(int s)
        {
            if (s == 1)
            {
                this.txtName.Enabled = true;
                this.txtNote.Enabled = true;
                this.txtPwd.Enabled = true;
                this.txtRpwd.Enabled = true;
            }
            if (s == -1)
            {
                this.txtName.Enabled =false;
                this.txtNote.Enabled = false;
                this.txtPwd.Enabled = false;
                this.txtRpwd.Enabled = false;
            }
          


        }
        /// <summary>
        /// 设置按钮状态
        /// </summary>
         private void ControlStatus(string status )
         {
             toolStrip1.Tag = status;
             if (status == "SEL")//查询
             {
                 toolSave.Enabled = false;
                 toolCancel.Enabled = false;
                 toolAdd.Enabled = true;
                 toolAmend.Enabled = true;
                 toolDelete.Enabled = true;
                 this.TxtStatus(-1);
             
             }
             if (status == "ADD")//添加
             {
                 toolSave.Enabled = true;
                 toolCancel.Enabled = true;
                 toolAdd.Enabled = false;
                 toolAmend.Enabled = false;
                 toolDelete.Enabled = false;
                 this.TxtStatus(1);

             }
             if (status == "EDIT")//编辑
             {
                 toolSave.Enabled = true;
                 toolCancel.Enabled = true;
                 toolAdd.Enabled = false;
                 toolAmend.Enabled = false;
                 toolDelete.Enabled = false;
                 this.TxtStatus(1);

             }

         
         }
         /// <summary>
         /// 设置参数值
         /// </summary>
         private void ParametersAddValue()
         {

             string isadmin;
             if (chbAdmin.Checked == true)
             { isadmin = "1"; }
             else { isadmin = "0"; }

             db.Cmd.Parameters.Clear();
             db.Cmd.Parameters.AddWithValue("@OperatorName", this.txtName.Text.Trim());
             db.Cmd.Parameters.AddWithValue("@Note", this.txtNote.Text.Trim());
             db.Cmd.Parameters.AddWithValue("@PassWord",this.txtPwd.Text);
             db.Cmd.Parameters.AddWithValue("@IsAdmin", isadmin);
         }

         /// <summary>
         /// 设置控件的显示值
         /// </summary>
         private void FillControls()
         {
            this.txtName.Text = this.dgvSYOperatorInfo["OperatorName", this.dgvSYOperatorInfo.CurrentCell.RowIndex].Value.ToString();
            this.txtNote.Text = this.dgvSYOperatorInfo["Note", this.dgvSYOperatorInfo.CurrentCell.RowIndex].Value.ToString();
            this.txtPwd.Text = this.dgvSYOperatorInfo["PassWord", this.dgvSYOperatorInfo.CurrentCell.RowIndex].Value.ToString();
            this.txtRpwd.Text = this.dgvSYOperatorInfo["PassWord", this.dgvSYOperatorInfo.CurrentCell.RowIndex].Value.ToString();
            if (this.dgvSYOperatorInfo["IsAdmin", this.dgvSYOperatorInfo.CurrentCell.RowIndex].Value.ToString() == "1")
            { this.chbAdmin.Checked = true; }
            else
            { this.chbAdmin.Checked = false; }


         }

         /// <summary>
         /// DataGridView绑定到数据源
         /// </summary>
         /// <param name="strWhere">Where条件子句</param>
         private void BindDataGridView(string strWhere)
         {
             string strSql = null;

             strSql = "SELECT * ";
             strSql += " FROM k3_2Operator" + strWhere; ;

             try
             {
                 this.dgvSYOperatorInfo.DataSource = db.GetDataSet(strSql, "SYOperator").Tables["SYOperator"];
             }
             catch (Exception ex)
             {
                 MessageBox.Show(ex.Message, "软件提示");
                 throw ex;
             }
         }


        private void OperatorForm_Load(object sender, EventArgs e)
        {
            this.ControlStatus("SEL");
            BindDataGridView("");
        }

        private void toolAdd_Click(object sender, EventArgs e)
        {
            this.ControlStatus("ADD");
            this.txtName.Text = "";
            this.txtNote.Text = "";
            this.txtPwd.Text = "";
            this.txtRpwd.Text = "";

        }

        private void toolCancel_Click(object sender, EventArgs e)
        {
            this.ControlStatus("SEL");
        }

        private void toolExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtOK_Click(object sender, EventArgs e)
        {

            string strWhere = String.Empty;
        
            strWhere = " WHERE OperatorName LIKE '%" + txtKeyWord.Text.Trim() + "%'";
                    this.BindDataGridView(strWhere);
         }

        private void toolSave_Click(object sender, EventArgs e)
        {//保存
             string strCode = null;
            SqlDataReader sdr = null;

           

            if (String.IsNullOrEmpty(txtName.Text.Trim()))
            {
                MessageBox.Show("用户 姓名名称不许为空！", "软件提示");
                this.txtName.Focus();
                return;
            }

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

            //添加
            if (toolStrip1.Tag.ToString() == "ADD")
            {
               strCode = "select * from k3_2Operator where OperatorName = '" + this.txtName.Text.Trim() + "'";

                try
                {
                    sdr = db.GetDataReader(strCode);
                    sdr.Read();
                    if (!sdr.HasRows)
                    {
                        sdr.Close();

                        strCode = "INSERT INTO dbo.k3_2Operator( OperatorName ,[PassWord] ,IsAdmin , Note)";
                        strCode += "VALUES(@OperatorName,@PassWord,@IsAdmin,@Note)";

                        ParametersAddValue();

                        if (db.ExecDataBySql(strCode) > 0)
                        {
                            MessageBox.Show("保存成功！", "软件提示");
                            this.BindDataGridView("");
                            ControlStatus("SEL");
                        }
                        else
                        {
                            MessageBox.Show("保存失败！", "软件提示");
                        }
                    }
                    else
                    {
                        MessageBox.Show("姓名重复，请重新设置", "软件提示");
                        this.txtName.Focus();
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

            if (toolStrip1.Tag.ToString() == "EDIT")
            {
                string strOldOperatorName = null; //未修改之前的用户姓名
                string strUserid ="0";
                strOldOperatorName = this.dgvSYOperatorInfo["OperatorName", this.dgvSYOperatorInfo.CurrentCell.RowIndex].Value.ToString();
                strUserid = this.dgvSYOperatorInfo["UserID", this.dgvSYOperatorInfo.CurrentCell.RowIndex].Value.ToString();
                if (strUserid==PropertyClass.OperatorID.ToString())
               {
                   if (strOldOperatorName != this.txtName.Text.Trim())
                   {
                       MessageBox.Show("不允许修改自己的名字！", "软件提示");
                      
                       return;
                   }
                
                }
                
                //用户编码被修改过
                if (strOldOperatorName != this.txtName.Text.Trim())
                {
                    strCode = "select * from k3_2Operator where OperatorName= '" + this.txtName.Text.Trim() + "'";

                    try
                    {
                        sdr = db.GetDataReader(strCode);
                        sdr.Read();
                        if (sdr.HasRows)
                        {
                            MessageBox.Show("用户姓名重复，请重新设置", "软件提示");
                            this.txtName.Focus();
                            sdr.Close();
                            return;
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

                //更新数据库
                try
                {
                    strCode = "UPDATE k3_2Operator SET OperatorName = @OperatorName,PassWord = @PassWord,Note=@Note,IsAdmin=@IsAdmin ";
                    strCode += "WHERE UserID =" + strUserid;

                    ParametersAddValue();

                    if (db.ExecDataBySql(strCode) > 0)
                    {
                        MessageBox.Show("保存成功！", "软件提示");
                        this.BindDataGridView("");
                        ControlStatus("SEL");
                       // txtAgainPassWord.ReadOnly = true;
                       // txtPassWord.ReadOnly = true;
                    }
                    else
                    {
                        MessageBox.Show("保存失败！", "软件提示");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "软件提示");
                    throw ex;
                }
            }





        }

        private void dgvSYOperatorInfo_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (toolStrip1.Tag.ToString() == "EDIT")
            {
                FillControls();
            }
          

        }

        private void toolAmend_Click(object sender, EventArgs e)
        {
            this.ControlStatus("EDIT");
        }

        private void toolreflush_Click(object sender, EventArgs e)
        {
            this.BindDataGridView("");
        }

        private void toolDelete_Click(object sender, EventArgs e)
        {//删除

            string  strUserid = this.dgvSYOperatorInfo["UserID", this.dgvSYOperatorInfo.CurrentCell.RowIndex].Value.ToString ();
            if (strUserid==PropertyClass.OperatorID.ToString ())
            {
                MessageBox.Show("不允许删除自己！", "软件提示");
                return;
            }
            string strSYOperatorSql = null; //表示提交SYOperator表的SQL语句
            string strSYAssignRightSql = null; //表示提交SYAssignRight表的SQL语句
            List<string> strSqls = new List<string>();
            strSYOperatorSql = "DELETE FROM k3_2Operator WHERE UserID = '" + strUserid + "'";
            strSqls.Add(strSYOperatorSql);
            strSYAssignRightSql = "Delete From SYAssignRight Where UserID = '" + strUserid + "'";
            strSqls.Add(strSYAssignRightSql);

            if (MessageBox.Show("确定要删除吗？", "软件提示", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
            {
                try
                {
                    //提交多条SQL语句
                    if (db.ExecDataBySqls(strSqls))
                    {
                        MessageBox.Show("删除成功！", "软件提示");
                    }
                    else
                    {
                        MessageBox.Show("删除失败！", "软件提示");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "软件提示");
                    throw ex;
                }

                this.BindDataGridView("");
            }
            this.ControlStatus("SEL");

        }

     
    }
}
