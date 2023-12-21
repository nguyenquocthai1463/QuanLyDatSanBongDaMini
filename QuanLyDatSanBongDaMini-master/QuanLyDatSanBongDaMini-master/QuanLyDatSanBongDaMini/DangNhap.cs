using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace QuanLyDatSanBongDaMini
{
    public partial class DangNhap : Form
    {
        public DangNhap()
        {
            InitializeComponent();
        }
       
        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            Control ctr = (Control)sender;
            if (ctr.Text.Trim().Length == 0)
                this.errorProvider1.SetError(ctr, "Vui lòng nhập mật khẩu!");
            else
                this.errorProvider1.Clear();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            Control ctr = (Control)sender;
            if (ctr.Text.Trim().Length == 0)
                this.errorProvider1.SetError(ctr, "Vui lòng nhập Tên đăng nhập!");
            else
                this.errorProvider1.Clear();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                TextBox_MatKhau.PasswordChar = (char)0;
            }
            else
            {
                TextBox_MatKhau.PasswordChar = '*';
            }
        }

        private void DangNhap_Load(object sender, EventArgs e)
        {
          
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string chuoiketnoi = "Data Source=DESKTOP-F8192VD\\QUOCTHAI;Initial Catalog=QL_DatSanBongDa;Integrated Security=True";
            using (SqlConnection connection = new SqlConnection(chuoiketnoi))
            {
                connection.Open();

                string query = "SELECT * FROM TaiKhoan WHERE TenDangNhap = @username AND MatKhau = @password";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@username", TextBox_TenTaiKhoan.Text);
                    command.Parameters.AddWithValue("@password", TextBox_MatKhau.Text);

                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        // Đăng nhập thành công
                        QuanLyDichVu quanLyForm = new QuanLyDichVu();
                        this.Hide();
                        quanLyForm.ShowDialog();
                        this.Close();
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

