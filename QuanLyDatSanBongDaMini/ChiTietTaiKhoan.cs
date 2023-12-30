using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyDatSanBongDaMini
{
    public partial class ChiTietTaiKhoan : Form
    {
        public ChiTietTaiKhoan(string  hoTen, string canCuoc, string SDT)
        {
            InitializeComponent();
            txtHoVaTen.Text = hoTen;
            txtCCCD.Text = canCuoc;
            txtSDT.Text = SDT;
            // Ẩn khả năng sửa thông tin tài khoản
            txtHoVaTen.Enabled = false;
            txtCCCD.Enabled = false;
            txtSDT.Enabled = false;
        }

        private void ChiTietTaiKhoan_Load(object sender, EventArgs e)
        {

        }
    }
}
