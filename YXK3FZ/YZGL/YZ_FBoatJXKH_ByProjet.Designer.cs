namespace YXK3FZ.YZGL
{
	partial class YZ_FBoatJXKH_ByProjet
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
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
			this.splitContainer1 = new System.Windows.Forms.SplitContainer();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.richTextBox1 = new System.Windows.Forms.RichTextBox();
			this.cobFBoatID = new System.Windows.Forms.ComboBox();
			this.label1 = new System.Windows.Forms.Label();
			this.btnEXCEL = new System.Windows.Forms.Button();
			this.btnFind = new System.Windows.Forms.Button();
			this.dataGridView1 = new System.Windows.Forms.DataGridView();
			this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Column9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Column10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Column11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Column12 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.bdsMaster = new System.Windows.Forms.BindingSource(this.components);
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
			this.splitContainer1.TabIndex = 2;
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.richTextBox1);
			this.groupBox1.Controls.Add(this.cobFBoatID);
			this.groupBox1.Controls.Add(this.label1);
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
			this.richTextBox1.Location = new System.Drawing.Point(421, 17);
			this.richTextBox1.Name = "richTextBox1";
			this.richTextBox1.Size = new System.Drawing.Size(582, 78);
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
			// btnEXCEL
			// 
			this.btnEXCEL.Location = new System.Drawing.Point(325, 41);
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
			this.btnFind.Location = new System.Drawing.Point(243, 41);
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
            this.Column7,
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5,
            this.Column6,
            this.Column8,
            this.Column9,
            this.Column10,
            this.Column11,
            this.Column12});
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
			// Column7
			// 
			this.Column7.DataPropertyName = "年份";
			this.Column7.HeaderText = "年份";
			this.Column7.Name = "Column7";
			this.Column7.ReadOnly = true;
			this.Column7.Width = 80;
			// 
			// Column1
			// 
			this.Column1.DataPropertyName = "序号";
			this.Column1.HeaderText = "序号";
			this.Column1.Name = "Column1";
			this.Column1.ReadOnly = true;
			this.Column1.Width = 80;
			// 
			// Column2
			// 
			this.Column2.DataPropertyName = "考核项目";
			this.Column2.HeaderText = "考核项目";
			this.Column2.Name = "Column2";
			this.Column2.ReadOnly = true;
			// 
			// Column3
			// 
			this.Column3.DataPropertyName = "目标指标";
			dataGridViewCellStyle1.Format = "N2";
			dataGridViewCellStyle1.NullValue = null;
			this.Column3.DefaultCellStyle = dataGridViewCellStyle1;
			this.Column3.HeaderText = "目标指标";
			this.Column3.Name = "Column3";
			this.Column3.ReadOnly = true;
			// 
			// Column4
			// 
			this.Column4.DataPropertyName = "目标单价";
			dataGridViewCellStyle2.Format = "N4";
			this.Column4.DefaultCellStyle = dataGridViewCellStyle2;
			this.Column4.HeaderText = "目标单价";
			this.Column4.Name = "Column4";
			this.Column4.ReadOnly = true;
			// 
			// Column5
			// 
			this.Column5.DataPropertyName = "目标成本";
			dataGridViewCellStyle3.Format = "N2";
			this.Column5.DefaultCellStyle = dataGridViewCellStyle3;
			this.Column5.HeaderText = "目标成本(元/t料)";
			this.Column5.Name = "Column5";
			this.Column5.ReadOnly = true;
			this.Column5.Width = 80;
			// 
			// Column6
			// 
			this.Column6.DataPropertyName = "目标比例";
			this.Column6.HeaderText = "目标比例";
			this.Column6.Name = "Column6";
			this.Column6.ReadOnly = true;
			// 
			// Column8
			// 
			this.Column8.DataPropertyName = "实际指标";
			dataGridViewCellStyle4.Format = "N2";
			this.Column8.DefaultCellStyle = dataGridViewCellStyle4;
			this.Column8.HeaderText = "实际指标";
			this.Column8.Name = "Column8";
			this.Column8.ReadOnly = true;
			// 
			// Column9
			// 
			this.Column9.DataPropertyName = "指标增减";
			dataGridViewCellStyle5.Format = "N2";
			this.Column9.DefaultCellStyle = dataGridViewCellStyle5;
			this.Column9.HeaderText = "指标增减";
			this.Column9.Name = "Column9";
			this.Column9.ReadOnly = true;
			// 
			// Column10
			// 
			this.Column10.DataPropertyName = "实际成本";
			dataGridViewCellStyle6.Format = "N2";
			this.Column10.DefaultCellStyle = dataGridViewCellStyle6;
			this.Column10.HeaderText = "实际成本(元/t料)";
			this.Column10.Name = "Column10";
			this.Column10.ReadOnly = true;
			this.Column10.Width = 80;
			// 
			// Column11
			// 
			this.Column11.DataPropertyName = "比目标增减";
			dataGridViewCellStyle7.Format = "N2";
			this.Column11.DefaultCellStyle = dataGridViewCellStyle7;
			this.Column11.HeaderText = "比目标增减";
			this.Column11.Name = "Column11";
			this.Column11.ReadOnly = true;
			// 
			// Column12
			// 
			this.Column12.DataPropertyName = "实际比例";
			this.Column12.HeaderText = "实际比例";
			this.Column12.Name = "Column12";
			this.Column12.ReadOnly = true;
			// 
			// YZ_FBoatJXKH_ByProjet
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1008, 730);
			this.Controls.Add(this.splitContainer1);
			this.Name = "YZ_FBoatJXKH_ByProjet";
			this.Text = "船次绩效考核成本指标(按分项)查询";
			this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
			this.Load += new System.EventHandler(this.YZ_FBoatJXKH_ByProjet_Load);
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
		private System.Windows.Forms.RichTextBox richTextBox1;
		private System.Windows.Forms.ComboBox cobFBoatID;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button btnEXCEL;
		private System.Windows.Forms.Button btnFind;
		private System.Windows.Forms.DataGridView dataGridView1;
		private System.Windows.Forms.BindingSource bdsMaster;
		private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
		private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
		private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
		private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
		private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
		private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
		private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
		private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
		private System.Windows.Forms.DataGridViewTextBoxColumn Column9;
		private System.Windows.Forms.DataGridViewTextBoxColumn Column10;
		private System.Windows.Forms.DataGridViewTextBoxColumn Column11;
		private System.Windows.Forms.DataGridViewTextBoxColumn Column12;
	}
}