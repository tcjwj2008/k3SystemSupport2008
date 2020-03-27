namespace YXK3FZ.SP
{
	partial class FrmPriceDiff
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
			this.splitContainer1 = new System.Windows.Forms.SplitContainer();
			this.btnFind = new System.Windows.Forms.Button();
			this.label2 = new System.Windows.Forms.Label();
			this.dtToday = new System.Windows.Forms.DateTimePicker();
			this.label1 = new System.Windows.Forms.Label();
			this.dtYesterday = new System.Windows.Forms.DateTimePicker();
			this.dataGridView1 = new System.Windows.Forms.DataGridView();
			this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.bdsMaster = new System.Windows.Forms.BindingSource(this.components);
			this.splitContainer1.Panel1.SuspendLayout();
			this.splitContainer1.Panel2.SuspendLayout();
			this.splitContainer1.SuspendLayout();
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
			this.splitContainer1.Panel1.Controls.Add(this.btnFind);
			this.splitContainer1.Panel1.Controls.Add(this.label2);
			this.splitContainer1.Panel1.Controls.Add(this.dtToday);
			this.splitContainer1.Panel1.Controls.Add(this.label1);
			this.splitContainer1.Panel1.Controls.Add(this.dtYesterday);
			// 
			// splitContainer1.Panel2
			// 
			this.splitContainer1.Panel2.Controls.Add(this.dataGridView1);
			this.splitContainer1.Size = new System.Drawing.Size(977, 569);
			this.splitContainer1.SplitterDistance = 70;
			this.splitContainer1.SplitterWidth = 1;
			this.splitContainer1.TabIndex = 0;
			// 
			// btnFind
			// 
			this.btnFind.Location = new System.Drawing.Point(417, 21);
			this.btnFind.Name = "btnFind";
			this.btnFind.Size = new System.Drawing.Size(90, 26);
			this.btnFind.TabIndex = 10;
			this.btnFind.Tag = "查询";
			this.btnFind.Text = "查询";
			this.btnFind.UseVisualStyleBackColor = true;
			this.btnFind.Click += new System.EventHandler(this.btnFind_Click);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("宋体", 10F);
			this.label2.Location = new System.Drawing.Point(204, 26);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(63, 14);
			this.label2.TabIndex = 9;
			this.label2.Text = "今天日期";
			// 
			// dtToday
			// 
			this.dtToday.CustomFormat = "yyyy-MM-dd";
			this.dtToday.Font = new System.Drawing.Font("宋体", 10F);
			this.dtToday.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			this.dtToday.Location = new System.Drawing.Point(275, 22);
			this.dtToday.Name = "dtToday";
			this.dtToday.Size = new System.Drawing.Size(116, 23);
			this.dtToday.TabIndex = 8;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("宋体", 10F);
			this.label1.Location = new System.Drawing.Point(11, 26);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(63, 14);
			this.label1.TabIndex = 9;
			this.label1.Text = "昨天日期";
			// 
			// dtYesterday
			// 
			this.dtYesterday.CustomFormat = "yyyy-MM-dd";
			this.dtYesterday.Font = new System.Drawing.Font("宋体", 10F);
			this.dtYesterday.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			this.dtYesterday.Location = new System.Drawing.Point(82, 22);
			this.dtYesterday.Name = "dtYesterday";
			this.dtYesterday.Size = new System.Drawing.Size(116, 23);
			this.dtYesterday.TabIndex = 8;
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
            this.Column7,
            this.Column5,
            this.Column8,
            this.Column6});
			this.dataGridView1.DataSource = this.bdsMaster;
			this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dataGridView1.Location = new System.Drawing.Point(0, 0);
			this.dataGridView1.Name = "dataGridView1";
			this.dataGridView1.ReadOnly = true;
			this.dataGridView1.RowTemplate.Height = 23;
			this.dataGridView1.Size = new System.Drawing.Size(975, 496);
			this.dataGridView1.TabIndex = 0;
			// 
			// Column1
			// 
			this.Column1.DataPropertyName = "客户代码";
			this.Column1.HeaderText = "客户代码";
			this.Column1.Name = "Column1";
			this.Column1.ReadOnly = true;
			// 
			// Column2
			// 
			this.Column2.DataPropertyName = "客户名称";
			this.Column2.HeaderText = "客户名称";
			this.Column2.Name = "Column2";
			this.Column2.ReadOnly = true;
			// 
			// Column3
			// 
			this.Column3.DataPropertyName = "物料代码";
			this.Column3.HeaderText = "物料代码";
			this.Column3.Name = "Column3";
			this.Column3.ReadOnly = true;
			// 
			// Column4
			// 
			this.Column4.DataPropertyName = "物料名称";
			this.Column4.HeaderText = "物料名称";
			this.Column4.Name = "Column4";
			this.Column4.ReadOnly = true;
			// 
			// Column7
			// 
			this.Column7.DataPropertyName = "昨天日期";
			this.Column7.HeaderText = "昨天日期";
			this.Column7.Name = "Column7";
			this.Column7.ReadOnly = true;
			// 
			// Column5
			// 
			this.Column5.DataPropertyName = "昨天价格";
			this.Column5.HeaderText = "昨天价格";
			this.Column5.Name = "Column5";
			this.Column5.ReadOnly = true;
			// 
			// Column8
			// 
			this.Column8.DataPropertyName = "今天日期";
			this.Column8.HeaderText = "今天日期";
			this.Column8.Name = "Column8";
			this.Column8.ReadOnly = true;
			// 
			// Column6
			// 
			this.Column6.DataPropertyName = "今天价格";
			this.Column6.HeaderText = "今天价格";
			this.Column6.Name = "Column6";
			this.Column6.ReadOnly = true;
			// 
			// FrmPriceDiff
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(977, 569);
			this.Controls.Add(this.splitContainer1);
			this.Name = "FrmPriceDiff";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "价格差异N";
			this.Load += new System.EventHandler(this.FrmPriceDiff_Load);
			this.splitContainer1.Panel1.ResumeLayout(false);
			this.splitContainer1.Panel1.PerformLayout();
			this.splitContainer1.Panel2.ResumeLayout(false);
			this.splitContainer1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.bdsMaster)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.SplitContainer splitContainer1;
		private System.Windows.Forms.Button btnFind;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.DateTimePicker dtYesterday;
		private System.Windows.Forms.DataGridView dataGridView1;
		private System.Windows.Forms.BindingSource bdsMaster;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.DateTimePicker dtToday;
		private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
		private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
		private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
		private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
		private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
		private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
		private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
		private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
	}
}