namespace YXK3FZ.SY
{
    partial class FormAssignRight
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormAssignRight));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolSave = new System.Windows.Forms.ToolStripButton();
            this.toolExit = new System.Windows.Forms.ToolStripButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.tvModule = new System.Windows.Forms.TreeView();
            this.panel2 = new System.Windows.Forms.Panel();
            this.tvOperator = new System.Windows.Forms.TreeView();
            this.dgvINRightInfo = new System.Windows.Forms.DataGridView();
            this.UserID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Moduleid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RightTag = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IsRight = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.bsINRight = new System.Windows.Forms.BindingSource(this.components);
            this.toolStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvINRightInfo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsINRight)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolSave,
            this.toolExit});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(707, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolSave
            // 
            this.toolSave.Image = ((System.Drawing.Image)(resources.GetObject("toolSave.Image")));
            this.toolSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolSave.Name = "toolSave";
            this.toolSave.Size = new System.Drawing.Size(52, 22);
            this.toolSave.Text = "保存";
            this.toolSave.Click += new System.EventHandler(this.toolSave_Click);
            // 
            // toolExit
            // 
            this.toolExit.Image = global::YXK3FZ.Properties.Resources.stop;
            this.toolExit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolExit.Name = "toolExit";
            this.toolExit.Size = new System.Drawing.Size(52, 22);
            this.toolExit.Text = "退出";
            this.toolExit.Click += new System.EventHandler(this.toolExit_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 25);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(437, 326);
            this.panel1.TabIndex = 1;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.tvModule);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(139, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(298, 326);
            this.panel3.TabIndex = 1;
            // 
            // tvModule
            // 
            this.tvModule.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvModule.Location = new System.Drawing.Point(0, 0);
            this.tvModule.Name = "tvModule";
            this.tvModule.Size = new System.Drawing.Size(298, 326);
            this.tvModule.TabIndex = 0;
            this.tvModule.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvModule_AfterSelect);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.tvOperator);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(139, 326);
            this.panel2.TabIndex = 0;
            // 
            // tvOperator
            // 
            this.tvOperator.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvOperator.Location = new System.Drawing.Point(0, 0);
            this.tvOperator.Name = "tvOperator";
            this.tvOperator.Size = new System.Drawing.Size(139, 326);
            this.tvOperator.TabIndex = 0;
            this.tvOperator.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvOperator_AfterSelect);
            // 
            // dgvINRightInfo
            // 
            this.dgvINRightInfo.AllowUserToAddRows = false;
            this.dgvINRightInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvINRightInfo.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.UserID,
            this.Moduleid,
            this.RightTag,
            this.IsRight});
            this.dgvINRightInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvINRightInfo.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dgvINRightInfo.Location = new System.Drawing.Point(437, 25);
            this.dgvINRightInfo.Name = "dgvINRightInfo";
            this.dgvINRightInfo.RowTemplate.Height = 23;
            this.dgvINRightInfo.Size = new System.Drawing.Size(270, 326);
            this.dgvINRightInfo.TabIndex = 2;
            // 
            // UserID
            // 
            this.UserID.DataPropertyName = "UserID";
            this.UserID.HeaderText = "UserID";
            this.UserID.Name = "UserID";
            this.UserID.Visible = false;
            // 
            // Moduleid
            // 
            this.Moduleid.DataPropertyName = "Moduleid";
            this.Moduleid.HeaderText = "Moduleid";
            this.Moduleid.Name = "Moduleid";
            this.Moduleid.Visible = false;
            // 
            // RightTag
            // 
            this.RightTag.DataPropertyName = "RightTag";
            this.RightTag.HeaderText = "操作权限";
            this.RightTag.Name = "RightTag";
            this.RightTag.ReadOnly = true;
            // 
            // IsRight
            // 
            this.IsRight.DataPropertyName = "IsRight";
            this.IsRight.FalseValue = "0";
            this.IsRight.HeaderText = "授权";
            this.IsRight.Name = "IsRight";
            this.IsRight.TrueValue = "1";
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "close.ico");
            this.imageList1.Images.SetKeyName(1, "open.ico");
            // 
            // FormAssignRight
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(707, 351);
            this.Controls.Add(this.dgvINRightInfo);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.toolStrip1);
            this.Name = "FormAssignRight";
            this.Text = "权限管理";
            this.Load += new System.EventHandler(this.FormAssignRight_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvINRightInfo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsINRight)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolSave;
        private System.Windows.Forms.ToolStripButton toolExit;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TreeView tvModule;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TreeView tvOperator;
        private System.Windows.Forms.DataGridView dgvINRightInfo;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.BindingSource bsINRight;
        private System.Windows.Forms.DataGridViewTextBoxColumn UserID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Moduleid;
        private System.Windows.Forms.DataGridViewTextBoxColumn RightTag;
        private System.Windows.Forms.DataGridViewCheckBoxColumn IsRight;
    }
}