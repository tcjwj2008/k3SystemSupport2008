using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
//using System.Linq;
using System.Text;
using System.Windows.Forms;
using YXK3FZ.DataClass;
using YXK3FZ.Properties;
using YXK3FZ.ComClass;
using YXK3FZ.SY;
using YXK3FZ.CC;
using YXK3FZ.CW;
using YXK3FZ.SO;
using YXK3FZ.RYGYL;
using YXK3FZ.RP.from;
using System.Threading;
using System.Reflection;
using YXK3FZ.RYGYL.RP.rpt;
using YXK3FZ.RYGYL.RP.from;


namespace YXK3FZ
{
    public partial class mainForm : Form
    {
        private delegate void MyHandler();
       // private frmWaiting frmwaiting = null;
        public mainForm()
        {
            InitializeComponent();
        }

        //
        //private void ShowfrmWaiting()
        //{
        //     frmwaiting = new frmWaiting();

        //    frmwaiting.ShowDialog();

        //    //frmwaiting = null;
        //}

        //public void ThreadFun()
        //{
        //   this.BeginInvoke(new MyHandler(ShowfrmWaiting));
        //   Thread.Sleep(6000);
        //   this.Invoke(new MyHandler(frmwaiting.Close));
        //}



        //


        private void mainForm_Load(object sender, EventArgs e)
        {
            this.labUser.Text = "当前操作:"+PropertyClass.OperatorName;
            //tabControl2
          this.tabControl2.DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed;
            this.tabControl2.Alignment = System.Windows.Forms.TabAlignment.Left;

            this.tabControl3.DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed;
            this.tabControl3.Alignment = System.Windows.Forms.TabAlignment.Left;

            this.tabYZGL.DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed;
            this.tabYZGL.Alignment = System.Windows.Forms.TabAlignment.Left;

						this.tabControl6.DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed;
						this.tabControl6.Alignment = System.Windows.Forms.TabAlignment.Left;
            

           // this.tabPage10.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
           // this.tabPage1.Size = new System.Drawing.Size(156, 92);
           // this.tabPage1.TabIndex = 0;
           // this.tabPage1.Text = "海宁1";


            //this.tabPage10.Text = "销售订单";


        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (PropertyClass.IsAdmin == "1")
            {
                OperatorForm frmOperator = new OperatorForm();
                frmOperator.Show();

            }
            else
            {
                MessageBox.Show("需管理员权限！", "软件提示");
                return;
            }

        }

        private void mainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Dispose();
            System.Windows.Forms.Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (PropertyClass.IsAdmin == "1")
            {
                FormAssignRight FormAssignRight = new FormAssignRight();
                FormAssignRight.Show();

            }
            else
            {
                MessageBox.Show("需管理员权限！", "软件提示");
                return;
            }
        }

