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
using YXK3FZ.ComClass;
namespace YXK3FZ.SO
{
    public partial class frmSeorderPlanEdit : Form
    {

        DataBase db = new DataBase();
        DataBase k3db = null;
        DataSet ds = null;
        CommonUse commUse = new CommonUse();
        //SqlDataAdapter sda = null;
        //帐套的链接
        string ZtRyconstring;
        string fType;//类型 判断窗体是新增还是编辑状态
        string Finterid;//单据内码
        string fbillno;//单据编号
       public  string FCheckerID;
       public  string FCustID;
       public  string FBillerID;
       public  string FEmpID;
        
        public frmSeorderPlanEdit(string typestr)
        {
            InitializeComponent();
            this.fType = typestr;
            if (this.fType == "ADD")
            {
                this.Text = "销售计划单--新增";
            }
            if (this.fType == "EDIT")
            {
                this.Text = "销售计划单--修改";
            }

        }

 
        private void frmSeorderPlanEdit_Load(object sender, EventArgs e)
        {
            //得到肉业的链接
            ds = db.GetDataSet("SELECT Fdbstr    FROM dbo.YXZTLIST WHERE ID=2" , "con");
            DataRow dr = ds.Tables[0].Rows[0];
            ZtRyconstring = dr["Fdbstr"].ToString();
            k3db = new DataBase(ZtRyconstring);
            
            if (this.fType == "ADD")
            {
               //得到新的单据编号和内码
                //SqlParameter param1 = new SqlParameter("@TableName", SqlDbType.VarChar);
                //param1.Value = "RYSP_SeorderPlan";
                //SqlParameter param2 = new SqlParameter("@FFdate", SqlDbType.VarChar);
                //param2.Value = DateTime.Now.ToString("yyyyMMdd");
                ////创建泛型
                //List<SqlParameter> parameters = new List<SqlParameter>();
                //parameters.Add(param1);
                //parameters.Add(param2);
                ////把泛型中的元素复制到数组中
                //SqlParameter[] inputParameters = parameters.ToArray();

                //DataTable dt = db.GetDataTable("GetICMaxNum", inputParameters);

                //this.txtFbillno.Text = dt.Rows[0][1].ToString();
                //this.Finterid = dt.Rows[0][0].ToString();
                this.FBillerID = PropertyClass.OperatorID.ToString();
                this.txtFBillerName.Text = PropertyClass.OperatorName;
                this.txtFdate.Text = DateTime.Now.ToString("yyyy-MM-dd");
                this.txtSumFamout.Text = "0";
           
            }
   




        }

        private void button1_Click(object sender, EventArgs e)
        {//调用查询窗体 查供应商 
            frmSelectDataDialog frmselect = new frmSelectDataDialog("Cus","");

            frmselect.frmSeorderPlanEdit = this;          //将新创建的窗体对象设置为同一个窗体类的实例（对象）
            frmselect.frmName = "frmSeorderPlanEdit";　　//用于识别　是那一个窗体调用的select窗口的
            frmselect.ShowDialog();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            frmSelectDataDialog frmselect = new frmSelectDataDialog("Emp","");

            frmselect.frmSeorderPlanEdit = this;          //将新创建的窗体对象设置为同一个窗体类的实例（对象）
            frmselect.frmName = "frmSeorderPlanEdit";　　//用于识别　是那一个窗体调用的select窗口的
            frmselect.ShowDialog();
        }

