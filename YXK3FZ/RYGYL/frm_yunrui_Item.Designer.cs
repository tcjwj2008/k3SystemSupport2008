namespace YXK3FZ.RYGYL
{
    partial class frm_yunrui_Item
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
					this.label3 = new System.Windows.Forms.Label();
					this.cbHistroy = new System.Windows.Forms.CheckBox();
					this.button2 = new System.Windows.Forms.Button();
					this.button1 = new System.Windows.Forms.Button();
					this.label2 = new System.Windows.Forms.Label();
					this.label1 = new System.Windows.Forms.Label();
					this.txtNewValue = new System.Windows.Forms.TextBox();
					this.txtOldValue = new System.Windows.Forms.TextBox();
					this.SuspendLayout();
					// 
					// label3
					// 
					this.label3.Dock = System.Windows.Forms.DockStyle.Bottom;
					this.label3.Location = new System.Drawing.Point(0, 227);
					this.label3.Name = "label3";
					this.label3.Size = new System.Drawing.Size(443, 18);
					this.label3.TabIndex = 5;
					this.label3.Text = "注：修改物料代码之前，请确认K3是否存在物料代码\r\n";
					// 
					// cbHistroy
					// 
					this.cbHistroy.AutoSize = true;
					this.cbHistroy.Font = new System.Drawing.Font("宋体", 10F);
					this.cbHistroy.Location = new System.Drawing.Point(151, 123);
					this.cbHistroy.Name = "cbHistroy";
					this.cbHistroy.Size = new System.Drawing.Size(138, 18);
					this.cbHistroy.TabIndex = 12;
					this.cbHistroy.Text = "是否修改历史单据";
					this.cbHistroy.UseVisualStyleBackColor = true;
					this.cbHistroy.Visible = false;
					// 
					// button2
					// 
					this.button2.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
					this.button2.Location = new System.Drawing.Point(274, 165);
					this.button2.Name = "button2";
					this.button2.Size = new System.Drawing.Size(92, 35);
					this.button2.TabIndex = 10;
					this.button2.Text = "取消";
					this.button2.UseVisualStyleBackColor = true;
					this.button2.Click += new System.EventHandler(this.button2_Click);
					// 
					// button1
					// 
					this.button1.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
					this.button1.Location = new System.Drawing.Point(173, 165);
					this.button1.Name = "button1";
					this.button1.Size = new System.Drawing.Size(92, 35);
					this.button1.TabIndex = 11;
					this.button1.Text = "确定";
					this.button1.UseVisualStyleBackColor = true;
					this.button1.Click += new System.EventHandler(this.button1_Click);
					// 
					// label2
					// 
					this.label2.AutoSize = true;
					this.label2.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
					this.label2.Location = new System.Drawing.Point(38, 89);
					this.label2.Name = "label2";
					this.label2.Size = new System.Drawing.Size(114, 19);
					this.label2.TabIndex = 9;
					this.label2.Text = "新物料代码:";
					// 
					// label1
					// 
					this.label1.AutoSize = true;
					this.label1.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
					this.label1.Location = new System.Drawing.Point(38, 44);
					this.label1.Name = "label1";
					this.label1.Size = new System.Drawing.Size(114, 19);
					this.label1.TabIndex = 8;
					this.label1.Text = "旧物料代码:";
					// 
					// txtNewValue
					// 
					this.txtNewValue.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
					this.txtNewValue.Location = new System.Drawing.Point(151, 83);
					this.txtNewValue.Name = "txtNewValue";
					this.txtNewValue.Size = new System.Drawing.Size(253, 29);
					this.txtNewValue.TabIndex = 6;
					this.txtNewValue.Tag = "代码开头以R/S";
					// 
					// txtOldValue
					// 
					this.txtOldValue.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
					this.txtOldValue.Location = new System.Drawing.Point(151, 44);
					this.txtOldValue.Name = "txtOldValue";
					this.txtOldValue.Size = new System.Drawing.Size(253, 29);
					this.txtOldValue.TabIndex = 7;
					this.txtOldValue.Tag = "代码开头以R/S";
					// 
					// frm_yunrui_Item
					// 
					this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
					this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
					this.ClientSize = new System.Drawing.Size(443, 245);
					this.Controls.Add(this.cbHistroy);
					this.Controls.Add(this.button2);
					this.Controls.Add(this.button1);
					this.Controls.Add(this.label2);
					this.Controls.Add(this.label1);
					this.Controls.Add(this.txtNewValue);
					this.Controls.Add(this.txtOldValue);
					this.Controls.Add(this.label3);
					this.Name = "frm_yunrui_Item";
					this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
					this.Text = "修改物料代码";
					this.ResumeLayout(false);
					this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox cbHistroy;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtNewValue;
        private System.Windows.Forms.TextBox txtOldValue;
    }
}