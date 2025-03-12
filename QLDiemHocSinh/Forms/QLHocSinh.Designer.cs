namespace QLDiemHocSinh.Forms
{
    partial class QLHocSinh
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
            this.Dgv_HocSinh = new System.Windows.Forms.DataGridView();
            this.DTP_NgaySinhHS = new System.Windows.Forms.DateTimePicker();
            this.Btn_HuyDL = new System.Windows.Forms.Button();
            this.Btn_ThoatFormQL = new System.Windows.Forms.Button();
            this.Btn_LoadHS = new System.Windows.Forms.Button();
            this.Btn_SuaHocSinh = new System.Windows.Forms.Button();
            this.Btn_XoaHocSinh = new System.Windows.Forms.Button();
            this.Btn_ThemHocSinh = new System.Windows.Forms.Button();
            this.Txt_TenHocSinh = new System.Windows.Forms.TextBox();
            this.Txt_MaHocSinh = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.Cb_GioiTinhHS = new System.Windows.Forms.ComboBox();
            this.Cb_LopHoc = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.Dgv_HocSinh)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // Dgv_HocSinh
            // 
            this.Dgv_HocSinh.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Dgv_HocSinh.Location = new System.Drawing.Point(42, 318);
            this.Dgv_HocSinh.Name = "Dgv_HocSinh";
            this.Dgv_HocSinh.RowHeadersWidth = 51;
            this.Dgv_HocSinh.RowTemplate.Height = 24;
            this.Dgv_HocSinh.Size = new System.Drawing.Size(744, 237);
            this.Dgv_HocSinh.TabIndex = 5;
            this.Dgv_HocSinh.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Dgv_HocSinh_CellClick);
            // 
            // DTP_NgaySinhHS
            // 
            this.DTP_NgaySinhHS.Location = new System.Drawing.Point(499, 40);
            this.DTP_NgaySinhHS.Name = "DTP_NgaySinhHS";
            this.DTP_NgaySinhHS.Size = new System.Drawing.Size(226, 22);
            this.DTP_NgaySinhHS.TabIndex = 3;
            // 
            // Btn_HuyDL
            // 
            this.Btn_HuyDL.Location = new System.Drawing.Point(429, 166);
            this.Btn_HuyDL.Name = "Btn_HuyDL";
            this.Btn_HuyDL.Size = new System.Drawing.Size(75, 23);
            this.Btn_HuyDL.TabIndex = 13;
            this.Btn_HuyDL.Text = "Huỷ";
            this.Btn_HuyDL.UseVisualStyleBackColor = true;
            this.Btn_HuyDL.Click += new System.EventHandler(this.Btn_HuyDL_Click);
            // 
            // Btn_ThoatFormQL
            // 
            this.Btn_ThoatFormQL.Location = new System.Drawing.Point(597, 167);
            this.Btn_ThoatFormQL.Name = "Btn_ThoatFormQL";
            this.Btn_ThoatFormQL.Size = new System.Drawing.Size(75, 23);
            this.Btn_ThoatFormQL.TabIndex = 12;
            this.Btn_ThoatFormQL.Text = "Thoát";
            this.Btn_ThoatFormQL.UseVisualStyleBackColor = true;
            this.Btn_ThoatFormQL.Click += new System.EventHandler(this.Btn_ThoatFormQL_Click);
            // 
            // Btn_LoadHS
            // 
            this.Btn_LoadHS.Location = new System.Drawing.Point(319, 166);
            this.Btn_LoadHS.Name = "Btn_LoadHS";
            this.Btn_LoadHS.Size = new System.Drawing.Size(75, 23);
            this.Btn_LoadHS.TabIndex = 11;
            this.Btn_LoadHS.Text = "Nạp";
            this.Btn_LoadHS.UseVisualStyleBackColor = true;
            this.Btn_LoadHS.Click += new System.EventHandler(this.Btn_LoadHS_Click);
            // 
            // Btn_SuaHocSinh
            // 
            this.Btn_SuaHocSinh.Location = new System.Drawing.Point(222, 166);
            this.Btn_SuaHocSinh.Name = "Btn_SuaHocSinh";
            this.Btn_SuaHocSinh.Size = new System.Drawing.Size(75, 23);
            this.Btn_SuaHocSinh.TabIndex = 10;
            this.Btn_SuaHocSinh.Text = "Sửa";
            this.Btn_SuaHocSinh.UseVisualStyleBackColor = true;
            this.Btn_SuaHocSinh.Click += new System.EventHandler(this.Btn_SuaHocSinh_Click);
            // 
            // Btn_XoaHocSinh
            // 
            this.Btn_XoaHocSinh.Location = new System.Drawing.Point(123, 166);
            this.Btn_XoaHocSinh.Name = "Btn_XoaHocSinh";
            this.Btn_XoaHocSinh.Size = new System.Drawing.Size(75, 23);
            this.Btn_XoaHocSinh.TabIndex = 9;
            this.Btn_XoaHocSinh.Text = "Xoá";
            this.Btn_XoaHocSinh.UseVisualStyleBackColor = true;
            this.Btn_XoaHocSinh.Click += new System.EventHandler(this.Btn_XoaHocSinh_Click);
            // 
            // Btn_ThemHocSinh
            // 
            this.Btn_ThemHocSinh.Location = new System.Drawing.Point(23, 167);
            this.Btn_ThemHocSinh.Name = "Btn_ThemHocSinh";
            this.Btn_ThemHocSinh.Size = new System.Drawing.Size(75, 23);
            this.Btn_ThemHocSinh.TabIndex = 8;
            this.Btn_ThemHocSinh.Text = "Thêm";
            this.Btn_ThemHocSinh.UseVisualStyleBackColor = true;
            this.Btn_ThemHocSinh.Click += new System.EventHandler(this.Btn_ThemHocSinh_Click);
            // 
            // Txt_TenHocSinh
            // 
            this.Txt_TenHocSinh.Location = new System.Drawing.Point(127, 76);
            this.Txt_TenHocSinh.Name = "Txt_TenHocSinh";
            this.Txt_TenHocSinh.Size = new System.Drawing.Size(185, 22);
            this.Txt_TenHocSinh.TabIndex = 5;
            // 
            // Txt_MaHocSinh
            // 
            this.Txt_MaHocSinh.Location = new System.Drawing.Point(127, 42);
            this.Txt_MaHocSinh.Name = "Txt_MaHocSinh";
            this.Txt_MaHocSinh.Size = new System.Drawing.Size(185, 22);
            this.Txt_MaHocSinh.TabIndex = 4;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(396, 42);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(73, 16);
            this.label5.TabIndex = 3;
            this.label5.Text = "Ngày sinh :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(396, 87);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(36, 16);
            this.label4.TabIndex = 2;
            this.label4.Text = "Lớp :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(24, 79);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(89, 16);
            this.label3.TabIndex = 1;
            this.label3.Text = "Tên học sinh :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(24, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 16);
            this.label2.TabIndex = 0;
            this.label2.Text = "Mã học sinh :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(298, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(217, 25);
            this.label1.TabIndex = 4;
            this.label1.Text = "QUẢN LÝ HỌC SINH";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.Cb_GioiTinhHS);
            this.groupBox1.Controls.Add(this.Cb_LopHoc);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.DTP_NgaySinhHS);
            this.groupBox1.Controls.Add(this.Btn_HuyDL);
            this.groupBox1.Controls.Add(this.Btn_ThoatFormQL);
            this.groupBox1.Controls.Add(this.Btn_LoadHS);
            this.groupBox1.Controls.Add(this.Btn_SuaHocSinh);
            this.groupBox1.Controls.Add(this.Btn_XoaHocSinh);
            this.groupBox1.Controls.Add(this.Btn_ThemHocSinh);
            this.groupBox1.Controls.Add(this.Txt_TenHocSinh);
            this.groupBox1.Controls.Add(this.Txt_MaHocSinh);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(42, 80);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(744, 215);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thông tin học sinh :";
            // 
            // Cb_GioiTinhHS
            // 
            this.Cb_GioiTinhHS.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Cb_GioiTinhHS.FormattingEnabled = true;
            this.Cb_GioiTinhHS.Location = new System.Drawing.Point(123, 117);
            this.Cb_GioiTinhHS.Name = "Cb_GioiTinhHS";
            this.Cb_GioiTinhHS.Size = new System.Drawing.Size(189, 24);
            this.Cb_GioiTinhHS.TabIndex = 17;
            // 
            // Cb_LopHoc
            // 
            this.Cb_LopHoc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Cb_LopHoc.FormattingEnabled = true;
            this.Cb_LopHoc.Location = new System.Drawing.Point(499, 83);
            this.Cb_LopHoc.Name = "Cb_LopHoc";
            this.Cb_LopHoc.Size = new System.Drawing.Size(226, 24);
            this.Cb_LopHoc.TabIndex = 16;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(24, 120);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(60, 16);
            this.label6.TabIndex = 14;
            this.label6.Text = "Giới tính :";
            // 
            // QLHocSinh
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(828, 594);
            this.Controls.Add(this.Dgv_HocSinh);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox1);
            this.Name = "QLHocSinh";
            this.Text = "QLHocSinh";
            this.Load += new System.EventHandler(this.QLHocSinh_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Dgv_HocSinh)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView Dgv_HocSinh;
        private System.Windows.Forms.DateTimePicker DTP_NgaySinhHS;
        private System.Windows.Forms.Button Btn_HuyDL;
        private System.Windows.Forms.Button Btn_ThoatFormQL;
        private System.Windows.Forms.Button Btn_LoadHS;
        private System.Windows.Forms.Button Btn_SuaHocSinh;
        private System.Windows.Forms.Button Btn_XoaHocSinh;
        private System.Windows.Forms.Button Btn_ThemHocSinh;
        private System.Windows.Forms.TextBox Txt_TenHocSinh;
        private System.Windows.Forms.TextBox Txt_MaHocSinh;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox Cb_LopHoc;
        private System.Windows.Forms.ComboBox Cb_GioiTinhHS;
    }
}