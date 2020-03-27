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

namespace YXK3FZ.RYGYL
{
	public partial class frmMOrder : Form
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
		int isICC = 1;//是否判断信用 根据白名单 1 是 0 否 -1 启用并小与信用
		int isFunitTou = 0;//单位是否只是头
		int isUPrice = 0;
		int PriceFrom = 0;//单价取值方向 0 肉业 1 食品
		int SELtype = 0;//过滤类型 0 客户 1 产品

		//表头

		string Finterid;//内码
		string Fbillno;
		string Fstatus;
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
		string ordertablename = "yx_order";
		string entrytablename = "yx_orderentry";



		string fnamenum = "";
		// string fitemid =null;
		//明细




		//构造函数
		public frmMOrder(string zttype, string typestr, string billid)
		{
			//单据类型  如果是编剧状态 带 单据内码  否则单据内码=null
			InitializeComponent();
			this.ZtType = zttype;
			this.fType = typestr;
		
			if (this.ZtType == "R") //肉业
			{
				#region R-肉业
				this.Tag = "99";
				ds = db.GetDataSet("SELECT Fdbstr    FROM dbo.YXZTLIST WHERE ID=2", "con");
				this.dgvDetail.Columns["Column_Fbigpig"].Visible = false;     //大猪
				this.dgvDetail.Columns["Column_Fmediumpig"].Visible = false;  //中猪
				this.dgvDetail.Columns["Column_Fsmallpig"].Visible = false;   //小猪
				this.dgvDetail.Columns["Column_Fmarrypig"].Visible = false;   //婚用

				if (this.fType == "ADD")
				{
					this.Text = "肉业销售订单--新增";

				}
				if (this.fType == "EDIT")
				{
					this.Text = "肉业销售订单--修改";

				}
				if (this.fType == "SEL")
				{
					this.Text = "肉业销售订单--查询";
					this.Finterid = billid;
				}

				#endregion
			}
			if (this.ZtType == "S") //食品
			{
				#region S-食品
				this.Tag = "102";
				ds = db.GetDataSet("SELECT Fdbstr    FROM dbo.YXZTLIST WHERE ID=1", "con");
				this.dgvDetail.Columns["Column_Fbigpig"].Visible = false;     //大猪
				this.dgvDetail.Columns["Column_Fmediumpig"].Visible = false;  //中猪
				this.dgvDetail.Columns["Column_Fsmallpig"].Visible = false;   //小猪
				this.dgvDetail.Columns["Column_FGYYQ"].Visible = false;       //工艺要求
				

				if (this.fType == "ADD")
				{
					this.Text = "食品销售订单--新增";

				}
				if (this.fType == "EDIT")
				{
					this.Text = "食品销售订单--修改";

				}
				if (this.fType == "SEL")
				{
					this.Text = "食品销售订单--查询";
					this.Finterid = billid;
				}
				#endregion
			
			}
			if (this.ZtType == "M") //门店
			{
				#region M-门店
				this.Tag = "104";
				ds = db.GetDataSet("SELECT Fdbstr    FROM dbo.YXZTLIST WHERE ID=1", "con");
				this.dgvDetail.Columns["Column_Fbigpig"].Visible = false;    //大猪
				this.dgvDetail.Columns["Column_Fmediumpig"].Visible = false; //中猪
				this.dgvDetail.Columns["Column_Fsmallpig"].Visible = false;  //小猪
				this.dgvDetail.Columns["Column_Fmarrypig"].Visible = false;  //婚用
				this.dgvDetail.Columns["Column_FGYYQ"].Visible = false;       //工艺要求

				if (this.fType == "ADD")
				{
					this.Text = "门店销售订单--新增";

				}
				if (this.fType == "EDIT")
				{
					this.Text = "门店销售订单--修改";

				}
				if (this.fType == "SEL")
				{
					this.Text = "门店销售订单--查询";
					this.Finterid = billid;
				}
				#endregion
			}

			DataRow dr = ds.Tables[0].Rows[0];
			ZtRyconstring = dr["Fdbstr"].ToString();



			

		}

		//窗体加载
		private void frmOrder_Load(object sender, EventArgs e)
		{
			//权限控制

			commUse.CortrolButtonEnabled(btnADD, this);
			commUse.CortrolButtonEnabled(tsbtnEdit, this);
			commUse.CortrolButtonEnabled(btnSave, this);
			commUse.CortrolButtonEnabled(btnConfirmer, this);
			commUse.CortrolButtonEnabled(btnHConfirmer, this);
			commUse.CortrolButtonEnabled(btnCheck, this);
			commUse.CortrolButtonEnabled(btnHcheck, this);

			if (this.ZtType == "M")
			{
				ordertablename = "yx_orderM";
				entrytablename = "yx_orderMentry";
			}

			if (this.ZtType == "R")
			{
				label2.Text = "开市场凭证头数";
				label2.Width = label2.Width + 50;
				txt_ptime.Location = new Point(115, 133);
				txt_ptime.Width = txt_ptime.Width - 30;
			}

			if (this.ZtType == "M")
			{
				//改变标签显示
				//label28.Text = "门店名称";//客户名称
				//label27.Text = "门店代码";//客户代码
				//label25.Text = "门店地址";//客户地址
				//label19.Text = "区域名称";//客户地址
				//label18.Text = "区域代码";//客户地址 
				//label17.Text = "门店负责人";//客户地址
				//label3.Text = "订单类型";//客户地址
				this.cmborderType.Visible = true;
				this.txtFnote.Visible = false;
				this.label7.Visible = true;
				this.txtFfpts.Visible = true;
				//调整单价列到数量后面
				this.dgvDetail.Columns["Column_Fprice"].DisplayIndex = 7;

			}





			if (this.fType == "ADD")
			{   //初始编号 制单人 制单日期 金额合计

				if (btnADD.Enabled == false)
				{
					MessageBox.Show("没有权限!");
					this.Close();

				}
				if (this.ZtType == "M")
				{
					this.txtFbillno.Text = commUse.SelBillno("yx_orderM", ZtRyconstring);
					//txtFempName.ReadOnly= false;
					if (DateTime.Now.Hour >= 15)
					{
						this.cmborderType.Text = "B";
					}
					else
					{
						this.cmborderType.Text = "A";
					}

				}
				else
				{
					this.txtFbillno.Text = commUse.SelBillno("yx_order", ZtRyconstring);
				}
				this.txtFBillerName.Text = PropertyClass.OperatorName;
				this.DT_pdate.Value = DateTime.Now.AddDays(1);
				this.txtFdate.Text = DateTime.Now.ToString("yyyy-MM-dd");
				this.txtSumFamout.Text = "0";


			}


			if (this.fType == "SEL")
			{
				this.selLoad(this.Finterid);

			}




		}