        private void txtFCustNumber_KeyPress(object sender, KeyPressEventArgs e)
        {//客户按下回车键时
            if (e.KeyChar == 13)
            {
              if (this.FCustID==null)
              {
                  ds = k3db.GetDataSet("  SELECT FItemID, FNumber 代码,FName 名称,FAddress 地址 FROM dbo.t_Organization WHERE FDeleted=0 and fnumber like '%" + txtFCustNumber.Text + "%'    ", "tab");
                  if (ds.Tables[0].Rows.Count == 1)
                  {
                      this.FCustID = ds.Tables[0].Rows[0][0].ToString();
                      this.txtFCustName.Text= ds.Tables[0].Rows[0][2].ToString();
                      this.txtFCustAdder.Text = ds.Tables[0].Rows[0][3].ToString();

                  }
                  else
                  {

                      frmSelectDataDialog frmselect = new frmSelectDataDialog("Cus", txtFCustNumber.Text);

                      frmselect.frmSeorderPlanEdit = this;          //将新创建的窗体对象设置为同一个窗体类的实例（对象）
                      frmselect.frmName = "frmSeorderPlanEdit";　　//用于识别　是那一个窗体调用的select窗口的
                      frmselect.ShowDialog();   

                  }

              
              }

              
            } 



        }

