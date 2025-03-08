namespace QLDiemHocSinh.Forms
{
    partial class QLLopHoc
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.Btn_HuyDL = new System.Windows.Forms.Button();
            this.Btn_ThoatLopHoc = new System.Windows.Forms.Button();
            this.Btn_LoadHSLopHoc = new System.Windows.Forms.Button();
            this.Btn_SuaLopHoc = new System.Windows.Forms.Button();
            this.Btn_XoaLopHoc = new System.Windows.Forms.Button();
            this.Btn_ThemLopHoc = new System.Windows.Forms.Button();
            this.Txt_KhoiLH = new System.Windows.Forms.TextBox();
            this.Txt_TenLopHoc = new System.Windows.Forms.TextBox();
            this.Txt_MaLopHoc = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.Dgv_LopHoc = new System.Windows.Forms.DataGridView();
            this.DTP_NamHoc = new System.Windows.Forms.DateTimePicker();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Dgv_LopHoc)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.DTP_NamHoc);
            this.groupBox1.Controls.Add(this.Btn_HuyDL);
            this.groupBox1.Controls.Add(this.Btn_ThoatLopHoc);
            this.groupBox1.Controls.Add(this.Btn_LoadHSLopHoc);
            this.groupBox1.Controls.Add(this.Btn_SuaLopHoc);
            this.groupBox1.Controls.Add(this.Btn_XoaLopHoc);
            this.groupBox1.Controls.Add(this.Btn_ThemLopHoc);
            this.groupBox1.Controls.Add(this.Txt_KhoiLH);
            this.groupBox1.Controls.Add(this.Txt_TenLopHoc);
            this.groupBox1.Controls.Add(this.Txt_MaLopHoc);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(24, 72);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(744, 215);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thông tin lớp học :";
            // 
            // Btn_HuyDL
            // 
            this.Btn_HuyDL.Location = new System.Drawing.Point(433, 145);
            this.Btn_HuyDL.Name = "Btn_HuyDL";
            this.Btn_HuyDL.Size = new System.Drawing.Size(75, 23);
            this.Btn_HuyDL.TabIndex = 13;
            this.Btn_HuyDL.Text = "Huỷ";
            this.Btn_HuyDL.UseVisualStyleBackColor = true;
            this.Btn_HuyDL.Click += new System.EventHandler(this.Btn_HuyDL_Click);
            // 
            // Btn_ThoatLopHoc
            // 
            this.Btn_ThoatLopHoc.Location = new System.Drawing.Point(601, 146);
            this.Btn_ThoatLopHoc.Name = "Btn_ThoatLopHoc";
            this.Btn_ThoatLopHoc.Size = new System.Drawing.Size(75, 23);
            this.Btn_ThoatLopHoc.TabIndex = 12;
            this.Btn_ThoatLopHoc.Text = "Thoát";
            this.Btn_ThoatLopHoc.UseVisualStyleBackColor = true;
            this.Btn_ThoatLopHoc.Click += new System.EventHandler(this.Btn_ThoatLopHoc_Click);
            // 
            // Btn_LoadHSLopHoc
            // 
            this.Btn_LoadHSLopHoc.Location = new System.Drawing.Point(323, 145);
            this.Btn_LoadHSLopHoc.Name = "Btn_LoadHSLopHoc";
            this.Btn_LoadHSLopHoc.Size = new System.Drawing.Size(75, 23);
            this.Btn_LoadHSLopHoc.TabIndex = 11;
            this.Btn_LoadHSLopHoc.Text = "Nạp";
            this.Btn_LoadHSLopHoc.UseVisualStyleBackColor = true;
            this.Btn_LoadHSLopHoc.Click += new System.EventHandler(this.Btn_LoadHSLopHoc_Click);
            // 
            // Btn_SuaLopHoc
            // 
            this.Btn_SuaLopHoc.Location = new System.Drawing.Point(226, 145);
            this.Btn_SuaLopHoc.Name = "Btn_SuaLopHoc";
            this.Btn_SuaLopHoc.Size = new System.Drawing.Size(75, 23);
            this.Btn_SuaLopHoc.TabIndex = 10;
            this.Btn_SuaLopHoc.Text = "Sửa";
            this.Btn_SuaLopHoc.UseVisualStyleBackColor = true;
            this.Btn_SuaLopHoc.Click += new System.EventHandler(this.Btn_SuaLopHoc_Click);
            // 
            // Btn_XoaLopHoc
            // 
            this.Btn_XoaLopHoc.Location = new System.Drawing.Point(127, 145);
            this.Btn_XoaLopHoc.Name = "Btn_XoaLopHoc";
            this.Btn_XoaLopHoc.Size = new System.Drawing.Size(75, 23);
            this.Btn_XoaLopHoc.TabIndex = 9;
            this.Btn_XoaLopHoc.Text = "Xoá";
            this.Btn_XoaLopHoc.UseVisualStyleBackColor = true;
            this.Btn_XoaLopHoc.Click += new System.EventHandler(this.Btn_XoaLopHoc_Click);
            // 
            // Btn_ThemLopHoc
            // 
            this.Btn_ThemLopHoc.Location = new System.Drawing.Point(27, 146);
            this.Btn_ThemLopHoc.Name = "Btn_ThemLopHoc";
            this.Btn_ThemLopHoc.Size = new System.Drawing.Size(75, 23);
            this.Btn_ThemLopHoc.TabIndex = 8;
            this.Btn_ThemLopHoc.Text = "Thêm";
            this.Btn_ThemLopHoc.UseVisualStyleBackColor = true;
            this.Btn_ThemLopHoc.Click += new System.EventHandler(this.Btn_ThemLopHoc_Click);
            // 
            // Txt_KhoiLH
            // 
            this.Txt_KhoiLH.Location = new System.Drawing.Point(499, 76);
            this.Txt_KhoiLH.Name = "Txt_KhoiLH";
            this.Txt_KhoiLH.Size = new System.Drawing.Size(226, 22);
            this.Txt_KhoiLH.TabIndex = 7;
            // 
            // Txt_TenLopHoc
            // 
            this.Txt_TenLopHoc.Location = new System.Drawing.Point(127, 76);
            this.Txt_TenLopHoc.Name = "Txt_TenLopHoc";
            this.Txt_TenLopHoc.Size = new System.Drawing.Size(185, 22);
            this.Txt_TenLopHoc.TabIndex = 5;
            // 
            // Txt_MaLopHoc
            // 
            this.Txt_MaLopHoc.Location = new System.Drawing.Point(127, 42);
            this.Txt_MaLopHoc.Name = "Txt_MaLopHoc";
            this.Txt_MaLopHoc.Size = new System.Drawing.Size(185, 22);
            this.Txt_MaLopHoc.TabIndex = 4;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(396, 42);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(67, 16);
            this.label5.TabIndex = 3;
            this.label5.Text = "Năm học :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(396, 83);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(39, 16);
            this.label4.TabIndex = 2;
            this.label4.Text = "Khối :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(24, 79);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(84, 16);
            this.label3.TabIndex = 1;
            this.label3.Text = "Tên lớp học :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(24, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 16);
            this.label2.TabIndex = 0;
            this.label2.Text = "Mã lớp học :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(280, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(209, 25);
            this.label1.TabIndex = 1;
            this.label1.Text = "QUẢN LÝ LỚP HỌC";
            // 
            // Dgv_LopHoc
            // 
            this.Dgv_LopHoc.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Dgv_LopHoc.Location = new System.Drawing.Point(24, 309);
            this.Dgv_LopHoc.Name = "Dgv_LopHoc";
            this.Dgv_LopHoc.RowHeadersWidth = 51;
            this.Dgv_LopHoc.RowTemplate.Height = 24;
            this.Dgv_LopHoc.Size = new System.Drawing.Size(744, 237);
            this.Dgv_LopHoc.TabIndex = 2;
            this.Dgv_LopHoc.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Dgv_LopHoc_CellClick);
            // 
            // DTP_NamHoc
            // 
            this.DTP_NamHoc.Location = new System.Drawing.Point(499, 40);
            this.DTP_NamHoc.Name = "DTP_NamHoc";
            this.DTP_NamHoc.Size = new System.Drawing.Size(226, 22);
            this.DTP_NamHoc.TabIndex = 3;
            // 
            // QLLopHoc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 558);
            this.Controls.Add(this.Dgv_LopHoc);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox1);
            this.Name = "QLLopHoc";
            this.Text = "Quản Lý Lớp Học";
            this.Load += new System.EventHandler(this.QLLopHoc_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Dgv_LopHoc)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox Txt_KhoiLH;
        private System.Windows.Forms.TextBox Txt_TenLopHoc;
        private System.Windows.Forms.TextBox Txt_MaLopHoc;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView Dgv_LopHoc;
        private System.Windows.Forms.Button Btn_HuyDL;
        private System.Windows.Forms.Button Btn_ThoatLopHoc;
        private System.Windows.Forms.Button Btn_LoadHSLopHoc;
        private System.Windows.Forms.Button Btn_SuaLopHoc;
        private System.Windows.Forms.Button Btn_XoaLopHoc;
        private System.Windows.Forms.Button Btn_ThemLopHoc;
        private System.Windows.Forms.DateTimePicker DTP_NamHoc;
    }
}