using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using YXK3FZ.DataClass;
using YXK3FZ.ComClass;

namespace YXK3FZ.RYGL
{
    public partial class frmRYGLMonthBase : Form
    {
			  //ERP数据库
        DataBase db = new DataBase();       
        DataSet ds = null;
			  //k3肉业数据库
        DataBase k3db = null;
			  //权限类
        CommonUse commUse = new CommonUse();
        string ZtRyconstring = string.Empty;        
        string fnamenum = "";
        int FEditID = 0; //修改时的编号
        string MasterState = "SEL";


          public frmRYGLMonthBase()
          {
              InitializeComponent();
              ds = db.GetDataSet("SELECT Fdbstr  FROM dbo.YXZTLIST WHERE ID=2", "con");
              DataRow dr = ds.Tables[0].Rows[0];
              ZtRyconstring = dr["Fdbstr"].ToString(); //获取K3账套连接字符串
              k3db = new DataBase(ZtRyconstring);
          }

          //窗体加载
          private void frmOrder_Load(object sender, EventArgs e)
          { 
              //权限控制 
              commUse.CortrolButtonEnabled(btnADD, this);
              commUse.CortrolButtonEnabled(tsbtnEdit, this);
              commUse.CortrolButtonEnabled(btnSave, this);
              commUse.CortrolButtonEnabled(btnOK, this);
              commUse.CortrolButtonEnabled(btnCancel, this);
              string sSQL = string.Empty;          

              if (btnOK.Enabled == true)
              {
                  getDate(string.Empty, string.Empty);
              }
              else
              {
                  btnCancel.Enabled = false;
              }
              SetTextBoxState(MasterState);
              dateTimePicker2.Checked = false;             

          }

        //加载列表数据
       private void getDate(string Q,string sSQLWH)
          {              
              string sSQL = string.Empty;
              sSQL = "  SELECT E.* FROM AIS_YXRY2.dbo.t_CustDate_PerMonth e ";              
              sSQL += " Where 1=1 ";
              if (Q != string.Empty) //如果是查询
              {
                  sSQL += sSQLWH;
              }                              
              bdsMaster.DataSource = k3db.GetDataSet(sSQL, "sel").Tables[0].DefaultView;
          }


			 //显示序号
        private void dgvDetail_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e) 
        {            
            SolidBrush b = new SolidBrush(this.dgvDetail.RowHeadersDefaultCellStyle.ForeColor);
            e.Graphics.DrawString((e.RowIndex + 1).ToString(System.Globalization.CultureInfo.CurrentUICulture), this.dgvDetail.DefaultCellStyle.Font, b, e.RowBounds.Location.X + 20, e.RowBounds.Location.Y + 4);

        }

        //新增每月系数源码
        private void btnADD_Click(object sender, EventArgs e)
        {

            if (MasterState == "ADD")
            {
                MessageBox.Show("当前是新增状态，无法新增");
                return;
            }
            if (MasterState == "EDIT")
            {
                MessageBox.Show("当前是修改状态，无法新增");
                return;
            }
            MasterState = "ADD";
					  //修改控件状态值
            SetTextBoxState(MasterState);
            txtFPurchaseAmount.Text = string.Empty;
            txtFWorkerAmount.Text = string.Empty;
            txtFProduceAmount.Text = string.Empty;
            txtFWorkerAmount2.Text = string.Empty;
            txtFProduceAmount2.Text = string.Empty;
            txtFCartonAmount.Text = string.Empty;
            txtFWeaveAmount.Text = string.Empty;
					  //增加气调系数20190805
						this.txtMapAccount1.Text = string.Empty;
						this.txtMapAccount2.Text = string.Empty;
            txtFPurchaseAmount.Focus();
            
        }

       //修改单据
        private void tsbtnEdit_Click(object sender, EventArgs e)
        {
					  //未选中任何单据，返回
            if (bdsMaster.Current == null)
                return;

            if (MasterState == "ADD")
            {
                MessageBox.Show("当前是新增状态，无法修改");
                return;
            }
            if (MasterState == "EDIT")
            {
                MessageBox.Show("当前是修改状态，无法修改");
                return;
            }

            int FID = Convert.ToInt32(((DataRowView)bdsMaster.Current).Row["FID"]);
            FEditID = FID;
            SetFieldValue(FID);
            MasterState = "EDIT";
            SetTextBoxState(MasterState);
            txtFPurchaseAmount.Focus();
            dateTimePicker1.Enabled = false;

        }

