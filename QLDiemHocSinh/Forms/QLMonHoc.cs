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
    public partial class QLMonHoc : Form
    {
        private readonly NhomMonHocHandler _nhomMonHocHandler;
        private readonly NhomMonHocServices _nhomMonHocServices;

        private readonly MonHocHandler _monHocHandler;
        private readonly MonHocServices _monHocServices;

        public QLMonHoc()
        {
            InitializeComponent();
            ConnectionString connectionString = new ConnectionString();
            _nhomMonHocServices = new NhomMonHocServices(connectionString);
            _nhomMonHocHandler = new NhomMonHocHandler(_nhomMonHocServices);

            _monHocServices = new MonHocServices(connectionString);
            _monHocHandler = new MonHocHandler(_monHocServices);
        }

        private void QLMonHoc_Load(object sender, EventArgs e)
        {
            Dgv_NhomMonHoc.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            Dgv_NhomMonHoc.MultiSelect = false;
            Dgv_NhomMonHoc.AllowUserToAddRows = false;
            Dgv_NhomMonHoc.ReadOnly = true; // Ngăn chỉnh sửa toàn bộ DataGridView

            Dgv_MonHoc.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            Dgv_MonHoc.MultiSelect = false;
            Dgv_MonHoc.AllowUserToAddRows = false;
            Dgv_MonHoc.ReadOnly = true; // Ngăn chỉnh sửa toàn bộ DataGridView

            LockFields();
        }

        private void LockFields()
        {
            Txt_MaNhomMH.ReadOnly = true;
            Txt_MaNhomMH.TabStop = false;
            Txt_MaNhomMH.Enabled = false;

            Txt_MaMonHoc.ReadOnly = true;
            Txt_MaMonHoc.TabStop = false;
            Txt_MaMonHoc.Enabled = false;

            LoadDanhSachNhomMonHoc(Cb_NhomMonHoc);
        }

        private void Btn_LoadDSNhomMH_Click(object sender, EventArgs e)
        {
            _nhomMonHocHandler.HandleLoadData(Dgv_NhomMonHoc); // Load dữ liệu khi form mở
        }

        private void Btn_ThemNhomMH_Click(object sender, EventArgs e)
        {
            _nhomMonHocHandler.HandleInsert(Txt_TenNhomMH, newId =>
            {
                _nhomMonHocHandler.HandleLoadData(Dgv_NhomMonHoc);
            });
        }

        private void Btn_XoaNhomMH_Click(object sender, EventArgs e)
        {
            if (Dgv_NhomMonHoc.CurrentRow != null)
            {
                string id = Txt_MaNhomMH.Text;
                _nhomMonHocHandler.HandleDelete(id, () =>
                {
                    _nhomMonHocHandler.HandleLoadData(Dgv_NhomMonHoc);
                    ClearDuLieu();
                });
            }
        }

        private void ClearDuLieu()
        {
            Txt_MaNhomMH.Clear();
            Txt_TenNhomMH.Clear();
        }

        private void ClearDuLieuMH()
        {
            Txt_MaMonHoc.Clear();
            Txt_TenMonHoc.Clear();
            Txt_KhoiMonHoc.Clear();
            Cb_NhomMonHoc.SelectedIndex = -1;
        }

        private void Btn_SuaNhomMH_Click(object sender, EventArgs e)
        {
            if (Dgv_NhomMonHoc.CurrentRow != null)
            {
                string id = Txt_MaNhomMH.Text;
                _nhomMonHocHandler.HandleUpdate(id, Txt_TenNhomMH, () =>
                {
                    _nhomMonHocHandler.HandleLoadData(Dgv_NhomMonHoc);
                });
            }
        }

        private void Btn_HuyDLNhomMH_Click(object sender, EventArgs e)
        {
            ClearDuLieu();
        }

        private void Btn_ThoatFormMonHoc_Click(object sender, EventArgs e)
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

        private void Dgv_NhomMonHoc_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < Dgv_NhomMonHoc.Rows.Count)
            {
                DataGridViewRow row = Dgv_NhomMonHoc.Rows[e.RowIndex];
                Txt_MaNhomMH.Text = _nhomMonHocServices.GetNhomMonHoc()[e.RowIndex].MaNhom;
                Txt_TenNhomMH.Text = row.Cells["Tên nhóm môn"].Value?.ToString() ?? "";
            }
        }

        private void Btn_LoadDSMonHoc_Click(object sender, EventArgs e)
        {
            _monHocHandler.HandleLoadData(Dgv_MonHoc);
        }

        private void LoadDanhSachNhomMonHoc(ComboBox cboNhomMonHoc)
        {
            try
            {
                // Kiểm tra ComboBox có null không
                if (cboNhomMonHoc == null)
                {
                    throw new ArgumentNullException(nameof(cboNhomMonHoc), "ComboBox không được null.");
                }

                // Lấy danh sách nhóm hàng từ service
                List<NhomMonHocModel> NhomMonHocModels= _nhomMonHocServices.GetNhomMonHoc();

                // Kiểm tra danh sách nhóm hàng có dữ liệu không
                if (NhomMonHocModels == null || NhomMonHocModels.Count == 0)
                {
                    MessageBox.Show("Không có dữ liệu nhóm môn để hiển thị.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                // Gán dữ liệu cho ComboBox
                cboNhomMonHoc.DataSource = NhomMonHocModels;         
                cboNhomMonHoc.DisplayMember = "TenNhom";    
                cboNhomMonHoc.ValueMember = "MaNhom";     
                cboNhomMonHoc.SelectedIndex = -1;               
            }
            catch (Exception ex)
            {
                // Xử lý lỗi nếu có
                MessageBox.Show($"Lỗi khi tải danh sách nhóm môn: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Btn_ThemMonHoc_Click(object sender, EventArgs e)
        {
            _monHocHandler.HandleInsert(Txt_TenMonHoc, Txt_KhoiMonHoc, Cb_NhomMonHoc, newId =>
            {
                _monHocHandler.HandleLoadData(Dgv_MonHoc);
            });
        }

        private void Btn_XoaMonHoc_Click(object sender, EventArgs e)
        {
            if (Dgv_MonHoc.CurrentRow != null)
            {
                string id = Txt_MaMonHoc.Text;
                _monHocHandler.HandleDelete(id, () =>
                {
                    _monHocHandler.HandleLoadData(Dgv_MonHoc);
                    ClearDuLieuMH();
                });
            }
        }

        private void Btn_SuaMonHoc_Click(object sender, EventArgs e)
        {
            if (Dgv_MonHoc.CurrentRow != null)
            {
                string id = Txt_MaMonHoc.Text;
                _monHocHandler.HandleUpdate(id, Txt_TenMonHoc, Txt_KhoiMonHoc, Cb_NhomMonHoc, () =>
                {
                    _monHocHandler.HandleLoadData(Dgv_MonHoc);
                });
            }
        }

        private void Btn_HuyDLMonHoc_Click(object sender, EventArgs e)
        {
            ClearDuLieuMH();
        }

        private void Dgv_MonHoc_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < Dgv_MonHoc.Rows.Count)
            {
                DataGridViewRow row = Dgv_MonHoc.Rows[e.RowIndex];
                Txt_MaMonHoc.Text = _monHocServices.GetMonHoc()[e.RowIndex].MaMH;
                Txt_TenMonHoc.Text = row.Cells["Tên môn học"].Value?.ToString() ?? "";
                Txt_KhoiMonHoc.Text = row.Cells["Khối"].Value?.ToString() ?? "";
                if (row.Cells["Tên nhóm môn học"].Value != null)
                {
                    string tenNhomMH = row.Cells["Tên nhóm môn học"].Value.ToString();
                    foreach (var item in Cb_NhomMonHoc.Items)
                    {
                        if (item.GetType().GetProperty(Cb_NhomMonHoc.DisplayMember)?.GetValue(item)?.ToString() == tenNhomMH)
                        {
                            Cb_NhomMonHoc.SelectedItem = item; // Chọn giá trị phù hợp trong ComboBox
                            break;
                        }
                    }
                }
                else
                {
                    Cb_NhomMonHoc.SelectedIndex = -1; // Nếu không có giá trị, đặt ComboBox về trạng thái rỗng
                }

            }
        }

        private void Btn_ThoatMonHoc_Click(object sender, EventArgs e)
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
