namespace QLDiemHocSinh.Forms
{
    partial class XepLoaiHSForm
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.Txt_maDiem = new System.Windows.Forms.TextBox();
            this.Cb_MonHoc_XL = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.Btn_LoadDS = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.Btn_XoaDiem = new System.Windows.Forms.Button();
            this.Btn_capNhatDFiem = new System.Windows.Forms.Button();
            this.Btn_nhapDiem = new System.Windows.Forms.Button();
            this.Txt_DiemSoHS = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.Cb_LoaiDiem_XL = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.Txt_TenHS_XL = new System.Windows.Forms.TextBox();
            this.Txt_MaHS_XL = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.Dgv_DiemHS = new System.Windows.Forms.DataGridView();
            this.Txt_DiemTB3HS = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.Cb_HanhKiemHS = new System.Windows.Forms.ComboBox();
            this.Txt_HocLuc_XL = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.Btn_CapNhatHanhKiemHS = new System.Windows.Forms.Button();
            this.Btn_DanhGiaHS = new System.Windows.Forms.Button();
            this.Txt_MaHK = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Dgv_DiemHS)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(264, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(114, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "CHÁM ĐIỂM";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.Txt_MaHK);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.Txt_maDiem);
            this.groupBox1.Controls.Add(this.Cb_MonHoc_XL);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.Btn_LoadDS);
            this.groupBox1.Controls.Add(this.button4);
            this.groupBox1.Controls.Add(this.Btn_XoaDiem);
            this.groupBox1.Controls.Add(this.Btn_capNhatDFiem);
            this.groupBox1.Controls.Add(this.Btn_nhapDiem);
            this.groupBox1.Controls.Add(this.Txt_DiemSoHS);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.Cb_LoaiDiem_XL);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.Txt_TenHS_XL);
            this.groupBox1.Controls.Add(this.Txt_MaHS_XL);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(21, 55);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(637, 166);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thông tin";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(423, 128);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 32);
            this.button1.TabIndex = 16;
            this.button1.Text = "Huỷ";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Txt_maDiem
            // 
            this.Txt_maDiem.Location = new System.Drawing.Point(10, 99);
            this.Txt_maDiem.Name = "Txt_maDiem";
            this.Txt_maDiem.Size = new System.Drawing.Size(22, 22);
            this.Txt_maDiem.TabIndex = 15;
            this.Txt_maDiem.Visible = false;
            // 
            // Cb_MonHoc_XL
            // 
            this.Cb_MonHoc_XL.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Cb_MonHoc_XL.FormattingEnabled = true;
            this.Cb_MonHoc_XL.Location = new System.Drawing.Point(394, 23);
            this.Cb_MonHoc_XL.Name = "Cb_MonHoc_XL";
            this.Cb_MonHoc_XL.Size = new System.Drawing.Size(194, 24);
            this.Cb_MonHoc_XL.TabIndex = 14;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(308, 28);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(64, 16);
            this.label9.TabIndex = 13;
            this.label9.Text = "Môn học :";
            // 
            // Btn_LoadDS
            // 
            this.Btn_LoadDS.Location = new System.Drawing.Point(332, 128);
            this.Btn_LoadDS.Name = "Btn_LoadDS";
            this.Btn_LoadDS.Size = new System.Drawing.Size(75, 32);
            this.Btn_LoadDS.TabIndex = 12;
            this.Btn_LoadDS.Text = "Nạp lại";
            this.Btn_LoadDS.UseVisualStyleBackColor = true;
            this.Btn_LoadDS.Click += new System.EventHandler(this.Btn_LoadDS_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(556, 128);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 32);
            this.button4.TabIndex = 11;
            this.button4.Text = "Thoát";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // Btn_XoaDiem
            // 
            this.Btn_XoaDiem.Location = new System.Drawing.Point(228, 128);
            this.Btn_XoaDiem.Name = "Btn_XoaDiem";
            this.Btn_XoaDiem.Size = new System.Drawing.Size(75, 32);
            this.Btn_XoaDiem.TabIndex = 10;
            this.Btn_XoaDiem.Text = "Xoá";
            this.Btn_XoaDiem.UseVisualStyleBackColor = true;
            this.Btn_XoaDiem.Click += new System.EventHandler(this.Btn_XoaDiem_Click);
            // 
            // Btn_capNhatDFiem
            // 
            this.Btn_capNhatDFiem.Location = new System.Drawing.Point(100, 128);
            this.Btn_capNhatDFiem.Name = "Btn_capNhatDFiem";
            this.Btn_capNhatDFiem.Size = new System.Drawing.Size(99, 32);
            this.Btn_capNhatDFiem.TabIndex = 9;
            this.Btn_capNhatDFiem.Text = "Sửa Điểm";
            this.Btn_capNhatDFiem.UseVisualStyleBackColor = true;
            this.Btn_capNhatDFiem.Click += new System.EventHandler(this.Btn_capNhatDFiem_Click);
            // 
            // Btn_nhapDiem
            // 
            this.Btn_nhapDiem.Location = new System.Drawing.Point(10, 128);
            this.Btn_nhapDiem.Name = "Btn_nhapDiem";
            this.Btn_nhapDiem.Size = new System.Drawing.Size(75, 32);
            this.Btn_nhapDiem.TabIndex = 8;
            this.Btn_nhapDiem.Text = "Nhập";
            this.Btn_nhapDiem.UseVisualStyleBackColor = true;
            this.Btn_nhapDiem.Click += new System.EventHandler(this.Btn_nhapDiem_Click);
            // 
            // Txt_DiemSoHS
            // 
            this.Txt_DiemSoHS.Location = new System.Drawing.Point(462, 96);
            this.Txt_DiemSoHS.Name = "Txt_DiemSoHS";
            this.Txt_DiemSoHS.Size = new System.Drawing.Size(61, 22);
            this.Txt_DiemSoHS.TabIndex = 7;
            this.Txt_DiemSoHS.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Txt_DiemSoHS_KeyPress);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(366, 99);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(80, 16);
            this.label5.TabIndex = 6;
            this.label5.Text = "Nhập Điểm :";
            // 
            // Cb_LoaiDiem_XL
            // 
            this.Cb_LoaiDiem_XL.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Cb_LoaiDiem_XL.FormattingEnabled = true;
            this.Cb_LoaiDiem_XL.Location = new System.Drawing.Point(394, 58);
            this.Cb_LoaiDiem_XL.Name = "Cb_LoaiDiem_XL";
            this.Cb_LoaiDiem_XL.Size = new System.Drawing.Size(194, 24);
            this.Cb_LoaiDiem_XL.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(308, 61);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(73, 16);
            this.label4.TabIndex = 4;
            this.label4.Text = "Loại Điểm :";
            // 
            // Txt_TenHS_XL
            // 
            this.Txt_TenHS_XL.Location = new System.Drawing.Point(116, 63);
            this.Txt_TenHS_XL.Name = "Txt_TenHS_XL";
            this.Txt_TenHS_XL.Size = new System.Drawing.Size(159, 22);
            this.Txt_TenHS_XL.TabIndex = 3;
            // 
            // Txt_MaHS_XL
            // 
            this.Txt_MaHS_XL.Location = new System.Drawing.Point(116, 25);
            this.Txt_MaHS_XL.Name = "Txt_MaHS_XL";
            this.Txt_MaHS_XL.Size = new System.Drawing.Size(159, 22);
            this.Txt_MaHS_XL.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 66);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(94, 16);
            this.label3.TabIndex = 1;
            this.label3.Text = "Tên Học Sinh :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 16);
            this.label2.TabIndex = 0;
            this.label2.Text = "Mã Học Sinh :";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.Dgv_DiemHS);
            this.groupBox2.Location = new System.Drawing.Point(21, 227);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(637, 202);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Danh sách điểm đã nhập";
            // 
            // Dgv_DiemHS
            // 
            this.Dgv_DiemHS.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Dgv_DiemHS.Location = new System.Drawing.Point(10, 21);
            this.Dgv_DiemHS.Name = "Dgv_DiemHS";
            this.Dgv_DiemHS.RowHeadersWidth = 51;
            this.Dgv_DiemHS.RowTemplate.Height = 24;
            this.Dgv_DiemHS.Size = new System.Drawing.Size(621, 175);
            this.Dgv_DiemHS.TabIndex = 0;
            this.Dgv_DiemHS.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Dgv_DiemHS_CellClick);
            // 
            // Txt_DiemTB3HS
            // 
            this.Txt_DiemTB3HS.Location = new System.Drawing.Point(174, 455);
            this.Txt_DiemTB3HS.Name = "Txt_DiemTB3HS";
            this.Txt_DiemTB3HS.Size = new System.Drawing.Size(159, 22);
            this.Txt_DiemTB3HS.TabIndex = 14;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(18, 458);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(150, 16);
            this.label6.TabIndex = 13;
            this.label6.Text = "Điểm trung bình 3 hệ số :";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(350, 461);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(78, 16);
            this.label7.TabIndex = 15;
            this.label7.Text = "Hạnh Kiểm :";
            // 
            // Cb_HanhKiemHS
            // 
            this.Cb_HanhKiemHS.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Cb_HanhKiemHS.FormattingEnabled = true;
            this.Cb_HanhKiemHS.Location = new System.Drawing.Point(434, 455);
            this.Cb_HanhKiemHS.Name = "Cb_HanhKiemHS";
            this.Cb_HanhKiemHS.Size = new System.Drawing.Size(175, 24);
            this.Cb_HanhKiemHS.TabIndex = 16;
            // 
            // Txt_HocLuc_XL
            // 
            this.Txt_HocLuc_XL.Location = new System.Drawing.Point(174, 493);
            this.Txt_HocLuc_XL.Name = "Txt_HocLuc_XL";
            this.Txt_HocLuc_XL.Size = new System.Drawing.Size(159, 22);
            this.Txt_HocLuc_XL.TabIndex = 18;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(18, 496);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(62, 16);
            this.label8.TabIndex = 17;
            this.label8.Text = "Học Lực :";
            // 
            // Btn_CapNhatHanhKiemHS
            // 
            this.Btn_CapNhatHanhKiemHS.Location = new System.Drawing.Point(529, 488);
            this.Btn_CapNhatHanhKiemHS.Name = "Btn_CapNhatHanhKiemHS";
            this.Btn_CapNhatHanhKiemHS.Size = new System.Drawing.Size(110, 27);
            this.Btn_CapNhatHanhKiemHS.TabIndex = 19;
            this.Btn_CapNhatHanhKiemHS.Text = "Cập nhật";
            this.Btn_CapNhatHanhKiemHS.UseVisualStyleBackColor = true;
            this.Btn_CapNhatHanhKiemHS.Click += new System.EventHandler(this.Btn_CapNhatHanhKiemHS_Click);
            // 
            // Btn_DanhGiaHS
            // 
            this.Btn_DanhGiaHS.Location = new System.Drawing.Point(415, 488);
            this.Btn_DanhGiaHS.Name = "Btn_DanhGiaHS";
            this.Btn_DanhGiaHS.Size = new System.Drawing.Size(108, 27);
            this.Btn_DanhGiaHS.TabIndex = 19;
            this.Btn_DanhGiaHS.Text = "Đánh giá";
            this.Btn_DanhGiaHS.UseVisualStyleBackColor = true;
            this.Btn_DanhGiaHS.Click += new System.EventHandler(this.Btn_DanhGiaHS_Click);
            // 
            // Txt_MaHK
            // 
            this.Txt_MaHK.Location = new System.Drawing.Point(38, 100);
            this.Txt_MaHK.Name = "Txt_MaHK";
            this.Txt_MaHK.Size = new System.Drawing.Size(21, 22);
            this.Txt_MaHK.TabIndex = 17;
            this.Txt_MaHK.Visible = false;
            // 
            // XepLoaiHSForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(687, 526);
            this.Controls.Add(this.Btn_DanhGiaHS);
            this.Controls.Add(this.Btn_CapNhatHanhKiemHS);
            this.Controls.Add(this.Txt_HocLuc_XL);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.Cb_HanhKiemHS);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.Txt_DiemTB3HS);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Name = "XepLoaiHSForm";
            this.Text = "Chấm điểm học sinh";
            this.Load += new System.EventHandler(this.XepLoaiHSForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Dgv_DiemHS)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox Txt_DiemSoHS;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox Cb_LoaiDiem_XL;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox Txt_TenHS_XL;
        private System.Windows.Forms.TextBox Txt_MaHS_XL;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView Dgv_DiemHS;
        private System.Windows.Forms.Button Btn_LoadDS;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button Btn_XoaDiem;
        private System.Windows.Forms.Button Btn_capNhatDFiem;
        private System.Windows.Forms.Button Btn_nhapDiem;
        private System.Windows.Forms.TextBox Txt_DiemTB3HS;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox Cb_HanhKiemHS;
        private System.Windows.Forms.TextBox Txt_HocLuc_XL;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox Cb_MonHoc_XL;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button Btn_CapNhatHanhKiemHS;
        private System.Windows.Forms.TextBox Txt_maDiem;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button Btn_DanhGiaHS;
        private System.Windows.Forms.TextBox Txt_MaHK;
    }
}