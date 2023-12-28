using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyDatSanBongDaMini
{
    public partial class QuanLyKhachHang : Form
    {
        private SqlConnection con;
        private string conStr = "Data Source=MSI\\MSSQLSERVER01;Database=QL_DatSanBongDa;Integrated Security=true";
        SqlCommand command;

        public QuanLyKhachHang()
        {
            InitializeComponent();
            con = new SqlConnection(conStr);
        }
        void HienThiDSKH()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    con.Open();
                    string sql = "SELECT MaKH, HovaTen, SoDienThoai, CanCuocCongDan FROM KhachHang";
                    SqlCommand cmd = new SqlCommand(sql, con);
                    SqlDataReader reader = cmd.ExecuteReader();

                    lsvKH.Items.Clear();

                    while (reader.Read())
                    {
                        ListViewItem item = new ListViewItem(reader["MaKH"].ToString());
                        item.SubItems.Add(reader["HovaTen"].ToString());
                        item.SubItems.Add(reader["SoDienThoai"].ToString());
                        item.SubItems.Add(reader["CanCuocCongDan"].ToString());
                        lsvKH.Items.Add(item);
                    }

                    reader.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi hiển thị danh sách khách hàng: " + ex.Message);
            }
        }
        void setNull()
        {
            txtSearch.Text = "";
            txtPhone.Text = "";
            txtMaKH.Text = "";
            txtHoTen.Text = "";
            txtCCCD.Text = "";
            txtMaKH.Focus();
        }

      
       
        void TimKhachHang()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    con.Open();
                    string searchText = txtSearch.Text;
                    string sql = "SELECT * FROM KhachHang WHERE HoVaTen LIKE '%' + @SearchText + '%'";
                    SqlCommand cmd = new SqlCommand(sql, con);
                    cmd.Parameters.AddWithValue("@SearchText", searchText);

                    SqlDataReader reader = cmd.ExecuteReader();

                    lsvKH.Items.Clear();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            ListViewItem lvi = lsvKH.Items.Add(reader[0].ToString());

                            for (int i = 1; i < reader.FieldCount; i++)
                            {
                                lvi.SubItems.Add(reader[i].ToString());
                            }
                        }
                    }
                    else
                    {
                        lblKhongTimThay.Visible = true;
                    }

                    reader.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tìm khách hàng: " + ex.Message);
            }
        }

       
        bool KiemTraSoDienThoai(string soDienThoai)
        {
            // Loại bỏ các ký tự không phải là chữ số
            string chiSoDienThoai = Regex.Replace(soDienThoai, @"[^\d]", "");

            // Kiểm tra độ dài của số điện thoại
            if (soDienThoai.Length == 10)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        bool KiemtraCanCuocCongDan(string canCuocCongDan)
        {
            // Loại bỏ các ký tự không phải là chữ số
            string chiSoCCCD = Regex.Replace(canCuocCongDan, @"[^\d]", "");

            // Kiểm tra độ dài của số điện thoại
            if (canCuocCongDan.Length == 10)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        int checktrung()
        {
            int chk = 0;
            for (int i = 0; i < lsvKH.Items.Count; i++)
            {
                if (lsvKH.Items[i].SubItems[2].Text == txtPhone.Text)
                {
                    chk = 1;
                    break;
                }
            }
            return chk;
        }
        int checkrong()
        {
            int k = 0;
            if (txtHoTen.Text != "" && txtPhone.Text != "")
            {
                k = 1;

            }
            return k;

        }
        private void btnSearch_Click_1(object sender, EventArgs e)
        {
            btnThem.Enabled = false;

            if (txtSearch.Text != "")
            {
                TimKhachHang();
            }
            else
            {
                MessageBox.Show("Nhập mã khách hàng cần tìm");
            }

        }

        private void lsvKH_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (lsvKH.SelectedIndices.Count > 0)
            {

                btnThem.Enabled = false;
                btnSearch.Enabled = false;
                txtSearch.Enabled = false;
                txtMaKH.Enabled = false;
                txtMaKH.Text = lsvKH.SelectedItems[0].SubItems[0].Text;
                txtHoTen.Text = lsvKH.SelectedItems[0].SubItems[1].Text;
                txtPhone.Text = lsvKH.SelectedItems[0].SubItems[2].Text;
                txtCCCD.Text = lsvKH.SelectedItems[0].SubItems[3].Text;
            }
        }

        private void gbKH_Enter(object sender, EventArgs e)
        {

        }

        private void QuanLyKhachHang_Load_1(object sender, EventArgs e)
        {
            txtMaKH.Enabled = false;

            HienThiDSKH();
        }

        private void btnThem_Click_1(object sender, EventArgs e)
        {
            if (checkrong() == 1)
            {
                if (KiemTraSoDienThoai(txtPhone.Text) && KiemtraCanCuocCongDan(txtCCCD.Text))
                {
                    try
                    {
                        using (SqlConnection con = new SqlConnection(conStr))
                        {
                            
                            con.Open();

                            // Kiểm tra xem số điện thoại hoặc số căn cước công dân đã tồn tại trong cơ sở dữ liệu hay chưa
                            string checkDuplicateQuery = "SELECT COUNT(*) FROM KhachHang WHERE SoDienThoai = @SoDienThoai OR CanCuocCongDan = @CanCuocCongDan";
                            SqlCommand checkDuplicateCmd = new SqlCommand(checkDuplicateQuery, con);
                            checkDuplicateCmd.Parameters.AddWithValue("@SoDienThoai", txtPhone.Text);
                            checkDuplicateCmd.Parameters.AddWithValue("@CanCuocCongDan", txtCCCD.Text);
                            int duplicateCount = (int)checkDuplicateCmd.ExecuteScalar();

                            if (duplicateCount == 0)
                            {
                                // Thực hiện câu truy vấn INSERT
                                string insertQuery = "INSERT INTO KhachHang (HovaTen, SoDienThoai, CanCuocCongDan) VALUES (@HovaTen, @SoDienThoai, @CanCuocCongDan)";
                                SqlCommand insertCmd = new SqlCommand(insertQuery, con);
                                insertCmd.Parameters.AddWithValue("@HovaTen", txtHoTen.Text);
                                insertCmd.Parameters.AddWithValue("@SoDienThoai", txtPhone.Text);
                                insertCmd.Parameters.AddWithValue("@CanCuocCongDan", txtCCCD.Text);
                                insertCmd.ExecuteNonQuery();

                                MessageBox.Show("Thêm mới Khách hàng thành công");
                                HienThiDSKH();
                                setNull();
                            }
                            else
                            {
                                MessageBox.Show("Số điện thoại hoặc số căn cước công dân đã tồn tại");
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi khi thêm mới Khách hàng: " + ex.Message);
                    }
                }
                else
                {
                    MessageBox.Show("Số điện thoại hoặc Căn cước công dân không đúng định dạng (phải có 10 chữ số).");
                    txtPhone.Focus();
                    txtCCCD.Focus();
                }
            }
            else
            {
                lblCB.Visible = true;
            }
        }

        private void btnXoa_Click_1(object sender, EventArgs e)
        {
            if (lsvKH.SelectedIndices.Count > 0)
            {
                try
                {
                    using (SqlConnection con = new SqlConnection(conStr))
                    {
                        con.Open();
                        string maKH = lsvKH.SelectedItems[0].SubItems[0].Text;
                        string sql = "DELETE FROM KhachHang WHERE MaKH = @MaKH";
                        SqlCommand cmd = new SqlCommand(sql, con);
                        cmd.Parameters.AddWithValue("@MaKH", maKH);
                        cmd.ExecuteNonQuery();

                        lsvKH.Items.RemoveAt(lsvKH.SelectedIndices[0]);
                        MessageBox.Show("Xóa khách hàng '" + maKH + "' thành công!");
                        setNull();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi xóa khách hàng: " + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn khách hàng cần xóa");
            }
        }

        private void btnSua_Click_1(object sender, EventArgs e)
        {
            if (lsvKH.SelectedIndices.Count > 0)
            {
                try
                {
                    if (KiemTraSoDienThoai(txtPhone.Text) && KiemtraCanCuocCongDan(txtCCCD.Text))
                    {
                        using (SqlConnection con = new SqlConnection(conStr))
                        {
                            con.Open();
                            string maKH = lsvKH.SelectedItems[0].SubItems[0].Text;

                            // Kiểm tra xem số điện thoại hoặc số căn cước công dân đã tồn tại trong cơ sở dữ liệu hay chưa
                            string checkDuplicateQuery = "SELECT COUNT(*) FROM KhachHang WHERE (SoDienThoai = @SoDienThoai OR CanCuocCongDan = @CanCuocCongDan) AND MaKH != @MaKH";
                            SqlCommand checkDuplicateCmd = new SqlCommand(checkDuplicateQuery, con);
                            checkDuplicateCmd.Parameters.AddWithValue("@SoDienThoai", txtPhone.Text);
                            checkDuplicateCmd.Parameters.AddWithValue("@CanCuocCongDan", txtCCCD.Text);
                            checkDuplicateCmd.Parameters.AddWithValue("@MaKH", maKH);
                            int duplicateCount = (int)checkDuplicateCmd.ExecuteScalar();

                            if (duplicateCount == 0)
                            {
                                string sql = "UPDATE KhachHang SET HovaTen = @HoTen, SoDienThoai = @Phone, CanCuocCongDan = @CCCD WHERE MaKH = @MaKH";
                                SqlCommand cmd = new SqlCommand(sql, con);
                                cmd.Parameters.AddWithValue("@HoTen", txtHoTen.Text);
                                cmd.Parameters.AddWithValue("@Phone", txtPhone.Text);
                                cmd.Parameters.AddWithValue("@CCCD", txtCCCD.Text);
                                cmd.Parameters.AddWithValue("@MaKH", maKH);
                                cmd.ExecuteNonQuery();

                                MessageBox.Show("Cập nhật khách hàng '" + maKH + "' thành công");
                                HienThiDSKH();
                                setNull();
                            }
                            else
                            {
                                MessageBox.Show("Số điện thoại hoặc số căn cước công dân đã tồn tại");
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Số điện thoại hoặc Căn cước công dân không đúng định dạng (phải có 10 chữ số).");
                        txtPhone.Focus();
                        txtCCCD.Focus();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi cập nhật khách hàng: " + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn khách hàng muốn cập nhật");
            }
        }

        private void btnHuy_Click_1(object sender, EventArgs e)
        {
            setNull();
            txtMaKH.Enabled = false;
            btnSearch.Enabled = true;
            btnSua.Enabled = true;
            btnThem.Enabled = true;
            btnXoa.Enabled = true;
            txtSearch.Enabled = true;
            HienThiDSKH();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc muốn thoát", "Thoát", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                this.Close();
            }
        }
        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
