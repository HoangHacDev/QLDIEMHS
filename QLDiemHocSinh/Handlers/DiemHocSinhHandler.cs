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
    public class DiemHocSinhHandler
    {
        private readonly DiemServices _diemServices;
        //private readonly ConnectionString _connectionString;

        public DiemHocSinhHandler(DiemServices diemServices)
        {
            _diemServices = diemServices ?? throw new ArgumentNullException(nameof(diemServices));
        }

        public void HandleInsert(TextBox maHS, string maLop, ComboBox maMH, ComboBox maLoaiDiem, TextBox diem, Action<string> onSuccess)
        {
            string maHocSinh = maHS.Text.Trim();
            //string MaLop = maLop.Text.Trim();
            string maMonHoc = maMH.SelectedValue?.ToString();
            string MaLoaiDiem = maLoaiDiem.SelectedValue?.ToString();
            float DiemHS = float.Parse(diem.Text.Trim());
            //int HocKy = int.Parse(hocKy.Text.Trim());
            //string NamHoc = namHoc.Text.Trim();
            int[] hockychophep = { 1, 2 };
            if (string.IsNullOrEmpty(maHocSinh))
            {
                MessageBox.Show("Chưa chọn học sinh!");
                return;
            }
            //if (string.IsNullOrEmpty(MaLop))
            //{
            //    MessageBox.Show("Chưa chọn học sinh!");
            //    return;
            //}
            if (string.IsNullOrEmpty(maMonHoc))
            {
                MessageBox.Show("Chưa chọn môn học!");
                return;
            }
            if (string.IsNullOrEmpty(MaLoaiDiem))
            {
                MessageBox.Show("Chưa chọn Loại điểm để chấm!");
                return;
            }
            //if (!hockychophep.Contains(HocKy))
            //{
            //    MessageBox.Show("Vui lòng nhập học kỳ hợp lệ (1, 2)!");
            //    return;
            //}

            string newId = _diemServices.ThemDiemHS(maHocSinh, maLop, maMonHoc, MaLoaiDiem, DiemHS);

            if (newId != null)
            {
                MessageBox.Show($"Đã thêm chấm điểm cho học sinh : {maHocSinh}", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                onSuccess?.Invoke(newId);
            }
        }

        public DataTable HandleLoadData(DataGridView dgvMonHoc, string maHS = null)
        {
            List<DiemHocSinhModel> diemHocSinhModels = _diemServices.GetDiemHS(maHS);
            DataTable dt = new DataTable();
            dt.Columns.Add("STT", typeof(int));
            dt.Columns.Add("Mã điểm", typeof(string));
            dt.Columns.Add("Tên môn học", typeof(string));
            dt.Columns.Add("Loại điểm", typeof(string));
            //dt.Columns.Add("Hệ Số", typeof(string));
            dt.Columns.Add("Điểm", typeof(string));


            for (int i = 0; i < diemHocSinhModels.Count; i++)
            {
                dt.Rows.Add(i + 1, diemHocSinhModels[i].MaDiem, diemHocSinhModels[i].TenMH, diemHocSinhModels[i].TenLoaiDiem, diemHocSinhModels[i].Diem);
            }

            dgvMonHoc.DataSource = dt;
            dgvMonHoc.Columns["Mã điểm"].Visible = false; // Ẩn cột ID
            dgvMonHoc.Columns["STT"].Width = 50;
            dgvMonHoc.Columns["Tên môn học"].Width = 100;
            dgvMonHoc.Columns["Loại điểm"].Width = 150;
            //dgvMonHoc.Columns["Hệ Số"].Width = 50;
            dgvMonHoc.Columns["Điểm"].Width = 100;

            return dt; // Trả về DataTable
        }

        public void HandleUpdate(string id_MaDiem, TextBox maHS, string maLop, ComboBox maMH, ComboBox maLoaiDiem, TextBox diem, Action onSuccess)
        {
            string maHocSinh = maHS.Text.Trim();
            //string MaLop = maLop.Text.Trim();
            string maMonHoc = maMH.SelectedValue?.ToString();
            string MaLoaiDiem = maLoaiDiem.SelectedValue?.ToString();
            float DiemHS = float.Parse(diem.Text.Trim());
            //int HocKy = int.Parse(hocKy.Text.Trim());
            //string NamHoc = namHoc.Text.Trim();
            int[] hockychophep = { 1, 2 };

            if (string.IsNullOrEmpty(maHocSinh))
            {
                MessageBox.Show("Chưa chọn học sinh!");
                return;
            }
            //if (string.IsNullOrEmpty(MaLop))
            //{
            //    MessageBox.Show("Chưa chọn học sinh!");
            //    return;
            //}
            if (string.IsNullOrEmpty(maMonHoc))
            {
                MessageBox.Show("Chưa chọn môn học!");
                return;
            }
            if (string.IsNullOrEmpty(MaLoaiDiem))
            {
                MessageBox.Show("Chưa chọn Loại điểm để chấm!");
                return;
            }
            //if (!hockychophep.Contains(HocKy))
            //{
            //    MessageBox.Show("Vui lòng nhập học kỳ hợp lệ (1, 2)!");
            //    return;
            //}

            bool updated = _diemServices.CapnhatDiemHS(id_MaDiem, maHocSinh, maLop, maMonHoc, MaLoaiDiem, DiemHS);
            if (updated)
            {
                MessageBox.Show("Đã cập nhật điểm cho học sinh!");
                onSuccess?.Invoke();
            }
        }

        public void HandleDelete(string id_MaDiem, Action onSuccess)
        {
            if (string.IsNullOrEmpty(id_MaDiem))
            {
                MessageBox.Show("Vui lòng chọn 1 loại điểm học sinh để xóa!");
                return;
            }

            if (MessageBox.Show("Bạn có chắc muốn điểm học sinh này?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                bool deleted = _diemServices.DeleteDiemHS(id_MaDiem);
                if (deleted)
                {
                    MessageBox.Show("Đã xóa điểm học sinh!");
                    onSuccess?.Invoke();
                }
            }
        }

        public void HandleInsertHanhKiem(TextBox maHS, string maLop, TextBox diemTB, TextBox hocLuc, ComboBox hanhKiem, Action<string> onSuccess)
        {
            string maHocSinh = maHS.Text.Trim();
            float DiemHS = float.Parse(diemTB.Text.Trim());
            string HocLuc = hocLuc.Text.Trim();
            string HanhKiem = hanhKiem.Text.Trim();
            if (string.IsNullOrEmpty(maHocSinh))
            {
                MessageBox.Show("Chưa chọn học sinh!");
                return;
            }
            if (string.IsNullOrEmpty(HocLuc))
            {
                MessageBox.Show("Chưa có học lực cho học sinh!");
                return;
            }
            if (string.IsNullOrEmpty(HanhKiem))
            {
                MessageBox.Show("Chưa chọn hạnh kiểm cho học sinh!");
                return;
            }

            string newId = _diemServices.DanhGiaHS(maHocSinh, maLop, DiemHS, HocLuc, HanhKiem);

            if (newId != null)
            {
                MessageBox.Show($"Đã thêm hạnh kiểm cho học sinh : {maHocSinh}", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                onSuccess?.Invoke(newId);
            }
        }

        public void HandleUpdateHanhkiem(string id_MaDiem, TextBox maHS, string maLop, TextBox diemTB, TextBox hocLuc, ComboBox hanhKiem, Action onSuccess)
        {
            string maHocSinh = maHS.Text.Trim();
            float DiemHS = float.Parse(diemTB.Text.Trim());
            string HocLuc = hocLuc.Text.Trim();
            string HanhKiem = hanhKiem.Text.Trim();
            if (string.IsNullOrEmpty(maHocSinh))
            {
                MessageBox.Show("Chưa chọn học sinh!");
                return;
            }
            if (string.IsNullOrEmpty(HocLuc))
            {
                MessageBox.Show("Chưa có học lực cho học sinh!");
                return;
            }
            if (string.IsNullOrEmpty(HanhKiem))
            {
                MessageBox.Show("Chưa chọn hạnh kiểm cho học sinh!");
                return;
            }
            bool updated = _diemServices.CapnhatDanhGiaHS(id_MaDiem, maHocSinh, maLop, DiemHS, HocLuc, HanhKiem);
            if (updated)
            {
                MessageBox.Show("Đã cập nhật điểm cho học sinh!");
                onSuccess?.Invoke();
            }
        }
    }
}
