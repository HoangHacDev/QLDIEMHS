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
    public partial class QLHocSinh : Form
    {
        private readonly HocSinhHandler _hocSinhHandler;
        private readonly HocSinhSerivces _hocSinhSerivces;

        private readonly LopHocServices _lopHocServices;

        public QLHocSinh()
        {
            InitializeComponent();
            ConnectionString connectionString = new ConnectionString();
            _hocSinhSerivces = new HocSinhSerivces(connectionString);
            _hocSinhHandler = new HocSinhHandler(_hocSinhSerivces);

            _lopHocServices = new LopHocServices(connectionString);
        }

        private void QLHocSinh_Load(object sender, EventArgs e)
        {
            // Trong hàm khởi tạo của form:
            List<GioiTinhItem> gioiTinhList = new List<GioiTinhItem>()
            {
                new GioiTinhItem { ID = 1, Value = "Nam" },
                new GioiTinhItem { ID = 2, Value = "Nữ" }
            };

            Cb_GioiTinhHS.DataSource = gioiTinhList;
            Cb_GioiTinhHS.DisplayMember = "Value"; // Hiển thị thuộc tính Value
            Cb_GioiTinhHS.ValueMember = "ID";    // Sử dụng ID làm giá trị
            Cb_GioiTinhHS.SelectedIndex = -1;

            Dgv_HocSinh.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            Dgv_HocSinh.MultiSelect = false;
            Dgv_HocSinh.AllowUserToAddRows = false;
            Dgv_HocSinh.ReadOnly = true; // Ngăn chỉnh sửa toàn bộ DataGridView

            LockFields();
        }

        private void Btn_ThemHocSinh_Click(object sender, EventArgs e)
        {
            //Console.WriteLine(Cb_GioiTinhHS);
            _hocSinhHandler.HandleInsert(Txt_TenHocSinh, DTP_NgaySinhHS.Value, Cb_GioiTinhHS, Cb_LopHoc, newId =>
            {
                _hocSinhHandler.HandleLoadData(Dgv_HocSinh);
            });
        }

        private void Btn_XoaHocSinh_Click(object sender, EventArgs e)
        {
            if (Dgv_HocSinh.CurrentRow != null)
            {
                string id = Txt_MaHocSinh.Text;
                _hocSinhHandler.HandleDelete(id, () =>
                {
                    _hocSinhHandler.HandleLoadData(Dgv_HocSinh);
                    ClearDuLieuMH();
                });
            }
        }

        private void Btn_SuaHocSinh_Click(object sender, EventArgs e)
        {
            if (Dgv_HocSinh.CurrentRow != null)
            {
                string id = Txt_MaHocSinh.Text;
                _hocSinhHandler.HandleUpdate(id, Txt_TenHocSinh, DTP_NgaySinhHS.Value, Cb_GioiTinhHS, Cb_LopHoc, () =>
                {
                    _hocSinhHandler.HandleLoadData(Dgv_HocSinh);
                });
            }
        }

        private void Btn_LoadHS_Click(object sender, EventArgs e)
        {
            _hocSinhHandler.HandleLoadData(Dgv_HocSinh); // Load dữ liệu khi form mở
        }

        private void Btn_HuyDL_Click(object sender, EventArgs e)
        {
            ClearDuLieuMH();
        }

        private void Btn_ThoatFormQL_Click(object sender, EventArgs e)
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

        private void ClearDuLieuMH()
        {
            Txt_MaHocSinh.Clear();
            Txt_TenHocSinh.Clear();
            Cb_GioiTinhHS.SelectedIndex = -1;
            Cb_LopHoc.SelectedIndex = -1;
        }

        private void LockFields()
        {
            Txt_MaHocSinh.ReadOnly = true;
            Txt_MaHocSinh.TabStop = false;
            Txt_MaHocSinh.Enabled = false;

            LoadDanhSachLopHoc(Cb_LopHoc);
        }

        private void LoadDanhSachLopHoc(ComboBox cboLopHoc)
        {
            try
            {
                // Kiểm tra ComboBox có null không
                if (cboLopHoc == null)
                {
                    throw new ArgumentNullException(nameof(cboLopHoc), "ComboBox không được null.");
                }

                // Lấy danh sách nhóm hàng từ service
                List<LopHocModel> LopHocModels = _lopHocServices.GetLopHoc();

                // Kiểm tra danh sách nhóm hàng có dữ liệu không
                if (LopHocModels == null || LopHocModels.Count == 0)
                {
                    MessageBox.Show("Không có dữ liệu lớp học để hiển thị.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                // Gán dữ liệu cho ComboBox
                cboLopHoc.DataSource = LopHocModels;
                cboLopHoc.DisplayMember = "TenLop";
                cboLopHoc.ValueMember = "MaLop";
                cboLopHoc.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                // Xử lý lỗi nếu có
                MessageBox.Show($"Lỗi khi tải danh sách lớp học: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Dgv_HocSinh_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < Dgv_HocSinh.Rows.Count)
            {
                DataGridViewRow row = Dgv_HocSinh.Rows[e.RowIndex];
                Txt_MaHocSinh.Text = _hocSinhSerivces.GetHocSinh()[e.RowIndex].MaHS;
                Txt_TenHocSinh.Text = row.Cells["Tên học sinh"].Value?.ToString() ?? "";
                DTP_NgaySinhHS.Text = row.Cells["Ngày sinh"].Value?.ToString() ?? "";

                if (row.Cells["Giới tính"].Value != null)
                {
                    string gioiTinh = row.Cells["Giới tính"].Value.ToString();
                    foreach (var item in Cb_GioiTinhHS.Items)
                    {
                        if (item.GetType().GetProperty(Cb_GioiTinhHS.DisplayMember)?.GetValue(item)?.ToString() == gioiTinh)
                        {
                            Cb_GioiTinhHS.SelectedItem = item; // Chọn giá trị phù hợp trong ComboBox
                            break;
                        }
                    }
                }
                else
                {
                    Cb_GioiTinhHS.SelectedIndex = -1; // Nếu không có giá trị, đặt ComboBox về trạng thái rỗng
                }

                if (row.Cells["Lớp"].Value != null)
                {
                    string tenLop = row.Cells["Lớp"].Value.ToString();
                    foreach (var item in Cb_LopHoc.Items)
                    {
                        if (item.GetType().GetProperty(Cb_LopHoc.DisplayMember)?.GetValue(item)?.ToString() == tenLop)
                        {
                            Cb_LopHoc.SelectedItem = item; // Chọn giá trị phù hợp trong ComboBox
                            break;
                        }
                    }
                }
                else
                {
                    Cb_LopHoc.SelectedIndex = -1; // Nếu không có giá trị, đặt ComboBox về trạng thái rỗng
                }

            }
        }
    }
}
