namespace YXK3FZ.SO
{
    partial class frmSeorderPlanEdit
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSeorderPlanEdit));
            this.groupbox1 = new System.Windows.Forms.GroupBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.ColumnFitemID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnFitemNnmber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnFitemName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnFmodel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnFKUnitID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnFKUnitName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnFFUnitName = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.ColumnFSecCoefficient = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnFPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnFSkQty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnFSFQty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnFSAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.label14 = new System.Windows.Forms.Label();
            this.txtFnote = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtFCustAdder = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.txtFEmpNumber = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtFCustName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtFbillno = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.txtFCustNumber = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label13 = new System.Windows.Forms.Label();
            this.txtICCredit = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txtSumFamout = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtFdate = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtFcheckdate = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtFBillerName = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtFcheckName = new System.Windows.Forms.TextBox();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnSave = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton3 = new System.Windows.Forms.ToolStripButton();
            this.cms_right = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.groupbox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupbox1
            // 
            this.groupbox1.Controls.Add(this.dataGridView1);
            this.groupbox1.Controls.Add(this.groupBox3);
            this.groupbox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupbox1.Location = new System.Drawing.Point(0, 0);
            this.groupbox1.Name = "groupbox1";
            this.groupbox1.Size = new System.Drawing.Size(1104, 593);
            this.groupbox1.TabIndex = 0;
            this.groupbox1.TabStop = false;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnFitemID,
            this.ColumnFitemNnmber,
            this.ColumnFitemName,
            this.ColumnFmodel,
            this.ColumnFKUnitID,
            this.ColumnFKUnitName,
            this.ColumnFFUnitName,
            this.ColumnFSecCoefficient,
            this.ColumnFPrice,
            this.ColumnFSkQty,
            this.ColumnFSFQty,
            this.ColumnFSAmount});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.ControlLightLight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(3, 168);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(1098, 422);
            this.dataGridView1.TabIndex = 9;
            this.dataGridView1.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellValueChanged);
            this.dataGridView1.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellDoubleClick);
            this.dataGridView1.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dataGridView1_RowPostPaint);
            this.dataGridView1.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dataGridView1_EditingControlShowing);
            // 
            // ColumnFitemID
            // 
            this.ColumnFitemID.HeaderText = "产品内码";
            this.ColumnFitemID.Name = "ColumnFitemID";
            this.ColumnFitemID.Visible = false;
            // 
            // ColumnFitemNnmber
            // 
            this.ColumnFitemNnmber.HeaderText = "产品代码";
            this.ColumnFitemNnmber.Name = "ColumnFitemNnmber";
            // 
            // ColumnFitemName
            // 
            this.ColumnFitemName.HeaderText = "产品名称";
            this.ColumnFitemName.Name = "ColumnFitemName";
            this.ColumnFitemName.ReadOnly = true;
            // 
            // ColumnFmodel
            // 
            this.ColumnFmodel.HeaderText = "规格型号";
            this.ColumnFmodel.Name = "ColumnFmodel";
            this.ColumnFmodel.ReadOnly = true;
            // 
            // ColumnFKUnitID
            // 
            this.ColumnFKUnitID.HeaderText = "K3单位内码";
            this.ColumnFKUnitID.Name = "ColumnFKUnitID";
            this.ColumnFKUnitID.ReadOnly = true;
            this.ColumnFKUnitID.Visible = false;
            // 
            // ColumnFKUnitName
            // 
            this.ColumnFKUnitName.HeaderText = "K3单位";
            this.ColumnFKUnitName.Name = "ColumnFKUnitName";
            this.ColumnFKUnitName.ReadOnly = true;
            // 
            // ColumnFFUnitName
            // 
            this.ColumnFFUnitName.HeaderText = "辅助单位";
            this.ColumnFFUnitName.Items.AddRange(new object[] {
            "公斤",
            "头"});
            this.ColumnFFUnitName.Name = "ColumnFFUnitName";
            this.ColumnFFUnitName.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ColumnFFUnitName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // ColumnFSecCoefficient
            // 
            this.ColumnFSecCoefficient.HeaderText = "换算率";
            this.ColumnFSecCoefficient.Name = "ColumnFSecCoefficient";
            this.ColumnFSecCoefficient.ReadOnly = true;
            this.ColumnFSecCoefficient.Visible = false;
            // 
            // ColumnFPrice
            // 
            this.ColumnFPrice.HeaderText = "单价";
            this.ColumnFPrice.Name = "ColumnFPrice";
            this.ColumnFPrice.ReadOnly = true;
            // 
            // ColumnFSkQty
            // 
            this.ColumnFSkQty.HeaderText = "计划重量";
            this.ColumnFSkQty.Name = "ColumnFSkQty";
            // 
            // ColumnFSFQty
            // 
            this.ColumnFSFQty.HeaderText = "辅助重量";
            this.ColumnFSFQty.Name = "ColumnFSFQty";
            // 
            // ColumnFSAmount
            // 
            this.ColumnFSAmount.HeaderText = "计划销售金额";
            this.ColumnFSAmount.Name = "ColumnFSAmount";
            this.ColumnFSAmount.ReadOnly = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.textBox2);
            this.groupBox3.Controls.Add(this.textBox1);
            this.groupBox3.Controls.Add(this.label16);
            this.groupBox3.Controls.Add(this.label15);
            this.groupBox3.Controls.Add(this.dateTimePicker1);
            this.groupBox3.Controls.Add(this.label14);
            this.groupBox3.Controls.Add(this.txtFnote);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.txtFCustAdder);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.button2);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.txtFEmpNumber);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.txtFCustName);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.txtFbillno);
            this.groupBox3.Controls.Add(this.button1);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.txtFCustNumber);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox3.Location = new System.Drawing.Point(3, 17);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(1098, 151);
            this.groupBox3.TabIndex = 8;
            this.groupBox3.TabStop = false;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(630, 99);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(319, 21);
            this.textBox2.TabIndex = 36;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(320, 99);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(228, 21);
            this.textBox1.TabIndex = 35;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label16.Location = new System.Drawing.Point(554, 105);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(70, 14);
            this.label16.TabIndex = 34;
            this.label16.Text = "配送要求:";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label15.Location = new System.Drawing.Point(246, 103);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(70, 14);
            this.label15.TabIndex = 33;
            this.label15.Text = "配送性质:";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker1.Location = new System.Drawing.Point(78, 99);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(162, 21);
            this.dateTimePicker1.TabIndex = 32;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label14.Location = new System.Drawing.Point(9, 103);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(70, 14);
            this.label14.TabIndex = 31;
            this.label14.Text = "到货时间:";
            // 
            // txtFnote
            // 
            this.txtFnote.Location = new System.Drawing.Point(292, 125);
            this.txtFnote.Name = "txtFnote";
            this.txtFnote.Size = new System.Drawing.Size(657, 21);
            this.txtFnote.TabIndex = 3;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label7.Location = new System.Drawing.Point(244, 127);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(42, 14);
            this.label7.TabIndex = 13;
            this.label7.Text = "备注:";
            // 
            // txtFCustAdder
            // 
            this.txtFCustAdder.Location = new System.Drawing.Point(630, 73);
            this.txtFCustAdder.Name = "txtFCustAdder";
            this.txtFCustAdder.ReadOnly = true;
            this.txtFCustAdder.Size = new System.Drawing.Size(320, 21);
            this.txtFCustAdder.TabIndex = 12;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.Location = new System.Drawing.Point(554, 78);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(70, 14);
            this.label6.TabIndex = 11;
            this.label6.Text = "客户地址:";
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("宋体", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button2.Location = new System.Drawing.Point(186, 124);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(29, 23);
            this.button2.TabIndex = 10;
            this.button2.Text = ">>";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(23, 127);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(56, 14);
            this.label5.TabIndex = 8;
            this.label5.Text = "业务员:";
            // 
            // txtFEmpNumber
            // 
            this.txtFEmpNumber.Location = new System.Drawing.Point(78, 125);
            this.txtFEmpNumber.Name = "txtFEmpNumber";
            this.txtFEmpNumber.Size = new System.Drawing.Size(109, 21);
            this.txtFEmpNumber.TabIndex = 2;
            this.txtFEmpNumber.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtFEmpNumber_KeyPress);
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label1.Location = new System.Drawing.Point(3, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(1092, 36);
            this.label1.TabIndex = 0;
            this.label1.Text = "销售计划单";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtFCustName
            // 
            this.txtFCustName.Location = new System.Drawing.Point(320, 73);
            this.txtFCustName.Name = "txtFCustName";
            this.txtFCustName.ReadOnly = true;
            this.txtFCustName.Size = new System.Drawing.Size(228, 21);
            this.txtFCustName.TabIndex = 7;
            this.txtFCustName.TextChanged += new System.EventHandler(this.txtFCustName_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(9, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 14);
            this.label2.TabIndex = 1;
            this.label2.Text = "单据编号:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(244, 78);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(70, 14);
            this.label4.TabIndex = 6;
            this.label4.Text = "客户名称:";
            // 
            // txtFbillno
            // 
            this.txtFbillno.Location = new System.Drawing.Point(78, 55);
            this.txtFbillno.Name = "txtFbillno";
            this.txtFbillno.ReadOnly = true;
            this.txtFbillno.Size = new System.Drawing.Size(109, 21);
            this.txtFbillno.TabIndex = 30;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("宋体", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button1.Location = new System.Drawing.Point(203, 77);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(29, 23);
            this.button1.TabIndex = 5;
            this.button1.Text = ">>";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(9, 82);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 14);
            this.label3.TabIndex = 3;
            this.label3.Text = "客户代码:";
            // 
            // txtFCustNumber
            // 
            this.txtFCustNumber.Location = new System.Drawing.Point(78, 77);
            this.txtFCustNumber.Name = "txtFCustNumber";
            this.txtFCustNumber.Size = new System.Drawing.Size(125, 21);
            this.txtFCustNumber.TabIndex = 1;
            this.txtFCustNumber.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtFCustNumber_KeyPress);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label13);
            this.groupBox2.Controls.Add(this.txtICCredit);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.txtSumFamout);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.txtFdate);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.txtFcheckdate);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.txtFBillerName);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.txtFcheckName);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox2.Location = new System.Drawing.Point(0, 477);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1104, 116);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label13.Location = new System.Drawing.Point(12, 19);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(98, 14);
            this.label13.TabIndex = 20;
            this.label13.Text = "当前信用额度:";
            // 
            // txtICCredit
            // 
            this.txtICCredit.Location = new System.Drawing.Point(115, 14);
            this.txtICCredit.Name = "txtICCredit";
            this.txtICCredit.ReadOnly = true;
            this.txtICCredit.Size = new System.Drawing.Size(109, 21);
            this.txtICCredit.TabIndex = 19;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label12.Location = new System.Drawing.Point(306, 19);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(126, 14);
            this.label12.TabIndex = 18;
            this.label12.Text = "销售计划金额合计:";
            // 
            // txtSumFamout
            // 
            this.txtSumFamout.Location = new System.Drawing.Point(438, 14);
            this.txtSumFamout.Name = "txtSumFamout";
            this.txtSumFamout.ReadOnly = true;
            this.txtSumFamout.Size = new System.Drawing.Size(109, 21);
            this.txtSumFamout.TabIndex = 17;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label11.Location = new System.Drawing.Point(571, 64);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(70, 14);
            this.label11.TabIndex = 16;
            this.label11.Text = "制单日期:";
            // 
            // txtFdate
            // 
            this.txtFdate.Location = new System.Drawing.Point(647, 59);
            this.txtFdate.Name = "txtFdate";
            this.txtFdate.ReadOnly = true;
            this.txtFdate.Size = new System.Drawing.Size(109, 21);
            this.txtFdate.TabIndex = 15;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label10.Location = new System.Drawing.Point(192, 64);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(70, 14);
            this.label10.TabIndex = 14;
            this.label10.Text = "审核日期:";
            // 
            // txtFcheckdate
            // 
            this.txtFcheckdate.Location = new System.Drawing.Point(267, 59);
            this.txtFcheckdate.Name = "txtFcheckdate";
            this.txtFcheckdate.ReadOnly = true;
            this.txtFcheckdate.Size = new System.Drawing.Size(109, 21);
            this.txtFcheckdate.TabIndex = 13;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label9.Location = new System.Drawing.Point(389, 64);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(56, 14);
            this.label9.TabIndex = 12;
            this.label9.Text = "制单人:";
            // 
            // txtFBillerName
            // 
            this.txtFBillerName.Location = new System.Drawing.Point(448, 59);
            this.txtFBillerName.Name = "txtFBillerName";
            this.txtFBillerName.ReadOnly = true;
            this.txtFBillerName.Size = new System.Drawing.Size(109, 21);
            this.txtFBillerName.TabIndex = 11;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label8.Location = new System.Drawing.Point(6, 64);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(56, 14);
            this.label8.TabIndex = 10;
            this.label8.Text = "审核人:";
            // 
            // txtFcheckName
            // 
            this.txtFcheckName.Location = new System.Drawing.Point(68, 59);
            this.txtFcheckName.Name = "txtFcheckName";
            this.txtFcheckName.ReadOnly = true;
            this.txtFcheckName.Size = new System.Drawing.Size(109, 21);
            this.txtFcheckName.TabIndex = 9;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnSave,
            this.toolStripButton2,
            this.toolStripButton3});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1104, 25);
            this.toolStrip1.TabIndex = 4;
            // 
            // btnSave
            // 
            this.btnSave.Image = global::YXK3FZ.Properties.Resources.save;
            this.btnSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(51, 22);
            this.btnSave.Tag = "保存";
            this.btnSave.Text = "保存";
            this.btnSave.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.Image = global::YXK3FZ.Properties.Resources.stop;
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(51, 22);
            this.toolStripButton2.Text = "关闭";
            // 
            // toolStripButton3
            // 
            this.toolStripButton3.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton3.Image")));
            this.toolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton3.Name = "toolStripButton3";
            this.toolStripButton3.Size = new System.Drawing.Size(51, 22);
            this.toolStripButton3.Tag = "审核";
            this.toolStripButton3.Text = "审核";
            // 
            // cms_right
            // 
            this.cms_right.Name = "cms_right";
            this.cms_right.Size = new System.Drawing.Size(153, 26);
           
            // 
            // frmSeorderPlanEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1104, 593);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupbox1);
            this.Name = "frmSeorderPlanEdit";
            this.Text = "frmSeorderPlanEdit";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmSeorderPlanEdit_Load);
            this.groupbox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupbox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtFbillno;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox txtFnote;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtSumFamout;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtFdate;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtFcheckdate;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtFBillerName;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtFcheckName;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtICCredit;
        private System.Windows.Forms.ToolStripButton btnSave;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        public System.Windows.Forms.TextBox txtFCustNumber;
        public System.Windows.Forms.TextBox txtFCustName;
        public System.Windows.Forms.DataGridView dataGridView1;
        public System.Windows.Forms.TextBox txtFCustAdder;
        public System.Windows.Forms.TextBox txtFEmpNumber;
        private System.Windows.Forms.ToolStripButton toolStripButton3;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnFitemID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnFitemNnmber;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnFitemName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnFmodel;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnFKUnitID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnFKUnitName;
        private System.Windows.Forms.DataGridViewComboBoxColumn ColumnFFUnitName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnFSecCoefficient;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnFPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnFSkQty;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnFSFQty;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnFSAmount;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label label14;
        public System.Windows.Forms.TextBox textBox2;
        public System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.ContextMenuStrip cms_right;
    }
}