using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;

using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using YXK3FZ.DataClass;
using YXK3FZ.ComClass;
using YXK3FZ.PrintDataGrid;
namespace YXK3FZ.DZPGL
{
    public partial class frmDZPOrderList : Form
    {

        DataBase db = new DataBase();
        DataBase k3db = null;
        DataSet ds = null;
        CommonUse commUse = new CommonUse();
        //SqlDataAdapter sda = null;
      
        string ZtType;//账套类型
        //帐套的链接
        string ZtRyconstring;
        string Selstr;
        string ordertablename = "yx_KJStock";
        string entrytablename = "yx_KJStockEntry";
        string vwname = "vw_YXDZP_order";


        public frmDZPOrderList(string Zttype)
        {
            InitializeComponent();

            this.Tag = "115";

            this.ZtType = Zttype;
        
            k3db = new DataBase(YXK3FZ.DataClass.DataBase.m_Connstr);

        }


       

        private void frmOrderList_Load(object sender, EventArgs e)
        {
            //窗体加载
            //权限控制
            commUse.CortrolButtonEnabled(btnSel, this);  //查询
            commUse.CortrolButtonEnabled(tsbtnSel, this);  //查看           
            commUse.CortrolButtonEnabled(tsbtnCheck, this);// 审核
            commUse.CortrolButtonEnabled(tsbtnFcheck, this); //反审核
            commUse.CortrolButtonEnabled(tsbtnDel, this); //删除

            //commUse.CortrolButtonEnabled(tsbtnOut, this);  //导出  
            //commUse.CortrolButtonEnabled(tsbtnEnter, this); //确认
            //commUse.CortrolButtonEnabled(tsbtnFenter, this); //反确认

            if (this.btnSel.Enabled == true)
            {
                Selstr = "SELECT TOP 100  * FROM "+this.vwname+" ORDER BY Finterid desc ";
                dgv_addDatabase();
            }

            

        }
        public void dgv_addDatabase()
        {
            try
            {
                ds= k3db.GetDataSet(Selstr, "sel");
                this.dgvOrderList.DataSource =ds.Tables[0].DefaultView;
            }
            catch (Exception ex)
            {                
                MessageBox.Show("查询失败!" + ex.ToString(), "软件提示");
                return;
            }

            for (int i = 0; i < this.dgvOrderList.Columns.Count; i++)
            {
                this.dgvOrderList.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;//不排序
                if (i <2)
                {
                    this.dgvOrderList.Columns[i].Visible = false;//前1列不显示
                }
                if (i == 2)
                {
                    this.dgvOrderList.Columns[i].Width = 120; //单据编号
                }
                else if (i == 3 || i == 4)
                {
                    this.dgvOrderList.Columns[i].Width = 70;
                }
                else if (i == 5)
                {
                    this.dgvOrderList.Columns[i].Width = 130;
                }
                else if (i == 6 )
                {
                    this.dgvOrderList.Columns[i].Width = 100;
                }
                else if (i == 7)
                {
                    this.dgvOrderList.Columns[i].Width = 80;
                }
                else if (i > 7 && i < 12)
                {
                    this.dgvOrderList.Columns[i].DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
                }
                else
                {
                    this.dgvOrderList.Columns[i].Width = 80;
                }
            }

          

            this.dgvOrderList.ClipboardCopyMode = DataGridViewClipboardCopyMode.Disable;
            
        
        
        }

        private void dgvOrderList_KeyDown(object sender, KeyEventArgs e)
        {
             if (e.Control && e.KeyCode == Keys.C)
             {
         //向剪切板中写入当前单元格的内容（若为空赋值为空格，否则报错）
                 string cellText = (dgvOrderList.CurrentCell.Value == DBNull.Value ? " " :dgvOrderList.CurrentCell.Value.ToString().Trim());
                  Clipboard.SetText(cellText);
              }
            }

        private void dgvOrderList_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            //显示序号
            SolidBrush b = new SolidBrush(this.dgvOrderList.RowHeadersDefaultCellStyle.ForeColor);
            e.Graphics.DrawString((e.RowIndex + 1).ToString(System.Globalization.CultureInfo.CurrentUICulture), this.dgvOrderList.DefaultCellStyle.Font, b, e.RowBounds.Location.X + 20, e.RowBounds.Location.Y + 4);
        
        }

