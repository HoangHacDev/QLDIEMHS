using System;

namespace QLDiemHocSinh.Models
{
    public class GiaoVienModel
    {
        public string MaGV { get; set; }
        public string HoTen { get; set; }
        public DateTime NgaySinh { get; set; }
        public bool GioiTinh { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string SoDienThoai { get; set; }
        public string Message { get; set; }
        public bool IsSuccess { get; set; }
    }
}
