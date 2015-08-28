namespace SchoolApp
{
    partial class Form1
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
            this.grid1 = new System.Windows.Forms.DataGridView();
            this.btgetLH = new System.Windows.Forms.Button();
            this.txtID = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btgetLT = new System.Windows.Forms.Button();
            this.btgetDT = new System.Windows.Forms.Button();
            this.btChiTiet = new System.Windows.Forms.Button();
            this.lbName = new System.Windows.Forms.Label();
            this.btHocPhi = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.grid1)).BeginInit();
            this.SuspendLayout();
            // 
            // grid1
            // 
            this.grid1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grid1.Location = new System.Drawing.Point(99, 73);
            this.grid1.Name = "grid1";
            this.grid1.Size = new System.Drawing.Size(608, 312);
            this.grid1.TabIndex = 0;
            // 
            // btgetLH
            // 
            this.btgetLH.Location = new System.Drawing.Point(325, 421);
            this.btgetLH.Name = "btgetLH";
            this.btgetLH.Size = new System.Drawing.Size(75, 23);
            this.btgetLH.TabIndex = 1;
            this.btgetLH.Text = "Lịch Học";
            this.btgetLH.UseVisualStyleBackColor = true;
            this.btgetLH.Click += new System.EventHandler(this.btgetLH_Click);
            // 
            // txtID
            // 
            this.txtID.Location = new System.Drawing.Point(187, 421);
            this.txtID.Name = "txtID";
            this.txtID.Size = new System.Drawing.Size(116, 20);
            this.txtID.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(106, 426);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Nhập MSV";
            // 
            // btgetLT
            // 
            this.btgetLT.Location = new System.Drawing.Point(421, 421);
            this.btgetLT.Name = "btgetLT";
            this.btgetLT.Size = new System.Drawing.Size(75, 23);
            this.btgetLT.TabIndex = 4;
            this.btgetLT.Text = "Lịch Thi";
            this.btgetLT.UseVisualStyleBackColor = true;
            this.btgetLT.Click += new System.EventHandler(this.btgetLT_Click);
            // 
            // btgetDT
            // 
            this.btgetDT.Location = new System.Drawing.Point(521, 421);
            this.btgetDT.Name = "btgetDT";
            this.btgetDT.Size = new System.Drawing.Size(75, 23);
            this.btgetDT.TabIndex = 5;
            this.btgetDT.Text = "Điểm Thi";
            this.btgetDT.UseVisualStyleBackColor = true;
            this.btgetDT.Click += new System.EventHandler(this.btgetDT_Click);
            // 
            // btChiTiet
            // 
            this.btChiTiet.Location = new System.Drawing.Point(729, 73);
            this.btChiTiet.Name = "btChiTiet";
            this.btChiTiet.Size = new System.Drawing.Size(75, 23);
            this.btChiTiet.TabIndex = 6;
            this.btChiTiet.Text = "Xem Chi Tiết";
            this.btChiTiet.UseVisualStyleBackColor = true;
            this.btChiTiet.Click += new System.EventHandler(this.btChiTiet_Click);
            // 
            // lbName
            // 
            this.lbName.AutoSize = true;
            this.lbName.Font = new System.Drawing.Font("Segoe Script", 14.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbName.Location = new System.Drawing.Point(96, 33);
            this.lbName.Name = "lbName";
            this.lbName.Size = new System.Drawing.Size(76, 30);
            this.lbName.TabIndex = 7;
            this.lbName.Text = "label2";
            // 
            // btHocPhi
            // 
            this.btHocPhi.Location = new System.Drawing.Point(632, 421);
            this.btHocPhi.Name = "btHocPhi";
            this.btHocPhi.Size = new System.Drawing.Size(75, 23);
            this.btHocPhi.TabIndex = 8;
            this.btHocPhi.Text = "Học Phí";
            this.btHocPhi.UseVisualStyleBackColor = true;
            this.btHocPhi.Click += new System.EventHandler(this.btHocPhi_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(843, 478);
            this.Controls.Add(this.btHocPhi);
            this.Controls.Add(this.lbName);
            this.Controls.Add(this.btChiTiet);
            this.Controls.Add(this.btgetDT);
            this.Controls.Add(this.btgetLT);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtID);
            this.Controls.Add(this.btgetLH);
            this.Controls.Add(this.grid1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grid1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView grid1;
        private System.Windows.Forms.Button btgetLH;
        private System.Windows.Forms.TextBox txtID;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btgetLT;
        private System.Windows.Forms.Button btgetDT;
        private System.Windows.Forms.Button btChiTiet;
        private System.Windows.Forms.Label lbName;
        private System.Windows.Forms.Button btHocPhi;
    }
}

