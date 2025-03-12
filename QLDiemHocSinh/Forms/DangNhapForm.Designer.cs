namespace QLDiemHocSinh.Forms
{
    partial class DangNhapForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.Btn_DangNhap = new System.Windows.Forms.Button();
            this.Btn_ThoatForm = new System.Windows.Forms.Button();
            this.Txt_Username = new System.Windows.Forms.TextBox();
            this.Txt_Password = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(34, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tài Khoản :";
            // 
            // Btn_DangNhap
            // 
            this.Btn_DangNhap.Location = new System.Drawing.Point(39, 104);
            this.Btn_DangNhap.Name = "Btn_DangNhap";
            this.Btn_DangNhap.Size = new System.Drawing.Size(101, 36);
            this.Btn_DangNhap.TabIndex = 1;
            this.Btn_DangNhap.Text = "Đăng nhập";
            this.Btn_DangNhap.UseVisualStyleBackColor = true;
            this.Btn_DangNhap.Click += new System.EventHandler(this.Btn_DangNhap_Click);
            // 
            // Btn_ThoatForm
            // 
            this.Btn_ThoatForm.Location = new System.Drawing.Point(208, 104);
            this.Btn_ThoatForm.Name = "Btn_ThoatForm";
            this.Btn_ThoatForm.Size = new System.Drawing.Size(75, 36);
            this.Btn_ThoatForm.TabIndex = 2;
            this.Btn_ThoatForm.Text = "Thoát";
            this.Btn_ThoatForm.UseVisualStyleBackColor = true;
            // 
            // Txt_Username
            // 
            this.Txt_Username.Location = new System.Drawing.Point(123, 26);
            this.Txt_Username.Name = "Txt_Username";
            this.Txt_Username.Size = new System.Drawing.Size(160, 22);
            this.Txt_Username.TabIndex = 3;
            // 
            // Txt_Password
            // 
            this.Txt_Password.Location = new System.Drawing.Point(123, 62);
            this.Txt_Password.Name = "Txt_Password";
            this.Txt_Password.Size = new System.Drawing.Size(160, 22);
            this.Txt_Password.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(36, 65);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 16);
            this.label2.TabIndex = 4;
            this.label2.Text = "Mật Khẩu :";
            // 
            // DangNhapForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(368, 152);
            this.Controls.Add(this.Txt_Password);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.Txt_Username);
            this.Controls.Add(this.Btn_ThoatForm);
            this.Controls.Add(this.Btn_DangNhap);
            this.Controls.Add(this.label1);
            this.Name = "DangNhapForm";
            this.Text = "Đăng nhập";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button Btn_DangNhap;
        private System.Windows.Forms.Button Btn_ThoatForm;
        private System.Windows.Forms.TextBox Txt_Username;
        private System.Windows.Forms.TextBox Txt_Password;
        private System.Windows.Forms.Label label2;
    }
}