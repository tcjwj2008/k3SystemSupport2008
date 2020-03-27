namespace YXK3FZ.RYGYL
{
    partial class frm_spOrderPlan
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
					this.groupBox1 = new System.Windows.Forms.GroupBox();
					this.btnOut = new System.Windows.Forms.Button();
					this.label1 = new System.Windows.Forms.Label();
					this.btnSel = new System.Windows.Forms.Button();
					this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
					this.label2 = new System.Windows.Forms.Label();
					this.txtFcur = new System.Windows.Forms.TextBox();
					this.panel2 = new System.Windows.Forms.Panel();
					this.crystalReportViewer1 = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
					this.cobMarket = new System.Windows.Forms.ComboBox();
					this.ckSelect = new System.Windows.Forms.CheckBox();
					this.panel1.SuspendLayout();
					this.groupBox1.SuspendLayout();
					this.panel2.SuspendLayout();
					this.SuspendLayout();
					// 
					// panel1
					// 
					this.panel1.Controls.Add(this.groupBox1);
					this.panel1.Controls.Add(this.txtFcur);
					this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
					this.panel1.Location = new System.Drawing.Point(0, 0);
					this.panel1.Name = "panel1";
					this.panel1.Size = new System.Drawing.Size(178, 710);
					this.panel1.TabIndex = 0;
					// 
					// groupBox1
					// 
					this.groupBox1.Controls.Add(this.ckSelect);
					this.groupBox1.Controls.Add(this.cobMarket);
					this.groupBox1.Controls.Add(this.btnOut);
					this.groupBox1.Controls.Add(this.label1);
					this.groupBox1.Controls.Add(this.btnSel);
					this.groupBox1.Controls.Add(this.dateTimePicker1);
					this.groupBox1.Controls.Add(this.label2);
					this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
					this.groupBox1.Location = new System.Drawing.Point(0, 0);
					this.groupBox1.Name = "groupBox1";
					this.groupBox1.Size = new System.Drawing.Size(178, 197);
					this.groupBox1.TabIndex = 0;
					this.groupBox1.TabStop = false;
					this.groupBox1.Text = "过滤";
					// 
					// btnOut
					// 
					this.btnOut.Location = new System.Drawing.Point(49, 150);
					this.btnOut.Name = "btnOut";
					this.btnOut.Size = new System.Drawing.Size(75, 23);
					this.btnOut.TabIndex = 17;
					this.btnOut.Text = "导出EXCEL";
					this.btnOut.UseVisualStyleBackColor = true;
					this.btnOut.Click += new System.EventHandler(this.btnOut_Click);
					// 
					// label1
					// 
					this.label1.AutoSize = true;
					this.label1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
					this.label1.Location = new System.Drawing.Point(3, 30);
					this.label1.Name = "label1";
					this.label1.Size = new System.Drawing.Size(70, 14);
					this.label1.TabIndex = 13;
					this.label1.Text = "配送日期:";
					// 
					// btnSel
					// 
					this.btnSel.Location = new System.Drawing.Point(49, 109);
					this.btnSel.Name = "btnSel";
					this.btnSel.Size = new System.Drawing.Size(75, 23);
					this.btnSel.TabIndex = 16;
					this.btnSel.Tag = "查询";
					this.btnSel.Text = "查询";
					this.btnSel.UseVisualStyleBackColor = true;
					this.btnSel.Click += new System.EventHandler(this.btnSel_Click);
					// 
					// dateTimePicker1
					// 
					this.dateTimePicker1.CustomFormat = "yyyy-mm-dd";
					this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
					this.dateTimePicker1.Location = new System.Drawing.Point(80, 26);
					this.dateTimePicker1.Name = "dateTimePicker1";
					this.dateTimePicker1.Size = new System.Drawing.Size(80, 21);
					this.dateTimePicker1.TabIndex = 12;
					// 
					// label2
					// 
					this.label2.AutoSize = true;
					this.label2.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
					this.label2.Location = new System.Drawing.Point(8, 60);
					this.label2.Name = "label2";
					this.label2.Size = new System.Drawing.Size(42, 14);
					this.label2.TabIndex = 14;
					this.label2.Text = "组别:";
					// 
					// txtFcur
					// 
					this.txtFcur.Location = new System.Drawing.Point(19, 237);
					this.txtFcur.Name = "txtFcur";
					this.txtFcur.Size = new System.Drawing.Size(105, 21);
					this.txtFcur.TabIndex = 15;
					this.txtFcur.Visible = false;
					// 
					// panel2
					// 
					this.panel2.Controls.Add(this.crystalReportViewer1);
					this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
					this.panel2.Location = new System.Drawing.Point(178, 0);
					this.panel2.Name = "panel2";
					this.panel2.Size = new System.Drawing.Size(766, 710);
					this.panel2.TabIndex = 1;
					// 
					// crystalReportViewer1
					// 
					this.crystalReportViewer1.ActiveViewIndex = -1;
					this.crystalReportViewer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
					this.crystalReportViewer1.DisplayGroupTree = false;
					this.crystalReportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
					this.crystalReportViewer1.Location = new System.Drawing.Point(0, 0);
					this.crystalReportViewer1.Name = "crystalReportViewer1";
					this.crystalReportViewer1.SelectionFormula = "";
					this.crystalReportViewer1.Size = new System.Drawing.Size(766, 710);
					this.crystalReportViewer1.TabIndex = 0;
					this.crystalReportViewer1.ViewTimeSelectionFormula = "";
					// 
					// cobMarket
					// 
					this.cobMarket.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
					this.cobMarket.FormattingEnabled = true;
					this.cobMarket.Location = new System.Drawing.Point(57, 60);
					this.cobMarket.Name = "cobMarket";
					this.cobMarket.Size = new System.Drawing.Size(103, 20);
					this.cobMarket.TabIndex = 1;
					// 
					// ckSelect
					// 
					this.ckSelect.AutoSize = true;
					this.ckSelect.Font = new System.Drawing.Font("宋体", 10F);
					this.ckSelect.Location = new System.Drawing.Point(3, 60);
					this.ckSelect.Name = "ckSelect";
					this.ckSelect.Size = new System.Drawing.Size(54, 18);
					this.ckSelect.TabIndex = 16;
					this.ckSelect.Text = "组别";
					this.ckSelect.UseVisualStyleBackColor = true;
					this.ckSelect.CheckedChanged += new System.EventHandler(this.ckSelect_CheckedChanged);
					// 
					// frm_spOrderPlan
					// 
					this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
					this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
					this.ClientSize = new System.Drawing.Size(944, 710);
					this.Controls.Add(this.panel2);
					this.Controls.Add(this.panel1);
					this.Name = "frm_spOrderPlan";
					this.Tag = "110";
					this.Text = "食品销售计划表";
					this.Load += new System.EventHandler(this.frm_spOrderPlan_Load);
					this.panel1.ResumeLayout(false);
					this.panel1.PerformLayout();
					this.groupBox1.ResumeLayout(false);
					this.groupBox1.PerformLayout();
					this.panel2.ResumeLayout(false);
					this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private CrystalDecisions.Windows.Forms.CrystalReportViewer crystalReportViewer1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSel;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtFcur;
        private System.Windows.Forms.Button btnOut;
				private System.Windows.Forms.ComboBox cobMarket;
				private System.Windows.Forms.CheckBox ckSelect;
    }
}