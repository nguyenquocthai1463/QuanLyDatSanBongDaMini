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
        public partial class QuanLyDichVu : Form
        {
            SqlConnection connection;
            SqlCommand command;
            string str = @"Data Source=DESKTOP-F8192VD\QUOCTHAI;Initial Catalog = QL_DatSanBongDa; Integrated Security = True";
            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable table = new DataTable();


            public QuanLyDichVu()
            {
                InitializeComponent();
            }

            private void loaddata()
            {
                command = connection.CreateCommand();
                command.CommandText = "select * from DichVu";
                adapter.SelectCommand = command;
                table.Clear();
                adapter.Fill(table);
                dataGridView1.DataSource = table;

                // Xóa cột "Tongtien" nếu tồn tại
                RemoveTongTienColumn();

                // Thêm cột mới cho tổng tiền vào DataGridView
                DataGridViewTextBoxColumn colTongTien = new DataGridViewTextBoxColumn();
                colTongTien.HeaderText = "Tổng Tiền";
                colTongTien.Name = "Tongtien";
                dataGridView1.Columns.Add(colTongTien);

                // Tính toán và hiển thị tổng tiền
                CalculateAndDisplayTotalPrice();
            }

            // Hàm để xóa cột "Tongtien" nếu tồn tại
            private void RemoveTongTienColumn()
            {
                if (dataGridView1.Columns.Contains("Tongtien"))
                {
                    dataGridView1.Columns.Remove("Tongtien");
                }
            }



            private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
            {
                int i;
                i = dataGridView1.CurrentRow.Index;
                txtMadv.Text = dataGridView1.Rows[i].Cells[0].Value.ToString();
                cbodv.Text = dataGridView1.Rows[i].Cells[1].Value.ToString();
                txtsoluong.Text = dataGridView1.Rows[i].Cells[2].Value.ToString();
                txtDongia.Text = dataGridView1.Rows[i].Cells[3].Value.ToString();
                txtKhachhang.Text = dataGridView1.Rows[i].Cells[4].Value.ToString();
                CalculateAndDisplayTotalPrice();
            }




            private void QuanLyDichVu_Load_1(object sender, EventArgs e)
            {
                connection = new SqlConnection(str);
                connection.Open();
                loaddata();

                // Ẩn cột "colTongTien" từ đầu
                if (dataGridView1.Columns.Contains("colTongTien"))
                {
                    dataGridView1.Columns["colTongTien"].Visible = true;
                }
            }


       
        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                command = connection.CreateCommand();
                command.CommandText = "INSERT INTO DichVu (TenDichVu, Soluong, DonGia, Tongtien, MaKH) VALUES (@TenDichVu, @Soluong, @DonGia, @Tongtien, @MaKH)";
                command.Parameters.AddWithValue("@TenDichVu", cbodv.Text);
                command.Parameters.AddWithValue("@Soluong", int.Parse(txtsoluong.Text));
                command.Parameters.AddWithValue("@DonGia", double.Parse(txtDongia.Text));

                // Tính toán tổng tiền và thêm vào tham số
                double tongTien = int.Parse(txtsoluong.Text) * double.Parse(txtDongia.Text);
                command.Parameters.AddWithValue("@Tongtien", tongTien);

                command.Parameters.AddWithValue("@MaKH", int.Parse(txtKhachhang.Text));

                command.ExecuteNonQuery();

                // Cập nhật DataGridView và tính toán tổng tiền
                loaddata();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void CalculateAndDisplayTotalPrice()
            {
                try
                {
                    foreach (DataGridViewRow row in dataGridView1.Rows)
                    {
                        if (row.Cells["Soluong"].Value != null && int.TryParse(row.Cells["Soluong"].Value.ToString(), out int soLuong) &&
                            row.Cells["DonGia"].Value != null && double.TryParse(row.Cells["DonGia"].Value.ToString(), out double donGia))
                        {
                            double tongTien = soLuong * donGia;
                            row.Cells["Tongtien"].Value = tongTien.ToString("N0") + " VND";
                        }
                        else
                        {
                            // Nếu giá trị không hợp lệ, đặt giá trị "0 VND" vào cột "Tongtien"
                            row.Cells["Tongtien"].Value = "0 VND";
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Đã xảy ra lỗi khi tính toán tổng tiền: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }






        //private void btnLuu_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        int maDV = Convert.ToInt32(txtMadv.Text);

        //        // Kiểm tra nếu TextBox số lượng đang hiển thị, cập nhật số lượng
        //        if (txtsoluong.Visible)
        //        {
        //            int soLuong = Convert.ToInt32(txtsoluong.Text);
        //            command = connection.CreateCommand();
        //            command.CommandText = "UPDATE DichVu SET Soluong=@Soluong WHERE MaDV=@MaDV";
        //            command.Parameters.AddWithValue("@MaDV", maDV);
        //            command.Parameters.AddWithValue("@Soluong", soLuong);
        //            command.ExecuteNonQuery();
        //        }

        //        MessageBox.Show("Đã cập nhật thông tin thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

        //        // Làm mới các ô
        //        txtMadv.Text = "";
        //        cbodv.Text = "";
        //        txtsoluong.Text = "";
        //        txtDongia.Text = "";
        //        txtKhachhang.Text = "";

        //        // Tải lại dữ liệu để cập nhật DataGridView
        //        loaddata();

        //        // Hiển thị lại tất cả các nút và ẩn nút Lưu
        //        btnThem.Enabled = true;
        //        btnXoa.Enabled = true;
        //        btnSua.Enabled = true;
        //        btnLuu.Visible = true;

        //        // Tính toán và hiển thị tổng tiền
        //        CalculateAndDisplayTotalPrice();
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("Đã xảy ra lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //}

        private void btnLuu_Click(object sender, EventArgs e)
        {
            try
            {
                int maDV = Convert.ToInt32(txtMadv.Text);

                // Kiểm tra nếu TextBox số lượng đang hiển thị, cập nhật số lượng
                if (txtsoluong.Visible)
                {
                    int soLuong = Convert.ToInt32(txtsoluong.Text);
                    command = connection.CreateCommand();
                    command.CommandText = "UPDATE DichVu SET Soluong=@Soluong WHERE MaDV=@MaDV";
                    command.Parameters.AddWithValue("@MaDV", maDV);
                    command.Parameters.AddWithValue("@Soluong", soLuong);
                    command.ExecuteNonQuery();
                }

                MessageBox.Show("Đã cập nhật thông tin thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Làm mới các ô
                txtMadv.Text = "";
                cbodv.Text = "";
                txtsoluong.Text = "";
                txtDongia.Text = "";
                txtKhachhang.Text = "";

                // Tải lại dữ liệu để cập nhật DataGridView
                loaddata();

                // Hiển thị lại tất cả các TextBox và Label
                cbodv.Visible = true;
                txtDongia.Visible = true;
                txtKhachhang.Visible = true;

                // Hiển thị lại nút Sửa
                btnSua.Visible = true;

                // Hiển thị lại nút Lưu
                btnLuu.Visible = true;

                // Hiển thị lại tất cả các nút Thêm, Xóa
                btnThem.Enabled = true;
                btnXoa.Enabled = true;
                btnSua.Enabled = true;

                // Tính toán và hiển thị tổng tiền
                CalculateAndDisplayTotalPrice();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void btnXoa_Click(object sender, EventArgs e)
            {
                try
                {
                    int i;
                    i = dataGridView1.CurrentRow.Index;

                    command = connection.CreateCommand();
                    command.CommandText = "DELETE FROM DichVu WHERE MaDV=@MaDV";
                    command.Parameters.AddWithValue("@MaDV", txtMadv.Text);

                    command.ExecuteNonQuery();

                    loaddata();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Đã xảy ra lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }



   
        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                int i = dataGridView1.CurrentRow.Index;

                // Ẩn các TextBox và Label không cần thiết
                cbodv.Visible = false;
                txtDongia.Visible = false;
                txtKhachhang.Visible = false;

                // Hiển thị TextBox số lượng để chỉnh sửa
                txtsoluong.Visible = true;

                // Hiển thị nút Lưu
                btnLuu.Visible = true;

                // Ẩn nút Sửa
                btnSua.Visible = true;

                // Hiển thị dữ liệu cần sửa
                txtMadv.Text = dataGridView1.Rows[i].Cells[0].Value.ToString();
                cbodv.Text = dataGridView1.Rows[i].Cells[1].Value.ToString();
                txtsoluong.Text = dataGridView1.Rows[i].Cells[2].Value.ToString();
                // Giữ giá trị đơn giá không thay đổi
                txtDongia.Text = dataGridView1.Rows[i].Cells[3].Value.ToString();
                txtKhachhang.Text = dataGridView1.Rows[i].Cells[4].Value.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void btnThoat_Click(object sender, EventArgs e)
            {
                Application.Exit();
            }
        //private void txttongtien_TextChanged(object sender, EventArgs e)
        //{

        //}



        private void grdichvu_Enter(object sender, EventArgs e)
            {

            }


            private void txtsoluong_TextChanged(object sender, EventArgs e)
            {
                // Khi số lượng thay đổi, tính toán và hiển thị tổng tiền
                CalculateAndDisplayTotalPrice();
            }


        }

    }




