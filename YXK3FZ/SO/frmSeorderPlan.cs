using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
//using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace YXK3FZ.SO
{
    public partial class frmSeorderPlan : Form
    {
        public frmSeorderPlan()
        {
            InitializeComponent();
        }

        private void frmSeorderPlan_Load(object sender, EventArgs e)
        {

        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            frmSeorderPlanEdit frmSeorderPlanEdit = new frmSeorderPlanEdit("ADD");
            frmSeorderPlanEdit.Show();
        }

        private void toolStripButton9_Click(object sender, EventArgs e)
        {
            frmIcitemSet frmIcitemSet = new frmIcitemSet();
            frmIcitemSet.Show();

        }
    }
}
