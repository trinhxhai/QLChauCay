
namespace QuanLyChauCayCanh
{
    partial class MainForm
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
            this.btnOpenDangNhap = new System.Windows.Forms.Button();
            this.btnQLNhanVien = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnQLKhachHang = new System.Windows.Forms.Button();
            this.btnQLChauCay = new System.Windows.Forms.Button();
            this.btnQLLoaiChauCay = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btnDangXuat = new System.Windows.Forms.Button();
            this.lbLoginUser = new System.Windows.Forms.Label();
            this.btnQLHoaDon = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnOpenDangNhap
            // 
            this.btnOpenDangNhap.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.btnOpenDangNhap.Location = new System.Drawing.Point(1058, 21);
            this.btnOpenDangNhap.Name = "btnOpenDangNhap";
            this.btnOpenDangNhap.Size = new System.Drawing.Size(124, 34);
            this.btnOpenDangNhap.TabIndex = 2;
            this.btnOpenDangNhap.Text = "Đăng nhập";
            this.btnOpenDangNhap.UseVisualStyleBackColor = true;
            this.btnOpenDangNhap.Click += new System.EventHandler(this.btnOpenDangNhap_Click);
            // 
            // btnQLNhanVien
            // 
            this.btnQLNhanVien.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.btnQLNhanVien.Location = new System.Drawing.Point(46, 54);
            this.btnQLNhanVien.Name = "btnQLNhanVien";
            this.btnQLNhanVien.Size = new System.Drawing.Size(221, 56);
            this.btnQLNhanVien.TabIndex = 3;
            this.btnQLNhanVien.Text = "Quản lý nhân viên";
            this.btnQLNhanVien.UseVisualStyleBackColor = true;
            this.btnQLNhanVien.Click += new System.EventHandler(this.btnQLNhanVien_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnQLHoaDon);
            this.groupBox1.Controls.Add(this.btnQLKhachHang);
            this.groupBox1.Controls.Add(this.btnQLChauCay);
            this.groupBox1.Controls.Add(this.btnQLLoaiChauCay);
            this.groupBox1.Controls.Add(this.btnQLNhanVien);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.groupBox1.Location = new System.Drawing.Point(35, 78);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1147, 504);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Chức năng";
            // 
            // btnQLKhachHang
            // 
            this.btnQLKhachHang.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.btnQLKhachHang.Location = new System.Drawing.Point(46, 307);
            this.btnQLKhachHang.Name = "btnQLKhachHang";
            this.btnQLKhachHang.Size = new System.Drawing.Size(220, 56);
            this.btnQLKhachHang.TabIndex = 6;
            this.btnQLKhachHang.Text = "Quản lí khách hàng";
            this.btnQLKhachHang.UseVisualStyleBackColor = true;
            this.btnQLKhachHang.Click += new System.EventHandler(this.btnQLKhachHang_Click);
            // 
            // btnQLChauCay
            // 
            this.btnQLChauCay.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.btnQLChauCay.Location = new System.Drawing.Point(46, 226);
            this.btnQLChauCay.Name = "btnQLChauCay";
            this.btnQLChauCay.Size = new System.Drawing.Size(221, 56);
            this.btnQLChauCay.TabIndex = 5;
            this.btnQLChauCay.Text = "Quản lý chậu cây";
            this.btnQLChauCay.UseVisualStyleBackColor = true;
            this.btnQLChauCay.Click += new System.EventHandler(this.btnQLChauCay_Click);
            // 
            // btnQLLoaiChauCay
            // 
            this.btnQLLoaiChauCay.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.btnQLLoaiChauCay.Location = new System.Drawing.Point(46, 145);
            this.btnQLLoaiChauCay.Name = "btnQLLoaiChauCay";
            this.btnQLLoaiChauCay.Size = new System.Drawing.Size(221, 56);
            this.btnQLLoaiChauCay.TabIndex = 4;
            this.btnQLLoaiChauCay.Text = "Quản lý loại chậu cây";
            this.btnQLLoaiChauCay.UseVisualStyleBackColor = true;
            this.btnQLLoaiChauCay.Click += new System.EventHandler(this.btnQLLoaiChauCay_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 21F);
            this.label1.Location = new System.Drawing.Point(29, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(382, 32);
            this.label1.TabIndex = 5;
            this.label1.Text = "Ứng dụng bán chậu cây cảnh";
            // 
            // btnDangXuat
            // 
            this.btnDangXuat.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.btnDangXuat.Location = new System.Drawing.Point(1058, 20);
            this.btnDangXuat.Name = "btnDangXuat";
            this.btnDangXuat.Size = new System.Drawing.Size(124, 34);
            this.btnDangXuat.TabIndex = 7;
            this.btnDangXuat.Text = "Đăng Xuất";
            this.btnDangXuat.UseVisualStyleBackColor = true;
            this.btnDangXuat.Visible = false;
            this.btnDangXuat.Click += new System.EventHandler(this.btnDangXuat_Click);
            // 
            // lbLoginUser
            // 
            this.lbLoginUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.lbLoginUser.Location = new System.Drawing.Point(883, 21);
            this.lbLoginUser.Name = "lbLoginUser";
            this.lbLoginUser.Size = new System.Drawing.Size(169, 34);
            this.lbLoginUser.TabIndex = 8;
            this.lbLoginUser.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lbLoginUser.Visible = false;
            // 
            // btnQLHoaDon
            // 
            this.btnQLHoaDon.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.btnQLHoaDon.Location = new System.Drawing.Point(46, 386);
            this.btnQLHoaDon.Name = "btnQLHoaDon";
            this.btnQLHoaDon.Size = new System.Drawing.Size(220, 56);
            this.btnQLHoaDon.TabIndex = 7;
            this.btnQLHoaDon.Text = "Quản lí hóa đơn";
            this.btnQLHoaDon.UseVisualStyleBackColor = true;
            this.btnQLHoaDon.Click += new System.EventHandler(this.btnQLHoaDon_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1384, 761);
            this.Controls.Add(this.lbLoginUser);
            this.Controls.Add(this.btnDangXuat);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnOpenDangNhap);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ứng dụng bán chậu cây cảnh";
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnOpenDangNhap;
        private System.Windows.Forms.Button btnQLNhanVien;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnDangXuat;
        private System.Windows.Forms.Label lbLoginUser;
        private System.Windows.Forms.Button btnQLLoaiChauCay;
        private System.Windows.Forms.Button btnQLChauCay;
        private System.Windows.Forms.Button btnQLKhachHang;
        private System.Windows.Forms.Button btnQLHoaDon;
    }
}