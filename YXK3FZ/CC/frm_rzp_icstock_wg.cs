using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Threading;
using Microsoft.Office.Interop.Excel;
using YXK3FZ.ComClass;
using YXK3FZ.DataClass;

namespace YXK3FZ.CC
{
    public partial class frm_rzp_icstock_wg : Form
    {
        public frm_rzp_icstock_wg()
        {
            InitializeComponent();
            ds = db.GetDataSet("SELECT Fdbstr  FROM YXERP.dbo.YXZTLIST WHERE ID=19", "con");
            DataRow dr = ds.Tables[0].Rows[0];
            ZtRyconstring = dr["Fdbstr"].ToString(); //获取K3账套连接字符串
            db = new DataBase(ZtRyconstring);
        }

        string ZtRyconstring = null;
        private delegate void MyHandler();
        private frmWaiting frmwaiting = null;

        System.Data.DataTable dttResult = new System.Data.DataTable();

        DataSet ds = new DataSet();//excel
        DataBase db = new DataBase(PropertyClass.con_rzp_test);
        CommonUse commUse = new CommonUse();


        private void btnRead_Click(object sender, EventArgs e)
        {
            string excelFileName = "";
            openFileDialog1.FileName = "";
            openFileDialog1.Filter = "EXCEL|*.xls;*.xlst;*.xlsx|所有文件|*.*";
            //openFileDialog1.Filter = "EXCEL文件(*.xls,*.xlsx)|*.xls,*.xlsx";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {


                excelFileName = openFileDialog1.FileName;

                //bind(excelFileName); 
                // ProgressbarEx.Progress.StartProgessBar(new ProgressbarEx.ShowProgess(bind(excelFileName)));

                //
                System.Data.DataTable dt = YXK3FZ.ComClass.NewNPOIExcelHelper.GetDataTable(excelFileName);


                this.dataGridView1.DataSource = dt;
                dttResult = dt;



            }
        }

        private void btnInput_Click(object sender, EventArgs e)
        {
            WaitFormService.CreateWaitForm();
            WaitFormService.SetWaitFormCaption("数据正在处理......");
            try
            {
                if (!validationData())
                    return;
                //DataBase db2 = new DataBase(PropertyClass.con_rzp_test);
    
                db.ExecDataBySql("sp_K3_insertoutsourceWarehousing");
                // SetFormCaption
                WaitFormService.SetWaitFormCaption("正在导入数据！");

            }
            catch (Exception ex)
            {
                this.toolStripStatusLabel1.Text = " 表格数据导入失败!";
                MessageBox.Show("导入K3失败!" + ex.ToString(), "软件提示");
                return;

            }
            finally
            {
                WaitFormService.CloseWaitForm();
            }
            MessageBox.Show("导入成功");

        }

        private bool validationData()
        {
            bool b = true;
            List<string> strSqls = new List<string>();
            string sql = "";
            if (this.dataGridView1.RowCount == 0)
            {
                MessageBox.Show("没有数据");
                b = false;
                return b ;
            }
            strSqls.Add("TRUNCATE TABLE  tempWGLK");
            DataRow dr = null;
            for (int i = 0; i < dttResult.Rows.Count; i++)
            {
                dr = dttResult.Rows[i];
                strSqls.Add("INSERT INTO tempWGLK(FDate,FBillno,FExplanation,FSupplyNumber,FAccountNumber,FItemNumber,FBatchNo,FQty,FPrice,FStockNumber,FNote,FDeptName,FEmpName,FBillerName,FFManagerName,FSManager,productdate,FSecCoefficient,FSecQty,FEntrySelfA0158,FEntrySelfA0160)VALUES('" + dr["日期"].ToString().Trim() + "','" + dr["单号"].ToString().Trim() + "','" + dr["摘要"].ToString().Trim() + "','" + dr["供应商代码"].ToString().Trim() + "','" + dr["往来科目"].ToString().Trim() + "','" + dr["物料代码"].ToString().Trim() + "','" + dr["批号"].ToString().Trim() + "','" + dr["数量"].ToString().Trim() + "','" + dr["金额"].ToString().Trim() + "','" + dr["仓库代码"].ToString().Trim() + "','" + dr["备注"].ToString().Trim() + "','" + dr["部门"].ToString().Trim() + "','" + dr["业务员"].ToString().Trim() + "','" + dr["制单"].ToString().Trim() + "','" + dr["验收"].ToString().Trim() + "','" + dr["保管"].ToString().Trim() + "','" + dr["生产日期"].ToString().Trim() + "','" + dr["换算率"].ToString().Trim() + "','" + dr["辅助数量"].ToString().Trim() + "','" + dr["含税单价"].ToString().Trim() + "','" + dr["含税金额"].ToString().Trim() + "')    UPDATE tempWGLK SET productdate  =NULL WHERE  ISNULL(productdate,'')=''");
            }
            strSqls.Add("exec validationdate");
            for (int i = 0; i < strSqls.Count; i++)
            {
                sql += strSqls[i] +"\n";
            }
                MessageBox.Show(sql);
            string msg = db.ExecDataBySqls1(strSqls);
            if(msg !="成功")
            {
                MessageBox.Show(msg);
                b = false;
            }
            return b;
        }

        private void frm_rzp_icstock_wg_Load(object sender, EventArgs e)
        {
            //commUse.CortrolButtonEnabled(btnRead, this);
            //commUse.CortrolButtonEnabled(btnInput, this);
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
