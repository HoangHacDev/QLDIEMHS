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
    public partial class QLDiem : Form
    {
        private readonly HocSinhHandler _hocSinhHandler;
        private readonly HocSinhSerivces _hocSinhSerivces;
        public QLDiem()
        {
            InitializeComponent();
            ConnectionString connectionString = new ConnectionString();
            _hocSinhSerivces = new HocSinhSerivces(connectionString);
            _hocSinhHandler = new HocSinhHandler(_hocSinhSerivces);

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
        }

        private void LoadDSHocSinh()
        {
            _hocSinhHandler.HandleLoadData(Dgv_DSHocSinh);
        }

        private void Dgv_DSHocSinh_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

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
    }
}
