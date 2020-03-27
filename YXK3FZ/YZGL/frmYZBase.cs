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

namespace YXK3FZ.YZGL
{
    public partial class frmYZBase : Form
    {

        DataBase db = new DataBase();       
        DataSet ds = null;
        DataBase k3db = null;
        CommonUse commUse = new CommonUse();

        string ordertablename = "YZ_Base";
        string entrytablename = "YZ_BaseEntry"; 
       
          string fnamenum = "";

          int FEditID = 0; //修改时的编号


          string MasterState = "SEL";//类型 判断窗体是新增还是编辑状态 ADD EDIT SEL


          public frmYZBase()
          {
              InitializeComponent();
              k3db = new DataBase(YXK3FZ.DataClass.DataBase.m_Connstr);
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
              sSQL = " SELECT FID,FName from YZ_Base";
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


              getDate(string.Empty, string.Empty);
              SetTextBoxState(MasterState);

          }

          //加载列表数据
          private void getDate(string Q,string sSQLWH)
          {              
              string sSQL = string.Empty;
              sSQL = " SELECT E.*,B.FName AS FTypeName FROM YZ_BaseEntry e ";
              sSQL += " INNER JOIN YZ_Base b ON e.FUID=B.FID ";
              sSQL += " Where 1=1 ";
              if (Q != string.Empty) //如果是查询
              {
                  sSQL += sSQLWH;
              }
              sSQL += " Order by E.FUID,E.FID ";                      
              bdsMaster.DataSource = k3db.GetDataSet(sSQL, "sel").Tables[0].DefaultView;
          }

       
        private void dgvDetail_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e) //显示序号
        {            
            SolidBrush b = new SolidBrush(this.dgvDetail.RowHeadersDefaultCellStyle.ForeColor);
            e.Graphics.DrawString((e.RowIndex + 1).ToString(System.Globalization.CultureInfo.CurrentUICulture), this.dgvDetail.DefaultCellStyle.Font, b, e.RowBounds.Location.X + 20, e.RowBounds.Location.Y + 4);

        }


        //新增
        private void btnADD_Click(object sender, EventArgs e)
        {
            if (MasterState == "ADD" || MasterState == "EDIT") //如果当前状态非查看状态
            {
							MessageBox.Show("当前状态为编辑状态");
							return;
            }
            else
            {
                cobType.SelectedIndex = -1;
                txtTypeName.Text = string.Empty;
								txtFShortName.Text = string.Empty;
                MasterState = "ADD";
                SetTextBoxState(MasterState);
                bdsMaster.AddNew();
            } 
            
        }

