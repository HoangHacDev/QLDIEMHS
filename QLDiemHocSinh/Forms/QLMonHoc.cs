using QLDiemHocSinh.Handlers;
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

        public QLMonHoc()
        {
            InitializeComponent();
            ConnectionString connectionString = new ConnectionString();
            _nhomMonHocServices = new NhomMonHocServices(connectionString);
            _nhomMonHocHandler = new NhomMonHocHandler(_nhomMonHocServices);
        }

        private void QLMonHoc_Load(object sender, EventArgs e)
        {
            Dgv_NhomMonHoc.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            Dgv_NhomMonHoc.MultiSelect = false;
            Dgv_NhomMonHoc.AllowUserToAddRows = false;
            Dgv_NhomMonHoc.ReadOnly = true; // Ngăn chỉnh sửa toàn bộ DataGridView

            LockFields();
        }

        private void LockFields()
        {
            Txt_MaNhomMH.ReadOnly = true;
            Txt_MaNhomMH.TabStop = false;
            Txt_MaNhomMH.Enabled = false;
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
                Txt_MaNhomMH.Text = _nhomMonHocServices.GetHangHoa()[e.RowIndex].MaNhom;
                Txt_TenNhomMH.Text = row.Cells["Tên nhóm môn"].Value?.ToString() ?? "";
            }
        }
    }
}
