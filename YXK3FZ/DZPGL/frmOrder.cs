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

namespace YXK3FZ.DZPGL
{
    public partial class frmDZPOrder : Form
    {

        DataBase db = new DataBase();
        //DataBase k3db = null;
        DataSet ds = null;
        CommonUse commUse = new CommonUse();
        //SqlDataAdapter sda = null;
        //帐套的链接
        string ZtType;//账套类型
        string ZtRyconstring;
        string fType;//类型 判断窗体是新增还是编辑状态 ADD EDIT SEL
        int isICC=1;//是否判断信用 根据白名单 1 是 0 否 -1 启用并小与信用
        int isFunitTou = 0;//单位是否只是头
        int isUPrice = 0;
        int PriceFrom = 0;//单价取值方向 0 肉业 1 食品

        int SELtype=0 ;//过滤类型 0 车次编号 1 客户
        
        //表头

          string Finterid;//内码
          string Fbillno;
          string Fstatus ;
          string FcurID;
          string FempName;
          //string Fpdate;//配送日期
          //string Fptime;//准确时间
          //string Fproperty;//配送性质
          string FdepID;//部门id
          //string Fcarnum;//车牌
          //string Fnote;//备注
          //string FSumFamout;//合计金额
          //string Fstatus;//0 待定 1 确认 2 审核
          //string FBillerName;//制单
          //string FcheckName;//审核
          string ordertablename = "yx_KJStock";
          string entrytablename = "yx_KJStockEntry";       
           
       
          string fnamenum = "";
         // string fitemid =null;
          //明细

          public frmDZPOrder(string zttype, string typestr, string billid)
          {
              //单据类型  如果是编剧状态 带 单据内码  否则单据内码=null

              InitializeComponent();
              this.ZtType = zttype;
              this.fType = typestr;  //窗体状态控制
              if (this.ZtType == "D")
              {
                  this.Tag = "114";
                  ds = db.GetDataSet("SELECT Fdbstr  FROM dbo.YXZTLIST WHERE ID=4", "con");

                  if (this.fType == "ADD")
                  {
                      this.Text = "筐具出入库订单--新增";
                  }
                  if (this.fType == "EDIT")
                  {
                      this.Text = "筐具出入库订单--修改";
                  }
                  if (this.fType == "SEL")
                  {
                      this.Text = "筐具出入库订单--查询";
                      this.Finterid = billid;
                  }

              }

              DataRow dr = ds.Tables[0].Rows[0];
              ZtRyconstring = dr["Fdbstr"].ToString(); //获取K3账套连接字符串


          }

          private void frmOrder_Load(object sender, EventArgs e)
          { 
              //窗体加载

              //权限控制 
              commUse.CortrolButtonEnabled(btnADD, this);
              commUse.CortrolButtonEnabled(tsbtnEdit, this);
              commUse.CortrolButtonEnabled(btnSave, this);
              commUse.CortrolButtonEnabled(btnConfirmer, this);
              commUse.CortrolButtonEnabled(btnHConfirmer, this);
              commUse.CortrolButtonEnabled(btnCheck, this);
              commUse.CortrolButtonEnabled(btnHcheck, this);

              if (this.fType == "ADD")  //初始编号 制单人 制单日期
              {  
                  if (btnADD.Enabled == false)
                  {
                      MessageBox.Show("没有权限!");
                      this.Close();
                  }

                  this.txtFbillno.Text = commUse.SelBillno("yx_KJStock", YXK3FZ.DataClass.DataBase.m_Connstr, "sp_YXDZP_SelBillno");
                  this.txtFBillerName.Text = PropertyClass.OperatorName;
                  this.DT_pdate.Value = DateTime.Now.AddDays(0);
                  this.txtFdate.Text = DateTime.Now.ToString("yyyy-MM-dd");

                  txtFcurname.Focus(); //聚焦光标

              }
              else if (this.fType == "SEL")
              {
                  this.selLoad(this.Finterid);
              } 


          }

          public void selLoad(string Finterid)
          {
              this.Text = "筐具出入库订单--查询";

              DataBase selDB = new DataBase(YXK3FZ.DataClass.DataBase.m_Connstr);
              string sqlstr = " SELECT * from yx_KJStock where FInterID='" + Finterid + "'  ";
              
              DataSet selds = selDB.GetDataSet(sqlstr, "sel");

              this.Fstatus = selds.Tables[0].Rows[0]["FStatus"].ToString(); //状态
              this.Fbillno = selds.Tables[0].Rows[0]["FBillNo"].ToString(); //单据编号  
              this.FcurID = selds.Tables[0].Rows[0]["FCarID"].ToString(); //车次编号

              this.txtFbillno.Text = this.Fbillno; //单据编号
              this.txtFcurname.Text = selds.Tables[0].Rows[0]["FCarID"].ToString(); //车次编号              
              this.DT_pdate.Value = DateTime.Parse(selds.Tables[0].Rows[0]["FDate"].ToString()); //配送日期
              this.txtFnote.Text = selds.Tables[0].Rows[0]["FNote"].ToString();//备注
              this.txtFBillerName.Text = selds.Tables[0].Rows[0]["FNewID"].ToString(); //制单人员
              this.txtFcheckName.Text = selds.Tables[0].Rows[0]["FCheckID"].ToString(); //审核人员
              this.txtFStause.Text = selds.Tables[0].Rows[0]["FStatus"].ToString();

              try  //制单日期
              {
                  this.txtFdate.Text = DateTime.Parse(selds.Tables[0].Rows[0]["FNewDate"].ToString()).ToString("yyyy-MM-dd");
              }
              catch
              {
                  this.txtFdate.Text = "";
              }
             
              try //审核日期
              {
                  this.txtFcheckdate.Text = DateTime.Parse(selds.Tables[0].Rows[0]["Fcheckdate"].ToString()).ToString("yyyy-MM-dd");
              }
              catch
              { 
                  this.txtFcheckdate.Text = "";
              }

             
              this.dataGridView2.Visible = false;
              this.txtFcurname.ReadOnly = true;             
              this.txtFnote.ReadOnly = true;

              //this.dgvDetail.CellValueChanged -= new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDetail_CellValueChanged);
              //this.dgvDetail.RowPostPaint -= new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dgvDetail_RowPostPaint);
              //this.dgvDetail.CellStateChanged -= new System.Windows.Forms.DataGridViewCellStateChangedEventHandler(this.dgvDetail_CellStateChanged);
              //this.dgvDetail.EditingControlShowing -= new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dgvDetail_EditingControlShowing);
             
             
              int dgvcount = this.dgvDetail.Rows.Count;

              dgvDetail.Rows.Clear(); //清空所有行

              sqlstr = " select  FCustID,FCustName,FSA,FOut05,FOut08,FIn05,FIn08 from yx_KJStockEntry  WHERE finterid='" + Finterid + "'   ";
              selds = selDB.GetDataSet(sqlstr, "sel");            


              this.dgvDetail.Rows.Add(selds.Tables[0].Rows.Count);

              for (int i = 0; i < selds.Tables[0].Rows.Count; i++)
              {
                  this.dgvDetail["colFCustID", i].Value = selds.Tables[0].Rows[i]["FCustID"].ToString();
                  this.dgvDetail["colFCustName", i].Value = selds.Tables[0].Rows[i]["FCustName"].ToString();
                  this.dgvDetail["colFOut05", i].Value = selds.Tables[0].Rows[i]["FOut05"].ToString();
                  this.dgvDetail["colFOut08", i].Value = selds.Tables[0].Rows[i]["FOut08"].ToString();
                  this.dgvDetail["colFIn05", i].Value = selds.Tables[0].Rows[i]["FIn05"].ToString();
                  this.dgvDetail["colFIn08", i].Value = selds.Tables[0].Rows[i]["FIn08"].ToString();
                  this.dgvDetail["colFSA", i].Value = selds.Tables[0].Rows[i]["FSA"].ToString();   
              }


              this.dgvDetail.ReadOnly = true;
          }

         

