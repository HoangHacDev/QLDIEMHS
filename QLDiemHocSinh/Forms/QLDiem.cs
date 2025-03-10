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

        private readonly LopHocServices _lopHocServices;
        public QLDiem()
        {
            InitializeComponent();
            ConnectionString connectionString = new ConnectionString();
            _hocSinhSerivces = new HocSinhSerivces(connectionString);
            _hocSinhHandler = new HocSinhHandler(_hocSinhSerivces);

            _lopHocServices = new LopHocServices(connectionString);
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

                // Mở form mới và truyền mã hóa đơn 
                XepLoaiHSForm xeploaiHS = new XepLoaiHSForm(maHocSinh, tenHocSinh);
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

                List<LopHocModel> lopHocModels = _lopHocServices.GetLopHoc();

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

            Txt_TenHS_XepLoai.ReadOnly = true;
            Txt_TenHS_XepLoai.TabStop = false;
            Txt_TenHS_XepLoai.Enabled = false;

            Txt_DTB_XepLoai.ReadOnly = true;
            Txt_DTB_XepLoai.TabStop = false;
            Txt_DTB_XepLoai.Enabled = false;

            Txt_HocLucHS.ReadOnly = true;
            Txt_HocLucHS.TabStop = false;
            Txt_HocLucHS.Enabled = false;

            Txt_HocKyXL.ReadOnly = true;
            Txt_HocKyXL.TabStop = false;
            Txt_HocKyXL.Enabled = false;

            Txt_HanhKiemHS.ReadOnly = true;
            Txt_HanhKiemHS.TabStop = false;
            Txt_HanhKiemHS.Enabled = false;
        }

        private void Cb_LopHS_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Cb_LopHS.SelectedIndex == -1) return;

            // Lấy mã khối lớp đã chọn
            string tenLop = Cb_LopHS.SelectedValue.ToString();
            Console.WriteLine(tenLop);
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
    }
}
