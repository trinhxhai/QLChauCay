
namespace QuanLyChauCayCanh
{
    partial class QLHoaDonForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(QLHoaDonForm));
            this.txtTimKiem = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.btnHuyTimKiem = new System.Windows.Forms.Button();
            this.btnThemHD = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btnHuyHD = new System.Windows.Forms.Button();
            this.btnLuuHD = new System.Windows.Forms.Button();
            this.ngayMua = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tenNhanVien = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.TenKhachHang = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Id = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lwHoaDon = new System.Windows.Forms.ListView();
            this.ngayTao = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ngaySua = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lbMessage = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtMa = new System.Windows.Forms.TextBox();
            this.btnTimKiem = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cbKhachHang = new System.Windows.Forms.ComboBox();
            this.btnXoaHD = new System.Windows.Forms.Button();
            this.lwCTHD = new System.Windows.Forms.ListView();
            this.ma = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tenChau = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.soLuong = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.giaBan = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.khuyenMai = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.thanhTien = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label5 = new System.Windows.Forms.Label();
            this.btnSuaChau = new System.Windows.Forms.Button();
            this.btnPrintHD = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.lbTong = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.printPreviewDialog1 = new System.Windows.Forms.PrintPreviewDialog();
            this.btnBackToMain = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtTimKiem
            // 
            this.txtTimKiem.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.txtTimKiem.Location = new System.Drawing.Point(113, 73);
            this.txtTimKiem.Name = "txtTimKiem";
            this.txtTimKiem.Size = new System.Drawing.Size(324, 26);
            this.txtTimKiem.TabIndex = 37;
            this.txtTimKiem.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtTimKiem_KeyDown);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label11.Location = new System.Drawing.Point(27, 75);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(79, 20);
            this.label11.TabIndex = 47;
            this.label11.Text = "Tìm kiếm :";
            // 
            // btnHuyTimKiem
            // 
            this.btnHuyTimKiem.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btnHuyTimKiem.Location = new System.Drawing.Point(534, 73);
            this.btnHuyTimKiem.Name = "btnHuyTimKiem";
            this.btnHuyTimKiem.Size = new System.Drawing.Size(79, 27);
            this.btnHuyTimKiem.TabIndex = 40;
            this.btnHuyTimKiem.Text = "Hủy";
            this.btnHuyTimKiem.UseVisualStyleBackColor = true;
            // 
            // btnThemHD
            // 
            this.btnThemHD.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.btnThemHD.Location = new System.Drawing.Point(808, 634);
            this.btnThemHD.Name = "btnThemHD";
            this.btnThemHD.Size = new System.Drawing.Size(108, 40);
            this.btnThemHD.TabIndex = 41;
            this.btnThemHD.Text = "Thêm";
            this.btnThemHD.UseVisualStyleBackColor = true;
            this.btnThemHD.Click += new System.EventHandler(this.btnThemHD_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 21F);
            this.label1.Location = new System.Drawing.Point(30, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(223, 32);
            this.label1.TabIndex = 38;
            this.label1.Text = "Quản lý hóa đơn";
            // 
            // btnHuyHD
            // 
            this.btnHuyHD.Enabled = false;
            this.btnHuyHD.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.btnHuyHD.Location = new System.Drawing.Point(1207, 634);
            this.btnHuyHD.Name = "btnHuyHD";
            this.btnHuyHD.Size = new System.Drawing.Size(108, 40);
            this.btnHuyHD.TabIndex = 44;
            this.btnHuyHD.Text = "Hủy";
            this.btnHuyHD.UseVisualStyleBackColor = true;
            this.btnHuyHD.Click += new System.EventHandler(this.btnHuy_Click);
            // 
            // btnLuuHD
            // 
            this.btnLuuHD.Enabled = false;
            this.btnLuuHD.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.btnLuuHD.Location = new System.Drawing.Point(944, 634);
            this.btnLuuHD.Name = "btnLuuHD";
            this.btnLuuHD.Size = new System.Drawing.Size(108, 40);
            this.btnLuuHD.TabIndex = 42;
            this.btnLuuHD.Text = "Lưu";
            this.btnLuuHD.UseVisualStyleBackColor = true;
            this.btnLuuHD.Click += new System.EventHandler(this.btnLuuHD_Click);
            // 
            // ngayMua
            // 
            this.ngayMua.Text = "Ngày mua";
            this.ngayMua.Width = 100;
            // 
            // tenNhanVien
            // 
            this.tenNhanVien.Text = "Tên nhân viên ";
            this.tenNhanVien.Width = 120;
            // 
            // TenKhachHang
            // 
            this.TenKhachHang.Text = "Tên khách hàng";
            this.TenKhachHang.Width = 120;
            // 
            // Id
            // 
            this.Id.Text = "Mã";
            this.Id.Width = 50;
            // 
            // lwHoaDon
            // 
            this.lwHoaDon.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Id,
            this.TenKhachHang,
            this.tenNhanVien,
            this.ngayMua,
            this.ngayTao,
            this.ngaySua});
            this.lwHoaDon.FullRowSelect = true;
            this.lwHoaDon.GridLines = true;
            this.lwHoaDon.HideSelection = false;
            this.lwHoaDon.Location = new System.Drawing.Point(32, 109);
            this.lwHoaDon.Name = "lwHoaDon";
            this.lwHoaDon.Size = new System.Drawing.Size(581, 565);
            this.lwHoaDon.TabIndex = 46;
            this.lwHoaDon.UseCompatibleStateImageBehavior = false;
            this.lwHoaDon.View = System.Windows.Forms.View.Details;
            this.lwHoaDon.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.lwLoaiChauCay_ItemSelectionChanged);
            // 
            // ngayTao
            // 
            this.ngayTao.Text = "Ngày tạo";
            this.ngayTao.Width = 100;
            // 
            // ngaySua
            // 
            this.ngaySua.Text = "Ngày sửa";
            this.ngaySua.Width = 100;
            // 
            // lbMessage
            // 
            this.lbMessage.Location = new System.Drawing.Point(44, 200);
            this.lbMessage.Name = "lbMessage";
            this.lbMessage.Size = new System.Drawing.Size(449, 64);
            this.lbMessage.TabIndex = 31;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label3.Location = new System.Drawing.Point(55, 86);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 17);
            this.label3.TabIndex = 12;
            this.label3.Text = "Mã :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label2.Location = new System.Drawing.Point(55, 128);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(92, 17);
            this.label2.TabIndex = 7;
            this.label2.Text = "Khách hàng :";
            // 
            // txtMa
            // 
            this.txtMa.Enabled = false;
            this.txtMa.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.txtMa.Location = new System.Drawing.Point(191, 86);
            this.txtMa.MaxLength = 3;
            this.txtMa.Name = "txtMa";
            this.txtMa.Size = new System.Drawing.Size(250, 23);
            this.txtMa.TabIndex = 4;
            // 
            // btnTimKiem
            // 
            this.btnTimKiem.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btnTimKiem.Location = new System.Drawing.Point(447, 72);
            this.btnTimKiem.Name = "btnTimKiem";
            this.btnTimKiem.Size = new System.Drawing.Size(76, 27);
            this.btnTimKiem.TabIndex = 39;
            this.btnTimKiem.Text = "Tìm";
            this.btnTimKiem.UseVisualStyleBackColor = true;
            this.btnTimKiem.Click += new System.EventHandler(this.btnTimKiem_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cbKhachHang);
            this.groupBox1.Controls.Add(this.lbMessage);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtMa);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.groupBox1.Location = new System.Drawing.Point(657, 390);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(682, 229);
            this.groupBox1.TabIndex = 45;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thông tin hóa đơn";
            // 
            // cbKhachHang
            // 
            this.cbKhachHang.FormattingEnabled = true;
            this.cbKhachHang.Location = new System.Drawing.Point(191, 128);
            this.cbKhachHang.Name = "cbKhachHang";
            this.cbKhachHang.Size = new System.Drawing.Size(250, 28);
            this.cbKhachHang.TabIndex = 34;
            // 
            // btnXoaHD
            // 
            this.btnXoaHD.Enabled = false;
            this.btnXoaHD.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.btnXoaHD.Location = new System.Drawing.Point(1073, 634);
            this.btnXoaHD.Name = "btnXoaHD";
            this.btnXoaHD.Size = new System.Drawing.Size(108, 40);
            this.btnXoaHD.TabIndex = 43;
            this.btnXoaHD.Text = "Xóa";
            this.btnXoaHD.UseVisualStyleBackColor = true;
            this.btnXoaHD.Click += new System.EventHandler(this.btnXoaHD_Click);
            // 
            // lwCTHD
            // 
            this.lwCTHD.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ma,
            this.tenChau,
            this.soLuong,
            this.giaBan,
            this.khuyenMai,
            this.thanhTien});
            this.lwCTHD.FullRowSelect = true;
            this.lwCTHD.GridLines = true;
            this.lwCTHD.HideSelection = false;
            this.lwCTHD.Location = new System.Drawing.Point(689, 124);
            this.lwCTHD.Name = "lwCTHD";
            this.lwCTHD.Size = new System.Drawing.Size(611, 213);
            this.lwCTHD.TabIndex = 48;
            this.lwCTHD.UseCompatibleStateImageBehavior = false;
            this.lwCTHD.View = System.Windows.Forms.View.Details;
            // 
            // ma
            // 
            this.ma.Text = "Mã";
            this.ma.Width = 50;
            // 
            // tenChau
            // 
            this.tenChau.Text = "Tên chậu cây";
            this.tenChau.Width = 120;
            // 
            // soLuong
            // 
            this.soLuong.Text = "Số lượng";
            this.soLuong.Width = 120;
            // 
            // giaBan
            // 
            this.giaBan.Text = "Giá bán";
            this.giaBan.Width = 100;
            // 
            // khuyenMai
            // 
            this.khuyenMai.Text = "Khuyến mại";
            this.khuyenMai.Width = 100;
            // 
            // thanhTien
            // 
            this.thanhTien.Text = "Thành tiền";
            this.thanhTien.Width = 115;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.label5.Location = new System.Drawing.Point(684, 84);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(301, 26);
            this.label5.TabIndex = 49;
            this.label5.Text = "Danh sách chậu theo hóa đơn";
            // 
            // btnSuaChau
            // 
            this.btnSuaChau.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.btnSuaChau.Location = new System.Drawing.Point(1191, 84);
            this.btnSuaChau.Name = "btnSuaChau";
            this.btnSuaChau.Size = new System.Drawing.Size(108, 35);
            this.btnSuaChau.TabIndex = 51;
            this.btnSuaChau.Text = "Sửa";
            this.btnSuaChau.UseVisualStyleBackColor = true;
            this.btnSuaChau.Click += new System.EventHandler(this.btnSuaChau_Click);
            // 
            // btnPrintHD
            // 
            this.btnPrintHD.Enabled = false;
            this.btnPrintHD.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.btnPrintHD.Location = new System.Drawing.Point(674, 633);
            this.btnPrintHD.Name = "btnPrintHD";
            this.btnPrintHD.Size = new System.Drawing.Size(108, 40);
            this.btnPrintHD.TabIndex = 53;
            this.btnPrintHD.Text = "In hóa đơn";
            this.btnPrintHD.UseVisualStyleBackColor = true;
            this.btnPrintHD.Click += new System.EventHandler(this.btnPrintHD_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label10.Location = new System.Drawing.Point(1271, 355);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(34, 20);
            this.label10.TabIndex = 64;
            this.label10.Text = "vnd";
            // 
            // lbTong
            // 
            this.lbTong.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lbTong.Location = new System.Drawing.Point(1108, 355);
            this.lbTong.Name = "lbTong";
            this.lbTong.Size = new System.Drawing.Size(158, 23);
            this.lbTong.TabIndex = 63;
            this.lbTong.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label7.Location = new System.Drawing.Point(1049, 355);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 20);
            this.label7.TabIndex = 62;
            this.label7.Text = "Tổng :";
            // 
            // printDocument1
            // 
            this.printDocument1.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDocument1_PrintPage);
            // 
            // printPreviewDialog1
            // 
            this.printPreviewDialog1.AutoScrollMargin = new System.Drawing.Size(0, 0);
            this.printPreviewDialog1.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            this.printPreviewDialog1.ClientSize = new System.Drawing.Size(400, 300);
            this.printPreviewDialog1.Document = this.printDocument1;
            this.printPreviewDialog1.Enabled = true;
            this.printPreviewDialog1.Icon = ((System.Drawing.Icon)(resources.GetObject("printPreviewDialog1.Icon")));
            this.printPreviewDialog1.Name = "printPreviewDialog1";
            this.printPreviewDialog1.Visible = false;
            // 
            // btnBackToMain
            // 
            this.btnBackToMain.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.btnBackToMain.Location = new System.Drawing.Point(1207, 12);
            this.btnBackToMain.Name = "btnBackToMain";
            this.btnBackToMain.Size = new System.Drawing.Size(108, 40);
            this.btnBackToMain.TabIndex = 65;
            this.btnBackToMain.Text = "Quay lại";
            this.btnBackToMain.UseVisualStyleBackColor = true;
            this.btnBackToMain.Click += new System.EventHandler(this.btnBackToMain_Click);
            // 
            // QLHoaDonForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1384, 761);
            this.Controls.Add(this.btnBackToMain);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.lbTong);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.btnPrintHD);
            this.Controls.Add(this.btnSuaChau);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lwCTHD);
            this.Controls.Add(this.txtTimKiem);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.btnHuyTimKiem);
            this.Controls.Add(this.btnThemHD);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnHuyHD);
            this.Controls.Add(this.btnLuuHD);
            this.Controls.Add(this.lwHoaDon);
            this.Controls.Add(this.btnTimKiem);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnXoaHD);
            this.Name = "QLHoaDonForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "QLHoaDonForm";
            this.Load += new System.EventHandler(this.QLHoaDonForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtTimKiem;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button btnHuyTimKiem;
        private System.Windows.Forms.Button btnThemHD;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnHuyHD;
        private System.Windows.Forms.Button btnLuuHD;
        public System.Windows.Forms.ColumnHeader ngayMua;
        private System.Windows.Forms.ColumnHeader tenNhanVien;
        private System.Windows.Forms.ColumnHeader TenKhachHang;
        private System.Windows.Forms.ColumnHeader Id;
        private System.Windows.Forms.ListView lwHoaDon;
        private System.Windows.Forms.Label lbMessage;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtMa;
        private System.Windows.Forms.Button btnTimKiem;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnXoaHD;
        private System.Windows.Forms.ColumnHeader ngayTao;
        private System.Windows.Forms.ColumnHeader ngaySua;
        private System.Windows.Forms.ComboBox cbKhachHang;
        private System.Windows.Forms.ListView lwCTHD;
        private System.Windows.Forms.ColumnHeader ma;
        private System.Windows.Forms.ColumnHeader tenChau;
        private System.Windows.Forms.ColumnHeader soLuong;
        public System.Windows.Forms.ColumnHeader giaBan;
        private System.Windows.Forms.ColumnHeader khuyenMai;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnSuaChau;
        private System.Windows.Forms.Button btnPrintHD;
        private System.Windows.Forms.ColumnHeader thanhTien;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label lbTong;
        private System.Windows.Forms.Label label7;
        private System.Drawing.Printing.PrintDocument printDocument1;
        private System.Windows.Forms.PrintPreviewDialog printPreviewDialog1;
        private System.Windows.Forms.Button btnBackToMain;
    }
}