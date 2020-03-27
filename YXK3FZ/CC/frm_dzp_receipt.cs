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
using System.Web;
using System.Diagnostics;
using System.Net;
using System.IO;
using System.IO.Compression;
using System.Text.RegularExpressions;   

namespace YXK3FZ.CC
{
    public partial class frm_dzp_receipt : Form
    {
        public frm_dzp_receipt()
        {
            InitializeComponent();
            ds = db.GetDataSet("SELECT Fdbstr  FROM YXERP.dbo.YXZTLIST WHERE ID=20", "con");
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
                {
                    return;
                }
               // DataBase db2 = new DataBase(ZtRyconstring);

                db.ExecDataBySql("sp_K3_insertreceipt");
                //SetFormCaption;
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
            if (this.dataGridView1.RowCount == 0)
            {
                MessageBox.Show("没有数据");
                b = false;
                return b;
            }
            strSqls.Add("IF OBJECT_ID('t_dzpreceipt') IS NULL CREATE TABLE t_dzpreceipt(FNumber VARCHAR(255),FDate DATETIME,FFincDate DATETIME,FClassTypeID VARCHAR(50),FExplanation varchar(255),FAmount DECIMAL(20,8),FPreparer VARCHAR(50),FDepartment VARCHAR(50),FRNumber VARCHAR(255))");
            DataRow dr = null;
            for (int i = 0; i < dttResult.Rows.Count; i++)
            {
                dr = dttResult.Rows[i];
                strSqls.Add("INSERT INTO dbo.t_dzpreceipt( FNumber ,FDate ,FFincDate ,FClassTypeID ,FExplanation ,FAmount ,FPreparer ,FDepartment)VALUES  ( '" + dr["单号"].ToString().Trim() + "' , '" + dr["单据日期"].ToString().Trim() + "' , '" + dr["财务日期"].ToString().Trim() + "' ,'" + dr["核算项目编号"].ToString().Trim() + "' ,'" + dr["摘要"].ToString().Trim() + "' ,'" + dr["结算实收金额"].ToString().Trim() + "' , '" + dr["制单人"].ToString().Trim() + "' ,'" + dr["部门"].ToString().Trim() + "'  )");
            }
            //strSqls.Add("exec validationdate");
            string msg = db.ExecDataBySqls1(strSqls);
            if (msg != "成功")
            {
                MessageBox.Show(msg);
                b = false;
            }
            return b;
        }



        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            bool status = false;

            //连接共享文件夹
            status = connectState(@"\\188.188.1.190\k3辅助系统", "", "");
            if (status)
            {
                //共享文件夹的目录
                DirectoryInfo theFolder = new DirectoryInfo(@"\\188.188.1.190\k3辅助系统");
                //相对共享文件夹的路径
                string fielpath = @"\导入格式\收款单.xlsx";
                //获取保存文件的路径
                string filename = theFolder.ToString() + fielpath;
                //执行方法
                Transport(filename, @"D:\", "收款单.xlsx");

            }
            else
            {
                //ListBox1.Items.Add("未能连接！");
            }
            Console.ReadKey();
        }


        public static bool connectState(string path)
        {
            return connectState(path, "", "");
        }
        /// <summary>
        /// 连接远程共享文件夹
        /// </summary>
        /// <param name="path">远程共享文件夹的路径</param>
        /// <param name="userName">用户名</param>
        /// <param name="passWord">密码</param>
        /// <returns></returns>
        public static bool connectState(string path, string userName, string passWord)
        {
            bool Flag = false;
            Process proc = new Process();
            try
            {
                proc.StartInfo.FileName = "cmd.exe";
                proc.StartInfo.UseShellExecute = false;
                proc.StartInfo.RedirectStandardInput = true;
                proc.StartInfo.RedirectStandardOutput = true;
                proc.StartInfo.RedirectStandardError = true;
                proc.StartInfo.CreateNoWindow = true;
                proc.Start();
                string dosLine = "net use " + path + " " + passWord + " /user:" + userName;
                proc.StandardInput.WriteLine(dosLine);
                proc.StandardInput.WriteLine("exit");
                while (!proc.HasExited)
                {
                    proc.WaitForExit(1000);
                }
                string errormsg = proc.StandardError.ReadToEnd();
                proc.StandardError.Close();
                if (string.IsNullOrEmpty(errormsg))
                {
                    Flag = true;
                }
                else
                {
                    throw new Exception(errormsg);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                proc.Close();
                proc.Dispose();
            }
            return Flag;
        }

        /// <summary>
        /// 向远程文件夹保存本地内容，或者从远程文件夹下载文件到本地
        /// </summary>
        /// <param name="src">要保存的文件的路径，如果保存文件到共享文件夹，这个路径就是本地文件路径如：@"D:\1.avi"</param>
        /// <param name="dst">保存文件的路径，不含名称及扩展名</param>
        /// <param name="fileName">保存文件的名称以及扩展名</param>
        public static void Transport(string src, string dst, string fileName)
        {

            FileStream inFileStream = new FileStream(src, FileMode.Open);
            if (!Directory.Exists(dst))
            {
                Directory.CreateDirectory(dst);
            }
            dst = dst + fileName;
            FileStream outFileStream = new FileStream(dst, FileMode.OpenOrCreate);

            byte[] buf = new byte[inFileStream.Length];

            int byteCount;

            while ((byteCount = inFileStream.Read(buf, 0, buf.Length)) > 0)
            {

                outFileStream.Write(buf, 0, byteCount);

            }

            inFileStream.Flush();

            inFileStream.Close();

            outFileStream.Flush();

            outFileStream.Close();

        }

        private void frm_dzp_receipt_Load(object sender, EventArgs e)
        {

        }


    }
}
