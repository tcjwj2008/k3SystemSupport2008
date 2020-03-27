namespace YXK3FZ.RYGYL
{
    partial class frm_yx_WhiteList
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
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dgvWhite = new System.Windows.Forms.DataGridView();
            this.panel3 = new System.Windows.Forms.Panel();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.dgvSel = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.button3 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtSel = new System.Windows.Forms.TextBox();
            this.btnFcu = new System.Windows.Forms.RadioButton();
            this.btnDep = new System.Windows.Forms.RadioButton();
            this.panel1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvWhite)).BeginInit();
            this.panel3.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSel)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.groupBox2);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(544, 395);
            this.panel1.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dgvWhite);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(310, 75);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(234, 320);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "白名单";
            // 
            // dgvWhite
            // 
            this.dgvWhite.AllowUserToAddRows = false;
            this.dgvWhite.AllowUserToDeleteRows = false;
            this.dgvWhite.AllowUserToOrderColumns = true;
            this.dgvWhite.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvWhite.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvWhite.Location = new System.Drawing.Point(3, 17);
            this.dgvWhite.Name = "dgvWhite";
            this.dgvWhite.ReadOnly = true;
            this.dgvWhite.RowTemplate.Height = 23;
            this.dgvWhite.Size = new System.Drawing.Size(228, 300);
            this.dgvWhite.TabIndex = 0;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.groupBox3);
            this.panel3.Controls.Add(this.groupBox1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel3.Location = new System.Drawing.Point(0, 75);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(310, 320);
            this.panel3.TabIndex = 2;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.dgvSel);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Location = new System.Drawing.Point(0, 0);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(222, 320);
            this.groupBox3.TabIndex = 1;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "过滤";
            // 
            // dgvSel
            // 
            this.dgvSel.AllowUserToAddRows = false;
            this.dgvSel.AllowUserToDeleteRows = false;
            this.dgvSel.AllowUserToOrderColumns = true;
            this.dgvSel.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvSel.Location = new System.Drawing.Point(3, 17);
            this.dgvSel.Name = "dgvSel";
            this.dgvSel.ReadOnly = true;
            this.dgvSel.RowTemplate.Height = 23;
            this.dgvSel.Size = new System.Drawing.Size(216, 300);
            this.dgvSel.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Right;
            this.groupBox1.Location = new System.Drawing.Point(222, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(88, 320);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "操作";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(7, 45);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 1;
            this.button2.Tag = "移入";
            this.button2.Text = "移入>>";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(6, 97);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Tag = "移出";
            this.button1.Text = "<<移出";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.button3);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.txtSel);
            this.panel2.Controls.Add(this.btnFcu);
            this.panel2.Controls.Add(this.btnDep);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(544, 75);
            this.panel2.TabIndex = 1;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(260, 42);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 5;
            this.button3.Tag = "查询";
            this.button3.Text = "查询";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 4;
            this.label1.Text = "名称或代码";
            // 
            // txtSel
            // 
            this.txtSel.Location = new System.Drawing.Point(73, 44);
            this.txtSel.Name = "txtSel";
            this.txtSel.Size = new System.Drawing.Size(181, 21);
            this.txtSel.TabIndex = 2;
            this.txtSel.TextChanged += new System.EventHandler(this.txtSel_TextChanged);
            // 
            // btnFcu
            // 
            this.btnFcu.AutoSize = true;
            this.btnFcu.Location = new System.Drawing.Point(141, 12);
            this.btnFcu.Name = "btnFcu";
            this.btnFcu.Size = new System.Drawing.Size(59, 16);
            this.btnFcu.TabIndex = 1;
            this.btnFcu.TabStop = true;
            this.btnFcu.Text = "按客户";
            this.btnFcu.UseVisualStyleBackColor = true;
            this.btnFcu.CheckedChanged += new System.EventHandler(this.btnFcu_CheckedChanged);
            // 
            // btnDep
            // 
            this.btnDep.AutoSize = true;
            this.btnDep.Location = new System.Drawing.Point(29, 12);
            this.btnDep.Name = "btnDep";
            this.btnDep.Size = new System.Drawing.Size(59, 16);
            this.btnDep.TabIndex = 0;
            this.btnDep.TabStop = true;
            this.btnDep.Text = "按部门";
            this.btnDep.UseVisualStyleBackColor = true;
            this.btnDep.CheckedChanged += new System.EventHandler(this.btnDep_CheckedChanged);
            // 
            // frm_yx_WhiteList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(544, 395);
            this.Controls.Add(this.panel1);
            this.Name = "frm_yx_WhiteList";
            this.Tag = "96";
            this.Text = "信用白名单";
            this.Load += new System.EventHandler(this.frm_yx_WhiteList_Load);
            this.panel1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvWhite)).EndInit();
            this.panel3.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSel)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox txtSel;
        private System.Windows.Forms.RadioButton btnFcu;
        private System.Windows.Forms.RadioButton btnDep;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dgvWhite;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.DataGridView dgvSel;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button3;
    }
}