﻿namespace YXK3FZ.DZPGL
{
    partial class frmDZPOrderList
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtFbill = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtFBiller = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cbbStause = new System.Windows.Forms.ComboBox();
            this.btnSel = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtFcur = new System.Windows.Forms.TextBox();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsbtnSel = new System.Windows.Forms.ToolStripButton();
            this.tsbtnDel = new System.Windows.Forms.ToolStripButton();
            this.tsbtnEnter = new System.Windows.Forms.ToolStripButton();
            this.tsbtnFenter = new System.Windows.Forms.ToolStripButton();
            this.tsbtnCheck = new System.Windows.Forms.ToolStripButton();
            this.tsbtnFcheck = new System.Windows.Forms.ToolStripButton();
            this.btnSuaXin = new System.Windows.Forms.ToolStripButton();
            this.btnCopy = new System.Windows.Forms.ToolStripButton();
            this.tsbtnOut = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.tsbtnClose = new System.Windows.Forms.ToolStripButton();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.dgvOrderList = new System.Windows.Forms.DataGridView();
            this.cmsRight = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.查看ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.确认ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.反确认ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.审核ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.反审核ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.删除ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.刷新ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.复制ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel3 = new System.Windows.Forms.Panel();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.MyPrintDocument = new System.Drawing.Printing.PrintDocument();
            this.label7 = new System.Windows.Forms.Label();
            this.txtFSA = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrderList)).BeginInit();
            this.cmsRight.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Controls.Add(this.toolStrip1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1030, 96);
            this.panel1.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.txtFSA);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.textBox1);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.txtFbill);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.txtFBiller);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.cbbStause);
            this.groupBox1.Controls.Add(this.btnSel);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtFcur);
            this.groupBox1.Controls.Add(this.dateTimePicker2);
            this.groupBox1.Controls.Add(this.dateTimePicker1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 25);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1030, 71);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "过滤";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(150, 45);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 12);
            this.label4.TabIndex = 20;
            this.label4.Text = "车次";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(183, 40);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 21);
            this.textBox1.TabIndex = 19;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(150, 19);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(29, 12);
            this.label8.TabIndex = 16;
            this.label8.Text = "单号";
            // 
            // txtFbill
            // 
            this.txtFbill.Location = new System.Drawing.Point(183, 14);
            this.txtFbill.Name = "txtFbill";
            this.txtFbill.Size = new System.Drawing.Size(100, 21);
            this.txtFbill.TabIndex = 15;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(288, 45);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(29, 12);
            this.label6.TabIndex = 12;
            this.label6.Text = "制单";
            // 
            // txtFBiller
            // 
            this.txtFBiller.Location = new System.Drawing.Point(321, 40);
            this.txtFBiller.Name = "txtFBiller";
            this.txtFBiller.Size = new System.Drawing.Size(100, 21);
            this.txtFBiller.TabIndex = 11;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(425, 19);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 10;
            this.label5.Text = "单据状态";
            // 
            // cbbStause
            // 
            this.cbbStause.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbStause.FormattingEnabled = true;
            this.cbbStause.Items.AddRange(new object[] {
            "未审核",
            "已审核",
            "全部"});
            this.cbbStause.Location = new System.Drawing.Point(482, 14);
            this.cbbStause.Name = "cbbStause";
            this.cbbStause.Size = new System.Drawing.Size(100, 20);
            this.cbbStause.TabIndex = 9;
            // 
            // btnSel
            // 
            this.btnSel.Location = new System.Drawing.Point(714, 27);
            this.btnSel.Name = "btnSel";
            this.btnSel.Size = new System.Drawing.Size(75, 23);
            this.btnSel.TabIndex = 8;
            this.btnSel.Tag = "查询";
            this.btnSel.Text = "查询";
            this.btnSel.UseVisualStyleBackColor = true;
            this.btnSel.Click += new System.EventHandler(this.btnSel_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(288, 19);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 12);
            this.label3.TabIndex = 6;
            this.label3.Text = "客户";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(2, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 5;
            this.label2.Text = "结束日期";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(2, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 4;
            this.label1.Text = "开始日期";
            // 
            // txtFcur
            // 
            this.txtFcur.Location = new System.Drawing.Point(321, 14);
            this.txtFcur.Name = "txtFcur";
            this.txtFcur.Size = new System.Drawing.Size(100, 21);
            this.txtFcur.TabIndex = 2;
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker2.Location = new System.Drawing.Point(59, 40);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(85, 21);
            this.dateTimePicker2.TabIndex = 1;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker1.Location = new System.Drawing.Point(58, 14);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(86, 21);
            this.dateTimePicker1.TabIndex = 0;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbtnSel,
            this.tsbtnDel,
            this.tsbtnEnter,
            this.tsbtnFenter,
            this.tsbtnCheck,
            this.tsbtnFcheck,
            this.btnSuaXin,
            this.btnCopy,
            this.tsbtnOut,
            this.toolStripButton1,
            this.tsbtnClose});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1030, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tsbtnSel
            // 
            this.tsbtnSel.Image = global::YXK3FZ.Properties.Resources.报损清单;
            this.tsbtnSel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnSel.Name = "tsbtnSel";
            this.tsbtnSel.Size = new System.Drawing.Size(51, 22);
            this.tsbtnSel.Tag = "查看";
            this.tsbtnSel.Text = "查看";
            this.tsbtnSel.Click += new System.EventHandler(this.tsbtnSel_Click);
            // 
            // tsbtnDel
            // 
            this.tsbtnDel.Image = global::YXK3FZ.Properties.Resources.delete;
            this.tsbtnDel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnDel.Name = "tsbtnDel";
            this.tsbtnDel.Size = new System.Drawing.Size(51, 22);
            this.tsbtnDel.Tag = "删除";
            this.tsbtnDel.Text = "删除";
            this.tsbtnDel.Click += new System.EventHandler(this.tsbtnDel_Click);
            // 
            // tsbtnEnter
            // 
            this.tsbtnEnter.Image = global::YXK3FZ.Properties.Resources.CLAIM;
            this.tsbtnEnter.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnEnter.Name = "tsbtnEnter";
            this.tsbtnEnter.Size = new System.Drawing.Size(51, 22);
            this.tsbtnEnter.Tag = "确认";
            this.tsbtnEnter.Text = "确认";
            this.tsbtnEnter.Visible = false;
            this.tsbtnEnter.Click += new System.EventHandler(this.tsbtnEnter_Click);
            // 
            // tsbtnFenter
            // 
            this.tsbtnFenter.Image = global::YXK3FZ.Properties.Resources.UNCLAIM;
            this.tsbtnFenter.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnFenter.Name = "tsbtnFenter";
            this.tsbtnFenter.Size = new System.Drawing.Size(63, 22);
            this.tsbtnFenter.Tag = "反确认";
            this.tsbtnFenter.Text = "反确认";
            this.tsbtnFenter.Visible = false;
            this.tsbtnFenter.Click += new System.EventHandler(this.tsbtnFenter_Click);
            // 
            // tsbtnCheck
            // 
            this.tsbtnCheck.Image = global::YXK3FZ.Properties.Resources.change;
            this.tsbtnCheck.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnCheck.Name = "tsbtnCheck";
            this.tsbtnCheck.Size = new System.Drawing.Size(51, 22);
            this.tsbtnCheck.Tag = "审核";
            this.tsbtnCheck.Text = "审核";
            this.tsbtnCheck.Click += new System.EventHandler(this.tsbtnCheck_Click);
            // 
            // tsbtnFcheck
            // 
            this.tsbtnFcheck.Image = global::YXK3FZ.Properties.Resources.cancel;
            this.tsbtnFcheck.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnFcheck.Name = "tsbtnFcheck";
            this.tsbtnFcheck.Size = new System.Drawing.Size(63, 22);
            this.tsbtnFcheck.Tag = "反审核";
            this.tsbtnFcheck.Text = "反审核";
            this.tsbtnFcheck.Click += new System.EventHandler(this.tsbtnFcheck_Click);
            // 
            // btnSuaXin
            // 
            this.btnSuaXin.Image = global::YXK3FZ.Properties.Resources.export;
            this.btnSuaXin.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSuaXin.Name = "btnSuaXin";
            this.btnSuaXin.Size = new System.Drawing.Size(51, 22);
            this.btnSuaXin.Text = "刷新";
            this.btnSuaXin.Click += new System.EventHandler(this.btnSuaXin_Click);
            // 
            // btnCopy
            // 
            this.btnCopy.Image = global::YXK3FZ.Properties.Resources.类别管理;
            this.btnCopy.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnCopy.Name = "btnCopy";
            this.btnCopy.Size = new System.Drawing.Size(51, 22);
            this.btnCopy.Tag = "复制";
            this.btnCopy.Text = "复制";
            this.btnCopy.Visible = false;
            this.btnCopy.Click += new System.EventHandler(this.btnCopy_Click);
            // 
            // tsbtnOut
            // 
            this.tsbtnOut.Image = global::YXK3FZ.Properties.Resources.xitong图标;
            this.tsbtnOut.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnOut.Name = "tsbtnOut";
            this.tsbtnOut.Size = new System.Drawing.Size(51, 22);
            this.tsbtnOut.Tag = "导出";
            this.tsbtnOut.Text = "导出";
            this.tsbtnOut.Click += new System.EventHandler(this.tsbtnOut_Click);
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.Image = global::YXK3FZ.Properties.Resources.print;
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(51, 22);
            this.toolStripButton1.Tag = "打印";
            this.toolStripButton1.Text = "打印";
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // tsbtnClose
            // 
            this.tsbtnClose.Image = global::YXK3FZ.Properties.Resources.stop;
            this.tsbtnClose.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnClose.Name = "tsbtnClose";
            this.tsbtnClose.Size = new System.Drawing.Size(51, 22);
            this.tsbtnClose.Tag = "关闭";
            this.tsbtnClose.Text = "关闭";
            this.tsbtnClose.Click += new System.EventHandler(this.tsbtnClose_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.panel4);
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 96);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1030, 348);
            this.panel2.TabIndex = 1;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.dgvOrderList);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1030, 314);
            this.panel4.TabIndex = 1;
            // 
            // dgvOrderList
            // 
            this.dgvOrderList.AllowUserToAddRows = false;
            this.dgvOrderList.AllowUserToDeleteRows = false;
            this.dgvOrderList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOrderList.ContextMenuStrip = this.cmsRight;
            this.dgvOrderList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvOrderList.Location = new System.Drawing.Point(0, 0);
            this.dgvOrderList.Name = "dgvOrderList";
            this.dgvOrderList.ReadOnly = true;
            this.dgvOrderList.RowTemplate.Height = 23;
            this.dgvOrderList.Size = new System.Drawing.Size(1030, 314);
            this.dgvOrderList.TabIndex = 0;
            this.dgvOrderList.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvOrderList_CellDoubleClick);
            this.dgvOrderList.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dgvOrderList_RowPostPaint);
            this.dgvOrderList.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgvOrderList_KeyDown);
            // 
            // cmsRight
            // 
            this.cmsRight.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.查看ToolStripMenuItem,
            this.确认ToolStripMenuItem,
            this.反确认ToolStripMenuItem,
            this.审核ToolStripMenuItem,
            this.反审核ToolStripMenuItem,
            this.删除ToolStripMenuItem,
            this.刷新ToolStripMenuItem,
            this.复制ToolStripMenuItem});
            this.cmsRight.Name = "cmsRight";
            this.cmsRight.Size = new System.Drawing.Size(111, 180);
            // 
            // 查看ToolStripMenuItem
            // 
            this.查看ToolStripMenuItem.Name = "查看ToolStripMenuItem";
            this.查看ToolStripMenuItem.Size = new System.Drawing.Size(110, 22);
            this.查看ToolStripMenuItem.Text = "查看";
            this.查看ToolStripMenuItem.Click += new System.EventHandler(this.查看ToolStripMenuItem_Click);
            // 
            // 确认ToolStripMenuItem
            // 
            this.确认ToolStripMenuItem.Name = "确认ToolStripMenuItem";
            this.确认ToolStripMenuItem.Size = new System.Drawing.Size(110, 22);
            this.确认ToolStripMenuItem.Text = "确认";
            this.确认ToolStripMenuItem.Visible = false;
            this.确认ToolStripMenuItem.Click += new System.EventHandler(this.确认ToolStripMenuItem_Click);
            // 
            // 反确认ToolStripMenuItem
            // 
            this.反确认ToolStripMenuItem.Name = "反确认ToolStripMenuItem";
            this.反确认ToolStripMenuItem.Size = new System.Drawing.Size(110, 22);
            this.反确认ToolStripMenuItem.Text = "反确认";
            this.反确认ToolStripMenuItem.Visible = false;
            this.反确认ToolStripMenuItem.Click += new System.EventHandler(this.反确认ToolStripMenuItem_Click);
            // 
            // 审核ToolStripMenuItem
            // 
            this.审核ToolStripMenuItem.Name = "审核ToolStripMenuItem";
            this.审核ToolStripMenuItem.Size = new System.Drawing.Size(110, 22);
            this.审核ToolStripMenuItem.Text = "审核";
            this.审核ToolStripMenuItem.Click += new System.EventHandler(this.审核ToolStripMenuItem_Click);
            // 
            // 反审核ToolStripMenuItem
            // 
            this.反审核ToolStripMenuItem.Name = "反审核ToolStripMenuItem";
            this.反审核ToolStripMenuItem.Size = new System.Drawing.Size(110, 22);
            this.反审核ToolStripMenuItem.Text = "反审核";
            this.反审核ToolStripMenuItem.Click += new System.EventHandler(this.反审核ToolStripMenuItem_Click);
            // 
            // 删除ToolStripMenuItem
            // 
            this.删除ToolStripMenuItem.ForeColor = System.Drawing.Color.Red;
            this.删除ToolStripMenuItem.Name = "删除ToolStripMenuItem";
            this.删除ToolStripMenuItem.Size = new System.Drawing.Size(110, 22);
            this.删除ToolStripMenuItem.Text = "删除";
            this.删除ToolStripMenuItem.Click += new System.EventHandler(this.删除ToolStripMenuItem_Click);
            // 
            // 刷新ToolStripMenuItem
            // 
            this.刷新ToolStripMenuItem.Name = "刷新ToolStripMenuItem";
            this.刷新ToolStripMenuItem.Size = new System.Drawing.Size(110, 22);
            this.刷新ToolStripMenuItem.Text = "刷新";
            this.刷新ToolStripMenuItem.Click += new System.EventHandler(this.刷新ToolStripMenuItem_Click);
            // 
            // 复制ToolStripMenuItem
            // 
            this.复制ToolStripMenuItem.Name = "复制ToolStripMenuItem";
            this.复制ToolStripMenuItem.Size = new System.Drawing.Size(110, 22);
            this.复制ToolStripMenuItem.Text = "复制";
            this.复制ToolStripMenuItem.Visible = false;
            this.复制ToolStripMenuItem.Click += new System.EventHandler(this.复制ToolStripMenuItem_Click);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.statusStrip1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 314);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1030, 34);
            this.panel3.TabIndex = 0;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Location = new System.Drawing.Point(0, 12);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1030, 22);
            this.statusStrip1.TabIndex = 0;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(437, 45);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(41, 12);
            this.label7.TabIndex = 22;
            this.label7.Text = "业务员";
            // 
            // txtFSA
            // 
            this.txtFSA.Location = new System.Drawing.Point(482, 40);
            this.txtFSA.Name = "txtFSA";
            this.txtFSA.Size = new System.Drawing.Size(100, 21);
            this.txtFSA.TabIndex = 21;
            // 
            // frmDZPOrderList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1030, 444);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "frmDZPOrderList";
            this.Tag = "100";
            this.Text = "筐具出入库订单序时簿";
            this.Load += new System.EventHandler(this.frmOrderList_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrderList)).EndInit();
            this.cmsRight.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.TextBox txtFcur;
        private System.Windows.Forms.Button btnSel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStripButton tsbtnSel;
        private System.Windows.Forms.ToolStripButton tsbtnOut;
        private System.Windows.Forms.ToolStripButton tsbtnEnter;
        private System.Windows.Forms.ToolStripButton tsbtnFenter;
        private System.Windows.Forms.ToolStripButton tsbtnCheck;
        private System.Windows.Forms.ToolStripButton tsbtnFcheck;
        private System.Windows.Forms.ToolStripButton tsbtnClose;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cbbStause;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.DataGridView dgvOrderList;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripButton btnSuaXin;
        private System.Windows.Forms.ContextMenuStrip cmsRight;
        private System.Windows.Forms.ToolStripMenuItem 查看ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 确认ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 反确认ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 审核ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 反审核ToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton tsbtnDel;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Drawing.Printing.PrintDocument MyPrintDocument;
        private System.Windows.Forms.ToolStripMenuItem 删除ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 刷新ToolStripMenuItem;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtFBiller;
        private System.Windows.Forms.ToolStripButton btnCopy;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtFbill;
        private System.Windows.Forms.ToolStripMenuItem 复制ToolStripMenuItem;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtFSA;
    }
}