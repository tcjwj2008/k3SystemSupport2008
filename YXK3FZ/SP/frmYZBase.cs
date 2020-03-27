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

namespace YXK3FZ.SP
{
    public partial class frmSPBase : Form
    {

        DataBase db = new DataBase();       
        DataSet ds = null;
        DataBase k3db = null;
        CommonUse commUse = new CommonUse();
				string ZtRyconstring = string.Empty; //获取K3账套连接字符串

        string ordertablename = "SP_Base";
        string entrytablename = "SP_BaseEntry"; 
       
          string fnamenum = "";

          int FEditID = 0; //修改时的编号


          string MasterState = "SEL";//类型 判断窗体是新增还是编辑状态 ADD EDIT SEL


          public frmSPBase()
          {
              InitializeComponent();

							lblMarket.Visible = false;
							cobMarket.Visible = false;

							ds = db.GetDataSet("SELECT Fdbstr  FROM dbo.YXZTLIST WHERE ID=1", "con");
							DataRow dr = ds.Tables[0].Rows[0];
							ZtRyconstring = dr["Fdbstr"].ToString(); //获取K3账套连接字符串
							k3db = new DataBase(ZtRyconstring);              
          }

          //窗体加载
          private void frmOrder_Load(object sender, EventArgs e)
          { 
              //权限控制 
              //commUse.CortrolButtonEnabled(btnADD, this);
              //commUse.CortrolButtonEnabled(tsbtnEdit, this);
              //commUse.CortrolButtonEnabled(btnSave, this);
              //commUse.CortrolButtonEnabled(btnConfirmer, this);
              //commUse.CortrolButtonEnabled(btnHConfirmer, this);
              //commUse.CortrolButtonEnabled(btnCheck, this);
              //commUse.CortrolButtonEnabled(btnHcheck, this);

              string sSQL = string.Empty;             

              //加载参数数据
							sSQL = " SELECT FID,FName from AIS_YXSP2.dbo.SP_Base";
              ds = k3db.GetDataSet(sSQL, "sel");
              DataTable dttSQL = ds.Tables[0];
              DataTable dttSQLQ = dttSQL.Copy();

              cobType.DataSource = dttSQL;
              cobType.ValueMember = "FID";
              cobType.DisplayMember = "FName";
              cobType.SelectedIndex = -1;

              cobTypeQ.DataSource = dttSQLQ;
              cobTypeQ.ValueMember = "FID";
              cobTypeQ.DisplayMember = "FName";
              cobTypeQ.SelectedIndex = -1;

							sSQL = "select FName FROM SP_BaseEntry WHERE FUID=2 ";
							DataTable dttResult = k3db.GetDataSet(sSQL, "sel").Tables[0];
							cobMarket.DataSource = dttResult;
							cobMarket.ValueMember = "FName";
							cobMarket.DisplayMember = "FName";
							cobMarket.SelectedIndex = -1;



              getDate(string.Empty, string.Empty);
              SetTextBoxState(MasterState);

          }

