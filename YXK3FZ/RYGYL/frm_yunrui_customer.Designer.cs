namespace YXK3FZ.RYGYL
{
	partial class frm_yunrui_customer
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
			this.txtOldValue = new System.Windows.Forms.TextBox();
			this.txtNewValue = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.button1 = new System.Windows.Forms.Button();
			this.button2 = new System.Windows.Forms.Button();
			this.cbHistroy = new System.Windows.Forms.CheckBox();
			this.label3 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// txtOldValue
			// 
			this.txtOldValue.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.txtOldValue.Location = new System.Drawing.Point(133, 40);
			this.txtOldValue.Name = "txtOldValue";
			this.txtOldValue.Size = new System.Drawing.Size(253, 29);
			this.txtOldValue.TabIndex = 0;
			this.txtOldValue.Tag = "代码开头以R/S";
			// 
			// txtNewValue
			// 
			this.txtNewValue.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.txtNewValue.Location = new System.Drawing.Point(133, 79);
			this.txtNewValue.Name = "txtNewValue";
			this.txtNewValue.Size = new System.Drawing.Size(253, 29);
			this.txtNewValue.TabIndex = 0;
			this.txtNewValue.Tag = "代码开头以R/S";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.label1.Location = new System.Drawing.Point(20, 40);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(114, 19);
			this.label1.TabIndex = 1;
			this.label1.Text = "旧客户代码:";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.label2.Location = new System.Drawing.Point(20, 85);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(114, 19);
			this.label2.TabIndex = 1;
			this.label2.Text = "新客户代码:";
			// 
			// button1
			// 
			this.button1.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.button1.Location = new System.Drawing.Point(155, 161);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(92, 35);
			this.button1.TabIndex = 2;
			this.button1.Text = "确定";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// button2
			// 
			this.button2.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.button2.Location = new System.Drawing.Point(256, 161);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(92, 35);
			this.button2.TabIndex = 2;
			this.button2.Text = "取消";
			this.button2.UseVisualStyleBackColor = true;
			this.button2.Click += new System.EventHandler(this.button2_Click);
			// 
			// cbHistroy
			// 
			this.cbHistroy.AutoSize = true;
			this.cbHistroy.Font = new System.Drawing.Font("宋体", 10F);
			this.cbHistroy.Location = new System.Drawing.Point(133, 119);
			this.cbHistroy.Name = "cbHistroy";
			this.cbHistroy.Size = new System.Drawing.Size(138, 18);
			this.cbHistroy.TabIndex = 3;
			this.cbHistroy.Text = "是否修改历史单据";
			this.cbHistroy.UseVisualStyleBackColor = true;
			this.cbHistroy.Visible = false;
			// 
			// label3
			// 
			this.label3.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.label3.Location = new System.Drawing.Point(0, 227);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(443, 18);
			this.label3.TabIndex = 4;
			this.label3.Text = "注：修改客户代码之前，请确认K3是否存在客户代码\r\n";
			// 
			// frm_yunrui_customer
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(443, 245);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.cbHistroy);
			this.Controls.Add(this.button2);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.txtNewValue);
			this.Controls.Add(this.txtOldValue);
			this.Name = "frm_yunrui_customer";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "修改客户代码";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TextBox txtOldValue;
		private System.Windows.Forms.TextBox txtNewValue;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.CheckBox cbHistroy;
		private System.Windows.Forms.Label label3;
	}
}