namespace YXK3FZ.SY
{
	partial class frmSaleConvert
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
					this.panel1 = new System.Windows.Forms.Panel();
					this.label1 = new System.Windows.Forms.Label();
					this.panel2 = new System.Windows.Forms.Panel();
					this.panel3 = new System.Windows.Forms.Panel();
					this.groupBox1 = new System.Windows.Forms.GroupBox();
					this.comboBox1 = new System.Windows.Forms.ComboBox();
					this.panel4 = new System.Windows.Forms.Panel();
					this.button1 = new System.Windows.Forms.Button();
					this.listBox1 = new System.Windows.Forms.TextBox();
					this.panel1.SuspendLayout();
					this.panel2.SuspendLayout();
					this.panel3.SuspendLayout();
					this.groupBox1.SuspendLayout();
					this.panel4.SuspendLayout();
					this.SuspendLayout();
					// 
					// panel1
					// 
					this.panel1.Controls.Add(this.label1);
					this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
					this.panel1.Location = new System.Drawing.Point(0, 0);
					this.panel1.Name = "panel1";
					this.panel1.Size = new System.Drawing.Size(958, 42);
					this.panel1.TabIndex = 0;
					// 
					// label1
					// 
					this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
					this.label1.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
					this.label1.ForeColor = System.Drawing.Color.Red;
					this.label1.Location = new System.Drawing.Point(0, 0);
					this.label1.Name = "label1";
					this.label1.Size = new System.Drawing.Size(958, 42);
					this.label1.TabIndex = 0;
					this.label1.Text = "批量反钩稽发票功能";
					this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
					// 
					// panel2
					// 
					this.panel2.Controls.Add(this.panel3);
					this.panel2.Controls.Add(this.groupBox1);
					this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
					this.panel2.Location = new System.Drawing.Point(0, 42);
					this.panel2.Name = "panel2";
					this.panel2.Size = new System.Drawing.Size(234, 500);
					this.panel2.TabIndex = 3;
					// 
					// panel3
					// 
					this.panel3.Controls.Add(this.button1);
					this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
					this.panel3.Location = new System.Drawing.Point(0, 56);
					this.panel3.Name = "panel3";
					this.panel3.Size = new System.Drawing.Size(234, 444);
					this.panel3.TabIndex = 1;
					// 
					// groupBox1
					// 
					this.groupBox1.Controls.Add(this.comboBox1);
					this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
					this.groupBox1.Location = new System.Drawing.Point(0, 0);
					this.groupBox1.Name = "groupBox1";
					this.groupBox1.Size = new System.Drawing.Size(234, 56);
					this.groupBox1.TabIndex = 0;
					this.groupBox1.TabStop = false;
					this.groupBox1.Text = "选择账套";
					// 
					// comboBox1
					// 
					this.comboBox1.FormattingEnabled = true;
					this.comboBox1.Location = new System.Drawing.Point(4, 20);
					this.comboBox1.Name = "comboBox1";
					this.comboBox1.Size = new System.Drawing.Size(224, 20);
					this.comboBox1.TabIndex = 0;
					this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
					// 
					// panel4
					// 
					this.panel4.Controls.Add(this.listBox1);
					this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
					this.panel4.Location = new System.Drawing.Point(234, 42);
					this.panel4.Name = "panel4";
					this.panel4.Size = new System.Drawing.Size(724, 500);
					this.panel4.TabIndex = 4;
					// 
					// button1
					// 
					this.button1.Location = new System.Drawing.Point(45, 52);
					this.button1.Name = "button1";
					this.button1.Size = new System.Drawing.Size(149, 62);
					this.button1.TabIndex = 0;
					this.button1.Text = "开　　　始";
					this.button1.UseVisualStyleBackColor = true;
					this.button1.Click += new System.EventHandler(this.button1_Click_1);
					// 
					// listBox1
					// 
					this.listBox1.Dock = System.Windows.Forms.DockStyle.Fill;
					this.listBox1.Location = new System.Drawing.Point(0, 0);
					this.listBox1.Multiline = true;
					this.listBox1.Name = "listBox1";
					this.listBox1.Size = new System.Drawing.Size(724, 500);
					this.listBox1.TabIndex = 0;
					// 
					// frmSaleConvert
					// 
					this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
					this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
					this.ClientSize = new System.Drawing.Size(958, 542);
					this.Controls.Add(this.panel4);
					this.Controls.Add(this.panel2);
					this.Controls.Add(this.panel1);
					this.Name = "frmSaleConvert";
					this.Tag = "89";
					this.Text = "发票管理";
					this.Load += new System.EventHandler(this.frmSaleConvert_Load);
					this.panel1.ResumeLayout(false);
					this.panel2.ResumeLayout(false);
					this.panel3.ResumeLayout(false);
					this.groupBox1.ResumeLayout(false);
					this.panel4.ResumeLayout(false);
					this.panel4.PerformLayout();
					this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
				private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.GroupBox groupBox1;
				private System.Windows.Forms.ComboBox comboBox1;
				private System.Windows.Forms.Panel panel4;
				private System.Windows.Forms.Button button1;
				private System.Windows.Forms.TextBox listBox1;



    }
}