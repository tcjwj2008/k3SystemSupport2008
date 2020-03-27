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
	public partial class frm_yunrui_customer : Form
	{

		DataBase db = new DataBase();
		DataSet ds = null;
		CommonUse commUse = new CommonUse();
		DataBase k3db = null;

		string ZtRyconstring = string.Empty; //获取K3账套连接字符串

		public frm_yunrui_customer()
		{
			InitializeComponent();
			ds = db.GetDataSet("SELECT Fdbstr  FROM dbo.YXZTLIST WHERE ID=18", "con");
			DataRow dr = ds.Tables[0].Rows[0];
			ZtRyconstring = dr["Fdbstr"].ToString(); //获取K3账套连接字符串
			k3db = new DataBase(ZtRyconstring);
		}

		private void button1_Click(object sender, EventArgs e)
		{
			if (txtOldValue.Text == string.Empty)
			{
				MessageBox.Show("旧客户代码不能为空");
				txtOldValue.Focus();
				return;
			}

			if (txtNewValue.Text == string.Empty)
			{
				MessageBox.Show("新客户代码不能为空");
				txtNewValue.Focus();
				return;
			}

			//传递参数
			SqlParameter param1 = new SqlParameter("@FOldNumber", SqlDbType.VarChar);
			param1.Value = this.txtOldValue.Text.Trim();
			SqlParameter param2 = new SqlParameter("@FNewNumber", SqlDbType.VarChar);
			param2.Value = this.txtNewValue.Text.Trim();
			SqlParameter param3 = new SqlParameter("@FCheck", SqlDbType.VarChar);
			param3.Value = "0";
			if (cbHistroy.Checked) 
			{
				param3.Value = "1";
			}

			//创建泛型
			List<SqlParameter> parameters = new List<SqlParameter>();
			parameters.Add(param1);
			parameters.Add(param2);
			parameters.Add(param3);

			//把泛型中的元素复制到数组中
			SqlParameter[] inputParameters = parameters.ToArray();

			try
			{
				ds = k3db.GetProcDataSet("sp_check_cusotmer_czq", inputParameters);
				if (ds.Tables[0].Rows.Count == 0)
				{
					MessageBox.Show("当前旧客户代码不存在，无法保存修改");
					return;
				}

				////判断新代码在K3是否存在 
				//ds = k3db.GetProcDataSet("sp_checkK3_cusotmer_czq", inputParameters);
				//if (ds.Tables[0].Rows.Count == 0)
				//{
				//  MessageBox.Show("当前新客户代码不存在K3，无法保存修改");
				//  return;
				//}


				//执行修改代码

				ds = k3db.GetProcDataSet("sp_Save_cusotmer_czq", inputParameters);
				if (ds.Tables[0].Rows.Count == 0)
				{
					MessageBox.Show("当前操作失败：请联系信息部");
					return;
				}
				MessageBox.Show("修改成功！");



			}
			catch (Exception err)
			{
				MessageBox.Show("操作失败！" + err.Message);
			}







		}

		private void button2_Click(object sender, EventArgs e)
		{
			this.Close();
		}
	}
}
