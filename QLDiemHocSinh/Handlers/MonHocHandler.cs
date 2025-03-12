using QLDiemHocSinh.Models;
using QLDiemHocSinh.Services;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace QLDiemHocSinh.Handlers
{
    public class MonHocHandler
    {
        private readonly MonHocServices _monHocServices;
        //private readonly ConnectionString _connectionString;

        public MonHocHandler(MonHocServices monHocServices)
        {
            _monHocServices = monHocServices ?? throw new ArgumentNullException(nameof(monHocServices));
        }

        public void HandleInsert(TextBox txtTenMonHoc, TextBox txtKhoi, ComboBox cbTenNhomMH, Action<string> onSuccess)
        {
            string tenMH = txtTenMonHoc.Text.Trim();
            int khoiMH = int.Parse(txtKhoi.Text);
            string tenNhomMH = cbTenNhomMH.SelectedValue?.ToString();

            // Kiểm tra dữ liệu đầu vào
            if (string.IsNullOrEmpty(tenMH))
            {
                MessageBox.Show("Vui lòng nhập tên môn học!");
                return;
            }
            // Kiểm tra dữ liệu đầu vào
            if (khoiMH <= 6 && khoiMH >= 9)
            {
                MessageBox.Show("Vui lòng nhập Khối từ trong (6,7,8,9)!");
                return;
            }
            // Kiểm tra dữ liệu đầu vào
            if (string.IsNullOrEmpty(tenNhomMH))
            {
                MessageBox.Show("Vui lòng chọn nhóm môn học!");
                return;
            }

            string newId = _monHocServices.ThemMonHoc(tenMH, khoiMH, tenNhomMH);

            if (newId != null)
            {
                MessageBox.Show($"Đã thêm môn học: {newId}", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtTenMonHoc.Clear();
                txtKhoi.Clear();
                cbTenNhomMH.SelectedIndex = -1;
                onSuccess?.Invoke(newId);
            }
        }

        public void HandleLoadData(DataGridView dgvMonHoc)
        {
            List<MonHocModel> monHocModels = _monHocServices.GetMonHoc();
            DataTable dt = new DataTable();
            dt.Columns.Add("STT", typeof(int));
            dt.Columns.Add("MaMH", typeof(string));
            dt.Columns.Add("Tên môn học", typeof(string));
            dt.Columns.Add("Khối", typeof(string));
            dt.Columns.Add("Tên nhóm môn học", typeof(string));


            for (int i = 0; i < monHocModels.Count; i++)
            {
                dt.Rows.Add(i + 1, monHocModels[i].MaMH, monHocModels[i].TenMH, monHocModels[i].Khoi, monHocModels[i].TenNhom);
            }

            dgvMonHoc.DataSource = dt;
            dgvMonHoc.Columns["MaMH"].Visible = false; // Ẩn cột ID
            dgvMonHoc.Columns["STT"].Width = 50;
            dgvMonHoc.Columns["Tên môn học"].Width = 200;
            dgvMonHoc.Columns["Khối"].Width = 150;
            dgvMonHoc.Columns["Tên nhóm môn học"].Width = 150;

        }

        public void HandleUpdate(string id_MonHoc, TextBox txtTenMonHoc, TextBox KhoiMH, ComboBox cbTenNhom, Action onSuccess)
        {
            string tenMH = txtTenMonHoc.Text.Trim();
            int khoiMH = int.Parse(KhoiMH.Text);
            string tenNhomMH = cbTenNhom.SelectedValue?.ToString();

            // Kiểm tra dữ liệu đầu vào
            if (string.IsNullOrEmpty(tenMH))
            {
                MessageBox.Show("Vui lòng nhập tên môn học!");
                return;
            }
            // Kiểm tra dữ liệu đầu vào
            if (khoiMH <= 6 && khoiMH >= 9)
            {
                MessageBox.Show("Vui lòng nhập Khối từ trong (6,7,8,9)!");
                return;
            }
            // Kiểm tra dữ liệu đầu vào
            if (string.IsNullOrEmpty(tenNhomMH))
            {
                MessageBox.Show("Vui lòng chọn môn học!");
                return;
            }

            bool updated = _monHocServices.CapnhatMonMH(id_MonHoc, tenMH, khoiMH, tenNhomMH);
            if (updated)
            {
                MessageBox.Show("Đã cập nhật môn học!");
                onSuccess?.Invoke();
            }
        }

        public void HandleDelete(string id_MonHoc, Action onSuccess)
        {
            if (string.IsNullOrEmpty(id_MonHoc))
            {
                MessageBox.Show("Vui lòng chọn môn học để xóa!");
                return;
            }

            if (MessageBox.Show("Bạn có chắc muốn xóa môn học này?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                bool deleted = _monHocServices.DeleteNhomMon(id_MonHoc);
                if (deleted)
                {
                    MessageBox.Show("Đã xóa Nhóm môn học!");
                    onSuccess?.Invoke();
                }
            }
        }
    }
}
