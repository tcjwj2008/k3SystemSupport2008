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


namespace YXK3FZ.RYGL
{
    public partial class frmXSBase : Form
    {
			  //类的初始化 db 连接的ERP数据库
        DataBase db = new DataBase();       
        DataSet ds = null;
        DataBase k3db = null;
			  //初始化用户权限类
        CommonUse commUse = new CommonUse();

        string ZtRyconstring = string.Empty; //获取K3账套连接字符串
        string ordertablename = "YZ_Base";
        string entrytablename = "AIS_YXRY2.dbo.t_Item_XS_Base_New"; 
        //定义变量
        string fnamenum = "";
        int FEditID = 0; //修改时的编号
        string MasterState = "SEL";//类型 判断窗体是新增还是编辑状态 ADD EDIT SEL

        public frmXSBase()//内部方法
        {
            InitializeComponent();
            ds = db.GetDataSet("SELECT Fdbstr  FROM dbo.YXZTLIST WHERE ID=2", "con");
            DataRow dr = ds.Tables[0].Rows[0];
            ZtRyconstring = dr["Fdbstr"].ToString(); //获取K3账套连接字符串-肉业账套
            k3db = new DataBase(ZtRyconstring);
        }

          //窗体加载
          private void frmOrder_Load(object sender, EventArgs e)
          { 
              //权限控制 
              commUse.CortrolButtonEnabled(btnADD, this);
              commUse.CortrolButtonEnabled(tsbtnEdit, this);
              commUse.CortrolButtonEnabled(btnSave, this);
              commUse.CortrolButtonEnabled(btnExport, this);
              commUse.CortrolButtonEnabled(btnImport, this);
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

          }

          //加载列表数据
          private void getDate(string Q,string sSQLWH)
          {              
              string sSQL = string.Empty;
              sSQL = " SELECT * FROM  AIS_YXRY2.dbo.t_Item_XS_Base_New ";
            
              sSQL += " Where 1=1 ";
              if (Q != string.Empty) //如果是查询
              {
                  sSQL += sSQLWH;
              }
              sSQL += " order by OrderID  ";             
              bdsMaster.DataSource = k3db.GetDataSet(sSQL, "sel").Tables[0].DefaultView;
          }

