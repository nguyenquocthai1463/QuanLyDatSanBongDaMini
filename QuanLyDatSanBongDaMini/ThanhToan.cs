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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace QuanLyDatSanBongDaMini
{
    public partial class ThanhToan : Form
    {
        SqlConnection connection;
        SqlCommand command;
        string str = @"Data Source=TRIS72;Initial Catalog=QL_DatSanBongDa;Integrated Security=True";
        SqlDataAdapter adapter = new SqlDataAdapter();
        DataTable table = new DataTable();
        DataTable table1 = new DataTable();
        DataTable table2 = new DataTable();
        void loaddata()
        {

            command = connection.CreateCommand();
            command.CommandText = "select * from HoaDon";
            adapter.SelectCommand = command;
            table.Clear();
            adapter.Fill(table);
            dataGridView1.DataSource = table;

        }
        void loaddata2()
        {
            command = connection.CreateCommand();
            command.CommandText = "select * from DichVu";
            adapter.SelectCommand = command;
            table1.Clear();
            adapter.Fill(table1);
            dataGridView2.DataSource = table1;
        }

        void loaddata3()
        {
            command = connection.CreateCommand();
            command.CommandText = "select * from DatSan";
            adapter.SelectCommand = command;
            table2.Clear();
            adapter.Fill(table2);
            dataGridView3.DataSource = table2;
        }
        public ThanhToan()
        {
            InitializeComponent();
         
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
       
        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void ThanhToan_Load(object sender, EventArgs e)
        {
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView3.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            connection = new SqlConnection(str);
            connection.Open();
            loaddata();
            loaddata2();
            loaddata3();
            bingding();
        }

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
        }

        public void bingding()
        {
            textBox1.DataBindings.Clear();
            textBox1.DataBindings.Add("Text", dataGridView1.DataSource, "MaHoaDon");

            textBox2.DataBindings.Clear();
            textBox2.DataBindings.Add("Text", dataGridView1.DataSource, "TongThanhTien");

            textBox3.DataBindings.Clear();
            textBox3.DataBindings.Add("Text", dataGridView1.DataSource, "MaKH");


        }

      

        private void button2_Click_1(object sender, EventArgs e)
        {
            command = new SqlCommand("SELECT SUM(TongTien) FROM DichVu WHERE MaKH = @MaKhachHang", connection);

            // Lấy mã dịch vụ
            string maKhachHang = textBox3.Text;

            //// Lấy số lượng dịch vụ
            //int soLuongDichVu = Convert.ToInt32(textBox3.Text);

            // Gán mã dịch vụ và số lượng dịch vụ cho các biến tương ứng trong đối tượng SqlCommand
            command.Parameters.AddWithValue("@MaKhachHang", maKhachHang);

            // Thực thi truy vấn SELECT
            SqlDataReader reader = command.ExecuteReader();

            if (reader.Read())
            {
                //double giaTienDichVu = Convert.ToDouble(reader["TongTien"]);
                double giaTienDichVu = Convert.ToDouble(reader[0]);

                // Tính tiền dịch vụ
                //double tienDichVu = giaTienDichVu * soLuongDichVu;
                /*double tienDichVu = giaTienDichVu */;

                // Hiển thị tiền dịch vụ trên giao diện người dùng
                //textBox6.Text = tienDichVu.ToString();
                textBox6.Text = giaTienDichVu.ToString();

            }
            else
            {
                MessageBox.Show("Mã khách hàng không hợp lệ");
            }
            reader.Close();

            //command = new SqlCommand("SELECT TienSan FROM DatSan WHERE MaDatSan = @MaDatSan", connection);

            //// Lấy mã đặt sân
            //string maDatSan = textBox4.Text;

            //// Gán mã đặt sân cho tham số trong truy vấn
            //command.Parameters.AddWithValue("@MaDatSan", maDatSan);

            //// Thực thi truy vấn SELECT
            //SqlDataReader reader1 = command.ExecuteReader();

            //if (reader1.Read())
            //{
            //    double giaTienSan = Convert.ToDouble(reader1["TienSan"]);

            //    // Hiển thị giá tiền sân trên giao diện người dùng
            //    textBox7.Text = giaTienSan.ToString();
            //}
            //else
            //{
            //    MessageBox.Show("Mã đặt sân không hợp lệ!");
            //}
            //reader1.Close();

            //double tienDichVu1 = Convert.ToDouble(textBox6.Text);
            //double giaTienSan1 = Convert.ToDouble(textBox7.Text);
            //double tongTien = tienDichVu1 + giaTienSan1;
            //textBox2.Text = tongTien.ToString();


            command = new SqlCommand("SELECT SUM(ThanhTien) FROM DatSan WHERE MaKH = @MaKhachHang", connection);

            // Lấy mã đặt sân
            //string maDatSan = textBox4.Text;

            // Gán mã đặt sân cho tham số trong truy vấn
            command.Parameters.AddWithValue("@MaKhachHang", maKhachHang);

            // Thực thi truy vấn SELECT
            SqlDataReader reader1 = command.ExecuteReader();

            if (reader1.Read())
            {
                double giaTienSan = Convert.ToDouble(reader1[0]);

                // Hiển thị giá tiền sân trên giao diện người dùng
                textBox7.Text = giaTienSan.ToString();
            }
            else
            {
                MessageBox.Show("Mã khách hàng không hợp lệ!");
            }
            reader1.Close();

            double tienDichVu1 = Convert.ToDouble(textBox6.Text);
            double giaTienSan1 = Convert.ToDouble(textBox7.Text);
            double tongTien = tienDichVu1 + giaTienSan1;
            textBox2.Text = tongTien.ToString();

            dataGridView1.Refresh();

            connection.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {



        }

        //void buttonluusua()
        //{

        //    if (connection.State == ConnectionState.Closed)
        //    {
        //        // Mở kết nối CSDL
        //        connection.Open();
        //    }

        //    // Tạo đối tượng SqlCommand
        //    //SqlCommand command = new SqlCommand("UPDATE HoaDon SET SoLuongDichVu = @SoLuongDichVu, MaDatSan = @MaDatSan, MaDichVu = @MaDichVu, TongThanhTien = @TongThanhTien WHERE MaHoaDon = @MaHoaDon", connection);
        //    SqlCommand command = new SqlCommand("UPDATE HoaDon SET  TongThanhTien = @TongThanhTien WHERE MaKH = @MaKhachHang", connection);

        //    // Lấy giá trị từ các textbox
        //    string maHoaDon = textBox1.Text;
        //    //int soLuongDichVu = Convert.ToInt32(textBox3.Text);
        //    //string maDatSan = textBox4.Text;
        //    //string maDichVu = textBox5.Text;
        //    double tongTien = Convert.ToDouble(textBox2.Text);

        //    // Gán giá trị cho các biến trong đối tượng SqlCommand
        //    command.Parameters.AddWithValue("@MaHoaDon", maHoaDon);
        //    //command.Parameters.AddWithValue("@SoLuongDichVu", soLuongDichVu);
        //    //command.Parameters.AddWithValue("@MaDatSan", maDatSan);
        //    //command.Parameters.AddWithValue("@MaDichVu", maDichVu);
        //    command.Parameters.AddWithValue("@TongThanhTien", tongTien);

        //    // Thực thi truy vấn UPDATE
        //    command.ExecuteNonQuery();

        //    // Cập nhật dữ liệu trong datagridview
        //    dataGridView1.Refresh();

        //    loaddata();

        //    // Đóng kết nối
        //    connection.Close();
        //}

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
     
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            
 

            // Tạo đối tượng SqlCommand
            //SqlCommand command = new SqlCommand("INSERT INTO HoaDon (SoLuongDichVu, MaDatSan, MaDichVu, TongThanhTien) VALUES (@SoLuongDichVu, @MaDatSan, @MaDichVu, @TongThanhTien); SELECT SCOPE_IDENTITY();", connection);
            SqlCommand command = new SqlCommand("INSERT INTO HoaDon ( TongThanhTien, MaKH) VALUES (@TongThanhTien, @MaKhachHang); SELECT SCOPE_IDENTITY();", connection);

            // Lấy giá trị từ các textbox
            //int soLuongDichVu = Convert.ToInt32(textBox3.Text);
            //string maDatSan = textBox4.Text;
            //string maDichVu = textBox5.Text;
            double tongTien = Convert.ToDouble(textBox2.Text);
            double maKhachHang = Convert.ToDouble(textBox3.Text);

            // Gán giá trị cho các biến trong đối tượng SqlCommand
            //command.Parameters.AddWithValue("@SoLuongDichVu", soLuongDichVu);
            //command.Parameters.AddWithValue("@MaDatSan", maDatSan);
            //command.Parameters.AddWithValue("@MaDichVu", maDichVu);
            command.Parameters.AddWithValue("@TongThanhTien", tongTien);
            command.Parameters.AddWithValue("@MaKhachHang", maKhachHang);

            //// Mở kết nối CSDL
            //connection.Open();

            //// Thực thi truy vấn INSERT và lấy giá trị khóa chính tự động tăng
            //int maHoaDon = Convert.ToInt32(command.ExecuteScalar());

            //dataGridView1.Refresh();
            //// Đóng kết nối
            //connection.Close();

            //// Thực hiện các bước cập nhật datagridview hoặc các công việc khác sau khi thêm dữ liệu
            ///


            // Mở kết nối CSDL
            connection.Open();

            try
            {
                // Thực thi truy vấn INSERT và lấy giá trị khóa chính tự động tăng
                int maHoaDon = Convert.ToInt32(command.ExecuteScalar());

                dataGridView1.Refresh();
                MessageBox.Show("Xuất hóa đơn thành công!");
            }
            catch (Exception ex)
            {
                //MessageBox.Show("Không thể thêm dữ liệu. Lỗi: " + ex.Message);
                MessageBox.Show("Lỗi : Không thể xuất hóa đơn ");
            }
            dataGridView1.Refresh();

            loaddata();
            // Đóng kết nối
            connection.Close();


        }

        private void button5_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            //textBox4.Text = "";
            //textBox5.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
