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
namespace YXK3FZ.RYGYL
{
    public partial class frmSOrderList : Form
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
        string ordertablename = "yx_order";
        string entrytablename = "yx_orderentry";
        string vwname = "vw_yx_order";


				public frmSOrderList(string Zttype)
        {
            InitializeComponent();

					

						dateTimePicker1.Checked = false;
						dateTimePicker2.Checked = false;
						dateTimePicker3.Checked = false;
						dateTimePicker4.Checked = false;


            this.ZtType = Zttype;
            if (this.ZtType == "R")
            {
                this.Tag = "100";
                ds = db.GetDataSet("SELECT Fdbstr    FROM dbo.YXZTLIST WHERE ID=2", "con");
            }
            if (this.ZtType == "S")
            {
                this.Tag = "103";
                ds = db.GetDataSet("SELECT Fdbstr    FROM dbo.YXZTLIST WHERE ID=1", "con");
            }
            if (this.ZtType == "M")
            {
                this.Tag = "105";
                ds = db.GetDataSet("SELECT Fdbstr    FROM dbo.YXZTLIST WHERE ID=1", "con");
              ordertablename = "yx_orderM";
              entrytablename = "yx_orderMentry";
              vwname = "vw_yx_orderM";
            }

            DataRow dr = ds.Tables[0].Rows[0];
            ZtRyconstring = dr["Fdbstr"].ToString();
            ds = null;
            k3db = new DataBase(ZtRyconstring);

        }

