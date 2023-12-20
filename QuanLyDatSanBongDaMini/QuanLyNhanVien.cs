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
    public partial class QuanLyNhanVien : Form
    {
        string str = @"Data Source=ANHTU;Initial Catalog = QL_DatSanBongDa; Integrated Security = True";
        SqlConnection connection;
        SqlCommand command;
        SqlDataAdapter adapter = new SqlDataAdapter();
        DataTable table = new DataTable();
        public QuanLyNhanVien()
        {
            InitializeComponent();
            LoadDuLieuG();
        }

        void LoadDuLieuG()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(str))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand("select * from TaiKhoan where ChucVu = 'nhanvien'", connection);
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);
                    dgv_QuanLyNhanVien.DataSource = dataTable;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi khi load dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btn_Thoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void QuanLyNhanVien_Load(object sender, EventArgs e)
        {
            connection = new SqlConnection(str);
            connection.Open();
            LoadDuLieuG();
        }

        private void btn_ThemNhanVien_Click(object sender, EventArgs e)
        {
            try
            {
                string connectionString = @"Data Source=ANHTU;Initial Catalog=QL_DatSanBongDa;Integrated Security=True";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    command = connection.CreateCommand();
                    using (SqlCommand command = connection.CreateCommand())
                    {
                        command.CommandText = "INSERT INTO TaiKhoan (TenDangNhap, MatKhau, ChucVu) VALUES (@TenDangNhap, @MatKhau, @ChucVu)";
                        command.Parameters.AddWithValue("@TenDangNhap", txt_TenTaiKhoan.Text);
                        command.Parameters.AddWithValue("@MatKhau", txt_MatKhau.Text);
                        command.Parameters.AddWithValue("@ChucVu", txt_ChucVu.Text);
                        command.ExecuteNonQuery();
                    }

                }
                LoadDuLieuG();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void dgv_QuanLyNhanVien_SelectionChanged(object sender, EventArgs e)
        {

           
        }

        private void dgv_QuanLyNhanVien_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int i;
            i = dgv_QuanLyNhanVien.CurrentRow.Index;
            txt_MaTaiKhoan.Text = dgv_QuanLyNhanVien.Rows[i].Cells[0].Value.ToString();
            txt_TenTaiKhoan.Text = dgv_QuanLyNhanVien.Rows[i].Cells[1].Value.ToString();
            txt_MatKhau.Text = dgv_QuanLyNhanVien.Rows[i].Cells[2].Value.ToString();
            txt_ChucVu.Text = dgv_QuanLyNhanVien.Rows[i].Cells[3].Value.ToString();

            txt_MaTaiKhoan.Enabled = false;
        }
    }
}
