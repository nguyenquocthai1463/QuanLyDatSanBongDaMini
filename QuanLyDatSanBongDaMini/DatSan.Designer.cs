﻿namespace QuanLyDatSanBongDaMini
{
    partial class DatSan
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
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.label2 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.bt_lammoi = new System.Windows.Forms.Button();
            this.bt_datsan = new System.Windows.Forms.Button();
            this.giodat = new System.Windows.Forms.NumericUpDown();
            this.trasan = new System.Windows.Forms.DateTimePicker();
            this.nhansan = new System.Windows.Forms.DateTimePicker();
            this.cb_san = new System.Windows.Forms.ComboBox();
            this.cb_kh = new System.Windows.Forms.ComboBox();
            this.tb_tiensan = new System.Windows.Forms.TextBox();
            this.tb_masan = new System.Windows.Forms.TextBox();
            this.tb_makh = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lv_datsan = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.bt_sua = new System.Windows.Forms.Button();
            this.bt_xoa = new System.Windows.Forms.Button();
            this.flowLayoutPanel2.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.giodat)).BeginInit();
            this.SuspendLayout();
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.Controls.Add(this.label2);
            this.flowLayoutPanel2.Controls.Add(this.panel2);
            this.flowLayoutPanel2.Location = new System.Drawing.Point(12, 12);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(1085, 334);
            this.flowLayoutPanel2.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(132, 20);
            this.label2.TabIndex = 0;
            this.label2.Text = "Thông tin đặt sân";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.bt_xoa);
            this.panel2.Controls.Add(this.bt_sua);
            this.panel2.Controls.Add(this.bt_lammoi);
            this.panel2.Controls.Add(this.bt_datsan);
            this.panel2.Controls.Add(this.giodat);
            this.panel2.Controls.Add(this.trasan);
            this.panel2.Controls.Add(this.nhansan);
            this.panel2.Controls.Add(this.cb_san);
            this.panel2.Controls.Add(this.cb_kh);
            this.panel2.Controls.Add(this.tb_tiensan);
            this.panel2.Controls.Add(this.tb_masan);
            this.panel2.Controls.Add(this.tb_makh);
            this.panel2.Controls.Add(this.label13);
            this.panel2.Controls.Add(this.label12);
            this.panel2.Controls.Add(this.label11);
            this.panel2.Controls.Add(this.label10);
            this.panel2.Controls.Add(this.label9);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Location = new System.Drawing.Point(3, 23);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1081, 311);
            this.panel2.TabIndex = 1;
            this.panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.panel2_Paint);
            // 
            // bt_lammoi
            // 
            this.bt_lammoi.Location = new System.Drawing.Point(803, 225);
            this.bt_lammoi.Name = "bt_lammoi";
            this.bt_lammoi.Size = new System.Drawing.Size(155, 54);
            this.bt_lammoi.TabIndex = 17;
            this.bt_lammoi.Text = "Làm mới";
            this.bt_lammoi.UseVisualStyleBackColor = true;
            this.bt_lammoi.Click += new System.EventHandler(this.bt_lammoi_Click);
            // 
            // bt_datsan
            // 
            this.bt_datsan.Location = new System.Drawing.Point(803, 22);
            this.bt_datsan.Name = "bt_datsan";
            this.bt_datsan.Size = new System.Drawing.Size(155, 54);
            this.bt_datsan.TabIndex = 16;
            this.bt_datsan.Text = "Đặt sân";
            this.bt_datsan.UseVisualStyleBackColor = true;
            this.bt_datsan.Click += new System.EventHandler(this.bt_datsan_Click);
            // 
            // giodat
            // 
            this.giodat.DecimalPlaces = 1;
            this.giodat.Increment = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            this.giodat.Location = new System.Drawing.Point(129, 173);
            this.giodat.Name = "giodat";
            this.giodat.Size = new System.Drawing.Size(290, 26);
            this.giodat.TabIndex = 6;
            this.giodat.Value = new decimal(new int[] {
            10,
            0,
            0,
            65536});
            this.giodat.ValueChanged += new System.EventHandler(this.giodat_ValueChanged);
            // 
            // trasan
            // 
            this.trasan.CustomFormat = "dd/MM/yyyy HH:mm";
            this.trasan.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.trasan.Location = new System.Drawing.Point(129, 225);
            this.trasan.Name = "trasan";
            this.trasan.Size = new System.Drawing.Size(290, 26);
            this.trasan.TabIndex = 14;
            this.trasan.ValueChanged += new System.EventHandler(this.trasan_ValueChanged);
            // 
            // nhansan
            // 
            this.nhansan.CustomFormat = "dd/MM/yyyy HH:mm";
            this.nhansan.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.nhansan.Location = new System.Drawing.Point(129, 119);
            this.nhansan.Name = "nhansan";
            this.nhansan.Size = new System.Drawing.Size(290, 26);
            this.nhansan.TabIndex = 13;
            this.nhansan.ValueChanged += new System.EventHandler(this.nhansan_ValueChanged);
            // 
            // cb_san
            // 
            this.cb_san.FormattingEnabled = true;
            this.cb_san.Location = new System.Drawing.Point(129, 72);
            this.cb_san.Name = "cb_san";
            this.cb_san.Size = new System.Drawing.Size(290, 28);
            this.cb_san.TabIndex = 12;
            this.cb_san.SelectedIndexChanged += new System.EventHandler(this.cb_san_SelectedIndexChanged);
            // 
            // cb_kh
            // 
            this.cb_kh.FormattingEnabled = true;
            this.cb_kh.Location = new System.Drawing.Point(129, 22);
            this.cb_kh.Name = "cb_kh";
            this.cb_kh.Size = new System.Drawing.Size(290, 28);
            this.cb_kh.TabIndex = 11;
            this.cb_kh.SelectedIndexChanged += new System.EventHandler(this.cb_kh_SelectedIndexChanged);
            // 
            // tb_tiensan
            // 
            this.tb_tiensan.Location = new System.Drawing.Point(129, 272);
            this.tb_tiensan.Name = "tb_tiensan";
            this.tb_tiensan.Size = new System.Drawing.Size(290, 26);
            this.tb_tiensan.TabIndex = 10;
            // 
            // tb_masan
            // 
            this.tb_masan.Location = new System.Drawing.Point(535, 75);
            this.tb_masan.Name = "tb_masan";
            this.tb_masan.Size = new System.Drawing.Size(202, 26);
            this.tb_masan.TabIndex = 9;
            // 
            // tb_makh
            // 
            this.tb_makh.Location = new System.Drawing.Point(535, 25);
            this.tb_makh.Name = "tb_makh";
            this.tb_makh.Size = new System.Drawing.Size(202, 26);
            this.tb_makh.TabIndex = 8;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(450, 75);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(64, 20);
            this.label13.TabIndex = 7;
            this.label13.Text = "Mã Sân";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(450, 25);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(57, 20);
            this.label12.TabIndex = 6;
            this.label12.Text = "Mã KH";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(25, 275);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(69, 20);
            this.label11.TabIndex = 5;
            this.label11.Text = "Tiền sân";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(25, 225);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(62, 20);
            this.label10.TabIndex = 4;
            this.label10.Text = "Trả sân";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(25, 175);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(61, 20);
            this.label9.TabIndex = 3;
            this.label9.Text = "Giờ đặt";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(25, 125);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(77, 20);
            this.label8.TabIndex = 2;
            this.label8.Text = "Nhận sân";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(25, 75);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(38, 20);
            this.label7.TabIndex = 1;
            this.label7.Text = "Sân";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(25, 25);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(94, 20);
            this.label6.TabIndex = 0;
            this.label6.Text = "Khách hàng";
            // 
            // lv_datsan
            // 
            this.lv_datsan.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader6,
            this.columnHeader7});
            this.lv_datsan.HideSelection = false;
            this.lv_datsan.Location = new System.Drawing.Point(11, 352);
            this.lv_datsan.Name = "lv_datsan";
            this.lv_datsan.Size = new System.Drawing.Size(1085, 401);
            this.lv_datsan.TabIndex = 2;
            this.lv_datsan.UseCompatibleStateImageBehavior = false;
            this.lv_datsan.View = System.Windows.Forms.View.Details;
            this.lv_datsan.SelectedIndexChanged += new System.EventHandler(this.lv_datsan_SelectedIndexChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Mã đặt sân";
            this.columnHeader1.Width = 80;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Mã sân";
            this.columnHeader2.Width = 80;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Mã khách hàng";
            this.columnHeader3.Width = 100;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Giờ nhận sân";
            this.columnHeader4.Width = 150;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Số giờ đặt";
            this.columnHeader5.Width = 80;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "Giờ trả sân";
            this.columnHeader6.Width = 150;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "Tiền sân";
            this.columnHeader7.Width = 120;
            // 
            // bt_sua
            // 
            this.bt_sua.Location = new System.Drawing.Point(803, 91);
            this.bt_sua.Name = "bt_sua";
            this.bt_sua.Size = new System.Drawing.Size(155, 54);
            this.bt_sua.TabIndex = 18;
            this.bt_sua.Text = "Sửa";
            this.bt_sua.UseVisualStyleBackColor = true;
            this.bt_sua.Click += new System.EventHandler(this.bt_sua_Click);
            // 
            // bt_xoa
            // 
            this.bt_xoa.Location = new System.Drawing.Point(803, 158);
            this.bt_xoa.Name = "bt_xoa";
            this.bt_xoa.Size = new System.Drawing.Size(155, 54);
            this.bt_xoa.TabIndex = 19;
            this.bt_xoa.Text = "Xóa";
            this.bt_xoa.UseVisualStyleBackColor = true;
            this.bt_xoa.Click += new System.EventHandler(this.bt_xoa_Click);
            // 
            // DatSan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1336, 924);
            this.Controls.Add(this.lv_datsan);
            this.Controls.Add(this.flowLayoutPanel2);
            this.Name = "DatSan";
            this.Text = "DatSan";
            this.Load += new System.EventHandler(this.DatSan_Load);
            this.flowLayoutPanel2.ResumeLayout(false);
            this.flowLayoutPanel2.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.giodat)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.NumericUpDown giodat;
        private System.Windows.Forms.DateTimePicker trasan;
        private System.Windows.Forms.DateTimePicker nhansan;
        private System.Windows.Forms.ComboBox cb_san;
        private System.Windows.Forms.ComboBox cb_kh;
        private System.Windows.Forms.TextBox tb_tiensan;
        private System.Windows.Forms.TextBox tb_masan;
        private System.Windows.Forms.TextBox tb_makh;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button bt_datsan;
        private System.Windows.Forms.ListView lv_datsan;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.Button bt_lammoi;
        private System.Windows.Forms.Button bt_xoa;
        private System.Windows.Forms.Button bt_sua;
    }
}