namespace YXK3FZ.YZGL
{
	partial class frmYZJXKHSelect
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
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
			this.splitContainer1 = new System.Windows.Forms.SplitContainer();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.richTextBox1 = new System.Windows.Forms.RichTextBox();
			this.cobFBoatID = new System.Windows.Forms.ComboBox();
			this.cobFProject = new System.Windows.Forms.ComboBox();
			this.cobFDepartID = new System.Windows.Forms.ComboBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label14 = new System.Windows.Forms.Label();
			this.btnEXCEL = new System.Windows.Forms.Button();
			this.btnFind = new System.Windows.Forms.Button();
			this.dataGridView1 = new System.Windows.Forms.DataGridView();
			this.bdsMaster = new System.Windows.Forms.BindingSource(this.components);
			this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Column14 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Column15 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Column16 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Column17 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Column18 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Column9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Column10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Column11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Column12 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Column13 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.splitContainer1.Panel1.SuspendLayout();
			this.splitContainer1.Panel2.SuspendLayout();
			this.splitContainer1.SuspendLayout();
			this.groupBox1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.bdsMaster)).BeginInit();
			this.SuspendLayout();
			// 
			// splitContainer1
			// 
			this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
			this.splitContainer1.Location = new System.Drawing.Point(0, 0);
			this.splitContainer1.Name = "splitContainer1";
			this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
			// 
			// splitContainer1.Panel1
			// 
			this.splitContainer1.Panel1.Controls.Add(this.groupBox1);
			// 
			// splitContainer1.Panel2
			// 
			this.splitContainer1.Panel2.Controls.Add(this.dataGridView1);
			this.splitContainer1.Size = new System.Drawing.Size(1008, 730);
			this.splitContainer1.SplitterDistance = 100;
			this.splitContainer1.SplitterWidth = 1;
			this.splitContainer1.TabIndex = 1;
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.richTextBox1);
			this.groupBox1.Controls.Add(this.cobFBoatID);
			this.groupBox1.Controls.Add(this.cobFProject);
			this.groupBox1.Controls.Add(this.cobFDepartID);
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Controls.Add(this.label2);
			this.groupBox1.Controls.Add(this.label14);
			this.groupBox1.Controls.Add(this.btnEXCEL);
			this.groupBox1.Controls.Add(this.btnFind);
			this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.groupBox1.Location = new System.Drawing.Point(0, 0);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(1006, 98);
			this.groupBox1.TabIndex = 0;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "过滤条件";
			// 
			// richTextBox1
			// 
			this.richTextBox1.Dock = System.Windows.Forms.DockStyle.Right;
			this.richTextBox1.Enabled = false;
			this.richTextBox1.Location = new System.Drawing.Point(785, 17);
			this.richTextBox1.Name = "richTextBox1";
			this.richTextBox1.Size = new System.Drawing.Size(218, 78);
			this.richTextBox1.TabIndex = 57;
			this.richTextBox1.Text = "说明\n1、查询船次必须选择";
			// 
			// cobFBoatID
			// 
			this.cobFBoatID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cobFBoatID.FormattingEnabled = true;
			this.cobFBoatID.Location = new System.Drawing.Point(69, 43);
			this.cobFBoatID.Name = "cobFBoatID";
			this.cobFBoatID.Size = new System.Drawing.Size(127, 20);
			this.cobFBoatID.TabIndex = 56;
			// 
			// cobFProject
			// 
			this.cobFProject.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cobFProject.FormattingEnabled = true;
			this.cobFProject.Location = new System.Drawing.Point(259, 43);
			this.cobFProject.Name = "cobFProject";
			this.cobFProject.Size = new System.Drawing.Size(127, 20);
			this.cobFProject.TabIndex = 56;
			// 
			// cobFDepartID
			// 
			this.cobFDepartID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cobFDepartID.FormattingEnabled = true;
			this.cobFDepartID.Location = new System.Drawing.Point(449, 43);
			this.cobFDepartID.Name = "cobFDepartID";
			this.cobFDepartID.Size = new System.Drawing.Size(127, 20);
			this.cobFDepartID.TabIndex = 56;
			// 
			// label1
			// 
			this.label1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.label1.Location = new System.Drawing.Point(11, 43);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(52, 25);
			this.label1.TabIndex = 55;
			this.label1.Text = "船次";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label2
			// 
			this.label2.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.label2.Location = new System.Drawing.Point(202, 43);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(52, 25);
			this.label2.TabIndex = 55;
			this.label2.Text = "项目";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label14
			// 
			this.label14.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.label14.Location = new System.Drawing.Point(392, 43);
			this.label14.Name = "label14";
			this.label14.Size = new System.Drawing.Size(52, 25);
			this.label14.TabIndex = 55;
			this.label14.Text = "部门";
			this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// btnEXCEL
			// 
			this.btnEXCEL.Location = new System.Drawing.Point(673, 43);
			this.btnEXCEL.Name = "btnEXCEL";
			this.btnEXCEL.Size = new System.Drawing.Size(77, 23);
			this.btnEXCEL.TabIndex = 54;
			this.btnEXCEL.Tag = "导出";
			this.btnEXCEL.Text = "导出";
			this.btnEXCEL.UseVisualStyleBackColor = true;
			this.btnEXCEL.Click += new System.EventHandler(this.btnEXCEL_Click);
			// 
			// btnFind
			// 
			this.btnFind.Location = new System.Drawing.Point(591, 43);
			this.btnFind.Name = "btnFind";
			this.btnFind.Size = new System.Drawing.Size(77, 23);
			this.btnFind.TabIndex = 53;
			this.btnFind.Tag = "查询";
			this.btnFind.Text = "查询";
			this.btnFind.UseVisualStyleBackColor = true;
			this.btnFind.Click += new System.EventHandler(this.btnFind_Click);
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
            this.Column4,
            this.Column14,
            this.Column15,
            this.Column16,
            this.Column17,
            this.Column18,
            this.Column5,
            this.Column6,
            this.Column7,
            this.Column8,
            this.Column9,
            this.Column10,
            this.Column11,
            this.Column12,
            this.Column13});
			this.dataGridView1.DataSource = this.bdsMaster;
			this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dataGridView1.Location = new System.Drawing.Point(0, 0);
			this.dataGridView1.Name = "dataGridView1";
			this.dataGridView1.ReadOnly = true;
			this.dataGridView1.RowHeadersWidth = 50;
			this.dataGridView1.RowTemplate.Height = 23;
			this.dataGridView1.Size = new System.Drawing.Size(1006, 627);
			this.dataGridView1.TabIndex = 0;
			this.dataGridView1.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dgvDetail_RowPostPaint);
			// 
			// Column1
			// 
			this.Column1.DataPropertyName = "环节";
			this.Column1.HeaderText = "环节";
			this.Column1.Name = "Column1";
			this.Column1.ReadOnly = true;
			this.Column1.Width = 120;
			// 
			// Column2
			// 
			this.Column2.DataPropertyName = "项目";
			this.Column2.HeaderText = "项目";
			this.Column2.Name = "Column2";
			this.Column2.ReadOnly = true;
			// 
			// Column3
			// 
			this.Column3.DataPropertyName = "小项";
			this.Column3.HeaderText = "小项";
			this.Column3.Name = "Column3";
			this.Column3.ReadOnly = true;
			// 
			// Column4
			// 
			this.Column4.DataPropertyName = "部门";
			this.Column4.HeaderText = "部门";
			this.Column4.Name = "Column4";
			this.Column4.ReadOnly = true;
			// 
			// Column14
			// 
			this.Column14.DataPropertyName = "金额2";
			this.Column14.HeaderText = "金额(折算)";
			this.Column14.Name = "Column14";
			this.Column14.ReadOnly = true;
			// 
			// Column15
			// 
			this.Column15.DataPropertyName = "吨均2";
			this.Column15.HeaderText = "吨均(折算)";
			this.Column15.Name = "Column15";
			this.Column15.ReadOnly = true;
			// 
			// Column16
			// 
			this.Column16.DataPropertyName = "耗用量2";
			this.Column16.HeaderText = "耗用量(折算)";
			this.Column16.Name = "Column16";
			this.Column16.ReadOnly = true;
			this.Column16.Width = 120;
			// 
			// Column17
			// 
			this.Column17.DataPropertyName = "单耗2";
			this.Column17.HeaderText = "单耗(折算)";
			this.Column17.Name = "Column17";
			this.Column17.ReadOnly = true;
			// 
			// Column18
			// 
			this.Column18.DataPropertyName = "单价2";
			this.Column18.HeaderText = "单价(折算) ";
			this.Column18.Name = "Column18";
			this.Column18.ReadOnly = true;
			// 
			// Column5
			// 
			this.Column5.DataPropertyName = "金额";
			dataGridViewCellStyle1.NullValue = null;
			this.Column5.DefaultCellStyle = dataGridViewCellStyle1;
			this.Column5.HeaderText = "金额";
			this.Column5.Name = "Column5";
			this.Column5.ReadOnly = true;
			// 
			// Column6
			// 
			this.Column6.DataPropertyName = "吨均";
			this.Column6.HeaderText = "吨均";
			this.Column6.Name = "Column6";
			this.Column6.ReadOnly = true;
			// 
			// Column7
			// 
			this.Column7.DataPropertyName = "耗用量";
			this.Column7.HeaderText = "耗用量";
			this.Column7.Name = "Column7";
			this.Column7.ReadOnly = true;
			// 
			// Column8
			// 
			this.Column8.DataPropertyName = "单耗";
			this.Column8.HeaderText = "单耗";
			this.Column8.Name = "Column8";
			this.Column8.ReadOnly = true;
			// 
			// Column9
			// 
			this.Column9.DataPropertyName = "单耗单位";
			this.Column9.HeaderText = "单耗单位";
			this.Column9.Name = "Column9";
			this.Column9.ReadOnly = true;
			// 
			// Column10
			// 
			this.Column10.DataPropertyName = "单价";
			this.Column10.HeaderText = "单价";
			this.Column10.Name = "Column10";
			this.Column10.ReadOnly = true;
			// 
			// Column11
			// 
			this.Column11.DataPropertyName = "单价单位";
			this.Column11.HeaderText = "单价单位";
			this.Column11.Name = "Column11";
			this.Column11.ReadOnly = true;
			// 
			// Column12
			// 
			this.Column12.DataPropertyName = "上一年度完成数据";
			this.Column12.HeaderText = "上一年度完成数据";
			this.Column12.Name = "Column12";
			this.Column12.ReadOnly = true;
			this.Column12.Width = 80;
			// 
			// Column13
			// 
			this.Column13.DataPropertyName = "差异";
			this.Column13.HeaderText = "差异";
			this.Column13.Name = "Column13";
			this.Column13.ReadOnly = true;
			// 
			// frmYZJXKHSelect
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1008, 730);
			this.Controls.Add(this.splitContainer1);
			this.Name = "frmYZJXKHSelect";
			this.Text = "油脂绩效考核查询";
			this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
			this.Load += new System.EventHandler(this.frmYZJXKHSelect_Load);
			this.splitContainer1.Panel1.ResumeLayout(false);
			this.splitContainer1.Panel2.ResumeLayout(false);
			this.splitContainer1.ResumeLayout(false);
			this.groupBox1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.bdsMaster)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.SplitContainer splitContainer1;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Button btnEXCEL;
		private System.Windows.Forms.Button btnFind;
		private System.Windows.Forms.DataGridView dataGridView1;
		private System.Windows.Forms.BindingSource bdsMaster;
		private System.Windows.Forms.ComboBox cobFBoatID;
		private System.Windows.Forms.ComboBox cobFDepartID;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label14;
		private System.Windows.Forms.RichTextBox richTextBox1;
		private System.Windows.Forms.ComboBox cobFProject;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
		private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
		private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
		private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
		private System.Windows.Forms.DataGridViewTextBoxColumn Column14;
		private System.Windows.Forms.DataGridViewTextBoxColumn Column15;
		private System.Windows.Forms.DataGridViewTextBoxColumn Column16;
		private System.Windows.Forms.DataGridViewTextBoxColumn Column17;
		private System.Windows.Forms.DataGridViewTextBoxColumn Column18;
		private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
		private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
		private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
		private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
		private System.Windows.Forms.DataGridViewTextBoxColumn Column9;
		private System.Windows.Forms.DataGridViewTextBoxColumn Column10;
		private System.Windows.Forms.DataGridViewTextBoxColumn Column11;
		private System.Windows.Forms.DataGridViewTextBoxColumn Column12;
		private System.Windows.Forms.DataGridViewTextBoxColumn Column13;
	}
}