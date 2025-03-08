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
    public partial class DangNhapForm : Form
    {

        private readonly GiaoVienSerivces _giaoVienSerivces;

        public DangNhapForm()
        {
            InitializeComponent();

            ConnectionString connectionString = new ConnectionString();
            _giaoVienSerivces = new GiaoVienSerivces(connectionString);
        }

        private void Btn_DangNhap_Click(object sender, EventArgs e)
        {
            // Chạy tác vụ bất đồng bộ mà không chặn UI
            Task.Run(async () =>
            {
                await HandleDangNhapAsync();
            });
        }

        private async Task HandleDangNhapAsync()
        {
            string username = Txt_Username.Text;
            string password = Txt_Password.Text;

            GiaoVienModel result = await _giaoVienSerivces.DangNhapAsync(username, password);

            if (result.IsSuccess)
            {
                // Dùng Invoke để thao tác với UI thread
                this.Invoke((MethodInvoker)delegate
                {
                    MessageBox.Show($"Đăng nhập thành công!");

                    // Tạo instance của form chính (giả sử tên là MainForm)
                    GiaoDienChinh giaoDienChinh = new GiaoDienChinh();

                    // Hiển thị form chính
                    giaoDienChinh.Show();

                    // Ẩn form đăng nhập hiện tại
                    this.Hide();
                    // Hoặc đóng form đăng nhập hoàn toàn: this.Close();
                });

            }
            else
            {
                // Dùng Invoke cho trường hợp lỗi
                this.Invoke((MethodInvoker)delegate
                {
                    MessageBox.Show(result.Message);
                });
            }
        }
    }
}
