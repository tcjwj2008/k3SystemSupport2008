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
    public partial class FormAssignRight : Form
    {
        DataBase db = new DataBase();
        CommonUse commUse = new CommonUse();
        SqlDataAdapter sda = null;
        DataTable dt = null;
        
        public FormAssignRight()
        {
            InitializeComponent();
        }

        private void FormAssignRight_Load(object sender, EventArgs e)
        {
            //绑定到数据源

            commUse.BuildTree(tvOperator, imageList1, "用户", "k3_2Operator Where IsAdmin <> '1'", "UserID", "OperatorName");
            commUse.BuildTree2(tvModule, imageList1, "功能模块", "k3_2sysMK", "ID", "FNAME","0");
           // commUse.BindComboBox(dgvINRightInfo.Columns["RightTag"], "RightTag", "RightName", "Select RightTag,RightName From INRight", "INRight");
       
        }

        private void tvModule_AfterSelect(object sender, TreeViewEventArgs e)
        {

            commUse.DataGridViewReset(dgvINRightInfo);//清空DataGridView

            if (tvOperator.SelectedNode != null)
            {
                if (tvOperator.SelectedNode.Tag != null)
                {
                    if (tvModule.SelectedNode != null)
                    {
                        if (tvModule.SelectedNode.Tag != null)
                        {
                            //string strSql = "Select OperatorCode,ModuleTag,RightTag,IsRight From SYAssignRight ";
                            //strSql += "Where OperatorCode = '" + tvOperator.SelectedNode.Tag.ToString() + "' and ModuleTag = '" + tvModule.SelectedNode.Tag.ToString() + "'";
                            string strSql = " SELECT  UserID, Moduleid, RightTag, IsRight "+
                                            " FROM  dbo.SYAssignRight WHERE UserID="+tvOperator.SelectedNode.Tag.ToString()+
                                            " and Moduleid=" + tvModule.SelectedNode.Tag.ToString() ;



                            try
                            {
                                sda = new SqlDataAdapter(strSql, db.Conn);
                                SqlCommandBuilder scb = new SqlCommandBuilder(sda);

                                dt = new DataTable();
                                sda.Fill(dt);
                                bsINRight.DataSource = dt; //BindingSource绑定数据源
                                
                                dgvINRightInfo.DataSource = bsINRight; //DataGridView控件绑定数据源

                               



                                //if (dgvINRightInfo.RowCount == 0)
                                //{
                                //    InsertOperation(tvModule.SelectedNode.Tag.ToString());//插入模块的操作权限
                                //}
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message, "软件提示");
                                throw ex;
                            }
                        }
                    }
                }
            }






        }

        private void tvOperator_AfterSelect(object sender, TreeViewEventArgs e)
        {
            tvModule_AfterSelect(sender, e);
        }

        private void toolSave_Click(object sender, EventArgs e)
        {
            if (tvOperator.SelectedNode != null)
            {
                if (tvOperator.SelectedNode.Tag != null)
                {
                    if (tvModule.SelectedNode != null)
                    {
                        if (tvModule.SelectedNode.Tag != null)
                        {
                            try
                            {
                                dgvINRightInfo.EndEdit(); //当前单元格结束编辑
                                bsINRight.EndEdit(); //将挂起的更改应用于基础数据源。

                                sda.Update(dt); //根据多态性可知，所有DbDataAdapter的非空子类引用都可以调用“Update(DataTable dataTable)”方法
                               //循环表
                                if (dt.Rows.Count == 0)
                                {
                                    return;
                                }
 
                                
                                
                                MessageBox.Show("保存成功！", "软件提示");
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show("保存失败！(" + ex.Message + ")", "软件提示");
                            }
                        }
                    }
                }
            }


        }

        private void toolExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }


       
    }
}
