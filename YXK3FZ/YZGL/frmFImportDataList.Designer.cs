namespace YXK3FZ.YZGL
{
	partial class frmFImportDataList
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
			this.splitContainer2 = new System.Windows.Forms.SplitContainer();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.button3 = new System.Windows.Forms.Button();
			this.btnImport = new System.Windows.Forms.Button();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.groupBox3 = new System.Windows.Forms.GroupBox();
			this.rbByDay = new System.Windows.Forms.RadioButton();
			this.rbByYear = new System.Windows.Forms.RadioButton();
			this.rbByHour = new System.Windows.Forms.RadioButton();
			this.rbByMonth = new System.Windows.Forms.RadioButton();
			this.label1 = new System.Windows.Forms.Label();
			this.lblTitle = new System.Windows.Forms.Label();
			this.txtFDate2 = new System.Windows.Forms.DateTimePicker();
			this.txtFDate1 = new System.Windows.Forms.DateTimePicker();
			this.button2 = new System.Windows.Forms.Button();
			this.button1 = new System.Windows.Forms.Button();
			this.dataGridView1 = new System.Windows.Forms.DataGridView();
			this.Column0 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.colFDateTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Column9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Column10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Column11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Column12 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Column13 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Column14 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Column15 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Column16 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Column17 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.bdsFind = new System.Windows.Forms.BindingSource(this.components);
			this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
			this.splitContainer1.Panel1.SuspendLayout();
			this.splitContainer1.Panel2.SuspendLayout();
			this.splitContainer1.SuspendLayout();
			this.splitContainer2.Panel1.SuspendLayout();
			this.splitContainer2.Panel2.SuspendLayout();
			this.splitContainer2.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.groupBox3.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.bdsFind)).BeginInit();
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
			this.splitContainer1.Panel1.Controls.Add(this.splitContainer2);
			// 
			// splitContainer1.Panel2
			// 
			this.splitContainer1.Panel2.Controls.Add(this.dataGridView1);
			this.splitContainer1.Size = new System.Drawing.Size(1263, 603);
			this.splitContainer1.SplitterDistance = 100;
			this.splitContainer1.SplitterWidth = 1;
			this.splitContainer1.TabIndex = 0;
			// 
			// splitContainer2
			// 
			this.splitContainer2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainer2.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
			this.splitContainer2.IsSplitterFixed = true;
			this.splitContainer2.Location = new System.Drawing.Point(0, 0);
			this.splitContainer2.Name = "splitContainer2";
			// 
			// splitContainer2.Panel1
			// 
			this.splitContainer2.Panel1.Controls.Add(this.groupBox2);
			// 
			// splitContainer2.Panel2
			// 
			this.splitContainer2.Panel2.Controls.Add(this.groupBox1);
			this.splitContainer2.Size = new System.Drawing.Size(1263, 100);
			this.splitContainer2.SplitterDistance = 200;
			this.splitContainer2.SplitterWidth = 1;
			this.splitContainer2.TabIndex = 1;
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.button3);
			this.groupBox2.Controls.Add(this.btnImport);
			this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.groupBox2.Location = new System.Drawing.Point(0, 0);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(198, 98);
			this.groupBox2.TabIndex = 0;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "操作窗口";
			// 
			// button3
			// 
			this.button3.Location = new System.Drawing.Point(67, 24);
			this.button3.Name = "button3";
			this.button3.Size = new System.Drawing.Size(77, 23);
			this.button3.TabIndex = 0;
			this.button3.Tag = "读取EXCEL";
			this.button3.Text = "读取EXCEL";
			this.button3.UseVisualStyleBackColor = true;
			this.button3.Click += new System.EventHandler(this.button3_Click);
			// 
			// btnImport
			// 
			this.btnImport.Location = new System.Drawing.Point(67, 58);
			this.btnImport.Name = "btnImport";
			this.btnImport.Size = new System.Drawing.Size(77, 23);
			this.btnImport.TabIndex = 0;
			this.btnImport.Tag = "导入";
			this.btnImport.Text = "导入";
			this.btnImport.UseVisualStyleBackColor = true;
			this.btnImport.Click += new System.EventHandler(this.btnImport_Click);
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.groupBox3);
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Controls.Add(this.lblTitle);
			this.groupBox1.Controls.Add(this.txtFDate2);
			this.groupBox1.Controls.Add(this.txtFDate1);
			this.groupBox1.Controls.Add(this.button2);
			this.groupBox1.Controls.Add(this.button1);
			this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.groupBox1.Location = new System.Drawing.Point(0, 0);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(1060, 98);
			this.groupBox1.TabIndex = 0;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "过滤窗口";
			// 
			// groupBox3
			// 
			this.groupBox3.Controls.Add(this.rbByDay);
			this.groupBox3.Controls.Add(this.rbByYear);
			this.groupBox3.Controls.Add(this.rbByHour);
			this.groupBox3.Controls.Add(this.rbByMonth);
			this.groupBox3.Location = new System.Drawing.Point(7, 33);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Size = new System.Drawing.Size(200, 53);
			this.groupBox3.TabIndex = 55;
			this.groupBox3.TabStop = false;
			this.groupBox3.Text = "查询依据";
			// 
			// rbByDay
			// 
			this.rbByDay.AutoSize = true;
			this.rbByDay.Location = new System.Drawing.Point(57, 20);
			this.rbByDay.Name = "rbByDay";
			this.rbByDay.Size = new System.Drawing.Size(35, 16);
			this.rbByDay.TabIndex = 54;
			this.rbByDay.Text = "天";
			this.rbByDay.UseVisualStyleBackColor = true;
			this.rbByDay.CheckedChanged += new System.EventHandler(this.rbByDay_CheckedChanged);
			// 
			// rbByYear
			// 
			this.rbByYear.AutoSize = true;
			this.rbByYear.Location = new System.Drawing.Point(149, 20);
			this.rbByYear.Name = "rbByYear";
			this.rbByYear.Size = new System.Drawing.Size(35, 16);
			this.rbByYear.TabIndex = 54;
			this.rbByYear.Text = "年";
			this.rbByYear.UseVisualStyleBackColor = true;
			this.rbByYear.CheckedChanged += new System.EventHandler(this.rbByYear_CheckedChanged);
			// 
			// rbByHour
			// 
			this.rbByHour.AutoSize = true;
			this.rbByHour.Location = new System.Drawing.Point(11, 20);
			this.rbByHour.Name = "rbByHour";
			this.rbByHour.Size = new System.Drawing.Size(35, 16);
			this.rbByHour.TabIndex = 54;
			this.rbByHour.Text = "时";
			this.rbByHour.UseVisualStyleBackColor = true;
			this.rbByHour.CheckedChanged += new System.EventHandler(this.rbByHour_CheckedChanged);
			// 
			// rbByMonth
			// 
			this.rbByMonth.AutoSize = true;
			this.rbByMonth.Location = new System.Drawing.Point(103, 20);
			this.rbByMonth.Name = "rbByMonth";
			this.rbByMonth.Size = new System.Drawing.Size(35, 16);
			this.rbByMonth.TabIndex = 54;
			this.rbByMonth.Text = "月";
			this.rbByMonth.UseVisualStyleBackColor = true;
			this.rbByMonth.CheckedChanged += new System.EventHandler(this.rbByMonth_CheckedChanged);
			// 
			// label1
			// 
			this.label1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.label1.Location = new System.Drawing.Point(448, 48);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(29, 22);
			this.label1.TabIndex = 51;
			this.label1.Text = "至";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// lblTitle
			// 
			this.lblTitle.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.lblTitle.Location = new System.Drawing.Point(244, 48);
			this.lblTitle.Name = "lblTitle";
			this.lblTitle.Size = new System.Drawing.Size(65, 22);
			this.lblTitle.TabIndex = 50;
			this.lblTitle.Text = "查询时间";
			this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// txtFDate2
			// 
			this.txtFDate2.CustomFormat = "yyyy-MM-dd HH";
			this.txtFDate2.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			this.txtFDate2.Location = new System.Drawing.Point(475, 48);
			this.txtFDate2.Name = "txtFDate2";
			this.txtFDate2.Size = new System.Drawing.Size(140, 21);
			this.txtFDate2.TabIndex = 53;
			// 
			// txtFDate1
			// 
			this.txtFDate1.CustomFormat = "yyyy-MM-dd HH";
			this.txtFDate1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			this.txtFDate1.Location = new System.Drawing.Point(311, 48);
			this.txtFDate1.Name = "txtFDate1";
			this.txtFDate1.Size = new System.Drawing.Size(140, 21);
			this.txtFDate1.TabIndex = 52;
			// 
			// button2
			// 
			this.button2.Location = new System.Drawing.Point(707, 48);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(77, 23);
			this.button2.TabIndex = 0;
			this.button2.Tag = "导出";
			this.button2.Text = "导出";
			this.button2.UseVisualStyleBackColor = true;
			this.button2.Click += new System.EventHandler(this.button2_Click);
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(624, 48);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(77, 23);
			this.button1.TabIndex = 0;
			this.button1.Tag = "查询";
			this.button1.Text = "查询";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// dataGridView1
			// 
			this.dataGridView1.AllowUserToAddRows = false;
			this.dataGridView1.AllowUserToDeleteRows = false;
			this.dataGridView1.AutoGenerateColumns = false;
			this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column0,
            this.colFDateTime,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5,
            this.Column6,
            this.Column7,
            this.Column8,
            this.Column9,
            this.Column10,
            this.Column11,
            this.Column12,
            this.Column13,
            this.Column14,
            this.Column15,
            this.Column16,
            this.Column17});
			this.dataGridView1.DataSource = this.bdsFind;
			this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dataGridView1.Location = new System.Drawing.Point(0, 0);
			this.dataGridView1.Name = "dataGridView1";
			this.dataGridView1.ReadOnly = true;
			this.dataGridView1.RowTemplate.Height = 23;
			this.dataGridView1.Size = new System.Drawing.Size(1261, 500);
			this.dataGridView1.TabIndex = 0;
			this.dataGridView1.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dataGridView1_RowPostPaint);
			// 
			// Column0
			// 
			this.Column0.DataPropertyName = "FName";
			this.Column0.HeaderText = "排放口";
			this.Column0.Name = "Column0";
			this.Column0.ReadOnly = true;
			this.Column0.Width = 130;
			// 
			// colFDateTime
			// 
			this.colFDateTime.DataPropertyName = "FDateTime";
			dataGridViewCellStyle1.Format = "yyyy-MM-dd HH";
			dataGridViewCellStyle1.NullValue = null;
			this.colFDateTime.DefaultCellStyle = dataGridViewCellStyle1;
			this.colFDateTime.HeaderText = "时间段";
			this.colFDateTime.Name = "colFDateTime";
			this.colFDateTime.ReadOnly = true;
			// 
			// Column2
			// 
			this.Column2.DataPropertyName = "AvgSO2";
			this.Column2.HeaderText = "二氧化硫平均浓度(毫克/立方米/小时)";
			this.Column2.Name = "Column2";
			this.Column2.ReadOnly = true;
			this.Column2.Width = 140;
			// 
			// Column3
			// 
			this.Column3.DataPropertyName = "DischargeSO2";
			this.Column3.HeaderText = "二氧化硫排放量（千克/小时）";
			this.Column3.Name = "Column3";
			this.Column3.ReadOnly = true;
			this.Column3.Width = 120;
			// 
			// Column4
			// 
			this.Column4.DataPropertyName = "AvgSO2ZSND";
			this.Column4.HeaderText = "SO2折算浓度平均浓度(毫克/立方米/小时)";
			this.Column4.Name = "Column4";
			this.Column4.ReadOnly = true;
			this.Column4.Width = 145;
			// 
			// Column5
			// 
			this.Column5.DataPropertyName = "DischargeSO2ZSND";
			this.Column5.HeaderText = "SO2折算浓度排放量（千克/小时）";
			this.Column5.Name = "Column5";
			this.Column5.ReadOnly = true;
			this.Column5.Width = 140;
			// 
			// Column6
			// 
			this.Column6.DataPropertyName = "AvgNOX";
			this.Column6.HeaderText = "氮氧化物平均浓度(毫克/立方米/小时)";
			this.Column6.Name = "Column6";
			this.Column6.ReadOnly = true;
			this.Column6.Width = 140;
			// 
			// Column7
			// 
			this.Column7.DataPropertyName = "DischargeNOX";
			this.Column7.HeaderText = "氮氧化物排放量（千克/小时）";
			this.Column7.Name = "Column7";
			this.Column7.ReadOnly = true;
			this.Column7.Width = 120;
			// 
			// Column8
			// 
			this.Column8.DataPropertyName = "AvgNOXZSND";
			this.Column8.HeaderText = "NOx折算浓度平均浓度(毫克/立方米/小时)";
			this.Column8.Name = "Column8";
			this.Column8.ReadOnly = true;
			this.Column8.Width = 145;
			// 
			// Column9
			// 
			this.Column9.DataPropertyName = "DischargeNOXZSND";
			this.Column9.HeaderText = "NOx折算浓度排放量（千克/小时）";
			this.Column9.Name = "Column9";
			this.Column9.ReadOnly = true;
			this.Column9.Width = 130;
			// 
			// Column10
			// 
			this.Column10.DataPropertyName = "AvgSMOKE";
			this.Column10.HeaderText = "烟尘平均浓度(毫克/立方米/小时)";
			this.Column10.Name = "Column10";
			this.Column10.ReadOnly = true;
			this.Column10.Width = 130;
			// 
			// Column11
			// 
			this.Column11.DataPropertyName = "DischargeSMOKE";
			this.Column11.HeaderText = "烟尘排放量（千克/小时）";
			this.Column11.Name = "Column11";
			this.Column11.ReadOnly = true;
			this.Column11.Width = 130;
			// 
			// Column12
			// 
			this.Column12.DataPropertyName = "AvgSMOKEZSND";
			this.Column12.HeaderText = "烟尘折算浓度平均浓度(毫克/立方米/小时)";
			this.Column12.Name = "Column12";
			this.Column12.ReadOnly = true;
			this.Column12.Width = 150;
			// 
			// Column13
			// 
			this.Column13.DataPropertyName = "DischargeSMOKEZSND";
			this.Column13.HeaderText = "烟尘折算浓度排放量（千克/小时）";
			this.Column13.Name = "Column13";
			this.Column13.ReadOnly = true;
			this.Column13.Width = 140;
			// 
			// Column14
			// 
			this.Column14.DataPropertyName = "AvgO2";
			this.Column14.HeaderText = "含氧量平均浓度(百分比/小时)";
			this.Column14.Name = "Column14";
			this.Column14.ReadOnly = true;
			this.Column14.Width = 140;
			// 
			// Column15
			// 
			this.Column15.DataPropertyName = "AvgFlow";
			this.Column15.HeaderText = "均值流量(立方米/小时)\t";
			this.Column15.Name = "Column15";
			this.Column15.ReadOnly = true;
			this.Column15.Width = 130;
			// 
			// Column16
			// 
			this.Column16.DataPropertyName = "SumFlow";
			this.Column16.HeaderText = "累计流量(千立方米/小时)";
			this.Column16.Name = "Column16";
			this.Column16.ReadOnly = true;
			this.Column16.Width = 130;
			// 
			// Column17
			// 
			this.Column17.HeaderText = "停机时间";
			this.Column17.Name = "Column17";
			this.Column17.ReadOnly = true;
			this.Column17.Visible = false;
			// 
			// openFileDialog1
			// 
			this.openFileDialog1.FileName = "openFileDialog1";
			// 
			// frmFImportDataList
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1263, 603);
			this.Controls.Add(this.splitContainer1);
			this.Name = "frmFImportDataList";
			this.Tag = "1222";
			this.Text = "数据查询界面";
			this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
			this.Load += new System.EventHandler(this.frmFImportDataList_Load);
			this.splitContainer1.Panel1.ResumeLayout(false);
			this.splitContainer1.Panel2.ResumeLayout(false);
			this.splitContainer1.ResumeLayout(false);
			this.splitContainer2.Panel1.ResumeLayout(false);
			this.splitContainer2.Panel2.ResumeLayout(false);
			this.splitContainer2.ResumeLayout(false);
			this.groupBox2.ResumeLayout(false);
			this.groupBox1.ResumeLayout(false);
			this.groupBox3.ResumeLayout(false);
			this.groupBox3.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.bdsFind)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.SplitContainer splitContainer1;
		private System.Windows.Forms.DataGridView dataGridView1;
		private System.Windows.Forms.BindingSource bdsFind;
		private System.Windows.Forms.SplitContainer splitContainer2;
		private System.Windows.Forms.Button btnImport;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label lblTitle;
		private System.Windows.Forms.DateTimePicker txtFDate2;
		private System.Windows.Forms.DateTimePicker txtFDate1;
		private System.Windows.Forms.GroupBox groupBox3;
		private System.Windows.Forms.RadioButton rbByDay;
		private System.Windows.Forms.RadioButton rbByYear;
		private System.Windows.Forms.RadioButton rbByHour;
		private System.Windows.Forms.RadioButton rbByMonth;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.Button button3;
		private System.Windows.Forms.OpenFileDialog openFileDialog1;
		private System.Windows.Forms.DataGridViewTextBoxColumn Column0;
		private System.Windows.Forms.DataGridViewTextBoxColumn colFDateTime;
		private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
		private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
		private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
		private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
		private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
		private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
		private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
		private System.Windows.Forms.DataGridViewTextBoxColumn Column9;
		private System.Windows.Forms.DataGridViewTextBoxColumn Column10;
		private System.Windows.Forms.DataGridViewTextBoxColumn Column11;
		private System.Windows.Forms.DataGridViewTextBoxColumn Column12;
		private System.Windows.Forms.DataGridViewTextBoxColumn Column13;
		private System.Windows.Forms.DataGridViewTextBoxColumn Column14;
		private System.Windows.Forms.DataGridViewTextBoxColumn Column15;
		private System.Windows.Forms.DataGridViewTextBoxColumn Column16;
		private System.Windows.Forms.DataGridViewTextBoxColumn Column17;
	}
}