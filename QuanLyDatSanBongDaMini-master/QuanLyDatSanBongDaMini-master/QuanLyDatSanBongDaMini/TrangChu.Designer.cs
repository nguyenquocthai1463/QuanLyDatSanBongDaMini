﻿namespace QuanLyDatSanBongDaMini
{
    partial class TrangChu
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
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.form_datsan = new System.Windows.Forms.Button();
            this.form_thanhtoan = new System.Windows.Forms.Button();
            this.form_quanlykhachhang = new System.Windows.Forms.Button();
            this.form_quanlyhoadon = new System.Windows.Forms.Button();
            this.form_quanlynhanvien = new System.Windows.Forms.Button();
            this.form_quanlydichvu = new System.Windows.Forms.Button();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.form_datsan);
            this.flowLayoutPanel1.Controls.Add(this.form_thanhtoan);
            this.flowLayoutPanel1.Controls.Add(this.form_quanlykhachhang);
            this.flowLayoutPanel1.Controls.Add(this.form_quanlyhoadon);
            this.flowLayoutPanel1.Controls.Add(this.form_quanlynhanvien);
            this.flowLayoutPanel1.Controls.Add(this.form_quanlydichvu);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(225, 795);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(225, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1116, 795);
            this.panel1.TabIndex = 1;
            // 
            // form_datsan
            // 
            this.form_datsan.Location = new System.Drawing.Point(3, 3);
            this.form_datsan.Name = "form_datsan";
            this.form_datsan.Size = new System.Drawing.Size(222, 121);
            this.form_datsan.TabIndex = 0;
            this.form_datsan.Text = "ĐẶT SÂN";
            this.form_datsan.UseVisualStyleBackColor = true;
            // 
            // form_thanhtoan
            // 
            this.form_thanhtoan.Location = new System.Drawing.Point(3, 130);
            this.form_thanhtoan.Name = "form_thanhtoan";
            this.form_thanhtoan.Size = new System.Drawing.Size(222, 121);
            this.form_thanhtoan.TabIndex = 1;
            this.form_thanhtoan.Text = "THANH TOÁN";
            this.form_thanhtoan.UseVisualStyleBackColor = true;
            // 
            // form_quanlykhachhang
            // 
            this.form_quanlykhachhang.Location = new System.Drawing.Point(3, 257);
            this.form_quanlykhachhang.Name = "form_quanlykhachhang";
            this.form_quanlykhachhang.Size = new System.Drawing.Size(222, 121);
            this.form_quanlykhachhang.TabIndex = 2;
            this.form_quanlykhachhang.Text = "QUẢN LÝ KHÁCH HÀNG";
            this.form_quanlykhachhang.UseVisualStyleBackColor = true;
            // 
            // form_quanlyhoadon
            // 
            this.form_quanlyhoadon.Location = new System.Drawing.Point(3, 384);
            this.form_quanlyhoadon.Name = "form_quanlyhoadon";
            this.form_quanlyhoadon.Size = new System.Drawing.Size(222, 121);
            this.form_quanlyhoadon.TabIndex = 3;
            this.form_quanlyhoadon.Text = "QUẢN LÝ HÓA ĐƠN";
            this.form_quanlyhoadon.UseVisualStyleBackColor = true;
            // 
            // form_quanlynhanvien
            // 
            this.form_quanlynhanvien.Location = new System.Drawing.Point(3, 511);
            this.form_quanlynhanvien.Name = "form_quanlynhanvien";
            this.form_quanlynhanvien.Size = new System.Drawing.Size(222, 121);
            this.form_quanlynhanvien.TabIndex = 4;
            this.form_quanlynhanvien.Text = "QUẢN LÝ NHÂN VIÊN";
            this.form_quanlynhanvien.UseVisualStyleBackColor = true;
            // 
            // form_quanlydichvu
            // 
            this.form_quanlydichvu.Location = new System.Drawing.Point(3, 638);
            this.form_quanlydichvu.Name = "form_quanlydichvu";
            this.form_quanlydichvu.Size = new System.Drawing.Size(222, 121);
            this.form_quanlydichvu.TabIndex = 5;
            this.form_quanlydichvu.Text = "QUẢN LÝ DỊCH VỤ";
            this.form_quanlydichvu.UseVisualStyleBackColor = true;
            // 
            // TrangChu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1341, 795);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Name = "TrangChu";
            this.Text = "TrangChu";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.flowLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button form_datsan;
        private System.Windows.Forms.Button form_thanhtoan;
        private System.Windows.Forms.Button form_quanlykhachhang;
        private System.Windows.Forms.Button form_quanlyhoadon;
        private System.Windows.Forms.Button form_quanlynhanvien;
        private System.Windows.Forms.Button form_quanlydichvu;
    }
}