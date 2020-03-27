namespace YXK3FZ.YZGL
{
	partial class YZ_FYearDataByDept
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
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(YZ_FYearDataByDept));
			this.bdsMaster = new System.Windows.Forms.BindingSource(this.components);
			this.toolStrip1 = new System.Windows.Forms.ToolStrip();
			this.btnADD = new System.Windows.Forms.ToolStripButton();
			this.tsbtnEdit = new System.Windows.Forms.ToolStripButton();
			this.btnSave = new System.Windows.Forms.ToolStripButton();
			this.btnDelete = new System.Windows.Forms.ToolStripButton();
			this.btnConfirmer = new System.Windows.Forms.ToolStripButton();
			this.btnHConfirmer = new System.Windows.Forms.ToolStripButton();
			this.btnCheck = new System.Windows.Forms.ToolStripButton();
			this.btnHcheck = new System.Windows.Forms.ToolStripButton();
			this.btnExport = new System.Windows.Forms.ToolStripButton();
			this.btnClose = new System.Windows.Forms.ToolStripButton();
			this.statusStrip1 = new System.Windows.Forms.StatusStrip();
			this.LabTishi = new System.Windows.Forms.ToolStripStatusLabel();
			this.splitContainer1 = new System.Windows.Forms.SplitContainer();
			this.edtFYear = new System.Windows.Forms.TextBox();
			this.edtZB = new System.Windows.Forms.TextBox();
			this.edtFText = new System.Windows.Forms.TextBox();
			this.cobFProject = new System.Windows.Forms.ComboBox();
			this.label5 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.splitContainer2 = new System.Windows.Forms.SplitContainer();
			this.dataGridView1 = new System.Windows.Forms.DataGridView();
			this.edtFYearQ = new System.Windows.Forms.TextBox();
			this.label6 = new System.Windows.Forms.Label();
			this.button2 = new System.Windows.Forms.Button();
			this.button1 = new System.Windows.Forms.Button();
			this.cobFProjectQ = new System.Windows.Forms.ComboBox();
			this.label8 = new System.Windows.Forms.Label();
			this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			((System.ComponentModel.ISupportInitialize)(this.bdsMaster)).BeginInit();
			this.toolStrip1.SuspendLayout();
			this.statusStrip1.SuspendLayout();
			this.splitContainer1.Panel1.SuspendLayout();
			this.splitContainer1.Panel2.SuspendLayout();
			this.splitContainer1.SuspendLayout();
			this.splitContainer2.Panel1.SuspendLayout();
			this.splitContainer2.Panel2.SuspendLayout();
			this.splitContainer2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
			this.SuspendLayout();
			// 
			// bdsMaster
			// 
			this.bdsMaster.CurrentChanged += new System.EventHandler(this.bdsMaster_CurrentChanged);
			// 
			// toolStrip1
			// 
			this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnADD,
            this.tsbtnEdit,
            this.btnSave,
            this.btnDelete,
            this.btnConfirmer,
            this.btnHConfirmer,
            this.btnCheck,
            this.btnHcheck,
            this.btnExport,
            this.btnClose});
			this.toolStrip1.Location = new System.Drawing.Point(0, 0);
			this.toolStrip1.Name = "toolStrip1";
			this.toolStrip1.Size = new System.Drawing.Size(1008, 25);
			this.toolStrip1.TabIndex = 7;
			this.toolStrip1.Text = "toolStrip1";
			// 
			// btnADD
			// 
			this.btnADD.Image = global::YXK3FZ.Properties.Resources.add;
			this.btnADD.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnADD.Name = "btnADD";
			this.btnADD.Size = new System.Drawing.Size(52, 22);
			this.btnADD.Tag = "新增";
			this.btnADD.Text = "新增";
			this.btnADD.Click += new System.EventHandler(this.btnADD_Click);
			// 
			// tsbtnEdit
			// 
			this.tsbtnEdit.Image = global::YXK3FZ.Properties.Resources.采购订单;
			this.tsbtnEdit.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsbtnEdit.Name = "tsbtnEdit";
			this.tsbtnEdit.Size = new System.Drawing.Size(52, 22);
			this.tsbtnEdit.Tag = "编辑";
			this.tsbtnEdit.Text = "编辑";
			this.tsbtnEdit.Click += new System.EventHandler(this.tsbtnEdit_Click);
			// 
			// btnSave
			// 
			this.btnSave.Image = global::YXK3FZ.Properties.Resources.save;
			this.btnSave.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnSave.Name = "btnSave";
			this.btnSave.Size = new System.Drawing.Size(52, 22);
			this.btnSave.Tag = "保存";
			this.btnSave.Text = "保存";
			this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
			// 
			// btnDelete
			// 
			this.btnDelete.Image = ((System.Drawing.Image)(resources.GetObject("btnDelete.Image")));
			this.btnDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnDelete.Name = "btnDelete";
			this.btnDelete.Size = new System.Drawing.Size(52, 22);
			this.btnDelete.Text = "删除";
			this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
			// 
			// btnConfirmer
			// 
			this.btnConfirmer.Image = global::YXK3FZ.Properties.Resources.CLAIM;
			this.btnConfirmer.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnConfirmer.Name = "btnConfirmer";
			this.btnConfirmer.Size = new System.Drawing.Size(52, 22);
			this.btnConfirmer.Tag = "确认";
			this.btnConfirmer.Text = "确认";
			this.btnConfirmer.Visible = false;
			// 
			// btnHConfirmer
			// 
			this.btnHConfirmer.Image = global::YXK3FZ.Properties.Resources.UNCLAIM;
			this.btnHConfirmer.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnHConfirmer.Name = "btnHConfirmer";
			this.btnHConfirmer.Size = new System.Drawing.Size(64, 22);
			this.btnHConfirmer.Tag = "反确认";
			this.btnHConfirmer.Text = "反确认";
			this.btnHConfirmer.Visible = false;
			// 
			// btnCheck
			// 
			this.btnCheck.Image = global::YXK3FZ.Properties.Resources.change;
			this.btnCheck.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnCheck.Name = "btnCheck";
			this.btnCheck.Size = new System.Drawing.Size(52, 22);
			this.btnCheck.Tag = "审核";
			this.btnCheck.Text = "审核";
			this.btnCheck.Visible = false;
			// 
			// btnHcheck
			// 
			this.btnHcheck.Image = global::YXK3FZ.Properties.Resources.cancel;
			this.btnHcheck.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnHcheck.Name = "btnHcheck";
			this.btnHcheck.Size = new System.Drawing.Size(64, 22);
			this.btnHcheck.Tag = "反审核";
			this.btnHcheck.Text = "反审核";
			this.btnHcheck.Visible = false;
			// 
			// btnExport
			// 
			this.btnExport.Image = ((System.Drawing.Image)(resources.GetObject("btnExport.Image")));
			this.btnExport.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnExport.Name = "btnExport";
			this.btnExport.Size = new System.Drawing.Size(52, 22);
			this.btnExport.Text = "导出";
			this.btnExport.Visible = false;
			// 
			// btnClose
			// 
			this.btnClose.Image = global::YXK3FZ.Properties.Resources.stop;
			this.btnClose.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnClose.Name = "btnClose";
			this.btnClose.Size = new System.Drawing.Size(52, 22);
			this.btnClose.Tag = "退出";
			this.btnClose.Text = "退出";
			this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
			// 
			// statusStrip1
			// 
			this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.LabTishi});
			this.statusStrip1.Location = new System.Drawing.Point(0, 708);
			this.statusStrip1.Name = "statusStrip1";
			this.statusStrip1.Size = new System.Drawing.Size(1008, 22);
			this.statusStrip1.TabIndex = 43;
			this.statusStrip1.Text = "statusStrip1";
			// 
			// LabTishi
			// 
			this.LabTishi.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.LabTishi.Name = "LabTishi";
			this.LabTishi.Size = new System.Drawing.Size(43, 17);
			this.LabTishi.Text = "提示：";
			// 
			// splitContainer1
			// 
			this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
			this.splitContainer1.Location = new System.Drawing.Point(0, 25);
			this.splitContainer1.Name = "splitContainer1";
			// 
			// splitContainer1.Panel1
			// 
			this.splitContainer1.Panel1.Controls.Add(this.edtFYear);
			this.splitContainer1.Panel1.Controls.Add(this.edtZB);
			this.splitContainer1.Panel1.Controls.Add(this.edtFText);
			this.splitContainer1.Panel1.Controls.Add(this.cobFProject);
			this.splitContainer1.Panel1.Controls.Add(this.label5);
			this.splitContainer1.Panel1.Controls.Add(this.label3);
			this.splitContainer1.Panel1.Controls.Add(this.label2);
			this.splitContainer1.Panel1.Controls.Add(this.label1);
			// 
			// splitContainer1.Panel2
			// 
			this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
			this.splitContainer1.Size = new System.Drawing.Size(1008, 683);
			this.splitContainer1.SplitterDistance = 311;
			this.splitContainer1.SplitterWidth = 1;
			this.splitContainer1.TabIndex = 44;
			// 
			// edtFYear
			// 
			this.edtFYear.Location = new System.Drawing.Point(81, 5);
			this.edtFYear.Name = "edtFYear";
			this.edtFYear.Size = new System.Drawing.Size(208, 21);
			this.edtFYear.TabIndex = 38;
			// 
			// edtZB
			// 
			this.edtZB.Location = new System.Drawing.Point(81, 55);
			this.edtZB.Name = "edtZB";
			this.edtZB.Size = new System.Drawing.Size(208, 21);
			this.edtZB.TabIndex = 38;
			// 
			// edtFText
			// 
			this.edtFText.Location = new System.Drawing.Point(81, 80);
			this.edtFText.Multiline = true;
			this.edtFText.Name = "edtFText";
			this.edtFText.Size = new System.Drawing.Size(208, 235);
			this.edtFText.TabIndex = 37;
			// 
			// cobFProject
			// 
			this.cobFProject.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cobFProject.FormattingEnabled = true;
			this.cobFProject.Location = new System.Drawing.Point(81, 30);
			this.cobFProject.Name = "cobFProject";
			this.cobFProject.Size = new System.Drawing.Size(208, 20);
			this.cobFProject.TabIndex = 36;
			// 
			// label5
			// 
			this.label5.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.label5.Location = new System.Drawing.Point(10, 5);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(64, 25);
			this.label5.TabIndex = 35;
			this.label5.Text = "年份";
			this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label3
			// 
			this.label3.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.label3.Location = new System.Drawing.Point(10, 80);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(64, 25);
			this.label3.TabIndex = 35;
			this.label3.Text = "备注";
			this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label2
			// 
			this.label2.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.label2.Location = new System.Drawing.Point(10, 55);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(64, 25);
			this.label2.TabIndex = 35;
			this.label2.Text = "指标";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label1
			// 
			this.label1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.label1.Location = new System.Drawing.Point(10, 30);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(64, 25);
			this.label1.TabIndex = 35;
			this.label1.Text = "考核部门";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// splitContainer2
			// 
			this.splitContainer2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainer2.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
			this.splitContainer2.Location = new System.Drawing.Point(0, 0);
			this.splitContainer2.Name = "splitContainer2";
			this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
			// 
			// splitContainer2.Panel1
			// 
			this.splitContainer2.Panel1.Controls.Add(this.dataGridView1);
			// 
			// splitContainer2.Panel2
			// 
			this.splitContainer2.Panel2.Controls.Add(this.edtFYearQ);
			this.splitContainer2.Panel2.Controls.Add(this.label6);
			this.splitContainer2.Panel2.Controls.Add(this.button2);
			this.splitContainer2.Panel2.Controls.Add(this.button1);
			this.splitContainer2.Panel2.Controls.Add(this.cobFProjectQ);
			this.splitContainer2.Panel2.Controls.Add(this.label8);
			this.splitContainer2.Size = new System.Drawing.Size(696, 683);
			this.splitContainer2.SplitterDistance = 532;
			this.splitContainer2.SplitterWidth = 1;
			this.splitContainer2.TabIndex = 0;
			// 
			// dataGridView1
			// 
			this.dataGridView1.AllowUserToAddRows = false;
			this.dataGridView1.AllowUserToDeleteRows = false;
			this.dataGridView1.AutoGenerateColumns = false;
			this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column5});
			this.dataGridView1.DataSource = this.bdsMaster;
			this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dataGridView1.Location = new System.Drawing.Point(0, 0);
			this.dataGridView1.Name = "dataGridView1";
			this.dataGridView1.ReadOnly = true;
			this.dataGridView1.RowTemplate.Height = 23;
			this.dataGridView1.Size = new System.Drawing.Size(694, 530);
			this.dataGridView1.TabIndex = 0;
			this.dataGridView1.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dgvDetail_RowPostPaint);
			// 
			// edtFYearQ
			// 
			this.edtFYearQ.Location = new System.Drawing.Point(106, 45);
			this.edtFYearQ.Name = "edtFYearQ";
			this.edtFYearQ.Size = new System.Drawing.Size(208, 21);
			this.edtFYearQ.TabIndex = 45;
			// 
			// label6
			// 
			this.label6.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.label6.Location = new System.Drawing.Point(35, 45);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(64, 25);
			this.label6.TabIndex = 44;
			this.label6.Text = "年份";
			this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// button2
			// 
			this.button2.Location = new System.Drawing.Point(456, 56);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(75, 23);
			this.button2.TabIndex = 43;
			this.button2.Text = "清空";
			this.button2.UseVisualStyleBackColor = true;
			this.button2.Click += new System.EventHandler(this.button2_Click);
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(375, 56);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(75, 23);
			this.button1.TabIndex = 43;
			this.button1.Text = "查询";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// cobFProjectQ
			// 
			this.cobFProjectQ.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cobFProjectQ.FormattingEnabled = true;
			this.cobFProjectQ.Location = new System.Drawing.Point(106, 70);
			this.cobFProjectQ.Name = "cobFProjectQ";
			this.cobFProjectQ.Size = new System.Drawing.Size(208, 20);
			this.cobFProjectQ.TabIndex = 42;
			// 
			// label8
			// 
			this.label8.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.label8.Location = new System.Drawing.Point(35, 70);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(64, 25);
			this.label8.TabIndex = 39;
			this.label8.Text = "考核部门";
			this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// Column1
			// 
			this.Column1.DataPropertyName = "年份";
			this.Column1.HeaderText = "年份";
			this.Column1.Name = "Column1";
			this.Column1.ReadOnly = true;
			this.Column1.Width = 80;
			// 
			// Column2
			// 
			this.Column2.DataPropertyName = "考核部门";
			this.Column2.HeaderText = "考核项目";
			this.Column2.Name = "Column2";
			this.Column2.ReadOnly = true;
			// 
			// Column3
			// 
			this.Column3.DataPropertyName = "指标";
			this.Column3.HeaderText = "指标";
			this.Column3.Name = "Column3";
			this.Column3.ReadOnly = true;
			this.Column3.Width = 150;
			// 
			// Column5
			// 
			this.Column5.DataPropertyName = "备注";
			this.Column5.HeaderText = "备注";
			this.Column5.Name = "Column5";
			this.Column5.ReadOnly = true;
			this.Column5.Width = 200;
			// 
			// YZ_FYearDataByDept
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1008, 730);
			this.Controls.Add(this.splitContainer1);
			this.Controls.Add(this.statusStrip1);
			this.Controls.Add(this.toolStrip1);
			this.Name = "YZ_FYearDataByDept";
			this.Text = "年度绩效考核成本指标数据(按部门)";
			this.Load += new System.EventHandler(this.YZ_FYearDataByDept_Load);
			((System.ComponentModel.ISupportInitialize)(this.bdsMaster)).EndInit();
			this.toolStrip1.ResumeLayout(false);
			this.toolStrip1.PerformLayout();
			this.statusStrip1.ResumeLayout(false);
			this.statusStrip1.PerformLayout();
			this.splitContainer1.Panel1.ResumeLayout(false);
			this.splitContainer1.Panel1.PerformLayout();
			this.splitContainer1.Panel2.ResumeLayout(false);
			this.splitContainer1.ResumeLayout(false);
			this.splitContainer2.Panel1.ResumeLayout(false);
			this.splitContainer2.Panel2.ResumeLayout(false);
			this.splitContainer2.Panel2.PerformLayout();
			this.splitContainer2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.BindingSource bdsMaster;
		private System.Windows.Forms.ToolStrip toolStrip1;
		private System.Windows.Forms.ToolStripButton btnADD;
		private System.Windows.Forms.ToolStripButton tsbtnEdit;
		private System.Windows.Forms.ToolStripButton btnSave;
		private System.Windows.Forms.ToolStripButton btnDelete;
		private System.Windows.Forms.ToolStripButton btnConfirmer;
		private System.Windows.Forms.ToolStripButton btnHConfirmer;
		private System.Windows.Forms.ToolStripButton btnCheck;
		private System.Windows.Forms.ToolStripButton btnHcheck;
		private System.Windows.Forms.ToolStripButton btnExport;
		private System.Windows.Forms.ToolStripButton btnClose;
		private System.Windows.Forms.StatusStrip statusStrip1;
		private System.Windows.Forms.ToolStripStatusLabel LabTishi;
		private System.Windows.Forms.SplitContainer splitContainer1;
		private System.Windows.Forms.TextBox edtFYear;
		private System.Windows.Forms.TextBox edtZB;
		private System.Windows.Forms.TextBox edtFText;
		private System.Windows.Forms.ComboBox cobFProject;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.SplitContainer splitContainer2;
		private System.Windows.Forms.DataGridView dataGridView1;
		private System.Windows.Forms.TextBox edtFYearQ;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.ComboBox cobFProjectQ;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
		private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
		private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
		private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
	}
}