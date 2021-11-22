
namespace QuanLyChauCayCanh
{
    partial class BaoCaoThongKeForm
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
            this.dpFrom = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dpTo = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.bntTKChauCay = new System.Windows.Forms.Button();
            this.bntTKLoaiChauCay = new System.Windows.Forms.Button();
            this.bntTKKhachHang = new System.Windows.Forms.Button();
            this.bntTKNhanVien = new System.Windows.Forms.Button();
            this.lwChauCay = new System.Windows.Forms.ListView();
            this.Id = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Ten = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SoLuong = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.TongThanhTien = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label4 = new System.Windows.Forms.Label();
            this.lbTongTien = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lbTitle = new System.Windows.Forms.Label();
            this.lwLoaiChauCay = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lwKhachHang = new System.Windows.Forms.ListView();
            this.maKH = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tenKH = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ngaySinh = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.sdt = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.soLanMua = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.soLuongMua = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ThanhTien = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lwNhanVien = new System.Windows.Forms.ListView();
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader8 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader9 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader10 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader11 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnBackToMain = new System.Windows.Forms.Button();
            this.btnPrintStatic = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // dpFrom
            // 
            this.dpFrom.Location = new System.Drawing.Point(231, 74);
            this.dpFrom.Name = "dpFrom";
            this.dpFrom.Size = new System.Drawing.Size(200, 20);
            this.dpFrom.TabIndex = 0;
            this.dpFrom.ValueChanged += new System.EventHandler(this.dpFrom_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label1.Location = new System.Drawing.Point(75, 74);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(145, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Dữ liệu lấy từ ngày :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label2.Location = new System.Drawing.Point(464, 74);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(36, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "đến";
            // 
            // dpTo
            // 
            this.dpTo.Location = new System.Drawing.Point(519, 73);
            this.dpTo.Name = "dpTo";
            this.dpTo.Size = new System.Drawing.Size(200, 20);
            this.dpTo.TabIndex = 3;
            this.dpTo.ValueChanged += new System.EventHandler(this.dpTo_ValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 21F);
            this.label3.Location = new System.Drawing.Point(22, 23);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(235, 32);
            this.label3.TabIndex = 39;
            this.label3.Text = "Báo cáo thống kê";
            // 
            // bntTKChauCay
            // 
            this.bntTKChauCay.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.bntTKChauCay.Location = new System.Drawing.Point(832, 172);
            this.bntTKChauCay.Name = "bntTKChauCay";
            this.bntTKChauCay.Size = new System.Drawing.Size(364, 72);
            this.bntTKChauCay.TabIndex = 40;
            this.bntTKChauCay.Text = "Thống kê chậu cây bán được";
            this.bntTKChauCay.UseVisualStyleBackColor = true;
            this.bntTKChauCay.Click += new System.EventHandler(this.bntTKChauCay_Click);
            // 
            // bntTKLoaiChauCay
            // 
            this.bntTKLoaiChauCay.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.bntTKLoaiChauCay.Location = new System.Drawing.Point(832, 250);
            this.bntTKLoaiChauCay.Name = "bntTKLoaiChauCay";
            this.bntTKLoaiChauCay.Size = new System.Drawing.Size(364, 72);
            this.bntTKLoaiChauCay.TabIndex = 41;
            this.bntTKLoaiChauCay.Text = "Thống kê loại chậu cây bán được";
            this.bntTKLoaiChauCay.UseVisualStyleBackColor = true;
            this.bntTKLoaiChauCay.Click += new System.EventHandler(this.bntTKLoaiChauCay_Click);
            // 
            // bntTKKhachHang
            // 
            this.bntTKKhachHang.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.bntTKKhachHang.Location = new System.Drawing.Point(833, 330);
            this.bntTKKhachHang.Name = "bntTKKhachHang";
            this.bntTKKhachHang.Size = new System.Drawing.Size(364, 72);
            this.bntTKKhachHang.TabIndex = 42;
            this.bntTKKhachHang.Text = "Thống kê khách hàng mua";
            this.bntTKKhachHang.UseVisualStyleBackColor = true;
            this.bntTKKhachHang.Click += new System.EventHandler(this.bntTKKhachHang_Click);
            // 
            // bntTKNhanVien
            // 
            this.bntTKNhanVien.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.bntTKNhanVien.Location = new System.Drawing.Point(833, 410);
            this.bntTKNhanVien.Name = "bntTKNhanVien";
            this.bntTKNhanVien.Size = new System.Drawing.Size(364, 72);
            this.bntTKNhanVien.TabIndex = 43;
            this.bntTKNhanVien.Text = "Thống kê nhân viên bán hàng";
            this.bntTKNhanVien.UseVisualStyleBackColor = true;
            this.bntTKNhanVien.Click += new System.EventHandler(this.bntTKNhanVien_Click);
            // 
            // lwChauCay
            // 
            this.lwChauCay.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Id,
            this.Ten,
            this.SoLuong,
            this.TongThanhTien});
            this.lwChauCay.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.lwChauCay.HideSelection = false;
            this.lwChauCay.Location = new System.Drawing.Point(67, 160);
            this.lwChauCay.Name = "lwChauCay";
            this.lwChauCay.Size = new System.Drawing.Size(688, 434);
            this.lwChauCay.TabIndex = 44;
            this.lwChauCay.UseCompatibleStateImageBehavior = false;
            this.lwChauCay.View = System.Windows.Forms.View.Details;
            // 
            // Id
            // 
            this.Id.Text = "Mã chậu";
            this.Id.Width = 80;
            // 
            // Ten
            // 
            this.Ten.Text = "Tên chậu";
            this.Ten.Width = 150;
            // 
            // SoLuong
            // 
            this.SoLuong.Text = "Số lượng bán được";
            this.SoLuong.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.SoLuong.Width = 150;
            // 
            // TongThanhTien
            // 
            this.TongThanhTien.Text = "Tổng thành tiền";
            this.TongThanhTien.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.TongThanhTien.Width = 305;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label4.Location = new System.Drawing.Point(391, 616);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(92, 20);
            this.label4.TabIndex = 45;
            this.label4.Text = "Tổng cộng :";
            // 
            // lbTongTien
            // 
            this.lbTongTien.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbTongTien.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lbTongTien.Location = new System.Drawing.Point(485, 611);
            this.lbTongTien.Name = "lbTongTien";
            this.lbTongTien.Size = new System.Drawing.Size(216, 30);
            this.lbTongTien.TabIndex = 46;
            this.lbTongTien.Text = "0";
            this.lbTongTien.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label5.Location = new System.Drawing.Point(708, 615);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(44, 20);
            this.label5.TabIndex = 48;
            this.label5.Text = "(vnd)";
            // 
            // lbTitle
            // 
            this.lbTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.lbTitle.Location = new System.Drawing.Point(69, 113);
            this.lbTitle.Name = "lbTitle";
            this.lbTitle.Size = new System.Drawing.Size(683, 30);
            this.lbTitle.TabIndex = 47;
            // 
            // lwLoaiChauCay
            // 
            this.lwLoaiChauCay.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4});
            this.lwLoaiChauCay.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.lwLoaiChauCay.HideSelection = false;
            this.lwLoaiChauCay.Location = new System.Drawing.Point(67, 160);
            this.lwLoaiChauCay.Name = "lwLoaiChauCay";
            this.lwLoaiChauCay.Size = new System.Drawing.Size(688, 434);
            this.lwLoaiChauCay.TabIndex = 49;
            this.lwLoaiChauCay.UseCompatibleStateImageBehavior = false;
            this.lwLoaiChauCay.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Mã loại chậu";
            this.columnHeader1.Width = 100;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Tên loại chậu";
            this.columnHeader2.Width = 150;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Số lượng bán được";
            this.columnHeader3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.columnHeader3.Width = 150;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Tổng thành tiền";
            this.columnHeader4.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.columnHeader4.Width = 285;
            // 
            // lwKhachHang
            // 
            this.lwKhachHang.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.maKH,
            this.tenKH,
            this.ngaySinh,
            this.sdt,
            this.soLanMua,
            this.soLuongMua,
            this.ThanhTien});
            this.lwKhachHang.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.lwKhachHang.HideSelection = false;
            this.lwKhachHang.Location = new System.Drawing.Point(67, 160);
            this.lwKhachHang.Name = "lwKhachHang";
            this.lwKhachHang.Size = new System.Drawing.Size(688, 434);
            this.lwKhachHang.TabIndex = 50;
            this.lwKhachHang.UseCompatibleStateImageBehavior = false;
            this.lwKhachHang.View = System.Windows.Forms.View.Details;
            // 
            // maKH
            // 
            this.maKH.Text = "Mã KH";
            // 
            // tenKH
            // 
            this.tenKH.Text = "Tên KH";
            this.tenKH.Width = 120;
            // 
            // ngaySinh
            // 
            this.ngaySinh.Text = "Ngày sinh";
            this.ngaySinh.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.ngaySinh.Width = 120;
            // 
            // sdt
            // 
            this.sdt.Text = "Số điện thoại";
            this.sdt.Width = 120;
            // 
            // soLanMua
            // 
            this.soLanMua.Text = "Số lần";
            this.soLanMua.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // soLuongMua
            // 
            this.soLuongMua.Text = "Số lượng";
            this.soLuongMua.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.soLuongMua.Width = 80;
            // 
            // ThanhTien
            // 
            this.ThanhTien.Text = "Tổng thành tiền";
            this.ThanhTien.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.ThanhTien.Width = 124;
            // 
            // lwNhanVien
            // 
            this.lwNhanVien.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader5,
            this.columnHeader6,
            this.columnHeader8,
            this.columnHeader9,
            this.columnHeader10,
            this.columnHeader11});
            this.lwNhanVien.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.lwNhanVien.HideSelection = false;
            this.lwNhanVien.Location = new System.Drawing.Point(67, 160);
            this.lwNhanVien.Name = "lwNhanVien";
            this.lwNhanVien.Size = new System.Drawing.Size(688, 434);
            this.lwNhanVien.TabIndex = 51;
            this.lwNhanVien.UseCompatibleStateImageBehavior = false;
            this.lwNhanVien.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Mã NV";
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "Tên nhân viên";
            this.columnHeader6.Width = 150;
            // 
            // columnHeader8
            // 
            this.columnHeader8.Text = "Tên tài khoản";
            this.columnHeader8.Width = 150;
            // 
            // columnHeader9
            // 
            this.columnHeader9.Text = "Số hóa đơn";
            this.columnHeader9.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.columnHeader9.Width = 100;
            // 
            // columnHeader10
            // 
            this.columnHeader10.Text = "Số lượng";
            this.columnHeader10.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.columnHeader10.Width = 80;
            // 
            // columnHeader11
            // 
            this.columnHeader11.Text = "Tổng thành tiền";
            this.columnHeader11.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.columnHeader11.Width = 143;
            // 
            // btnBackToMain
            // 
            this.btnBackToMain.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.btnBackToMain.Location = new System.Drawing.Point(1206, 12);
            this.btnBackToMain.Name = "btnBackToMain";
            this.btnBackToMain.Size = new System.Drawing.Size(108, 40);
            this.btnBackToMain.TabIndex = 52;
            this.btnBackToMain.Text = "Quay lại";
            this.btnBackToMain.UseVisualStyleBackColor = true;
            this.btnBackToMain.Click += new System.EventHandler(this.btnBackToMain_Click);
            // 
            // btnPrintStatic
            // 
            this.btnPrintStatic.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btnPrintStatic.Location = new System.Drawing.Point(67, 608);
            this.btnPrintStatic.Name = "btnPrintStatic";
            this.btnPrintStatic.Size = new System.Drawing.Size(170, 35);
            this.btnPrintStatic.TabIndex = 53;
            this.btnPrintStatic.Text = "In báo cáo";
            this.btnPrintStatic.UseVisualStyleBackColor = true;
            this.btnPrintStatic.Click += new System.EventHandler(this.btnPrintStatic_Click);
            // 
            // BaoCaoThongKeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1384, 761);
            this.Controls.Add(this.btnPrintStatic);
            this.Controls.Add(this.btnBackToMain);
            this.Controls.Add(this.lwNhanVien);
            this.Controls.Add(this.lwKhachHang);
            this.Controls.Add(this.lwLoaiChauCay);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lbTitle);
            this.Controls.Add(this.lbTongTien);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lwChauCay);
            this.Controls.Add(this.bntTKNhanVien);
            this.Controls.Add(this.bntTKKhachHang);
            this.Controls.Add(this.bntTKLoaiChauCay);
            this.Controls.Add(this.bntTKChauCay);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dpTo);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dpFrom);
            this.Name = "BaoCaoThongKeForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "BaoCaoThongKeForm";
            this.Load += new System.EventHandler(this.BaoCaoThongKeForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dpFrom;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dpTo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button bntTKChauCay;
        private System.Windows.Forms.Button bntTKLoaiChauCay;
        private System.Windows.Forms.Button bntTKKhachHang;
        private System.Windows.Forms.Button bntTKNhanVien;
        private System.Windows.Forms.ListView lwChauCay;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lbTongTien;
        private System.Windows.Forms.ColumnHeader Id;
        private System.Windows.Forms.ColumnHeader Ten;
        private System.Windows.Forms.ColumnHeader SoLuong;
        private System.Windows.Forms.ColumnHeader TongThanhTien;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lbTitle;
        private System.Windows.Forms.ListView lwLoaiChauCay;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ListView lwKhachHang;
        private System.Windows.Forms.ColumnHeader maKH;
        private System.Windows.Forms.ColumnHeader tenKH;
        private System.Windows.Forms.ColumnHeader ngaySinh;
        private System.Windows.Forms.ColumnHeader sdt;
        private System.Windows.Forms.ColumnHeader soLanMua;
        private System.Windows.Forms.ColumnHeader soLuongMua;
        private System.Windows.Forms.ColumnHeader ThanhTien;
        private System.Windows.Forms.ListView lwNhanVien;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader columnHeader8;
        private System.Windows.Forms.ColumnHeader columnHeader9;
        private System.Windows.Forms.ColumnHeader columnHeader10;
        private System.Windows.Forms.ColumnHeader columnHeader11;
        private System.Windows.Forms.Button btnBackToMain;
        private System.Windows.Forms.Button btnPrintStatic;
    }
}