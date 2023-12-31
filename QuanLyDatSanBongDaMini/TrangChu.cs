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
            //Nếu là quản lý thì được thao tác trên tất cả form ở trang chủ
            if (quyen == "Quản lý")
            {
                QuanLyNhanVien f = new QuanLyNhanVien();
                f.ShowDialog();
            }
            else
            {
                MessageBox.Show("Bạn không có quyền truy cập chức năng!", "Thông báo !", MessageBoxButtons.OK, MessageBoxIcon.Information);
                form_quanlynhanvien.Enabled = false;
            }
        }

        private void form_datsan_Click(object sender, EventArgs e)
        {
            DatSan f = new DatSan();
            f.ShowDialog();
        }

        private void form_thanhtoan_Click(object sender, EventArgs e)
        {

            ThanhToan f = new ThanhToan();
            f.ShowDialog();
        }

        private void form_quanlykhachhang_Click(object sender, EventArgs e)
        {//Nếu là quản lý thì được thao tác trên tất cả form ở trang chủ
            if (quyen == "Quản lý")
            {
                QuanLyKhachHang f = new QuanLyKhachHang();
                f.ShowDialog();
            }
            else
            {
                MessageBox.Show("Bạn không có quyền truy cập chức năng!", "Thông báo !", MessageBoxButtons.OK, MessageBoxIcon.Information);
                form_quanlykhachhang.Enabled = false;
            }
            
        }

        private void btn_DangXuat_Click(object sender, EventArgs e)
        {
            this.Hide(); // Ẩn form hiện tại
            DangNhap dangnhap = new DangNhap();
            dangnhap.Show(); // Mở form đăng nhập
        }

        private void form_quanlyhoadon_Click(object sender, EventArgs e)
        {
            if (quyen == "Quản lý")
            {
                QuanLyHoaDon f = new QuanLyHoaDon();
                f.ShowDialog();
            }
            else
            {
                MessageBox.Show("Bạn không có quyền truy cập chức năng!", "Thông báo !", MessageBoxButtons.OK, MessageBoxIcon.Information);
                form_quanlyhoadon.Enabled = false;
            }
        }

        private void form_quanlydichvu_Click(object sender, EventArgs e)
        {
            if (quyen == "Quản lý")
            {
                QuanLyDichVu f = new QuanLyDichVu();
                f.ShowDialog();
            }
            else
            {
                MessageBox.Show("Bạn không có quyền truy cập chức năng!", "Thông báo !", MessageBoxButtons.OK, MessageBoxIcon.Information);
                form_quanlydichvu.Enabled = false;
            }
        }
    }
}