        private void btnSel_Click(object sender, EventArgs e)
        {
            //查询

            Selstr = "  SELECT  * FROM "+this.vwname+"  WHERE 1=1  ";
            Selstr += " AND   制单日期 BETWEEN '" + this.dateTimePicker1.Value.ToString("yyyy-MM-dd") 
                     + "' AND '" + this.dateTimePicker2.Value.ToString("yyyy-MM-dd") + "'  ";

            if (cbbStause.Text.Length >0) //状态
            {
                if (cbbStause.Text.Trim() != "全部")
                {
                    Selstr += " AND 状态 = '" + cbbStause.Text.Trim() + "'   ";
                }
            }

            if (this.txtFcur.Text.Trim() != "") //客户
            {
                Selstr += " AND 客户名称+ 客户代码 LIKE '%" + this.txtFcur.Text.Trim() + "%'";
            }

            if (this.txtFBiller.Text.Trim() != "")
            {
                Selstr += " AND 制单人 LIKE '%" + this.txtFBiller.Text.Trim() + "%'";
            }

            if (this.txtFbill.Text.Trim() != "")
            {
                Selstr += " AND 单据编号 LIKE '%" + this.txtFbill.Text.Trim() + "%'";
            }

            if (textBox1.Text.Trim() != "")
            {
                Selstr += " AND 车次 LIKE '%" + this.textBox1.Text.Trim() + "%'";
            }

            if (txtFSA.Text.Trim() != "")
            {
                Selstr += " AND 业务员 LIKE '%" + this.txtFSA.Text.Trim() + "%'";
            }

            Selstr += " ORDER BY 制单日期,单据编号  ";
           

            dgv_addDatabase(); 

        }




        private void tsbtnSel_Click(object sender, EventArgs e)  //查看
        {

            if (this.dgvOrderList.Rows.Count <= 0 || this.dgvOrderList.CurrentRow==null)
            {
                return;
            }
           // frmDZPOrder frmOrder = new frmDZPOrder(this.ZtType, "SEL", this.dgvOrderList["FInterID ", this.dgvOrderList.CurrentRow.Index].Value.ToString());
            frmDZPOrder frmOrder = new frmDZPOrder(this.ZtType, "SEL", dgvOrderList.CurrentRow.Cells["FInterID"].Value.ToString());
           
            frmOrder.Show();


        }

        private void btnSuaXin_Click(object sender, EventArgs e) //刷新
        {
            if (this.btnSel.Enabled==false)
            {
                return;
            }
            dgv_addDatabase(); 
        }

