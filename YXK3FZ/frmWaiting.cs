using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
//using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace YXK3FZ
{
    public partial class frmWaiting : Form
    {
        public frmWaiting()
        {
            InitializeComponent();
            //SetText("");

        }
        private delegate void SetTextHandler(string text);
        public void SetText(string text)
        {
            if (label1.InvokeRequired)
            {
                 this.Invoke(new SetTextHandler(SetText), text);
             }
            else
            {
                this.label1.Text = text;
            }


        }


        private void frmWaiting_Load(object sender, EventArgs e)
        {

        }
    }
}