          //加载列表数据
          private void getDate(string Q,string sSQLWH)
          {              
              string sSQL = string.Empty;
							sSQL = " SELECT E.*,B.FName AS FTypeName FROM AIS_YXSP2.dbo.SP_BaseEntry e ";
							sSQL += " INNER JOIN AIS_YXSP2.dbo.SP_Base b ON e.FUID=B.FID ";
              sSQL += " Where 1=1 ";
              if (Q != string.Empty) //如果是查询
              {
                  sSQL += sSQLWH;
              }
							sSQL += " Order by E.SortID ";                      
              bdsMaster.DataSource = k3db.GetDataSet(sSQL, "sel").Tables[0].DefaultView;
          }

       
        private void dgvDetail_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e) //显示序号
        {            
            SolidBrush b = new SolidBrush(this.dgvDetail.RowHeadersDefaultCellStyle.ForeColor);
            e.Graphics.DrawString((e.RowIndex + 1).ToString(System.Globalization.CultureInfo.CurrentUICulture), this.dgvDetail.DefaultCellStyle.Font, b, e.RowBounds.Location.X + 20, e.RowBounds.Location.Y + 4);

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
						if (((System.Windows.Forms.TextBox)sender).Text.Length <= 0)
							e.Handled = true;   //小数点不能在第一位
						else
						{
							float f;
							float oldf;
							bool b1 = false, b2 = false;
							b1 = float.TryParse(((System.Windows.Forms.TextBox)sender).Text, out oldf);
							b2 = float.TryParse(((System.Windows.Forms.TextBox)sender).Text + e.KeyChar.ToString(), out f);
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


        //新增
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
					SetTextBoxState(MasterState);

					cobType.SelectedIndex = -1;
					txtTypeName.Text = string.Empty;
          
            
        }

       //修改
        private void tsbtnEdit_Click(object sender, EventArgs e)
        {
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

            if (cobType.SelectedIndex == -1)
            {
                MessageBox.Show("参数类别不能为空");
                cobType.Focus();
                return;

            }
            if (txtTypeName.Text == string.Empty)
            {
                MessageBox.Show("参数名称不能为空");
                txtTypeName.Focus();
                return;
            }
						if (txtSortID.Text == string.Empty)
						{
							MessageBox.Show("排序编码不能为空");
							txtSortID.Focus();
							return;
						}

            //查重
            string sSQL = string.Empty;

            if (MasterState == "ADD")
            {
                sSQL = " SELECT count(*) from SP_BaseEntry where FName=@FName and FUID=@FUID  ";

                SqlParameter[] par = new SqlParameter[] 
                 {
                    new SqlParameter("@FName", txtTypeName.Text.Trim()),
                     new SqlParameter("@FUID", cobType.SelectedValue)
                 };
								if (SqlHelper.Exists(ZtRyconstring, sSQL, par))
                {
                    MessageBox.Show("存在相同的参数，无法保存");
                    return;
                }
            }
            else if (MasterState == "EDIT")
            {
                int FID = Convert.ToInt32(((DataRowView)bdsMaster.Current).Row["FID"]);
                sSQL = " SELECT count(*) from SP_BaseEntry where FName=@FName and FID<>@FID  and FUID=@FUID  ";

                SqlParameter[] par = new SqlParameter[] 
                {
                  new SqlParameter("@FName", txtTypeName.Text.Trim()),
                  new SqlParameter("@FID", FID),
                   new SqlParameter("@FUID", cobType.SelectedValue)
                 };
								if (SqlHelper.Exists(ZtRyconstring, sSQL, par))
                {
                    MessageBox.Show("存在相同的参数，无法保存");
                    return;
                }
            }


						if (cobType.Text == "批次")
						{
							cobMarket.SelectedIndex = -1;
						}

            if (MasterState == "ADD")
            {


							sSQL = " insert into SP_BaseEntry(FUID,FName,FRemark,FRemark2,SortID) values (@FUID,@FName,@FRemark,@FRemark2,@SortID) ";
                SqlParameter[] par = new SqlParameter[] 
                {
                  new SqlParameter("@FUID", cobType.SelectedValue),
                  new SqlParameter("@FName", txtTypeName.Text.Trim()),
									new SqlParameter("@FRemark",cobMarket.Text.Trim()),
									new SqlParameter("@FRemark2",txtFRemark2.Text),
									new SqlParameter("@SortID",txtSortID.Text)
                   
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
							sSQL = " update SP_BaseEntry set FName= @FName,FRemark=@FRemark,FRemark2=@FRemark2,SortID=@SortID where FID=@FID";
                SqlParameter[] par = new SqlParameter[] 
                {
                  new SqlParameter("@FID", FEditID),
                  new SqlParameter("@FName", txtTypeName.Text.Trim()),
									new SqlParameter("@FRemark",cobMarket.Text.Trim()),
									new SqlParameter("@FRemark2",txtFRemark2.Text),
									new SqlParameter("@SortID",txtSortID.Text)
                   
                 };
								if (SqlHelper.ExecuteNonQuery(ZtRyconstring, sSQL, par) > 0)
                {
                    MasterState = "SEL";
                    SetTextBoxState(MasterState);
                    getDate(string.Empty, string.Empty);

                    int index = bdsMaster.Find("FID", FEditID);//按CompanyName查找IBM
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
                sSQL = "DELETE from SP_BaseEntry where  FID=@FID  ";

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
            if (cobTypeQ.SelectedIndex != -1)
            {
                sSQLWH += " and b.FName='" + cobTypeQ.Text + "' ";
            }
            if (txtTypeNameQ.Text != string.Empty)
            {
                sSQLWH += " and e.FName like '%"+txtTypeNameQ.Text.Trim()+"%'";
            }

            getDate("Q", sSQLWH);
        }

        private void btnCancel_Click(object sender, EventArgs e) //取消
        {
            getDate(string.Empty, string.Empty);
            cobTypeQ.SelectedIndex = -1;
            txtTypeNameQ.Text = string.Empty;
        }

        private void bdsMaster_CurrentChanged(object sender, EventArgs e)
        {
					if (bdsMaster.Current == null)
						return;

					int FID = Convert.ToInt32(((DataRowView)bdsMaster.Current).Row["FID"]);
					SetFieldValue(FID);
					MasterState = "SEL";
					SetTextBoxState(MasterState);      
           
          
        }

        private void SetFieldValue(int FID)
        {
            string sSQL = string.Empty;
            sSQL = " SELECT E.*,B.FName AS FTypeName FROM SP_BaseEntry e ";
            sSQL += " INNER JOIN SP_Base b ON e.FUID=B.FID ";
            sSQL += " Where e.FID=@FID ";

            SqlParameter[] par = new SqlParameter[] {
             new SqlParameter("@FID", FID)
          };

						DataTable dttSQL = SqlHelper.ExecuteDataTable(ZtRyconstring, sSQL, par);

						cobType.SelectedIndex = -1;

         if (dttSQL.Rows.Count > 0)
         {
             cobType.Text = dttSQL.Rows[0]["FTypeName"].ToString();
             txtTypeName.Text = dttSQL.Rows[0]["FName"].ToString();
						 cobMarket.Text = dttSQL.Rows[0]["FRemark"].ToString();
						 txtFRemark2.Text = dttSQL.Rows[0]["FRemark2"].ToString();
						 txtSortID.Text = dttSQL.Rows[0]["SortID"].ToString();
         }
         else
         {
             cobType.SelectedIndex = -1;
             txtTypeName.Text = string.Empty;
						 cobMarket.SelectedIndex = -1;
						 txtFRemark2.Text = string.Empty;
						 txtSortID.Text = string.Empty;
         }

        }

        private void SetTextBoxState(string sMasterState)
        {
           // string MasterState = "SEL";//类型 判断窗体是新增还是编辑状态 ADD EDIT SEL
            if (sMasterState == "SEL")
            {
                cobType.Enabled = false;
                txtTypeName.ReadOnly = true;
								cobMarket.Enabled = false;
								txtFRemark2.ReadOnly = true;
								txtSortID.ReadOnly = true;
            }
						else if (sMasterState == "ADD")
            {
                cobType.Enabled = true;
                txtTypeName.ReadOnly = false;
								cobMarket.Enabled = true;
								txtFRemark2.ReadOnly = false;
								txtSortID.ReadOnly = false;
            }
						else if (sMasterState == "EDIT")
						{
							cobType.Enabled = false;
							txtTypeName.ReadOnly = false;
							cobMarket.Enabled = true;
							txtFRemark2.ReadOnly = false;
							txtSortID.ReadOnly = false;
						}
        }

				private void cobType_SelectedIndexChanged(object sender, EventArgs e)
				{
					if (cobType.Text == "市场")
					{
						cobMarket.Visible = true;
						lblMarket.Visible = true;
						
					}
					else
					{
						cobMarket.Visible = false;
						lblMarket.Visible = false;
						cobMarket.SelectedIndex = -1;
					}
				}    


    
    }
}