        private void tsbtnDel_Click(object sender, EventArgs e) //删除
        {
            if (this.dgvOrderList.SelectedRows.Count == 0)
            {
                MessageBox.Show("没有选中任何行！");
                return;
            }

            if (MessageBox.Show("确定要删除吗？", "软件提示", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {

                string delSql = "(";
                foreach (DataGridViewRow row in this.dgvOrderList.SelectedRows)
                {
                    if (this.dgvOrderList["Fstatus", row.Index].Value.ToString()=="已审核")
                    {
                        MessageBox.Show("部分单据的状态不允许删除！");
                        return;
                    }
                    delSql += this.dgvOrderList["Finterid", row.Index].Value.ToString() + ",";

                }
                delSql = delSql.Substring(0, delSql.Length - 1);
                delSql += ")";
                delSql = " DELETE "+ordertablename+" WHERE FINTERID in  " + delSql;


                try
                {
                    DataBase upDb = new DataBase(YXK3FZ.DataClass.DataBase.m_Connstr);
                    upDb.ExecDataBySql(delSql);
                    MessageBox.Show("删除成功");
                    dgv_addDatabase(); 
                    

                }
                catch (Exception ex)
                {
                    MessageBox.Show("删除失败！原因：" + ex.ToString());
                    return;
                }




            }
        }

        private void tsbtnClose_Click(object sender, EventArgs e)
        {//
            if (MessageBox.Show("确定要退出吗？", "软件提示", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void tsbtnEnter_Click(object sender, EventArgs e)
        {
            if (this.dgvOrderList.SelectedRows.Count == 0)
            {
                MessageBox.Show("没有选中任何行！");
                return;
            }
            if (MessageBox.Show("确定要确认单据吗？", "软件提示", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {

                string delSql = "(";
                foreach (DataGridViewRow row in this.dgvOrderList.SelectedRows)
                {
                    if (Int32.Parse(this.dgvOrderList["Fstatus", row.Index].Value.ToString()) > 0)
                    {
                        MessageBox.Show("部分单据的状态不允许确认！");
                        return;
                    }
                    delSql += this.dgvOrderList["Finterid", row.Index].Value.ToString() + ",";

                }
                delSql = delSql.Substring(0, delSql.Length - 1);
                delSql += ")";
                delSql = "  UPDATE "+ordertablename+" SET Fstatus=1,FConfirmerName='"+PropertyClass.OperatorName+"',FConfirmerdate='" +
                               DateTime.Now.ToString("yyyy-MM-dd") + "' WHERE Finterid in  " + delSql;


                try
                {
                    DataBase upDb = new DataBase(this.ZtRyconstring);
                    upDb.ExecDataBySql(delSql);
                    MessageBox.Show("确认成功");
                    dgv_addDatabase();


                }
                catch (Exception ex)
                {
                    MessageBox.Show("确认失败！原因：" + ex.ToString());
                    return;
                }




            }
        }

        private void tsbtnFenter_Click(object sender, EventArgs e)
        {
            if (this.dgvOrderList.SelectedRows.Count == 0)
            {
                MessageBox.Show("没有选中任何行！");
                return;
            }
            if (MessageBox.Show("确定要反确认单据吗？", "软件提示", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {

                string delSql = "(";
                foreach (DataGridViewRow row in this.dgvOrderList.SelectedRows)
                {
                    if (Int32.Parse(this.dgvOrderList["Fstatus", row.Index].Value.ToString())!=1)
                    {
                        MessageBox.Show("部分单据的状态不允许反确认！");
                        return;
                    }
                    delSql += this.dgvOrderList["Finterid", row.Index].Value.ToString() + ",";

                }
                delSql = delSql.Substring(0, delSql.Length - 1);
                delSql += ")";
                delSql = "  UPDATE " + ordertablename + " SET Fstatus=0,FConfirmerName='',FConfirmerdate=null WHERE Finterid in  " + delSql;


                try
                {
                    DataBase upDb = new DataBase(this.ZtRyconstring);
                    upDb.ExecDataBySql(delSql);
                    MessageBox.Show(" 反确认成功");
                    dgv_addDatabase();


                }
                catch (Exception ex)
                {
                    MessageBox.Show("反确认失败！原因：" + ex.ToString());
                    return;
                }




            }
        }

        private void tsbtnCheck_Click(object sender, EventArgs e) //审核
        {
            if (this.dgvOrderList.SelectedRows.Count == 0)
            {
                MessageBox.Show("没有选中任何行！");
                return;
            }
            if (MessageBox.Show("确定要审核单据吗？", "软件提示", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {

                string delSql = "(";
                foreach (DataGridViewRow row in this.dgvOrderList.SelectedRows)
                {
                    if (this.dgvOrderList["Fstatus", row.Index].Value.ToString()=="已审核")
                    {
                        MessageBox.Show("部分单据的状态不允许审核！");
                        return;
                    }
                    delSql += this.dgvOrderList["Finterid", row.Index].Value.ToString() + ",";

                }
                delSql = delSql.Substring(0, delSql.Length - 1);
                delSql += ")";
                delSql = " UPDATE " + ordertablename + " SET Fstatus='已审核',Fcheckid='" + PropertyClass.OperatorName + "',Fcheckdate='" +
                               DateTime.Now.ToString("yyyy-MM-dd") + "' WHERE Finterid  in  " + delSql;


                try
                {
                    DataBase upDb = new DataBase(YXK3FZ.DataClass.DataBase.m_Connstr);
                    upDb.ExecDataBySql(delSql);
                    MessageBox.Show("审核成功");
                    dgv_addDatabase();


                }
                catch (Exception ex)
                {
                    MessageBox.Show("审核失败！原因：" + ex.ToString());
                    return;
                }




            }



        }

        private void tsbtnFcheck_Click(object sender, EventArgs e) //反审核
        {
            if (this.dgvOrderList.SelectedRows.Count == 0)
            {
                MessageBox.Show("没有选中任何行！");
                return;
            }
            if (MessageBox.Show("确定要反审核单据吗？", "软件提示", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {

                string delSql = "(";
                foreach (DataGridViewRow row in this.dgvOrderList.SelectedRows)
                {
                    if (this.dgvOrderList["Fstatus", row.Index].Value.ToString()=="未审核")
                    {
                        MessageBox.Show("部分单据的状态不允许反审核！");
                        return;
                    }
                    delSql += this.dgvOrderList["Finterid", row.Index].Value.ToString() + ",";

                }
                delSql = delSql.Substring(0, delSql.Length - 1);
                delSql += ")";
                delSql = " UPDATE " + ordertablename + " SET Fstatus='未审核',Fcheckid='',Fcheckdate=null WHERE Finterid  in  " + delSql;


                try
                {
                    DataBase upDb = new DataBase(YXK3FZ.DataClass.DataBase.m_Connstr);
                    upDb.ExecDataBySql(delSql);
                    MessageBox.Show("反审核成功");
                    dgv_addDatabase();


                }
                catch (Exception ex)
                {
                    MessageBox.Show("反审核失败！原因：" + ex.ToString());
                    return;
                }




            }

        }

        private void tsbtnOut_Click(object sender, EventArgs e)
        {
            //commUse.Excelout(ds);
            if(dgvOrderList.Rows.Count >0)
            commUse.DataGridViewToExcel(dgvOrderList);
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {//打印

            PrintDGV.Print_DataGridView(dgvOrderList);

        }

        private void 查看ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.tsbtnSel.Enabled == true)
            {
                tsbtnSel_Click(null, null);

            }
            else
            {
                MessageBox.Show("没有权限！");
            }
        }

        private void 确认ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.tsbtnEnter.Enabled == true)
            {
                tsbtnEnter_Click(null, null);

            }
            else
            {
                MessageBox.Show("没有权限！");
            }
        }

        private void 反确认ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.tsbtnFenter.Enabled == true)
            {
                tsbtnFenter_Click(null, null);

            }
            else
            {
                MessageBox.Show("没有权限！");
            }
        }

        private void 审核ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.tsbtnCheck.Enabled == true)
            {
                tsbtnCheck_Click(null, null);

            }
            else
            {
                MessageBox.Show("没有权限！");
            }
        }

        private void 反审核ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.tsbtnFcheck.Enabled == true)
            {
                tsbtnFcheck_Click(null, null);

            }
            else
            {
                MessageBox.Show("没有权限！");
            }
        }

        private void 删除ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.tsbtnDel.Enabled == true)
            {
                tsbtnDel_Click(null, null);

            }
            else
            {
                MessageBox.Show("没有权限！");
            }
        }

        private void 刷新ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.btnSel.Enabled == false)
            {
                return;
            }
            dgv_addDatabase(); 
        }