        //保存
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (MasterState == "SEL") //
            {
                MessageBox.Show("查看状态，无法保存");
                return;
            }

            //必填判断
         
            if (txtFPurchaseAmount.Text == string.Empty)
            {
                MessageBox.Show("物资采购金额不能为空");
                txtFPurchaseAmount.Focus();
                return;
            }
            if (txtFWorkerAmount.Text == string.Empty)
            {
                MessageBox.Show("屠宰直接人工金额不能为空");
                txtFWorkerAmount.Focus();
                return;
            }
            if (txtFProduceAmount.Text == string.Empty)
            {
                MessageBox.Show("屠宰制造费用金额不能为空");
                txtFProduceAmount.Focus();
                return;
            }

            if (txtFWorkerAmount2.Text == string.Empty)
            {
                MessageBox.Show("分割直接人工金额不能为空");
                txtFWorkerAmount2.Focus();
                return;
            }
            if (txtFProduceAmount2.Text == string.Empty)
            {
                MessageBox.Show("分割制造费用金额不能为空");
                txtFProduceAmount2.Focus();
                return;
            }

            if (txtFCartonAmount.Text == string.Empty)
            {
							MessageBox.Show("屠宰包装金额不能为空");
                txtFCartonAmount.Focus();
                return;
            }
            if (txtFWeaveAmount.Text == string.Empty)
            {
							MessageBox.Show("分割包装金额不能为空");
                txtFWeaveAmount.Focus();
                return;
            }
					  //气调不能为空
						if (this.txtMapAccount1.Text == string.Empty)
						{
							MessageBox.Show("屠宰气调金额不能为空");
							txtMapAccount1.Focus();
							return;
						}
						if (this.txtMapAccount2.Text == string.Empty)
						{
							MessageBox.Show("分割气调金额不能为空");
							txtMapAccount2.Focus();
							return;
						}


            //查重
            string sSQL = string.Empty;
            if (MasterState == "ADD")
            {
                sSQL = " SELECT count(*) from AIS_YXRY2.dbo.t_CustDate_PerMonth where FDate=@FDate   ";
                SqlParameter[] par = new SqlParameter[] 
                 {
                    new SqlParameter("@FDate", dateTimePicker1.Text.Trim())
                    
                 };
                if (SqlHelper.Exists(ZtRyconstring, sSQL, par))
                {
                    MessageBox.Show("存在相同的年月份，无法保存");
                    return;
                }
            }
            else if (MasterState == "EDIT")
            {
                int FID = Convert.ToInt32(((DataRowView)bdsMaster.Current).Row["FID"]);
            }

