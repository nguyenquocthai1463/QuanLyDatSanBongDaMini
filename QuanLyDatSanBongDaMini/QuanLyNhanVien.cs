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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Tab;

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
            FillChucVuComboBox();
        }

        void LoadDuLieuG()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(str))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand("select MaTK, TenDangNhap, MatKhau, ChucVu from TaiKhoan", connection);
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
            FillChucVuComboBox();
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
                        command.Parameters.AddWithValue("@ChucVu", comboBox_ChucVu.Text);
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

       
        private void FillChucVuComboBox()
        {
            string connectionString = @"Data Source=ANHTU;Initial Catalog=QL_DatSanBongDa;Integrated Security=True";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT DISTINCT ChucVu FROM TaiKhoan";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        List<string> chucVuList = new List<string>();
                        while (reader.Read())
                        {
                            chucVuList.Add(reader["ChucVu"].ToString());
                        }
                        comboBox_ChucVu.DataSource = chucVuList;
                    }
                }
            }
        }

        private void dgv_QuanLyNhanVien_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int i;
            i = dgv_QuanLyNhanVien.CurrentRow.Index;
            txt_MaTaiKhoan.Text = dgv_QuanLyNhanVien.Rows[i].Cells[0].Value.ToString();
            txt_TenTaiKhoan.Text = dgv_QuanLyNhanVien.Rows[i].Cells[1].Value.ToString();
            txt_MatKhau.Text = dgv_QuanLyNhanVien.Rows[i].Cells[2].Value.ToString();
            comboBox_ChucVu.Text = dgv_QuanLyNhanVien.Rows[i].Cells[3].Value.ToString();

            txt_MaTaiKhoan.Enabled = false;
 
        }

        private void btn_Sua_Click(object sender, EventArgs e)
        {

            try
            {
                int i = dgv_QuanLyNhanVien.CurrentRow.Index;

                // Ẩn các TextBox và Label không cần thiết
                txt_MaTaiKhoan.Enabled = false;

                // Hiển thị TextBox số lượng để chỉnh sửa
                txt_MatKhau.Visible = true;
                txt_TenTaiKhoan.Visible = true;
                comboBox_ChucVu.Visible = true;
                // Hiển thị nút Lưu
                btn_Luu.Visible = true;

                // Ẩn nút Sửa
                btn_Sua.Visible = true;
                // Giữ giá trị đơn giá không thay đổi
                txt_MaTaiKhoan.Text = dgv_QuanLyNhanVien.Rows[i].Cells[0].Value.ToString();
                // Hiển thị dữ liệu cần sửa
                txt_TenTaiKhoan.Text = dgv_QuanLyNhanVien.Rows[i].Cells[1].Value.ToString();
                txt_MatKhau.Text = dgv_QuanLyNhanVien.Rows[i].Cells[2].Value.ToString();
                comboBox_ChucVu.Text = dgv_QuanLyNhanVien.Rows[i].Cells[3].Value.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btn_Luu_Click(object sender, EventArgs e)
        {
            try
            {
                int i = dgv_QuanLyNhanVien.CurrentRow.Index;

                // Mở kết nối
                using (SqlConnection connection = new SqlConnection(str))
                {
                    connection.Open();
                    string query = "UPDATE TaiKhoan SET TenDangNhap = @TenDangNhap, MatKhau = @MatKhau, ChucVu = @ChucVu WHERE MaTK = @MaTK";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@TenDangNhap", txt_TenTaiKhoan.Text);
                        command.Parameters.AddWithValue("@MatKhau", txt_MatKhau.Text);
                        command.Parameters.AddWithValue("@ChucVu", comboBox_ChucVu.Text);
                        command.Parameters.AddWithValue("@MaTK", txt_MaTaiKhoan.Text);

                        command.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Lưu thông tin thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadDuLieuG(); // Reload dữ liệu sau khi đã cập nhật
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_Xoa_Click(object sender, EventArgs e)
        {
            try
            {
                int i;
                i = dgv_QuanLyNhanVien.CurrentRow.Index;

                command = connection.CreateCommand();
                command.CommandText = "DELETE FROM TaiKhoan WHERE MaTK=@MaTK";
                command.Parameters.AddWithValue("@MaTK", txt_MaTaiKhoan.Text);
                command.ExecuteNonQuery();
                LoadDuLieuG();
                MessageBox.Show("Xóa thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                txt_MaTaiKhoan.Text = " ";
                txt_TenTaiKhoan.Text = "";
                txt_MatKhau.Text = " ";
                comboBox_ChucVu.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_LamMoi_Click(object sender, EventArgs e)
        {
            txt_MaTaiKhoan.Text = "";
            txt_TenTaiKhoan.Text = "";
            txt_MatKhau.Text = "";
            comboBox_ChucVu.SelectedIndex = -1;

            txt_MaTaiKhoan.Enabled = false;
        }

        private void btn_ChiTiet_Click(object sender, EventArgs e)
        {
            string connectionString = @"Data Source=ANHTU;Initial Catalog=QL_DatSanBongDa;Integrated Security=True";
            // Đảm bảo rằng đã chọn một tài khoản trong DataGridView trước khi nhấn nút "Chi Tiết"
            if (dgv_QuanLyNhanVien.SelectedRows.Count > 0)
            {
                // Lấy mã tài khoản từ cột cần hiển thị (ví dụ: cột "MaTK" có tên là "MaTK")
                string maTaiKhoan = dgv_QuanLyNhanVien.SelectedRows[0].Cells["MaTK"].Value.ToString();

                // Thực hiện truy vấn để lấy thông tin chi tiết tài khoản từ cơ sở dữ liệu dựa trên mã tài khoản
                string query = "SELECT HoVaTen, CanCuocCongDan, SoDienThoai FROM ThongTinTaiKhoan WHERE MaTK = @MaTK";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@MaTK", maTaiKhoan);
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            string hoTen = reader["HoVaTen"].ToString();
                            string canCuocCongDan = reader["CanCuocCongDan"].ToString();
                            string soDienThoai = reader["SoDienThoai"].ToString();

                            // Hiển thị thông tin chi tiết tài khoản trên form mới
                            ChiTietTaiKhoan chiTietForm = new ChiTietTaiKhoan(hoTen, canCuocCongDan, soDienThoai);
                            chiTietForm.Show();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy thông tin chi tiết cho tài khoản này.");
                    }
                    reader.Close();
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một tài khoản trước khi xem chi tiết.");
            }
        }
    }
}
