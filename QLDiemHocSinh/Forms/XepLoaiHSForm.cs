using QLDiemHocSinh.Models;
using QLDiemHocSinh.Services;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace QLDiemHocSinh.Forms
{
    public partial class XepLoaiHSForm : Form
    {
        private readonly string _maHocSinh;
        private readonly string _tenHocSinh;

        private readonly MonHocServices _monHocServices;
        private readonly DiemServices _diemServices;

        public XepLoaiHSForm(string maHocSinh, string tenHocSinh)
        {
            InitializeComponent();
            ConnectionString connectionString = new ConnectionString();
            _monHocServices = new MonHocServices(connectionString);
            _diemServices = new DiemServices(connectionString);

            _maHocSinh = maHocSinh;
            _tenHocSinh = tenHocSinh;
        }

        private void XepLoaiHSForm_Load(object sender, EventArgs e)
        {
            Txt_MaHS_XL.Text = _maHocSinh;
            Txt_TenHS_XL.Text = _tenHocSinh;

            Txt_MaHS_XL.ReadOnly = true;
            Txt_MaHS_XL.TabStop = false;
            Txt_MaHS_XL.Enabled = false;

            Txt_TenHS_XL.ReadOnly = true;
            Txt_TenHS_XL.TabStop = false;
            Txt_TenHS_XL.Enabled = false;

            Txt_DiemTB3HS.ReadOnly = true;
            Txt_DiemTB3HS.TabStop = false;
            Txt_DiemTB3HS.Enabled = false;

            Txt_HocLuc_XL.ReadOnly = true;
            Txt_HocLuc_XL.TabStop = false;
            Txt_HocLuc_XL.Enabled = false;

            LoadDanhSachMonHoc(Cb_MonHoc_XL);
            LoadDanhSachLoaiDiem(Cb_LoaiDiem_XL);
        }

        private void LoadDanhSachMonHoc(ComboBox cbLopHocHS)
        {
            try
            {
                // Kiểm tra ComboBox có null không
                if (cbLopHocHS == null)
                {
                    throw new ArgumentNullException(nameof(cbLopHocHS), "ComboBox không được null.");
                }

                List<MonHocModel> monHocModels = _monHocServices.GetMonHoc();

                if (monHocModels == null || monHocModels.Count == 0)
                {
                    MessageBox.Show("Không có dữ liệu môn học để hiển thị.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                // Gán dữ liệu cho ComboBox
                cbLopHocHS.DataSource = monHocModels;
                cbLopHocHS.DisplayMember = "TenMH";
                cbLopHocHS.ValueMember = "MaMH";
                cbLopHocHS.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                // Xử lý lỗi nếu có
                MessageBox.Show($"Lỗi khi tải danh sách môn học: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadDanhSachLoaiDiem(ComboBox CbLoaiDiemHS)
        {
            try
            {
                // Kiểm tra ComboBox có null không
                if (CbLoaiDiemHS == null)
                {
                    throw new ArgumentNullException(nameof(CbLoaiDiemHS), "ComboBox không được null.");
                }

                List<LoaiDiemModel> diemHocSinhModels = _diemServices.GetLoaiDiem();

                if (diemHocSinhModels == null || diemHocSinhModels.Count == 0)
                {
                    MessageBox.Show("Không có dữ liệu loại điểm để hiển thị.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                // Gán dữ liệu cho ComboBox
                CbLoaiDiemHS.DataSource = diemHocSinhModels;
                CbLoaiDiemHS.DisplayMember = "TenLoaiDiem";
                CbLoaiDiemHS.ValueMember = "MaLoaiDiem";
                CbLoaiDiemHS.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                // Xử lý lỗi nếu có
                MessageBox.Show($"Lỗi khi tải danh sách loại điểm : {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
            "Bạn có chắc chắn muốn thoát không?",
            "Xác nhận thoát",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                this.Close();
            }
        }
    }
}
