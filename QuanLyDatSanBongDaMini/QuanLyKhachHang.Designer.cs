namespace QuanLyDatSanBongDaMini
{
    partial class QuanLyKhachHang
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.gb_LKH = new System.Windows.Forms.GroupBox();
            this.lblKhongTimThay = new System.Windows.Forms.Label();
            this.btnSearch = new System.Windows.Forms.Button();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.btnHuy = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnThem = new System.Windows.Forms.Button();
            this.lsvKH = new System.Windows.Forms.ListView();
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader8 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lblCB = new System.Windows.Forms.Label();
            this.txtPhone = new System.Windows.Forms.TextBox();
            this.txtMaKH = new System.Windows.Forms.TextBox();
            this.txtHoTen = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.gbKH = new System.Windows.Forms.GroupBox();
            this.lblPhone = new System.Windows.Forms.Label();
            this.lblHoTen = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtCCCD = new System.Windows.Forms.TextBox();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.gb_LKH.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.gbKH.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Book Antiqua", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(543, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(314, 35);
            this.label1.TabIndex = 42;
            this.label1.Text = "Quản Lý Khách Hàng";
            // 
            // gb_LKH
            // 
            this.gb_LKH.Controls.Add(this.lblKhongTimThay);
            this.gb_LKH.Controls.Add(this.btnSearch);
            this.gb_LKH.Controls.Add(this.txtSearch);
            this.gb_LKH.Controls.Add(this.label7);
            this.gb_LKH.Controls.Add(this.groupBox2);
            this.gb_LKH.Controls.Add(this.lsvKH);
            this.gb_LKH.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gb_LKH.Location = new System.Drawing.Point(23, 311);
            this.gb_LKH.Name = "gb_LKH";
            this.gb_LKH.Size = new System.Drawing.Size(1296, 555);
            this.gb_LKH.TabIndex = 44;
            this.gb_LKH.TabStop = false;
            this.gb_LKH.Text = "Danh sách khách hàng";
            // 
            // lblKhongTimThay
            // 
            this.lblKhongTimThay.AutoSize = true;
            this.lblKhongTimThay.ForeColor = System.Drawing.Color.Red;
            this.lblKhongTimThay.Location = new System.Drawing.Point(694, 80);
            this.lblKhongTimThay.Name = "lblKhongTimThay";
            this.lblKhongTimThay.Size = new System.Drawing.Size(210, 20);
            this.lblKhongTimThay.TabIndex = 39;
            this.lblKhongTimThay.Text = "Không tìm thấy khách hàng";
            this.lblKhongTimThay.Visible = false;
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(962, 44);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(100, 38);
            this.btnSearch.TabIndex = 40;
            this.btnSearch.Text = "Tìm";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click_1);
            // 
            // txtSearch
            // 
            this.txtSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearch.Location = new System.Drawing.Point(698, 46);
            this.txtSearch.Margin = new System.Windows.Forms.Padding(4);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(235, 30);
            this.txtSearch.TabIndex = 38;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(471, 51);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(192, 20);
            this.label7.TabIndex = 37;
            this.label7.Text = "Tìm khách hàng theo tên";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.button1);
            this.groupBox2.Controls.Add(this.btnHuy);
            this.groupBox2.Controls.Add(this.btnSua);
            this.groupBox2.Controls.Add(this.btnXoa);
            this.groupBox2.Controls.Add(this.btnThem);
            this.groupBox2.Location = new System.Drawing.Point(698, 396);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(589, 86);
            this.groupBox2.TabIndex = 36;
            this.groupBox2.TabStop = false;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(477, 22);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(107, 51);
            this.button1.TabIndex = 15;
            this.button1.Text = "Thoát";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // btnHuy
            // 
            this.btnHuy.Location = new System.Drawing.Point(362, 22);
            this.btnHuy.Margin = new System.Windows.Forms.Padding(4);
            this.btnHuy.Name = "btnHuy";
            this.btnHuy.Size = new System.Drawing.Size(107, 51);
            this.btnHuy.TabIndex = 14;
            this.btnHuy.Text = "Hủy";
            this.btnHuy.UseVisualStyleBackColor = true;
            this.btnHuy.Click += new System.EventHandler(this.btnHuy_Click_1);
            // 
            // btnSua
            // 
            this.btnSua.Location = new System.Drawing.Point(247, 22);
            this.btnSua.Margin = new System.Windows.Forms.Padding(4);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(107, 51);
            this.btnSua.TabIndex = 14;
            this.btnSua.Text = "Sửa";
            this.btnSua.UseVisualStyleBackColor = true;
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click_1);
            // 
            // btnXoa
            // 
            this.btnXoa.Location = new System.Drawing.Point(132, 22);
            this.btnXoa.Margin = new System.Windows.Forms.Padding(4);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(107, 51);
            this.btnXoa.TabIndex = 12;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.UseVisualStyleBackColor = true;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click_1);
            // 
            // btnThem
            // 
            this.btnThem.Location = new System.Drawing.Point(17, 22);
            this.btnThem.Margin = new System.Windows.Forms.Padding(4);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(107, 51);
            this.btnThem.TabIndex = 11;
            this.btnThem.Text = "Thêm";
            this.btnThem.UseVisualStyleBackColor = true;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click_1);
            // 
            // lsvKH
            // 
            this.lsvKH.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader6,
            this.columnHeader7,
            this.columnHeader8,
            this.columnHeader1});
            this.lsvKH.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lsvKH.FullRowSelect = true;
            this.lsvKH.GridLines = true;
            this.lsvKH.HideSelection = false;
            this.lsvKH.Location = new System.Drawing.Point(33, 126);
            this.lsvKH.Margin = new System.Windows.Forms.Padding(4);
            this.lsvKH.Name = "lsvKH";
            this.lsvKH.Size = new System.Drawing.Size(1256, 250);
            this.lsvKH.TabIndex = 15;
            this.lsvKH.UseCompatibleStateImageBehavior = false;
            this.lsvKH.View = System.Windows.Forms.View.Details;
            this.lsvKH.SelectedIndexChanged += new System.EventHandler(this.lsvKH_SelectedIndexChanged_1);
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "Mã khách hàng";
            this.columnHeader6.Width = 151;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "Tên khách hàng";
            this.columnHeader7.Width = 193;
            // 
            // columnHeader8
            // 
            this.columnHeader8.Text = "Số điện thoại";
            this.columnHeader8.Width = 219;
            // 
            // lblCB
            // 
            this.lblCB.AutoSize = true;
            this.lblCB.ForeColor = System.Drawing.Color.Red;
            this.lblCB.Location = new System.Drawing.Point(627, 179);
            this.lblCB.Name = "lblCB";
            this.lblCB.Size = new System.Drawing.Size(233, 20);
            this.lblCB.TabIndex = 39;
            this.lblCB.Text = "Vui lòng nhập đầy đủ thông tin";
            this.lblCB.Visible = false;
            // 
            // txtPhone
            // 
            this.txtPhone.Location = new System.Drawing.Point(842, 55);
            this.txtPhone.Margin = new System.Windows.Forms.Padding(4);
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.Size = new System.Drawing.Size(445, 27);
            this.txtPhone.TabIndex = 3;
            // 
            // txtMaKH
            // 
            this.txtMaKH.Location = new System.Drawing.Point(146, 58);
            this.txtMaKH.Margin = new System.Windows.Forms.Padding(4);
            this.txtMaKH.Name = "txtMaKH";
            this.txtMaKH.Size = new System.Drawing.Size(533, 27);
            this.txtMaKH.TabIndex = 1;
            // 
            // txtHoTen
            // 
            this.txtHoTen.Location = new System.Drawing.Point(146, 116);
            this.txtHoTen.Margin = new System.Windows.Forms.Padding(4);
            this.txtHoTen.Name = "txtHoTen";
            this.txtHoTen.Size = new System.Drawing.Size(533, 27);
            this.txtHoTen.TabIndex = 1;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(40, 58);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(61, 20);
            this.label5.TabIndex = 2;
            this.label5.Text = "Mã KH";
            // 
            // gbKH
            // 
            this.gbKH.Controls.Add(this.txtCCCD);
            this.gbKH.Controls.Add(this.label2);
            this.gbKH.Controls.Add(this.lblCB);
            this.gbKH.Controls.Add(this.txtPhone);
            this.gbKH.Controls.Add(this.txtMaKH);
            this.gbKH.Controls.Add(this.txtHoTen);
            this.gbKH.Controls.Add(this.label5);
            this.gbKH.Controls.Add(this.lblPhone);
            this.gbKH.Controls.Add(this.lblHoTen);
            this.gbKH.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbKH.Location = new System.Drawing.Point(23, 72);
            this.gbKH.Margin = new System.Windows.Forms.Padding(4);
            this.gbKH.Name = "gbKH";
            this.gbKH.Padding = new System.Windows.Forms.Padding(4);
            this.gbKH.Size = new System.Drawing.Size(1295, 216);
            this.gbKH.TabIndex = 43;
            this.gbKH.TabStop = false;
            this.gbKH.Text = "Thông tin khách hàng";
            this.gbKH.Enter += new System.EventHandler(this.gbKH_Enter);
            // 
            // lblPhone
            // 
            this.lblPhone.AutoSize = true;
            this.lblPhone.Location = new System.Drawing.Point(750, 55);
            this.lblPhone.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPhone.Name = "lblPhone";
            this.lblPhone.Size = new System.Drawing.Size(84, 20);
            this.lblPhone.TabIndex = 2;
            this.lblPhone.Text = "Điện thoại";
            // 
            // lblHoTen
            // 
            this.lblHoTen.AutoSize = true;
            this.lblHoTen.Location = new System.Drawing.Point(40, 120);
            this.lblHoTen.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblHoTen.Name = "lblHoTen";
            this.lblHoTen.Size = new System.Drawing.Size(59, 20);
            this.lblHoTen.TabIndex = 0;
            this.lblHoTen.Text = "Họ tên";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(750, 124);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(163, 20);
            this.label2.TabIndex = 40;
            this.label2.Text = "Căn Cước Công Dân";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // txtCCCD
            // 
            this.txtCCCD.Location = new System.Drawing.Point(936, 117);
            this.txtCCCD.Margin = new System.Windows.Forms.Padding(4);
            this.txtCCCD.Name = "txtCCCD";
            this.txtCCCD.Size = new System.Drawing.Size(353, 27);
            this.txtCCCD.TabIndex = 41;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Căn Cước Công Dân";
            this.columnHeader1.Width = 288;
            // 
            // QuanLyKhachHang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1331, 868);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.gb_LKH);
            this.Controls.Add(this.gbKH);
            this.Name = "QuanLyKhachHang";
            this.Text = "QuanLyKhachHang";
            this.Load += new System.EventHandler(this.QuanLyKhachHang_Load_1);
            this.gb_LKH.ResumeLayout(false);
            this.gb_LKH.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.gbKH.ResumeLayout(false);
            this.gbKH.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox gb_LKH;
        private System.Windows.Forms.Label lblKhongTimThay;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnHuy;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.ListView lsvKH;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.ColumnHeader columnHeader8;
        private System.Windows.Forms.Label lblCB;
        private System.Windows.Forms.TextBox txtPhone;
        private System.Windows.Forms.TextBox txtMaKH;
        private System.Windows.Forms.TextBox txtHoTen;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox gbKH;
        private System.Windows.Forms.Label lblPhone;
        private System.Windows.Forms.Label lblHoTen;
        private System.Windows.Forms.TextBox txtCCCD;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ColumnHeader columnHeader1;
    }
}