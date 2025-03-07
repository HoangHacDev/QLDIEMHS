using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLDiemHocSinh.Models
{
    public class DiemHocSinhModel
    {
        public string MaDiem { get; set; }
        public string MaHS { get; set; }
        public string MaMH { get; set; }
        public string MaLoaiDiem { get; set; }
        public float Diem { get; set; }
        public int HocKy { get; set; }
        public string NamHoc { get; set; }
    }
}
