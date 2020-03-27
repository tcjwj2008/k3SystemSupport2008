namespace YXK3FZ.RYGYL
{
    partial class frm_yx_tzjh
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnSel = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.dgvMb = new System.Windows.Forms.DataGridView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.txtB6 = new System.Windows.Forms.TextBox();
            this.txtA6 = new System.Windows.Forms.TextBox();
            this.txtH3 = new System.Windows.Forms.TextBox();
            this.txtG3 = new System.Windows.Forms.TextBox();
            this.txtF3 = new System.Windows.Forms.TextBox();
            this.txtE3 = new System.Windows.Forms.TextBox();
            this.txtD3 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtA3 = new System.Windows.Forms.TextBox();
            this.txtB3 = new System.Windows.Forms.TextBox();
            this.txtC3 = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMb)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnEdit);
            this.groupBox1.Controls.Add(this.btnSave);
            this.groupBox1.Controls.Add(this.btnSel);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.dateTimePicker1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(150, 571);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "菜单";
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(12, 106);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(113, 23);
            this.btnEdit.TabIndex = 5;
            this.btnEdit.Tag = "编辑";
            this.btnEdit.Text = "编辑";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(12, 146);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(113, 23);
            this.btnSave.TabIndex = 4;
            this.btnSave.Tag = "保存";
            this.btnSave.Text = "保存";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnSel
            // 
            this.btnSel.Location = new System.Drawing.Point(12, 66);
            this.btnSel.Name = "btnSel";
            this.btnSel.Size = new System.Drawing.Size(113, 23);
            this.btnSel.TabIndex = 2;
            this.btnSel.Tag = "查询";
            this.btnSel.Text = "查询";
            this.btnSel.UseVisualStyleBackColor = true;
            this.btnSel.Click += new System.EventHandler(this.btnSel_Click_1);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(2, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "日期:";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.CustomFormat = "yyyy-mm-dd";
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker1.Location = new System.Drawing.Point(40, 20);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(103, 21);
            this.dateTimePicker1.TabIndex = 0;
            this.dateTimePicker1.ValueChanged += new System.EventHandler(this.dateTimePicker1_ValueChanged);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.groupBox3);
            this.panel1.Controls.Add(this.groupBox2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(150, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(874, 571);
            this.panel1.TabIndex = 1;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.dgvMb);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Location = new System.Drawing.Point(0, 106);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(874, 465);
            this.groupBox3.TabIndex = 1;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "前日暂存";
            // 
            // dgvMb
            // 
            this.dgvMb.AllowUserToAddRows = false;
            this.dgvMb.AllowUserToDeleteRows = false;
            this.dgvMb.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMb.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvMb.Location = new System.Drawing.Point(3, 17);
            this.dgvMb.Name = "dgvMb";
            this.dgvMb.RowTemplate.Height = 23;
            this.dgvMb.Size = new System.Drawing.Size(868, 445);
            this.dgvMb.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.tableLayoutPanel1);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox2.Location = new System.Drawing.Point(0, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(874, 106);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "计划";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanel1.ColumnCount = 10;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.Controls.Add(this.txtB6, 9, 2);
            this.tableLayoutPanel1.Controls.Add(this.txtA6, 8, 2);
            this.tableLayoutPanel1.Controls.Add(this.txtH3, 7, 2);
            this.tableLayoutPanel1.Controls.Add(this.txtG3, 6, 2);
            this.tableLayoutPanel1.Controls.Add(this.txtF3, 5, 2);
            this.tableLayoutPanel1.Controls.Add(this.txtE3, 4, 2);
            this.tableLayoutPanel1.Controls.Add(this.txtD3, 3, 2);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label4, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.label5, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.txtA3, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.txtB3, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.txtC3, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.label6, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.label7, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.label8, 4, 1);
            this.tableLayoutPanel1.Controls.Add(this.label9, 5, 1);
            this.tableLayoutPanel1.Controls.Add(this.label10, 6, 1);
            this.tableLayoutPanel1.Controls.Add(this.label11, 7, 0);
            this.tableLayoutPanel1.Controls.Add(this.label12, 8, 0);
            this.tableLayoutPanel1.Controls.Add(this.label13, 9, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 17);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(868, 86);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // txtB6
            // 
            this.txtB6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtB6.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtB6.Location = new System.Drawing.Point(778, 60);
            this.txtB6.Name = "txtB6";
            this.txtB6.Size = new System.Drawing.Size(86, 23);
            this.txtB6.TabIndex = 21;
            this.txtB6.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtA6
            // 
            this.txtA6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtA6.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtA6.Location = new System.Drawing.Point(692, 60);
            this.txtA6.Name = "txtA6";
            this.txtA6.Size = new System.Drawing.Size(79, 23);
            this.txtA6.TabIndex = 20;
            this.txtA6.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtH3
            // 
            this.txtH3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtH3.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtH3.Location = new System.Drawing.Point(606, 60);
            this.txtH3.Name = "txtH3";
            this.txtH3.Size = new System.Drawing.Size(79, 23);
            this.txtH3.TabIndex = 19;
            this.txtH3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtG3
            // 
            this.txtG3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtG3.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtG3.Location = new System.Drawing.Point(520, 60);
            this.txtG3.Name = "txtG3";
            this.txtG3.ReadOnly = true;
            this.txtG3.Size = new System.Drawing.Size(79, 23);
            this.txtG3.TabIndex = 18;
            this.txtG3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtF3
            // 
            this.txtF3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtF3.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtF3.Location = new System.Drawing.Point(434, 60);
            this.txtF3.Name = "txtF3";
            this.txtF3.ReadOnly = true;
            this.txtF3.Size = new System.Drawing.Size(79, 23);
            this.txtF3.TabIndex = 17;
            this.txtF3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtE3
            // 
            this.txtE3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtE3.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtE3.Location = new System.Drawing.Point(348, 60);
            this.txtE3.Name = "txtE3";
            this.txtE3.Size = new System.Drawing.Size(79, 23);
            this.txtE3.TabIndex = 16;
            this.txtE3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtD3
            // 
            this.txtD3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtD3.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtD3.Location = new System.Drawing.Point(262, 60);
            this.txtD3.Name = "txtD3";
            this.txtD3.Size = new System.Drawing.Size(79, 23);
            this.txtD3.TabIndex = 15;
            this.txtD3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.label2, 3);
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Location = new System.Drawing.Point(4, 1);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(251, 27);
            this.label2.TabIndex = 0;
            this.label2.Text = "华南办事处、华东办事处订单量（头）";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Location = new System.Drawing.Point(4, 29);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 27);
            this.label3.TabIndex = 1;
            this.label3.Text = "昨日预留冷量";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label4.Location = new System.Drawing.Point(90, 29);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(79, 27);
            this.label4.TabIndex = 2;
            this.label4.Text = "今日白条量";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label5.Location = new System.Drawing.Point(176, 29);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(79, 27);
            this.label5.TabIndex = 3;
            this.label5.Text = "今日预留冷分割";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtA3
            // 
            this.txtA3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtA3.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtA3.Location = new System.Drawing.Point(4, 60);
            this.txtA3.Name = "txtA3";
            this.txtA3.Size = new System.Drawing.Size(79, 23);
            this.txtA3.TabIndex = 4;
            this.txtA3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtB3
            // 
            this.txtB3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtB3.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtB3.Location = new System.Drawing.Point(90, 60);
            this.txtB3.Name = "txtB3";
            this.txtB3.Size = new System.Drawing.Size(79, 23);
            this.txtB3.TabIndex = 5;
            this.txtB3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtC3
            // 
            this.txtC3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtC3.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtC3.Location = new System.Drawing.Point(176, 60);
            this.txtC3.Name = "txtC3";
            this.txtC3.Size = new System.Drawing.Size(79, 23);
            this.txtC3.TabIndex = 6;
            this.txtC3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.label6, 4);
            this.label6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label6.Location = new System.Drawing.Point(262, 1);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(337, 27);
            this.label6.TabIndex = 7;
            this.label6.Text = "厦门办事处、福州办事处订单量（头）";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label7.Location = new System.Drawing.Point(262, 29);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(79, 27);
            this.label7.TabIndex = 8;
            this.label7.Text = "昨日预留量";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label8.Location = new System.Drawing.Point(348, 29);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(79, 27);
            this.label8.TabIndex = 9;
            this.label8.Text = "今日预留冷分割";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label9.Location = new System.Drawing.Point(434, 29);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(79, 27);
            this.label9.TabIndex = 10;
            this.label9.Text = "今日白条";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label10.Location = new System.Drawing.Point(520, 29);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(79, 27);
            this.label10.TabIndex = 11;
            this.label10.Text = "今日分割量";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label11.Location = new System.Drawing.Point(606, 1);
            this.label11.Name = "label11";
            this.tableLayoutPanel1.SetRowSpan(this.label11, 2);
            this.label11.Size = new System.Drawing.Size(79, 55);
            this.label11.TabIndex = 12;
            this.label11.Text = "今日生猪采购量";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label12.Location = new System.Drawing.Point(692, 1);
            this.label12.Name = "label12";
            this.tableLayoutPanel1.SetRowSpan(this.label12, 2);
            this.label12.Size = new System.Drawing.Size(79, 55);
            this.label12.TabIndex = 13;
            this.label12.Text = "一部头数";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label13.Location = new System.Drawing.Point(778, 1);
            this.label13.Name = "label13";
            this.tableLayoutPanel1.SetRowSpan(this.label13, 2);
            this.label13.Size = new System.Drawing.Size(86, 55);
            this.label13.TabIndex = 14;
            this.label13.Text = "生白头数";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // frm_yx_tzjh
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1024, 571);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.groupBox1);
            this.Name = "frm_yx_tzjh";
            this.Tag = "95";
            this.Text = "屠宰计划";
            this.Load += new System.EventHandler(this.frm_yx_tzjh_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMb)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.DataGridView dgvMb;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnSel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtA3;
        private System.Windows.Forms.TextBox txtB3;
        private System.Windows.Forms.TextBox txtC3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtB6;
        private System.Windows.Forms.TextBox txtA6;
        private System.Windows.Forms.TextBox txtH3;
        private System.Windows.Forms.TextBox txtG3;
        private System.Windows.Forms.TextBox txtF3;
        private System.Windows.Forms.TextBox txtE3;
        private System.Windows.Forms.TextBox txtD3;
        private System.Windows.Forms.Button btnEdit;

    }
}