        private void dgvOrderList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (this.btnSel.Enabled == true)
            {
                tsbtnSel_Click(null,null);
            }
        }

        private void btnCopy_Click(object sender, EventArgs e)
        {

            //if (this.dgvOrderList.SelectedRows.Count == 0)
            //{
            //    MessageBox.Show("没有选中任何行！");
            //    return;
            //}
            if (MessageBox.Show("确定要复制单据吗？", "软件提示", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                string fid="";
                string delSql = "";
                foreach (DataGridViewRow row in this.dgvOrderList.Rows)
                {
                    if (fid != this.dgvOrderList["Finterid", row.Index].Value.ToString())
                    {
                    fid = this.dgvOrderList["Finterid", row.Index].Value.ToString();
                    delSql += fid + ",";
                    }

                }
                delSql = delSql.Substring(0, delSql.Length - 1);
              
              

             
                    DataBase copyDb = new DataBase(this.ZtRyconstring);
                    SqlParameter param1 = new SqlParameter("@str", SqlDbType.VarChar);
                    param1.Value = delSql;
                    SqlParameter param2 = new SqlParameter("@username", SqlDbType.VarChar);
                    param2.Value =PropertyClass.OperatorName;
                 
                    //创建泛型
                    List<SqlParameter> parameters = new List<SqlParameter>();
                    parameters.Add(param1);
                    parameters.Add(param2);
                
                    //把泛型中的元素复制到数组中
                    SqlParameter[] inputParameters = parameters.ToArray();
                    DataSet dsCopy;
                    try
                    {
                         if (this.ZtType=="M")
                         {
                             dsCopy = copyDb.GetProcDataSet("sp_yx_copyM", inputParameters);
                         }
                         else 
                         {
                            dsCopy = copyDb.GetProcDataSet("sp_yx_copy", inputParameters);
                         }
                        string isok= dsCopy.Tables[0].Rows[0][0].ToString();
                        string  msg= dsCopy.Tables[0].Rows[0][1].ToString();
                        if (isok == "1")
                        {
                            MessageBox.Show("复制单据成功！");
                            dgv_addDatabase();
                        
                        }
                        else
                        {
                            MessageBox.Show(msg);
                            return;
                        
                        }
                    }
                    catch(Exception ex )
                    {
                        MessageBox.Show("复制失败："+ex.ToString());
                        return;
                    }
                    
                    
                 



            }



        }

        private void 复制ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.btnCopy.Enabled == true)
            {
                btnCopy_Click(null, null);
            }
           

        }

     


   

     

     
    


    }
}
