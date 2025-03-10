using QLDiemHocSinh.Models;
using QLDiemHocSinh.Services;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace QLDiemHocSinh.Handlers
{
    public class HocSinhHandler
    {
        private readonly HocSinhSerivces _hocSinhSerivces;
        //private readonly ConnectionString _connectionString;

        public HocSinhHandler(HocSinhSerivces hocSinhSerivces)
        {
            _hocSinhSerivces = hocSinhSerivces ?? throw new ArgumentNullException(nameof(hocSinhSerivces));
        }

        public void HandleInsert(TextBox txtTenHocSinh, DateTime ngaySinh, ComboBox CbgioiTinh, ComboBox maLop, Action<string> onSuccess)
        {
            string tenHocSinh = txtTenHocSinh.Text.Trim();
            DateTime NgaySinhHS = ngaySinh;
            //int gioiTinh = (int)CbgioiTinh.SelectedValue;
            string gioiTinh = CbgioiTinh.SelectedValue?.ToString();
            string MaLop = maLop.SelectedValue?.ToString();
            bool gioiTinhBool;
          
            if (string.IsNullOrEmpty(tenHocSinh))
            {
                MessageBox.Show("Vui lòng nhập tên học sinh!");
                return;
            }

            if (NgaySinhHS > DateTime.Now)
            {
                MessageBox.Show("Năm sinh không được lớn hơn năm hiện tại!");
                return;
            }

            if (gioiTinh == "1")
            {
                gioiTinhBool = true;
            }
            else if (gioiTinh == "2")
            {
                gioiTinhBool = false;
            }
            else
            {
                MessageBox.Show("Vui lòng giới tính!");
                return;
            }

            if (string.IsNullOrEmpty(MaLop))
            {
                MessageBox.Show("Vui lòng chọn lớp học cho học sinh!");
                return;
            }

            string newId = _hocSinhSerivces.ThemHocSinh(tenHocSinh, NgaySinhHS, gioiTinhBool, MaLop);

            if (newId != null)
            {
                MessageBox.Show($"Đã thêm môn học: {newId}", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtTenHocSinh.Clear();
                ngaySinh = DateTime.Now;
                CbgioiTinh.SelectedIndex = -1;
                maLop.SelectedIndex = -1;
                onSuccess?.Invoke(newId);
            }
        }

        public void HandleLoadData(DataGridView dgvMonHoc)
        {
            List<HocSinhModel> monHocModels = _hocSinhSerivces.GetHocSinh();
            DataTable dt = new DataTable();
            dt.Columns.Add("STT", typeof(int));
            dt.Columns.Add("Mã học sinh", typeof(string));
            dt.Columns.Add("Tên học sinh", typeof(string));
            dt.Columns.Add("Ngày sinh", typeof(string));
            dt.Columns.Add("Giới tính", typeof(string));
            dt.Columns.Add("Lớp", typeof(string));


            for (int i = 0; i < monHocModels.Count; i++)
            {
                string GioiTinhHS = monHocModels[i].GioiTinh ? "Nam" : "Nữ";

                dt.Rows.Add(i + 1, monHocModels[i].MaHS, monHocModels[i].HoTen, monHocModels[i].NgaySinh, GioiTinhHS, monHocModels[i].TenLop);
            }

            dgvMonHoc.DataSource = dt;
            dgvMonHoc.Columns["Mã học sinh"].Visible = false; // Ẩn cột ID
            dgvMonHoc.Columns["STT"].Width = 50;
            dgvMonHoc.Columns["Tên học sinh"].Width = 150;
            dgvMonHoc.Columns["Ngày sinh"].Width = 150;
            dgvMonHoc.Columns["Giới tính"].Width = 80;
            dgvMonHoc.Columns["Lớp"].Width = 100;

        }

        public void HandleLoadDataFill(DataGridView dgvMonHoc, string tenLop, string tenKhoi)
        {
            List<HocSinhModel> monHocModels = _hocSinhSerivces.GetHocSinhFill(tenLop, tenKhoi);
            DataTable dt = new DataTable();
            dt.Columns.Add("STT", typeof(int));
            dt.Columns.Add("Mã học sinh", typeof(string));
            dt.Columns.Add("Tên học sinh", typeof(string));
            dt.Columns.Add("Ngày sinh", typeof(string));
            dt.Columns.Add("Giới tính", typeof(string));
            dt.Columns.Add("Lớp", typeof(string));


            for (int i = 0; i < monHocModels.Count; i++)
            {
                string GioiTinhHS = monHocModels[i].GioiTinh ? "Nam" : "Nữ";

                dt.Rows.Add(i + 1, monHocModels[i].MaHS, monHocModels[i].HoTen, monHocModels[i].NgaySinh, GioiTinhHS, monHocModels[i].TenLop);
            }

            dgvMonHoc.DataSource = dt;
            dgvMonHoc.Columns["Mã học sinh"].Visible = false; // Ẩn cột ID
            dgvMonHoc.Columns["STT"].Width = 50;
            dgvMonHoc.Columns["Tên học sinh"].Width = 150;
            dgvMonHoc.Columns["Ngày sinh"].Width = 150;
            dgvMonHoc.Columns["Giới tính"].Width = 80;
            dgvMonHoc.Columns["Lớp"].Width = 100;

        }

        public void HandleUpdate(string id_HocSinh, TextBox txtTenHocSinh, DateTime ngaySinh, ComboBox CbgioiTinh, ComboBox maLop, Action onSuccess)
        {
            string tenHocSinh = txtTenHocSinh.Text.Trim();
            DateTime NgaySinhHS = ngaySinh;
            //int gioiTinh = (int)CbgioiTinh.SelectedValue;
            string gioiTinh = CbgioiTinh.SelectedValue?.ToString();
            string MaLop = maLop.SelectedValue?.ToString();
            bool gioiTinhBool;

            if (string.IsNullOrEmpty(tenHocSinh))
            {
                MessageBox.Show("Vui lòng nhập tên học sinh!");
                return;
            }

            if (NgaySinhHS > DateTime.Now)
            {
                MessageBox.Show("Năm sinh không được lớn hơn năm hiện tại!");
                return;
            }

            if (gioiTinh == "1")
            {
                gioiTinhBool = true;
            }
            else if (gioiTinh == "2")
            {
                gioiTinhBool = false;
            }
            else
            {
                MessageBox.Show("Vui lòng giới tính!");
                return;
            }

            if (string.IsNullOrEmpty(MaLop))
            {
                MessageBox.Show("Vui lòng chọn lớp học cho học sinh!");
                return;
            }

            bool updated = _hocSinhSerivces.CapnhatHocSinh(id_HocSinh, tenHocSinh, NgaySinhHS, gioiTinhBool, MaLop);
            if (updated)
            {
                MessageBox.Show("Đã cập nhật học sinh!");
                onSuccess?.Invoke();
            }
        }

        public void HandleDelete(string id_HocSinh, Action onSuccess)
        {
            if (string.IsNullOrEmpty(id_HocSinh))
            {
                MessageBox.Show("Vui lòng chọn học sinh để xóa!");
                return;
            }

            if (MessageBox.Show("Bạn có chắc muốn xóa học sinh này?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                bool deleted = _hocSinhSerivces.DeleteHocSinh(id_HocSinh);
                if (deleted)
                {
                    MessageBox.Show("Đã xóa học sinh!");
                    onSuccess?.Invoke();
                }
            }
        }
    }
}
