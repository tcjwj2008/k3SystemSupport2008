namespace YXK3FZ.YZGL
{
	partial class frmYZPerMonthProject
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmYZPerMonthProject));
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
			this.splitContainer1 = new System.Windows.Forms.SplitContainer();
			this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			this.label14 = new System.Windows.Forms.Label();
			this.label8 = new System.Windows.Forms.Label();
			this.label9 = new System.Windows.Forms.Label();
			this.label12 = new System.Windows.Forms.Label();
			this.label10 = new System.Windows.Forms.Label();
			this.label11 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.label7 = new System.Windows.Forms.Label();
			this.edtFYear = new System.Windows.Forms.TextBox();
			this.edtFMonth = new System.Windows.Forms.TextBox();
			this.edtFMonthDay = new System.Windows.Forms.TextBox();
			this.edtFNote = new System.Windows.Forms.TextBox();
			this.edtFServicePlan = new System.Windows.Forms.TextBox();
			this.txtFServiceReal = new System.Windows.Forms.TextBox();
			this.txtFWork = new System.Windows.Forms.TextBox();
			this.edtFActivePlan = new System.Windows.Forms.TextBox();
			this.edtFActiveReal = new System.Windows.Forms.TextBox();
			this.txtFDown = new System.Windows.Forms.TextBox();
			this.edtFWorkPlan = new System.Windows.Forms.TextBox();
			this.txtFWorkReal = new System.Windows.Forms.TextBox();
			this.txtFAmount = new System.Windows.Forms.TextBox();
			this.splitContainer2 = new System.Windows.Forms.SplitContainer();
			this.dataGridView1 = new System.Windows.Forms.DataGridView();
			this.Column14 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
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
			this.bdsMaster = new System.Windows.Forms.BindingSource(this.components);
			this.button2 = new System.Windows.Forms.Button();
			this.edtFYearQ = new System.Windows.Forms.DateTimePicker();
			this.button1 = new System.Windows.Forms.Button();
			this.label13 = new System.Windows.Forms.Label();
			this.statusStrip1 = new System.Windows.Forms.StatusStrip();
			this.LabTishi = new System.Windows.Forms.ToolStripStatusLabel();
			this.toolStrip1.SuspendLayout();
			this.splitContainer1.Panel1.SuspendLayout();
			this.splitContainer1.Panel2.SuspendLayout();
			this.splitContainer1.SuspendLayout();
			this.tableLayoutPanel1.SuspendLayout();
			this.splitContainer2.Panel1.SuspendLayout();
			this.splitContainer2.Panel2.SuspendLayout();
			this.splitContainer2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.bdsMaster)).BeginInit();
			this.statusStrip1.SuspendLayout();
			this.SuspendLayout();
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
			this.toolStrip1.Size = new System.Drawing.Size(1135, 25);
			this.toolStrip1.TabIndex = 5;
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
			this.btnDelete.Visible = false;
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
			// 
			// splitContainer1
			// 
			this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
			this.splitContainer1.Location = new System.Drawing.Point(0, 25);
			this.splitContainer1.Name = "splitContainer1";
			this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
			// 
			// splitContainer1.Panel1
			// 
			this.splitContainer1.Panel1.Controls.Add(this.tableLayoutPanel1);
			// 
			// splitContainer1.Panel2
			// 
			this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
			this.splitContainer1.Size = new System.Drawing.Size(1135, 705);
			this.splitContainer1.SplitterDistance = 109;
			this.splitContainer1.SplitterWidth = 1;
			this.splitContainer1.TabIndex = 6;
			// 
			// tableLayoutPanel1
			// 
			this.tableLayoutPanel1.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
			this.tableLayoutPanel1.ColumnCount = 9;
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 331F));
			this.tableLayoutPanel1.Controls.Add(this.label14, 0, 0);
			this.tableLayoutPanel1.Controls.Add(this.label8, 0, 3);
			this.tableLayoutPanel1.Controls.Add(this.label9, 2, 3);
			this.tableLayoutPanel1.Controls.Add(this.label12, 4, 3);
			this.tableLayoutPanel1.Controls.Add(this.label10, 4, 2);
			this.tableLayoutPanel1.Controls.Add(this.label11, 4, 1);
			this.tableLayoutPanel1.Controls.Add(this.label2, 0, 1);
			this.tableLayoutPanel1.Controls.Add(this.label3, 2, 1);
			this.tableLayoutPanel1.Controls.Add(this.label5, 2, 2);
			this.tableLayoutPanel1.Controls.Add(this.label4, 0, 2);
			this.tableLayoutPanel1.Controls.Add(this.label6, 6, 0);
			this.tableLayoutPanel1.Controls.Add(this.label1, 4, 0);
			this.tableLayoutPanel1.Controls.Add(this.label7, 2, 0);
			this.tableLayoutPanel1.Controls.Add(this.edtFYear, 1, 0);
			this.tableLayoutPanel1.Controls.Add(this.edtFMonth, 3, 0);
			this.tableLayoutPanel1.Controls.Add(this.edtFMonthDay, 5, 0);
			this.tableLayoutPanel1.Controls.Add(this.edtFNote, 7, 0);
			this.tableLayoutPanel1.Controls.Add(this.edtFServicePlan, 1, 1);
			this.tableLayoutPanel1.Controls.Add(this.txtFServiceReal, 3, 1);
			this.tableLayoutPanel1.Controls.Add(this.txtFWork, 5, 1);
			this.tableLayoutPanel1.Controls.Add(this.edtFActivePlan, 1, 2);
			this.tableLayoutPanel1.Controls.Add(this.edtFActiveReal, 3, 2);
			this.tableLayoutPanel1.Controls.Add(this.txtFDown, 5, 2);
			this.tableLayoutPanel1.Controls.Add(this.edtFWorkPlan, 1, 3);
			this.tableLayoutPanel1.Controls.Add(this.txtFWorkReal, 3, 3);
			this.tableLayoutPanel1.Controls.Add(this.txtFAmount, 5, 3);
			this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			this.tableLayoutPanel1.RowCount = 5;
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
			this.tableLayoutPanel1.Size = new System.Drawing.Size(1133, 107);
			this.tableLayoutPanel1.TabIndex = 0;
			// 
			// label14
			// 
			this.label14.Dock = System.Windows.Forms.DockStyle.Fill;
			this.label14.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.label14.Location = new System.Drawing.Point(4, 1);
			this.label14.Name = "label14";
			this.label14.Size = new System.Drawing.Size(114, 25);
			this.label14.TabIndex = 35;
			this.label14.Text = "年份";
			this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label8
			// 
			this.label8.Dock = System.Windows.Forms.DockStyle.Fill;
			this.label8.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.label8.Location = new System.Drawing.Point(4, 79);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(114, 25);
			this.label8.TabIndex = 40;
			this.label8.Text = "加工计划天数";
			this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label9
			// 
			this.label9.Dock = System.Windows.Forms.DockStyle.Fill;
			this.label9.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.label9.Location = new System.Drawing.Point(246, 79);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(114, 25);
			this.label9.TabIndex = 40;
			this.label9.Text = "加工实际天数";
			this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label12
			// 
			this.label12.Dock = System.Windows.Forms.DockStyle.Fill;
			this.label12.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.label12.Location = new System.Drawing.Point(488, 79);
			this.label12.Name = "label12";
			this.label12.Size = new System.Drawing.Size(114, 25);
			this.label12.TabIndex = 41;
			this.label12.Text = "加工数量";
			this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label10
			// 
			this.label10.Dock = System.Windows.Forms.DockStyle.Fill;
			this.label10.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.label10.Location = new System.Drawing.Point(488, 53);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(114, 25);
			this.label10.TabIndex = 40;
			this.label10.Text = "停机天数";
			this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label11
			// 
			this.label11.Dock = System.Windows.Forms.DockStyle.Fill;
			this.label11.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.label11.Location = new System.Drawing.Point(488, 27);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(114, 25);
			this.label11.TabIndex = 40;
			this.label11.Text = "加工天数";
			this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label2
			// 
			this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.label2.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.label2.Location = new System.Drawing.Point(4, 27);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(114, 25);
			this.label2.TabIndex = 38;
			this.label2.Text = "维修计划天数";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label3
			// 
			this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
			this.label3.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.label3.Location = new System.Drawing.Point(246, 27);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(114, 25);
			this.label3.TabIndex = 38;
			this.label3.Text = "维修实际天数";
			this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label5
			// 
			this.label5.Dock = System.Windows.Forms.DockStyle.Fill;
			this.label5.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.label5.Location = new System.Drawing.Point(246, 53);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(114, 25);
			this.label5.TabIndex = 38;
			this.label5.Text = "活动实际天数";
			this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label4
			// 
			this.label4.Dock = System.Windows.Forms.DockStyle.Fill;
			this.label4.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.label4.Location = new System.Drawing.Point(4, 53);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(114, 25);
			this.label4.TabIndex = 38;
			this.label4.Text = "活动计划天数";
			this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label6
			// 
			this.label6.Dock = System.Windows.Forms.DockStyle.Fill;
			this.label6.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.label6.Location = new System.Drawing.Point(730, 1);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(114, 25);
			this.label6.TabIndex = 39;
			this.label6.Text = "计划备注";
			this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label1
			// 
			this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.label1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.label1.Location = new System.Drawing.Point(488, 1);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(114, 25);
			this.label1.TabIndex = 39;
			this.label1.Text = "日历天数";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label7
			// 
			this.label7.Dock = System.Windows.Forms.DockStyle.Fill;
			this.label7.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.label7.Location = new System.Drawing.Point(246, 1);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(114, 25);
			this.label7.TabIndex = 39;
			this.label7.Text = "月份";
			this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// edtFYear
			// 
			this.edtFYear.Location = new System.Drawing.Point(125, 4);
			this.edtFYear.MaxLength = 4;
			this.edtFYear.Name = "edtFYear";
			this.edtFYear.Size = new System.Drawing.Size(114, 21);
			this.edtFYear.TabIndex = 42;
			this.edtFYear.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_KeyPress);
			// 
			// edtFMonth
			// 
			this.edtFMonth.Location = new System.Drawing.Point(367, 4);
			this.edtFMonth.MaxLength = 2;
			this.edtFMonth.Name = "edtFMonth";
			this.edtFMonth.Size = new System.Drawing.Size(114, 21);
			this.edtFMonth.TabIndex = 42;
			this.edtFMonth.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_KeyPress);
			// 
			// edtFMonthDay
			// 
			this.edtFMonthDay.Location = new System.Drawing.Point(609, 4);
			this.edtFMonthDay.Name = "edtFMonthDay";
			this.edtFMonthDay.Size = new System.Drawing.Size(114, 21);
			this.edtFMonthDay.TabIndex = 42;
			// 
			// edtFNote
			// 
			this.edtFNote.Location = new System.Drawing.Point(851, 4);
			this.edtFNote.Name = "edtFNote";
			this.edtFNote.Size = new System.Drawing.Size(114, 21);
			this.edtFNote.TabIndex = 42;
			// 
			// edtFServicePlan
			// 
			this.edtFServicePlan.Location = new System.Drawing.Point(125, 30);
			this.edtFServicePlan.Name = "edtFServicePlan";
			this.edtFServicePlan.Size = new System.Drawing.Size(114, 21);
			this.edtFServicePlan.TabIndex = 42;
			// 
			// txtFServiceReal
			// 
			this.txtFServiceReal.Location = new System.Drawing.Point(367, 30);
			this.txtFServiceReal.Name = "txtFServiceReal";
			this.txtFServiceReal.ReadOnly = true;
			this.txtFServiceReal.Size = new System.Drawing.Size(114, 21);
			this.txtFServiceReal.TabIndex = 42;
			// 
			// txtFWork
			// 
			this.txtFWork.Location = new System.Drawing.Point(609, 30);
			this.txtFWork.Name = "txtFWork";
			this.txtFWork.ReadOnly = true;
			this.txtFWork.Size = new System.Drawing.Size(114, 21);
			this.txtFWork.TabIndex = 42;
			// 
			// edtFActivePlan
			// 
			this.edtFActivePlan.Location = new System.Drawing.Point(125, 56);
			this.edtFActivePlan.Name = "edtFActivePlan";
			this.edtFActivePlan.Size = new System.Drawing.Size(114, 21);
			this.edtFActivePlan.TabIndex = 42;
			// 
			// edtFActiveReal
			// 
			this.edtFActiveReal.Location = new System.Drawing.Point(367, 56);
			this.edtFActiveReal.Name = "edtFActiveReal";
			this.edtFActiveReal.Size = new System.Drawing.Size(114, 21);
			this.edtFActiveReal.TabIndex = 42;
			// 
			// txtFDown
			// 
			this.txtFDown.Location = new System.Drawing.Point(609, 56);
			this.txtFDown.Name = "txtFDown";
			this.txtFDown.ReadOnly = true;
			this.txtFDown.Size = new System.Drawing.Size(114, 21);
			this.txtFDown.TabIndex = 42;
			// 
			// edtFWorkPlan
			// 
			this.edtFWorkPlan.Location = new System.Drawing.Point(125, 82);
			this.edtFWorkPlan.Name = "edtFWorkPlan";
			this.edtFWorkPlan.Size = new System.Drawing.Size(114, 21);
			this.edtFWorkPlan.TabIndex = 42;
			// 
			// txtFWorkReal
			// 
			this.txtFWorkReal.Location = new System.Drawing.Point(367, 82);
			this.txtFWorkReal.Name = "txtFWorkReal";
			this.txtFWorkReal.ReadOnly = true;
			this.txtFWorkReal.Size = new System.Drawing.Size(114, 21);
			this.txtFWorkReal.TabIndex = 42;
			// 
			// txtFAmount
			// 
			this.txtFAmount.Location = new System.Drawing.Point(609, 82);
			this.txtFAmount.Name = "txtFAmount";
			this.txtFAmount.ReadOnly = true;
			this.txtFAmount.Size = new System.Drawing.Size(114, 21);
			this.txtFAmount.TabIndex = 42;
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
			this.splitContainer2.Panel2.Controls.Add(this.button2);
			this.splitContainer2.Panel2.Controls.Add(this.edtFYearQ);
			this.splitContainer2.Panel2.Controls.Add(this.button1);
			this.splitContainer2.Panel2.Controls.Add(this.label13);
			this.splitContainer2.Panel2.Controls.Add(this.statusStrip1);
			this.splitContainer2.Size = new System.Drawing.Size(1135, 595);
			this.splitContainer2.SplitterDistance = 465;
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
            this.Column14,
            this.Column1,
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
            this.Column13});
			this.dataGridView1.DataSource = this.bdsMaster;
			this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dataGridView1.Location = new System.Drawing.Point(0, 0);
			this.dataGridView1.Name = "dataGridView1";
			this.dataGridView1.ReadOnly = true;
			this.dataGridView1.RowTemplate.Height = 23;
			this.dataGridView1.Size = new System.Drawing.Size(1133, 463);
			this.dataGridView1.TabIndex = 0;
			this.dataGridView1.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dataGridView1_RowPostPaint);
			// 
			// Column14
			// 
			this.Column14.DataPropertyName = "FYearMonth";
			this.Column14.HeaderText = "年月份";
			this.Column14.Name = "Column14";
			this.Column14.ReadOnly = true;
			// 
			// Column1
			// 
			this.Column1.DataPropertyName = "FYear";
			this.Column1.HeaderText = "年份";
			this.Column1.Name = "Column1";
			this.Column1.ReadOnly = true;
			// 
			// Column2
			// 
			this.Column2.DataPropertyName = "FMonth";
			this.Column2.HeaderText = "月份";
			this.Column2.Name = "Column2";
			this.Column2.ReadOnly = true;
			this.Column2.Visible = false;
			// 
			// Column3
			// 
			this.Column3.DataPropertyName = "FMonthDay";
			this.Column3.HeaderText = "日历天数";
			this.Column3.Name = "Column3";
			this.Column3.ReadOnly = true;
			// 
			// Column4
			// 
			this.Column4.DataPropertyName = "FServicePlan";
			this.Column4.HeaderText = "维修计划天数";
			this.Column4.Name = "Column4";
			this.Column4.ReadOnly = true;
			// 
			// Column5
			// 
			this.Column5.DataPropertyName = "FServiceReal";
			this.Column5.HeaderText = "维修实际天数";
			this.Column5.Name = "Column5";
			this.Column5.ReadOnly = true;
			// 
			// Column6
			// 
			this.Column6.DataPropertyName = "FActivePlan";
			this.Column6.HeaderText = "活动计划天数";
			this.Column6.Name = "Column6";
			this.Column6.ReadOnly = true;
			// 
			// Column7
			// 
			this.Column7.DataPropertyName = "FActiveReal";
			this.Column7.HeaderText = "活动实际天数";
			this.Column7.Name = "Column7";
			this.Column7.ReadOnly = true;
			// 
			// Column8
			// 
			this.Column8.DataPropertyName = "FWorkPlan";
			this.Column8.HeaderText = "加工计划天数";
			this.Column8.Name = "Column8";
			this.Column8.ReadOnly = true;
			// 
			// Column9
			// 
			this.Column9.DataPropertyName = "FWorkReal";
			this.Column9.HeaderText = "加工实际天数";
			this.Column9.Name = "Column9";
			this.Column9.ReadOnly = true;
			// 
			// Column10
			// 
			this.Column10.DataPropertyName = "FDown";
			this.Column10.HeaderText = "停机天数";
			this.Column10.Name = "Column10";
			this.Column10.ReadOnly = true;
			// 
			// Column11
			// 
			this.Column11.DataPropertyName = "FWork";
			this.Column11.HeaderText = "加工天数";
			this.Column11.Name = "Column11";
			this.Column11.ReadOnly = true;
			// 
			// Column12
			// 
			this.Column12.DataPropertyName = "FAmount";
			this.Column12.HeaderText = "加工数量";
			this.Column12.Name = "Column12";
			this.Column12.ReadOnly = true;
			// 
			// Column13
			// 
			this.Column13.DataPropertyName = "FNote";
			this.Column13.HeaderText = "计划备注";
			this.Column13.Name = "Column13";
			this.Column13.ReadOnly = true;
			// 
			// bdsMaster
			// 
			this.bdsMaster.CurrentChanged += new System.EventHandler(this.bdsMaster_CurrentChanged);
			// 
			// button2
			// 
			this.button2.Location = new System.Drawing.Point(389, 40);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(77, 23);
			this.button2.TabIndex = 58;
			this.button2.Tag = "导出";
			this.button2.Text = "导出";
			this.button2.UseVisualStyleBackColor = true;
			this.button2.Click += new System.EventHandler(this.button2_Click);
			// 
			// edtFYearQ
			// 
			this.edtFYearQ.CustomFormat = "yyyy";
			this.edtFYearQ.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			this.edtFYearQ.Location = new System.Drawing.Point(137, 42);
			this.edtFYearQ.Name = "edtFYearQ";
			this.edtFYearQ.Size = new System.Drawing.Size(122, 21);
			this.edtFYearQ.TabIndex = 57;
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(294, 40);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(77, 23);
			this.button1.TabIndex = 44;
			this.button1.Tag = "查询";
			this.button1.Text = "查询";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// label13
			// 
			this.label13.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.label13.Location = new System.Drawing.Point(39, 38);
			this.label13.Name = "label13";
			this.label13.Size = new System.Drawing.Size(114, 25);
			this.label13.TabIndex = 43;
			this.label13.Text = "查询年";
			this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// statusStrip1
			// 
			this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.LabTishi});
			this.statusStrip1.Location = new System.Drawing.Point(0, 105);
			this.statusStrip1.Name = "statusStrip1";
			this.statusStrip1.Size = new System.Drawing.Size(1133, 22);
			this.statusStrip1.TabIndex = 41;
			this.statusStrip1.Text = "statusStrip1";
			// 
			// LabTishi
			// 
			this.LabTishi.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.LabTishi.Name = "LabTishi";
			this.LabTishi.Size = new System.Drawing.Size(43, 17);
			this.LabTishi.Text = "提示：";
			// 
			// frmYZPerMonthProject
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1135, 730);
			this.Controls.Add(this.splitContainer1);
			this.Controls.Add(this.toolStrip1);
			this.Name = "frmYZPerMonthProject";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Tag = "1221";
			this.Text = "每月计划列表";
			this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
			this.Load += new System.EventHandler(this.frmYZPerMonthProject_Load);
			this.toolStrip1.ResumeLayout(false);
			this.toolStrip1.PerformLayout();
			this.splitContainer1.Panel1.ResumeLayout(false);
			this.splitContainer1.Panel2.ResumeLayout(false);
			this.splitContainer1.ResumeLayout(false);
			this.tableLayoutPanel1.ResumeLayout(false);
			this.tableLayoutPanel1.PerformLayout();
			this.splitContainer2.Panel1.ResumeLayout(false);
			this.splitContainer2.Panel2.ResumeLayout(false);
			this.splitContainer2.Panel2.PerformLayout();
			this.splitContainer2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.bdsMaster)).EndInit();
			this.statusStrip1.ResumeLayout(false);
			this.statusStrip1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

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
		private System.Windows.Forms.SplitContainer splitContainer1;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
		private System.Windows.Forms.Label label14;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.SplitContainer splitContainer2;
		private System.Windows.Forms.DataGridView dataGridView1;
		private System.Windows.Forms.BindingSource bdsMaster;
		private System.Windows.Forms.Label label12;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.TextBox edtFYear;
		private System.Windows.Forms.TextBox edtFMonth;
		private System.Windows.Forms.TextBox edtFMonthDay;
		private System.Windows.Forms.TextBox edtFNote;
		private System.Windows.Forms.TextBox edtFServicePlan;
		private System.Windows.Forms.TextBox txtFServiceReal;
		private System.Windows.Forms.TextBox txtFWork;
		private System.Windows.Forms.TextBox edtFActivePlan;
		private System.Windows.Forms.TextBox edtFActiveReal;
		private System.Windows.Forms.TextBox txtFDown;
		private System.Windows.Forms.TextBox edtFWorkPlan;
		private System.Windows.Forms.TextBox txtFWorkReal;
		private System.Windows.Forms.TextBox txtFAmount;
		private System.Windows.Forms.StatusStrip statusStrip1;
		private System.Windows.Forms.ToolStripStatusLabel LabTishi;
		private System.Windows.Forms.DataGridViewTextBoxColumn Column14;
		private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
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
		private System.Windows.Forms.Label label13;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.DateTimePicker edtFYearQ;
		private System.Windows.Forms.Button button2;
	}
}