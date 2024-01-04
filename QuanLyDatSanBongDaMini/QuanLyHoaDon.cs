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
    public partial class QuanLyHoaDon : Form
    {
        private SqlConnection con;
        private string conStr = "Data Source=MSI\\MSSQLSERVER01;Database=QL_DatSanBongDa;Integrated Security=true";
        SqlCommand command;
        public QuanLyHoaDon()
        {
            InitializeComponent();
            con = new SqlConnection(conStr);
        }
        void HienThiDSHD()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    con.Open();
                    string sql = "SELECT MaHoaDon, TongThanhTien, MaDatSan, MaDV FROM HoaDon";
                    SqlCommand cmd = new SqlCommand(sql, con);
                    SqlDataReader reader = cmd.ExecuteReader();

                    lsv_HD.Items.Clear();

                    while (reader.Read())
                    {
                        ListViewItem item = new ListViewItem(reader["MaHoaDon"].ToString());
                        item.SubItems.Add(reader["TongThanhTien"].ToString());
                        item.SubItems.Add(reader["MaDatSan"].ToString());
                        item.SubItems.Add(reader["MaDV"].ToString());
                        lsv_HD.Items.Add(item);
                    }

                    reader.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi hiển thị danh sách hóa đơn: " + ex.Message);
            }
        }
        void HienThiDSDV()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    con.Open();
                    string sql = "SELECT MaDV,TenDichVu, DonGia FROM DichVu";
                    SqlCommand cmd = new SqlCommand(sql, con);
                    SqlDataReader reader = cmd.ExecuteReader();

                    listView1.Items.Clear();

                    while (reader.Read())
                    {
                        ListViewItem item = new ListViewItem(reader["MaDV"].ToString());
                        item.SubItems.Add(reader["TenDichVu"].ToString());
                        item.SubItems.Add(reader["DonGia"].ToString());
                        listView1.Items.Add(item);
                    }

                    reader.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi hiển thị danh sách dịch vụ: " + ex.Message);
            }
        }

        void HienThiDSSB()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    con.Open();
                    string sql = "SELECT MaSan,TenSan, DonGia FROM San";
                    SqlCommand cmd = new SqlCommand(sql, con);
                    SqlDataReader reader = cmd.ExecuteReader();

                    lsvDSSB.Items.Clear();

                    while (reader.Read())
                    {
                        ListViewItem item = new ListViewItem(reader["MaSan"].ToString());
                        item.SubItems.Add(reader["TenSan"].ToString());
                        item.SubItems.Add(reader["DonGia"].ToString());
                        lsvDSSB.Items.Add(item);
                    }

                    reader.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi hiển thị danh sách sân bóng: " + ex.Message);
            }
        }


        void setNULL()
        {
            txtMahd.Text = "";
            textMaDS.Text = "";
            textMaDV.Text = "";
            txtTongTienHD.Text = "";
            txtSearchSB.Text = "";
            textBox4.Text= "";
            lblKhongTimThayDV.Text = "";
            lblKhongTimThaySB.Text = "";
            txtMahd.Focus();
        }

        private void lsvDSDV_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lsv_HD.SelectedIndices.Count > 0)
            {

                
               txtMahd.Text = lsv_HD.SelectedItems[0].SubItems[0].Text;
               textMaDS.Text = lsv_HD.SelectedItems[0].SubItems[1].Text;
               textMaDV.Text = lsv_HD.SelectedItems[0].SubItems[2].Text;
               txtTongTienHD.Text = lsv_HD.SelectedItems[0].SubItems[3].Text;
            }
        }
        private void btnTongTien_Click(object sender, EventArgs e)
        {
            int maDatSan;
            if (!int.TryParse(textMaDS.Text, out maDatSan))
            {
                MessageBox.Show("Mã đặt sân không hợp lệ!");
                return;
            }

            int maDichVu;
            if (!int.TryParse(textMaDV.Text, out maDichVu))
            {
                MessageBox.Show("Mã dịch vụ không hợp lệ!");
                return;
            }

            double tongTien = TinhTongTien(maDatSan, maDichVu);
            txtTongTienHD.Text = tongTien.ToString("C");
        }

        private double TinhTongTien(int MaDatSan, int MaDV)
        {
            double tongTien = 0;

            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    con.Open();

                    string sql = "SELECT (s.ThanhTien + dv.DonGia) AS TongThanhTien " +
                                 "FROM HoaDon hd " +
                                 "JOIN San s ON hd.MaSan = s.MaSan " +
                                 "JOIN DichVu dv ON hd.MaDV = dv.MaDV " +
                                 "WHERE hd.MaDatSan = @MaDatSan AND hd.MaDV = @MaDV";

                    SqlCommand cmd = new SqlCommand(sql, con);
                    cmd.Parameters.AddWithValue("@MaDatSan", MaDatSan);
                    cmd.Parameters.AddWithValue("@MaDV", MaDV);

                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        object result = reader["TongThanhTien"];
                        if (result != null && result != DBNull.Value)
                        {
                            tongTien = Convert.ToDouble(result);
                        }
                    }
                    reader.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tính tổng tiền hóa đơn: " + ex.Message);
            }

            return tongTien;
        }
        void TimDichVu()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    con.Open();
                    string searchText = textBox4.Text;
                    string sql = "SELECT * FROM DichVu WHERE MaDV LIKE '%' + @SearchText + '%'";
                    SqlCommand cmd = new SqlCommand(sql, con);
                    cmd.Parameters.AddWithValue("@SearchText", searchText);

                    SqlDataReader reader = cmd.ExecuteReader();

                    listView1.Items.Clear();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            ListViewItem lvi = listView1.Items.Add(reader[0].ToString());

                            for (int i = 1; i < reader.FieldCount; i++)
                            {
                                lvi.SubItems.Add(reader[i].ToString());
                            }
                        }
                    }
                    else
                    {
                        lblKhongTimThayDV.Visible = true;
                    }

                    reader.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tìm dịch vụ: " + ex.Message);
            }
        }

        void TimSanBong()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    con.Open();
                    string searchText = txtSearchSB.Text;
                    string sql = "SELECT * FROM San WHERE MaSan LIKE '%' + @SearchText + '%'";
                    SqlCommand cmd = new SqlCommand(sql, con);
                    cmd.Parameters.AddWithValue("@SearchText", searchText);

                    SqlDataReader reader = cmd.ExecuteReader();

                    lsvDSSB.Items.Clear();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            ListViewItem lvi = lsvDSSB.Items.Add(reader[0].ToString());

                            for (int i = 1; i < reader.FieldCount; i++)
                            {
                                lvi.SubItems.Add(reader[i].ToString());
                            }
                        }
                    }
                    else
                    {
                        lblKhongTimThaySB.Visible = true;
                    }

                    reader.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tìm sân bóng: " + ex.Message);
            }
        }


        private void QuanLyHoaDon_Load(object sender, EventArgs e)
        {
            HienThiDSHD();
            HienThiDSDV();
            HienThiDSSB();
        }

        private void lsvDSDV_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }

        private void btnSearchSB_Click(object sender, EventArgs e)
        {
            if (txtSearchSB.Text != "")
            {
                TimSanBong();
            }
            else
            {
                MessageBox.Show("Nhập mã sân bóng cần tìm");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox4.Text != "")
            {
                TimDichVu();
            }
            else
            {
                MessageBox.Show("Nhập mã dich vụ cần tìm");
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            setNULL();
            HienThiDSDV();
            HienThiDSHD();
            HienThiDSSB();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc muốn thoát", "Thoát", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void btnTongtien_Click_1(object sender, EventArgs e)
        {
            int MaDatSan;
            if (!int.TryParse(textMaDS.Text, out MaDatSan))
            {
                MessageBox.Show("Mã đặt sân không hợp lệ!");
                return;
            }

            int MaDV;
            if (!int.TryParse(textMaDV.Text, out MaDV))
            {
                MessageBox.Show("Mã dịch vụ không hợp lệ!");
                return;
            }

            double tongTien = TinhTongTien(MaDatSan, MaDV);
            txtTongTienHD.Text = tongTien.ToString("C");
        }
    }
}
