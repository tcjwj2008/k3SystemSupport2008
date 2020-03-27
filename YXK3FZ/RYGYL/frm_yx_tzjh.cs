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
    public partial class frm_yx_tzjh : Form
    {
        DataBase db =new DataBase();
       DataBase k3db = null;
        DataSet ds = null;
        DataSet dsDgv = null;
        CommonUse commUse = new CommonUse();
        string Ftye;// SEL ADD EDIT
        string Fdate;
        string conRY = "";

        public frm_yx_tzjh()
        {
            InitializeComponent();
            ds = db.GetDataSet("SELECT Fdbstr    FROM dbo.YXZTLIST WHERE ID=2", "con");
            DataRow dr = ds.Tables[0].Rows[0];
            conRY = dr["Fdbstr"].ToString();
        }

        private void frm_yx_tzjh_Load(object sender, EventArgs e)
        {
            commUse.CortrolButtonEnabled(btnSave, this);
            commUse.CortrolButtonEnabled(btnSel, this);
           
            commUse.CortrolButtonEnabled(btnEdit, this);

         
            this.txtA3.Enabled = false;
            this.txtB3.Enabled = false;
            this.txtC3.Enabled = false;
            this.txtD3.Enabled = false;
            this.txtE3.Enabled = false;
            this.txtF3.Enabled = false;
            this.txtG3.Enabled = false;
            this.txtH3.Enabled = false;
            this.txtA6.Enabled = false;
            this.txtB6.Enabled = false;
            this.dgvMb.ReadOnly = true;
            k3db = new DataBase(conRY);
            if (this.btnSel.Enabled==true)
            {
            btnSel_Click_1(null,null);
            }


        }


        public void Status_load(string type)
        {
            if (type == "SEL")
            {
                ds = k3db.GetDataSet(" SELECT * FROM yx_icitem_plane WHERE fdate='" + Fdate + "'  ", "tab");
                if (ds.Tables[0].Rows.Count==0)
                {
                    ds = k3db.GetDataSet("SELECT '' A3 ,'' B3,'' C3 ,'' D3,'' E3 ,'' F3,'' G3 ,'' H3,'' A6 ,'' B6", "tab");
                
                }
                this.txtA3.Text = ds.Tables[0].Rows[0]["A3"].ToString();
                this.txtB3.Text = ds.Tables[0].Rows[0]["B3"].ToString();
                this.txtC3.Text = ds.Tables[0].Rows[0]["C3"].ToString();
                this.txtD3.Text = ds.Tables[0].Rows[0]["D3"].ToString();
                this.txtE3.Text = ds.Tables[0].Rows[0]["E3"].ToString();
                this.txtF3.Text = ds.Tables[0].Rows[0]["F3"].ToString();
                this.txtG3.Text = ds.Tables[0].Rows[0]["G3"].ToString();
                this.txtH3.Text = ds.Tables[0].Rows[0]["H3"].ToString();
                this.txtA6.Text = ds.Tables[0].Rows[0]["A6"].ToString();
                this.txtB6.Text = ds.Tables[0].Rows[0]["B6"].ToString();
                
                this.txtA3.Enabled = false;
                this.txtB3.Enabled = false;
                this.txtC3.Enabled = false;
                this.txtD3.Enabled = false;
                this.txtE3.Enabled = false;
                this.txtF3.Enabled = false;
                this.txtG3.Enabled = false;
                this.txtH3.Enabled = false;
                this.txtA6.Enabled = false;
                this.txtB6.Enabled = false;

                SqlParameter param = new SqlParameter("@fdate", SqlDbType.VarChar);
                param.Value = Fdate;
                //创建泛型
                List<SqlParameter> parameters = new List<SqlParameter>();
                parameters.Add(param);
                //把泛型中的元素复制到数组中
                SqlParameter[] inputParameters = parameters.ToArray();

             
               dsDgv = k3db.GetProcDataSet("sp_yx_Selqrzc", inputParameters);
                this.dgvMb.DataSource=dsDgv.Tables[0];

                this.dgvMb.ReadOnly = true;






            
            }
            if (type == "EDIT")
            {
                this.txtA3.Enabled = true;
                this.txtB3.Enabled = true;
                this.txtC3.Enabled = true;
                this.txtD3.Enabled = true;
                this.txtE3.Enabled = true;
                //this.txtF3.Enabled = true;
                //this.txtG3.Enabled = true;
                this.txtH3.Enabled = true;
                this.txtA6.Enabled = true;
                this.txtB6.Enabled = true;
                this.dgvMb.ReadOnly = true;
                //this.txtA3.Text = "";
                //this.txtB3.Text = "";
                //this.txtC3.Text = "";
                //this.txtD3.Text = "";
                //this.txtE3.Text = "";
                //this.txtF3.Text = "";
                //this.txtG3.Text = "";
                //this.txtH3.Text = "";
                //this.txtA6.Text = "";
                //this.txtB6.Text = "";
                this.dgvMb.ReadOnly =false;
              
                this.dgvMb.Columns["日期"].ReadOnly = true;
                this.dgvMb.Columns["类别"].ReadOnly = true;
                this.dgvMb.Columns["产品代码"].ReadOnly = true;
                this.dgvMb.Columns["产品名称"].ReadOnly = true;
                this.dgvMb.Columns["均重"].ReadOnly = true;
             




            }  
            



        
        }

        private void btnSel_Click_1(object sender, EventArgs e)
        {
            Fdate = this.dateTimePicker1.Value.ToString("yyyy-MM-dd");
            this.Ftye = "SEL";
            this.Status_load(this.Ftye);
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {

            if (this.Ftye != "SEL")
            {
          
                return;
            }
            this.Ftye = "EDIT";
            this.Status_load(this.Ftye);

        }

        private void btnSave_Click(object sender, EventArgs e)
        {

            if(this.Ftye!="EDIT")
            {
                return;
            }

            if (this.txtA3.Text == "" ||
             this.txtB3.Text == "" ||
             this.txtC3.Text == "" ||
             this.txtD3.Text == "" ||
             this.txtE3.Text == "" ||
             this.txtH3.Text == "" ||
             this.txtA6.Text == "" ||
             this.txtB6.Text == "")
            {
                MessageBox.Show("输入不完整！");
                return;
            }
            try {
                Convert.ToSingle(this.txtA3.Text.Trim());
                Convert.ToSingle(this.txtB3.Text.Trim());
                Convert.ToSingle(this.txtC3.Text.Trim());
                Convert.ToSingle(this.txtD3.Text.Trim());
                Convert.ToSingle(this.txtE3.Text.Trim());
                Convert.ToSingle(this.txtH3.Text.Trim());
                Convert.ToSingle(this.txtA6.Text.Trim());
                Convert.ToSingle(this.txtB6.Text.Trim());

            
            }
            catch
                {
                    MessageBox.Show("输入非数字！");
                    return;
            }


            Fdate = this.dateTimePicker1.Value.ToString("yyyy-MM-dd");
            List<string> Insertsql = new List<string>();
            

            Insertsql.Add(" DELETE yx_icitem_qrzc  WHERE fdate='"+Fdate+"'");
            Insertsql.Add(" DELETE dbo.yx_icitem_plane   WHERE fdate='" + Fdate + "'");
           
            //INSERT INTO  yx_icitem_qrzc (fdate , fnumber,fzc ) VALUES('2015-04-01','7.1.01.01.000120',2.5)
            this.dgvMb.EndEdit();
            for (int i = 0; i < this.dgvMb.Rows.Count; i++)
            {
                string fzc = "0";
                if (this.dgvMb["前日暂存", i].Value.ToString().Trim() != "") { fzc = this.dgvMb["前日暂存", i].Value.ToString().Trim(); }
                Insertsql.Add(" INSERT INTO  yx_icitem_qrzc (fdate , fnumber,fzc ) VALUES('" + Fdate + "','" + this.dgvMb["产品代码", i].Value.ToString() + "'," + fzc + ")  ");

            
            }


            Insertsql.Add(" INSERT INTO dbo.yx_icitem_plane( fdate ,A3 ,B3 ,C3 ,D3 ,E3 ,H3 , A6 ,B6 ,FuserName)VALUES  ('" +
               Fdate + "'," + this.txtA3.Text.Trim() + "," +
               this.txtB3.Text.Trim() + "," +
               this.txtC3.Text.Trim() + "," +
              this.txtD3.Text.Trim() + "," +
              this.txtE3.Text.Trim() + "," +
              this.txtH3.Text.Trim() + "," +
              this.txtA6.Text.Trim() + "," +
              this.txtB6.Text.Trim() + ",'" + PropertyClass.OperatorName + "')");
            try
            {
                bool ok = k3db.ExecDataBySqls(Insertsql);
                if (ok==false)
                {
                    MessageBox.Show("保存失败！");
                    return;
                }
                MessageBox.Show("保存成功！");
                this.Ftye = "SEL";
                this.Status_load(this.Ftye);


            }
            catch
            {
                MessageBox.Show("保存失败！");
                return;
            }




        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            if (this.btnSel.Enabled==true)
            {
            this.Ftye = "SEL";
            btnSel_Click_1(null, null);
            }

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

       

      
    }
}
