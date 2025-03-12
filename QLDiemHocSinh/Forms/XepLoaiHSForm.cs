using QLDiemHocSinh.Handlers;
using QLDiemHocSinh.Models;
using QLDiemHocSinh.Services;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace QLDiemHocSinh.Forms
{
    public partial class XepLoaiHSForm : Form
    {
        private readonly string _maHocSinh;
        private readonly string _tenHocSinh;
        private readonly string _HocSinhLop;

        private readonly MonHocServices _monHocServices;
        private readonly DiemServices _diemServices;
        private readonly DiemHocSinhHandler _diemHocSinhHandler;


        public XepLoaiHSForm(string maHocSinh, string tenHocSinh, string hocSinhLop)
        {
            InitializeComponent();
            ConnectionString connectionString = new ConnectionString();
            _monHocServices = new MonHocServices(connectionString);
            _diemServices = new DiemServices(connectionString);
            _diemHocSinhHandler = new DiemHocSinhHandler(_diemServices);

            _maHocSinh = maHocSinh;
            _tenHocSinh = tenHocSinh;
            _HocSinhLop = hocSinhLop;
        }

        private void XepLoaiHSForm_Load(object sender, EventArgs e)
        {
            Txt_MaHS_XL.Text = _maHocSinh;
            Txt_TenHS_XL.Text = _tenHocSinh;

            Txt_MaHS_XL.ReadOnly = true;
            Txt_MaHS_XL.TabStop = false;
            Txt_MaHS_XL.Enabled = false;

            Txt_TenHS_XL.ReadOnly = true;
            Txt_TenHS_XL.TabStop = false;
            Txt_TenHS_XL.Enabled = false;

            Txt_DiemTB3HS.ReadOnly = true;
            Txt_DiemTB3HS.TabStop = false;
            Txt_DiemTB3HS.Enabled = false;

            Txt_HocLuc_XL.ReadOnly = true;
            Txt_HocLuc_XL.TabStop = false;
            Txt_HocLuc_XL.Enabled = false;

            // Trong hàm khởi tạo của form:
            List<HanhKiemItems> hanhKiemItems = new List<HanhKiemItems>()
            {
                new HanhKiemItems { ID = 1, Value = "Tốt" },
                new HanhKiemItems { ID = 2, Value = "Khá" },
                new HanhKiemItems { ID = 3, Value = "Trung Bình" },
                new HanhKiemItems { ID = 4, Value = "Yếu" }
            };

            Cb_HanhKiemHS.DataSource = hanhKiemItems;
            Cb_HanhKiemHS.DisplayMember = "Value"; // Hiển thị thuộc tính Value
            Cb_HanhKiemHS.ValueMember = "Value";    // Sử dụng ID làm giá trị
            Cb_HanhKiemHS.SelectedIndex = -1;

            Dgv_DiemHS.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            Dgv_DiemHS.MultiSelect = false;
            Dgv_DiemHS.AllowUserToAddRows = false;
            Dgv_DiemHS.ReadOnly = true; // Ngăn chỉnh sửa toàn bộ DataGridView

            Dgv_DiemHS.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            Txt_DiemSoHS.KeyPress += Txt_DiemSoHS_KeyPress;
            Txt_DiemSoHS.TextAlign = HorizontalAlignment.Right;

            LoadDanhSachMonHoc(Cb_MonHoc_XL);
            LoadDanhSachLoaiDiem(Cb_LoaiDiem_XL);
            LoadDiemHocSinh();
        }

        private void LoadDanhSachMonHoc(ComboBox cbLopHocHS)
        {
            try
            {
                // Kiểm tra ComboBox có null không
                if (cbLopHocHS == null)
                {
                    throw new ArgumentNullException(nameof(cbLopHocHS), "ComboBox không được null.");
                }

                List<MonHocModel> monHocModels = _monHocServices.GetMonHoc();

                if (monHocModels == null || monHocModels.Count == 0)
                {
                    MessageBox.Show("Không có dữ liệu môn học để hiển thị.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                // Gán dữ liệu cho ComboBox
                cbLopHocHS.DataSource = monHocModels;
                cbLopHocHS.DisplayMember = "TenMH";
                cbLopHocHS.ValueMember = "MaMH";
                cbLopHocHS.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                // Xử lý lỗi nếu có
                MessageBox.Show($"Lỗi khi tải danh sách môn học: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadDanhSachLoaiDiem(ComboBox CbLoaiDiemHS)
        {
            try
            {
                // Kiểm tra ComboBox có null không
                if (CbLoaiDiemHS == null)
                {
                    throw new ArgumentNullException(nameof(CbLoaiDiemHS), "ComboBox không được null.");
                }

                List<LoaiDiemModel> diemHocSinhModels = _diemServices.GetLoaiDiem();

                if (diemHocSinhModels == null || diemHocSinhModels.Count == 0)
                {
                    MessageBox.Show("Không có dữ liệu loại điểm để hiển thị.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                // Gán dữ liệu cho ComboBox
                CbLoaiDiemHS.DataSource = diemHocSinhModels;
                CbLoaiDiemHS.DisplayMember = "TenLoaiDiem";
                CbLoaiDiemHS.ValueMember = "MaLoaiDiem";
                CbLoaiDiemHS.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                // Xử lý lỗi nếu có
                MessageBox.Show($"Lỗi khi tải danh sách loại điểm : {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button4_Click(object sender, EventArgs e)
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

        private void Btn_nhapDiem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Txt_DiemSoHS.Text))
            {
                MessageBox.Show("Vui lòng nhập điểm!");
                return;
            }

            float diemSo = float.Parse(Txt_DiemSoHS.Text); // Đã chặn chữ ở KeyPress nên Parse an toàn
            if (diemSo < 0)
            {
                MessageBox.Show("Điểm không được là số âm!");
                return;
            }

            // Thêm giới hạn trên nếu cần
            if (diemSo > 10)
            {
                MessageBox.Show("Điểm không được lớn hơn 10!");
                return;
            }

            _diemHocSinhHandler.HandleInsert(Txt_MaHS_XL, _HocSinhLop, Cb_MonHoc_XL, Cb_LoaiDiem_XL, Txt_DiemSoHS, newId =>
            {
                _diemHocSinhHandler.HandleLoadData(Dgv_DiemHS, _maHocSinh);
                LoadDiemHocSinh();
            });
        }

        private void Btn_capNhatDFiem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Txt_DiemSoHS.Text))
            {
                MessageBox.Show("Vui lòng nhập điểm!");
                return;
            }

            float diemSo = float.Parse(Txt_DiemSoHS.Text); // Đã chặn chữ ở KeyPress nên Parse an toàn
            if (diemSo < 0)
            {
                MessageBox.Show("Điểm không được là số âm!");
                return;
            }

            // Thêm giới hạn trên nếu cần
            if (diemSo > 10)
            {
                MessageBox.Show("Điểm không được lớn hơn 10!");
                return;
            }

            _diemHocSinhHandler.HandleUpdate(Txt_maDiem.Text ,Txt_MaHS_XL, _HocSinhLop, Cb_MonHoc_XL, Cb_LoaiDiem_XL, Txt_DiemSoHS, () =>
            {
                _diemHocSinhHandler.HandleLoadData(Dgv_DiemHS, _maHocSinh);
                LoadDiemHocSinh();
            });
        }

        private void Btn_XoaDiem_Click(object sender, EventArgs e)
        {
            if (Dgv_DiemHS.CurrentRow != null)
            {
                string id = Txt_maDiem.Text;
                _diemHocSinhHandler.HandleDelete(id, () =>
                {
                    _diemHocSinhHandler.HandleLoadData(Dgv_DiemHS);
                    Cb_MonHoc_XL.SelectedIndex = -1;
                    Cb_LoaiDiem_XL.SelectedIndex = -1;
                    Txt_maDiem.Clear();
                    Txt_DiemSoHS.Clear();
                    LoadDiemHocSinh();
                });
            }
        }

        private void Btn_LoadDS_Click(object sender, EventArgs e)
        {
            _diemHocSinhHandler.HandleLoadData(Dgv_DiemHS, _maHocSinh);
        }

        private void Txt_DiemSoHS_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Chỉ cho phép số, dấu chấm (.) và phím điều khiển (backspace, enter...)
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true; // Chặn ký tự không hợp lệ
                return;
            }

            // Chỉ cho phép 1 dấu chấm
            if (e.KeyChar == '.' && Txt_DiemSoHS.Text.Contains("."))
            {
                e.Handled = true;
                return;
            }
        }

        private void Dgv_DiemHS_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < Dgv_DiemHS.Rows.Count)
            {
                var diemHSList = _diemServices.GetDiemHS(_maHocSinh); // Get the collection once

                if (diemHSList != null && e.RowIndex < diemHSList.Count) // Check for null and valid index
                {
                    Txt_maDiem.Text = diemHSList[e.RowIndex].MaDiem.ToString();
                    Txt_MaHK.Text = diemHSList[e.RowIndex].MaHK.ToString();
                    Txt_DiemSoHS.Text = diemHSList[e.RowIndex].Diem.ToString("0.##");
                    string tenMonHoc = diemHSList[e.RowIndex].TenMH.ToString();
                    string tenLoaiDiem = diemHSList[e.RowIndex].TenLoaiDiem.ToString();
                    string HanhKiem = diemHSList[e.RowIndex].HanhKiem.ToString();


                    if (tenMonHoc != null)
                    {
                        foreach (var item in Cb_MonHoc_XL.Items)
                        {
                            if (item.GetType().GetProperty(Cb_MonHoc_XL.DisplayMember)?.GetValue(item)?.ToString() == tenMonHoc)
                            {
                                Cb_MonHoc_XL.SelectedItem = item; // Chọn giá trị phù hợp trong ComboBox
                                break;
                            }
                        }
                    }
                    else
                    {
                        Cb_MonHoc_XL.SelectedIndex = -1; // Nếu không có giá trị, đặt ComboBox về trạng thái rỗng
                    }

                    if (tenLoaiDiem != null)
                    {
                        foreach (var item in Cb_LoaiDiem_XL.Items)
                        {
                            if (item.GetType().GetProperty(Cb_LoaiDiem_XL.DisplayMember)?.GetValue(item)?.ToString() == tenLoaiDiem)
                            {
                                Cb_LoaiDiem_XL.SelectedItem = item; // Chọn giá trị phù hợp trong ComboBox
                                break;
                            }
                        }
                    }
                    else
                    {
                        Cb_LoaiDiem_XL.SelectedIndex = -1; // Nếu không có giá trị, đặt ComboBox về trạng thái rỗng
                    }

                    if (HanhKiem != null)
                    {
                        foreach (var item in Cb_HanhKiemHS.Items)
                        {
                            if (item.GetType().GetProperty(Cb_HanhKiemHS.DisplayMember)?.GetValue(item)?.ToString() == HanhKiem)
                            {
                                Cb_HanhKiemHS.SelectedItem = item; // Chọn giá trị phù hợp trong ComboBox
                                break;
                            }
                        }
                    }
                    else
                    {
                        Cb_HanhKiemHS.SelectedIndex = -1; // Nếu không có giá trị, đặt ComboBox về trạng thái rỗng
                    }
                }
                else
                {
                    MessageBox.Show("Invalid row index or empty data.");
                }

                //Txt_maDiem.Text = _diemServices.GetDiemHS()[e.RowIndex].MaDiem.ToString();
                //Txt_MaHK.Text = _diemServices.GetDiemHS()[e.RowIndex].MaHK.ToString();
                //Txt_DiemSoHS.Text = _diemServices.GetDiemHS()[e.RowIndex].Diem.ToString("0.##");
                //string tenMonHoc = _diemServices.GetDiemHS()[e.RowIndex].TenMH.ToString();
                //string tenLoaiDiem = _diemServices.GetDiemHS()[e.RowIndex].TenLoaiDiem.ToString();
                //string HanhKiem = _diemServices.GetDiemHS()[e.RowIndex].HanhKiem.ToString();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Cb_MonHoc_XL.SelectedIndex = -1;
            Cb_LoaiDiem_XL.SelectedIndex = -1;
            Txt_maDiem.Clear();
            Txt_DiemSoHS.Clear();
        }

        private void LoadDiemHocSinh()
        {
           DataTable dt = _diemHocSinhHandler.HandleLoadData(Dgv_DiemHS, _maHocSinh);
            if (dt != null && dt.Rows.Count > 0)
            {
                Dictionary<string, List<DiemHocSinhModel>> monHocDiem = new Dictionary<string, List<DiemHocSinhModel>>();

                // Nhóm dữ liệu theo môn học
                foreach (DataRow row in dt.Rows)
                {
                    string tenMonHoc = row["Tên môn học"].ToString();
                    string tenLoaiDiem = row["Loại điểm"].ToString();
                    float diem = Convert.ToSingle(row["Điểm"]);

                    DiemHocSinhModel diemHocSinh = new DiemHocSinhModel
                    {
                        TenMH = tenMonHoc,
                        TenLoaiDiem = tenLoaiDiem,
                        Diem = diem
                    };

                    if (!monHocDiem.ContainsKey(tenMonHoc))
                    {
                        monHocDiem[tenMonHoc] = new List<DiemHocSinhModel>();
                    }

                    monHocDiem[tenMonHoc].Add(diemHocSinh);
                }

                double tongDiemTrungBinh = 0;
                int soLuongMonHoc = monHocDiem.Count;

                // Tính điểm trung bình cho từng môn học
                foreach (var monHoc in monHocDiem)
                {
                    double diemTrungBinhMon = TinhDiemTrungBinhMon(monHoc.Value);
                    tongDiemTrungBinh += diemTrungBinhMon;
                }

                // Tính điểm trung bình chung
                double diemTrungBinhChung = tongDiemTrungBinh / soLuongMonHoc;
                Txt_DiemTB3HS.Text = diemTrungBinhChung.ToString("N2");
                // Xếp loại học lực
                string hocLuc = XepLoaiHocLuc(diemTrungBinhChung);

                // Hiển thị học lực (ví dụ: trong label1)
                Txt_HocLuc_XL.Text = hocLuc;
            }
            else
            {
                Txt_DiemTB3HS.Text = "0.00";
                Txt_HocLuc_XL.Text = " ";
            }

        }

        // Hàm tính điểm trung bình cho từng môn học
        private double TinhDiemTrungBinhMon(List<DiemHocSinhModel> diemMonHoc)
        {
            double diemMieng = 0, diem15Phut = 0, diem1Tiet = 0, diemHocKy = 0;

            foreach (DiemHocSinhModel diem in diemMonHoc)
            {
                if (diem.TenLoaiDiem == "Kiểm tra miệng") diemMieng = diem.Diem;
                else if (diem.TenLoaiDiem == "Kiểm tra 15p") diem15Phut = diem.Diem;
                else if (diem.TenLoaiDiem == "Kiểm tra 1 tiết") diem1Tiet = diem.Diem;
                else if (diem.TenLoaiDiem == "Kiểm tra học kỳ") diemHocKy = diem.Diem;
            }

            return (diemMieng + diem15Phut + diem1Tiet * 2 + diemHocKy * 3) / 7;
        }

        // Hàm xếp loại học lực
        private string XepLoaiHocLuc(double diemTrungBinh)
        {
            if (diemTrungBinh >= 8.0)
            {
                return "Giỏi";
            }
            else if (diemTrungBinh >= 6.5)
            {
                return "Khá";
            }
            else if (diemTrungBinh >= 5.0)
            {
                return "Trung bình";
            }
            else if (diemTrungBinh >= 3.5)
            {
                return "Yếu";
            }
            else
            {
                return "Kém";
            }
        }

        private void Btn_DanhGiaHS_Click(object sender, EventArgs e)
        {

            _diemHocSinhHandler.HandleInsertHanhKiem(Txt_MaHS_XL, _HocSinhLop, Txt_DiemTB3HS, Txt_HocLuc_XL, Cb_HanhKiemHS, newId =>
            {
                _diemHocSinhHandler.HandleLoadData(Dgv_DiemHS, _maHocSinh);
                LoadDiemHocSinh();
            });
        }

        private void Btn_CapNhatHanhKiemHS_Click(object sender, EventArgs e)
        {
            string id = Txt_MaHK.Text;
            _diemHocSinhHandler.HandleUpdateHanhkiem(id, Txt_MaHS_XL, _HocSinhLop, Txt_DiemTB3HS, Txt_HocLuc_XL, Cb_HanhKiemHS, () =>
            {
                _diemHocSinhHandler.HandleLoadData(Dgv_DiemHS, _maHocSinh);
                LoadDiemHocSinh();
            });
        }
    }
}
