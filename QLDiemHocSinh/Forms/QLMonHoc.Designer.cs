namespace QLDiemHocSinh.Forms
{
    partial class QLMonHoc
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.Dgv_MonHoc = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.Cb_NhomMonHoc = new System.Windows.Forms.ComboBox();
            this.Btn_HuyDLMonHoc = new System.Windows.Forms.Button();
            this.Btn_ThoatMonHoc = new System.Windows.Forms.Button();
            this.Btn_LoadDSMonHoc = new System.Windows.Forms.Button();
            this.Btn_SuaMonHoc = new System.Windows.Forms.Button();
            this.Btn_XoaMonHoc = new System.Windows.Forms.Button();
            this.Btn_ThemMonHoc = new System.Windows.Forms.Button();
            this.Txt_KhoiMonHoc = new System.Windows.Forms.TextBox();
            this.Txt_TenMonHoc = new System.Windows.Forms.TextBox();
            this.Txt_MaMonHoc = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.Dgv_NhomMonHoc = new System.Windows.Forms.DataGridView();
            this.label10 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.Btn_HuyDLNhomMH = new System.Windows.Forms.Button();
            this.Btn_ThoatFormMonHoc = new System.Windows.Forms.Button();
            this.Btn_LoadDSNhomMH = new System.Windows.Forms.Button();
            this.Btn_SuaNhomMH = new System.Windows.Forms.Button();
            this.Btn_XoaNhomMH = new System.Windows.Forms.Button();
            this.Btn_ThemNhomMH = new System.Windows.Forms.Button();
            this.Txt_TenNhomMH = new System.Windows.Forms.TextBox();
            this.Txt_MaNhomMH = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Dgv_MonHoc)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Dgv_NhomMonHoc)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(2, 3);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(767, 578);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.Dgv_MonHoc);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(759, 549);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Môn Học";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // Dgv_MonHoc
            // 
            this.Dgv_MonHoc.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Dgv_MonHoc.Location = new System.Drawing.Point(6, 290);
            this.Dgv_MonHoc.Name = "Dgv_MonHoc";
            this.Dgv_MonHoc.RowHeadersWidth = 51;
            this.Dgv_MonHoc.RowTemplate.Height = 24;
            this.Dgv_MonHoc.Size = new System.Drawing.Size(744, 237);
            this.Dgv_MonHoc.TabIndex = 5;
            this.Dgv_MonHoc.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Dgv_MonHoc_CellClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(256, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(216, 25);
            this.label1.TabIndex = 4;
            this.label1.Text = "QUẢN LÝ MÔN HỌC";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.Cb_NhomMonHoc);
            this.groupBox1.Controls.Add(this.Btn_HuyDLMonHoc);
            this.groupBox1.Controls.Add(this.Btn_ThoatMonHoc);
            this.groupBox1.Controls.Add(this.Btn_LoadDSMonHoc);
            this.groupBox1.Controls.Add(this.Btn_SuaMonHoc);
            this.groupBox1.Controls.Add(this.Btn_XoaMonHoc);
            this.groupBox1.Controls.Add(this.Btn_ThemMonHoc);
            this.groupBox1.Controls.Add(this.Txt_KhoiMonHoc);
            this.groupBox1.Controls.Add(this.Txt_TenMonHoc);
            this.groupBox1.Controls.Add(this.Txt_MaMonHoc);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(6, 53);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(744, 215);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thông tin môn học :";
            // 
            // Cb_NhomMonHoc
            // 
            this.Cb_NhomMonHoc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Cb_NhomMonHoc.FormattingEnabled = true;
            this.Cb_NhomMonHoc.Location = new System.Drawing.Point(499, 76);
            this.Cb_NhomMonHoc.Name = "Cb_NhomMonHoc";
            this.Cb_NhomMonHoc.Size = new System.Drawing.Size(177, 24);
            this.Cb_NhomMonHoc.TabIndex = 14;
            // 
            // Btn_HuyDLMonHoc
            // 
            this.Btn_HuyDLMonHoc.Location = new System.Drawing.Point(433, 145);
            this.Btn_HuyDLMonHoc.Name = "Btn_HuyDLMonHoc";
            this.Btn_HuyDLMonHoc.Size = new System.Drawing.Size(75, 23);
            this.Btn_HuyDLMonHoc.TabIndex = 13;
            this.Btn_HuyDLMonHoc.Text = "Huỷ";
            this.Btn_HuyDLMonHoc.UseVisualStyleBackColor = true;
            this.Btn_HuyDLMonHoc.Click += new System.EventHandler(this.Btn_HuyDLMonHoc_Click);
            // 
            // Btn_ThoatMonHoc
            // 
            this.Btn_ThoatMonHoc.Location = new System.Drawing.Point(601, 146);
            this.Btn_ThoatMonHoc.Name = "Btn_ThoatMonHoc";
            this.Btn_ThoatMonHoc.Size = new System.Drawing.Size(75, 23);
            this.Btn_ThoatMonHoc.TabIndex = 12;
            this.Btn_ThoatMonHoc.Text = "Thoát";
            this.Btn_ThoatMonHoc.UseVisualStyleBackColor = true;
            this.Btn_ThoatMonHoc.Click += new System.EventHandler(this.Btn_ThoatMonHoc_Click);
            // 
            // Btn_LoadDSMonHoc
            // 
            this.Btn_LoadDSMonHoc.Location = new System.Drawing.Point(323, 145);
            this.Btn_LoadDSMonHoc.Name = "Btn_LoadDSMonHoc";
            this.Btn_LoadDSMonHoc.Size = new System.Drawing.Size(75, 23);
            this.Btn_LoadDSMonHoc.TabIndex = 11;
            this.Btn_LoadDSMonHoc.Text = "Nạp";
            this.Btn_LoadDSMonHoc.UseVisualStyleBackColor = true;
            this.Btn_LoadDSMonHoc.Click += new System.EventHandler(this.Btn_LoadDSMonHoc_Click);
            // 
            // Btn_SuaMonHoc
            // 
            this.Btn_SuaMonHoc.Location = new System.Drawing.Point(226, 145);
            this.Btn_SuaMonHoc.Name = "Btn_SuaMonHoc";
            this.Btn_SuaMonHoc.Size = new System.Drawing.Size(75, 23);
            this.Btn_SuaMonHoc.TabIndex = 10;
            this.Btn_SuaMonHoc.Text = "Sửa";
            this.Btn_SuaMonHoc.UseVisualStyleBackColor = true;
            this.Btn_SuaMonHoc.Click += new System.EventHandler(this.Btn_SuaMonHoc_Click);
            // 
            // Btn_XoaMonHoc
            // 
            this.Btn_XoaMonHoc.Location = new System.Drawing.Point(127, 145);
            this.Btn_XoaMonHoc.Name = "Btn_XoaMonHoc";
            this.Btn_XoaMonHoc.Size = new System.Drawing.Size(75, 23);
            this.Btn_XoaMonHoc.TabIndex = 9;
            this.Btn_XoaMonHoc.Text = "Xoá";
            this.Btn_XoaMonHoc.UseVisualStyleBackColor = true;
            this.Btn_XoaMonHoc.Click += new System.EventHandler(this.Btn_XoaMonHoc_Click);
            // 
            // Btn_ThemMonHoc
            // 
            this.Btn_ThemMonHoc.Location = new System.Drawing.Point(27, 146);
            this.Btn_ThemMonHoc.Name = "Btn_ThemMonHoc";
            this.Btn_ThemMonHoc.Size = new System.Drawing.Size(75, 23);
            this.Btn_ThemMonHoc.TabIndex = 8;
            this.Btn_ThemMonHoc.Text = "Thêm";
            this.Btn_ThemMonHoc.UseVisualStyleBackColor = true;
            this.Btn_ThemMonHoc.Click += new System.EventHandler(this.Btn_ThemMonHoc_Click);
            // 
            // Txt_KhoiMonHoc
            // 
            this.Txt_KhoiMonHoc.Location = new System.Drawing.Point(499, 42);
            this.Txt_KhoiMonHoc.Name = "Txt_KhoiMonHoc";
            this.Txt_KhoiMonHoc.Size = new System.Drawing.Size(177, 22);
            this.Txt_KhoiMonHoc.TabIndex = 6;
            // 
            // Txt_TenMonHoc
            // 
            this.Txt_TenMonHoc.Location = new System.Drawing.Point(127, 76);
            this.Txt_TenMonHoc.Name = "Txt_TenMonHoc";
            this.Txt_TenMonHoc.Size = new System.Drawing.Size(185, 22);
            this.Txt_TenMonHoc.TabIndex = 5;
            // 
            // Txt_MaMonHoc
            // 
            this.Txt_MaMonHoc.Location = new System.Drawing.Point(127, 42);
            this.Txt_MaMonHoc.Name = "Txt_MaMonHoc";
            this.Txt_MaMonHoc.Size = new System.Drawing.Size(185, 22);
            this.Txt_MaMonHoc.TabIndex = 4;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(396, 42);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(39, 16);
            this.label5.TabIndex = 3;
            this.label5.Text = "Khối :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(396, 83);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 16);
            this.label4.TabIndex = 2;
            this.label4.Text = "Nhóm :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(24, 79);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(91, 16);
            this.label3.TabIndex = 1;
            this.label3.Text = "Tên môn học :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(24, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 16);
            this.label2.TabIndex = 0;
            this.label2.Text = "Mã môn học :";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.Dgv_NhomMonHoc);
            this.tabPage2.Controls.Add(this.label10);
            this.tabPage2.Controls.Add(this.groupBox2);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(759, 549);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Nhóm Môn Học";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // Dgv_NhomMonHoc
            // 
            this.Dgv_NhomMonHoc.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Dgv_NhomMonHoc.Location = new System.Drawing.Point(7, 295);
            this.Dgv_NhomMonHoc.Name = "Dgv_NhomMonHoc";
            this.Dgv_NhomMonHoc.RowHeadersWidth = 51;
            this.Dgv_NhomMonHoc.RowTemplate.Height = 24;
            this.Dgv_NhomMonHoc.Size = new System.Drawing.Size(744, 237);
            this.Dgv_NhomMonHoc.TabIndex = 5;
            this.Dgv_NhomMonHoc.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Dgv_NhomMonHoc_CellClick);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(247, 20);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(233, 25);
            this.label10.TabIndex = 4;
            this.label10.Text = "QUẢN LÝ NHÓM MÔN";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.Btn_HuyDLNhomMH);
            this.groupBox2.Controls.Add(this.Btn_ThoatFormMonHoc);
            this.groupBox2.Controls.Add(this.Btn_LoadDSNhomMH);
            this.groupBox2.Controls.Add(this.Btn_SuaNhomMH);
            this.groupBox2.Controls.Add(this.Btn_XoaNhomMH);
            this.groupBox2.Controls.Add(this.Btn_ThemNhomMH);
            this.groupBox2.Controls.Add(this.Txt_TenNhomMH);
            this.groupBox2.Controls.Add(this.Txt_MaNhomMH);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Location = new System.Drawing.Point(7, 58);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(744, 215);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Thông tin nhóm môn học :";
            // 
            // Btn_HuyDLNhomMH
            // 
            this.Btn_HuyDLNhomMH.Location = new System.Drawing.Point(433, 145);
            this.Btn_HuyDLNhomMH.Name = "Btn_HuyDLNhomMH";
            this.Btn_HuyDLNhomMH.Size = new System.Drawing.Size(75, 23);
            this.Btn_HuyDLNhomMH.TabIndex = 13;
            this.Btn_HuyDLNhomMH.Text = "Huỷ";
            this.Btn_HuyDLNhomMH.UseVisualStyleBackColor = true;
            this.Btn_HuyDLNhomMH.Click += new System.EventHandler(this.Btn_HuyDLNhomMH_Click);
            // 
            // Btn_ThoatFormMonHoc
            // 
            this.Btn_ThoatFormMonHoc.Location = new System.Drawing.Point(601, 146);
            this.Btn_ThoatFormMonHoc.Name = "Btn_ThoatFormMonHoc";
            this.Btn_ThoatFormMonHoc.Size = new System.Drawing.Size(75, 23);
            this.Btn_ThoatFormMonHoc.TabIndex = 12;
            this.Btn_ThoatFormMonHoc.Text = "Thoát";
            this.Btn_ThoatFormMonHoc.UseVisualStyleBackColor = true;
            this.Btn_ThoatFormMonHoc.Click += new System.EventHandler(this.Btn_ThoatFormMonHoc_Click);
            // 
            // Btn_LoadDSNhomMH
            // 
            this.Btn_LoadDSNhomMH.Location = new System.Drawing.Point(323, 145);
            this.Btn_LoadDSNhomMH.Name = "Btn_LoadDSNhomMH";
            this.Btn_LoadDSNhomMH.Size = new System.Drawing.Size(75, 23);
            this.Btn_LoadDSNhomMH.TabIndex = 11;
            this.Btn_LoadDSNhomMH.Text = "Nạp";
            this.Btn_LoadDSNhomMH.UseVisualStyleBackColor = true;
            this.Btn_LoadDSNhomMH.Click += new System.EventHandler(this.Btn_LoadDSNhomMH_Click);
            // 
            // Btn_SuaNhomMH
            // 
            this.Btn_SuaNhomMH.Location = new System.Drawing.Point(226, 145);
            this.Btn_SuaNhomMH.Name = "Btn_SuaNhomMH";
            this.Btn_SuaNhomMH.Size = new System.Drawing.Size(75, 23);
            this.Btn_SuaNhomMH.TabIndex = 10;
            this.Btn_SuaNhomMH.Text = "Sửa";
            this.Btn_SuaNhomMH.UseVisualStyleBackColor = true;
            this.Btn_SuaNhomMH.Click += new System.EventHandler(this.Btn_SuaNhomMH_Click);
            // 
            // Btn_XoaNhomMH
            // 
            this.Btn_XoaNhomMH.Location = new System.Drawing.Point(127, 145);
            this.Btn_XoaNhomMH.Name = "Btn_XoaNhomMH";
            this.Btn_XoaNhomMH.Size = new System.Drawing.Size(75, 23);
            this.Btn_XoaNhomMH.TabIndex = 9;
            this.Btn_XoaNhomMH.Text = "Xoá";
            this.Btn_XoaNhomMH.UseVisualStyleBackColor = true;
            this.Btn_XoaNhomMH.Click += new System.EventHandler(this.Btn_XoaNhomMH_Click);
            // 
            // Btn_ThemNhomMH
            // 
            this.Btn_ThemNhomMH.Location = new System.Drawing.Point(27, 146);
            this.Btn_ThemNhomMH.Name = "Btn_ThemNhomMH";
            this.Btn_ThemNhomMH.Size = new System.Drawing.Size(75, 23);
            this.Btn_ThemNhomMH.TabIndex = 8;
            this.Btn_ThemNhomMH.Text = "Thêm";
            this.Btn_ThemNhomMH.UseVisualStyleBackColor = true;
            this.Btn_ThemNhomMH.Click += new System.EventHandler(this.Btn_ThemNhomMH_Click);
            // 
            // Txt_TenNhomMH
            // 
            this.Txt_TenNhomMH.Location = new System.Drawing.Point(499, 63);
            this.Txt_TenNhomMH.Name = "Txt_TenNhomMH";
            this.Txt_TenNhomMH.Size = new System.Drawing.Size(177, 22);
            this.Txt_TenNhomMH.TabIndex = 6;
            // 
            // Txt_MaNhomMH
            // 
            this.Txt_MaNhomMH.Location = new System.Drawing.Point(127, 63);
            this.Txt_MaNhomMH.Name = "Txt_MaNhomMH";
            this.Txt_MaNhomMH.Size = new System.Drawing.Size(185, 22);
            this.Txt_MaNhomMH.TabIndex = 4;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(400, 66);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(73, 16);
            this.label6.TabIndex = 3;
            this.label6.Text = "Tên nhóm :";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(24, 66);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(86, 16);
            this.label9.TabIndex = 0;
            this.label9.Text = "Mã môn học :";
            // 
            // QLMonHoc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(771, 581);
            this.Controls.Add(this.tabControl1);
            this.Name = "QLMonHoc";
            this.Text = "QLMonHoc";
            this.Load += new System.EventHandler(this.QLMonHoc_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Dgv_MonHoc)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Dgv_NhomMonHoc)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.DataGridView Dgv_MonHoc;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button Btn_HuyDLMonHoc;
        private System.Windows.Forms.Button Btn_ThoatMonHoc;
        private System.Windows.Forms.Button Btn_LoadDSMonHoc;
        private System.Windows.Forms.Button Btn_SuaMonHoc;
        private System.Windows.Forms.Button Btn_XoaMonHoc;
        private System.Windows.Forms.Button Btn_ThemMonHoc;
        private System.Windows.Forms.TextBox Txt_KhoiMonHoc;
        private System.Windows.Forms.TextBox Txt_TenMonHoc;
        private System.Windows.Forms.TextBox Txt_MaMonHoc;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.DataGridView Dgv_NhomMonHoc;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button Btn_HuyDLNhomMH;
        private System.Windows.Forms.Button Btn_ThoatFormMonHoc;
        private System.Windows.Forms.Button Btn_LoadDSNhomMH;
        private System.Windows.Forms.Button Btn_SuaNhomMH;
        private System.Windows.Forms.Button Btn_XoaNhomMH;
        private System.Windows.Forms.Button Btn_ThemNhomMH;
        private System.Windows.Forms.TextBox Txt_TenNhomMH;
        private System.Windows.Forms.TextBox Txt_MaNhomMH;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox Cb_NhomMonHoc;
    }
}