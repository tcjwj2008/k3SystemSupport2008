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
using System.Collections;
using System.Data.OleDb;


namespace YXK3FZ.SP
{
    public partial class frmXYBase : Form
    {

        DataBase db = new DataBase();       
        DataSet ds = null;
        DataBase k3db = null;
        CommonUse commUse = new CommonUse();

          string ZtRyconstring = string.Empty; //获取K3账套连接字符串

				
         

          int FEditID = 0; //修改时的编号


          string MasterState = "SEL";//类型 判断窗体是新增还是编辑状态 ADD EDIT SEL


					public frmXYBase()
          {
              InitializeComponent();
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

							//commUse.CortrolButtonEnabled(btnExport, this);
							//commUse.CortrolButtonEnabled(btnImport, this);


              //commUse.CortrolButtonEnabled(btnConfirmer, this);
              //commUse.CortrolButtonEnabled(btnHConfirmer, this);
              //commUse.CortrolButtonEnabled(btnCheck, this);
              //commUse.CortrolButtonEnabled(btnHcheck, this);

							//commUse.CortrolButtonEnabled(btnOK, this);
							//commUse.CortrolButtonEnabled(btnCancel, this);



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

              

          }

          //加载列表数据
          private void getDate(string Q,string sSQLWH)
          {              
              string sSQL = string.Empty;
							sSQL = " select *  FROM  t_SPXYBase b ";            
              sSQL += " Where 1=1 ";
              if (Q != string.Empty) //如果是查询
              {
                  sSQL += sSQLWH;
              }
              sSQL += " order by b.FNumber  ";
             
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
           
            txtFName.Text = string.Empty;
            txtFNumber.Text = string.Empty;
            txtCBXS.Text = string.Empty;
           

            txtFNumber.Focus();
            
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

						int FID = Convert.ToInt32(((DataRowView)bdsMaster.Current).Row["FInterID"]);
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
            if (txtFNumber.Text == string.Empty)
            {
                MessageBox.Show("客户代码不能为空");
                txtFNumber.Focus();
                return;
            }
            

            if (txtCBXS.Text == string.Empty)
            {
                MessageBox.Show("信用额度不能为空");
                txtCBXS.Focus();
                return;
            }
                     

           
           

            
            string sSQL = string.Empty;
					//检查当前客户代码是否存在K3

						sSQL = " select FItemID,FName,FNumber from t_Organization where FNumber=@FNumber ";
					 SqlParameter[] par0 = new SqlParameter[] 
                 {
                     new SqlParameter("@FNumber", txtFNumber.Text.Trim())
                   
                 };
					 DataTable dttSQL = SqlHelper.ExecuteDataTable(ZtRyconstring, sSQL, par0);
					 if (dttSQL.Rows.Count == 0)
					 {
						 MessageBox.Show("当前客户编号不存在K3中，请输入正确的K3客户代码");						 
						 return;
					 }

					 string sFItemID = dttSQL.Rows[0]["FItemID"].ToString().Trim(); //内码
					 string sFNumber = dttSQL.Rows[0]["FNumber"].ToString().Trim(); //客户编号
					 string sFName = dttSQL.Rows[0]["FName"].ToString().Trim(); //客户名称


					 //查重

            if (MasterState == "ADD")
            {
							sSQL = " SELECT count(*) from t_SPXYBase where FInterID=@FInterID   ";

                SqlParameter[] par = new SqlParameter[] 
                 {
                     new SqlParameter("@FInterID", sFItemID)
                   
                 };
								if (SqlHelper.Exists(ZtRyconstring, sSQL, par))
                {
                    MessageBox.Show("存在相同的内码，无法保存");
                    return;
                }
            }
            else if (MasterState == "EDIT")
            {
							int FID = Convert.ToInt32(((DataRowView)bdsMaster.Current).Row["FInterID"]); //获取当前已保存的内码

							if(Convert.ToInt32(sFItemID)!=FID) //如果内码不一样
							{
								sSQL = " SELECT count(*) from t_SPXYBase where FInterID=@FInterID   ";

								SqlParameter[] par = new SqlParameter[] 
                 {
                     new SqlParameter("@FInterID", sFItemID)
                   
                 };
								if (SqlHelper.Exists(ZtRyconstring, sSQL, par))
								{
									MessageBox.Show("存在相同的内码，无法保存");
									return;
								}
							}

               
            }

            if (MasterState == "ADD")
            {
							sSQL = " insert into t_SPXYBase(FInterID, FXYMoney,FNumber,FName) values (@FInterID, @FXYMoney,@FNumber,@FName) ";
							SqlParameter[] par = new SqlParameter[] 
								{
								   new SqlParameter("@FInterID", sFItemID),
								   new SqlParameter("@FXYMoney", txtCBXS.Text.Trim()),
								   new SqlParameter("@FNumber", sFNumber) ,  
								   new SqlParameter("@FName", sFName)								   
                   
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
							int FID = Convert.ToInt32(((DataRowView)bdsMaster.Current).Row["FInterID"]); //获取当前已保存的内码

							sSQL = " delete from t_SPXYBase where FInterID=@FInterID";
							SqlParameter[] par2 = new SqlParameter[] 
								{
								   new SqlParameter("@FInterID", FID)								  			   
                   
								 };
							if (SqlHelper.ExecuteNonQuery(ZtRyconstring, sSQL, par2) > 0)
							{
								sSQL = " insert into t_SPXYBase(FInterID, FXYMoney,FNumber,FName) values (@FInterID, @FXYMoney,@FNumber,@FName) ";
								SqlParameter[] par = new SqlParameter[] 
								{
								   new SqlParameter("@FInterID", sFItemID),
								   new SqlParameter("@FXYMoney", txtCBXS.Text.Trim()),
								   new SqlParameter("@FNumber", sFNumber) ,  
								   new SqlParameter("@FName", sFName)								   
                   
								 };

								if (SqlHelper.ExecuteNonQuery(ZtRyconstring, sSQL, par) > 0)
								{
									MasterState = "SEL";
									SetTextBoxState(MasterState);
									getDate(string.Empty, string.Empty);

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
                sSQL = "DELETE from AIS_YXRY2.dbo.t_Item_XS_Base where  FID=@FID  ";

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
        
            if (txtFNameQ.Text != string.Empty)
            {
                sSQLWH += " and b.FName like '%" + txtFNameQ.Text.Trim() + "%'";
            }
            if (txtFNumberQ.Text != string.Empty)
            {
                sSQLWH += " and b.FNumber like '%" + txtFNumberQ.Text.Trim() + "%'";
            }

            getDate("Q", sSQLWH);
        }

        private void btnCancel_Click(object sender, EventArgs e) //取消
        {
            getDate(string.Empty, string.Empty);
           
            txtFNameQ.Text = string.Empty;
            txtFNumberQ.Text = string.Empty;
        }

        private void bdsMaster_CurrentChanged(object sender, EventArgs e)
        {
            if (bdsMaster.Current == null)
                return;

						int FID = Convert.ToInt32(((DataRowView)bdsMaster.Current).Row["FInterID"]);
            SetFieldValue(FID);
            MasterState = "SEL";
            SetTextBoxState(MasterState);           
          
        }

				private void SetFieldValue(int FInterID)
        {
            string sSQL = string.Empty;
						sSQL = " SELECT * from t_SPXYBase ";
						sSQL += " Where FInterID=@FInterID ";
            SqlParameter[] par = new SqlParameter[] {
             new SqlParameter("@FInterID", FInterID)
          };

            System.Data.DataTable dttSQL = SqlHelper.ExecuteDataTable(ZtRyconstring, sSQL, par);
            if (dttSQL.Rows.Count > 0)
            {
                txtFName.Text = dttSQL.Rows[0]["FName"].ToString();
                txtFNumber.Text = dttSQL.Rows[0]["FNumber"].ToString();
								txtCBXS.Text = dttSQL.Rows[0]["FXYMoney"].ToString();
            }
            else
            {
               
                txtFName.Text = string.Empty;
                txtFNumber.Text = string.Empty;               
                txtCBXS.Text = string.Empty;
                

            }

        }

        private void SetTextBoxState(string sMasterState)
        {
           // string MasterState = "SEL";//类型 判断窗体是新增还是编辑状态 ADD EDIT SEL
            if (sMasterState == "SEL")
            {
               
                txtFName.ReadOnly = true;
                txtFNumber.ReadOnly = true;
                txtCBXS.ReadOnly = true;
                
            }
            else if (sMasterState == "ADD")
            {
               
                txtFName.ReadOnly = true;
                txtFNumber.ReadOnly = false;
                txtCBXS.ReadOnly = false;
                
            }
            else if (sMasterState == "EDIT")
            {
               
                txtFName.ReadOnly = true;
                txtFNumber.ReadOnly = false;
                txtCBXS.ReadOnly = false;
                
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

      

        private void btnExport_Click(object sender, EventArgs e) //导出
        {
            if (bdsMaster.Count == 0)
            {
                MessageBox.Show("无数据，无法导出");
                return;
            }
            string sFileName = "系数导出";
            ComClass.CommExcel.ExportExcel(sFileName, dgvDetail, true);

        }

        private void btnImport_Click(object sender, EventArgs e) //导入
        {
        }

        private void SqlBulkCopyByDatatable(string connectionString, string TableName, System.Data.DataTable dt)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlBulkCopy sqlbulkcopy = new SqlBulkCopy(connectionString, SqlBulkCopyOptions.UseInternalTransaction))
                {
                    try
                    {
                        sqlbulkcopy.DestinationTableName = TableName;
                        for (int i = 0; i < dt.Columns.Count; i++)
                        {
                            sqlbulkcopy.ColumnMappings.Add(dt.Columns[i].ColumnName, dt.Columns[i].ColumnName);

                        }
                        sqlbulkcopy.WriteToServer(dt);
                    }
                    catch (System.Exception ex)
                    {
                        throw ex;
                    }
                }
            }
        }


        public DataTable ExcelDT2(string savePath)
        {
            string strConn = string.Empty;
          
            strConn = "Provider=Microsoft.Ace.OleDb.4.0;" + "data source=" + savePath + ";Extended Properties='Excel 8.0; HDR=Yes; IMEX=1'";
            strConn = "Provider=Microsoft.Ace.OleDb.12.0;" + "data source=" + savePath + ";Extended Properties='Excel 12.0; HDR=Yes; IMEX=1'";

            OleDbConnection conn= new OleDbConnection(strConn); //连接excel           
 

            if (conn.State.ToString() == "Open")
            {
                conn.Close();
            }
            conn.Open();    //外部表不是预期格式，不兼容2010的excel表结构  
            string s = conn.State.ToString();
            OleDbDataAdapter myCommand = null;
            ds = null;
            string strExcel = "select 产品代码,产品名称,成本比例系数,人工比例系数, switch(车间类别='屠宰车间','1',车间类别='分割车间','2') as  车间类别,对应屠宰车间代码 as 对应代码,备注,	排序代码 AS  OrderID from [sheet1$]";  //如果有多个sheet表时可以选择是第几张sheet表      
            myCommand = new OleDbDataAdapter(strExcel, conn);//用strExcel初始化myCommand，查看myCommand里面的表的数据？？  
            ds = new DataSet();
            myCommand.Fill(ds);     //把表中的数据存放在ds(dataSet)  
            conn.Close();

            return ds.Tables[0];

        }  



       

    
    }
}
