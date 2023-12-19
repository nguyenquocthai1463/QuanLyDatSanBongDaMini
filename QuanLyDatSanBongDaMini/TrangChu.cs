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
    public partial class TrangChu : Form
    {

        string tenDangNhap = "";
        string tenNhanVien = "";
        string matKhau = "";
        string quyen = "";
        public TrangChu()
        {
            InitializeComponent();
        }

        public TrangChu(string tenDangNhap, string tenNhanVien, string matkhau, string quyen)
        {
            InitializeComponent();
            this.tenDangNhap = tenDangNhap;
            this.tenNhanVien = tenNhanVien;
            this.matKhau = matkhau;
            this.quyen = quyen;
        }

        private void form_quanlynhanvien_Click(object sender, EventArgs e)
        {
            if (quyen == "quanly")
            {
                QuanLyNhanVien f = new QuanLyNhanVien();
                f.ShowDialog();
            }
            else
            {
                MessageBox.Show("Bạn không có quyền truy cập chức năng!", "Thông báo !", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

    }
}