        private void textBox13_TextChanged(object sender, EventArgs e)
        {
            //录入车次编号显示过滤界面
            SELtype = 0;
            if (this.dataGridView2.Visible == false)
            {
                this.dataGridView2.Location = new Point(txtFcurname.Location.X, txtFcurname.Location.Y + this.panel1.Location.Y + txtFcurname.Height + 1);
                this.dataGridView2.Width = txtFcurname.Width;
                this.dataGridView2.Visible = true;
            }
            DataBase dbselFcur = new DataBase(ZtRyconstring);
            string sSQL = string.Empty;
           // sSQL = " SELECT DISTINCT F_102 AS 车次编号  FROM dbo.t_Organization WHERE  FDeleted=0 AND F_102 LIKE '%" + txtFcurname.Text.Trim() + "%' ";
            sSQL += " SELECT DISTINCT CASE WHEN LEN(F_102) <=2 THEN F_102 ELSE SUBSTRING(F_102,LEN(F_102)-2+1,2) END AS 车次编号 ";
            sSQL += " FROM dbo.t_Organization WHERE  FDeleted=0 ";
            sSQL += " AND CASE WHEN LEN(F_102) <=2 THEN F_102 ELSE SUBSTRING(F_102,LEN(F_102)-2+1,2) END LIKE '%" + txtFcurname.Text.Trim() + "%' ";
            this.dataGridView2.DataSource = dbselFcur.GetDataSet(sSQL,"selFcur").Tables[0];
           
        }

        private void dataGridView2_CellDoubleClick(object sender, DataGridViewCellEventArgs e) //选中客户后
        { 
            if (e.RowIndex > -1 && e.ColumnIndex > -1)
            {
                if (SELtype == 0)//选择车次编号
                {
                    #region 选择车次编号

                    this.FcurID = this.dataGridView2.CurrentRow.Cells[0].Value.ToString(); //获取当前选择的车次编号
                    txtFcurname.Text = this.FcurID.ToString(); //回写当前选择的车次编号

                    OnFcurIDGetBase(this.FcurID); //获得车次编号后，加载客户方法

                    if (this.fType == "ADD")
                    {
                        this.dgvDetail.Rows.Add(20);
                        this.dgvDetail.BeginEdit(true);
                        getFcurList(FcurID);
                    }

                    this.dataGridView2.DataSource = null;
                    this.dataGridView2.Visible = false;

                    #endregion
                }
                if (SELtype == 1)//选择客户
                {
                    add_ItemDataBese(this.dataGridView2.CurrentRow.Cells[1].Value.ToString(), //客户代码
                        this.dataGridView2.CurrentRow.Cells[2].Value.ToString(), //客户名称
                        this.dgvDetail.CurrentRow.Index);
                    this.dataGridView2.DataSource = null;
                    this.dataGridView2.Visible = false;
                }

            }
        }

        private void dgvDetail_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e) //显示序号
        {            
            SolidBrush b = new SolidBrush(this.dgvDetail.RowHeadersDefaultCellStyle.ForeColor);
            e.Graphics.DrawString((e.RowIndex + 1).ToString(System.Globalization.CultureInfo.CurrentUICulture), this.dgvDetail.DefaultCellStyle.Font, b, e.RowBounds.Location.X + 20, e.RowBounds.Location.Y + 4);

        }

        private void txtFcurname_KeyDown(object sender, KeyEventArgs e) //车次编号输入后，按回车事件
        {
            if (e.KeyCode == Keys.Enter)
            {
                DataBase dbselFcur1 = new DataBase(ZtRyconstring);
                DataSet dssel;

                string sSQL = string.Empty;
                // sSQL = " SELECT DISTINCT F_102 AS 车次编号  FROM dbo.t_Organization WHERE  FDeleted=0 AND F_102 LIKE '%" + txtFcurname.Text.Trim() + "%' ";
                sSQL += " SELECT DISTINCT CASE WHEN LEN(F_102) <=2 THEN F_102 ELSE SUBSTRING(F_102,LEN(F_102)-2+1,2) END AS 车次编号 ";
                sSQL += " FROM dbo.t_Organization WHERE  FDeleted=0 ";
                sSQL += " AND CASE WHEN LEN(F_102) <=2 THEN F_102 ELSE SUBSTRING(F_102,LEN(F_102)-2+1,2) END LIKE '%" + txtFcurname.Text.Trim() + "%' ";
           
                dssel = dbselFcur1.GetDataSet(sSQL,"selFcur");
                if (dssel.Tables[0].Rows.Count == 1)
                {
                    this.FcurID = dssel.Tables[0].Rows[0][0].ToString();
                    //获得客户id后调用加载信息方法
                    OnFcurIDGetBase(this.FcurID);
                    if (this.fType == "ADD")
                    {
                        this.dgvDetail.Rows.Add(20);
                        this.dgvDetail.BeginEdit(true);
                        getFcurList(FcurID);

                    }
                    this.dataGridView2.Visible = false;
                }
                else
                {
                    SELtype = 0;
                    if (this.dataGridView2.Visible == false)
                    {
                        this.dataGridView2.Location = new Point(txtFcurname.Location.X, txtFcurname.Location.Y + this.panel1.Location.Y + txtFcurname.Height + 1);
                        this.dataGridView2.Width = txtFcurname.Width;
                        this.dataGridView2.Visible = true;
                    }
                    DataBase dbselFcur = new DataBase(ZtRyconstring);
                     this.dataGridView2.DataSource=dbselFcur.GetDataSet(sSQL,"selFcur").Tables[0];                  
                    
                }
            }
        } 
        