		public void selLoad(string Finterid)
		{
			this.Text = "销售订单--查询";
			DataBase selDB = new DataBase(this.ZtRyconstring);

			#region 修改前语句
			////TODO  m
			//string sqlstr = " SELECT  Finterid,Fbillno,a.Fstatus,FcurID,FdepID,k.fname fcurname,k.fnumber fcurnumber,k.FAddress," +
			//              "  d.fname AS fdepname,d.fnumber AS fdepnumber,FempName,Fpdate,Fptime,Fproperty,Fcarnum,a.Fnote,FSumFamout," +
			//             " FBillerName,FConfirmerName,FcheckName,FBillerdate,FConfirmerdate,Fcheckdate ," +
			//              " CASE a.Fstatus WHEN 0 THEN '待确认' WHEN 1 THEN '已确认' WHEN 2 THEN '已审核' WHEN 3 THEN '已关闭' END status  " +
			//             "  FROM dbo.yx_order a   INNER JOIN dbo.t_Department d ON a.FdepID=d.FItemID " +
			//              " INNER JOIN dbo.t_Organization k ON k.FItemID=a.FcurID WHERE a.Finterid=" + Finterid;

			#endregion

			string sqlstr = string.Empty;

			if (this.ZtType == "R") //肉业
			{
				sqlstr += " SELECT  Finterid,Fbillno,a.Fstatus,FcurID,FdepID,k.fname fcurname,k.fnumber fcurnumber,k.FAddress, ";
				sqlstr += " d.fname AS fdepname,d.fnumber AS fdepnumber,FempName,Fpdate,Fptime,Fproperty,Fcarnum,a.Fnote,FSumFamout,";
				sqlstr += " FBillerName,FConfirmerName,FcheckName,FBillerdate,FConfirmerdate,Fcheckdate ,";
				sqlstr += " CASE a.Fstatus WHEN 0 THEN '待确认' WHEN 1 THEN '已确认' WHEN 2 THEN '已审核' WHEN 3 THEN '已关闭' END status ";
				sqlstr += " FROM dbo.yx_order a ";
				sqlstr += " INNER JOIN dbo.t_Department d ON a.FdepID=d.FItemID";
				sqlstr += " INNER JOIN dbo.t_Organization k ON k.FItemID=a.FcurID";
				sqlstr += " WHERE a.Finterid ='" + Finterid + "' ";

			}
			else if (this.ZtType == "S") //食品
			{
				sqlstr += " SELECT  Finterid,Fbillno,a.Fstatus,FcurID,FdepID,k.fname fcurname,k.fnumber fcurnumber,k.FAddress, ";
				sqlstr += " d.fname AS fdepname,d.fnumber AS fdepnumber,FempName,Fpdate,Fptime,Fproperty,Fcarnum,a.Fnote,FSumFamout,";
				sqlstr += " FBillerName,FConfirmerName,FcheckName,FBillerdate,FConfirmerdate,Fcheckdate ,";
				sqlstr += " isnull(BatchID,0) BatchID,isnull(MarketID,0) MarketID,"; //添加的字段：批次，市场2016－03－26
				sqlstr += " CASE a.Fstatus WHEN 0 THEN '待确认' WHEN 1 THEN '已确认' WHEN 2 THEN '已审核' WHEN 3 THEN '已关闭' END status ";
				sqlstr += " FROM dbo.yx_order a ";
				sqlstr += " INNER JOIN dbo.t_Department d ON a.FdepID=d.FItemID";
				sqlstr += " INNER JOIN dbo.t_Organization k ON k.FItemID=a.FcurID";

				sqlstr += " WHERE a.Finterid ='" + Finterid + "' ";

			}
			else if (this.ZtType == "M") //门店
			{
				sqlstr += " SELECT  Finterid,Fbillno,a.Fstatus,FcurID,FdepID,k.fname fcurname,k.fnumber fcurnumber,k.f_101 FAddress,";
				sqlstr += " d.fname AS fdepname,'' AS fdepnumber,FempName,Fpdate,Fptime,Fproperty,Fcarnum,a.Fnote,FSumFamout,";
				sqlstr += " FBillerName,FConfirmerName,FcheckName,FBillerdate,FConfirmerdate,Fcheckdate ,";
				sqlstr += " CASE a.Fstatus WHEN 0 THEN '待确认' WHEN 1 THEN '已确认' WHEN 2 THEN '已审核' WHEN 3 THEN '已关闭' END status  FROM dbo.yx_orderM a";
				sqlstr += " LEFT  JOIN dbo.t_Item  d ON a.FdepID=d.FItemID";
				sqlstr += " INNER JOIN t_Item_3001  k ON   k.FItemID=a.FcurID";
				sqlstr += " WHERE a.Finterid ='" + Finterid + "' ";			

			}
			
			DataSet selds = selDB.GetDataSet(sqlstr, "sel"); //得到查询结果
		
			this.Fstatus = selds.Tables[0].Rows[0]["Fstatus"].ToString();
			this.Fbillno = selds.Tables[0].Rows[0]["Fbillno"].ToString();
			this.FcurID = selds.Tables[0].Rows[0]["FcurID"].ToString();
			this.FdepID = selds.Tables[0].Rows[0]["FdepID"].ToString();
			this.txtFbillno.Text = this.Fbillno;
			this.txtFcurname.Text = selds.Tables[0].Rows[0]["fcurname"].ToString();
			this.txtFcurNumber.Text = selds.Tables[0].Rows[0]["fcurnumber"].ToString();
			this.txtFcurAdder.Text = selds.Tables[0].Rows[0]["FAddress"].ToString();
			this.txtFdepName.Text = selds.Tables[0].Rows[0]["fdepname"].ToString();
			this.txtFdepNumber.Text = selds.Tables[0].Rows[0]["fdepnumber"].ToString();
			this.txtFempName.Text = selds.Tables[0].Rows[0]["FempName"].ToString();
			this.DT_pdate.Value = DateTime.Parse(selds.Tables[0].Rows[0]["Fpdate"].ToString());
			this.txt_ptime.Text = selds.Tables[0].Rows[0]["Fptime"].ToString();
			this.txtFproperty.Text = selds.Tables[0].Rows[0]["Fproperty"].ToString();
			this.txtCPH.Text = selds.Tables[0].Rows[0]["Fcarnum"].ToString();
			if (this.ZtType == "M")
			{
				this.cmborderType.Text = selds.Tables[0].Rows[0]["Fnote"].ToString();
			}
			else
			{
				this.txtFnote.Text = selds.Tables[0].Rows[0]["Fnote"].ToString();
			}
			this.txtSumFamout.Text = selds.Tables[0].Rows[0]["FSumFamout"].ToString();
			this.txtFBillerName.Text = selds.Tables[0].Rows[0]["FBillerName"].ToString();
			this.txtFConfirmerName.Text = selds.Tables[0].Rows[0]["FConfirmerName"].ToString();
			this.txtFcheckName.Text = selds.Tables[0].Rows[0]["FcheckName"].ToString();

			try
			{
				this.txtFdate.Text = DateTime.Parse(selds.Tables[0].Rows[0]["FBillerdate"].ToString()).ToString("yyyy-MM-dd");
			}
			catch
			{
				this.txtFdate.Text = "";
			}
			try
			{
				this.txtFConfirmerDate.Text = DateTime.Parse(selds.Tables[0].Rows[0]["FConfirmerdate"].ToString()).ToString("yyyy-MM-dd");
			}
			catch
			{
				this.txtFConfirmerDate.Text = "";
			}
			try
			{
				this.txtFcheckdate.Text = DateTime.Parse(selds.Tables[0].Rows[0]["Fcheckdate"].ToString()).ToString("yyyy-MM-dd");
			}
			catch
			{ this.txtFcheckdate.Text = ""; }

			this.txtFStause.Text = selds.Tables[0].Rows[0]["status"].ToString();
			this.dataGridView2.Visible = false;
			this.txtFcurname.ReadOnly = true;
			this.txt_ptime.ReadOnly = true;
			this.txtFproperty.ReadOnly = true;
			this.txtCPH.ReadOnly = true;
			this.txtFnote.ReadOnly = true;
			this.cmborderType.Enabled = false;

	

		
			
			
			//TODO ADD PIGHEAR
			sqlstr = "SELECT  u.Fentryid Column_Fentryid,u.Fitemid Column_Fitemid,t.FName Column_Fname,t.fnumber Column_Fnumber," +
								 " t.FModel Column_Fmodel,u.Funit Column_FunitName,u.Fqty Column_Fqty,u.Fzlbz Column_Fzlbz,u.Fpsyq Column_Fpsyq," +
							" u.Fnote Column_Fnote,u.FConversion Column_FConversion,u.Fk3unit Column_K3unitname,u.Fk3qty Column_K3Qty," +
							" '' Column_JYqty,u.Fprice Column_Fprice,u.Famout Column_Famout,u.Fpighead Column_Fpighead," +
							"  ISNULL(Fbigpig,0) Column_Fbigpig,ISNULL(Fmediumpig,0) Column_Fmediumpig ,ISNULL(Fsmallpig,0) Column_Fsmallpig,FGYYQ Column_FGYYQ,ISNULL(Fmarrypig,0) Column_Fmarrypig   " +
							" FROM " + this.entrytablename + " u" +
							 " INNER JOIN t_icitem t ON u.Fitemid=t.FItemID WHERE finterid=" + Finterid;

			//sqlstr = " SELECT  u.Fentryid 分录,u.Fitemid 产品ID,t.FName 产品名称,t.fnumber 产品代码," +
			//         " t.FModel 规格,u.Funit 单位,u.Fqty 数量,u.Fzlbz 质量标准,u.Fpsyq 配送要求," +
			//         " u.Fnote 备注,u.FConversion 换算率,u.Fk3unit K3单位,u.Fk3qty K3数量," +
			//      " '' [结余数量（公斤）],u.Fprice 单价,u.Famout 金额 FROM dbo.yx_orderentry u" +
			//         " INNER JOIN t_icitem t ON u.Fitemid=t.FItemID WHERE finterid=" + this.Finterid;

			this.dgvDetail.CellValueChanged -= new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDetail_CellValueChanged);
			this.dgvDetail.RowPostPaint -= new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dgvDetail_RowPostPaint);
			this.dgvDetail.CellStateChanged -= new System.Windows.Forms.DataGridViewCellStateChangedEventHandler(this.dgvDetail_CellStateChanged);
			this.dgvDetail.EditingControlShowing -= new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dgvDetail_EditingControlShowing);
			int dgvcount = this.dgvDetail.Rows.Count;
			for (int i = 0; i < dgvcount; i++)
			{
				this.dgvDetail.Rows.RemoveAt(0);
			}
			selds = selDB.GetDataSet(sqlstr, "sel");
			// this.dgvDetail.DataSource = selds.Tables[0];


			this.dgvDetail.Rows.Add(selds.Tables[0].Rows.Count);
			for (int i = 0; i < selds.Tables[0].Rows.Count; i++)
			{
				this.dgvDetail["Column_Fentryid", i].Value = selds.Tables[0].Rows[i]["Column_Fentryid"].ToString();
				this.dgvDetail["Column_Fitemid", i].Value = selds.Tables[0].Rows[i]["Column_Fitemid"].ToString();
				this.dgvDetail["Column_Fname", i].Value = selds.Tables[0].Rows[i]["Column_Fname"].ToString();
				this.dgvDetail["Column_Fnumber", i].Value = selds.Tables[0].Rows[i]["Column_Fnumber"].ToString();
				this.dgvDetail["Column_Fmodel", i].Value = selds.Tables[0].Rows[i]["Column_Fmodel"].ToString();
				this.dgvDetail["Column_FunitName", i].Value = selds.Tables[0].Rows[i]["Column_FunitName"].ToString();
				this.dgvDetail["Column_Fqty", i].Value = selds.Tables[0].Rows[i]["Column_Fqty"].ToString();
				this.dgvDetail["Column_Fzlbz", i].Value = selds.Tables[0].Rows[i]["Column_Fzlbz"].ToString();
				this.dgvDetail["Column_Fpsyq", i].Value = selds.Tables[0].Rows[i]["Column_Fpsyq"].ToString();
				this.dgvDetail["Column_Fnote", i].Value = selds.Tables[0].Rows[i]["Column_Fnote"].ToString();
				this.dgvDetail["Column_FConversion", i].Value = selds.Tables[0].Rows[i]["Column_FConversion"].ToString();
				this.dgvDetail["Column_K3unitname", i].Value = selds.Tables[0].Rows[i]["Column_K3unitname"].ToString();
				this.dgvDetail["Column_K3Qty", i].Value = selds.Tables[0].Rows[i]["Column_K3Qty"].ToString();
				this.dgvDetail["Column_JYqty", i].Value = selds.Tables[0].Rows[i]["Column_JYqty"].ToString();
				this.dgvDetail["Column_Fprice", i].Value = selds.Tables[0].Rows[i]["Column_Fprice"].ToString();
				this.dgvDetail["Column_Famout", i].Value = selds.Tables[0].Rows[i]["Column_Famout"].ToString();
				this.dgvDetail["Column_Fpighead", i].Value = selds.Tables[0].Rows[i]["Column_Fpighead"].ToString();
				this.dgvDetail["Column_Fbigpig", i].Value = selds.Tables[0].Rows[i]["Column_Fbigpig"].ToString();
				this.dgvDetail["Column_Fmediumpig", i].Value = selds.Tables[0].Rows[i]["Column_Fmediumpig"].ToString();
				this.dgvDetail["Column_Fsmallpig", i].Value = selds.Tables[0].Rows[i]["Column_Fsmallpig"].ToString();
				this.dgvDetail["Column_Fmarrypig", i].Value = selds.Tables[0].Rows[i]["Column_Fmarrypig"].ToString();
				//FGYYQ
				this.dgvDetail["Column_FGYYQ", i].Value = selds.Tables[0].Rows[i]["Column_FGYYQ"].ToString(); //工艺要求

			}


			this.dgvDetail.ReadOnly = true;





		}

		private void textBox13_TextChanged(object sender, EventArgs e)
		{//录入客户名称或代码显示过滤界面
			SELtype = 0;
			if (this.dataGridView2.Visible == false)
			{
				this.dataGridView2.Location = new Point(txtFcurname.Location.X, txtFcurname.Location.Y + this.panel1.Location.Y + txtFcurname.Height + 1);
				this.dataGridView2.Width = txtFcurname.Width;
				this.dataGridView2.Visible = true;
			}
			// this.Controls.Add(dgv);
			// MessageBox.Show( "软件提示");
			//  string sqlstr = "SELECT FItemID, fnumber AS 客户代码,fname AS 客户名称 FROM dbo.t_Organization WHERE fname+fnumber LIKE '%" + txtFcurname.Text.Trim()+ "%' ";
			DataBase dbselFcur = new DataBase(ZtRyconstring);
			if (this.ZtType == "M")
			{
				this.dataGridView2.DataSource = dbselFcur.GetDataSet(
							"  SELECT FItemID,fnumber AS 门店代码,fname AS 门店名称 FROM t_Item WHERE FItemClassID=3001 AND FDetail=1 AND FDeleted=0 AND fname+fnumber LIKE '%" + txtFcurname.Text.Trim() + "%' ",
							 "selFcur").Tables[0];

			}
			else
			{
				this.dataGridView2.DataSource = dbselFcur.GetDataSet(
						 "SELECT FItemID, fnumber AS 客户代码,fname AS 客户名称 FROM dbo.t_Organization WHERE  FDeleted=0 AND fname+fnumber LIKE '%" + txtFcurname.Text.Trim() + "%' ",
							"selFcur").Tables[0];
			}

			this.dataGridView2.Columns[0].Visible = false;
		}

		private void dgvDetail_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
		{
			//显示序号
			SolidBrush b = new SolidBrush(this.dgvDetail.RowHeadersDefaultCellStyle.ForeColor);
			e.Graphics.DrawString((e.RowIndex + 1).ToString(System.Globalization.CultureInfo.CurrentUICulture), this.dgvDetail.DefaultCellStyle.Font, b, e.RowBounds.Location.X + 20, e.RowBounds.Location.Y + 4);

		}

		private void dataGridView2_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
		{
			//选中客户后

			if (e.RowIndex > -1 && e.ColumnIndex > -1)
			{



				if (SELtype == 0)//选择客户
				{
					this.FcurID = this.dataGridView2.CurrentRow.Cells[0].Value.ToString();
					//获得客户id后调用加载信息方法
					OnFcurIDGetBase(this.FcurID);

					if (this.fType == "ADD")
					{
						this.dgvDetail.Rows.Add(20);
						this.dgvDetail.BeginEdit(true);
						getFcurList(FcurID);
					}


					this.dataGridView2.DataSource = null;
					this.dataGridView2.Visible = false;
				}
				if (SELtype == 1)//选择产品
				{
					//this.FcurID = this.dataGridView2.CurrentRow.Cells[0].Value.ToString();
					////获得客户id后调用加载信息方法
					//OnFcurIDGetBase(this.FcurID);
					//this.fitemid = this.dataGridView2.CurrentRow.Cells[0].Value.ToString();
					//调用取得产品内码后获得产品信息
					add_ItemDataBese(this.dataGridView2.CurrentRow.Cells[0].Value.ToString(), this.dgvDetail.CurrentRow.Index);
					this.dataGridView2.DataSource = null;
					this.dataGridView2.Visible = false;
				}

			}



		}
		private void txtFcurname_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				DataBase dbselFcur1 = new DataBase(ZtRyconstring);
				DataSet dssel;

				if (this.ZtType == "M")
				{
					dssel = dbselFcur1.GetDataSet(
																			 " SELECT FItemID  FROM t_Item WHERE FItemClassID=3001 AND FDetail=1 AND FDeleted=0 AND fname+fnumber LIKE '%" + txtFcurname.Text.Trim() + "%' ",
																			 " selFcur");
				}
				else
				{
					dssel = dbselFcur1.GetDataSet(
										"SELECT FItemID  FROM dbo.t_Organization WHERE  FDeleted=0 AND fname+fnumber LIKE '%" + txtFcurname.Text.Trim() + "%' ",
										 "selFcur");
				}
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
					// this.Controls.Add(dgv);
					// MessageBox.Show( "软件提示");
					//  string sqlstr = "SELECT FItemID, fnumber AS 客户代码,fname AS 客户名称 FROM dbo.t_Organization WHERE fname+fnumber LIKE '%" + txtFcurname.Text.Trim()+ "%' ";
					DataBase dbselFcur = new DataBase(ZtRyconstring);
					if (this.ZtType == "M")
					{
						this.dataGridView2.DataSource = dbselFcur.GetDataSet(
							 "  SELECT FItemID,fnumber AS 门店代码,fname AS 门店名称 FROM t_Item WHERE FItemClassID=3001 AND FDetail=1 AND FDeleted=0 AND fname+fnumber LIKE '%" + txtFcurname.Text.Trim() + "%' ",
						"selFcur").Tables[0];
					}
					else
					{
						this.dataGridView2.DataSource = dbselFcur.GetDataSet(
								 "SELECT FItemID, fnumber AS 客户代码,fname AS 客户名称 FROM dbo.t_Organization WHERE  FDeleted=0 AND fname+fnumber LIKE '%" + txtFcurname.Text.Trim() + "%' ",
									"selFcur").Tables[0];
					}

					this.dataGridView2.Columns[0].Visible = false;



				}




			}
		}


		public void rowJiSuan()//行计算k3数量 金额 合计金额 信用
		{

			int row = this.dgvDetail.CurrentCell.RowIndex;//行
			int col = this.dgvDetail.CurrentCell.ColumnIndex;
			string ColumnName = this.dgvDetail.Columns[col].HeaderText;

			if (ColumnName != "产品名称")
			{
				this.dataGridView2.DataSource = null;
				this.dataGridView2.Visible = false;
			}


			if (ColumnName == "数量" || ColumnName == "单位" || ColumnName == "产品名称" || ColumnName == "单价")
			{


				if (this.dgvDetail["Column_Fqty", row].Value != null &&
					 this.dgvDetail["Column_Fqty", row].Value.ToString() != "" &&
					 this.dgvDetail["Column_FConversion", row].Value != null &&
					 this.dgvDetail["Column_FConversion", row].Value.ToString() != "" &&
					// this.dgvDetail["Column_Fprice", row].Value != null &&
					// this.dgvDetail["Column_Fprice", row].Value.ToString() != "" &&
					 this.dgvDetail["Column_Fitemid", row].Value != null &&
					 this.dgvDetail["Column_Fitemid", row].Value.ToString() != ""
					// this.fitemid!=null


					 )
				{
					try
					{
						this.dgvDetail["Column_K3Qty", row].Value =
						(Convert.ToSingle(this.dgvDetail["Column_Fqty", row].Value.ToString()) *
						 Convert.ToSingle(this.dgvDetail["Column_FConversion", row].Value.ToString())).ToString();
					}
					catch
					{
						MessageBox.Show("重量录入非法字符！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
						this.dgvDetail["Column_Fqty", row].Value = "";
						return;

					}

					if (this.ZtType != "M" &&
							this.dgvDetail["Column_Fprice", row].Value != null &&
							this.dgvDetail["Column_Fprice", row].Value.ToString() != ""
							)
					{
						try
						{
							this.dgvDetail["Column_Famout", row].Value = Convert.ToSingle
														((Convert.ToSingle(this.dgvDetail["Column_K3Qty", row].Value.ToString()) *
														 Convert.ToSingle(this.dgvDetail["Column_FPrice", row].Value.ToString()))).ToString();
						}
						catch
						{
							MessageBox.Show("行金额计算出错！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
							return;
						}


						try
						{
							this.txtSumFamout.Text = "0";
							for (int i = 0; i <= this.dgvDetail.Rows.Count - 1; i++)
							{

								if (this.dgvDetail["Column_Fqty", i].Value != null &&
											 this.dgvDetail["Column_Fqty", i].Value.ToString() != "" &&
											 this.dgvDetail["Column_FConversion", i].Value != null &&
											 this.dgvDetail["Column_FConversion", i].Value.ToString() != "" &&
											 this.dgvDetail["Column_Fprice", i].Value != null &&
												this.dgvDetail["Column_Fprice", i].Value.ToString() != "" &&
											 this.dgvDetail["Column_Fitemid", i].Value != null &&
											 this.dgvDetail["Column_Fitemid", i].Value.ToString() != "" &&
												this.dgvDetail["Column_Famout", i].Value != null &&
											 this.dgvDetail["Column_Famout", i].Value.ToString() != ""
										)
								{
									this.txtSumFamout.Text = (Convert.ToSingle(this.txtSumFamout.Text) + Convert.ToSingle(dgvDetail["Column_Famout", i].Value.ToString())).ToString();
								}
							}

						}
						catch
						{
							MessageBox.Show("合计金额计算出错！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
							return;
						}
					}
					this.Warning();
					this.dataGridView2.Visible = false;
					// this.dgvDetail.CurrentCell = dgvDetail["Column_Fitemid", row+1];
					// this.dgvDetail.Rows.Add();

					// this.fitemid = null;

				}
			}

		}

		private void dgvDetail_CellStateChanged(object sender, DataGridViewCellStateChangedEventArgs e)
		{
			rowJiSuan();//计算行的数量 金额
		}

		private void dgvDetail_CellValueChanged(object sender, DataGridViewCellEventArgs e)
		{//单元格的值变化时
			if (e.RowIndex > -1 && e.ColumnIndex > -1)
			{
				string ColumnName = this.dgvDetail.Columns[e.ColumnIndex].HeaderText;
				//    if (ColumnName == "产品名称" &&
				//        this.dgvDetail["Column_Fitemid", e.RowIndex].Value == null &&
				//        this.dgvDetail["Column_Fname", e.RowIndex].Value != null)
				//    {//输入只有唯一的产品时赋值
				//        string sqlstr = " SELECT t.FItemID,t.fname  FROM t_icitem  t WHERE fnumber like '7.%' and fname+fnumber LIKE '%" +
				//                         this.dgvDetail["Column_Fname", e.RowIndex].Value.ToString() + "%'";
				//        DataBase dbselFitem = new DataBase(ZtRyconstring);
				//        if (dbselFitem.GetDataSet(sqlstr, "sel").Tables[0].Rows.Count == 1)
				//        {
				//            this.dgvDetail.BeginEdit(true);
				//            this.dgvDetail["Column_Fname", e.RowIndex].Value = dbselFitem.GetDataSet(sqlstr, "sel").Tables[0].Rows[0][1].ToString();
				//            this.dgvDetail.EditingControlShowing -= new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dgvDetail_EditingControlShowing);

				//            string fitemid = dbselFitem.GetDataSet(sqlstr, "sel").Tables[0].Rows[0][0].ToString();
				//            add_ItemDataBese(fitemid, e.RowIndex);
				//            this.dgvDetail.CurrentCell = this.dgvDetail["Column_Fqty", e.RowIndex];
				//            this.dgvDetail.EditingControlShowing -= new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dgvDetail_EditingControlShowing);

				//        }




				//    }

				if (ColumnName == "单位")
				{

					if (this.dgvDetail["Column_FunitName", e.RowIndex].Value.ToString() == "头" && this.dgvDetail["Column_Fitemid", e.RowIndex].Value != null)
					{
						string Conversion = "";
						try
						{
							Conversion = this.getItemUnitFConversion(this.dgvDetail["Column_Fitemid", e.RowIndex].Value.ToString(),
																												 this.dgvDetail["Column_FunitName", e.RowIndex].Value.ToString(),
								// this.dgvDetail["Column_K3unitname", e.RowIndex].Value.ToString());
																											 "公斤");
						}
						catch
						{
							Conversion = "";
						}
						if (Conversion == "")
						{
							MessageBox.Show("没有改产品的单位换算，请先到单位设置中添加！");
							this.dgvDetail["Column_Famout", e.RowIndex].Value = "0";
							this.dgvDetail["Column_FConversion", e.RowIndex].Value = "1";
							return;

						}
						else
						{
							this.dgvDetail["Column_FConversion", e.RowIndex].Value = Conversion;
						}
					}
					if (this.dgvDetail["Column_FunitName", e.RowIndex].Value.ToString() == "公斤")
					{
						this.dgvDetail["Column_Famout", e.RowIndex].Value = "";
						this.dgvDetail["Column_FConversion", e.RowIndex].Value = "1";
					}
					this.rowJiSuan();
				}


			}
		}

		private void dgvDetail_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
		{//单元格变化时
			int row;
			row = this.dgvDetail.CurrentCell.RowIndex;//行
			int col;
			col = this.dgvDetail.CurrentCell.ColumnIndex;
			//列名：  this.dataGridView1.Columns[this.dataGridView1.CurrentCell.ColumnIndex].HeaderText

			// int row = this.dgvDetail.CurrentRow.Index;
			if (row != 0)
			{
				if (this.ZtType != "M")
				{
					if (this.dgvDetail["Column_Fqty", row - 1].Value == null ||
				 this.dgvDetail["Column_Fqty", row - 1].Value.ToString() == "" ||
				 this.dgvDetail["Column_FConversion", row - 1].Value == null ||
				 this.dgvDetail["Column_FConversion", row - 1].Value.ToString() == "" ||
				 this.dgvDetail["Column_Fprice", row - 1].Value == null ||
					this.dgvDetail["Column_Fprice", row - 1].Value.ToString() == "" ||
				 this.dgvDetail["Column_Fitemid", row - 1].Value == null ||
				 this.dgvDetail["Column_Fitemid", row - 1].Value.ToString() == "")
					{
						MessageBox.Show("上一行数据不完整！");
						this.dgvDetail.Rows[row - 1].Selected = true;

						return;

					}
				}
				else
				{

					if (this.dgvDetail["Column_Fqty", row - 1].Value == null ||
						 this.dgvDetail["Column_Fqty", row - 1].Value.ToString() == "" ||
						 this.dgvDetail["Column_FConversion", row - 1].Value == null ||
						 this.dgvDetail["Column_FConversion", row - 1].Value.ToString() == "" ||
						 this.dgvDetail["Column_Fitemid", row - 1].Value == null ||
						 this.dgvDetail["Column_Fitemid", row - 1].Value.ToString() == "")
					{
						MessageBox.Show("上一行数据不完整！");
						this.dgvDetail.Rows[row - 1].Selected = true;

						return;

					}

				}


			}


			if (col == 2)//如果是第三格 
			{
				TextBox tb = e.Control as TextBox;
				tb.KeyPress += new KeyPressEventHandler(tb_KeyPress);
				fnamenum = tb.Text;


			}
			else
			{

				this.dataGridView2.DataSource = null;
				this.dataGridView2.Visible = false;
			}

		}

		void tb_KeyPress(object sender, KeyPressEventArgs e)
		{//文本变化时  在单元格变化时调用
			SELtype = 1;
			int row;
			row = this.dgvDetail.CurrentCell.RowIndex;//行
			int col;
			col = this.dgvDetail.CurrentCell.ColumnIndex;
			if (col == 2)//指定单元格是物料名称是才处理
			{
				this.dataGridView2.Location = new Point(this.dgvDetail.Location.X,
								 panel1.Location.Y + dgvDetail.GetCellDisplayRectangle(this.dgvDetail.CurrentCell.ColumnIndex, this.dgvDetail.CurrentCell.RowIndex, false).Y +
								 panel2.Location.Y + this.dgvDetail.Location.Y);

				//int row;
				// row = this.dgvDetail.CurrentCell.RowIndex;//行
				// DataGridView1.CurrentCell.EditedFormattedValue 

				if (this.dgvDetail.CurrentCell.EditedFormattedValue.ToString() != "")//用dgvDetail.CurrentCell.EditedFormattedValue取得正在编辑的值
				{
					string sqlstr = " SELECT t.FItemID,t.fnumber 产品代码,t.fname 产品名称,t.fmodel 规格 FROM t_icitem  t WHERE fnumber like '7.%' and fname+fnumber LIKE '%" +
														this.dgvDetail.CurrentCell.EditedFormattedValue.ToString() + "%'";
					DataBase dbselFitem = new DataBase(ZtRyconstring);
					this.dataGridView2.DataSource = dbselFitem.GetDataSet(sqlstr, "sel").Tables[0];
					this.dataGridView2.Columns[0].Visible = false;

					this.dataGridView2.Visible = true;

				}
			}

		}

		//获得客户id后调用加载信息方法
		public void OnFcurIDGetBase(string FcurID)
		{

			DataBase dbselFcur = new DataBase(ZtRyconstring);

			string strSQL = " SELECT fitemid,客户代码,客户名称,地址,fdepid,部门代码,部门名称,业务员  FROM yx_v_OnFcurIDGetBase WHERE fitemid=" + FcurID;
			if (this.ZtType == "M")
			{
				strSQL = "  Select t1.FItemID FItemID,t1.FNumber 客户代码,t1.FName 客户名称,t3.F_101 地址, t3.F_105 fdepid,'' 部门代码,T7.FName 部门名称,t3.F_103 业务员" +
								" FROM dbo.t_Item t1 LEFT Join  t_Item_3001 t3  ON t1.FItemID=t3.FItemID LEFT Join t_Item T7 On t3.F_105=T7.FItemID " +
								" WHERE t1.FItemClassID=3001 AND t1.FDetail=1 AND t1.FDeleted=0 and  t1.fitemid=" + FcurID;

				getMDfpts(FcurID);//获得分配头数
			}
			//  string strSQL = " SELECT *  FROM t_Organization WHERE fitemid=" + FcurID;
			DataSet ds = dbselFcur.GetDataSet(strSQL, "selFcur");
			DataRow dr = ds.Tables[0].Rows[0];
			FempName = dr["业务员"].ToString();
			FdepID = dr["fdepid"].ToString(); ;//部门id
			this.txtFcurname.Text = dr["客户名称"].ToString();
			this.txtFcurNumber.Text = dr["客户代码"].ToString();
			this.txtFdepName.Text = dr["部门名称"].ToString();
			this.txtFdepNumber.Text = dr["部门代码"].ToString();
			this.txtFempName.Text = dr["业务员"].ToString();
			//this.PriceFrom = this.GetPriceFrom(FcurID, FdepID);//取得单价的方向
			//取得单价能否修改

			//this.isUPrice = this.GetisUPrice(FcurID, FdepID);
			if (this.ZtType == "R")
			{
				this.isUPrice = 0;
				this.isICC = 1;
			}
			if (this.ZtType == "S")
			{
				this.isUPrice = 1;
				this.isICC = 0;
			}
			if (this.ZtType == "M")
			{
				this.isUPrice = 1;
				this.isICC = 0;
			}

			// this.isFunitTou = this.GetIsFunitTou(FcurID, FdepID);//取得单位是否只是头
			// this.isICC = this.GetisICC(FcurID, FdepID);//取得信用的状态
			if (isICC != 0)
			{
				//取得即时信用额度
				SqlParameter param = new SqlParameter("@FcurIDs", SqlDbType.VarChar);
				param.Value = FcurID;
				//创建泛型
				List<SqlParameter> parameters = new List<SqlParameter>();
				parameters.Add(param);
				//把泛型中的元素复制到数组中
				SqlParameter[] inputParameters = parameters.ToArray();

				YXK3FZ.DataClass.DataBase ztdb = new YXK3FZ.DataClass.DataBase(ZtRyconstring);
				DataSet dsIcc = ztdb.GetProcDataSet("yx_sp_getICCredit", inputParameters);
				this.txtICCredit.Text = dsIcc.Tables[0].Rows[0][0].ToString();
			}
			this.Warning();
			//取得即时信用额度
			//自动选单 取得上一次的单据分录补充到明细




			dgvEditStasue();
			this.txtFproperty.Focus();

			//this.dgvDetail.Rows.Add(20);//添加行
			//this.dgvDetail.BeginEdit(true); 



			//this.isFunitTou = 1;// 测试
			//if (this.isFunitTou == 1)//单位只是头
			//{
			//    this.dgvDetail.Columns["Column_FunitName"].ReadOnly = true;
			//    //this.dgvDetail.Rows[0].Cells["Column_FunitName"].Value ="头";
			//}
			//int isFunitTou = 0;//单位是否只是头
			//int isUPrice = 0;

			//单价列可编辑
			//todo





		}

		public void dgvEditStasue()
		{
			this.dgvDetail.ReadOnly = false;
			this.dgvDetail.Columns["Column_Fnumber"].ReadOnly = true;
			this.dgvDetail.Columns["Column_Fmodel"].ReadOnly = true;
			this.dgvDetail.Columns["Column_FConversion"].ReadOnly = true;
			this.dgvDetail.Columns["Column_K3unitname"].ReadOnly = true;
			this.dgvDetail.Columns["Column_K3Qty"].ReadOnly = true;
			this.dgvDetail.Columns["Column_JYqty"].ReadOnly = true;
			this.dgvDetail.Columns["Column_Famout"].ReadOnly = true;
			this.dgvDetail.Columns["Column_Fprice"].ReadOnly = true;
			//     if (this.isFunitTou == 1)//单位只是头
			//{
			//    this.dgvDetail.Columns["Column_FunitName"].ReadOnly = true;
			//    //this.dgvDetail.Rows[0].Cells["Column_FunitName"].Value ="头";
			//}
			if (this.isUPrice == 1)
			{

				this.dgvDetail.Columns["Column_Fprice"].ReadOnly = false;
			}


		}
		public int GetisICC(string FcurID, string FdepID)
		{  //判断是否启用信用 
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
		{  //判断单价取值方向
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
		{  //判断单价取值方向
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




		public void Warning()
		{//判断信用已单据金额的关系


			if (isICC != 0)
			{
				if (float.Parse(this.txtICCredit.Text) < float.Parse(this.txtSumFamout.Text))
				{
					this.label29.ForeColor = Color.Red;
					isICC = Math.Abs(isICC) * -1;//绝对值乘以-1

				}
				else
				{

					this.label29.ForeColor = Color.Blue;
					isICC = 1;
				}


			}

		}



		public void add_ItemDataBese(string fitemid, int row)//根据物料内码填充行的产品信息
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



				if (this.ZtType == "R")
				{
					this.dgvDetail["Column_FunitName", row].Value = "公斤";
					this.dgvDetail["Column_Fprice", row].Value = dsitem.Tables[0].Rows[0][4].ToString(); ;//FKUnitID
					if (this.dgvDetail["Column_Fprice", row].Value == null || this.dgvDetail["Column_Fprice", row].Value.ToString() == "")
					{
						MessageBox.Show("没有该产品的单价，请到K3中添加！");
						return;
					}

				}
				if (this.ZtType == "S")
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
				this.rowJiSuan();
				this.dgvDetail.CurrentCell = dgvDetail["Column_FQty", row]; //设置辅助重量单元格获得焦点
				//dgvDetail.BeginEdit(true);

			}


		}

		public string getItemUnitFConversion(string fitemid, string unitname, string k3unitname)
		{//取得换算率
			string FConversion = null;
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

		private void 添加新行ToolStripMenuItem_Click(object sender, EventArgs e)
		{//添加一行
			this.dgvDetail.Rows.Add();
		}
		private void M_deleterow_Click(object sender, EventArgs e)
		{//删除当前行

			this.dgvDetail.Rows.RemoveAt(this.dgvDetail.CurrentCell.RowIndex);

		}

		private void btnSave_Click(object sender, EventArgs e) //保存事件
		{

			if (this.fType == "SEL")
			{
				MessageBox.Show("查询模式下不能保存！");
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
			if (this.fType == "ADD") //新增
			{
				Finterid = commUse.GetlBillID(ordertablename, ZtRyconstring);
				Fbillno = commUse.GetlBillno(ordertablename, ZtRyconstring);

			}
			if (this.fType == "EDIT") //编辑
			{
				Insertsql.Add(" DELETE " + entrytablename + " WHERE FINTERID=" + Finterid);
				Insertsql.Add(" DELETE " + ordertablename + " WHERE FINTERID=" + Finterid);

			}

			for (int i = 0; i < this.dgvDetail.Rows.Count; i++)
			{
				if (this.dgvDetail["Column_Fitemid", i].Value == null)
				{
					break;
				}

				string Fzlbz = ""; if (this.dgvDetail["Column_Fzlbz", i].Value != null) { Fzlbz = this.dgvDetail["Column_Fzlbz", i].Value.ToString(); }
				string Fpsyq = ""; if (this.dgvDetail["Column_Fpsyq", i].Value != null) { Fpsyq = this.dgvDetail["Column_Fpsyq", i].Value.ToString(); }
				string Fnote = ""; if (this.dgvDetail["Column_Fnote", i].Value != null) { Fnote = this.dgvDetail["Column_Fnote", i].Value.ToString(); }
				string FGYYQ = "";  //工艺要求

				if (ZtType == "R") //如果是肉业
				{
					if (this.dgvDetail["Column_FGYYQ", i].Value != null) { FGYYQ = this.dgvDetail["Column_FGYYQ", i].Value.ToString(); }
				}


				string Fpighead = "0";
				if (this.dgvDetail["Column_Fpighead", i].Value != null)
				{
					if (this.dgvDetail["Column_Fpighead", i].Value.ToString().Trim() != "")
					{
						Fpighead = this.dgvDetail["Column_Fpighead", i].Value.ToString();
					}
				}
				string Fbigpig = "0";
				if (this.dgvDetail["Column_Fbigpig", i].Value != null)
				{
					if (this.dgvDetail["Column_Fbigpig", i].Value.ToString().Trim() != "")
					{
						Fbigpig = this.dgvDetail["Column_Fbigpig", i].Value.ToString();
					}
				}
				string Fmediumpig = "0";
				if (this.dgvDetail["Column_Fmediumpig", i].Value != null)
				{
					if (this.dgvDetail["Column_Fmediumpig", i].Value.ToString().Trim() != "")
					{
						Fmediumpig = this.dgvDetail["Column_Fmediumpig", i].Value.ToString();
					}
				}
				string Fsmallpig = "0";
				if (this.dgvDetail["Column_Fsmallpig", i].Value != null)
				{
					if (this.dgvDetail["Column_Fsmallpig", i].Value.ToString().Trim() != "")
					{
						Fsmallpig = this.dgvDetail["Column_Fsmallpig", i].Value.ToString();
					}
				}
				string Fmarrypig = "0";
				if (this.dgvDetail["Column_Fmarrypig", i].Value != null)
				{
					if (this.dgvDetail["Column_Fmarrypig", i].Value.ToString().Trim() != "")
					{
						Fmarrypig = this.dgvDetail["Column_Fmarrypig", i].Value.ToString();
					}
				}


				string Fprice = this.dgvDetail["Column_Fprice", i].Value.ToString();
				string Famout = this.dgvDetail["Column_Famout", i].Value.ToString();
				if (this.ZtType == "M")
				{
					Fprice = "0";
					Famout = "0";
				}

				string Esql = "  INSERT INTO " + entrytablename + " ( Finterid ,Fentryid ,Fitemid ,Fk3unit ,Fprice ,Funit ," +
										" FConversion ,Fqty ,Fk3qty ,Famout ,Fzlbz ,Fpsyq ,FGYYQ,Fnote,Fpighead,Fbigpig,Fmediumpig,Fsmallpig,Fmarrypig ) VALUES  (" +
											 Finterid + " ," +
											 i.ToString() + " , " +
											 this.dgvDetail["Column_Fitemid", i].Value.ToString() +
											" ,'公斤'," +
											 Fprice + " ,'" +
											this.dgvDetail["Column_FunitName", i].Value.ToString() + "' , " +
											this.dgvDetail["Column_FConversion", i].Value.ToString() + " ," +
											this.dgvDetail["Column_Fqty", i].Value.ToString() + " ," +
											this.dgvDetail["Column_K3Qty", i].Value.ToString() + " ," +
										 Famout + " ,'" +
											Fzlbz + "' ,'" +
											Fpsyq + "' ,'" +
											FGYYQ + "' ,'" +
											Fnote + "'," + Fpighead + "," + Fbigpig + "," + Fmediumpig + "," + Fsmallpig + "," + Fmarrypig + ")";

				Insertsql.Add(Esql);

			}
			string PSql = "";
			if (this.ZtType == "M") //门店
			{
				PSql = "INSERT INTO " + ordertablename + " ( Finterid ,Fbillno , FcurID ,FempName ,Fpdate , Fptime ,Fproperty ,FdepID ,Fcarnum ," +
											 " Fnote ,FSumFamout,FBillerName ,FBillerdate,Fstatus) VALUES  (" +
											 Finterid + ",'" + Fbillno + "'," + this.FcurID + ",'" + txtFempName.Text + "','" + this.DT_pdate.Value.ToString("yyyy-MM-dd") +
											 "','" + this.txt_ptime.Text + "','" + txtFproperty.Text + "'," + this.FdepID + ",'" + this.txtCPH.Text + "','" +
											 this.cmborderType.Text + "'," + this.txtSumFamout.Text + ",'" + PropertyClass.OperatorName + "','" + DateTime.Now.ToString("yyyy-MM-dd") + "',0)";


			}
			else
			{
				PSql = "INSERT INTO " + ordertablename + " ( Finterid ,Fbillno , FcurID ,FempName ,Fpdate , Fptime ,Fproperty ,FdepID ,Fcarnum ," +
												 " Fnote ,FSumFamout,FBillerName ,FBillerdate,Fstatus) VALUES  (" +
												 Finterid + ",'" + Fbillno + "'," + this.FcurID + ",'" + txtFempName.Text + "','" + this.DT_pdate.Value.ToString("yyyy-MM-dd") +
												 "','" + this.txt_ptime.Text + "','" + txtFproperty.Text + "'," + this.FdepID + ",'" + this.txtCPH.Text + "','" +
												 this.txtFnote.Text + "'," + this.txtSumFamout.Text + ",'" + PropertyClass.OperatorName + "','" + DateTime.Now.ToString("yyyy-MM-dd") + "',0)";

			


			}
			Insertsql.Add(PSql);
			string Confirmer = "0";
			if (this.isICC >= 0)
			{
				Confirmer = "1";
				Insertsql.Add(" UPDATE " + ordertablename + " SET Fstatus=" + Confirmer + ",FConfirmerName='系统自动',FConfirmerdate='" +
								 DateTime.Now.ToString("yyyy-MM-dd") + "' WHERE Finterid=" + Finterid);
			}
			else
			{
				Confirmer = "0";


				Insertsql.Add(" UPDATE " + ordertablename + " SET Fstatus=" + Confirmer + ",FConfirmerName=null,FConfirmerdate=null WHERE Finterid=" + Finterid);
			}
			this.Fstatus = Confirmer;


			DataBase insertDB = new DataBase(this.ZtRyconstring);
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

					//成功后改到sel
					LabTishi.Text = "保存成功！";
					this.fType = "SEL";
					//if (this.isICC >= 0)
					//{
					//    this.txtFStause.Text = "已确认";
					//    this.txtFConfirmerName.Text = "系统自动";
					//    this.txtFConfirmerDate.Text = DateTime.Now.ToString("yyyy-MM-dd");

					//}
					//else {
					//    this.txtFStause.Text = "待确认";
					//    this.txtFConfirmerName.Text = "";
					//    this.txtFConfirmerDate.Text ="";


					//}

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
		public int save_checkorder()
		{
			int isPass = 0;

			if (this.FcurID == string.Empty || this.FcurID == "")
			{
				MessageBox.Show("客户不能为空");
				return isPass;
			}

			if (this.ZtType == "M" && this.cmborderType.Text == "")
			{
				MessageBox.Show("订单类型不能为空");
				return isPass;
			}


			if (dgvDetail.Rows.Count == 0)
			{
				MessageBox.Show("至少要有一行明细！");
				return isPass;

			}

			float sumFamout = 0;
			//遍历明细DataGridView1.Rows (nRowIndex).Selected =True
			for (int i = 0; i < dgvDetail.Rows.Count; i++)//再计算一次
			{
				if (this.dgvDetail["Column_Fitemid", i].Value == null) 
				{
					break; 
				}

				try //判断K3数量
				{
					this.dgvDetail["Column_K3Qty", i].Value =
					(Convert.ToSingle(this.dgvDetail["Column_Fqty", i].Value.ToString()) *
					 Convert.ToSingle(this.dgvDetail["Column_FConversion", i].Value.ToString())).ToString();
				}
				catch
				{
					MessageBox.Show("重量录入非法字符！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
					this.dgvDetail["Column_Fqty", i].Value = "";
					return isPass;

				}

				if (this.ZtType != "M") //如果是门店
				{
					try //计算金额
					{
						this.dgvDetail["Column_Famout", i].Value = Convert.ToSingle
													((Convert.ToSingle(this.dgvDetail["Column_K3Qty", i].Value.ToString()) *
													 Convert.ToSingle(this.dgvDetail["Column_FPrice", i].Value.ToString()))).ToString();
						sumFamout = sumFamout + Convert.ToSingle(this.dgvDetail["Column_Famout", i].Value.ToString());
					}
					catch
					{
						MessageBox.Show("行金额计算出错！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
						return isPass;
					}
				}
				else
				{
					this.dgvDetail["Column_FPrice", i].Value = ""; //单价
					this.dgvDetail["Column_Famout", i].Value = ""; //金额
				}

			}


			this.txtSumFamout.Text = sumFamout.ToString(); //销售金额合计:
			//this.dgvDetail.EndEdit();
			for (int i = 0; i < dgvDetail.Rows.Count; i++)//
			{

				if (this.dgvDetail["Column_Fqty", i].Value == null &&  //数量

													 this.dgvDetail["Column_FGYYQ", i].Value == null && //工艺要求

													 this.dgvDetail["Column_FConversion", i].Value == null &&  //换算率

													 this.dgvDetail["Column_Fprice", i].Value == null && //价格

													 this.dgvDetail["Column_Fitemid", i].Value == null &&  //产品内码

													 this.dgvDetail["Column_Famout", i].Value == null  //金额
											 )
				{
					break;
				}

				if (this.dgvDetail["Column_Fitemid", i].Value == null || this.dgvDetail["Column_Fitemid", i].Value.ToString() == "")
				{
					MessageBox.Show("第" + (i + 1).ToString() + "行没有选择产品！");

					return isPass;

				}
				if (this.dgvDetail["Column_Fqty", i].Value == null || this.dgvDetail["Column_Fqty", i].Value.ToString() == "")
				{
					MessageBox.Show("第" + (i + 1).ToString() + "行没有数量！");

					return isPass;

				}

				if (this.ZtType == "R") //如果是肉业
				{
					if (this.dgvDetail["Column_FGYYQ", i].Value == null || this.dgvDetail["Column_FGYYQ", i].Value.ToString() == "")
					{
						MessageBox.Show("第" + (i + 1).ToString() + "行工艺要求不能为空！");

						return isPass;

					}
				}

				if (this.ZtType != "M") //如果不是门店
				{
					if (this.dgvDetail["Column_Famout", i].Value == null || this.dgvDetail["Column_Famout", i].Value.ToString() == "")
					{
						MessageBox.Show("第" + (i + 1).ToString() + "行金额错误！");

						return isPass;

					}
				}

			}

			this.Warning();

			isPass = 1;
			// this.dgvDetail.BeginEdit(true);
			return isPass;
		}

		public void getFcurList(string FcurID)
		{
			//先清空
			this.txtFproperty.Text = "";
			this.txt_ptime.Text = "";
			this.txtCPH.Text = "";
			this.txtFnote.Text = "";
			for (int i = 0; i < dgvDetail.Rows.Count; i++)
			{
				this.dgvDetail.Rows.RemoveAt(i);
			}
			DataBase dbsel = new DataBase(this.ZtRyconstring);
			DataSet dssel = new DataSet();
			try
			{

				dssel = dbsel.GetDataSet(" SELECT v.Fproperty,v.Fptime,v.Fcarnum,v.Fnote vfnote, u.fitemid,u.Fqty,u.Funit,u.Fzlbz,u.Fpsyq ," +
																" u.Fnote uFnote,u.Fpighead,v.FBillerName  FROM  " + entrytablename + " u INNER JOIN " + ordertablename + " v ON v.finterid=u.Finterid " +
																" WHERE v.finterid=(SELECT MAX(finterid) FROM " + ordertablename + " WHERE FcurID=" + FcurID + ")  ",
																		 "sel");

			}
			catch { return; }

			if (dssel.Tables[0].Rows.Count == 0)
			{
				return;
			}
			this.dgvDetail.Rows.Add(dssel.Tables[0].Rows.Count + 10);
			for (int i = 0; i < dssel.Tables[0].Rows.Count; i++)
			{
				//表头
				if (i == 0)
				{
					this.txtFproperty.Text = dssel.Tables[0].Rows[i][0].ToString();
					this.txt_ptime.Text = dssel.Tables[0].Rows[i][1].ToString();
					this.txtCPH.Text = dssel.Tables[0].Rows[i][2].ToString();
					this.txtFnote.Text = dssel.Tables[0].Rows[i][3].ToString();
					this.txtFBillerName.Text = dssel.Tables[0].Rows[i][11].ToString();
				}

				this.dgvDetail.Rows[i].Selected = true;
				this.dgvDetail["Column_K3unitname", i].Value = "公斤";
				this.dgvDetail["Column_Fitemid", i].Value = dssel.Tables[0].Rows[i][4].ToString();
				add_ItemDataBese(dssel.Tables[0].Rows[i][4].ToString(), i);
				this.dgvDetail["Column_FunitName", i].Value = dssel.Tables[0].Rows[i][6].ToString();

				getItemUnitFConversion(dssel.Tables[0].Rows[i][4].ToString(), dssel.Tables[0].Rows[i][6].ToString(), "公斤");
				this.dgvDetail["Column_FQty", i].Value = dssel.Tables[0].Rows[i][5].ToString();
				this.dgvDetail["Column_Fzlbz", i].Value = dssel.Tables[0].Rows[i][7].ToString();
				this.dgvDetail["Column_Fpsyq", i].Value = dssel.Tables[0].Rows[i][8].ToString();
				this.dgvDetail["Column_Fnote", i].Value = dssel.Tables[0].Rows[i][9].ToString();
				this.dgvDetail["Column_Fpighead", i].Value = dssel.Tables[0].Rows[i][10].ToString();


			}
			this.save_checkorder();
			this.dgvDetail.Rows[0].Selected = true;




		}



		private void btnADD_Click(object sender, EventArgs e)
		{//新增
			//清空
			this.Finterid = "0";
			this.Fstatus = "0";
			this.Fbillno = "";
			this.FcurID = "0";
			this.FdepID = "";
			this.txtFBillerName.Text = PropertyClass.OperatorName;
			this.DT_pdate.Value = DateTime.Now.AddDays(1);
			this.txtFdate.Text = DateTime.Now.ToString("yyyy-MM-dd");
			this.txtSumFamout.Text = "0";
			if (this.ZtType == "M")
			{
				this.txtFbillno.Text = commUse.SelBillno("yx_orderM", ZtRyconstring);
				this.txtFempName.ReadOnly = false;
				this.label7.Visible = true;
				this.txtFfpts.Visible = true;//分配头数可见

				if (DateTime.Now.Hour >= 15)
				{
					this.cmborderType.Text = "B";

				}
				else
				{
					this.cmborderType.Text = "A";
				}

			}
			else
			{
				this.txtFbillno.Text = commUse.SelBillno("yx_order", ZtRyconstring);
			}
			this.txtFcurname.Text = "";
			this.txtFcurNumber.Text = "";
			this.txtFcurAdder.Text = "";
			this.txtFdepName.Text = "";
			this.txtFdepNumber.Text = "";
			this.txtFempName.Text = "";

			this.txt_ptime.Text = "";
			this.txtFproperty.Text = "";
			this.txtCPH.Text = "";
			this.txtFnote.Text = "";

			this.txtFConfirmerName.Text = "";
			this.txtFcheckName.Text = "";

			this.txtFConfirmerDate.Text = ""; ;
			this.txtFcheckdate.Text = ""; ;
			this.txtFStause.Text = ""; ;
			this.dataGridView2.Visible = false;
			this.txtFcurname.ReadOnly = false;
			this.txt_ptime.ReadOnly = false;
			this.txtFproperty.ReadOnly = false;
			this.txtCPH.ReadOnly = false;
			this.txtFnote.ReadOnly = false;
			this.cmborderType.Enabled = true;
			int dgvcount = this.dgvDetail.Rows.Count;
			for (int i = 0; i < dgvcount; i++)
			{
				this.dgvDetail.Rows.RemoveAt(0);
			}
			//this.dgvDetail.Rows.Add(20);
			if (this.fType == "SEL")
			{
				this.dgvDetail.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDetail_CellValueChanged);
				this.dgvDetail.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dgvDetail_RowPostPaint);
				this.dgvDetail.CellStateChanged += new System.Windows.Forms.DataGridViewCellStateChangedEventHandler(this.dgvDetail_CellStateChanged);
				this.dgvDetail.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dgvDetail_EditingControlShowing);
			}


			this.dgvDetail.ReadOnly = false;
			this.fType = "ADD";
			this.Text = "销售计划单--新增";


		}

		private void tsbtnEdit_Click(object sender, EventArgs e)
		{//edit
			if (this.fType == "ADD") { return; }
			if (this.fType == "SEL")
			{
				if (Int32.Parse(this.Fstatus) > 1)
				{
					MessageBox.Show("该单据状态不允许编辑！");
					return;

				}

				OnFcurIDGetBase(FcurID);

				//先取得信用额度
				//SqlParameter param = new SqlParameter("@FcurIDs", SqlDbType.VarChar);
				// param.Value = FcurID;
				// //创建泛型
				// List<SqlParameter> parameters = new List<SqlParameter>();
				// parameters.Add(param);
				// //把泛型中的元素复制到数组中
				// SqlParameter[] inputParameters = parameters.ToArray();

				// YXK3FZ.DataClass.DataBase ztdb = new YXK3FZ.DataClass.DataBase(ZtRyconstring);
				// DataSet dsIcc = ztdb.GetProcDataSet("yx_sp_getICCredit", inputParameters);
				// this.txtICCredit.Text = dsIcc.Tables[0].Rows[0][0].ToString();



				this.dataGridView2.Visible = false;
				this.txtFcurname.ReadOnly = false;
				this.txt_ptime.ReadOnly = false;
				this.txtFproperty.ReadOnly = false;
				this.txtCPH.ReadOnly = false;
				this.txtFnote.ReadOnly = false;
				if (this.ZtType == "M")
				{
					txtFempName.ReadOnly = false;
					this.cmborderType.Enabled = true;
				}
				this.dgvDetail.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDetail_CellValueChanged);
				this.dgvDetail.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dgvDetail_RowPostPaint);
				this.dgvDetail.CellStateChanged += new System.Windows.Forms.DataGridViewCellStateChangedEventHandler(this.dgvDetail_CellStateChanged);
				this.dgvDetail.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dgvDetail_EditingControlShowing);
				// this.dgvDetail.ReadOnly = false;
				dgvEditStasue();
				this.dgvDetail.Rows.Add(5);
				this.fType = "EDIT";
				this.Text = "销售计划单--编辑";


			}



		}

		private void btnConfirmer_Click(object sender, EventArgs e)
		{
			if (this.fType != "SEL")
			{
				MessageBox.Show("该单据还没有保存！");
				return;

			}
			if (MessageBox.Show("确认要确认该单据？", "消息对话框！", MessageBoxButtons.YesNoCancel,
					MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1) != DialogResult.Yes)
			{
				return;
			}
			if (Int32.Parse(this.Fstatus) != 0)
			{
				MessageBox.Show("不允许确认！");
				return;

			}
			string updateSql = " UPDATE dbo.yx_order SET Fstatus=1,FConfirmerName='" + PropertyClass.OperatorName + "',FConfirmerdate='" +
												 DateTime.Now.ToString("yyyy-MM-dd") + "' WHERE Finterid=" + Finterid;
			if (this.ZtType == "M")
			{
				updateSql = " UPDATE dbo.yx_orderM SET Fstatus=1,FConfirmerName='" + PropertyClass.OperatorName + "',FConfirmerdate='" +
													 DateTime.Now.ToString("yyyy-MM-dd") + "' WHERE Finterid=" + Finterid;

			}


			try
			{
				DataBase upDb = new DataBase(this.ZtRyconstring);
				upDb.ExecDataBySql(updateSql);
				MessageBox.Show("确认成功");

				this.selLoad(this.Finterid);

			}
			catch (Exception ex)
			{
				MessageBox.Show("确认失败！原因：" + ex.ToString());
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

				this.selLoad(this.Finterid);

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


			if (Int32.Parse(this.Fstatus) != 1)
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

				this.selLoad(this.Finterid);

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

				this.selLoad(this.Finterid);

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
				btnCheck_Click(null, null);

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
			else
			{
				MessageBox.Show("没有权限！");
			}
		}

		private void 保存ToolStripMenuItem_Click(object sender, EventArgs e)
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
		public void getMDfpts(string FcurID)
		{
			string selSql = " SELECT ffpqty FROM yx_mdfpts WHERE fdate='" + txtFdate.Text + "' AND fmdid=" + FcurID;
			DataBase dbsel = new DataBase(this.ZtRyconstring);
			DataSet dssel = new DataSet();
			try
			{

				dssel = dbsel.GetDataSet(selSql, "sel");

			}
			catch { return; }

			if (dssel.Tables[0].Rows.Count == 0)
			{
				return;
			}
			this.txtFfpts.Text = dssel.Tables[0].Rows[0][0].ToString();

		}







	}
}