        private void frmOrderList_Load(object sender, EventArgs e)
        {//窗体加载
            //权限控制
            commUse.CortrolButtonEnabled(btnSel, this);
            commUse.CortrolButtonEnabled(tsbtnSel, this);
            commUse.CortrolButtonEnabled(tsbtnOut, this);
            commUse.CortrolButtonEnabled(tsbtnEnter, this);
            commUse.CortrolButtonEnabled(tsbtnFenter, this);
            commUse.CortrolButtonEnabled(tsbtnFcheck, this);
            commUse.CortrolButtonEnabled(tsbtnCheck, this);//
            commUse.CortrolButtonEnabled(tsbtnDel, this);

            if (this.ZtType=="M")
            {
                label3.Text = "门店";
                label7.Text = "区域";

                label9.Visible = true;
                this.cbmOrderType.Visible = true;


                label10.Text = "门店负责人";

            }

						string sSQL = string.Empty;
						DataBase DB = new DataBase(this.ZtRyconstring);

						sSQL = "SELECT FID,FName FROM SP_BaseEntry WHERE FUID=1"; //市场
						DataTable dttMarket = DB.GetDataSet(sSQL, "sel").Tables[0];

						DataRow dtr = dttMarket.NewRow();
						dtr["FID"] = 99999;
						dtr["FName"] ="全部";
						dttMarket.Rows.Add(dtr);


						cbmOrderType.DataSource = dttMarket;
						cbmOrderType.ValueMember = "FID";
						cbmOrderType.DisplayMember = "FName";
						cbmOrderType.SelectedIndex = -1;




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
                this.dgvOrderList.DataSource =ds.Tables[0];
            }
            catch (Exception ex)
            {
                
                MessageBox.Show("查询失败!" + ex.ToString(), "软件提示");
                return;
             
            
            }
            for (int i = 0; i < this.dgvOrderList.Columns.Count; i++)
            {
               // this.dgvOrderList.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;//不排序
                if (i < 4)
                {
                    this.dgvOrderList.Columns[i].Visible = false;//前4列不显示
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
        {//查询





            Selstr = "  SELECT  * FROM "+this.vwname+"  WHERE 1=1  ";

						if (dateTimePicker1.Checked == true && dateTimePicker2.Checked == true)
						{
							Selstr += " AND   制单日期 BETWEEN '" + this.dateTimePicker1.Value.ToString("yyyy-MM-dd")
											 + "' AND '" + this.dateTimePicker2.Value.ToString("yyyy-MM-dd") + "'  ";
						}
						else
						{
							if (dateTimePicker1.Checked == true)
							{
								Selstr += " AND   制单日期 >= '" + this.dateTimePicker1.Value.ToString("yyyy-MM-dd") + "' ";
							}
							else if (dateTimePicker2.Checked == true)
							{
								Selstr += " AND   制单日期 <= '" + this.dateTimePicker1.Value.ToString("yyyy-MM-dd") + "' ";
							}
						}			


						if (dateTimePicker3.Checked == true && dateTimePicker4.Checked == true)
						{
							Selstr += " AND   配送日期 BETWEEN '" + this.dateTimePicker3.Value.ToString("yyyy-MM-dd")
											 + "' AND '" + this.dateTimePicker4.Value.ToString("yyyy-MM-dd") + "'  ";
						}
						else
						{
							if (dateTimePicker3.Checked == true)
							{
								Selstr += " AND   配送日期 >= '" + this.dateTimePicker3.Value.ToString("yyyy-MM-dd") + "' ";
							}
							else if (dateTimePicker4.Checked == true)
							{
								Selstr += " AND   配送日期 <= '" + this.dateTimePicker4.Value.ToString("yyyy-MM-dd") + "' ";
							}
						}




            if (cbbStause.SelectedIndex > -1 && cbbStause.SelectedIndex<4)
            {

                Selstr += " and Fstatus= "+cbbStause.SelectedIndex.ToString ();
            }
            if (this.txtFcur.Text.Trim()!= "")
            {
                if (this.ZtType == "M")
                { Selstr += " AND 门店名称+ 门店代码 LIKE '%" + this.txtFcur.Text.Trim() + "%'"; }
                else
                {
                    Selstr += " AND 客户名称+ 客户代码 LIKE '%" + this.txtFcur.Text.Trim() + "%'";
                }
            
            }
            if (this.txtItem.Text.Trim() != "")
            {
                Selstr += " AND 产品名称+ 产品代码 LIKE '%" + this.txtItem.Text.Trim() + "%'";

            }
            if (this.txtFBiller.Text.Trim() != "")
            {
                Selstr += " AND 制单人 LIKE '%" + this.txtFBiller.Text.Trim() + "%'";

            }
            if (this.txtFdep.Text.Trim() != "")
            {


							if (this.ZtType == "M")
							{ Selstr += " AND 区域名称 LIKE '%" + this.txtFdep.Text.Trim() + "%'"; }
							else
							{
								Selstr += " AND 部门名称 LIKE '%" + this.txtFdep.Text.Trim() + "%'";
							}


            }
            if (this.txtFbill.Text.Trim() != "")
            {
                Selstr += " AND 单据编号 LIKE '%" + this.txtFbill.Text.Trim() + "%'";

            }

            if (this.ZtType=="M" && this.cbmOrderType.Text != "")
            {
                Selstr += " AND 订单类型 LIKE '%" + this.cbmOrderType.Text + "%'";

            }
						if (cbmOrderType.SelectedIndex != -1 && cbmOrderType.Text!="全部")
						{
							Selstr += " AND 市场 = '" + cbmOrderType.Text+ "'";
						}

            if (this.txtEmp.Text.Trim() != "")
            {

                if (this.ZtType == "M")
                {
                    Selstr += " AND 门店负责人 LIKE '%" + this.txtEmp.Text.Trim() + "%'";
                }
                else
                {
                    Selstr += " AND 业务员 LIKE '%" + this.txtEmp.Text.Trim() + "%'";
                }



            }


            if (this.ZtType == "M")
            {
                Selstr += " ORDER BY 制单日期,单据编号,门店负责人 ";
            }
            else {
                Selstr += " ORDER BY 制单日期,单据编号,业务员  ";
            
            }

            dgv_addDatabase(); 






        }

        private void tsbtnSel_Click(object sender, EventArgs e)
        {

            if (this.dgvOrderList.Rows.Count <= 0 || this.dgvOrderList.CurrentRow==null)
            {
                return;
            }
            frmSOrder frmOrder = new frmSOrder(this.ZtType,"SEL", this.dgvOrderList["Finterid", this.dgvOrderList.CurrentRow.Index].Value.ToString());
            frmOrder.Show();


        }

        private void btnSuaXin_Click(object sender, EventArgs e)
        {
            if (this.btnSel.Enabled==false)
            {
                return;
            }
            dgv_addDatabase(); 
        }

        private void tsbtnDel_Click(object sender, EventArgs e)
        {//删除
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
                    if (Int32.Parse(this.dgvOrderList["Fstatus", row.Index].Value.ToString()) > 1)
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
                    DataBase upDb = new DataBase(this.ZtRyconstring);
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

        private void tsbtnCheck_Click(object sender, EventArgs e)
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
                    if (Int32.Parse(this.dgvOrderList["Fstatus", row.Index].Value.ToString()) != 1)
                    {
                        MessageBox.Show("部分单据的状态不允许审核！");
                        return;
                    }
                    delSql += this.dgvOrderList["Finterid", row.Index].Value.ToString() + ",";

                }
                delSql = delSql.Substring(0, delSql.Length - 1);
                delSql += ")";
                delSql = " UPDATE " + ordertablename + " SET Fstatus=2,FcheckName='" + PropertyClass.OperatorName + "',Fcheckdate='" +
                               DateTime.Now.ToString("yyyy-MM-dd") + "' WHERE Finterid  in  " + delSql;


                try
                {
                    DataBase upDb = new DataBase(this.ZtRyconstring);
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

        private void tsbtnFcheck_Click(object sender, EventArgs e)
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
                    if (Int32.Parse(this.dgvOrderList["Fstatus", row.Index].Value.ToString()) != 2)
                    {
                        MessageBox.Show("部分单据的状态不允许反审核！");
                        return;
                    }
                    delSql += this.dgvOrderList["Finterid", row.Index].Value.ToString() + ",";

                }
                delSql = delSql.Substring(0, delSql.Length - 1);
                delSql += ")";
                delSql = " UPDATE " + ordertablename + " SET Fstatus=1,FcheckName='',Fcheckdate=null WHERE Finterid  in  " + delSql;


                try
                {
                    DataBase upDb = new DataBase(this.ZtRyconstring);
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
            commUse.Excelout(ds);
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
