using QLDiemHocSinh.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLDiemHocSinh
{
    public partial class GiaoDienChinh : Form
    {
        public GiaoDienChinh()
        {
            InitializeComponent();
        }

        private void lớpHọcToolStripMenuItem_Click(object sender, EventArgs e)
        {
            QLLopHoc qLLopHoc = new QLLopHoc();
            qLLopHoc.ShowDialog();
        }
    }
}