        private void mainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("确定要退出吗？", "软件提示", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                e.Cancel = false;
            }
            else
            {
                e.Cancel = true;
                System.Windows.Forms.Application.Exit();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {

              frmPwd frmPwd= new frmPwd();
              frmPwd.Show();  

        }

        private void button4_Click(object sender, EventArgs e)
        {
            frm_sp_in_icstock_xs frm_sp_in_icstock_xs = new frm_sp_in_icstock_xs();
            frm_sp_in_icstock_xs.Show();

        }

				private void button22_Click(object sender, EventArgs e) //肉业帐套—导入销售出库
				{
					frm_ry_in_icstock_xs frm_ry_in_icstock_xs = new frm_ry_in_icstock_xs();
					frm_ry_in_icstock_xs.Show();
				}

        private void button5_Click(object sender, EventArgs e)
        {
            frmBTpfsk frmBTpfsk = new frmBTpfsk();
            frmBTpfsk.Show();

        }

        private void button7_Click(object sender, EventArgs e)
        {
            frmWordNote frmWordNote = new frmWordNote();
            frmWordNote.Show();

        }

        private void button6_Click(object sender, EventArgs e)
        {
          
            WaitFormService.CreateWaitForm();
            WaitFormService.SetWaitFormCaption(" yyyyyyyyyyyyyyy");
           // Assembly asmb = Assembly.GetExecutingAssembly();
           //Object obj = asmb.CreateInstance("frmWaiting");
           //Form frmWaiting = obj as Form;
           // this.Visible = false;
           // this.ShowDialog(frmWaiting);

            int i = 1;
            while (i < 1000000000)
            {
                i = i + 1;

            }

            WaitFormService.CloseWaitForm();
          //  this.Visible = true;

        }

        private void button8_Click(object sender, EventArgs e)
        {//单价

            frmPriceMager frmPriceMage = new frmPriceMager();
            frmPriceMage.Show();

        }

        private void button6_Click_1(object sender, EventArgs e)
        {//食品应收站款表
            frmSPyszk frmSPyszk = new frmSPyszk();
            frmSPyszk.Show();

        }

        private void button9_Click(object sender, EventArgs e)
        {
            FrmRYmdseorder frmRYmdseorder = new FrmRYmdseorder();
            frmRYmdseorder.Show();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            frmSeorderPlan frmSeorderPlan = new frmSeorderPlan();
            frmSeorderPlan.Show();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            frmDzpYsTJ frmDzpYsTJ = new frmDzpYsTJ();
            frmDzpYsTJ.DB_ID = 4;  //传递数据库表所在连接字符串
            frmDzpYsTJ.Show();
        }

        private void button17_Click(object sender, EventArgs e)
        {
            frmDzpYsTJ frmDzpYsTJ = new frmDzpYsTJ();
            frmDzpYsTJ.DB_ID = 7;  //传递数据库表所在连接字符串
            frmDzpYsTJ.Text += "Demo1";
            frmDzpYsTJ.Show();
        }

				private void button25_Click(object sender, EventArgs e)
				{
					frmDzpYsTJ frmDzpYsTJ = new frmDzpYsTJ();
					frmDzpYsTJ.DB_ID = 17;  //传递数据库表所在连接字符串
					frmDzpYsTJ.Text += "历史";
					frmDzpYsTJ.Show();
				}


        private void button13_Click(object sender, EventArgs e)
        {
            frmDzpYsmx frmDzpYsmx = new frmDzpYsmx();
            frmDzpYsmx.DB_ID = 4;//传递数据库表所在连接字符串
            frmDzpYsmx.Show();
        }

        private void button18_Click(object sender, EventArgs e)
        {
            frmDzpYsmx frmDzpYsmx = new frmDzpYsmx();
            frmDzpYsmx.DB_ID = 7;//传递数据库表所在连接字符串
            frmDzpYsmx.Text += "Demo1";
            frmDzpYsmx.Show();
        }

		

				private void button26_Click(object sender, EventArgs e)
				{
					frmDzpYsmx frmDzpYsmx = new frmDzpYsmx();
					frmDzpYsmx.DB_ID = 17;//传递数据库表所在连接字符串
					frmDzpYsmx.Text += "历史";
					frmDzpYsmx.Show();
				}


				//肉业食品经营表
        private void button14_Click(object sender, EventArgs e)
        {
            //frmNewRSjy frmNewRSjy = new frmNewRSjy();
            //frmNewRSjy.Show();

            //frmRSjy frmRSjy = new frmRSjy();
            //frmRSjy.Show();  

            FRMRSJYB FRMRSJYB = new FRMRSJYB();
            FRMRSJYB.Show();


        }
				//肉业食品经营表New
				private void button24_Click(object sender, EventArgs e)
				{
					frmNewRSjy frmNewRSjy = new frmNewRSjy();
					frmNewRSjy.Show();  
				}

        private void button15_Click(object sender, EventArgs e)
        {
            //frmSpZydNew frmSpZydnew = new frmSpZydNew();

            //frmSpZydnew.Show();
        }

        private void tabControl2_DrawItem(object sender, DrawItemEventArgs e)
        {//实现tabControl的文字从左到右

           Rectangle tabTextArea = tabControl2.GetTabRect(e.Index);
           
            Graphics g = e.Graphics;
            StringFormat sf = new StringFormat();
            sf.LineAlignment = StringAlignment.Center;
            sf.Alignment = StringAlignment.Center;
            Font font = this.tabControl2.Font;
            SolidBrush brush = new SolidBrush(Color.Black);
            g.DrawString(((TabControl)(sender)).TabPages[e.Index].Text, font, brush, tabTextArea, sf);



        }

				private void listBox1_DoubleClick(object sender, EventArgs e) //肉业供应链管理——销售订单——双击
        {          
            if (this.listBox1.SelectedItem==null)
            {
                return;
            }

            if (this.listBox1.SelectedItem.ToString() == "肉业销售订单__新增")
						{
							#region 肉业销售订单__新增
							foreach (Form f in Application.OpenForms)
                {
                    if (f.Name == "frmOrder")
                    {
                        f.Activate();
                        return;
                    }
                }
             
                frmOrder frmOrder = new frmOrder("R","ADD", null);
              
                frmOrder.Show();

							#endregion
						}
						else if (this.listBox1.SelectedItem.ToString() == "肉业销售订单__新增N")
						{
							#region 肉业销售订单__新增N
							foreach (Form f in Application.OpenForms)
							{
								if (f.Name == "frmROrder")
								{
									f.Activate();
									return;
								}
							}

							YXK3FZ.RYGYL.frmROrder frmROrder = new YXK3FZ.RYGYL.frmROrder("R", "ADD", null);
							frmROrder.Show();

							#endregion
						}
						else if (this.listBox1.SelectedItem.ToString() == "屠宰计划")
						{
							#region 屠宰计划
							foreach (Form f in Application.OpenForms)
                {
                    if (f.Name == "frm_yx_tzjh")
                    {
                        f.Activate();
                        return;
                    }
                }
                frm_yx_tzjh frm_yx_tzjh = new frm_yx_tzjh();
                frm_yx_tzjh.Show();
							#endregion
						}
						else if (this.listBox1.SelectedItem.ToString() == "肉业销售订单__维护")
						{
							#region 肉业销售订单__维护
							foreach (Form f in Application.OpenForms)
                {
                   
                    if (f.Name == "frmOrderList")
                    {
                        f.Activate();
                        return;
                    }
                }
                frmOrderList frmOrderList = new frmOrderList("R");
                frmOrderList.Show();
							#endregion
						}
						else if (this.listBox1.SelectedItem.ToString() == "肉业销售订单__维护N")
						{
							#region 肉业销售订单__维护N
							foreach (Form f in Application.OpenForms)
							{

								if (f.Name == "frmOrderList")
								{
									f.Activate();
									return;
								}
							}
							frmROrderList frmOrderList = new frmROrderList("R");
							frmOrderList.Show();
							#endregion
						}
						else if (this.listBox1.SelectedItem.ToString() == "排单结余表")
						{
							#region 排单结余表
							foreach (Form f in Application.OpenForms)
                {

                    if (f.Name == "frm_rp_pdjy")
                    {
                        f.Activate();
                        return;
                    }
                }
                frm_rp_pdjy frm_rp_pdjy = new frm_rp_pdjy();
                frm_rp_pdjy.Show();

							#endregion
						}
						else if (this.listBox1.SelectedItem.ToString() == "销售订单汇总表（打印）")
						{
							#region 销售订单汇总表（打印）
							foreach (Form f in Application.OpenForms)
                {

                    if (f.Name == "  frm_ry_orderMary")
                    {
                        f.Activate();
                        return;
                    }
                }
                frm_ry_orderMary frm_ry_orderMary = new frm_ry_orderMary();
                frm_ry_orderMary.Show();

							#endregion
						}

        }

        private void lisbSet_DoubleClick(object sender, EventArgs e)
        {
            if (this.lisbSet.SelectedItem.ToString() == "单位换算设置")
            {
                frm_YX_ICitemSet frm_YX_ICitemSet = new frm_YX_ICitemSet();
                frm_YX_ICitemSet.Show();


            } 
              if (this.lisbSet.SelectedItem.ToString() == "信用白名单设置")
            {
                frm_yx_WhiteList frm_yx_WhiteList = new frm_yx_WhiteList("W");
                frm_yx_WhiteList.Show();


            }

              if (this.lisbSet.SelectedItem.ToString() == "订单单价取向设置")
              {
                  frm_yx_WhiteList frm_yx_WhiteList = new frm_yx_WhiteList("P");
                  frm_yx_WhiteList.Show();


              }
              if (this.lisbSet.SelectedItem.ToString() == "唯一单位(头)设置")
              {
                  frm_yx_WhiteList frm_yx_WhiteList = new frm_yx_WhiteList("U");
                  frm_yx_WhiteList.Show();


              }
              if (this.lisbSet.SelectedItem.ToString() == "订单单价可修改设置")
              {
                  frm_yx_WhiteList frm_yx_WhiteList = new frm_yx_WhiteList("K");
                  frm_yx_WhiteList.Show();


              }




        }

        private void listBox2_DoubleClick(object sender, EventArgs e)
        {

            if (this.listBox2.SelectedItem == null)
            {
                return;
            }
						//基础数据录入

						if (this.listBox2.SelectedItem.ToString() == "基础数据录入")
						{
							#region 基础数据录入
							foreach (Form f in Application.OpenForms)
							{
								if (f.Name == "frmSPBase")
								{
									f.Activate();
									return;
								}
							}

							YXK3FZ.SP.frmSPBase frm = new YXK3FZ.SP.frmSPBase ();
							frm.Show();
							#endregion
						}
						else if (this.listBox2.SelectedItem.ToString() == "业务员基数")
						{
							#region 业务员基数
							foreach (Form f in Application.OpenForms)
							{
								if (f.Name == "frm_yx_EmpJS")
								{
									f.Activate();
									return;
								}
							}

							frm_yx_EmpJS frm_yx_EmpJS = new frm_yx_EmpJS();

							frm_yx_EmpJS.Show();
							#endregion
						}
						else if (this.listBox2.SelectedItem.ToString() == "食品信用额度配置")
						{
							#region 食品信用额度配置
							foreach (Form f in Application.OpenForms)
							{
								if (f.Name == "frmXYBase")
								{
									f.Activate();
									return;
								}
							}

							YXK3FZ.SP.frmXYBase frmXYBase = new YXK3FZ.SP.frmXYBase();

							frmXYBase.Show();
							#endregion
						}

						else if (this.listBox2.SelectedItem.ToString() == "食品销售订单__新增")
						{
							#region 食品销售订单__新增
							foreach (Form f in Application.OpenForms)
                {
                    if (f.Name == "frmOrder")
                    {
                        f.Activate();
                        return;
                    }
                }

                frmOrder frmOrderS = new frmOrder("S", "ADD", null);

                frmOrderS.Show();

							#endregion
						}
						else if (this.listBox2.SelectedItem.ToString() == "食品销售订单__新增N")
						{
							#region 食品销售订单__新增N
							foreach (Form f in Application.OpenForms)
							{
								if (f.Name == "frmOrderS")
								{
									f.Activate();
									return;
								}
							}

							frmSOrder frmOrderS = new frmSOrder("S", "ADD", null);

							frmOrderS.Show();

							#endregion
						}							
						else if (this.listBox2.SelectedItem.ToString() == "食品销售订单__维护")
						{
							#region 食品销售订单__维护
							foreach (Form f in Application.OpenForms)
                {

                    if (f.Name == "frmOrderListS")
                    {
                        f.Activate();
                        return;
                    }
                }
                frmOrderList frmOrderListS = new frmOrderList("S");
                frmOrderListS.Show();

							#endregion
						}
						else if (this.listBox2.SelectedItem.ToString() == "食品销售订单__维护N")
						{
							#region 食品销售订单__维护N
							foreach (Form f in Application.OpenForms)
							{

								if (f.Name == "frmOrderListS")
								{
									f.Activate();
									return;
								}
							}
							frmSOrderList frmOrderListS = new frmSOrderList("S");
							frmOrderListS.Show();

							#endregion
						}

						else if (this.listBox2.SelectedItem.ToString() == "食品销售计划表")
						{
							#region 食品销售计划表
							foreach (Form f in Application.OpenForms)
                {

                    if (f.Name == "frm_spOrderPlan")
                    {
                        f.Activate();
                        return;
                    }
                }
                frm_spOrderPlan frm_spOrderPlan = new frm_spOrderPlan();
                frm_spOrderPlan.Show();
							#endregion
						}
						else if (this.listBox2.SelectedItem.ToString() == "白条批发部级别明细表")
						{
							#region 白条批发部级别明细表
							foreach (Form f in Application.OpenForms)
                {

                    if (f.Name == "frm_yx_btpfjbmx")
                    {
                        f.Activate();
                        return;
                    }
                }
                frm_yx_btpfjbmx frm_yx_btpfjbmx = new frm_yx_btpfjbmx();
                frm_yx_btpfjbmx.Show();
							#endregion
						}
						else if (this.listBox2.SelectedItem.ToString() == "白条批发部级别明细表N")
						{
							#region 白条批发部级别明细表N
							foreach (Form f in Application.OpenForms)
							{

								if (f.Name == "frmBTpfmx02")
								{
									f.Activate();
									return;
								}
							}
							YXK3FZ.SP.frmBTpfmx02 frmBTpfmx02 = new YXK3FZ.SP.frmBTpfmx02 ();
							frmBTpfmx02.Show();
							#endregion
						}
						else if (this.listBox2.SelectedItem.ToString() == "价格差异N")
						{
							#region 价格差异N
							foreach (Form f in Application.OpenForms)
							{

								if (f.Name == "FrmPriceDiff")
								{
									f.Activate();
									return;
								}
							}
							YXK3FZ.SP.FrmPriceDiff FrmPriceDiff = new YXK3FZ.SP.FrmPriceDiff();
							FrmPriceDiff.Show();
							#endregion
							//FrmPriceDiff
						}
						else if (this.listBox2.SelectedItem.ToString() == "报表差异N")
						{
							#region 报表差异N
							foreach (Form f in Application.OpenForms)
							{

								if (f.Name == "FrmReportDiff")
								{
									f.Activate();
									return;
								}
							}
							YXK3FZ.SP.FrmReportDiff FrmReportDiff = new YXK3FZ.SP.FrmReportDiff();
							FrmReportDiff.Show();
							#endregion
						}




							//白条配送余额表
						else if (this.listBox2.SelectedItem.ToString() == "白条配送余额表")
						{
							#region 白条配送余额表
							foreach (Form f in Application.OpenForms)
							{

								if (f.Name == "frmBTpsyeb02")
								{
									f.Activate();
									return;
								}
							}
							YXK3FZ.SP.frmBTpsyeb02 frmBTpsyeb02 = new YXK3FZ.SP.frmBTpsyeb02();
							frmBTpsyeb02.Show();
							#endregion
						}

						else if (this.listBox2.SelectedItem.ToString() == "业务员每日基数完成表")
						{
							#region 业务员每日基数完成表
							foreach (Form f in Application.OpenForms)
							{

								if (f.Name == "frm_yx_ywyjswcb")
								{
									f.Activate();
									return;
								}
							}
							frm_yx_ywyjswcb frm_yx_ywyjswcb = new frm_yx_ywyjswcb();
							frm_yx_ywyjswcb.Show();
							#endregion
						}
						else if (this.listBox2.SelectedItem.ToString() == "门店分配头数")
						{
							#region 门店分配头数
							foreach (Form f in Application.OpenForms)
							{
								if (f.Name == "frm_yx_mdfpts")
								{
									f.Activate();
									return;
								}
							}

							frm_yx_mdfpts frm_yx_mdfpts = new frm_yx_mdfpts();

							frm_yx_mdfpts.Show();

							#endregion
						}
						else if (this.listBox2.SelectedItem.ToString() == "门店销售订单__新增")
						{
							#region 门店销售订单__新增
							foreach (Form f in Application.OpenForms)
							{
								if (f.Name == "frmOrderM")
								{
									f.Activate();
									return;
								}
							}

							frmOrder frmOrderM = new frmOrder("M", "ADD", null);

							frmOrderM.Show();
							#endregion
						}
						else if (this.listBox2.SelectedItem.ToString() == "门店销售订单__新增N")
						{
							#region 门店销售订单__新增N
							foreach (Form f in Application.OpenForms)
							{
								if (f.Name == "frmOrderM")
								{
									f.Activate();
									return;
								}
							}

							frmMOrder frmOrderM = new frmMOrder("M", "ADD", null);

							frmOrderM.Show();
							#endregion
						}
						else if (this.listBox2.SelectedItem.ToString() == "门店销售订单__维护")
						{
							#region 门店销售订单__维护
							foreach (Form f in Application.OpenForms)
							{

								if (f.Name == "frmOrderListM")
								{
									f.Activate();
									return;
								}
							}
							frmOrderList frmOrderListM = new frmOrderList("M");
							frmOrderListM.Show();
							#endregion
						}
						else if (this.listBox2.SelectedItem.ToString() == "门店销售订单__维护N")
						{
							#region 门店销售订单__维护N
							foreach (Form f in Application.OpenForms)
							{

								if (f.Name == "frmOrderListM")
								{
									f.Activate();
									return;
								}
							}
							frmMOrderList frmOrderListM = new frmMOrderList("M");
							frmOrderListM.Show();
							#endregion
						}
						else if (this.listBox2.SelectedItem.ToString() == "各直营店一次配送明细表")
						{
							#region 各直营店一次配送明细表
							foreach (Form f in Application.OpenForms)
							{

								if (f.Name == "frm_yx_zydpsmxb")
								{
									f.Activate();
									return;
								}
							}
							frm_yx_zydpsmxb frm_yx_zydpsmxb = new frm_yx_zydpsmxb();
							frm_yx_zydpsmxb.Show();
							#endregion
						}
						else if (this.listBox2.SelectedItem.ToString() == "直营店追加单")
						{
							#region 直营店追加单
							foreach (Form f in Application.OpenForms)
							{

								if (f.Name == "frm_yx_zydzjd")
								{
									f.Activate();
									return;
								}
							}
							frm_yx_zydzjd frm_yx_zydzjd = new frm_yx_zydzjd();
							frm_yx_zydzjd.Show();
							#endregion
						}


        }

        private void button16_Click(object sender, EventArgs e)
        {
            frmBTpfskdz frmBTpfskdz = new frmBTpfskdz();
            frmBTpfskdz.Show();
        }

        #region 筐具

        private void tabControl3_DrawItem(object sender, DrawItemEventArgs e)
        {
            //实现tabControl的文字从左到右
            Rectangle tabTextArea = tabControl3.GetTabRect(e.Index);
            Graphics g = e.Graphics;
            StringFormat sf = new StringFormat();
            sf.LineAlignment = StringAlignment.Center;
            sf.Alignment = StringAlignment.Center;
            Font font = this.tabControl3.Font;
            SolidBrush brush = new SolidBrush(Color.Black);
            g.DrawString(((TabControl)(sender)).TabPages[e.Index].Text, font, brush, tabTextArea, sf);
        }
        

        private void listBox3_DoubleClick(object sender, EventArgs e) //筐具出入库订单
        {
            #region 筐具出入库订单

            if (this.listBox3.SelectedItem==null)
            {
                return;                
            }


            if (this.listBox3.SelectedItem.ToString() == "筐具出入库订单__新增")
            {
                #region 筐具出入库订单__新增
                foreach (Form f in Application.OpenForms)
                {
                    if (f.Name == "frmDZPOrder")
                    {
                        f.Activate();
                        return;
                    }                 
                }
                DZPGL.frmDZPOrder frmOrder = new YXK3FZ.DZPGL.frmDZPOrder("D", "ADD", null);
                frmOrder.Show();

                #endregion
            }
            else if (this.listBox3.SelectedItem.ToString() == "筐具出入库订单__维护")
            {
                #region 筐具出入库订单__维护
                foreach (Form f in Application.OpenForms)
                {
                    if (f.Name == "frmDZPOrderList")
                    {
                        f.Activate();
                        return;
                    }
                }
                DZPGL.frmDZPOrderList frmOrderList = new YXK3FZ.DZPGL.frmDZPOrderList("D");
                frmOrderList.Show();

                #endregion
            }
            else if (this.listBox3.SelectedItem.ToString() == "筐具出入库订单__报表")
            {
                #region 筐具出入库订单__报表
                foreach (Form f in Application.OpenForms)
                {
                    if (f.Name == "frm_DZPKJ_orderMary")
                    {
                        f.Activate();
                        return;
                    }
                }
                DZPGL.frm_DZPKJ_orderMary frmorderMary = new YXK3FZ.DZPGL.frm_DZPKJ_orderMary();
                frmorderMary.Show();

                #endregion
            }

            #endregion

        }

        #endregion

        #region 油脂管理

        private void tabYZGL_DrawItem(object sender, DrawItemEventArgs e)
        {
            //实现tabControl的文字从左到右

            Rectangle tabTextArea = tabYZGL.GetTabRect(e.Index);

            Graphics g = e.Graphics;
            StringFormat sf = new StringFormat();
            sf.LineAlignment = StringAlignment.Center;
            sf.Alignment = StringAlignment.Center;
            Font font = this.tabControl3.Font;
            SolidBrush brush = new SolidBrush(Color.Black);
            g.DrawString(((TabControl)(sender)).TabPages[e.Index].Text, font, brush, tabTextArea, sf);
        }

        //加工日历
        private void listBox5_DoubleClick(object sender, EventArgs e)
        {
            if (this.listBox5.SelectedItem == null)
            {
                return;
						}

						#region 标题说明

						//[01新增] 生产部--车间--加工日历
						//[01维护] 生产部--车间--加工日历
						//--------------------------------------------
						//[02新增] 生产部--锅炉科--锅炉车间--加工日历
						//[02维护] 生产部--锅炉科--锅炉车间--加工日历 
						//--------------------------------------------
						//[03新增] 生产部--锅炉科--环保--加工日历
						//[03维护] 生产部--锅炉科--环保--加工日历 
						//--------------------------------------------
						//[04新增] 生产部--公用工程--水务科--加工日历(1) 
						//[04维护] 生产部--公用工程--水务科--加工日历(1)
						//--------------------------------------------
						//[05新增] 生产部--公用工程--水务科--加工日历(2) 
						//[05维护] 生产部--公用工程--水务科--加工日历(2) 
						//--------------------------------------------
						//[06新增] 生产部--公用工程--配电科--加工日历(1)
						//[06维护] 生产部--公用工程--配电科--加工日历(1)
						//--------------------------------------------  
						//[07新增] 生产部--公用工程--配电科--加工日历(2) 
						//[07维护] 生产部--公用工程--配电科--加工日历(2)  
						//--------------------------------------------
						//[08新增] 生产部--公用工程--机修科--加工日历
						//[08维护] 生产部--公用工程--机修科--加工日历 
						//--------------------------------------------
						//[09新增] 生产部--仓储--筒仓科--加工日历
						//[09维护] 生产部--仓储--筒仓科--加工日历
						//--------------------------------------------
						//[10新增] 生产部--仓储--油库科--加工日历 
						//[10维护] 生产部--仓储--油库科--加工日历
						//--------------------------------------------
						//[11新增] 生产部--仓储--粕库科--加工日历
						//[11维护] 生产部--仓储--粕库科--加工日历 
						//--------------------------------------------
						//[12新增] 品管部--质量--加工日历 
						//[12维护] 品管部--质量--加工日历 
						//--------------------------------------------
						//[13新增] 管理部--安全科--加工日历 
						//[13维护] 管理部--安全科--加工日历

						#endregion

						if (this.listBox5.SelectedItem.ToString().Substring(0, 6) == "[01新增]")
            {
                #region 生产部--车间--加工日历
                foreach (Form f in Application.OpenForms)
                {
                    if (f.Name == "frmYZOrder01")
                    {
                        f.Activate();
                        return;
                    }
                }
                YZGL.frmYZOrder01 frmOrder = new YXK3FZ.YZGL.frmYZOrder01("ADD", null);
                frmOrder.Show();

                #endregion
            }
						else if (this.listBox5.SelectedItem.ToString().Substring(0, 6) == "[01维护]")
						{
							#region 生产部--车间--加工日历维护
							foreach (Form f in Application.OpenForms)
							{
								if (f.Name == "frmYZOrderList01")
								{
									f.Activate();
									return;
								}
							}
							YZGL.frmYZOrderList01 frmYZOrderList01 = new YXK3FZ.YZGL.frmYZOrderList01();
							frmYZOrderList01.Show();

							#endregion
						}

						else if (this.listBox5.SelectedItem.ToString().Substring(0, 6) == "[02新增]")
						{
							#region 生产部--锅炉科--锅炉车间--加工日历
							foreach (Form f in Application.OpenForms)
							{
								if (f.Name == "frmYZOrder02")
								{
									f.Activate();
									return;
								}
							}
							YZGL.frmYZOrder02 frmOrder02 = new YXK3FZ.YZGL.frmYZOrder02("ADD", null);
							frmOrder02.Show();

							#endregion
						}
						else if (this.listBox5.SelectedItem.ToString().Substring(0, 6) == "[02维护]")
						{
							#region 生产部--锅炉科--锅炉车间--加工日历维护
							foreach (Form f in Application.OpenForms)
							{
								if (f.Name == "frmYZOrderList02")
								{
									f.Activate();
									return;
								}
							}
							YZGL.frmYZOrderList02 frmYZOrderList02 = new YXK3FZ.YZGL.frmYZOrderList02();
							frmYZOrderList02.Show();

							#endregion
						}

						else if (this.listBox5.SelectedItem.ToString().Substring(0, 6) == "[03新增]")
						{
							#region 生产部--锅炉科--环保--加工日历序时簿
							foreach (Form f in Application.OpenForms)
							{
								if (f.Name == "frmYZOrder03")
								{
									f.Activate();
									return;
								}
							}
							YZGL.frmYZOrder03 frmOrder03 = new YXK3FZ.YZGL.frmYZOrder03("ADD", null);
							frmOrder03.Show();

							#endregion
						}
						else if (this.listBox5.SelectedItem.ToString().Substring(0, 6) == "[03维护]")
						{
							#region 生产部--锅炉科--环保--加工日历序时簿维护
							foreach (Form f in Application.OpenForms)
							{
								if (f.Name == "frmYZOrderList03")
								{
									f.Activate();
									return;
								}
							}
							YZGL.frmYZOrderList03 frmYZOrderList03 = new YXK3FZ.YZGL.frmYZOrderList03();
							frmYZOrderList03.Show();

							#endregion
						}

						else if (this.listBox5.SelectedItem.ToString().Substring(0, 6) == "[04新增]")
						{
							#region 生产部--公用工程--水务科--加工日历(1)
							foreach (Form f in Application.OpenForms)
							{
								if (f.Name == "frmYZOrder04")
								{
									f.Activate();
									return;
								}
							}
							YZGL.frmYZOrder04 frmOrder04 = new YXK3FZ.YZGL.frmYZOrder04("ADD", null);
							frmOrder04.Show();

							#endregion
						}
						else if (this.listBox5.SelectedItem.ToString().Substring(0, 6) == "[04维护]")
						{
							#region 生产部--公用工程--水务科--加工日历(1)序时簿维护
							foreach (Form f in Application.OpenForms)
							{
								if (f.Name == "frmYZOrderList04")
								{
									f.Activate();
									return;
								}
							}
							YZGL.frmYZOrderList04 frmYZOrderList04 = new YXK3FZ.YZGL.frmYZOrderList04();
							frmYZOrderList04.Show();

							#endregion
						}


						else if (this.listBox5.SelectedItem.ToString().Substring(0, 6) == "[05新增]")
						{
							#region 生产部--公用工程--水务科--加工日历(2)
							foreach (Form f in Application.OpenForms)
							{
								if (f.Name == "frmYZOrder05")
								{
									f.Activate();
									return;
								}
							}
							YZGL.frmYZOrder05 frmOrder05 = new YXK3FZ.YZGL.frmYZOrder05("ADD", null);
							frmOrder05.Show();

							#endregion
						}
						else if (this.listBox5.SelectedItem.ToString().Substring(0, 6) == "[05维护]")
						{
							#region 生产部--公用工程--水务科--加工日历(2)序时簿维护
							foreach (Form f in Application.OpenForms)
							{
								if (f.Name == "frmYZOrderList05")
								{
									f.Activate();
									return;
								}
							}
							YZGL.frmYZOrderList05 frmYZOrderList05 = new YXK3FZ.YZGL.frmYZOrderList05();
							frmYZOrderList05.Show();

							#endregion
						}


						else if (this.listBox5.SelectedItem.ToString().Substring(0, 6) == "[06新增]")
						{
							#region 生产部--公用工程--配电科--加工日历(1)
							foreach (Form f in Application.OpenForms)
							{
								if (f.Name == "frmYZOrder06")
								{
									f.Activate();
									return;
								}
							}
							YZGL.frmYZOrder06 frmOrder06 = new YXK3FZ.YZGL.frmYZOrder06("ADD", null);
							frmOrder06.Show();

							#endregion
						}
						else if (this.listBox5.SelectedItem.ToString().Substring(0, 6) == "[06维护]")
						{
							#region 生产部--公用工程--配电科--加工日历(1)序时簿维护
							foreach (Form f in Application.OpenForms)
							{
								if (f.Name == "frmYZOrderList06")
								{
									f.Activate();
									return;
								}
							}
							YZGL.frmYZOrderList06 frmYZOrderList06 = new YXK3FZ.YZGL.frmYZOrderList06();
							frmYZOrderList06.Show();

							#endregion
						}


						else if (this.listBox5.SelectedItem.ToString().Substring(0, 6) == "[07新增]")
						{
							#region 生产部--公用工程--配电科--加工日历(2)
							foreach (Form f in Application.OpenForms)
							{
								if (f.Name == "frmYZOrder07")
								{
									f.Activate();
									return;
								}
							}
							YZGL.frmYZOrder07 frmOrder07 = new YXK3FZ.YZGL.frmYZOrder07("ADD", null);
							frmOrder07.Show();

							#endregion
						}
						else if (this.listBox5.SelectedItem.ToString().Substring(0, 6) == "[07维护]")
						{
							#region 生产部--公用工程--配电科--加工日历(2)序时簿维护
							foreach (Form f in Application.OpenForms)
							{
								if (f.Name == "frmYZOrderList07")
								{
									f.Activate();
									return;
								}
							}
							YZGL.frmYZOrderList07 frmYZOrderList07 = new YXK3FZ.YZGL.frmYZOrderList07();
							frmYZOrderList07.Show();

							#endregion
						}

						else if (this.listBox5.SelectedItem.ToString().Substring(0, 6) == "[08新增]")
						{
							#region 生产部--公用工程--机修科--加工日历
							foreach (Form f in Application.OpenForms)
							{
								if (f.Name == "frmYZOrder08")
								{
									f.Activate();
									return;
								}
							}
							YZGL.frmYZOrder08 frmOrder08 = new YXK3FZ.YZGL.frmYZOrder08("ADD", null);
							frmOrder08.Show();

							#endregion
						}
						else if (this.listBox5.SelectedItem.ToString().Substring(0, 6) == "[08维护]")
						{
							#region 生产部--公用工程--机修科--加工日历序时簿维护
							foreach (Form f in Application.OpenForms)
							{
								if (f.Name == "frmYZOrderList08")
								{
									f.Activate();
									return;
								}
							}
							YZGL.frmYZOrderList08 frmYZOrderList08 = new YXK3FZ.YZGL.frmYZOrderList08();
							frmYZOrderList08.Show();

							#endregion
						}

						else if (this.listBox5.SelectedItem.ToString().Substring(0, 6) == "[09新增]")
						{
							#region 生产部--仓储--筒仓科--加工日历
							foreach (Form f in Application.OpenForms)
							{
								if (f.Name == "frmYZOrder09")
								{
									f.Activate();
									return;
								}
							}
							YZGL.frmYZOrder09 frmOrder09 = new YXK3FZ.YZGL.frmYZOrder09("ADD", null);
							frmOrder09.Show();

							#endregion
						}
						else if (this.listBox5.SelectedItem.ToString().Substring(0, 6) == "[09维护]")
						{
							#region 生产部--仓储--筒仓科--加工日历序时簿维护
							foreach (Form f in Application.OpenForms)
							{
								if (f.Name == "frmYZOrderList09")
								{
									f.Activate();
									return;
								}
							}
							YZGL.frmYZOrderList09 frmYZOrderList09 = new YXK3FZ.YZGL.frmYZOrderList09();
							frmYZOrderList09.Show();

							#endregion
						}


						else if (this.listBox5.SelectedItem.ToString().Substring(0, 6) == "[10新增]")
						{
							#region 生产部--仓储--油库科--加工日历
							foreach (Form f in Application.OpenForms)
							{
								if (f.Name == "frmYZOrder10")
								{
									f.Activate();
									return;
								}
							}
							YZGL.frmYZOrder10 frmOrder10 = new YXK3FZ.YZGL.frmYZOrder10("ADD", null);
							frmOrder10.Show();

							#endregion
						}
						else if (this.listBox5.SelectedItem.ToString().Substring(0, 6) == "[10维护]")
						{
							#region 生产部--仓储--油库科--加工日历序时簿维护
							foreach (Form f in Application.OpenForms)
							{
								if (f.Name == "frmYZOrderList10")
								{
									f.Activate();
									return;
								}
							}
							YZGL.frmYZOrderList10 frmYZOrderList10 = new YXK3FZ.YZGL.frmYZOrderList10();
							frmYZOrderList10.Show();

							#endregion
						}


						else if (this.listBox5.SelectedItem.ToString().Substring(0, 6) == "[11新增]")
						{
							#region 生产部--仓储--粕库科--加工日历
							foreach (Form f in Application.OpenForms)
							{
								if (f.Name == "frmYZOrder11")
								{
									f.Activate();
									return;
								}
							}
							YZGL.frmYZOrder11 frmOrder11 = new YXK3FZ.YZGL.frmYZOrder11("ADD", null);
							frmOrder11.Show();

							#endregion
						}
						else if (this.listBox5.SelectedItem.ToString().Substring(0, 6) == "[11维护]")
						{
							#region 生产部--仓储--粕库科--加工日历序时簿维护
							foreach (Form f in Application.OpenForms)
							{
								if (f.Name == "frmYZOrderList11")
								{
									f.Activate();
									return;
								}
							}
							YZGL.frmYZOrderList11 frmYZOrderList11 = new YXK3FZ.YZGL.frmYZOrderList11();
							frmYZOrderList11.Show();

							#endregion
						}

						else if (this.listBox5.SelectedItem.ToString().Substring(0, 6) == "[12新增]")
						{
							#region 品管部--质量--加工日历
							foreach (Form f in Application.OpenForms)
							{
								if (f.Name == "frmYZOrder12")
								{
									f.Activate();
									return;
								}
							}
							YZGL.frmYZOrder12 frmOrder12 = new YXK3FZ.YZGL.frmYZOrder12("ADD", null);
							frmOrder12.Show();

							#endregion
						}
						else if (this.listBox5.SelectedItem.ToString().Substring(0, 6) == "[12维护]")
						{
							#region 品管部--质量--加工日历序时簿维护
							foreach (Form f in Application.OpenForms)
							{
								if (f.Name == "frmYZOrderList12")
								{
									f.Activate();
									return;
								}
							}
							YZGL.frmYZOrderList12 frmYZOrderList12 = new YXK3FZ.YZGL.frmYZOrderList12();
							frmYZOrderList12.Show();

							#endregion
						}

						else if (this.listBox5.SelectedItem.ToString().Substring(0, 6) == "[13新增]")
						{
							#region 管理部--安全科--加工日历
							foreach (Form f in Application.OpenForms)
							{
								if (f.Name == "frmYZOrder13")
								{
									f.Activate();
									return;
								}
							}
							YZGL.frmYZOrder13 frmOrder13 = new YXK3FZ.YZGL.frmYZOrder13("ADD", null);
							frmOrder13.Show();

							#endregion
						}
						else if (this.listBox5.SelectedItem.ToString().Substring(0, 6) == "[13维护]")
						{
							#region 管理部--安全科--加工日历序时簿维护
							foreach (Form f in Application.OpenForms)
							{
								if (f.Name == "frmYZOrderList13")
								{
									f.Activate();
									return;
								}
							}
							YZGL.frmYZOrderList13 frmYZOrderList13 = new YXK3FZ.YZGL.frmYZOrderList13();
							frmYZOrderList13.Show();

							#endregion
						}

        }

        //基础数据
        private void listBox6_DoubleClick(object sender, EventArgs e)
        {
            if (this.listBox6.SelectedItem == null)
            {
                return;
            }
            if (this.listBox6.SelectedItem.ToString() == "基础数据录入")
            {
                #region 班次
                foreach (Form f in Application.OpenForms)
                {
                    if (f.Name == "frmYZBase")
                    {
                        f.Activate();
                        return;
                    }
                }
                YZGL.frmYZBase frmOrder = new YXK3FZ.YZGL.frmYZBase();
                frmOrder.Show();

                #endregion
            }


        }

				//锅炉烟气排放数据统计
				private void listBox10_DoubleClick(object sender, EventArgs e)
				{
					if (this.listBox10.SelectedItem == null)
					{
						return;
					}
					if (this.listBox10.SelectedItem.ToString() == "参数指标设定")
					{
						#region 参数指标设定

						foreach (Form f in Application.OpenForms)
						{
							if (f.Name == "frmYZParameterSet")
							{
								f.Activate();
								return;
							}
						}
						YZGL.frmYZParameterSet frmYZParameterSet = new YXK3FZ.YZGL.frmYZParameterSet();
						frmYZParameterSet.Show();


						#endregion
					}
					else if (this.listBox10.SelectedItem.ToString() == "每月计划列表")
					{
						#region 每月计划列表

						foreach (Form f in Application.OpenForms)
						{
							if (f.Name == "frmYZPerMonthProject")
							{
								f.Activate();
								return;
							}
						}
						YZGL.frmYZPerMonthProject frmYZPerMonthProject = new YXK3FZ.YZGL.frmYZPerMonthProject();
						frmYZPerMonthProject.Show();


						#endregion
					}
					else if (this.listBox10.SelectedItem.ToString() == "数据查询列表")
					{
						#region 数据查询列表
						foreach (Form f in Application.OpenForms)
						{
							if (f.Name == "frmFImportDataList")
							{
								f.Activate();
								return;
							}
						}
						YZGL.frmFImportDataList frmFImportDataList = new YXK3FZ.YZGL.frmFImportDataList();
						frmFImportDataList.Show();

						#endregion
					}
					//银祥油脂生产系统年度查询
					if (this.listBox10.SelectedItem.ToString() == "生产系统年度查询")
					{
						#region 生产系统年度查询

						foreach (Form f in Application.OpenForms)
						{
							if (f.Name == "frmYZYearSelect")
							{
								f.Activate();
								return;
							}
						}
						YZGL.frmYZYearSelect frmYZYearSelect = new YXK3FZ.YZGL.frmYZYearSelect();
						frmYZYearSelect.Show();


						#endregion
					}
				}

        #endregion

     
        //肉业－－日成本计算

        private void listBox4_DoubleClick(object sender, EventArgs e)
        {
            if (this.listBox4.SelectedItem == null)
                return;

            if (this.listBox4.SelectedItem.ToString() == "系数设置")
            {
                #region 系数设置
                foreach (Form f in Application.OpenForms)
                {
                    if (f.Name == "frmXSBase")
                    {
                        f.Activate();
                        return;
                    }
                }
                YXK3FZ.RYGL.frmXSBase frm = new YXK3FZ.RYGL.frmXSBase();
                frm.Show();

                #endregion
            }
            else if (this.listBox4.SelectedItem.ToString() == "成本查询")
            {
                #region 成本查询
                foreach (Form f in Application.OpenForms)
                {
                    if (f.Name == "frmCostQueryForm")
                    {
                        f.Activate();
                        return;
                    }
                }
                YXK3FZ.RYGL.frmCostQueryForm frm = new YXK3FZ.RYGL.frmCostQueryForm();
                frm.Show();

                #endregion
            }
            else if (this.listBox4.SelectedItem.ToString() == "每天数据录入")
            {
                #region 每天数据录入
                foreach (Form f in Application.OpenForms)
                {
                    if (f.Name == "frmRYGLDayBase")
                    {
                        f.Activate();
                        return;
                    }
                }
                YXK3FZ.RYGL.frmRYGLDayBase frm = new YXK3FZ.RYGL.frmRYGLDayBase();
                frm.Show();

                #endregion
            }
            else if (this.listBox4.SelectedItem.ToString() == "每月数据录入")
            {
                #region 每月数据录入
                foreach (Form f in Application.OpenForms)
                {
                    if (f.Name == "frmRYGLMonthBase")
                    {
                        f.Activate();
                        return;
                    }
                }
                YXK3FZ.RYGL.frmRYGLMonthBase frm = new YXK3FZ.RYGL.frmRYGLMonthBase();
                frm.Show();

                #endregion
            }
						else if (this.listBox4.SelectedItem.ToString() == "数据汇总查询")
						{

							#region 数据汇总查询

							foreach (Form f in Application.OpenForms)
							{
								if (f.Name == "frmQuery")
								{
									f.Activate();
									return;
								}
							}
							YXK3FZ.RYGL.frmQuery frm = new YXK3FZ.RYGL.frmQuery();
							frm.Show();


							#endregion

						}
						else if (this.listBox4.SelectedItem.ToString() == "肉业公司日成本分析")
						{

							#region 肉业公司日成本分析

							foreach (Form f in Application.OpenForms)
							{
								if (f.Name == "frmRYDayPrice")
								{
									f.Activate();
									return;
								}
							}
							YXK3FZ.RYGL.frmRYDayPrice frm = new YXK3FZ.RYGL.frmRYDayPrice();
							frm.Show();


							#endregion

						}
					


        }


				//饲料厂
			  private void listBox11_DoubleClick(object sender, EventArgs e) //饲料厂
				{
					if (this.listBox11.SelectedItem == null)
					{
						return;
					}

					if (this.listBox11.SelectedItem.ToString() == "基础数据录入")
					{
						#region 基础数据录入
						foreach (Form f in Application.OpenForms)
						{
							if (f.Name == "frmYXSLHLBBase")
							{
								f.Activate();
								return;
							}
						}
						YXSLHLB.frmYXSLHLBBase frmYXSLHLBBase = new YXK3FZ.YXSLHLB.frmYXSLHLBBase ();
						frmYXSLHLBBase.Show();

						#endregion
					}
				}


				//肉业应收对账表
				private void button19_Click(object sender, EventArgs e)
				{

				}

				private void button20_Click(object sender, EventArgs e)
				{
					frmDzpYsTJ frmDzpYsTJ = new frmDzpYsTJ();
					frmDzpYsTJ.DB_ID = 2;  //传递数据库表所在连接字符串
					frmDzpYsTJ.Show();
				}

				private void button21_Click(object sender, EventArgs e)
				{
					frmDzpYsmx frmDzpYsmx = new frmDzpYsmx();
					frmDzpYsmx.DB_ID = 2;//传递数据库表所在连接字符串
					frmDzpYsmx.Show();
				}

				private void listBox12_DoubleClick(object sender, EventArgs e)
				{
					if (this.listBox12.SelectedItem == null)
					{
						return;
					}

					if (this.listBox12.SelectedItem.ToString() == "项目维护")
					{
						#region 项目维护
						foreach (Form f in Application.OpenForms)
						{
							if (f.Name == "frmYZProject")
							{
								f.Activate();
								return;
							}
						}
						YXK3FZ.YZGL.frmYZProject frmYZProject = new YXK3FZ.YZGL.frmYZProject();
						frmYZProject.Show();

						#endregion
					}
					else if (this.listBox12.SelectedItem.ToString() == "部门年度自填数据")
					{
						#region 部门年度自填数据
						foreach (Form f in Application.OpenForms)
						{
							if (f.Name == "frmYZDepartYearData")
							{
								f.Activate();
								return;
							}
						}
						YXK3FZ.YZGL.frmYZDepartYearData frmYZDepartYearData = new YXK3FZ.YZGL.frmYZDepartYearData();
						frmYZDepartYearData.Show();

						#endregion
					}
					else if (this.listBox12.SelectedItem.ToString() == "船次自填数据")
					{
						#region 船次自填数据
						foreach (Form f in Application.OpenForms)
						{
							if (f.Name == "frmYZBoatYearData")
							{
								f.Activate();
								return;
							}
						}
						YXK3FZ.YZGL.frmYZBoatYearData frmYZBoatYearData = new YXK3FZ.YZGL.frmYZBoatYearData();
						frmYZBoatYearData.Show();

						#endregion
					}
					else if (this.listBox12.SelectedItem.ToString() == "油脂绩效考核查询")
					{
						#region 油脂绩效考核查询
						foreach (Form f in Application.OpenForms)
						{
							if (f.Name == "frmYZJXKHSelect")
							{
								f.Activate();
								return;
							}
						}
						YXK3FZ.YZGL.frmYZJXKHSelect frmYZJXKHSelect = new YXK3FZ.YZGL.frmYZJXKHSelect();
						frmYZJXKHSelect.Show();

						#endregion
					}
					else if (this.listBox12.SelectedItem.ToString() == "水电部门自填数据")
					{						
						#region 水电部门自填数据
						foreach (Form f in Application.OpenForms)
						{
							if (f.Name == "frmYZWaterElecData")
							{
								f.Activate();
								return;
							}
						}
						YXK3FZ.YZGL.frmYZWaterElecData frmYZWaterElecData = new YXK3FZ.YZGL.frmYZWaterElecData();
						frmYZWaterElecData.Show();

						#endregion
					}
					else if (this.listBox12.SelectedItem.ToString() == "年度绩效考核成本指标数据(按分项)")
					{
						#region 年度绩效考核成本指标数据(按分项)
						foreach (Form f in Application.OpenForms)
						{
							if (f.Name == "YZ_FYearData")
							{
								f.Activate();
								return;
							}
						}
						YXK3FZ.YZGL.YZ_FYearData YZ_FYearData = new YXK3FZ.YZGL.YZ_FYearData();
						YZ_FYearData.Show();

						#endregion
					}
					else if (this.listBox12.SelectedItem.ToString() == "年度绩效考核成本指标数据(按部门)")
					{
						#region 年度绩效考核成本指标数据(按部门)
						foreach (Form f in Application.OpenForms)
						{
							if (f.Name == "YZ_FYearDataByDept")
							{
								f.Activate();
								return;
							}
						}
						YXK3FZ.YZGL.YZ_FYearDataByDept YZ_FYearDataByDept = new YXK3FZ.YZGL.YZ_FYearDataByDept();
						YZ_FYearDataByDept.Show();

						#endregion
					}
					else if (this.listBox12.SelectedItem.ToString() == "船次绩效考核成本指标(按分项)查询")
					{
						#region 船次绩效考核成本指标(按分项)查询
						foreach (Form f in Application.OpenForms)
						{
							if (f.Name == "YZ_FBoatJXKH_ByProjet")
							{
								f.Activate();
								return;
							}
						}
						YXK3FZ.YZGL.YZ_FBoatJXKH_ByProjet YZ_FBoatJXKH_ByProjet = new YXK3FZ.YZGL.YZ_FBoatJXKH_ByProjet();
						YZ_FBoatJXKH_ByProjet.Show();

						#endregion
					}
					else if (this.listBox12.SelectedItem.ToString() == "船次绩效考核成本指标(按部门)查询")
					{
						#region 船次绩效考核成本指标(按部门)查询
						foreach (Form f in Application.OpenForms)
						{
							if (f.Name == "YZ_FBoatJXKH_ByDepart")
							{
								f.Activate();
								return;
							}
						}
						YXK3FZ.YZGL.YZ_FBoatJXKH_ByDepart YZ_FBoatJXKH_ByDepart = new YXK3FZ.YZGL.YZ_FBoatJXKH_ByDepart();
						YZ_FBoatJXKH_ByDepart.Show();

						#endregion
					}

				}

				private void tabControl6_DrawItem(object sender, DrawItemEventArgs e)
				{
					//实现tabControl的文字从左到右

					Rectangle tabTextArea = tabControl6.GetTabRect(e.Index);

					Graphics g = e.Graphics;
					StringFormat sf = new StringFormat();
					sf.LineAlignment = StringAlignment.Center;
					sf.Alignment = StringAlignment.Center;
					Font font = this.tabControl6.Font;
					SolidBrush brush = new SolidBrush(Color.Black);
					g.DrawString(((TabControl)(sender)).TabPages[e.Index].Text, font, brush, tabTextArea, sf);
				}

				private void listBox14_DoubleClick(object sender, EventArgs e)
				{
					//CWGL-YZ-06-油脂开具增值税专用(普通)发票申请
					if (this.listBox14.SelectedItem.ToString() == "CWGL-YZ-06-油脂开具增值税专用(普通)发票申请")
					{
						#region CWGL-YZ-06-油脂开具增值税专用(普通)发票申请
						foreach (Form f in Application.OpenForms)
						{
							if (f.Name == "frmOA_YZ01")
							{
								f.Activate();
								return;
							}
						}
						YXK3FZ.OA.frmOA_YZ01 frmOA_YZ01 = new YXK3FZ.OA.frmOA_YZ01 ();
						frmOA_YZ01.Show();

						#endregion
					}
					else if (this.listBox14.SelectedItem.ToString() == "副合同编号相关数据录入")
					{
						#region 副合同编号相关数据录入
						foreach (Form f in Application.OpenForms)
						{
							if (f.Name == "frmOA_YZ02")
							{
								f.Activate();
								return;
							}
						}
						YXK3FZ.OA.frmOA_YZ02 frmOA_YZ02 = new YXK3FZ.OA.frmOA_YZ02();
						frmOA_YZ02.Show();

						#endregion
					}
					else if (this.listBox14.SelectedItem.ToString() == "销售合同执行明细报表查询")
					{
						#region 副合同编号相关数据录入
						foreach (Form f in Application.OpenForms)
						{
							if (f.Name == "frmOA_YZ03")
							{
								f.Activate();
								return;
							}
						}
						YXK3FZ.OA.frmOA_YZ03 frmOA_YZ03 = new YXK3FZ.OA.frmOA_YZ03();
						frmOA_YZ03.Show();

						#endregion
					}

				}

				private void button23_Click(object sender, EventArgs e) //青花瓷
				{

					#region 青花瓷
					foreach (Form f in Application.OpenForms)
					{
						if (f.Name == "frm_qhc")
						{
							f.Activate();
							return;
						}
					}
					YXK3FZ.RYGYL.frm_qhc frm_qhc = new frm_qhc();
					frm_qhc.Show();

					#endregion
				}

				private void button27_Click(object sender, EventArgs e) //云睿系统-修改客户代码 frm_yunrui_customer
				{
                    
					#region 青花瓷
					foreach (Form f in Application.OpenForms)
					{
						if (f.Name == "frm_yunrui_customer")
						{
							f.Activate();
							return;
						}
					}
					YXK3FZ.RYGYL.frm_yunrui_customer frm_yunrui_customer = new frm_yunrui_customer();
					frm_yunrui_customer.Show();

					#endregion
				}

                private void button28_Click(object sender, EventArgs e)
                {
                    frm_rzp_icstock_wg f = new frm_rzp_icstock_wg();
                    f.Show();
                }

                private void button29_Click(object sender, EventArgs e)
                {
                    frmDzpYsTJ_test frmDzpYsTJ = new frmDzpYsTJ_test();
                    frmDzpYsTJ.DB_ID = 4;  //传递数据库表所在连接字符串
                    frmDzpYsTJ.Show();
                }

                private void button11_Click(object sender, EventArgs e)
                {

                }

                private void button30_Click(object sender, EventArgs e)
                {
                    frm_dzp_icstock_csck f = new frm_dzp_icstock_csck();
                    f.Show();
                }

                private void button31_Click(object sender, EventArgs e)
                {
                    frm_dzp_receipt f = new frm_dzp_receipt();
                    f.Show();
                }

                private void button32_Click(object sender, EventArgs e)
                {
                    frm_dzp_receipt_other f = new frm_dzp_receipt_other();
                    f.Show();
                }

                private void btn_ItemNumberChange_Click(object sender, EventArgs e)
                {
                    #region 青花瓷
                    foreach (Form f in Application.OpenForms)
                    {
                        if (f.Name == "frm_yunrui_Item")
                        {
                            f.Activate();
                            return;
                        }
                    }
                    YXK3FZ.RYGYL.frm_yunrui_Item frm_yunrui_item = new frm_yunrui_Item();
                    frm_yunrui_item.Show();

                    #endregion
                }

                private void button33_Click(object sender, EventArgs e)
                {
                    foreach (Form f in Application.OpenForms)
                    {
                        if (f.Name == "frm_yunrui_Organization_Insert")
                        {
                            f.Activate();
                            return;
                        }
                    }
                    YXK3FZ.RYGYL.frm_yunrui_Organization_Insert frm_yunrui_item = new frm_yunrui_Organization_Insert();
                    frm_yunrui_item.Show();
                }

                private void button34_Click(object sender, EventArgs e)
                {
                    foreach (Form f in Application.OpenForms)
                    {
                        if (f.Name == "frm_yunrui_Item_Insert")
                        {
                            f.Activate();
                            return;
                        }
                    }
                    YXK3FZ.RYGYL.frm_yunrui_Item_Insert frm_yunrui_item = new frm_yunrui_Item_Insert();
                    frm_yunrui_item.Show();
                }

								private void button35_Click(object sender, EventArgs e)
								{
									frmSaleConvert frmWordNote = new frmSaleConvert();
									frmWordNote.Show();
								}

                                private void button19_Click_1(object sender, EventArgs e)
                                {
                                    frmSpZyd frmSpZyd = new frmSpZyd();

                                    frmSpZyd.Show();
                                }

                                private void button41_Click(object sender, EventArgs e)
                                {

                                }

                                private void button37_Click(object sender, EventArgs e)
                                {

                                }

                                private void listBox15_DoubleClick(object sender, EventArgs e)
                                {
                                    if (this.listBox15.SelectedItem.ToString() == "CWGL-DFYZ-06-东方油脂开具增值税专用(普通)发票申请")
                                    {
                                        #region CWGL-DFYZ-06-东方油脂开具增值税专用(普通)发票申请
                                        foreach (Form f in Application.OpenForms)
                                        {
                                            if (f.Name == "frmOA_YZ04")
                                            {
                                                f.Activate();
                                                return;
                                            }
                                        }
                                        YXK3FZ.OA.frmOA_YZ04 frmOA_YZ04 = new YXK3FZ.OA.frmOA_YZ04();
                                        frmOA_YZ04.Show();

                                        #endregion
                                    }
                                }

                                private void button43_Click(object sender, EventArgs e)
                                {
                                    frm_dzp_app_order f = new frm_dzp_app_order();
                                    f.Show();
                                }




       
			
			

			

			
			
			




    }
}
