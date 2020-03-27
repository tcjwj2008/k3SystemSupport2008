namespace YXK3FZ.YZGL
{
	partial class frmYZOrder10
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
					System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmYZOrder10));
					this.toolStrip1 = new System.Windows.Forms.ToolStrip();
					this.btnADD = new System.Windows.Forms.ToolStripButton();
					this.btnEdit = new System.Windows.Forms.ToolStripButton();
					this.btnSave = new System.Windows.Forms.ToolStripButton();
					this.btnConfirmer = new System.Windows.Forms.ToolStripButton();
					this.btnHConfirmer = new System.Windows.Forms.ToolStripButton();
					this.btnCheck = new System.Windows.Forms.ToolStripButton();
					this.btnHcheck = new System.Windows.Forms.ToolStripButton();
					this.btnExport = new System.Windows.Forms.ToolStripButton();
					this.btnClose = new System.Windows.Forms.ToolStripButton();
					this.panel2 = new System.Windows.Forms.Panel();
					this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
					this.label4 = new System.Windows.Forms.Label();
					this.label10 = new System.Windows.Forms.Label();
					this.label9 = new System.Windows.Forms.Label();
					this.label15 = new System.Windows.Forms.Label();
					this.label8 = new System.Windows.Forms.Label();
					this.label11 = new System.Windows.Forms.Label();
					this.label1 = new System.Windows.Forms.Label();
					this.label6 = new System.Windows.Forms.Label();
					this.label7 = new System.Windows.Forms.Label();
					this.label3 = new System.Windows.Forms.Label();
					this.label2 = new System.Windows.Forms.Label();
					this.label5 = new System.Windows.Forms.Label();
					this.label28 = new System.Windows.Forms.Label();
					this.label14 = new System.Windows.Forms.Label();
					this.label12 = new System.Windows.Forms.Label();
					this.label13 = new System.Windows.Forms.Label();
					this.label21 = new System.Windows.Forms.Label();
					this.label16 = new System.Windows.Forms.Label();
					this.cobFClassID = new System.Windows.Forms.ComboBox();
					this.cobFBoatID = new System.Windows.Forms.ComboBox();
					this.txtFDate = new System.Windows.Forms.DateTimePicker();
					this.txtFRunTimeByDay = new System.Windows.Forms.TextBox();
					this.edtFRunTimeByHour = new System.Windows.Forms.TextBox();
					this.edtFDownTimeByHour = new System.Windows.Forms.TextBox();
					this.edtFAmountOfFinish = new System.Windows.Forms.TextBox();
					this.edtFConsumptionByTon = new System.Windows.Forms.TextBox();
					this.edtFOilStoreByTon = new System.Windows.Forms.TextBox();
					this.edtFEmployeeNum = new System.Windows.Forms.TextBox();
					this.edtFIllDeviceNum = new System.Windows.Forms.TextBox();
					this.edtFServiceDevice = new System.Windows.Forms.TextBox();
					this.edtFRemark = new System.Windows.Forms.TextBox();
					this.txtFNewUser = new System.Windows.Forms.TextBox();
					this.txtFNewDate = new System.Windows.Forms.TextBox();
					this.txtFCheckUser = new System.Windows.Forms.TextBox();
					this.txtFCheckDate = new System.Windows.Forms.TextBox();
					this.txtFState = new System.Windows.Forms.TextBox();
					this.label17 = new System.Windows.Forms.Label();
					this.edtFMOilStoreByTon = new System.Windows.Forms.TextBox();
					this.label18 = new System.Windows.Forms.Label();
					this.cobFOrderClass = new System.Windows.Forms.ComboBox();
					this.toolStrip1.SuspendLayout();
					this.panel2.SuspendLayout();
					this.tableLayoutPanel1.SuspendLayout();
					this.SuspendLayout();
					// 
					// toolStrip1
					// 
					this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnADD,
            this.btnEdit,
            this.btnSave,
            this.btnConfirmer,
            this.btnHConfirmer,
            this.btnCheck,
            this.btnHcheck,
            this.btnExport,
            this.btnClose});
					this.toolStrip1.Location = new System.Drawing.Point(0, 0);
					this.toolStrip1.Name = "toolStrip1";
					this.toolStrip1.Size = new System.Drawing.Size(452, 25);
					this.toolStrip1.TabIndex = 3;
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
					// btnEdit
					// 
					this.btnEdit.Image = global::YXK3FZ.Properties.Resources.采购订单;
					this.btnEdit.ImageTransparentColor = System.Drawing.Color.Magenta;
					this.btnEdit.Name = "btnEdit";
					this.btnEdit.Size = new System.Drawing.Size(52, 22);
					this.btnEdit.Tag = "编辑";
					this.btnEdit.Text = "编辑";
					this.btnEdit.Click += new System.EventHandler(this.tsbtnEdit_Click);
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
					this.btnExport.Size = new System.Drawing.Size(52, 21);
					this.btnExport.Text = "导出";
					this.btnExport.Visible = false;
					// 
					// btnClose
					// 
					this.btnClose.Image = global::YXK3FZ.Properties.Resources.stop;
					this.btnClose.ImageTransparentColor = System.Drawing.Color.Magenta;
					this.btnClose.Name = "btnClose";
					this.btnClose.Size = new System.Drawing.Size(52, 21);
					this.btnClose.Tag = "退出";
					this.btnClose.Text = "退出";
					this.btnClose.Visible = false;
					// 
					// panel2
					// 
					this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
					this.panel2.Controls.Add(this.tableLayoutPanel1);
					this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
					this.panel2.Location = new System.Drawing.Point(0, 25);
					this.panel2.Name = "panel2";
					this.panel2.Size = new System.Drawing.Size(452, 548);
					this.panel2.TabIndex = 5;
					// 
					// tableLayoutPanel1
					// 
					this.tableLayoutPanel1.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
					this.tableLayoutPanel1.ColumnCount = 2;
					this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 140F));
					this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 421F));
					this.tableLayoutPanel1.Controls.Add(this.label4, 0, 19);
					this.tableLayoutPanel1.Controls.Add(this.label10, 0, 18);
					this.tableLayoutPanel1.Controls.Add(this.label9, 0, 15);
					this.tableLayoutPanel1.Controls.Add(this.label15, 0, 9);
					this.tableLayoutPanel1.Controls.Add(this.label8, 0, 17);
					this.tableLayoutPanel1.Controls.Add(this.label11, 0, 16);
					this.tableLayoutPanel1.Controls.Add(this.label1, 0, 6);
					this.tableLayoutPanel1.Controls.Add(this.label6, 0, 11);
					this.tableLayoutPanel1.Controls.Add(this.label7, 0, 12);
					this.tableLayoutPanel1.Controls.Add(this.label3, 0, 13);
					this.tableLayoutPanel1.Controls.Add(this.label2, 0, 7);
					this.tableLayoutPanel1.Controls.Add(this.label5, 0, 8);
					this.tableLayoutPanel1.Controls.Add(this.label28, 0, 4);
					this.tableLayoutPanel1.Controls.Add(this.label14, 0, 5);
					this.tableLayoutPanel1.Controls.Add(this.label12, 0, 0);
					this.tableLayoutPanel1.Controls.Add(this.label13, 0, 1);
					this.tableLayoutPanel1.Controls.Add(this.label21, 0, 3);
					this.tableLayoutPanel1.Controls.Add(this.label16, 0, 14);
					this.tableLayoutPanel1.Controls.Add(this.cobFClassID, 1, 0);
					this.tableLayoutPanel1.Controls.Add(this.cobFBoatID, 1, 1);
					this.tableLayoutPanel1.Controls.Add(this.txtFDate, 1, 3);
					this.tableLayoutPanel1.Controls.Add(this.txtFRunTimeByDay, 1, 4);
					this.tableLayoutPanel1.Controls.Add(this.edtFRunTimeByHour, 1, 5);
					this.tableLayoutPanel1.Controls.Add(this.edtFDownTimeByHour, 1, 6);
					this.tableLayoutPanel1.Controls.Add(this.edtFAmountOfFinish, 1, 7);
					this.tableLayoutPanel1.Controls.Add(this.edtFConsumptionByTon, 1, 8);
					this.tableLayoutPanel1.Controls.Add(this.edtFOilStoreByTon, 1, 9);
					this.tableLayoutPanel1.Controls.Add(this.edtFEmployeeNum, 1, 11);
					this.tableLayoutPanel1.Controls.Add(this.edtFIllDeviceNum, 1, 12);
					this.tableLayoutPanel1.Controls.Add(this.edtFServiceDevice, 1, 13);
					this.tableLayoutPanel1.Controls.Add(this.edtFRemark, 1, 14);
					this.tableLayoutPanel1.Controls.Add(this.txtFNewUser, 1, 15);
					this.tableLayoutPanel1.Controls.Add(this.txtFNewDate, 1, 16);
					this.tableLayoutPanel1.Controls.Add(this.txtFCheckUser, 1, 17);
					this.tableLayoutPanel1.Controls.Add(this.txtFCheckDate, 1, 18);
					this.tableLayoutPanel1.Controls.Add(this.txtFState, 1, 19);
					this.tableLayoutPanel1.Controls.Add(this.label17, 0, 10);
					this.tableLayoutPanel1.Controls.Add(this.edtFMOilStoreByTon, 1, 10);
					this.tableLayoutPanel1.Controls.Add(this.label18, 0, 2);
					this.tableLayoutPanel1.Controls.Add(this.cobFOrderClass, 1, 2);
					this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Left;
					this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
					this.tableLayoutPanel1.Name = "tableLayoutPanel1";
					this.tableLayoutPanel1.RowCount = 21;
					this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
					this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
					this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
					this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
					this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
					this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
					this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
					this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
					this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
					this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
					this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
					this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
					this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
					this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
					this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
					this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
					this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
					this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
					this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
					this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
					this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
					this.tableLayoutPanel1.Size = new System.Drawing.Size(409, 546);
					this.tableLayoutPanel1.TabIndex = 41;
					// 
					// label4
					// 
					this.label4.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
					this.label4.Location = new System.Drawing.Point(4, 495);
					this.label4.Name = "label4";
					this.label4.Size = new System.Drawing.Size(121, 22);
					this.label4.TabIndex = 34;
					this.label4.Text = "单据状态";
					this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
					// 
					// label10
					// 
					this.label10.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
					this.label10.Location = new System.Drawing.Point(4, 469);
					this.label10.Name = "label10";
					this.label10.Size = new System.Drawing.Size(121, 22);
					this.label10.TabIndex = 26;
					this.label10.Tag = " ";
					this.label10.Text = "审核日期";
					this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
					// 
					// label9
					// 
					this.label9.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
					this.label9.Location = new System.Drawing.Point(4, 391);
					this.label9.Name = "label9";
					this.label9.Size = new System.Drawing.Size(121, 22);
					this.label9.TabIndex = 24;
					this.label9.Text = "制单人";
					this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
					// 
					// label15
					// 
					this.label15.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
					this.label15.Location = new System.Drawing.Point(4, 235);
					this.label15.Name = "label15";
					this.label15.Size = new System.Drawing.Size(121, 22);
					this.label15.TabIndex = 39;
					this.label15.Text = "四级油库存量(吨)";
					this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
					// 
					// label8
					// 
					this.label8.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
					this.label8.Location = new System.Drawing.Point(4, 443);
					this.label8.Name = "label8";
					this.label8.Size = new System.Drawing.Size(121, 22);
					this.label8.TabIndex = 22;
					this.label8.Text = "审核人";
					this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
					// 
					// label11
					// 
					this.label11.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
					this.label11.Location = new System.Drawing.Point(4, 417);
					this.label11.Name = "label11";
					this.label11.Size = new System.Drawing.Size(121, 22);
					this.label11.TabIndex = 32;
					this.label11.Text = "制单日期";
					this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
					// 
					// label1
					// 
					this.label1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
					this.label1.Location = new System.Drawing.Point(4, 157);
					this.label1.Name = "label1";
					this.label1.Size = new System.Drawing.Size(121, 22);
					this.label1.TabIndex = 22;
					this.label1.Text = "停机时间(小时)";
					this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
					// 
					// label6
					// 
					this.label6.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
					this.label6.Location = new System.Drawing.Point(4, 287);
					this.label6.Name = "label6";
					this.label6.Size = new System.Drawing.Size(121, 22);
					this.label6.TabIndex = 22;
					this.label6.Text = "在岗人员(个)";
					this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
					// 
					// label7
					// 
					this.label7.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
					this.label7.Location = new System.Drawing.Point(4, 313);
					this.label7.Name = "label7";
					this.label7.Size = new System.Drawing.Size(121, 22);
					this.label7.TabIndex = 22;
					this.label7.Text = "带病运行设备(台)";
					this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
					// 
					// label3
					// 
					this.label3.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
					this.label3.Location = new System.Drawing.Point(4, 339);
					this.label3.Name = "label3";
					this.label3.Size = new System.Drawing.Size(121, 22);
					this.label3.TabIndex = 22;
					this.label3.Text = "维修设备(台)";
					this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
					// 
					// label2
					// 
					this.label2.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
					this.label2.Location = new System.Drawing.Point(4, 183);
					this.label2.Name = "label2";
					this.label2.Size = new System.Drawing.Size(121, 22);
					this.label2.TabIndex = 22;
					this.label2.Text = "四级油产量(吨)";
					this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
					// 
					// label5
					// 
					this.label5.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
					this.label5.Location = new System.Drawing.Point(4, 209);
					this.label5.Name = "label5";
					this.label5.Size = new System.Drawing.Size(121, 22);
					this.label5.TabIndex = 22;
					this.label5.Text = "四级油出库量(吨)";
					this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
					// 
					// label28
					// 
					this.label28.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
					this.label28.Location = new System.Drawing.Point(4, 105);
					this.label28.Name = "label28";
					this.label28.Size = new System.Drawing.Size(121, 22);
					this.label28.TabIndex = 22;
					this.label28.Text = "加工时间(天)";
					this.label28.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
					// 
					// label14
					// 
					this.label14.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
					this.label14.Location = new System.Drawing.Point(4, 131);
					this.label14.Name = "label14";
					this.label14.Size = new System.Drawing.Size(121, 22);
					this.label14.TabIndex = 37;
					this.label14.Text = "加工时间(小时)";
					this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
					// 
					// label12
					// 
					this.label12.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
					this.label12.Location = new System.Drawing.Point(4, 1);
					this.label12.Name = "label12";
					this.label12.Size = new System.Drawing.Size(121, 22);
					this.label12.TabIndex = 32;
					this.label12.Text = "班次";
					this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
					// 
					// label13
					// 
					this.label13.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
					this.label13.Location = new System.Drawing.Point(4, 27);
					this.label13.Name = "label13";
					this.label13.Size = new System.Drawing.Size(121, 22);
					this.label13.TabIndex = 34;
					this.label13.Text = "船次";
					this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
					// 
					// label21
					// 
					this.label21.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
					this.label21.Location = new System.Drawing.Point(4, 79);
					this.label21.Name = "label21";
					this.label21.Size = new System.Drawing.Size(121, 22);
					this.label21.TabIndex = 30;
					this.label21.Text = "加工日期";
					this.label21.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
					// 
					// label16
					// 
					this.label16.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
					this.label16.Location = new System.Drawing.Point(4, 365);
					this.label16.Name = "label16";
					this.label16.Size = new System.Drawing.Size(121, 22);
					this.label16.TabIndex = 40;
					this.label16.Text = "备注";
					this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
					// 
					// cobFClassID
					// 
					this.cobFClassID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
					this.cobFClassID.FormattingEnabled = true;
					this.cobFClassID.Location = new System.Drawing.Point(145, 4);
					this.cobFClassID.Name = "cobFClassID";
					this.cobFClassID.Size = new System.Drawing.Size(155, 20);
					this.cobFClassID.TabIndex = 41;
					// 
					// cobFBoatID
					// 
					this.cobFBoatID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
					this.cobFBoatID.FormattingEnabled = true;
					this.cobFBoatID.Location = new System.Drawing.Point(145, 30);
					this.cobFBoatID.Name = "cobFBoatID";
					this.cobFBoatID.Size = new System.Drawing.Size(155, 20);
					this.cobFBoatID.TabIndex = 42;
					// 
					// txtFDate
					// 
					this.txtFDate.CustomFormat = "yyyy-MM-dd";
					this.txtFDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
					this.txtFDate.Location = new System.Drawing.Point(145, 82);
					this.txtFDate.Name = "txtFDate";
					this.txtFDate.Size = new System.Drawing.Size(155, 21);
					this.txtFDate.TabIndex = 43;
					// 
					// txtFRunTimeByDay
					// 
					this.txtFRunTimeByDay.Location = new System.Drawing.Point(145, 108);
					this.txtFRunTimeByDay.Name = "txtFRunTimeByDay";
					this.txtFRunTimeByDay.ReadOnly = true;
					this.txtFRunTimeByDay.Size = new System.Drawing.Size(155, 21);
					this.txtFRunTimeByDay.TabIndex = 44;
					// 
					// edtFRunTimeByHour
					// 
					this.edtFRunTimeByHour.Location = new System.Drawing.Point(145, 134);
					this.edtFRunTimeByHour.Name = "edtFRunTimeByHour";
					this.edtFRunTimeByHour.Size = new System.Drawing.Size(155, 21);
					this.edtFRunTimeByHour.TabIndex = 44;
					// 
					// edtFDownTimeByHour
					// 
					this.edtFDownTimeByHour.Location = new System.Drawing.Point(145, 160);
					this.edtFDownTimeByHour.Name = "edtFDownTimeByHour";
					this.edtFDownTimeByHour.Size = new System.Drawing.Size(155, 21);
					this.edtFDownTimeByHour.TabIndex = 44;
					// 
					// edtFAmountOfFinish
					// 
					this.edtFAmountOfFinish.Location = new System.Drawing.Point(145, 186);
					this.edtFAmountOfFinish.Name = "edtFAmountOfFinish";
					this.edtFAmountOfFinish.Size = new System.Drawing.Size(155, 21);
					this.edtFAmountOfFinish.TabIndex = 44;
					// 
					// edtFConsumptionByTon
					// 
					this.edtFConsumptionByTon.Location = new System.Drawing.Point(145, 212);
					this.edtFConsumptionByTon.Name = "edtFConsumptionByTon";
					this.edtFConsumptionByTon.Size = new System.Drawing.Size(155, 21);
					this.edtFConsumptionByTon.TabIndex = 44;
					// 
					// edtFOilStoreByTon
					// 
					this.edtFOilStoreByTon.Location = new System.Drawing.Point(145, 238);
					this.edtFOilStoreByTon.Name = "edtFOilStoreByTon";
					this.edtFOilStoreByTon.Size = new System.Drawing.Size(155, 21);
					this.edtFOilStoreByTon.TabIndex = 44;
					// 
					// edtFEmployeeNum
					// 
					this.edtFEmployeeNum.Location = new System.Drawing.Point(145, 290);
					this.edtFEmployeeNum.Name = "edtFEmployeeNum";
					this.edtFEmployeeNum.Size = new System.Drawing.Size(155, 21);
					this.edtFEmployeeNum.TabIndex = 44;
					// 
					// edtFIllDeviceNum
					// 
					this.edtFIllDeviceNum.Location = new System.Drawing.Point(145, 316);
					this.edtFIllDeviceNum.Name = "edtFIllDeviceNum";
					this.edtFIllDeviceNum.Size = new System.Drawing.Size(155, 21);
					this.edtFIllDeviceNum.TabIndex = 44;
					// 
					// edtFServiceDevice
					// 
					this.edtFServiceDevice.Location = new System.Drawing.Point(145, 342);
					this.edtFServiceDevice.Name = "edtFServiceDevice";
					this.edtFServiceDevice.Size = new System.Drawing.Size(155, 21);
					this.edtFServiceDevice.TabIndex = 44;
					// 
					// edtFRemark
					// 
					this.edtFRemark.Location = new System.Drawing.Point(145, 368);
					this.edtFRemark.Name = "edtFRemark";
					this.edtFRemark.Size = new System.Drawing.Size(155, 21);
					this.edtFRemark.TabIndex = 44;
					// 
					// txtFNewUser
					// 
					this.txtFNewUser.Location = new System.Drawing.Point(145, 394);
					this.txtFNewUser.Name = "txtFNewUser";
					this.txtFNewUser.ReadOnly = true;
					this.txtFNewUser.Size = new System.Drawing.Size(155, 21);
					this.txtFNewUser.TabIndex = 44;
					// 
					// txtFNewDate
					// 
					this.txtFNewDate.Location = new System.Drawing.Point(145, 420);
					this.txtFNewDate.Name = "txtFNewDate";
					this.txtFNewDate.ReadOnly = true;
					this.txtFNewDate.Size = new System.Drawing.Size(155, 21);
					this.txtFNewDate.TabIndex = 44;
					// 
					// txtFCheckUser
					// 
					this.txtFCheckUser.Location = new System.Drawing.Point(145, 446);
					this.txtFCheckUser.Name = "txtFCheckUser";
					this.txtFCheckUser.ReadOnly = true;
					this.txtFCheckUser.Size = new System.Drawing.Size(155, 21);
					this.txtFCheckUser.TabIndex = 44;
					// 
					// txtFCheckDate
					// 
					this.txtFCheckDate.Location = new System.Drawing.Point(145, 472);
					this.txtFCheckDate.Name = "txtFCheckDate";
					this.txtFCheckDate.ReadOnly = true;
					this.txtFCheckDate.Size = new System.Drawing.Size(155, 21);
					this.txtFCheckDate.TabIndex = 44;
					// 
					// txtFState
					// 
					this.txtFState.Location = new System.Drawing.Point(145, 498);
					this.txtFState.Name = "txtFState";
					this.txtFState.ReadOnly = true;
					this.txtFState.Size = new System.Drawing.Size(155, 21);
					this.txtFState.TabIndex = 44;
					// 
					// label17
					// 
					this.label17.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
					this.label17.Location = new System.Drawing.Point(4, 261);
					this.label17.Name = "label17";
					this.label17.Size = new System.Drawing.Size(121, 22);
					this.label17.TabIndex = 45;
					this.label17.Text = "毛油库存(吨)";
					this.label17.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
					// 
					// edtFMOilStoreByTon
					// 
					this.edtFMOilStoreByTon.Location = new System.Drawing.Point(145, 264);
					this.edtFMOilStoreByTon.Name = "edtFMOilStoreByTon";
					this.edtFMOilStoreByTon.Size = new System.Drawing.Size(155, 21);
					this.edtFMOilStoreByTon.TabIndex = 44;
					// 
					// label18
					// 
					this.label18.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
					this.label18.Location = new System.Drawing.Point(4, 53);
					this.label18.Name = "label18";
					this.label18.Size = new System.Drawing.Size(121, 22);
					this.label18.TabIndex = 46;
					this.label18.Text = "是否当天最后一班";
					this.label18.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
					// 
					// cobFOrderClass
					// 
					this.cobFOrderClass.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
					this.cobFOrderClass.FormattingEnabled = true;
					this.cobFOrderClass.Location = new System.Drawing.Point(145, 56);
					this.cobFOrderClass.Name = "cobFOrderClass";
					this.cobFOrderClass.Size = new System.Drawing.Size(155, 20);
					this.cobFOrderClass.TabIndex = 47;
					// 
					// frmYZOrder10
					// 
					this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
					this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
					this.ClientSize = new System.Drawing.Size(452, 573);
					this.Controls.Add(this.panel2);
					this.Controls.Add(this.toolStrip1);
					this.Name = "frmYZOrder10";
					this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
					this.Tag = "1210";
					this.Text = "生产部--仓储--油库科--加工日历";
					this.Load += new System.EventHandler(this.frmOrder_Load);
					this.toolStrip1.ResumeLayout(false);
					this.toolStrip1.PerformLayout();
					this.panel2.ResumeLayout(false);
					this.tableLayoutPanel1.ResumeLayout(false);
					this.tableLayoutPanel1.PerformLayout();
					this.ResumeLayout(false);
					this.PerformLayout();

        }

        #endregion

				private System.Windows.Forms.ToolStrip toolStrip1;
				private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ToolStripButton btnADD;
        private System.Windows.Forms.ToolStripButton btnSave;
				private System.Windows.Forms.ToolStripButton btnConfirmer;
        private System.Windows.Forms.ToolStripButton btnCheck;
        private System.Windows.Forms.ToolStripButton btnClose;
        private System.Windows.Forms.ToolStripButton btnHConfirmer;
				private System.Windows.Forms.ToolStripButton btnHcheck;
				private System.Windows.Forms.ToolStripButton btnEdit;
				private System.Windows.Forms.ToolStripButton btnExport;
				private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
				private System.Windows.Forms.Label label4;
				private System.Windows.Forms.Label label10;
				private System.Windows.Forms.Label label9;
				private System.Windows.Forms.Label label15;
				private System.Windows.Forms.Label label8;
				private System.Windows.Forms.Label label11;
				private System.Windows.Forms.Label label1;
				private System.Windows.Forms.Label label6;
				private System.Windows.Forms.Label label7;
				private System.Windows.Forms.Label label3;
				private System.Windows.Forms.Label label2;
				private System.Windows.Forms.Label label5;
				private System.Windows.Forms.Label label28;
				private System.Windows.Forms.Label label14;
				private System.Windows.Forms.Label label12;
				private System.Windows.Forms.Label label13;
				private System.Windows.Forms.Label label21;
				private System.Windows.Forms.Label label16;
				private System.Windows.Forms.ComboBox cobFClassID;
				private System.Windows.Forms.ComboBox cobFBoatID;
				private System.Windows.Forms.DateTimePicker txtFDate;
				private System.Windows.Forms.TextBox txtFRunTimeByDay;
				private System.Windows.Forms.TextBox edtFRunTimeByHour;
				private System.Windows.Forms.TextBox edtFDownTimeByHour;
				private System.Windows.Forms.TextBox edtFAmountOfFinish;
				private System.Windows.Forms.TextBox edtFConsumptionByTon;
				private System.Windows.Forms.TextBox edtFOilStoreByTon;
				private System.Windows.Forms.TextBox edtFEmployeeNum;
				private System.Windows.Forms.TextBox edtFIllDeviceNum;
				private System.Windows.Forms.TextBox edtFServiceDevice;
				private System.Windows.Forms.TextBox edtFRemark;
				private System.Windows.Forms.TextBox txtFNewUser;
				private System.Windows.Forms.TextBox txtFNewDate;
				private System.Windows.Forms.TextBox txtFCheckUser;
				private System.Windows.Forms.TextBox txtFCheckDate;
				private System.Windows.Forms.TextBox txtFState;
				private System.Windows.Forms.Label label17;
				private System.Windows.Forms.TextBox edtFMOilStoreByTon;
				private System.Windows.Forms.Label label18;
				private System.Windows.Forms.ComboBox cobFOrderClass;
       
    }
}