        private void txtFEmpNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                if (this.FCustID == null)
                {
                    ds = k3db.GetDataSet("  SELECT FItemID, FNumber 代码,FName 名称,FAddress 地址 FROM dbo.t_emp WHERE FDeleted=0 and fnumber like '%" + this.txtFEmpNumber.Text + "%'    ", "tab");
                    if (ds.Tables[0].Rows.Count == 1)
                    {
                        this.FEmpID = ds.Tables[0].Rows[0][0].ToString();
                        this.txtFEmpNumber.Text = ds.Tables[0].Rows[0][2].ToString();
                        

                    }
                    else
                    {

                        frmSelectDataDialog frmselect = new frmSelectDataDialog("Emp", this.txtFEmpNumber.Text);

                        frmselect.frmSeorderPlanEdit = this;          //将新创建的窗体对象设置为同一个窗体类的实例（对象）
                        frmselect.frmName = "frmSeorderPlanEdit";　　//用于识别　是那一个窗体调用的select窗口的
                        frmselect.ShowDialog();

                    }


                }


            } 
            


        }

        private void dataGridView1_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {//显示序号
            SolidBrush b = new SolidBrush(this.dataGridView1.RowHeadersDefaultCellStyle.ForeColor);
            e.Graphics.DrawString((e.RowIndex + 1).ToString(System.Globalization.CultureInfo.CurrentUICulture), this.dataGridView1.DefaultCellStyle.Font, b, e.RowBounds.Location.X + 20, e.RowBounds.Location.Y + 4);

        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {//双击
            if (e.ColumnIndex == 1 )
            {
                // MessageBox.Show("1111"); .Value
                string fnumber;
                if (dataGridView1["ColumnFitemNnmber", e.RowIndex].Value == null)
                {
                    fnumber = "";

                }
                else
                { fnumber = dataGridView1["ColumnFitemNnmber", e.RowIndex].Value.ToString(); }
                frmSelectDataDialog frmselect = new frmSelectDataDialog("Icitem", fnumber);

                frmselect.frmSeorderPlanEdit = this;          //将新创建的窗体对象设置为同一个窗体类的实例（对象）
                frmselect.frmName = "frmSeorderPlanEdit";　　//用于识别　是那一个窗体调用的select窗口的
                frmselect.M_int_CurrentRow = e.RowIndex;
                frmselect.ShowDialog();
                this.dataGridView1.CurrentCell = dataGridView1["ColumnFSFQty", e.RowIndex]; //设置辅助重量单元格获得焦点
                dataGridView1.BeginEdit(true); 

            
            }

        }

       




        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {//

            if (e.ColumnIndex == 1 && e.RowIndex >= 0 && this.dataGridView1["ColumnFitemID", e.RowIndex].Value==null)　　//产品代码单元格变化
            {
               // this.dataGridView1.AllowUserToAddRows = false;
                string fnumber;
                int row;
                row = this.dataGridView1.CurrentCell.RowIndex;//行
                if (this.dataGridView1["ColumnFitemNnmber", row].Value == null)
                {
                    fnumber = "";

                }
                else
                { fnumber = this.dataGridView1["ColumnFitemNnmber", row].Value.ToString(); }

                ds = db.GetDataSet(" SELECT FItemID ,fnumber  代码,FName 名称,fmodel 规格型号,FUnitID FKUnitID,funitname k3单位,FSecUnitname 辅助单位,FSecCoefficient 换算率 FROM dbo.rysp_icitem  where Fdelete=0 and fnumber like '%" + fnumber + "%'    ", "tab");
                if (ds.Tables[0].Rows.Count == 1)
                { //如果输入的代码只有一个产品直接赋值

                    this.dataGridView1["ColumnFitemID", row].Value = ds.Tables[0].Rows[0][0].ToString(); ;// finterid
                    this.dataGridView1["ColumnFitemNnmber", row].Value = ds.Tables[0].Rows[0][1].ToString(); ;//fnumber
                    this.dataGridView1["ColumnFitemName", row].Value = ds.Tables[0].Rows[0][2].ToString(); ;//fname
                    this.dataGridView1["ColumnFmodel", row].Value = ds.Tables[0].Rows[0][3].ToString(); ;//fmodel
                    this.dataGridView1["ColumnFKUnitID", row].Value = ds.Tables[0].Rows[0][4].ToString(); ;//FKUnitID
                    this.dataGridView1["ColumnFKUnitName", row].Value = ds.Tables[0].Rows[0][5].ToString(); ;//funitname
                    this.dataGridView1["ColumnFFUnitName", row].Value = ds.Tables[0].Rows[0][6].ToString();//FSecUnitname 
                    this.dataGridView1["ColumnFSecCoefficient", row].Value = ds.Tables[0].Rows[0][7].ToString();//FSecCoefficient
                    this.dataGridView1.CurrentCell = dataGridView1["ColumnFSFQty", e.RowIndex]; //设置辅助重量单元格获得焦点
                    dataGridView1.BeginEdit(true); 

                }
                else
                {//否则弹出查询窗体


                    frmSelectDataDialog frmselect = new frmSelectDataDialog("Icitem", fnumber);

                    frmselect.frmSeorderPlanEdit = this;          //将新创建的窗体对象设置为同一个窗体类的实例（对象）
                    frmselect.frmName = "frmSeorderPlanEdit";　　//用于识别　是那一个窗体调用的select窗口的
                    frmselect.M_int_CurrentRow = this.dataGridView1.CurrentCell.RowIndex;
                    frmselect.ShowDialog();
                    //this.dataGridView1.CurrentCell = dataGridView1["ColumnFSFQty", e.RowIndex]; //设置辅助重量单元格获得焦点
                    //dataGridView1.BeginEdit(true); 


                }
            
            
            }

            if (e.ColumnIndex == 0 && e.RowIndex >= 0 )
            {//取得产品内码时 通过内码去获取单价
                if (this.dataGridView1["ColumnFitemID", e.RowIndex].Value != null)
               {
                   SqlParameter param1 = new SqlParameter("@ItemID", SqlDbType.Int);
                   param1.Value = int.Parse(this.dataGridView1["ColumnFitemID", e.RowIndex].Value.ToString());
                   SqlParameter param2 = new SqlParameter("@fcurid", SqlDbType.Int);
                   param2.Value =int.Parse(this.FCustID);
                   //创建泛型
                   List<SqlParameter> parameters = new List<SqlParameter>();
                   parameters.Add(param1);
                   parameters.Add(param2);
                   //把泛型中的元素复制到数组中
                   SqlParameter[] inputParameters = parameters.ToArray();

                   DataTable dt = db.GetDataTable("sp_getPrice", inputParameters);
                   if (dt.Rows.Count == 0)
                   {
                       MessageBox.Show("未能获得K3中的单价，请先到K3主控台维护单价！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                       this.dataGridView1["ColumnFPrice", e.RowIndex].Value = "";
                   }
                   else
                   {
                       this.dataGridView1["ColumnFPrice", e.RowIndex].Value = dt.Rows[0][0].ToString();
                   }
               
               }
            
            
            }

            if (e.ColumnIndex == 9  && e.RowIndex >= 0)
            {//更改k3重量
                try
                {
                    this.dataGridView1["ColumnFSFQty", e.RowIndex].Value =
                    (Convert.ToSingle(this.dataGridView1["ColumnFSkQty", e.RowIndex].Value.ToString()) /
                    Convert.ToSingle(this.dataGridView1["ColumnFSecCoefficient", e.RowIndex].Value.ToString())).ToString();
                }
                catch {
                    MessageBox.Show("重量录入非法字符！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                   
                
                }
                try
                {
                    //计算当前行金额
                    this.dataGridView1["ColumnFSAmount", e.RowIndex].Value = Convert.ToSingle
                       ((Convert.ToSingle(this.dataGridView1["ColumnFSkQty", e.RowIndex].Value.ToString()) *
                        Convert.ToSingle(this.dataGridView1["ColumnFPrice", e.RowIndex].Value.ToString()))).ToString();
                    //计算合计金额
                    try
                    {

                        float Sumfamout = 0;
                        for (int i = 0; i <= dataGridView1.RowCount; i++)
                        {
                            Sumfamout = Sumfamout + Convert.ToSingle(dataGridView1["ColumnFSAmount", i].Value.ToString());

                            this.txtSumFamout.Text = Sumfamout.ToString();

                        }

                    }
                    catch { }
                    
                    
                    //添加一行
                    this.dataGridView1.Rows.Add();

                }
                catch
                {
                    MessageBox.Show("重量或单价错误！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    
                }

            
            }
            if ( e.ColumnIndex == 10 && e.RowIndex >= 0)
            {//更改辅助重量
                try
                {
                    this.dataGridView1["ColumnFSkQty", e.RowIndex].Value =
                      (Convert.ToSingle(this.dataGridView1["ColumnFSFQty", e.RowIndex].Value.ToString()) *
                   Convert.ToSingle(this.dataGridView1["ColumnFSecCoefficient", e.RowIndex].Value.ToString())).ToString();
                }
                catch
                {
                    MessageBox.Show("重量录入非法字符！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                   
                
                }
            


            }





        }

        private void txtFCustName_TextChanged(object sender, EventArgs e)
        {// 这里判断是否选中客户DataGridViewRowCollection.Add 
            if (this.FCustID!=null && this.FCustID!="" )
            {
                if (this.dataGridView1.Rows.Count == 0)
                {
                    this.dataGridView1.Rows.Add();//分录添加一项
                }
                //获取信用额度txtICCredit
                  SqlParameter param1 = new SqlParameter("@fcurid", SqlDbType.Int);
                   param1.Value =this.FCustID;
                 
                   //创建泛型
                   List<SqlParameter> parameters = new List<SqlParameter>();
                   parameters.Add(param1);
                 
                   //把泛型中的元素复制到数组中
                   SqlParameter[] inputParameters = parameters.ToArray();

                   DataTable dt = k3db.GetDataTable("sp_RYSEPLAN_GET_ICCreditInstant", inputParameters);
                   if (dt.Rows.Count == 1 && dt.Rows[0][0].ToString() != "-1.00")
                   {
                       txtICCredit.Text = dt.Rows[0][0].ToString();
                   }
                   else {
                       txtICCredit.Text ="";
                   }
                  

            
            }




        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {//保存
          //1 判断
            if (this.FCustID == "" || this.FCustID ==null)
            {
                MessageBox.Show("必须选择客户！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            
            }

            if (this.FEmpID == "" || this.FEmpID == null)
            {
                MessageBox.Show("必须选择业务员！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;

            }
            double ICCredit;
            ICCredit = Convert.ToSingle(this.txtICCredit.Text) + Convert.ToSingle(this.txtSumFamout.Text);
            if (this.txtICCredit.Text != "" && (Convert.ToSingle(this.txtICCredit.Text) + Convert.ToSingle(txtSumFamout.Text)) < 0)
            {

                MessageBox.Show("信用额度不足！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }


            



        }

        private void dataGridView1_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {//辅助单位选的是什么

            ComboBox cbb = new ComboBox();
            cbb = e.Control as ComboBox;
            
             

        }

     


   

   

        
     

   


     
    }
}