        public void getFcurList(string FcurID)  //根据选择的车次编号来填充明细表格
        {
            #region 根据选择的车次编号来填充明细表格

            dgvDetail.Rows.Clear(); //清空

            string sSQL = string.Empty;
            sSQL += " SELECT fnumber AS FCustID,fname AS FCustName, ";
            sSQL += " '' AS FIn05,'' AS FIn08, ";
            sSQL += " '' AS FOut05,'' AS FOut08 ";
            sSQL += " FROM dbo.t_Organization  ";
            sSQL += "  WHERE  FDeleted=0 AND F_102='" + FcurID + "' ";


            sSQL = string.Empty;
            sSQL += " SELECT R.fnumber AS FCustID,R.fname AS FCustName,P.FName AS FSA,   ";
            sSQL += "  '' AS FIn05,'' AS FIn08,  ";
            sSQL += " cast(SUM(E.Fauxqty) as int) AS FOut05,'' AS FOut08  ";
            sSQL += " FROM dbo.t_Organization  R      ";  //客户表
            sSQL += " INNER JOIN SeOrder S ON R.FItemID=S.FCustID    "; //销售定单主表
            sSQL += " INNER JOIN SeOrderEntry E ON S.FInterID=E.FInterID  ";//销售明细表
            sSQL += "  INNER JOIN t_Item  T ON T.FItemID=E.FItemID  "; //物料基础表
            sSQL += "  INNER JOIN t_MeasureUnit M ON m.FItemID=e.FUnitID      ";//计量单位表
            sSQL += " inner join t_Emp P ON P.FItemID=S.FEmpID  ";

            sSQL += " WHERE  R.FDeleted=0 AND S.FDate='"+DT_pdate.Text+"'    ";
            sSQL += " AND  CASE WHEN LEN(F_102) <=2 THEN F_102 ELSE SUBSTRING(F_102,LEN(F_102)-2+1,2) END ='" + FcurID + "'  ";
            sSQL += " AND( T.FNumber ='8.01.004' AND m.FName='板2'   "; //卤水老豆腐
            sSQL += " OR T.FNumber ='8.01.016' AND m.FName='板4'   ";//家常豆腐
            sSQL += " OR T.FNumber ='8.06.006' AND m.FName='板5'   ";//仙草冻
            sSQL += "  OR T.FNumber ='8.01.007' AND m.FName='板3'   ";//本地豆干
            sSQL += "  OR T.FNumber ='8.01.015' AND m.FName='板2'   ";//发菜豆腐
            sSQL += " OR T.FNumber ='8.01.001' AND m.FName='板1'   ";//水豆腐
            sSQL += "  ) GROUP BY R.fnumber ,R.fname,P.FName ";

            DataBase dbsel = new DataBase(this.ZtRyconstring);
            DataSet  dssel = dbsel.GetDataSet(sSQL, "dttTemp");

            if (dssel.Tables[0].Rows.Count <= 0) //如果没有数据，返回
            {
                return;
            }

            this.dgvDetail.Rows.Add(dssel.Tables[0].Rows.Count);

            for (int i = 0; i < dssel.Tables[0].Rows.Count; i++)
            {
                this.dgvDetail["colFCustID", i].Value = dssel.Tables[0].Rows[i]["FCustID"].ToString();
                this.dgvDetail["colFCustName", i].Value = dssel.Tables[0].Rows[i]["FCustName"].ToString();
                this.dgvDetail["colFOut05", i].Value = dssel.Tables[0].Rows[i]["FOut05"].ToString();
                
                this.dgvDetail["colFOut08", i].Value = dssel.Tables[0].Rows[i]["FOut08"].ToString();
                this.dgvDetail["colFIn05", i].Value = dssel.Tables[0].Rows[i]["FIn05"].ToString();
               
                this.dgvDetail["colFIn08", i].Value = dssel.Tables[0].Rows[i]["FIn08"].ToString();

                this.dgvDetail["colFSA", i].Value = dssel.Tables[0].Rows[i]["FSA"].ToString();
            }
            
            this.dgvDetail.Rows[0].Selected = true;

            #endregion
        }
   




        private void dgvDetail_CellStateChanged(object sender, DataGridViewCellStateChangedEventArgs e)
        {
          
        }

        private void dgvDetail_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        { 
            //单元格的值变化时
            if (e.RowIndex > -1 && e.ColumnIndex > -1)
            {

            }
        }

        public DataGridViewTextBoxEditingControl dgvTxt = null; // 声明 一个 CellEdit 

        // 自定义事件KeyPress事件

        private void Cells_KeyPress(object sender, KeyPressEventArgs e)
        {
            keyPressXS(e, dgvTxt);
        }

        public static void keyPressXS(KeyPressEventArgs e, DataGridViewTextBoxEditingControl dgvTxt)
        {
            if (char.IsNumber(e.KeyChar) || e.KeyChar == (char)Keys.Back)
            {
                e.Handled = false;       //让操作生效 
            }
            else
            {
                e.Handled = true;
            }

        }

        private void dgvDetail_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            //单元格变化时            
            int row = this.dgvDetail.CurrentCell.RowIndex;//行
            int col = this.dgvDetail.CurrentCell.ColumnIndex;//列   

            //MessageBox.Show("行号:" + row.ToString() + "，列号:" + col.ToString());
            //return;

            //if (row != 0) //
            //{
            //    if (this.dgvDetail["colFCustID", row - 1].Value.ToString() == "" ||
            //        this.dgvDetail["colFOut05", row - 1].Value == null ||
            //     this.dgvDetail["colFOut06", row - 1].Value == null ||
            //     this.dgvDetail["colFOut08", row - 1].Value == null)
            //    {
            //        MessageBox.Show("上一行数据不完整");
            //        this.dgvDetail.Rows[row - 1].Selected = true;
            //        return;
            //    }
            //}
            

            if (col == 1)//如果是第一格，选择客户 
            {
                TextBox tb = e.Control as TextBox;
                tb.KeyPress += new KeyPressEventHandler(tb_KeyPress);
                //fnamenum = tb.Text;
                //tb.TextChanged += new EventHandler(tb_TextChanged);
            }
            else
            {
                this.dataGridView2.DataSource = null;
                this.dataGridView2.Visible = false;
            }
          

