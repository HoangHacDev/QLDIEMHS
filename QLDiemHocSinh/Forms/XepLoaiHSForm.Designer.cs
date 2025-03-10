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
            this.Cb_MonHoc_XL = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.button5 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.Cb_LoaiDiem_XL = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.Txt_TenHS_XL = new System.Windows.Forms.TextBox();
            this.Txt_MaHS_XL = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Txt_DiemTB3HS = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.Cb_HanhKiemHS = new System.Windows.Forms.ComboBox();
            this.Txt_HocLuc_XL = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
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
            this.groupBox1.Controls.Add(this.Cb_MonHoc_XL);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.button5);
            this.groupBox1.Controls.Add(this.button4);
            this.groupBox1.Controls.Add(this.button3);
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.textBox3);
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
            // Cb_MonHoc_XL
            // 
            this.Cb_MonHoc_XL.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Cb_MonHoc_XL.FormattingEnabled = true;
            this.Cb_MonHoc_XL.Location = new System.Drawing.Point(394, 27);
            this.Cb_MonHoc_XL.Name = "Cb_MonHoc_XL";
            this.Cb_MonHoc_XL.Size = new System.Drawing.Size(194, 24);
            this.Cb_MonHoc_XL.TabIndex = 14;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(308, 32);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(64, 16);
            this.label9.TabIndex = 13;
            this.label9.Text = "Môn học :";
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(282, 128);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(75, 32);
            this.button5.TabIndex = 12;
            this.button5.Text = "Nạp";
            this.button5.UseVisualStyleBackColor = true;
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
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(190, 128);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 32);
            this.button3.TabIndex = 10;
            this.button3.Text = "Xoá";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(100, 128);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 32);
            this.button2.TabIndex = 9;
            this.button2.Text = "Sửa Điểm";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(10, 128);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 32);
            this.button1.TabIndex = 8;
            this.button1.Text = "Nhập";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(394, 100);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(61, 22);
            this.textBox3.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(308, 103);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(80, 16);
            this.label5.TabIndex = 6;
            this.label5.Text = "Nhập Điểm :";
            // 
            // Cb_LoaiDiem_XL
            // 
            this.Cb_LoaiDiem_XL.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Cb_LoaiDiem_XL.FormattingEnabled = true;
            this.Cb_LoaiDiem_XL.Location = new System.Drawing.Point(394, 62);
            this.Cb_LoaiDiem_XL.Name = "Cb_LoaiDiem_XL";
            this.Cb_LoaiDiem_XL.Size = new System.Drawing.Size(194, 24);
            this.Cb_LoaiDiem_XL.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(308, 65);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(73, 16);
            this.label4.TabIndex = 4;
            this.label4.Text = "Loại Điểm :";
            // 
            // Txt_TenHS_XL
            // 
            this.Txt_TenHS_XL.Location = new System.Drawing.Point(116, 67);
            this.Txt_TenHS_XL.Name = "Txt_TenHS_XL";
            this.Txt_TenHS_XL.Size = new System.Drawing.Size(159, 22);
            this.Txt_TenHS_XL.TabIndex = 3;
            // 
            // Txt_MaHS_XL
            // 
            this.Txt_MaHS_XL.Location = new System.Drawing.Point(116, 29);
            this.Txt_MaHS_XL.Name = "Txt_MaHS_XL";
            this.Txt_MaHS_XL.Size = new System.Drawing.Size(159, 22);
            this.Txt_MaHS_XL.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 70);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(94, 16);
            this.label3.TabIndex = 1;
            this.label3.Text = "Tên Học Sinh :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 16);
            this.label2.TabIndex = 0;
            this.label2.Text = "Mã Học Sinh :";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dataGridView1);
            this.groupBox2.Location = new System.Drawing.Point(21, 227);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(637, 202);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Danh sách điểm đã nhập";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(10, 21);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(621, 175);
            this.dataGridView1.TabIndex = 0;
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
            // XepLoaiHSForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(687, 526);
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
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox Cb_LoaiDiem_XL;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox Txt_TenHS_XL;
        private System.Windows.Forms.TextBox Txt_MaHS_XL;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox Txt_DiemTB3HS;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox Cb_HanhKiemHS;
        private System.Windows.Forms.TextBox Txt_HocLuc_XL;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox Cb_MonHoc_XL;
        private System.Windows.Forms.Label label9;
    }
}