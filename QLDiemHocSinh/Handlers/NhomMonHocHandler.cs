using QLDiemHocSinh.Models;
using QLDiemHocSinh.Services;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLDiemHocSinh.Handlers
{
    public class NhomMonHocHandler
    {
        private readonly NhomMonHocServices _nhomMonHocServices;
        //private readonly ConnectionString _connectionString;

        public NhomMonHocHandler(NhomMonHocServices nhomMonHocServices)
        {
            _nhomMonHocServices = nhomMonHocServices ?? throw new ArgumentNullException(nameof(nhomMonHocServices));
        }

        public void HandleInsert(TextBox txtNhomMH, Action<string> onSuccess)
        {
            string tenNhomMH = txtNhomMH.Text.Trim();

            // Kiểm tra dữ liệu đầu vào
            if (string.IsNullOrEmpty(tenNhomMH))
            {
                MessageBox.Show("Vui lòng nhập tên nhóm môn học!");
                return;
            }

            string newId = _nhomMonHocServices.ThemNhonMH(tenNhomMH);

            if (newId != null)
            {
                MessageBox.Show($"Đã thêm nhóm môn học: {newId}", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtNhomMH.Clear();
                onSuccess?.Invoke(newId);
            }
        }

        public void HandleLoadData(DataGridView dgvMonHoc)
        {
            List<NhomMonHocModel> nhomMonHocs = _nhomMonHocServices.GetNhomMonHoc();
            DataTable dt = new DataTable();
            dt.Columns.Add("STT", typeof(int));
            dt.Columns.Add("MaNhom", typeof(string));
            dt.Columns.Add("Tên nhóm môn", typeof(string));

            for (int i = 0; i < nhomMonHocs.Count; i++)
            {
                dt.Rows.Add(i + 1, nhomMonHocs[i].MaNhom, nhomMonHocs[i].TenNhom);
            }

            dgvMonHoc.DataSource = dt;
            dgvMonHoc.Columns["MaNhom"].Visible = false; // Ẩn cột ID
            dgvMonHoc.Columns["STT"].Width = 50;
            dgvMonHoc.Columns["Tên nhóm môn"].Width = 500;

        }

        public void HandleUpdate(string idNhomMon, TextBox txtTenNhomMon, Action onSuccess)
        {
            string tenNhomMon = txtTenNhomMon.Text.Trim();

            if (string.IsNullOrEmpty(tenNhomMon))
            {
                MessageBox.Show("Vui lòng nhập tên nhóm môn học !");
                return;
            }

            bool updated = _nhomMonHocServices.CapNhapNhomMH(idNhomMon, tenNhomMon);
            if (updated)
            {
                MessageBox.Show("Đã cập nhật nhóm môn học!");
                onSuccess?.Invoke();
            }
        }

        public void HandleDelete(string idNhomMon, Action onSuccess)
        {
            if (string.IsNullOrEmpty(idNhomMon))
            {
                MessageBox.Show("Vui lòng chọn Nhóm môn để xóa!");
                return;
            }

            if (MessageBox.Show("Bạn có chắc muốn xóa Nhóm môn này?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                bool deleted = _nhomMonHocServices.DeleteNhomMon(idNhomMon);
                if (deleted)
                {
                    MessageBox.Show("Đã xóa Nhóm môn học!");
                    onSuccess?.Invoke();
                }
            }
        }
    }
}
