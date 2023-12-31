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
        public QuanLyDichVu()
        {
            InitializeComponent();
            this.cbodv.SelectedIndexChanged += new System.EventHandler(this.cbodv_SelectedIndexChanged);
            

            txtTonkho.ReadOnly = true;
            txtMadv.ReadOnly = true;
            txtThanhTien.ReadOnly = true;
        }
        SqlConnection connection;
        SqlCommand command;
        string conStr = "Data Source=MSI\\MSSQLSERVER01;Database=QL_DatSanBongDa;Integrated Security=true";
        SqlDataAdapter adapter = new SqlDataAdapter();
        DataTable table = new DataTable();

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

            //dơn giá
            dataGridView1.Columns["DonGia"].ReadOnly = true;
        }

        private void RemoveTongTienColumn()
        {
            if (dataGridView1.Columns.Contains("Tongtien"))
            {
                dataGridView1.Columns.Remove("Tongtien");
            }
        }
        private void txtKhachhang_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int i;
            i = dataGridView1.CurrentRow.Index;
            txtMadv.Text = dataGridView1.Rows[i].Cells[0].Value.ToString();
            cbodv.Text = dataGridView1.Rows[i].Cells[1].Value.ToString();
            txtsoluong.Text = dataGridView1.Rows[i].Cells[5].Value.ToString();
            txtDongia.Text = dataGridView1.Rows[i].Cells[2].Value.ToString();

            CalculateAndDisplayTotalPrice();
        }

        private void QuanLyDichVu_Load(object sender, EventArgs e)
        {
            connection = new SqlConnection(conStr);
            connection.Open();
            loaddata();

            // Ẩn cột "colTongTien" từ đầu
            if (dataGridView1.Columns.Contains("colTongTien"))
            {
                dataGridView1.Columns["colTongTien"].Visible = true;
            }
        }
        private void CalculateAndDisplayTotalPrice()
        {
            try
            {
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if (row.Cells["SLMua"].Value != null && int.TryParse(row.Cells["SLMua"].Value.ToString(), out int soLuong) &&
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

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                string tenDichVu = cbodv.Text;
                int soLuongThem = int.Parse(txtsoluong.Text);
                double donGia = double.Parse(txtDongia.Text);
                int maKH; // Biến cho Mã Khách Hàng
                if (!int.TryParse(txtMaKH.Text, out maKH)) // Sử dụng TryParse để kiểm tra xem có phải là số hợp lệ hay không
                {
                    MessageBox.Show("Mã khách hàng không hợp lệ.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return; // Dừng thực thi nếu mã khách hàng không hợp lệ
                }

                // Tính toán tổng tiền cho dịch vụ mới
                double tongTien = soLuongThem * donGia;

                // Kiểm tra số lượng tồn kho hiện có từ cơ sở dữ liệu
                command = connection.CreateCommand();
                command.CommandText = "SELECT SoLuongTonKho FROM DichVu WHERE TenDichVu = @TenDichVu";
                command.Parameters.AddWithValue("@TenDichVu", tenDichVu);
                object result = command.ExecuteScalar();

                if (result != null)
                {
                    int soLuongTonKho = Convert.ToInt32(result);

                    // Kiểm tra xem số lượng tồn kho có đủ không
                    if (soLuongTonKho >= soLuongThem)
                    {
                        // Cập nhật số lượng tồn kho mới
                        int soLuongTonKhoMoi = soLuongTonKho - soLuongThem;
                        command.CommandText = "UPDATE DichVu SET SoLuongTonKho = @SoLuongTonKhoMoi WHERE TenDichVu = @TenDichVu";
                        command.Parameters.AddWithValue("@SoLuongTonKhoMoi", soLuongTonKhoMoi);
                        command.ExecuteNonQuery();

                        // Thêm dịch vụ mới vào cơ sở dữ liệu
                        command.CommandText = "INSERT INTO DichVu (TenDichVu, SLMua, DonGia, Tongtien, SoLuongTonKho, MaKH) VALUES (@TenDichVu, @SLMua, @DonGia, @Tongtien, @SoLuongTonKhoMoi, @MaKH)";
                        command.Parameters.Clear();
                        command.Parameters.AddWithValue("@TenDichVu", tenDichVu);
                        command.Parameters.AddWithValue("@SLMua", soLuongThem);
                        command.Parameters.AddWithValue("@DonGia", donGia);
                        command.Parameters.AddWithValue("@Tongtien", tongTien);
                        command.Parameters.AddWithValue("@SoLuongTonKhoMoi", soLuongTonKhoMoi);
                        command.Parameters.AddWithValue("@MaKH", maKH);
                        command.ExecuteNonQuery();

                        // Hiển thị thông báo thành công
                        MessageBox.Show("Thêm dịch vụ thành công và số lượng tồn kho đã được cập nhật!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Không đủ số lượng tồn kho để thêm dịch vụ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    MessageBox.Show("Không tìm thấy dịch vụ trong cơ sở dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (FormatException fe)
            {
                MessageBox.Show("Lỗi định dạng dữ liệu nhập vào: " + fe.Message, "Lỗi Định Dạng", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi khi thêm dịch vụ: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                // Làm mới các trường nhập liệu
                txtMadv.Clear();
                txtMaKH.Clear(); // Làm mới trường Mã Khách Hàng
                cbodv.SelectedIndex = -1;
                txtsoluong.Clear();
                txtDongia.Clear();
                txtTonkho.Clear();

                // Tải lại dữ liệu để cập nhật DataGridView
                loaddata();
            }
        }





        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.CurrentRow != null)
                {
                    // Xác nhận trước khi xóa
                    var confirmResult = MessageBox.Show("Bạn có chắc chắn muốn xóa dịch vụ này không?",
                                                        "Xác nhận xóa!",
                                                        MessageBoxButtons.YesNo,
                                                        MessageBoxIcon.Question);
                    if (confirmResult == DialogResult.Yes)
                    {
                        int i = dataGridView1.CurrentRow.Index;

                        command = connection.CreateCommand();
                        command.CommandText = "DELETE FROM DichVu WHERE MaDV=@MaDV";
                        command.Parameters.AddWithValue("@MaDV", dataGridView1.Rows[i].Cells["MaDV"].Value); // Giả sử cột chứa mã dịch vụ là "MaDV"

                        command.ExecuteNonQuery();

                        // Cập nhật DataGridView
                        loaddata();

                        // Làm mới các ô nhập liệu
                        txtMadv.Text = "";
                        cbodv.SelectedIndex = -1; // hoặc cbodv.Text = "" nếu đây là TextBox
                        txtsoluong.Text = "";
                        txtDongia.Text = "";


                        MessageBox.Show("Dịch vụ đã được xóa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
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

                txtMadv.Text = dataGridView1.Rows[i].Cells["MaDV"].Value.ToString();
                cbodv.Text = dataGridView1.Rows[i].Cells["TenDichVu"].Value.ToString();
                txtsoluong.Text = dataGridView1.Rows[i].Cells["SLMua"].Value.ToString();
                txtDongia.Text = dataGridView1.Rows[i].Cells["DonGia"].Value.ToString();
                txtTonkho.Text = dataGridView1.Rows[i].Cells["SoLuongTonKho"].Value.ToString();
                txtMaKH.Text = dataGridView1.Rows[i].Cells["MaKH"].Value.ToString();

                // Set txtDongia to ReadOnly to prevent editing
                txtDongia.ReadOnly = true;
                txtsoluong.ReadOnly = false;
                txtMaKH.ReadOnly = true; // Nếu bạn cũng không muốn cho phép sửa mã khách hàng

                btnLuu.Enabled = true;
                btnSua.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi khi chuẩn bị sửa dịch vụ: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void btnLuu_Click(object sender, EventArgs e)
        {
            try
            {
                
                int maDV = Convert.ToInt32(txtMadv.Text);
                int newQuantity = Convert.ToInt32(txtsoluong.Text);
                int oldQuantity = Convert.ToInt32(dataGridView1.CurrentRow.Cells["SLMua"].Value);
                int currentStock = Convert.ToInt32(txtTonkho.Text);

           
                int newStockQuantity = currentStock - (newQuantity - oldQuantity);

               
                if (newStockQuantity >= 0)
                {
                    
                    command = connection.CreateCommand();
                    command.CommandText = "UPDATE DichVu SET SLMua=@SLMua, SoLuongTonKho=@SoLuongTonKho WHERE MaDV=@MaDV";
                    command.Parameters.AddWithValue("@MaDV", maDV);
                    command.Parameters.AddWithValue("@SLMua", newQuantity);
                    command.Parameters.AddWithValue("@SoLuongTonKho", newStockQuantity);

                    
                    command.ExecuteNonQuery();

                    
                    MessageBox.Show("Đã cập nhật thông tin và số lượng tồn kho thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    loaddata();

                    btnSua.Enabled = true;
                    btnLuu.Enabled = false;

                    
                    txtMadv.Clear();
                    txtsoluong.Clear();
                    txtDongia.Clear();
                    txtTonkho.Clear();
                    cbodv.SelectedIndex = -1;
                }
                else
                {
                    
                    MessageBox.Show("Số lượng tồn kho không đủ để cập nhật!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (FormatException fe)
            {
                
                MessageBox.Show("Lỗi định dạng dữ liệu nhập vào: " + fe.Message, "Lỗi Định Dạng", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                
                MessageBox.Show("Đã xảy ra lỗi khi cập nhật dịch vụ: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void btnThoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void txtsoluong_TextChanged(object sender, EventArgs e)
        {
            CalculateAndDisplayTotalPrice();
        }

        private void txtTonkho_TextChanged(object sender, EventArgs e)
        {

        }


        private void cbodv_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbodv.SelectedItem != null)
            {
                string selectedServiceName = cbodv.SelectedItem.ToString();

                try
                {
                    // Truy vấn để lấy số lượng tồn kho
                    SqlCommand commandStock = new SqlCommand("SELECT SoLuongTonKho FROM DichVu WHERE TenDichVu = @TenDichVu", connection);
                    commandStock.Parameters.AddWithValue("@TenDichVu", selectedServiceName);
                    var stockResult = commandStock.ExecuteScalar();
                    txtTonkho.Text = stockResult != null ? stockResult.ToString() : "0";

                    // Thêm truy vấn để lấy đơn giá dựa trên tên dịch vụ
                    SqlCommand commandPrice = new SqlCommand("SELECT DonGia FROM DichVu WHERE TenDichVu = @TenDichVu", connection);
                    commandPrice.Parameters.AddWithValue("@TenDichVu", selectedServiceName);
                    var priceResult = commandPrice.ExecuteScalar();

                    // Cập nhật TextBox đơn giá với giá trị lấy được, không có phần thập phân
                    txtDongia.Text = priceResult != null ? Convert.ToDecimal(priceResult).ToString("N0") : "0"; // "N0" định dạng số không có phần thập phân
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error retrieving service price and stock quantity: " + ex.Message);
                }
            }
        }

        private void btnCalculateTotal_Click_1(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtMaKH.Text))
            {
                if (int.TryParse(txtMaKH.Text, out int maKH))
                {
                    // Ensure the customer ID exists in the KhachHang table before attempting to calculate the total.
                    SqlCommand commandCheck = new SqlCommand("SELECT COUNT(*) FROM KhachHang WHERE MaKH = @MaKH", connection);
                    commandCheck.Parameters.AddWithValue("@MaKH", maKH);
                    int exists = (int)commandCheck.ExecuteScalar();

                    if (exists == 0)
                    {
                        MessageBox.Show("Mã khách hàng không tồn tại trong cơ sở dữ liệu.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return; // Exit if the customer ID doesn't exist
                    }

                    SqlCommand command = new SqlCommand("SELECT SUM(Tongtien) FROM DichVu WHERE MaKH = @MaKH", connection);
                    command.Parameters.AddWithValue("@MaKH", maKH);

                    var result = command.ExecuteScalar();

                    if (result != DBNull.Value)
                    {
                        decimal totalAmount = Convert.ToDecimal(result);
                        txtThanhTien.Text = totalAmount.ToString("N0") + " VND";
                    }
                    else
                    {
                        txtThanhTien.Text = "0 VND";
                    }
                }
                else
                {
                    MessageBox.Show("Mã khách hàng không hợp lệ.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("Vui lòng nhập mã khách hàng.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
       


    }
}