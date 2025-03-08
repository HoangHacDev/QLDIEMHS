using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLDiemHocSinh.Models
{
    public class HocSinhModel
    {
        public string MaHS { get; set; }
        public string HoTen { get; set; }
        public DateTime NgaySinh { get; set; }
        public bool GioiTinh { get; set; }
        public string MaLop { get; set; }
        public string TenLop { get; set; }
    }
}