				//显示序号
        private void dgvDetail_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e) 
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
					  //设置控件状态（新增），调用状态切换方法，清空各控件的值
            MasterState = "ADD";
            SetTextBoxState(MasterState);                
            txtFName.Text = string.Empty;
            txtFNumber.Text = string.Empty;
            txtCBXS.Text = string.Empty;
            txtRGXS.Text = string.Empty;
					  //增加气调系数20190803
						txtQTXS.Text = string.Empty;            
            txtRemark.Text = string.Empty;
            txtOrderID.Text = string.Empty;
            txtFNumber.Focus();            
        }

        //修改基础参数
        private void tsbtnEdit_Click(object sender, EventArgs e)
        {
					  //判断各个控件的状态值
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
					  //当前选中的数据的KEY
            int FID = Convert.ToInt32(((DataRowView)bdsMaster.Current).Row["FID"]);
            FEditID = FID;
					  //赋值到控件
            SetFieldValue(FID);

            MasterState = "EDIT";
            SetTextBoxState(MasterState);          

            txtFNumber.ReadOnly = true;
            txtFName.ReadOnly = true;            

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
                MessageBox.Show("产品代码不能为空");
                txtFNumber.Focus();
                return;
            }           

            if (txtFName.Text == string.Empty)
            {
                MessageBox.Show("产品名称不能为空");
                txtFName.Focus();
                return;
            }

            if (txtCBXS.Text == string.Empty)
            {
                MessageBox.Show("肉品比例系数不能为空");
                txtCBXS.Focus();
                return;
            }
            if (txtRGXS.Text == string.Empty)
            {
                MessageBox.Show("人工比例系数不能为空");
                txtRGXS.Focus();
                return;
            }           

            //是否有重复插入
            string sSQL = string.Empty;

            if (MasterState == "ADD")
            {
                sSQL = " SELECT count(*) from AIS_YXRY2.dbo.t_Item_XS_Base_New where 产品代码=@FNumber   ";

                SqlParameter[] par = new SqlParameter[] 
                 {
                     new SqlParameter("@FNumber", txtFNumber.Text.Trim())
                   
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
            }

            if (MasterState == "ADD")
            {
							  sSQL = " insert into AIS_YXRY2.dbo.t_Item_XS_Base_New(产品代码,产品名称,肉品系数,人工系数,备注,OrderID,气调系数) values (@产品代码,@产品名称,@肉品系数,@人工系数,@备注,@OrderID,@气调系数) ";
                SqlParameter[] par = new SqlParameter[] 
                {                  
                   new SqlParameter("@产品代码", txtFNumber.Text.Trim()),
                   new SqlParameter("@产品名称", txtFName.Text.Trim()) ,  
                   new SqlParameter("@肉品系数", txtCBXS.Text.Trim()),
                   new SqlParameter("@人工系数", txtRGXS.Text.Trim()) ,                   
                   new SqlParameter("@备注", txtRemark.Text.Trim()),
                   new SqlParameter("@OrderID", txtOrderID.Text.Trim()) ,
									 new SqlParameter("@气调系数", this.txtQTXS.Text.Trim()) 
                   
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
							sSQL = " update AIS_YXRY2.dbo.t_Item_XS_Base_New set 肉品系数=@肉品系数,人工系数=@人工系数,备注=@备注,气调系数=@气调系数,OrderID=@OrderID where FID=@FID";
                SqlParameter[] par = new SqlParameter[] 
                {
                   new SqlParameter("@FID", FEditID),
                   new SqlParameter("@肉品系数", txtCBXS.Text.Trim()),
                   new SqlParameter("@人工系数", txtRGXS.Text.Trim()) ,
									 new SqlParameter("@气调系数", this.txtQTXS.Text.Trim()) ,
                   new SqlParameter("@备注", txtRemark.Text.Trim()) ,
                   new SqlParameter("@OrderID", txtOrderID.Text.Trim()) 
                   
                 };
                if (SqlHelper.ExecuteNonQuery(ZtRyconstring, sSQL, par) > 0)
                {
                    MasterState = "SEL";
                    SetTextBoxState(MasterState);
                    getDate(string.Empty, string.Empty);

                    int index = bdsMaster.Find("FID", FEditID);//定位修改的行
                    if (index != -1)
                    {
                        bdsMaster.Position = index;//定位BindingSource
                    }
                   
                }

            }
        }

        //删除记录
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (bdsMaster.Current == null)
                return;

            if (MessageBox.Show("确定要删除当前数据？", "软件提示", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                int FID = Convert.ToInt32(((DataRowView)bdsMaster.Current).Row["FID"]);
                string sSQL = string.Empty;
                sSQL = "DELETE from AIS_YXRY2.dbo.t_Item_XS_Base_New where  FID=@FID  ";

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

        //退出按钮
        private void btnClose_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("确定要退出吗？", "软件提示", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                this.Close();
            }
        }

			  //查询记录的按钮
        private void btnOK_Click(object sender, EventArgs e) //查询
        {
            string sSQLWH = string.Empty;
          
            if (txtFNameQ.Text != string.Empty)
            {
                sSQLWH += " and 产品名称 like '%" + txtFNameQ.Text.Trim() + "%'";
            }
            if (txtFNumberQ.Text != string.Empty)
            {
                sSQLWH += " and 产品代码 like '%" + txtFNumberQ.Text.Trim() + "%'";
            }

            getDate("Q", sSQLWH);
        }
				//取消
        private void btnCancel_Click(object sender, EventArgs e) 
        {
            getDate(string.Empty, string.Empty);          
            txtFNameQ.Text = string.Empty;
            txtFNumberQ.Text = string.Empty;
        }

			  //点击不同记录，显示不同记录值
        private void bdsMaster_CurrentChanged(object sender, EventArgs e)
        {
            if (bdsMaster.Current == null)
                return;

            int FID = Convert.ToInt32(((DataRowView)bdsMaster.Current).Row["FID"]);
            SetFieldValue(FID);
            MasterState = "SEL";
            SetTextBoxState(MasterState);           
          
        }
			  //控件赋值的方法
        private void SetFieldValue(int FID)
        {
            string sSQL = string.Empty;
            sSQL = " SELECT * FROM  AIS_YXRY2.dbo.t_Item_XS_Base_New ";
            sSQL += " Where FID=@FID ";
            SqlParameter[] par = new SqlParameter[] {
             new SqlParameter("@FID", FID)
          };

            System.Data.DataTable dttSQL = SqlHelper.ExecuteDataTable(ZtRyconstring, sSQL, par);
            if (dttSQL.Rows.Count > 0)
            {
                txtFName.Text = dttSQL.Rows[0]["产品名称"].ToString();
                txtFNumber.Text = dttSQL.Rows[0]["产品代码"].ToString();
             
                txtCBXS.Text = dttSQL.Rows[0]["肉品系数"].ToString();
                txtRGXS.Text = dttSQL.Rows[0]["人工系数"].ToString();
               //增加气调系数
								this.txtQTXS.Text = dttSQL.Rows[0]["气调系数"].ToString();
                txtRemark.Text = dttSQL.Rows[0]["备注"].ToString();
                txtOrderID.Text = dttSQL.Rows[0]["OrderID"].ToString();
            }
            else
            {               
                txtFName.Text = string.Empty;
                txtFNumber.Text = string.Empty;               
                txtCBXS.Text = string.Empty;
                txtRGXS.Text = string.Empty;              
                txtRemark.Text = string.Empty;
                txtOrderID.Text = string.Empty;
								txtQTXS.Text = string.Empty;
            }

        }
			  //设定控件状态的方法
        private void SetTextBoxState(string sMasterState)
        {
           // string MasterState = "SEL";//类型 
            if (sMasterState == "SEL")
            {              
                txtFName.ReadOnly = true;
                txtFNumber.ReadOnly = true;
                txtCBXS.ReadOnly = true;
                txtRGXS.ReadOnly = true;               
                txtRemark.ReadOnly = true;
                txtOrderID.ReadOnly = true;
								this.txtQTXS.ReadOnly = true;//修改气调系数状态值
            }
            else if (sMasterState == "ADD")
            {               
                txtFName.ReadOnly = false;
                txtFNumber.ReadOnly = false;
                txtCBXS.ReadOnly = false;
                txtRGXS.ReadOnly = false;               
                txtRemark.ReadOnly = false;
                txtOrderID.ReadOnly = false;
								this.txtQTXS.ReadOnly = false;//修改气调系数状态值
            }
            else if (sMasterState == "EDIT")
            {               
                txtFName.ReadOnly = true;
                txtFNumber.ReadOnly = true;
                txtCBXS.ReadOnly = false;
                txtRGXS.ReadOnly = false;               
                txtRemark.ReadOnly = false;
                txtOrderID.ReadOnly = false;
								this.txtQTXS.ReadOnly = false;//修改气调系数状态值
            }
        }

			  //快捷键方法
        private void txt_KeyPress(object sender, KeyPressEventArgs e)
        {
            //判断按键是不是要输入的类型。
            if (((int)e.KeyChar < 48 || (int)e.KeyChar > 57) && (int)e.KeyChar != 8 && (int)e.KeyChar != 46)
                e.Handled = true;

                
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

				//导出
        private void btnExport_Click(object sender, EventArgs e) 
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
            if (MessageBox.Show("确认要覆盖系数基础数据？", "软件提示", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                OpenFileDialog saveDialog = new OpenFileDialog();
								saveDialog.Filter = "Excel文件|*.xls;*.xlsx";
                if (saveDialog.ShowDialog() == DialogResult.OK)
                {
									  DataTable dt = NPOIExcelHelperNewVersion.ExcelToTableForXLS(saveDialog.FileName);
                    DataTable myDT = new DataTable();
                    myDT.Columns.Add("产品代码", Type.GetType("System.String"));
                    myDT.Columns.Add("产品名称", Type.GetType("System.String"));                    
                    myDT.Columns.Add("肉品系数", Type.GetType("System.Double"));
                    myDT.Columns.Add("人工系数", Type.GetType("System.Double"));
										myDT.Columns.Add("气调系数", Type.GetType("System.Double"));
                    myDT.Columns.Add("OrderID", Type.GetType("System.Double"));
                    myDT.Columns.Add("备注", Type.GetType("System.String"));
  
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        myDT.Rows.Add(dt.Rows[i].ItemArray);
                    } 
                    SqlHelper.ExecuteNonQuery(ZtRyconstring, "DELETE from AIS_YXRY2.dbo.t_Item_XS_Base_New ");            
                    SqlBulkCopyByDatatable(ZtRyconstring, "t_Item_XS_Base_New", myDT);
                    getDate(string.Empty, string.Empty);
                    MessageBox.Show("数据导入成功");
                }

                
            }
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

    }
}
