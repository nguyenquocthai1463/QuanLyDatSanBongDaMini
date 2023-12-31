using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace QuanLyDatSanBongDaMini
{
    public partial class DatSan : Form
    {
        SqlConnection conn;
        DataSet ds_kh = new DataSet();
        DataSet ds_san = new DataSet();
        public DatSan()
        {
            conn = new SqlConnection("Data Source = LAPTOP-BUP1NJ3A\\NGUYENQUOCTHAI; Database = QL_DatSanBongDa; Integrated Security = true");
            InitializeComponent();
        }

        void LoadDuLieuKH()
        {
            string strsel = "select * from KhachHang";
            SqlDataAdapter da_kh = new SqlDataAdapter(strsel, conn);
            da_kh.Fill(ds_kh, "KhachHang");
            cb_kh.DataSource = ds_kh.Tables["KhachHang"];
            cb_kh.DisplayMember = "HoVaTen";
            cb_kh.ValueMember = "MaKH";
        }

        void LoadDuLieuSan()
        {
            string strsel = "select * from San";
            SqlDataAdapter da_san = new SqlDataAdapter(strsel, conn);
            da_san.Fill(ds_san, "San");
            cb_san.DataSource = ds_san.Tables["San"];
            cb_san.DisplayMember = "TenSan";
            cb_san.ValueMember = "MaSan";
        }

        private bool KiemTraLichTrung(DateTime gioDat, DateTime gioTra, int maSan)
        {
            conn.Open();
            string query = "SELECT COUNT(*) FROM DatSan WHERE MaSan = @MaSan AND ((@GioDat BETWEEN GioDat AND GioTra) OR (@GioTra BETWEEN GioDat AND GioTra))";
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@MaSan", maSan);
                cmd.Parameters.AddWithValue("@GioDat", gioDat);
                cmd.Parameters.AddWithValue("@GioTra", gioTra);
                int overlapCount = (int)cmd.ExecuteScalar();
                return overlapCount > 0;
            }
        }

        void LoadTienSan()
        {
            float tiensan = (float)giodat.Value * 300000;
            tb_tiensan.Text = tiensan.ToString();
        }

        void HienThiDSDS()
        {
            try
            {
                conn.Open();
                string sql = "SELECT * FROM DatSan";
                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataReader reader = cmd.ExecuteReader();

                lv_datsan.Items.Clear();

                while (reader.Read())
                {
                    ListViewItem item = new ListViewItem(reader["MaDatSan"].ToString());
                    item.SubItems.Add(reader["MaSan"].ToString());
                    item.SubItems.Add(reader["MaKH"].ToString());
                    item.SubItems.Add(reader["GioDat"].ToString());
                    item.SubItems.Add(reader["SoGioDat"].ToString());
                    item.SubItems.Add(reader["GioTra"].ToString());
                    item.SubItems.Add(reader["ThanhTien"].ToString());
                    lv_datsan.Items.Add(item);
                }
                reader.Close();
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi hiển thị danh sách đặt sân" + ": " + ex.Message);
            }
        }

        void setnull()
        {
            cb_san.SelectedIndex = 0;
            cb_kh.SelectedIndex = 0;
            nhansan.ResetText();
            giodat.Value = 0;
            tb_tiensan.Text = "";
            bt_xoa.Enabled = bt_sua.Enabled = false;
        }

        void TimLichDatSan()
        {
            try
            {
                conn.Open();
                string searchText = tb_search.Text;
                string sql = "SELECT * FROM DatSan WHERE MaDatSan LIKE '%' + @SearchText + '%'";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@SearchText", searchText);

                SqlDataReader reader = cmd.ExecuteReader();

                lv_datsan.Items.Clear();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        ListViewItem lvi = lv_datsan.Items.Add(reader[0].ToString());

                        for (int i = 1; i < reader.FieldCount; i++)
                        {
                            lvi.SubItems.Add(reader[i].ToString());
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Lỗi khi tìm lịch đặt sân! ");
                }

                reader.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tìm lịch đặt sân! " + ex.Message);
            }
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void DatSan_Load(object sender, EventArgs e)
        {
            LoadDuLieuKH();
            LoadDuLieuSan();
            HienThiDSDS();
            tb_masan.Enabled = tb_makh.Enabled = tb_tiensan.Enabled = trasan.Enabled = flowLayoutPanel1.Enabled = bt_sua.Enabled = bt_xoa.Enabled = false;
        }

        private void cb_kh_SelectedIndexChanged(object sender, EventArgs e)
        {
            tb_makh.Text = cb_kh.SelectedValue.ToString();
        }

        private void cb_san_SelectedIndexChanged(object sender, EventArgs e)
        {
            tb_masan.Text = cb_san.SelectedValue.ToString();
        }

        private void nhansan_ValueChanged(object sender, EventArgs e)
        {

        }

        private void trasan_ValueChanged(object sender, EventArgs e)
        {

        }

        private void giodat_ValueChanged(object sender, EventArgs e)
        {
            trasan.Value = nhansan.Value.AddHours((double)giodat.Value);
            LoadTienSan();
        }

        private void lv_datsan_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lv_datsan.SelectedIndices.Count > 0)
            {
                bt_sua.Enabled = bt_xoa.Enabled = true;
                tb_masan.Text = lv_datsan.SelectedItems[0].SubItems[1].Text;
                tb_makh.Text = lv_datsan.SelectedItems[0].SubItems[2].Text;
                nhansan.Text = lv_datsan.SelectedItems[0].SubItems[3].Text;
                giodat.Text = lv_datsan.SelectedItems[0].SubItems[4].Text;
                trasan.Text = lv_datsan.SelectedItems[0].SubItems[5].Text;
                tb_tiensan.Text = lv_datsan.SelectedItems[0].SubItems[6].Text;
            }
        }

        private void bt_datsan_Click(object sender, EventArgs e)
        {
            DateTime nhan = nhansan.Value;
            DateTime tra = trasan.Value;
            int masan = Int32.Parse(tb_masan.Text);
            int makh = Int32.Parse(tb_makh.Text);
            int tiensan = Int32.Parse(tb_tiensan.Text);
            if(nhansan.Value < DateTime.Now.AddHours(2))
            {
                MessageBox.Show("Thời gian đặt sân không hợp lệ, vui lòng đặt sân trước thời điểm hiện tại 2h!");
                nhansan.Focus();
                return;
            }
            if (KiemTraLichTrung(nhan, tra, masan) == false)
            {
                try
                {
                    bt_datsan.Enabled = false;
                    string sql = "INSERT INTO DatSan (GioDat, SoGioDat, GioTra, ThanhTien, MaSan, MaKH) VALUES (@GioDat, @SoGioDat, @GioTra, @ThanhTien, @MaSan, @MaKH)";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@GioDat", nhan);
                    cmd.Parameters.AddWithValue("@SoGioDat", giodat.Value);
                    cmd.Parameters.AddWithValue("@GioTra", tra);
                    cmd.Parameters.AddWithValue("@ThanhTien", tiensan);
                    cmd.Parameters.AddWithValue("@MaSan", masan);
                    cmd.Parameters.AddWithValue("@MaKH", makh);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Thêm lịch đặt sân thành công");
                    conn.Close();
                    HienThiDSDS();
                    setnull();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi thêm mới lịch đặt sân!");
                }
            }
            else
            {
                MessageBox.Show("Lịch đặt của bạn đã bị trùng, xin vui lòng chọn lịch khác!");

            }
        }

        private void bt_lammoi_Click(object sender, EventArgs e)
        {
            setnull();
        }

        private void bt_sua_Click(object sender, EventArgs e)
        {

            if (lv_datsan.SelectedIndices.Count > 0)
            {
                DateTime nhan = nhansan.Value;
                DateTime tra = trasan.Value;
                int masan = Int32.Parse(tb_masan.Text);
                int makh = Int32.Parse(tb_makh.Text);
                int tiensan = Int32.Parse(tb_tiensan.Text);
                try
                {
                    conn.Open();
                    string madatsan = lv_datsan.SelectedItems[0].SubItems[0].Text;
                    string sql = "UPDATE DatSan SET GioDat = @GioDat, SoGioDat = @SoGioDat, GioTra = @GioTra, ThanhTien = @ThanhTien, MaSan = @MaSan, MaKH = @MaKH WHERE MaDatSan = @MaDatSan";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@MaDatSan", madatsan);
                    cmd.Parameters.AddWithValue("@GioDat", nhan);
                    cmd.Parameters.AddWithValue("@SoGioDat", giodat.Value);
                    cmd.Parameters.AddWithValue("@GioTra", tra);
                    cmd.Parameters.AddWithValue("@ThanhTien", tiensan);
                    cmd.Parameters.AddWithValue("@MaSan", masan);
                    cmd.Parameters.AddWithValue("@MaKH", makh);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Cập nhật lich dat '" + madatsan + "' thành công");
                    conn.Close();
                    HienThiDSDS();
                    setnull();

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi cập nhật lịch đặt: " + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn lịch đặt muốn cập nhật");
            }
        }

        private void bt_xoa_Click(object sender, EventArgs e)
        {

            if (lv_datsan.SelectedIndices.Count > 0)
            {
                try
                {
                    conn.Open();
                    string madatsan = lv_datsan.SelectedItems[0].SubItems[0].Text;
                    string sql = "DELETE FROM DatSan WHERE MaDatSan = @MaDatSan";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@MaDatSan", madatsan);
                    cmd.ExecuteNonQuery();
                    lv_datsan.Items.RemoveAt(lv_datsan.SelectedIndices[0]);
                    MessageBox.Show("Xóa lich dat '" + madatsan + "' thành công");
                    conn.Close();
                    HienThiDSDS();
                    setnull();

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi xóa lịch đặt: " + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn lịch đặt muốn xóa");
            }
        }

        private void bt_search_Click(object sender, EventArgs e)
        {
            bt_datsan.Enabled = false;

            if (tb_search.Text != "")
            {
                TimLichDatSan();
                cb_kh.Enabled = cb_san.Enabled = giodat.Enabled = nhansan.Enabled = trasan.Enabled = tb_tiensan.Enabled = tb_makh.Enabled = tb_masan.Enabled = bt_datsan.Enabled = bt_lammoi.Enabled = bt_sua.Enabled = bt_xoa.Enabled = button2.Enabled = true;
                flowLayoutPanel1.Enabled = false;
            }
            else
            {
                MessageBox.Show("Nhập mã đặt sân cần tìm");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            flowLayoutPanel1.Enabled = true;
            cb_kh.Enabled = cb_san.Enabled = giodat.Enabled = nhansan.Enabled = trasan.Enabled = tb_tiensan.Enabled = tb_makh.Enabled = tb_masan.Enabled = bt_datsan.Enabled = bt_lammoi.Enabled = bt_sua.Enabled = bt_xoa.Enabled = button2.Enabled = false;
        }

        private void cb_kh_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void cb_san_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