            if (MasterState == "ADD")
            {
							sSQL = " insert into AIS_YXRY2.dbo.t_CustDate_PerMonth(FDate,FPurchaseAmount,FWorkerAmount,FProduceAmount,FWorkerAmount2,FProduceAmount2,FCartonAmount,FWeaveAmount,txtMapAccount1,txtMapAccount2 ) values (@FDate,@FPurchaseAmount,@FWorkerAmount,@FProduceAmount,@FWorkerAmount2,@FProduceAmount2,@FCartonAmount,@FWeaveAmount,@txtMapAccount1,@txtMapAccount2) ";
                SqlParameter[] par = new SqlParameter[] 
                {
                  new SqlParameter("@FDate",dateTimePicker1.Text.Trim()),
                  new SqlParameter("@FPurchaseAmount", txtFPurchaseAmount.Text.Trim()),   
                  new SqlParameter("@FWorkerAmount",txtFWorkerAmount.Text.Trim()),
                  new SqlParameter("@FProduceAmount", txtFProduceAmount.Text.Trim()),  
                  new SqlParameter("@FWorkerAmount2",txtFWorkerAmount2.Text.Trim()),
                  new SqlParameter("@FProduceAmount2",txtFProduceAmount2.Text.Trim()),  
                  new SqlParameter("@FCartonAmount",txtFCartonAmount.Text.Trim()),
                  new SqlParameter("@FWeaveAmount", txtFWeaveAmount.Text.Trim()) ,
									new SqlParameter("@txtMapAccount1",this.txtMapAccount1.Text.Trim()),
									new SqlParameter("@txtMapAccount2",this.txtMapAccount2.Text.Trim())                  
                 };

                if (SqlHelper.ExecuteNonQuery(ZtRyconstring, sSQL, par) > 0)
                {
                    MasterState = "SEL";
                    SetTextBoxState(MasterState);
                    getDate(string.Empty, string.Empty);                    
                }

            }
            else if (MasterState == "EDIT")
            {
							sSQL = " update AIS_YXRY2.dbo.t_CustDate_PerMonth set FDate= @FDate,FPurchaseAmount=@FPurchaseAmount,FWorkerAmount=@FWorkerAmount,FProduceAmount=@FProduceAmount,FWorkerAmount2=@FWorkerAmount2,FProduceAmount2=@FProduceAmount2,FCartonAmount=@FCartonAmount,FWeaveAmount=@FWeaveAmount,txtMapAccount1=@txtMapAccount1,txtMapAccount2=@txtMapAccount2 where FID=@FID";
                SqlParameter[] par = new SqlParameter[] 
                {
                  new SqlParameter("@FID", FEditID),
                  new SqlParameter("@FDate",dateTimePicker1.Text.Trim()),
                  new SqlParameter("@FPurchaseAmount", txtFPurchaseAmount.Text.Trim()),   
                  new SqlParameter("@FWorkerAmount",txtFWorkerAmount.Text.Trim()),
                  new SqlParameter("@FProduceAmount", txtFProduceAmount.Text.Trim()),  
                  new SqlParameter("@FWorkerAmount2",txtFWorkerAmount2.Text.Trim()),
                  new SqlParameter("@FProduceAmount2",txtFProduceAmount2.Text.Trim()),  
                  new SqlParameter("@FCartonAmount",txtFCartonAmount.Text.Trim()),
                  new SqlParameter("@FWeaveAmount", txtFWeaveAmount.Text.Trim()) ,
									new SqlParameter("@txtMapAccount1",this.txtMapAccount1.Text.Trim()),
									new SqlParameter("@txtMapAccount2",this.txtMapAccount2.Text.Trim())
                   
                 };
                if (SqlHelper.ExecuteNonQuery(ZtRyconstring, sSQL, par) > 0)
                {
                    MasterState = "SEL";
                    SetTextBoxState(MasterState);
                    getDate(string.Empty, string.Empty);

                    int index = bdsMaster.Find("FID", FEditID);
                    if (index != -1)
                    {
                        bdsMaster.Position = index;//定位BindingSource
                    }
                   
                }
					
            }				

        }

        //删除
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (bdsMaster.Current == null)
                return;

            if (MessageBox.Show("确定要删除当前数据？", "软件提示", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                int FID = Convert.ToInt32(((DataRowView)bdsMaster.Current).Row["FID"]);
                string sSQL = string.Empty;
                sSQL = "DELETE from AIS_YXRY2.dbo.t_CustDate_PerMonth where  FID=@FID  ";

                SqlParameter[] par = new SqlParameter[] 
                {                 
                  new SqlParameter("@FID", FID)
                 };

                if (SqlHelper.ExecuteNonQuery(ZtRyconstring, sSQL, par) > 0)
                {
                    getDate(string.Empty, string.Empty);
                }
            }

        }

        //退出
        private void btnClose_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("确定要退出吗？", "软件提示", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void btnOK_Click(object sender, EventArgs e) //查询
        {
            string sSQLWH = string.Empty;

            if (dateTimePicker2.Checked == true)
            {
                sSQLWH += " and e.FDate = '" + dateTimePicker2.Text.Trim() + "'";
            }           

            getDate("Q", sSQLWH);
        }

        private void btnCancel_Click(object sender, EventArgs e) //取消
        {
            getDate(string.Empty, string.Empty);

            dateTimePicker2.Checked = false;
        }

        private void bdsMaster_CurrentChanged(object sender, EventArgs e)
        {
            if (bdsMaster.Current == null)
                return;

            int FID = Convert.ToInt32(((DataRowView)bdsMaster.Current).Row["FID"]);
            MasterState = "SEL";
            SetTextBoxState(MasterState);
            SetFieldValue(FID);
          
        }
			  //增加气调的值显示20190805
        private void SetFieldValue(int FID)
        {
            string sSQL = string.Empty;
            sSQL = " SELECT E.* FROM AIS_YXRY2.dbo.t_CustDate_PerMonth e ";           
            sSQL += " Where e.FID=@FID ";
            SqlParameter[] par = new SqlParameter[] {
             new SqlParameter("@FID", FID)
          };

            DataTable dttSQL = SqlHelper.ExecuteDataTable(ZtRyconstring, sSQL, par);

         if (dttSQL.Rows.Count > 0)
         {
             dateTimePicker1.Text = dttSQL.Rows[0]["FDate"].ToString();
             txtFPurchaseAmount.Text = dttSQL.Rows[0]["FPurchaseAmount"].ToString();
             txtFWorkerAmount.Text = dttSQL.Rows[0]["FWorkerAmount"].ToString();
             txtFProduceAmount.Text = dttSQL.Rows[0]["FProduceAmount"].ToString();
             txtFWorkerAmount2.Text = dttSQL.Rows[0]["FWorkerAmount2"].ToString();
             txtFProduceAmount2.Text = dttSQL.Rows[0]["FProduceAmount2"].ToString();
             txtFCartonAmount.Text = dttSQL.Rows[0]["FCartonAmount"].ToString();
             txtFWeaveAmount.Text = dttSQL.Rows[0]["FWeaveAmount"].ToString();
					   //增加气调显示
						 this.txtMapAccount1.Text = dttSQL.Rows[0]["txtMapAccount1"].ToString();
						 this.txtMapAccount2.Text = dttSQL.Rows[0]["txtMapAccount2"].ToString();
         }
         else
         { 
             txtFPurchaseAmount.Text = string.Empty;
             txtFWorkerAmount.Text = string.Empty;
             txtFProduceAmount.Text = string.Empty;
             txtFWorkerAmount2.Text = string.Empty;
             txtFProduceAmount2.Text = string.Empty;
             txtFCartonAmount.Text = string.Empty;
             txtFWeaveAmount.Text = string.Empty;
					   //增加气调显示
						 this.txtMapAccount1.Text = string.Empty;
						 this.txtMapAccount2.Text = string.Empty;
         }

        }

        private void SetTextBoxState(string sMasterState)
        {
           // string MasterState = "SEL";//类型 判断窗体是新增还是编辑状态 ADD EDIT SEL
            if (sMasterState == "SEL")
            {
                dateTimePicker1.Enabled = false;
                txtFPurchaseAmount.ReadOnly = true;
                txtFWorkerAmount.ReadOnly = true;
                txtFProduceAmount.ReadOnly = true;
                txtFWorkerAmount2.ReadOnly = true;
                txtFProduceAmount2.ReadOnly = true;
                txtFCartonAmount.ReadOnly = true;
                txtFWeaveAmount.ReadOnly = true;
							  //增气调状态
								this.txtMapAccount1.ReadOnly = true;
								this.txtMapAccount2.ReadOnly = true;
            }
            else
            {
                dateTimePicker1.Enabled = true;
                txtFPurchaseAmount.ReadOnly = false;
                txtFWorkerAmount.ReadOnly = false;
                txtFProduceAmount.ReadOnly = false;
                txtFWorkerAmount2.ReadOnly = false;
                txtFProduceAmount2.ReadOnly = false;
                txtFCartonAmount.ReadOnly = false;
                txtFWeaveAmount.ReadOnly = false;
								//增气调状态
								this.txtMapAccount1.ReadOnly = false;
								this.txtMapAccount2.ReadOnly = false;
            }
        }
        
        private void txt_KeyPress(object sender, KeyPressEventArgs e)
        {
            //判断按键是不是要输入的类型。
            if (((int)e.KeyChar < 48 || (int)e.KeyChar > 57) && (int)e.KeyChar != 8 && (int)e.KeyChar != 46)
                e.Handled = true;

            // int len = ((TextBox)sender).Text.Length;

            //小数点的处理。
            if ((int)e.KeyChar == 46)  //小数点
            {
                if (((TextBox)sender).Text.Length <= 0)
                    e.Handled = true;   //小数点不能在第一位
                else
                {
                    float f;
                    float oldf;
                    bool b1 = false, b2 = false;
                    b1 = float.TryParse(((TextBox)sender).Text, out oldf);
                    b2 = float.TryParse(((TextBox)sender).Text + e.KeyChar.ToString(), out f);
                    if (b2 == false)
                    {
                        if (b1 == true)
                            e.Handled = true;
                        else
                            e.Handled = false;
                    }
                }
            }
        }
    
    }
}
