using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using YXK3FZ.DataClass;
using YXK3FZ.ComClass;

namespace YXK3FZ.SP
{
	public partial class FrmPriceDiff : Form
	{

		DataBase db = new DataBase();
		DataSet ds = null;
		DataBase k3db = null;
		CommonUse commUse = new CommonUse();
		string ZtRyconstring = string.Empty; //获取K3账套连接字符串

		public FrmPriceDiff()
		{
			InitializeComponent();
			ds = db.GetDataSet("SELECT Fdbstr  FROM dbo.YXZTLIST WHERE ID=1", "con");
			DataRow dr = ds.Tables[0].Rows[0];
			ZtRyconstring = dr["Fdbstr"].ToString(); //获取K3账套连接字符串
			k3db = new DataBase(ZtRyconstring);  
  
		}

		private void FrmPriceDiff_Load(object sender, EventArgs e)
		{
			dtToday.Text = DateTime.Now.AddDays(0).ToString("yyyy-MM-dd");
			dtYesterday.Text = DateTime.Now.AddDays(-1).ToString("yyyy-MM-dd");

		}

		private void btnFind_Click(object sender, EventArgs e)
		{
			string sSQL = string.Empty;

			sSQL += " SELECT T1.客户代码, t1.客户名称,t1.物料代码,t1.物料名称,t1.昨天日期,t1.物料价格 昨天价格,t2.今天日期,t2.物料价格 今天价格 FROM ( ";
			sSQL += " SELECT g.FItemID '客户代码',g.FName '客户名称', t.FNumber '物料代码',t.FName '物料名称',b.Fprice '物料价格', CONVERT(VARCHAR(20),A.FBillerdate,23) '昨天日期' FROM yx_order A  ";
			sSQL += " INNER JOIN yx_orderEntry B ON B.Finterid = A.Finterid  ";
			sSQL += " INNER JOIN dbo.t_ICItem t ON b.Fitemid=t.FItemID  ";
			sSQL += " INNER JOIN dbo.t_Organization g ON a.FcurID=g.FItemID  ";
			sSQL += " WHERE  A.FBillerdate='" + dtYesterday.Text + "'   ";
			sSQL += " )T1  ";
			sSQL += " INNER JOIN  ";
			sSQL += " (  ";
			sSQL += " SELECT g.FItemID '客户代码',g.FName '客户名称', t.FNumber '物料代码',t.FName '物料名称',b.Fprice '物料价格',  CONVERT(VARCHAR(20),A.FBillerdate,23)  '今天日期' FROM yx_order A  ";
			sSQL += " INNER JOIN yx_orderEntry B ON B.Finterid = A.Finterid  ";
			sSQL += " INNER JOIN dbo.t_ICItem t ON b.Fitemid=t.FItemID  ";
			sSQL += " INNER JOIN dbo.t_Organization g ON a.FcurID=g.FItemID  ";
			sSQL += " WHERE  A.FBillerdate='" + dtToday.Text + "'  ";
			sSQL += " )T2 ON T2.物料代码 = T1.物料代码 AND  T2.客户代码 = T1.客户代码  AND T2.物料价格 <> T1.物料价格  ";

			DataTable dtt = k3db.GetDataTable(sSQL, "A");
			bdsMaster.DataSource = dtt;
			if (dtt.Rows.Count == 0)
			{
				MessageBox.Show("查无数据");
			}


		}
	}
}
