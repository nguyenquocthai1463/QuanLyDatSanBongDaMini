using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyDatSanBongDaMini
{
    public partial class DangNhap : Form
    {
        public DangNhap()
        {
            InitializeComponent();
        }
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                txt_MatKhau.PasswordChar = (char)0;
            }
            else
            {
                txt_MatKhau.PasswordChar = '*';
            }
        }

        private void DangNhap_Load(object sender, EventArgs e)
        {

        }

        private void txt_TenDangNhap_TextChanged(object sender, EventArgs e)
        {
            Control ctr = (Control)sender;
            if (ctr.Text.Trim().Length == 0)
                this.errorProvider1.SetError(ctr, "Vui lòng nhập Tên đăng nhập!");
            else
                this.errorProvider1.Clear();
        }

        private void txt_MatKhau_TextChanged(object sender, EventArgs e)
        {
            Control ctr = (Control)sender;
            if (ctr.Text.Trim().Length == 0)
                this.errorProvider1.SetError(ctr, "Vui lòng nhập mật khẩu!");
            else
                this.errorProvider1.Clear();
        }

        private void btn_Thoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void DangNhap_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Bạn muốn thoát chương trình? ", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) != System.Windows.Forms.DialogResult.OK)
            {
                e.Cancel = true;
            }
        }

        private void btn_DangNhap_Click(object sender, EventArgs e)
        {

            string chuoiketnoi = "Data Source=ANHTU;Initial Catalog=QL_DatSanBongDa;Integrated Security=True";
            SqlDataAdapter da = new SqlDataAdapter("SELECT *FROM TaiKhoan where TenDangNhap = N'" + txt_TenDangNhap.Text + "' and MatKhau = N'" + txt_MatKhau.Text + "'", chuoiketnoi);
            DataTable dt = new DataTable();
            da.Fill(dt);
            using (SqlConnection connection = new SqlConnection(chuoiketnoi))
            {
                connection.Open();

                string query = "SELECT * FROM TaiKhoan WHERE TenDangNhap = @username AND MatKhau = @password";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@username", txt_TenDangNhap.Text);
                    command.Parameters.AddWithValue("@password", txt_MatKhau.Text);
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        // Đăng nhập thành công
                        MessageBox.Show("Đăng nhập thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        TrangChu quanLyForm = new TrangChu(dt.Rows[0][0].ToString(), dt.Rows[0][1].ToString(), dt.Rows[0][2].ToString(), dt.Rows[0][3].ToString());
                        this.Hide();
                        quanLyForm.ShowDialog();
                        this.Show();
                    }
                    else
                    {
                        MessageBox.Show("Đăng nhập thất bại. Kiểm tra lại tên tài khoản và mật khẩu.");
                    }
                }
            }
        }
    }
}