       //修改
        private void tsbtnEdit_Click(object sender, EventArgs e)
        {
            if (bdsMaster.Current == null)
                return;

            if (MasterState == "ADD" || MasterState == "EDIT") //如果当前状态非查看状态
            {
							MessageBox.Show("当前状态为编辑状态");
							return;
            }
            else
            {
                int FID = Convert.ToInt32(((DataRowView)bdsMaster.Current).Row["FID"]);
                FEditID = FID;
                SetFieldValue(FID);
                MasterState = "EDIT";
                SetTextBoxState(MasterState);
                cobType.Enabled = false;

            }

            

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

            //查重
            string sSQL = string.Empty;

            if (MasterState == "ADD")
            {
                sSQL = " SELECT count(*) from YZ_BaseEntry where FName=@FName and FUID=@FUID  ";

                SqlParameter[] par = new SqlParameter[] 
                 {
                    new SqlParameter("@FName", txtTypeName.Text.Trim()),
                     new SqlParameter("@FUID", cobType.SelectedValue)
                 };
                if (SqlHelper.Exists(YXK3FZ.DataClass.DataBase.m_Connstr, sSQL, par))
                {
                    MessageBox.Show("存在相同的参数，无法保存");
                    return;
                }
            }
            else if (MasterState == "EDIT")
            {
                int FID = Convert.ToInt32(((DataRowView)bdsMaster.Current).Row["FID"]);
                sSQL = " SELECT count(*) from YZ_BaseEntry where FName=@FName and FID<>@FID  and FUID=@FUID  ";

                SqlParameter[] par = new SqlParameter[] 
                {
                  new SqlParameter("@FName", txtTypeName.Text.Trim()),
                  new SqlParameter("@FID", FID),
                   new SqlParameter("@FUID", cobType.SelectedValue)
                 };
                if (SqlHelper.Exists(YXK3FZ.DataClass.DataBase.m_Connstr, sSQL, par))
                {
                    MessageBox.Show("存在相同的参数，无法保存");
                    return;
                }
            }

            if (MasterState == "ADD")
            {
							sSQL = " insert into YZ_BaseEntry(FUID,FName,FShortName,FText) values (@FUID,@FName,@FShortName,@FText) ";
                SqlParameter[] par = new SqlParameter[] 
                {
                  new SqlParameter("@FUID", cobType.SelectedValue),
								  new SqlParameter("@FShortName", txtFShortName.Text.Trim()),
									new SqlParameter("@FText", txtFText.Text.Trim()),
                  new SqlParameter("@FName", txtTypeName.Text.Trim())                
                   
                 };

                if (SqlHelper.ExecuteNonQuery(YXK3FZ.DataClass.DataBase.m_Connstr, sSQL, par) >0)
                {
                    MasterState = "SEL";
                    SetTextBoxState(MasterState);
                   // getDate(string.Empty, string.Empty);
										btnOK_Click(null, null);
                    
                }

            }
            else if (MasterState == "EDIT")
            {
							sSQL = " update YZ_BaseEntry set FName= @FName,FShortName=@FShortName,FText=@FText where FID=@FID";
                SqlParameter[] par = new SqlParameter[] 
                {
                  new SqlParameter("@FID", FEditID),
									new SqlParameter("@FShortName", txtFShortName.Text.Trim()),
									new SqlParameter("@FText", txtFText.Text.Trim()),
                  new SqlParameter("@FName", txtTypeName.Text.Trim())                
                   
                 };
                if (SqlHelper.ExecuteNonQuery(YXK3FZ.DataClass.DataBase.m_Connstr, sSQL, par) > 0)
                {
                    MasterState = "SEL";
                    SetTextBoxState(MasterState);
                    //getDate(string.Empty, string.Empty);
										btnOK_Click(null, null);

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
                sSQL = "DELETE from YZ_BaseEntry where  FID=@FID  ";

                SqlParameter[] par = new SqlParameter[] 
                {                 
                  new SqlParameter("@FID", FID)
                 };

                if (SqlHelper.ExecuteNonQuery(YXK3FZ.DataClass.DataBase.m_Connstr, sSQL, par) > 0)
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

            if (MasterState != "ADD")
            {
                int FID = Convert.ToInt32(((DataRowView)bdsMaster.Current).Row["FID"]);
                MasterState = "SEL";
                SetTextBoxState(MasterState);
                SetFieldValue(FID);
            }


            

            

            //if (MasterState == "SEL") //如果当前状态为查看状态
            //{
            //    SetFieldValue(FID);
            //}
            //else //非查看状态
            //{
            //    if (MessageBox.Show("当前数据处于编辑状态，确定要离开？", "软件提示", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            //    {
            //        MasterState = "SEL";
            //        SetTextBoxState(MasterState);
            //        SetFieldValue(FID);
            //    }
            //    else
            //    {
            //        MessageBox.Show("do it"+FEditID);
            //    }                
            //}

           
       
           
          
        }

        private void SetFieldValue(int FID)
        {
            string sSQL = string.Empty;
            sSQL = " SELECT E.*,B.FName AS FTypeName FROM YZ_BaseEntry e ";
            sSQL += " INNER JOIN YZ_Base b ON e.FUID=B.FID ";
            sSQL += " Where e.FID=@FID ";

            SqlParameter[] par = new SqlParameter[] {
             new SqlParameter("@FID", FID)
          };

         DataTable dttSQL=   SqlHelper.ExecuteDataTable(YXK3FZ.DataClass.DataBase.m_Connstr, sSQL, par);

         if (dttSQL.Rows.Count > 0)
         {
             cobType.Text = dttSQL.Rows[0]["FTypeName"].ToString();
             txtTypeName.Text = dttSQL.Rows[0]["FName"].ToString();
						 txtFShortName.Text = dttSQL.Rows[0]["FShortName"].ToString();
						 txtFText.Text = dttSQL.Rows[0]["FText"].ToString();
         }
         else
         {
             cobType.SelectedIndex = -1;
             txtTypeName.Text = string.Empty;
						 txtFShortName.Text = string.Empty;
						 txtFText.Text = string.Empty;

         }

        }

        private void SetTextBoxState(string sMasterState)
        {
           // string MasterState = "SEL";//类型 判断窗体是新增还是编辑状态 ADD EDIT SEL
            if (sMasterState == "SEL")
            {
                cobType.Enabled = false;
                txtTypeName.ReadOnly = true;
								txtFShortName.ReadOnly = true;
								txtFText.ReadOnly = true;
            }
            else
            {
                cobType.Enabled = true;
                txtTypeName.ReadOnly = false;
								txtFShortName.ReadOnly = false;
								txtFText.ReadOnly = false;
            }
        }

				private void cobType_SelectedIndexChanged(object sender, EventArgs e)
				{
					if (cobType.Text == "船次")
					{
						lblFShortName.Visible = true;
						txtFShortName.Visible = true;
					}
					else
					{
						lblFShortName.Visible = false;
						txtFShortName.Visible = false;

						txtFShortName.Text = string.Empty;
					}

				}

 
     
    





      


    
    }
}