            if (col >= 2)
            {
                dgvTxt = (DataGridViewTextBoxEditingControl)e.Control; // 赋值 
                dgvTxt.SelectAll();
                dgvTxt.KeyPress += Cells_KeyPress; // 绑定到事件 
            }

        }

        void tb_TextChanged(object sender, EventArgs e)
        {
            
        }

        void tb_KeyPress(object sender, KeyPressEventArgs e)
        {
            //文本变化时  在单元格变化时调用
            SELtype = 1; //客户
          
           int row = this.dgvDetail.CurrentCell.RowIndex;//行
           int col = this.dgvDetail.CurrentCell.ColumnIndex;

            if (col == 1)//指定单元格是客户名称是才处理
            {
                dataGridView2.Width = 271;

                this.dataGridView2.Location = new Point(this.dgvDetail.Location.X,
                         panel1.Location.Y + dgvDetail.GetCellDisplayRectangle(this.dgvDetail.CurrentCell.ColumnIndex, this.dgvDetail.CurrentCell.RowIndex, false).Y +
                         panel2.Location.Y + this.dgvDetail.Location.Y);


                if (this.dgvDetail.CurrentCell.EditedFormattedValue.ToString() != "")//用dgvDetail.CurrentCell.EditedFormattedValue取得正在编辑的值
                {
                    string sqlstr = " SELECT FItemID, fnumber AS 客户代码,fname AS 客户名称 FROM dbo.t_Organization WHERE  FDeleted=0 AND fname+fnumber LIKE '%" +
                                      this.dgvDetail.CurrentCell.EditedFormattedValue.ToString() + "%'   ";

                        

                    DataBase dbselFitem = new DataBase(ZtRyconstring);
                    this.dataGridView2.DataSource = dbselFitem.GetDataSet(sqlstr, "sel").Tables[0];
                    this.dataGridView2.Columns[0].Visible = false;

                    this.dataGridView2.Visible = true;

                }
                else
                {
                    this.dataGridView2.DataSource = null;
                    this.dataGridView2.Visible = false;
                }
            }

        }
      

        //获得客户id后调用加载信息方法
        public void OnFcurIDGetBase(string FcurID)
        {
            //DataBase dbselFcur = new DataBase(ZtRyconstring); 
         
            //if (isICC != 0)
            //{
            //    //取得即时信用额度
            //    SqlParameter param = new SqlParameter("@FcurIDs", SqlDbType.VarChar);
            //    param.Value = FcurID;
            //    //创建泛型
            //    List<SqlParameter> parameters = new List<SqlParameter>();
            //    parameters.Add(param);
            //    //把泛型中的元素复制到数组中
            //    SqlParameter[] inputParameters = parameters.ToArray();

            //    YXK3FZ.DataClass.DataBase ztdb = new YXK3FZ.DataClass.DataBase(ZtRyconstring);
            //    DataSet dsIcc = ztdb.GetProcDataSet("yx_sp_getICCredit", inputParameters);
                
            //}

            //string sSQL = string.Empty;
            //sSQL += " SELECT fnumber AS FCustID,fname AS FCustName, ";
            //sSQL += " '' AS FIn05,'' AS FIn06,'' AS FIn08, ";
            //sSQL += " '' AS FOut05,'' AS FOut06,'' AS FOut08 ";
            //sSQL += " FROM dbo.t_Organization  ";
            //sSQL += "  WHERE  FDeleted=0 AND F_102='" + FcurID + "' ";

            //DataSet ds = dbselFcur.GetDataSet(sSQL, "dttSQL");
            //dgvDetail.DataSource = ds.Tables[0].DefaultView;



            //dgvEditStasue();
            
            
         

           
            


        }

        public void dgvEditStasue()
        {
            this.dgvDetail.ReadOnly =false;

            //this.dgvDetail.Columns["Column_Fnumber"].ReadOnly = true;
            //this.dgvDetail.Columns["Column_Fmodel"].ReadOnly = true;
            //this.dgvDetail.Columns["Column_FConversion"].ReadOnly = true;
            //this.dgvDetail.Columns["Column_K3unitname"].ReadOnly = true;
            //this.dgvDetail.Columns["Column_K3Qty"].ReadOnly = true;
            //this.dgvDetail.Columns["Column_JYqty"].ReadOnly = true;
            //this.dgvDetail.Columns["Column_Famout"].ReadOnly = true;
            //this.dgvDetail.Columns["Column_Fprice"].ReadOnly = true;  
        
        }

        public int GetisICC(string FcurID, string FdepID)
        {  
            //判断是否启用信用 
            int isICC = 0;
            DataBase dbIcc = new DataBase(ZtRyconstring);
            SqlParameter param1 = new SqlParameter("@FcurID", SqlDbType.VarChar);
            param1.Value = FcurID;
            SqlParameter param2 = new SqlParameter("@FdepID", SqlDbType.VarChar);
            param2.Value = FdepID;
            //创建泛型
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(param1);
            parameters.Add(param2);
            //把泛型中的元素复制到数组中
            SqlParameter[] inputParameters = parameters.ToArray();
            isICC = Convert.ToInt16(dbIcc.GetProcDataSet("sp_yx_GetIsIcc", inputParameters).Tables[0].Rows[0][0].ToString());
            return isICC;
        }

        public int GetPriceFrom(string FcurID, string FdepID)
        {  //判断单价取值方向
            int PFrom = 0;
            DataBase dbIcc = new DataBase(ZtRyconstring);
            SqlParameter param1 = new SqlParameter("@FcurID", SqlDbType.VarChar);
            param1.Value = FcurID;
            SqlParameter param2 = new SqlParameter("@FdepID", SqlDbType.VarChar);
            param2.Value = FdepID;
            //创建泛型
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(param1);
            parameters.Add(param2);
            //把泛型中的元素复制到数组中
            SqlParameter[] inputParameters = parameters.ToArray();
            PFrom = Convert.ToInt16(dbIcc.GetProcDataSet("sp_yx_GetPriceFrom", inputParameters).Tables[0].Rows[0][0].ToString());
            return PFrom;
        }

        public int GetIsFunitTou(string FcurID, string FdepID)
        {  
            //判断单价取值方向
            int IsFunitTou = 0;
            DataBase dbIcc = new DataBase(ZtRyconstring);
            SqlParameter param1 = new SqlParameter("@FcurID", SqlDbType.VarChar);
            param1.Value = FcurID;
            SqlParameter param2 = new SqlParameter("@FdepID", SqlDbType.VarChar);
            param2.Value = FdepID;
            //创建泛型
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(param1);
            parameters.Add(param2);
            //把泛型中的元素复制到数组中
            SqlParameter[] inputParameters = parameters.ToArray();
            IsFunitTou = Convert.ToInt16(dbIcc.GetProcDataSet("sp_yx_isfunitTou", inputParameters).Tables[0].Rows[0][0].ToString());
            return IsFunitTou;
        }

        public int GetisUPrice(string FcurID, string FdepID)
        {  
            //判断单价取值方向
            int IsFunitTou = 0;
            DataBase dbIcc = new DataBase(ZtRyconstring);
            SqlParameter param1 = new SqlParameter("@FcurID", SqlDbType.VarChar);
            param1.Value = FcurID;
            SqlParameter param2 = new SqlParameter("@FdepID", SqlDbType.VarChar);
            param2.Value = FdepID;
            //创建泛型
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(param1);
            parameters.Add(param2);
            //把泛型中的元素复制到数组中
            SqlParameter[] inputParameters = parameters.ToArray();
            IsFunitTou = Convert.ToInt16(dbIcc.GetProcDataSet("sp_yx_isUPrice", inputParameters).Tables[0].Rows[0][0].ToString());
            return IsFunitTou;
        }





        /// <summary>
        /// //根据客户选定行填充客户信息
        /// </summary>
        /// <param name="sCustomerID">客户代码</param>
        /// <param name="sCustomerName">客户名称</param>
        /// <param name="row"></param>
        public void add_ItemDataBese(string sCustomerID,string sCustomerName, int row)
        {
            this.dgvDetail["colFCustID", row].Value = sCustomerID; 
            this.dgvDetail["colFCustName", row].Value = sCustomerName;

            string sSQL = string.Empty;
            sSQL += " SELECT R.fnumber AS FCustID,R.fname AS FCustName,P.FName AS FSA,  ";
            sSQL += "  '' AS FIn05,'' AS FIn08,  ";
            sSQL += " cast(SUM(E.Fauxqty) as int) AS FOut05,'' AS FOut08  ";
            sSQL += " FROM dbo.t_Organization  R      ";  //客户表
            sSQL += " INNER JOIN SeOrder S ON R.FItemID=S.FCustID    "; //销售定单主表
            sSQL += " INNER JOIN SeOrderEntry E ON S.FInterID=E.FInterID  ";//销售明细表
            sSQL += "  INNER JOIN t_Item  T ON T.FItemID=E.FItemID  "; //物料基础表
            sSQL += "  INNER JOIN t_MeasureUnit M ON m.FItemID=e.FUnitID      ";//计量单位表
            sSQL += " inner join t_Emp P ON P.FItemID=S.FEmpID  ";

            sSQL += " WHERE  R.FDeleted=0 AND S.FDate='" + DT_pdate.Text + "' And R.FNumber='" + sCustomerID + "'   ";
           // sSQL += " AND  CASE WHEN LEN(F_102) <=2 THEN F_102 ELSE SUBSTRING(F_102,LEN(F_102)-2+1,2) END ='" + FcurID + "'  ";
            sSQL += " AND( T.FNumber ='8.01.004' AND m.FName='板2'   "; //卤水老豆腐
            sSQL += " OR T.FNumber ='8.01.016' AND m.FName='板4'   ";//家常豆腐
            sSQL += " OR T.FNumber ='8.06.006' AND m.FName='板5'   ";//仙草冻
            sSQL += "  OR T.FNumber ='8.01.007' AND m.FName='板3'   ";//本地豆干
            sSQL += "  OR T.FNumber ='8.01.015' AND m.FName='板2'   ";//发菜豆腐
            sSQL += " OR T.FNumber ='8.01.001' AND m.FName='板1'   ";//水豆腐
            sSQL += "  ) GROUP BY R.fnumber ,R.fname,P.FName ";


            DataBase dbselFitem = new DataBase(ZtRyconstring);
            DataTable dttSQL = dbselFitem.GetDataSet(sSQL, "sel").Tables[0];
            if (dttSQL.Rows.Count > 0)
            {
                this.dgvDetail["colFOut05", row].Value = dttSQL.Rows[0]["FOut05"];
                this.dgvDetail["colFSA", row].Value = dttSQL.Rows[0]["FSA"];
            }
            else
            {
                this.dgvDetail["colFOut05", row].Value = "";
                this.dgvDetail["colFSA", row].Value = "";
            }
           
            this.dgvDetail["colFOut08", row].Value = "";
            this.dgvDetail["colFIn05", row].Value = "";
           
            this.dgvDetail["colFIn08", row].Value = "";
        }

        public void add_ItemDataBese(string fitemid,int row)//根据物料内码填充行的产品信息
        {

            DataBase dbItem = new DataBase(ZtRyconstring);
            SqlParameter param1 = new SqlParameter("@ItemID", SqlDbType.VarChar);
            param1.Value = fitemid;
            SqlParameter param2 = new SqlParameter("@FcurID", SqlDbType.VarChar);
            param2.Value = FcurID;
            SqlParameter param3 = new SqlParameter("@FdepID", SqlDbType.VarChar);
            param3.Value = FdepID;
            //创建泛型
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(param1);
            parameters.Add(param2);
            parameters.Add(param3);
            //把泛型中的元素复制到数组中
            SqlParameter[] inputParameters = parameters.ToArray();

            DataSet dsitem = dbItem.GetProcDataSet("sp_yx_getItemDataBase", inputParameters);

            //int row;
            //row = this.dgvDetail.CurrentCell.RowIndex;//行
            if (dsitem.Tables[0].Rows.Count == 1)
            { //如果输入的代码只有一个产品直接赋值

                this.dgvDetail["Column_Fitemid", row].Value = dsitem.Tables[0].Rows[0][0].ToString(); ;// finterid
           

                this.dgvDetail["Column_fname", row].Value = dsitem.Tables[0].Rows[0][1].ToString(); ;//fnumber
                
                this.dgvDetail["Column_fnumber", row].Value = dsitem.Tables[0].Rows[0][2].ToString(); ;//fname
                this.dgvDetail["Column_fmodel", row].Value = dsitem.Tables[0].Rows[0][3].ToString(); ;//fmodel
                
               
           
                if (this.ZtType=="R")
                {
                    this.dgvDetail["Column_FunitName", row].Value = "公斤";
                    this.dgvDetail["Column_Fprice", row].Value = dsitem.Tables[0].Rows[0][4].ToString(); ;//FKUnitID
                    if (this.dgvDetail["Column_Fprice", row].Value == null || this.dgvDetail["Column_Fprice", row].Value.ToString() == "")
                    {
                        MessageBox.Show("没有该产品的单价，请到K3中添加！");
                        return;
                    }

                }
                if (this.ZtType == "S" )
                {
                    this.dgvDetail["Column_Fprice", row].Value = dsitem.Tables[0].Rows[0][4].ToString(); ;//FKUnitID
                    if (this.dgvDetail["Column_Fprice", row].Value == null || this.dgvDetail["Column_Fprice", row].Value.ToString() == "")
                    {
                        MessageBox.Show("没有该产品的单价，请到K3中添加！");
                        return;
                    }
                    this.dgvDetail["Column_FunitName", row].Value = "头";
                }
                if (this.ZtType == "M")
                {
                  
                    this.dgvDetail["Column_FunitName", row].Value = "头";
                }


                this.dgvDetail["Column_K3unitname", row].Value = "公斤";
                //调用获取换算率的方法
                string Conversion = this.getItemUnitFConversion(this.dgvDetail["Column_Fitemid", row].Value.ToString(), 
                                                                this.dgvDetail["Column_FunitName", row].Value.ToString(),
                                                                this.dgvDetail["Column_K3unitname", row].Value.ToString());
                if (Conversion == null)
                {
                    MessageBox.Show("没有改产品的单位换算，请先到单位设置中添加！");
                    return;

                }
                else
                {
                    this.dgvDetail["Column_FConversion", row].Value = Conversion;            
                }
                //获取结余数量
                  //todo 
               // this.dgvDetail["Column_JYqty", row].Value = dsitem.Tables[0].Rows[0][5].ToString(); ;//
                //
              
                this.dgvDetail.CurrentCell = dgvDetail["Column_FQty", row]; //设置辅助重量单元格获得焦点
                //dgvDetail.BeginEdit(true);

            }

             
        }

        public string  getItemUnitFConversion(string fitemid,string unitname,string k3unitname)
        {
            //取得换算率
            string FConversion =null;
            string sqlstr = "";
            if (unitname == k3unitname)
            {
                FConversion = "1";
            
            }
            else
            {
                if (this.ZtType == "R")
                {
                    sqlstr = "SELECT FConversion FROM yx_icitem WHERE Fitemid=" + fitemid + " AND FUnitName='" + unitname + "'";

                }
                if (this.ZtType == "S" || this.ZtType == "M")
                {
                    sqlstr = "SELECT FConversion FROM AIS_YXRY2.DBO.yx_icitem WHERE FNUMBER=(SELECT FNUMBER FROM T_ICITEM WHERE FITEMID=" + 
                                     fitemid + ") AND FUnitName='" + unitname + "'";

                }
                
                
                DataBase dbCon = new DataBase(ZtRyconstring);
                try
                {
                    
                    FConversion = dbCon.GetDataSet(sqlstr, "Conversion").Tables[0].Rows[0][0].ToString();
                }
                catch
                {
                    FConversion = null;
                }
            
            }




            return FConversion;
        
        
        }




        private void 添加新行ToolStripMenuItem_Click(object sender, EventArgs e) //右击添加一行
        {
            //添加一行
            if (this.fType != "SEL")
            {
                this.dgvDetail.Rows.Add();
            }
            else
            {
                MessageBox.Show("查询模式无法操作");
                return;
            }
        }

        private void 保存ToolStripMenuItem_Click(object sender, EventArgs e) //右击保存
        {
            if (this.fType != "SEL")
            {
                if (this.btnSave.Enabled == true)
                {
                    btnSave_Click(null, null);
                }
                else
                {
                    MessageBox.Show("没有权限！");
                }
            }
            else
            {
                MessageBox.Show("查询模式无法操作");
                return;
            }
        }

        private void M_deleterow_Click(object sender, EventArgs e) //右击删除当前行    
        {
            //删除当前行  
            if (this.fType != "SEL")
            {
                if (dgvDetail.Rows.Count > 0)
                {
                    this.dgvDetail.Rows.RemoveAt(this.dgvDetail.CurrentCell.RowIndex);
                }
                else
                {
                    MessageBox.Show("无数据可以删除");
                    return;
                }
            }
            else
            {
                MessageBox.Show("查询模式无法操作");
                return;
            }
        }



        private void btnADD_Click(object sender, EventArgs e) //新增
        {
            //清空
            this.Finterid = "0";
            this.Fstatus = "未审核";
            this.Fbillno = "";
            this.FcurID = "0";
            this.FdepID = "";

            this.txtFBillerName.Text = PropertyClass.OperatorName; //制单人
            this.DT_pdate.Value = DateTime.Now.AddDays(0); //配送日期
            this.txtFdate.Text = DateTime.Now.ToString("yyyy-MM-dd"); //制单日期

            this.txtFbillno.Text = commUse.SelBillno("yx_KJStock", YXK3FZ.DataClass.DataBase.m_Connstr, "sp_YXDZP_SelBillno");

            this.txtFcurname.Text = "";        //车次编号         
            this.txtFnote.Text = "";          //备注 
            this.txtFcheckName.Text = "";     //审核人      
            this.txtFcheckdate.Text = "";    //审核日期
            this.txtFStause.Text = "";      //状态

            this.dataGridView2.Visible = false;
            this.txtFcurname.ReadOnly = false;           
            this.txtFnote.ReadOnly = false;  

            int dgvcount = this.dgvDetail.Rows.Count;
            for (int i = 0; i < dgvcount; i++)
            {
                this.dgvDetail.Rows.RemoveAt(0);
            }
           
            if (this.fType == "SEL")
            {
                this.dgvDetail.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDetail_CellValueChanged);
                this.dgvDetail.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dgvDetail_RowPostPaint);
                this.dgvDetail.CellStateChanged += new System.Windows.Forms.DataGridViewCellStateChangedEventHandler(this.dgvDetail_CellStateChanged);
                this.dgvDetail.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dgvDetail_EditingControlShowing);
            }


            this.dgvDetail.ReadOnly = false;
            this.fType = "ADD";
            this.Text = "筐具出入库订单__新增";


        }

        private void tsbtnEdit_Click(object sender, EventArgs e) //编辑
        {            
            if (this.fType == "ADD") { return; }

            if (this.fType == "SEL")
            {
                if (this.Fstatus=="已审核" )
                {
                    MessageBox.Show("该单据状态不允许编辑！");
                    return;

                }

                OnFcurIDGetBase(FcurID);

                this.dataGridView2.Visible = false;
                this.txtFcurname.ReadOnly = false;
                this.txtFnote.ReadOnly = false;

               

                this.dgvDetail.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDetail_CellValueChanged);
                this.dgvDetail.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dgvDetail_RowPostPaint);
                this.dgvDetail.CellStateChanged += new System.Windows.Forms.DataGridViewCellStateChangedEventHandler(this.dgvDetail_CellStateChanged);
                this.dgvDetail.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dgvDetail_EditingControlShowing);
                //this.dgvDetail.ReadOnly = false;
                dgvEditStasue();
                //this.dgvDetail.Rows.Add(5);
                this.fType = "EDIT";
                this.Text = "筐具出入库订单__修改";

            }



        }
        
        public int save_checkorder() //保存前判断
        {
            int isPass = 0;

            if (dgvDetail.Rows.Count == 0)
            {
                MessageBox.Show("至少要有一行明细");
                return isPass;
            }

            for (int i = 0; i < dgvDetail.Rows.Count; i++) //判断列表数据填写完整
            {
                for (int j = 1; j < dgvDetail.Columns.Count; j++)   // i 行号   j 列号(从1下标开始)
                {
                    if (fType == "EDIT") //如果是修改保存（判断 进 出）
                    {
                        if (this.dgvDetail[j, i].Value == null || this.dgvDetail[j, i].Value.ToString() == "")
                        {
                            MessageBox.Show("请把行:" + (i + 1) + ",列:" + j + ",数据填写完整(" + this.dgvDetail.Columns[j].HeaderText.Replace("       ", "").Trim() + ")");
                            this.dgvDetail.CurrentCell = this.dgvDetail.Rows[i].Cells[j];
                            return isPass;
                        }

                    }
                    else //如果是新增保存(只判断 出)
                    {
                        if (j <= 3 && j > 1)
                        {
                            if (this.dgvDetail[j, i].Value == null || this.dgvDetail[j, i].Value.ToString() == "")
                            {
                                MessageBox.Show("请把行:" + (i + 1) + ",列:" + j + ",数据填写完整(" + this.dgvDetail.Columns[j].HeaderText.Replace("       ", "").Trim() + ")");
                                this.dgvDetail.CurrentCell = this.dgvDetail.Rows[i].Cells[j];
                                return isPass;
                            }
                        }
                    }
                }
            }

            isPass = 1;

            return isPass;
        }

        private void btnSave_Click(object sender, EventArgs e) //保存
        {
            if (this.fType == "SEL")
            {
                MessageBox.Show("查询模式下不能保存");
                return;
            }

            this.dgvDetail.EndEdit();          
          
            int isPass;
            isPass = this.save_checkorder();

            if (isPass != 1)//检查通过
            {
                return;
            }

            List<string> Insertsql = new List<string>();
            if (this.fType == "ADD") //新增获取
            {
                Finterid = commUse.GetlBillID(ordertablename, YXK3FZ.DataClass.DataBase.m_Connstr,"sp_YXDZP_GetBillID");
                Fbillno = commUse.GetlBillno(ordertablename, YXK3FZ.DataClass.DataBase.m_Connstr, "sp_YXDZP_GetBillno");
            }            

            if (this.fType == "EDIT") //修改
            {
                Insertsql.Add(" DELETE " + entrytablename + " WHERE FInterID=" + Finterid);
                Insertsql.Add(" DELETE " + ordertablename + " WHERE FInterID=" + Finterid);
            }

            object colFOut05;
            object colFOut06 ;
            object colFOut08 ;
            object colFIn05 ;
            object colFIn06 ;
            object colFIn08;

            for (int i = 0; i < this.dgvDetail.Rows.Count; i++)
            {
                #region 处理DBNULL

                if (this.dgvDetail["colFOut05", i].Value == null || this.dgvDetail["colFOut05", i].Value.ToString() == "")
                {
                    colFOut05 = "NULL";
                }
                else
                {
                    colFOut05 = this.dgvDetail["colFOut05", i].Value;
                }                

                if (this.dgvDetail["colFOut08", i].Value == null || this.dgvDetail["colFOut08", i].Value.ToString() == "")
                {
                    colFOut08 = "NULL";
                }
                else
                {
                    colFOut08 = this.dgvDetail["colFOut08", i].Value;
                }

                if (this.dgvDetail["colFIn05", i].Value == null || this.dgvDetail["colFIn05", i].Value.ToString() == "")
                {
                    colFIn05 = "NULL";
                }
                else
                {
                    colFIn05 = this.dgvDetail["colFIn05", i].Value;
                }               

                if (this.dgvDetail["colFIn08", i].Value == null || this.dgvDetail["colFIn08", i].Value.ToString() == "")
                {
                    colFIn08 = "NULL";
                }
                else
                {
                    colFIn08 = this.dgvDetail["colFIn08", i].Value;
                }               

                #endregion


                string Esql = ""; //明细表
                Esql = "  INSERT INTO " + entrytablename + " ( FInterID ,FCustID ,FCustName,FSA,FOut05 ,FOut08 ," +
                           " FIn05 ,FIn08 ) VALUES  (" +
                              Finterid + " ,'" +
                             this.dgvDetail["colFCustID", i].Value.ToString() + "' , '" +
                             this.dgvDetail["colFCustName", i].Value.ToString() + "' , '" +
                             this.dgvDetail["colFSA", i].Value.ToString() + "' , " +
                             colFOut05 + " ," +

                             colFOut08 + " ," +
                             colFIn05 + " ," +

                             colFIn08 + " )";



                Insertsql.Add(Esql);

            }
            string PSql = ""; //主表
            PSql = "INSERT INTO " + ordertablename + " ( FInterID ,FBillNo , FCarID ,FDate ,FStatus,FNote ,FNewID ,FNewDate" +
                                " ) VALUES  (" +
                                Finterid + ",'" + Fbillno + "'," + this.FcurID + ",'" + this.DT_pdate.Value.ToString("yyyy-MM-dd") +
                                "','未审核','" +
                                this.txtFnote.Text + "','" + PropertyClass.OperatorName + "','" + DateTime.Now.ToString("yyyy-MM-dd") + "')";

            Insertsql.Add(PSql);   


            DataBase insertDB = new DataBase(YXK3FZ.DataClass.DataBase.m_Connstr);
            try
            {
                bool IsSuccess = insertDB.ExecDataBySqls(Insertsql);
                if (IsSuccess == false)
                {
                    MessageBox.Show("保存失败！");
                    LabTishi.Text = "保存失败!请查看单据后联系管理员处理！";
                    return;

                }
                else
                {
                    LabTishi.Text = "保存成功！";
                    this.fType = "SEL";
                }

            }
            catch
            {
                MessageBox.Show("保存失败！");
                LabTishi.Text = "保存失败!请查看单据后联系管理员处理！";
                return;
            }

            this.selLoad(this.Finterid);

        }

       

        
        
        
        private void btnConfirmer_Click(object sender, EventArgs e)
        {
            if (this.fType!="SEL")
            {
                MessageBox.Show("该单据还没有保存！");
                return;
            
            }
            if (MessageBox.Show("确认要确认该单据？", "消息对话框！", MessageBoxButtons.YesNoCancel,
                MessageBoxIcon.Warning,MessageBoxDefaultButton.Button1)!=DialogResult.Yes)
           {
               return;
           }
            if (Int32.Parse(this.Fstatus) != 0)
            {
                MessageBox.Show("不允许确认！");
                return;
            
            }
            string updateSql = " UPDATE dbo.yx_order SET Fstatus=1,FConfirmerName='"+PropertyClass.OperatorName+"',FConfirmerdate='" +
                               DateTime.Now.ToString("yyyy-MM-dd") + "' WHERE Finterid=" + Finterid ;
            if (this.ZtType == "M")
            {
             updateSql = " UPDATE dbo.yx_orderM SET Fstatus=1,FConfirmerName='" + PropertyClass.OperatorName + "',FConfirmerdate='" +
                                DateTime.Now.ToString("yyyy-MM-dd") + "' WHERE Finterid=" + Finterid;
            
            }


            try {
                DataBase upDb = new DataBase(this.ZtRyconstring);
               upDb.ExecDataBySql(updateSql);
               MessageBox.Show("确认成功" );
              
             
            
            }
            catch(Exception ex)
            {
                MessageBox.Show("确认失败！原因："+ex.ToString());
                return;
            }
    

        }

        private void btnHConfirmer_Click(object sender, EventArgs e)
        {
            if (this.fType != "SEL")
            {
                MessageBox.Show("该单据还没有保存！");
                return;

            }
            if (MessageBox.Show("确认要反确认该单据？", "消息对话框！", MessageBoxButtons.YesNoCancel,
              MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1) != DialogResult.Yes)
            {
                return;
            }


            if (Int32.Parse(this.Fstatus) != 1)
            {
                MessageBox.Show("单据状态不允许反确认！");
                return;

            }
            string updateSql = " UPDATE dbo.yx_order SET Fstatus=0,FConfirmerName='',FConfirmerdate=null  WHERE Finterid=" + Finterid;

            if (this.ZtType == "M")
            {
                updateSql = " UPDATE dbo.yx_orderM SET Fstatus=0,FConfirmerName='',FConfirmerdate=null  WHERE Finterid=" + Finterid;

            }


            try
            {
                DataBase upDb = new DataBase(this.ZtRyconstring);
                upDb.ExecDataBySql(updateSql);
                MessageBox.Show("反确认成功");

                

            }
            catch (Exception ex)
            {
                MessageBox.Show("反确认失败！原因：" + ex.ToString());
                return;
            }


        }

        private void btnCheck_Click(object sender, EventArgs e)
        {
            if (this.fType != "SEL")
            {
                MessageBox.Show("该单据还没有保存！");
                return;

            }
            if (MessageBox.Show("确认要审核该单据？", "消息对话框！", MessageBoxButtons.YesNoCancel,
           MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1) != DialogResult.Yes)
            {
                return;
            }


            if (Int32.Parse(this.Fstatus) !=1)
            {
                MessageBox.Show("单据状态不允许审核！");
                return;

            }
           
            string updateSql = " UPDATE dbo.yx_order SET Fstatus=2,FcheckName='" + PropertyClass.OperatorName + "',Fcheckdate='" +
                               DateTime.Now.ToString("yyyy-MM-dd") + "' WHERE Finterid=" + Finterid;

            if (this.ZtType == "M")
            {
                updateSql = " UPDATE dbo.yx_orderM SET Fstatus=2,FcheckName='" + PropertyClass.OperatorName + "',Fcheckdate='" +
                                  DateTime.Now.ToString("yyyy-MM-dd") + "' WHERE Finterid=" + Finterid;

            
            }
            try
            {
                DataBase upDb = new DataBase(this.ZtRyconstring);
                upDb.ExecDataBySql(updateSql);
                MessageBox.Show("审核成功");

                

            }
            catch (Exception ex)
            {
                MessageBox.Show("审核失败！原因：" + ex.ToString());
                return;
            }
        }

        private void btnHcheck_Click(object sender, EventArgs e)
        {
            if (this.fType != "SEL")
            {
                MessageBox.Show("该单据还没有保存！");
                return;

            }
            if (MessageBox.Show("确认要反审核该单据？", "消息对话框！", MessageBoxButtons.YesNoCancel,
                  MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1) != DialogResult.Yes)
            {
                return;
            }

            if (Int32.Parse(this.Fstatus) != 2)
            {
                MessageBox.Show("单据状态不允许反审核！");
                return;

            }
            string updateSql = " UPDATE dbo.yx_order SET Fstatus=1,FcheckName='',Fcheckdate=null WHERE Finterid=" + Finterid;
            if (this.ZtType == "M")
            {
               updateSql = " UPDATE dbo.yx_orderM SET Fstatus=1,FcheckName='',Fcheckdate=null WHERE Finterid=" + Finterid;
           
            }

            try
            {
                DataBase upDb = new DataBase(this.ZtRyconstring);
                upDb.ExecDataBySql(updateSql);
                MessageBox.Show("反审核成功");

                

            }
            catch (Exception ex)
            {
                MessageBox.Show("反审核失败！原因：" + ex.ToString());
                return;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("确定要退出吗？", "软件提示", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                this.Close();
            }
          

        }

        private void 审核ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.btnCheck.Enabled == true)
            {
                btnCheck_Click(null,null);

            }
            else
            {
                MessageBox.Show("没有权限！");
            }
        }

        private void 反审核ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //btnHcheck_Click
            if (this.btnHcheck.Enabled == true)
            {
                btnHcheck_Click(null, null);

            }
            else
            {
                MessageBox.Show("没有权限！");
            }

        }

        private void 确认ToolStripMenuItem_Click(object sender, EventArgs e)
        {//btnConfirmer_Click
            if (this.btnConfirmer.Enabled == true)
            {
                btnConfirmer_Click(null, null);

            }
            else
            {
                MessageBox.Show("没有权限！");
            }
        }

        private void 反确认ToolStripMenuItem_Click(object sender, EventArgs e)
        {//btnHConfirmer_Click
            if (this.btnHConfirmer.Enabled == true)
            {
                btnHConfirmer_Click(null, null);

            }
            else {
                MessageBox.Show("没有权限！");
            }
        }

       
       
        public void getMDfpts(string FcurID)
        {
            string selSql = " SELECT ffpqty FROM yx_mdfpts WHERE fdate='" + txtFdate.Text+ "' AND fmdid=" + FcurID;
            DataBase dbsel = new DataBase(this.ZtRyconstring);
            DataSet dssel = new DataSet();
            try
            {

                dssel = dbsel.GetDataSet(selSql,"sel");

            }
            catch { return; }

            if (dssel.Tables[0].Rows.Count == 0)
            {
                return;
            }
            
        
        }

        private void DT_pdate_ValueChanged(object sender, EventArgs e)
        {
            if (this.fType != "SEL")
            {
                if (txtFcurname.Text != "")
                {

                }
            }
        }
  
     

      


    
    }
}
