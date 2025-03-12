using QLDiemHocSinh.Handlers;
using QLDiemHocSinh.Models;
using QLDiemHocSinh.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLDiemHocSinh.Forms
{
    public partial class QLDiem : Form
    {
        private readonly HocSinhHandler _hocSinhHandler;
        private readonly HocSinhSerivces _hocSinhSerivces;

        private readonly DiemServices _diemServices;

        private readonly LopHocServices _lopHocServices;
        public QLDiem()
        {
            InitializeComponent();
            ConnectionString connectionString = new ConnectionString();
            _hocSinhSerivces = new HocSinhSerivces(connectionString);
            _hocSinhHandler = new HocSinhHandler(_hocSinhSerivces);

            _lopHocServices = new LopHocServices(connectionString);
            _diemServices = new DiemServices(connectionString);

        }

        private void QLDiem_Load(object sender, EventArgs e)
        {
            LoadDSHocSinh();
            LockFields();
            Dgv_DSHocSinh.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            Dgv_DSHocSinh.MultiSelect = false;
            Dgv_DSHocSinh.AllowUserToAddRows = false;
            Dgv_DSHocSinh.ReadOnly = true; // Ngăn chỉnh sửa toàn bộ DataGridView

            Dgv_DSHocSinh.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            LoadDanhSachLopHoc(Cb_LopHS);
            LoadDanhSachKhoiLopHoc(Cb_KhoiHS);
        }

        private void LoadDSHocSinh()
        {
            _hocSinhHandler.HandleLoadData(Dgv_DSHocSinh);
        }

        private void Dgv_DSHocSinh_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < Dgv_DSHocSinh.Rows.Count)
            {
                string maHocSinh = _hocSinhSerivces.GetHocSinh()[e.RowIndex].MaHS;
                string tenHocSinh = _hocSinhSerivces.GetHocSinh()[e.RowIndex].HoTen;
                string malopHS = _hocSinhSerivces.GetHocSinh()[e.RowIndex].MaLop;


                // Mở form mới và truyền mã hóa đơn 
                XepLoaiHSForm xeploaiHS = new XepLoaiHSForm(maHocSinh, tenHocSinh, malopHS);
                xeploaiHS.ShowDialog(); // Hiển thị form dưới dạng modal (hoặc Show() nếu không muốn modal)
            }
        }

        private void LoadDanhSachLopHoc(ComboBox cbLopHocHS)
        {
            try
            {
                // Kiểm tra ComboBox có null không
                if (cbLopHocHS == null)
                {
                    throw new ArgumentNullException(nameof(cbLopHocHS), "ComboBox không được null.");
                }

                List<LopHocModel> lopHocModels = _lopHocServices.GetTenLopHoc();

                if (lopHocModels == null || lopHocModels.Count == 0)
                {
                    MessageBox.Show("Không có dữ liệu lớp học để hiển thị.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                // Gán dữ liệu cho ComboBox
                cbLopHocHS.DataSource = lopHocModels;
                cbLopHocHS.DisplayMember = "TenLop";
                cbLopHocHS.ValueMember = "TenLop";
                cbLopHocHS.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                // Xử lý lỗi nếu có
                MessageBox.Show($"Lỗi khi tải danh sách lớp học: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadDanhSachKhoiLopHoc(ComboBox cbKhoiHS)
        {
            try
            {
                // Kiểm tra ComboBox có null không
                if (cbKhoiHS == null)
                {
                    throw new ArgumentNullException(nameof(cbKhoiHS), "ComboBox không được null.");
                }

                List<LopHocModel> lopHocModels = _lopHocServices.GetLopHoc();

                if (lopHocModels == null || lopHocModels.Count == 0)
                {
                    MessageBox.Show("Không có dữ liệu khối lớp học để hiển thị.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                // Gán dữ liệu cho ComboBox
                Cb_KhoiHS.DataSource = lopHocModels;
                Cb_KhoiHS.DisplayMember = "Khoi";
                Cb_KhoiHS.ValueMember = "Khoi";
                Cb_KhoiHS.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                // Xử lý lỗi nếu có
                MessageBox.Show($"Lỗi khi tải danh sách khối lớp học: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void LoadDanhSachMonHocTheoHS(ComboBox cbLopHocHS, string maHS)
        {
            try
            {
                // Xóa dữ liệu ComboBox trước khi cập nhật
                cbLopHocHS.DataSource = null;
                cbLopHocHS.Items.Clear();

                // Kiểm tra ComboBox có null không
                if (cbLopHocHS == null)
                {
                    throw new ArgumentNullException(nameof(cbLopHocHS), "ComboBox không được null.");
                }

                List<DiemHocSinhModel> diemHocSinhModels = _diemServices.GetDiemHS(maHS);

                if (diemHocSinhModels == null || diemHocSinhModels.Count == 0)
                {
                    //MessageBox.Show("Không có dữ điểm cho từng môn học để hiển thị.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                // Nhóm các DiemHocSinhModel theo tên môn học và lấy bản ghi đầu tiên của mỗi nhóm
                List<DiemHocSinhModel> monHocModels = diemHocSinhModels
                    .GroupBy(d => d.TenMH)
                    .Select(g => g.First())
                    .ToList();

                // Gán dữ liệu cho ComboBox
                cbLopHocHS.DataSource = monHocModels;
                cbLopHocHS.DisplayMember = "TenMH";
                cbLopHocHS.ValueMember = "TenMH";
                cbLopHocHS.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                // Xử lý lỗi nếu có
                MessageBox.Show($"Lỗi khi tải danh sách từng môn học: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LockFields()
        {
            Txt_DiemKTM.ReadOnly = true;
            Txt_DiemKTM.TabStop = false;
            Txt_DiemKTM.Enabled = false;

            Txt_DiemKT15P.ReadOnly = true;
            Txt_DiemKT15P.TabStop = false;
            Txt_DiemKT15P.Enabled = false;

            Txt_DiemKT1T.ReadOnly = true;
            Txt_DiemKT1T.TabStop = false;
            Txt_DiemKT1T.Enabled = false;

            Txt_DiemThiHKy.ReadOnly = true;
            Txt_DiemThiHKy.TabStop = false;
            Txt_DiemThiHKy.Enabled = false;

            Txt_DiemTrungBinhHS.ReadOnly = true;
            Txt_DiemTrungBinhHS.TabStop = false;
            Txt_DiemTrungBinhHS.Enabled = false;

            Txt_TenHocSinh.ReadOnly = true;
            Txt_TenHocSinh.TabStop = false;
            Txt_TenHocSinh.Enabled = false;

            Txt_MaHocSinh.ReadOnly = true;
            Txt_MaHocSinh.TabStop = false;
            Txt_MaHocSinh.Enabled = false;

            Txt_GioiTinhHS.ReadOnly = true;
            Txt_GioiTinhHS.TabStop = false;
            Txt_GioiTinhHS.Enabled = false;

            Txt_HSLop.ReadOnly = true;
            Txt_HSLop.TabStop = false;
            Txt_HSLop.Enabled = false;

            DTP_NgaySinhHS.Enabled = false;
            DTP_NgaySinhHS.TabStop = false;

            //Txt_TenHS_XepLoai.ReadOnly = true;
            //Txt_TenHS_XepLoai.TabStop = false;
            //Txt_TenHS_XepLoai.Enabled = false;

            Txt_DTB_XepLoai.ReadOnly = true;
            Txt_DTB_XepLoai.TabStop = false;
            Txt_DTB_XepLoai.Enabled = false;

            Txt_HocLucHS.ReadOnly = true;
            Txt_HocLucHS.TabStop = false;
            Txt_HocLucHS.Enabled = false;

            //Txt_HocKyXL.ReadOnly = true;
            //Txt_HocKyXL.TabStop = false;
            //Txt_HocKyXL.Enabled = false;

            Txt_HanhKiemHS.ReadOnly = true;
            Txt_HanhKiemHS.TabStop = false;
            Txt_HanhKiemHS.Enabled = false;
        }

        private void Cb_LopHS_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Cb_LopHS.SelectedIndex == -1) return;

            // Lấy mã khối lớp đã chọn
            string tenLop = Cb_LopHS.SelectedValue.ToString();
            // Lọc dữ liệu học sinh theo khối lớp
            LoadDSHocSinhFILL(tenLop, null);
        }

        private void Cb_KhoiHS_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Cb_KhoiHS.SelectedIndex == -1) return;

            // Lấy mã khối lớp đã chọn
            string tenKhoi = Cb_KhoiHS.SelectedValue.ToString();

            // Lọc dữ liệu học sinh theo khối lớp
            LoadDSHocSinhFILL(null, tenKhoi);
        }

        private void LoadDSHocSinhFILL(string tenLop, string tenKhoi)
        {
            _hocSinhHandler.HandleLoadDataFill(Dgv_DSHocSinh, tenLop, tenKhoi);
        }

        private void Btn_LoadDSHS_Click(object sender, EventArgs e)
        {
            LoadDSHocSinh();
            Cb_LopHS.SelectedIndex = -1;
            Cb_KhoiHS.SelectedIndex = -1;
        }

        private void Btn_ThoatForm_Click(object sender, EventArgs e)
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

        private void Dgv_DSHocSinh_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < Dgv_DSHocSinh.Rows.Count)
            {
                Txt_MaHocSinh.Text = _hocSinhSerivces.GetHocSinh()[e.RowIndex].MaHS.ToString();
                Txt_TenHocSinh.Text = _hocSinhSerivces.GetHocSinh()[e.RowIndex].HoTen.ToString();
                Txt_GioiTinhHS.Text = _hocSinhSerivces.GetHocSinh()[e.RowIndex].GioiTinh ? "Nam" : "Nữ";
                DTP_NgaySinhHS.Text = _hocSinhSerivces.GetHocSinh()[e.RowIndex].NgaySinh.ToString();
                Txt_HSLop.Text = _hocSinhSerivces.GetHocSinh()[e.RowIndex].TenLop.ToString();

                string maHS = _hocSinhSerivces.GetHocSinh()[e.RowIndex].MaHS;
                var diemHS = _diemServices.GetHanhkiem(maHS);

                LoadDanhSachMonHocTheoHS(Cb_MonHoc_HS, maHS);

                if (diemHS != null && diemHS.Any())
                {
                    var thongTinHocSinh = diemHS.First();
                    // Hiển thị điểm trung bình
                    Txt_DTB_XepLoai.Text = thongTinHocSinh.DiemTrungBinh.ToString("F2");

                    // Hiển thị học lực (giả sử có TextBox tên là Txt_HocLuc)
                    Txt_HocLucHS.Text = thongTinHocSinh.HocLuc;

                    // Hiển thị hạnh kiểm (giả sử có TextBox tên là Txt_HanhKiem)
                    Txt_HanhKiemHS.Text = thongTinHocSinh.HanhKiem;
                }
                else
                {
                    MessageBox.Show("Không tìm thấy điểm của học sinh này hoặc chưa chấm");
                    Txt_DTB_XepLoai.Clear();
                    Txt_HocLucHS.Clear();
                    Txt_HanhKiemHS.Clear();
                }
            }

        }

        private void Cb_MonHoc_HS_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Cb_MonHoc_HS.SelectedIndex != -1)
            {
                string tenMonHoc = Cb_MonHoc_HS.SelectedValue.ToString();
                string maHS = Txt_MaHocSinh.Text;
                HienThiDiemTheoMonHoc(maHS, tenMonHoc);
            }
        }

        private void HienThiDiemTheoMonHoc(string maHS, string tenMonHoc)
        {
            try
            {
                List<DiemHocSinhModel> diemHocSinhModels = _diemServices.GetDiemHS(maHS)
                    .Where(d => d.TenMH == tenMonHoc)
                    .ToList();

                if (diemHocSinhModels == null || diemHocSinhModels.Count == 0)
                {
                    // Xử lý trường hợp không có dữ liệu
                    ClearTextBoxes();
                    return;
                }

                ClearTextBoxes(); // Xóa dữ liệu cũ trước khi hiển thị dữ liệu mới

                double diemKTM = 0, diemKT15P = 0, diemKT1T = 0, diemThiHKy = 0;

                foreach (var diem in diemHocSinhModels)
                {
                    switch (diem.TenLoaiDiem)
                    {
                        case "Kiểm tra miệng":
                            diemKTM = diem.Diem;
                            Txt_DiemKTM.Text = diem.Diem.ToString();
                            break;
                        case "Kiểm tra 15p":
                            diemKT15P = diem.Diem;
                            Txt_DiemKT15P.Text = diem.Diem.ToString();
                            break;
                        case "Kiểm tra 1 tiết":
                            diemKT1T = diem.Diem;
                            Txt_DiemKT1T.Text = diem.Diem.ToString();
                            break;
                        case "Kiểm tra học kỳ":
                            diemThiHKy = diem.Diem;
                            Txt_DiemThiHKy.Text = diem.Diem.ToString();
                            break;
                    }
                }
                // Tính điểm trung bình theo hệ số
                double diemTrungBinh = (diemKTM * 1 + diemKT15P * 1 + diemKT1T * 2 + diemThiHKy * 3) / 7;

                // Hiển thị điểm trung bình lên TextBox
                Txt_DiemTrungBinhHS.Text = diemTrungBinh.ToString("0.00"); // Làm tròn đến 2 chữ số thập phân
            }
            catch (Exception ex)
            {
                // Xử lý lỗi
                MessageBox.Show($"Lỗi khi tải điểm: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ClearTextBoxes()
        {
            Txt_DiemKTM.Text = "";
            Txt_DiemKT15P.Text = "";
            Txt_DiemKT1T.Text = "";
            Txt_DiemThiHKy.Text = "";
        }
    }
}
