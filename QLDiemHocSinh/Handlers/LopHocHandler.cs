using QLDiemHocSinh.Models;
using QLDiemHocSinh.Services;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLDiemHocSinh.Handlers
{
    public class LopHocHandler
    {
        private readonly LopHocServices _lopHocServices;
        //private readonly ConnectionString _connectionString;

        public LopHocHandler(LopHocServices lopHocServices)
        {
            _lopHocServices = lopHocServices ?? throw new ArgumentNullException(nameof(lopHocServices));
        }

        public void HandleInsert(TextBox txtTenLopHoc, DateTime namHoc, TextBox txtKhoi, Action<string> onSuccess)
        {
            string tenLopHoc = txtTenLopHoc.Text.Trim();
            DateTime NamHoc = namHoc;
            string khoiLH = txtKhoi.Text.Trim().ToUpper();

            string[] khoiChoPhep = { "6A", "6B", "6C", "6D", "7A", "7B", "7C", "7D", "8A", "8B", "8C", "8D", "9A", "9B", "9C", "9D" };

            // Kiểm tra dữ liệu đầu vào
            if (string.IsNullOrEmpty(tenLopHoc))
            {
                MessageBox.Show("Vui lòng nhập tên lớp học!");
                return;
            }
            if (NamHoc > DateTime.Now)
            {
                MessageBox.Show("Năm học không được lớn hơn năm hiện tại!");
                return;
            }
            // Kiểm tra dữ liệu đầu vào
            if (!khoiChoPhep.Contains(khoiLH))
            {
                MessageBox.Show("Vui lòng nhập Khối hợp lệ (6A, 6B, 6C, 6D, 6A, 7A, 7B, 7C, 7D, 8A, 8B, 8C, 8D, 9A, 9B, 9C, 9D)!");
                return;
            }

            string newId = _lopHocServices.ThemLopHoc(tenLopHoc, NamHoc, khoiLH);

            if (newId != null)
            {
                MessageBox.Show($"Đã thêm lớp học: {newId}", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtTenLopHoc.Clear();
                namHoc = DateTime.Now;
                txtKhoi.Clear();
                onSuccess?.Invoke(newId);
            }
        }

        public void HandleLoadData(DataGridView dgvLopHoc)
        {
            List<LopHocModel> lopHocModels = _lopHocServices.GetLopHoc();
            DataTable dt = new DataTable();
            dt.Columns.Add("STT", typeof(int));
            dt.Columns.Add("Mã Lớp", typeof(string));
            dt.Columns.Add("Tên lớp học", typeof(string));
            dt.Columns.Add("Năm Học", typeof(string));
            dt.Columns.Add("Khối", typeof(string));


            for (int i = 0; i < lopHocModels.Count; i++)
            {
                dt.Rows.Add(i + 1, lopHocModels[i].MaLop, lopHocModels[i].TenLop, lopHocModels[i].NamHoc, lopHocModels[i].Khoi);
            }

            dgvLopHoc.DataSource = dt;
            dgvLopHoc.Columns["Mã Lớp"].Visible = false; // Ẩn cột ID
            dgvLopHoc.Columns["STT"].Width = 50;
            dgvLopHoc.Columns["Tên lớp học"].Width = 200;
            dgvLopHoc.Columns["Năm Học"].Width = 150;
            dgvLopHoc.Columns["Khối"].Width = 150;

        }

        public void HandleUpdate(string id_LopHoc, TextBox txtTenLopHoc, DateTime namHoc, TextBox txtKhoi, Action onSuccess)
        {
            string tenLopHoc = txtTenLopHoc.Text.Trim();
            DateTime NamHoc = namHoc;
            string khoiLH = txtKhoi.Text.Trim().ToUpper();

            string[] khoiChoPhep = { "6A", "6B", "6C", "6D", "7A", "7B", "7C", "7D", "8A", "8B", "8C", "8D", "9A", "9B", "9C", "9D" };

            // Kiểm tra dữ liệu đầu vào
            if (string.IsNullOrEmpty(tenLopHoc))
            {
                MessageBox.Show("Vui lòng nhập tên lớp học!");
                return;
            }
            if (NamHoc > DateTime.Now)
            {
                MessageBox.Show("Năm học không được lớn hơn năm hiện tại!");
                return;
            }
            // Kiểm tra dữ liệu đầu vào
            if (!khoiChoPhep.Contains(khoiLH))
            {
                MessageBox.Show("Vui lòng nhập Khối hợp lệ (6A, 6B, 6C, 6D, 6A, 7A, 7B, 7C, 7D, 8A, 8B, 8C, 8D, 9A, 9B, 9C, 9D)!");
                return;
            }

            bool updated = _lopHocServices.CapnhatLopHoc(id_LopHoc, tenLopHoc, NamHoc, khoiLH);
            if (updated)
            {
                MessageBox.Show("Đã cập nhật lớp học!");
                onSuccess?.Invoke();
            }
        }

        public void HandleDelete(string id_LopHoc, Action onSuccess)
        {
            if (string.IsNullOrEmpty(id_LopHoc))
            {
                MessageBox.Show("Vui lòng chọn lớp học để xóa!");
                return;
            }

            if (MessageBox.Show("Bạn có chắc muốn xóa lớp học này?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                bool deleted = _lopHocServices.DeleteLopHoc(id_LopHoc);
                if (deleted)
                {
                    MessageBox.Show("Đã xóa Nhóm lớp học!");
                    onSuccess?.Invoke();
                }
            }
        }
    }
}
