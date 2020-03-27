namespace YXK3FZ.SP
{
	partial class frmBTpsyeb02
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
					System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
					System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
					System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
					System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle16 = new System.Windows.Forms.DataGridViewCellStyle();
					this.groupBox1 = new System.Windows.Forms.GroupBox();
					this.btnExcel = new System.Windows.Forms.Button();
					this.btnFind = new System.Windows.Forms.Button();
					this.btnJS = new System.Windows.Forms.Button();
					this.label1 = new System.Windows.Forms.Label();
					this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
					this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
					this.dataGridView1 = new System.Windows.Forms.DataGridView();
					this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
					this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
					this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
					this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
					this.Column20 = new System.Windows.Forms.DataGridViewTextBoxColumn();
					this.Column21 = new System.Windows.Forms.DataGridViewTextBoxColumn();
					this.Column22 = new System.Windows.Forms.DataGridViewTextBoxColumn();
					this.Column23 = new System.Windows.Forms.DataGridViewTextBoxColumn();
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
					this.Column18 = new System.Windows.Forms.DataGridViewTextBoxColumn();
					this.Column19 = new System.Windows.Forms.DataGridViewTextBoxColumn();
					this.bdsMaster = new System.Windows.Forms.BindingSource(this.components);
					this.label2 = new System.Windows.Forms.Label();
					this.groupBox1.SuspendLayout();
					((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
					((System.ComponentModel.ISupportInitialize)(this.bdsMaster)).BeginInit();
					this.SuspendLayout();
					// 
					// groupBox1
					// 
					this.groupBox1.Controls.Add(this.label2);
					this.groupBox1.Controls.Add(this.btnExcel);
					this.groupBox1.Controls.Add(this.btnFind);
					this.groupBox1.Controls.Add(this.btnJS);
					this.groupBox1.Controls.Add(this.label1);
					this.groupBox1.Controls.Add(this.dateTimePicker1);
					this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
					this.groupBox1.Location = new System.Drawing.Point(0, 0);
					this.groupBox1.Name = "groupBox1";
					this.groupBox1.Size = new System.Drawing.Size(974, 59);
					this.groupBox1.TabIndex = 0;
					this.groupBox1.TabStop = false;
					// 
					// btnExcel
					// 
					this.btnExcel.Location = new System.Drawing.Point(402, 20);
					this.btnExcel.Name = "btnExcel";
					this.btnExcel.Size = new System.Drawing.Size(90, 26);
					this.btnExcel.TabIndex = 8;
					this.btnExcel.Tag = "导至EXCEL";
					this.btnExcel.Text = "导至EXCEL";
					this.btnExcel.UseVisualStyleBackColor = true;
					this.btnExcel.Click += new System.EventHandler(this.btnExcel_Click);
					// 
					// btnFind
					// 
					this.btnFind.Location = new System.Drawing.Point(311, 20);
					this.btnFind.Name = "btnFind";
					this.btnFind.Size = new System.Drawing.Size(90, 26);
					this.btnFind.TabIndex = 7;
					this.btnFind.Tag = "查询";
					this.btnFind.Text = "查询";
					this.btnFind.UseVisualStyleBackColor = true;
					this.btnFind.Click += new System.EventHandler(this.btnFind_Click);
					// 
					// btnJS
					// 
					this.btnJS.Location = new System.Drawing.Point(218, 20);
					this.btnJS.Name = "btnJS";
					this.btnJS.Size = new System.Drawing.Size(90, 26);
					this.btnJS.TabIndex = 7;
					this.btnJS.Tag = "计算";
					this.btnJS.Text = "计算";
					this.btnJS.UseVisualStyleBackColor = true;
					this.btnJS.Click += new System.EventHandler(this.btnJS_Click);
					// 
					// label1
					// 
					this.label1.AutoSize = true;
					this.label1.Font = new System.Drawing.Font("宋体", 10F);
					this.label1.Location = new System.Drawing.Point(13, 27);
					this.label1.Name = "label1";
					this.label1.Size = new System.Drawing.Size(63, 14);
					this.label1.TabIndex = 1;
					this.label1.Text = "查询日期";
					// 
					// dateTimePicker1
					// 
					this.dateTimePicker1.CustomFormat = "yyyy-MM-dd";
					this.dateTimePicker1.Font = new System.Drawing.Font("宋体", 10F);
					this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
					this.dateTimePicker1.Location = new System.Drawing.Point(84, 23);
					this.dateTimePicker1.Name = "dateTimePicker1";
					this.dateTimePicker1.Size = new System.Drawing.Size(116, 23);
					this.dateTimePicker1.TabIndex = 0;
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
            this.Column20,
            this.Column21,
            this.Column22,
            this.Column23,
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
            this.Column17,
            this.Column18,
            this.Column19});
					this.dataGridView1.DataSource = this.bdsMaster;
					this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
					this.dataGridView1.Location = new System.Drawing.Point(0, 59);
					this.dataGridView1.Name = "dataGridView1";
					this.dataGridView1.ReadOnly = true;
					this.dataGridView1.RowTemplate.Height = 23;
					this.dataGridView1.Size = new System.Drawing.Size(974, 455);
					this.dataGridView1.TabIndex = 1;
					this.dataGridView1.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dgvDetail_RowPostPaint);
					// 
					// Column1
					// 
					this.Column1.DataPropertyName = "市场";
					this.Column1.Frozen = true;
					this.Column1.HeaderText = "市场";
					this.Column1.Name = "Column1";
					this.Column1.ReadOnly = true;
					// 
					// Column2
					// 
					this.Column2.DataPropertyName = "K3代码";
					this.Column2.Frozen = true;
					this.Column2.HeaderText = "K3代码";
					this.Column2.Name = "Column2";
					this.Column2.ReadOnly = true;
					// 
					// Column3
					// 
					this.Column3.DataPropertyName = "客户名称";
					this.Column3.Frozen = true;
					this.Column3.HeaderText = "客户名称";
					this.Column3.Name = "Column3";
					this.Column3.ReadOnly = true;
					// 
					// Column4
					// 
					this.Column4.DataPropertyName = "前日累欠";
					dataGridViewCellStyle13.Format = "N2";
					dataGridViewCellStyle13.NullValue = null;
					this.Column4.DefaultCellStyle = dataGridViewCellStyle13;
					this.Column4.HeaderText = "前日累欠";
					this.Column4.Name = "Column4";
					this.Column4.ReadOnly = true;
					// 
					// Column20
					// 
					this.Column20.DataPropertyName = "当日应付";
					dataGridViewCellStyle14.Format = "N2";
					this.Column20.DefaultCellStyle = dataGridViewCellStyle14;
					this.Column20.HeaderText = "当日应付";
					this.Column20.Name = "Column20";
					this.Column20.ReadOnly = true;
					// 
					// Column21
					// 
					this.Column21.DataPropertyName = "次日配送金额";
					dataGridViewCellStyle15.Format = "N2";
					this.Column21.DefaultCellStyle = dataGridViewCellStyle15;
					this.Column21.HeaderText = "次日配送金额";
					this.Column21.Name = "Column21";
					this.Column21.ReadOnly = true;
					// 
					// Column22
					// 
					this.Column22.DataPropertyName = "信用额度";
					this.Column22.HeaderText = "信用额度";
					this.Column22.Name = "Column22";
					this.Column22.ReadOnly = true;
					// 
					// Column23
					// 
					this.Column23.DataPropertyName = "余额";
					dataGridViewCellStyle16.Format = "N2";
					this.Column23.DefaultCellStyle = dataGridViewCellStyle16;
					this.Column23.HeaderText = "余额";
					this.Column23.Name = "Column23";
					this.Column23.ReadOnly = true;
					// 
					// Column5
					// 
					this.Column5.DataPropertyName = "礼券";
					this.Column5.HeaderText = "礼券";
					this.Column5.Name = "Column5";
					this.Column5.ReadOnly = true;
					// 
					// Column6
					// 
					this.Column6.DataPropertyName = "现金收款";
					this.Column6.HeaderText = "现金收款";
					this.Column6.Name = "Column6";
					this.Column6.ReadOnly = true;
					// 
					// Column7
					// 
					this.Column7.DataPropertyName = "银行存款";
					this.Column7.HeaderText = "银行存款";
					this.Column7.Name = "Column7";
					this.Column7.ReadOnly = true;
					// 
					// Column8
					// 
					this.Column8.DataPropertyName = "[余额(不含当天销售)]";
					this.Column8.HeaderText = "[余额(不含当天销售)]";
					this.Column8.Name = "Column8";
					this.Column8.ReadOnly = true;
					this.Column8.Width = 150;
					// 
					// Column9
					// 
					this.Column9.DataPropertyName = "一级白条重量";
					this.Column9.HeaderText = "一级白条重量";
					this.Column9.Name = "Column9";
					this.Column9.ReadOnly = true;
					// 
					// Column10
					// 
					this.Column10.DataPropertyName = "一级白条金额";
					this.Column10.HeaderText = "一级白条金额";
					this.Column10.Name = "Column10";
					this.Column10.ReadOnly = true;
					// 
					// Column11
					// 
					this.Column11.DataPropertyName = "二级白条重量";
					this.Column11.HeaderText = "二级白条重量";
					this.Column11.Name = "Column11";
					this.Column11.ReadOnly = true;
					// 
					// Column12
					// 
					this.Column12.DataPropertyName = "二级白条金额";
					this.Column12.HeaderText = "二级白条金额";
					this.Column12.Name = "Column12";
					this.Column12.ReadOnly = true;
					// 
					// Column13
					// 
					this.Column13.DataPropertyName = "三级白条重量";
					this.Column13.HeaderText = "三级白条重量";
					this.Column13.Name = "Column13";
					this.Column13.ReadOnly = true;
					// 
					// Column14
					// 
					this.Column14.DataPropertyName = "三级白条金额";
					this.Column14.HeaderText = "三级白条金额";
					this.Column14.Name = "Column14";
					this.Column14.ReadOnly = true;
					// 
					// Column15
					// 
					this.Column15.DataPropertyName = "四级白条重量";
					this.Column15.HeaderText = "四级白条重量";
					this.Column15.Name = "Column15";
					this.Column15.ReadOnly = true;
					// 
					// Column16
					// 
					this.Column16.DataPropertyName = "四级白条金额";
					this.Column16.HeaderText = "四级白条金额";
					this.Column16.Name = "Column16";
					this.Column16.ReadOnly = true;
					// 
					// Column17
					// 
					this.Column17.DataPropertyName = "五级白条重量";
					this.Column17.HeaderText = "五级白条重量";
					this.Column17.Name = "Column17";
					this.Column17.ReadOnly = true;
					// 
					// Column18
					// 
					this.Column18.DataPropertyName = "五级白条金额";
					this.Column18.HeaderText = "五级白条金额";
					this.Column18.Name = "Column18";
					this.Column18.ReadOnly = true;
					// 
					// Column19
					// 
					this.Column19.DataPropertyName = "折让金额";
					this.Column19.HeaderText = "折让金额";
					this.Column19.Name = "Column19";
					this.Column19.ReadOnly = true;
					// 
					// label2
					// 
					this.label2.AutoSize = true;
					this.label2.ForeColor = System.Drawing.Color.Red;
					this.label2.Location = new System.Drawing.Point(580, 29);
					this.label2.Name = "label2";
					this.label2.Size = new System.Drawing.Size(197, 12);
					this.label2.TabIndex = 9;
					this.label2.Text = "操作说明：查询无数据时，请先计算";
					// 
					// frmBTpsyeb02
					// 
					this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
					this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
					this.ClientSize = new System.Drawing.Size(974, 514);
					this.Controls.Add(this.dataGridView1);
					this.Controls.Add(this.groupBox1);
					this.Name = "frmBTpsyeb02";
					this.Tag = "85";
					this.Text = "白条配送余额表";
					this.Load += new System.EventHandler(this.frmBTpfsk_Load);
					this.groupBox1.ResumeLayout(false);
					this.groupBox1.PerformLayout();
					((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
					((System.ComponentModel.ISupportInitialize)(this.bdsMaster)).EndInit();
					this.ResumeLayout(false);

        }

        #endregion

				private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
				private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Button btnJS;
        private System.Windows.Forms.Button btnExcel;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
				private System.Windows.Forms.DataGridView dataGridView1;
				private System.Windows.Forms.BindingSource bdsMaster;
				private System.Windows.Forms.Button btnFind;
				private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
				private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
				private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
				private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
				private System.Windows.Forms.DataGridViewTextBoxColumn Column20;
				private System.Windows.Forms.DataGridViewTextBoxColumn Column21;
				private System.Windows.Forms.DataGridViewTextBoxColumn Column22;
				private System.Windows.Forms.DataGridViewTextBoxColumn Column23;
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
				private System.Windows.Forms.DataGridViewTextBoxColumn Column18;
				private System.Windows.Forms.DataGridViewTextBoxColumn Column19;
				private System.Windows.Forms.Label label2;
    }
}