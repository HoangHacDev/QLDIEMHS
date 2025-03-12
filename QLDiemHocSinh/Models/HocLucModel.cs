using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLDiemHocSinh.Models
{
    public class HocLucModel
    {
        public int ID { get; set; }
        public string Value { get; set; }

        public override string ToString()
        {
            return Value; // Hiển thị giá trị trong ComboBox
        }
    }
}
