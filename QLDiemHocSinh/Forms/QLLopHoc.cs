using QLDiemHocSinh.Handlers;
using QLDiemHocSinh.Services;
using System;
using System.Windows.Forms;

namespace QLDiemHocSinh.Forms
{
    public partial class QLLopHoc : Form
    {
        private readonly LopHocHandler _lopHocHandler;
        private readonly LopHocServices _lopHocServices;
        public QLLopHoc()
        {
            InitializeComponent();
            ConnectionString connectionString = new ConnectionString();
            _lopHocServices = new LopHocServices(connectionString);
            _lopHocHandler = new LopHocHandler(_lopHocServices);
        }

        private void QLLopHoc_Load(object sender, EventArgs e)
        {
            Dgv_LopHoc.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            Dgv_LopHoc.MultiSelect = false;
            Dgv_LopHoc.AllowUserToAddRows = false;
            Dgv_LopHoc.ReadOnly = true; // Ngăn chỉnh sửa toàn bộ DataGridView

            LockFields();
        }

        private void LockFields()
        {
            Txt_MaLopHoc.ReadOnly = true;
            Txt_MaLopHoc.TabStop = false;
            Txt_MaLopHoc.Enabled = false;
        }

        private void Btn_ThemLopHoc_Click(object sender, EventArgs e)
        {
            _lopHocHandler.HandleInsert(Txt_TenLopHoc, DTP_NamHoc.Value, Txt_KhoiLH, newId =>
            {
                _lopHocHandler.HandleLoadData(Dgv_LopHoc);
            });
        }

        private void Btn_XoaLopHoc_Click(object sender, EventArgs e)
        {
            if (Dgv_LopHoc.CurrentRow != null)
            {
                string id = Txt_MaLopHoc.Text;
                _lopHocHandler.HandleDelete(id, () =>
                {
                    _lopHocHandler.HandleLoadData(Dgv_LopHoc);
                    ClearDuLieu();
                });
            }
        }

        private void ClearDuLieu()
        {
            Txt_MaLopHoc.Clear();
            DTP_NamHoc.Value = DateTime.Now;
            Txt_TenLopHoc.Clear();
            Txt_KhoiLH.Clear();
        }

        private void Btn_SuaLopHoc_Click(object sender, EventArgs e)
        {
            if (Dgv_LopHoc.CurrentRow != null)
            {
                string id = Txt_MaLopHoc.Text;
                _lopHocHandler.HandleUpdate(id, Txt_TenLopHoc, DTP_NamHoc.Value, Txt_KhoiLH, () =>
                {
                    _lopHocHandler.HandleLoadData(Dgv_LopHoc);
                });
            }
        }

        private void Btn_LoadHSLopHoc_Click(object sender, EventArgs e)
        {
            _lopHocHandler.HandleLoadData(Dgv_LopHoc);
        }

        private void Btn_HuyDL_Click(object sender, EventArgs e)
        {
            Txt_TenLopHoc.Clear();
            Txt_MaLopHoc.Clear();
            DTP_NamHoc.Value = DateTime.Now;
            Txt_KhoiLH.Clear();
        }

        private void Btn_ThoatLopHoc_Click(object sender, EventArgs e)
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

        private void Dgv_LopHoc_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < Dgv_LopHoc.Rows.Count)
            {
                DataGridViewRow row = Dgv_LopHoc.Rows[e.RowIndex];
                Txt_MaLopHoc.Text = _lopHocServices.GetLopHoc()[e.RowIndex].MaLop;
                Txt_TenLopHoc.Text = row.Cells["Tên lớp học"].Value?.ToString() ?? "";
                DTP_NamHoc.Text = row.Cells["Năm Học"].Value?.ToString() ?? "";
                Txt_KhoiLH.Text = row.Cells["Khối"].Value?.ToString() ?? "";

            }
        }
    }
}
