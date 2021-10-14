
namespace QuanLyChauCayCanh
{
    partial class QLChauCayForm
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
            this.components = new System.ComponentModel.Container();
            this.lwChauCay = new System.Windows.Forms.ListView();
            this.Id = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Ten = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ChieuDai = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ChieuRong = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ChieuCao = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.MauSac = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.MoTa = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SoLuong = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.GiaBan = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.LoaiChauCay = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.txtChieuCao = new System.Windows.Forms.TextBox();
            this.lbMessage = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtTimKiem = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.btnHuyTimKiem = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cbLoaiChauCay = new System.Windows.Forms.ComboBox();
            this.picBox = new System.Windows.Forms.PictureBox();
            this.bntAddPic = new System.Windows.Forms.Button();
            this.label12 = new System.Windows.Forms.Label();
            this.txtMoTa = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtMauSac = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtChieuRong = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtChieuDai = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtTen = new System.Windows.Forms.TextBox();
            this.txtGiaBan = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtMa = new System.Windows.Forms.TextBox();
            this.txtSoLuong = new System.Windows.Forms.TextBox();
            this.btnThem = new System.Windows.Forms.Button();
            this.btnTimKiem = new System.Windows.Forms.Button();
            this.btnLuu = new System.Windows.Forms.Button();
            this.btnHuy = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.openImageDialog = new System.Windows.Forms.OpenFileDialog();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.btnBackToMain = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picBox)).BeginInit();
            this.SuspendLayout();
            // 
            // lwChauCay
            // 
            this.lwChauCay.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Id,
            this.Ten,
            this.ChieuDai,
            this.ChieuRong,
            this.ChieuCao,
            this.MauSac,
            this.MoTa,
            this.SoLuong,
            this.GiaBan,
            this.LoaiChauCay});
            this.lwChauCay.FullRowSelect = true;
            this.lwChauCay.GridLines = true;
            this.lwChauCay.HideSelection = false;
            this.lwChauCay.Location = new System.Drawing.Point(31, 109);
            this.lwChauCay.Name = "lwChauCay";
            this.lwChauCay.Size = new System.Drawing.Size(680, 565);
            this.lwChauCay.TabIndex = 35;
            this.lwChauCay.UseCompatibleStateImageBehavior = false;
            this.lwChauCay.View = System.Windows.Forms.View.Details;
            this.lwChauCay.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.lwChauCay_ItemSelectionChanged);
            // 
            // Id
            // 
            this.Id.Text = "Id";
            this.Id.Width = 50;
            // 
            // Ten
            // 
            this.Ten.Text = "Tên";
            this.Ten.Width = 120;
            // 
            // ChieuDai
            // 
            this.ChieuDai.Text = "Chiều dài";
            // 
            // ChieuRong
            // 
            this.ChieuRong.Text = "Chiều rộng";
            // 
            // ChieuCao
            // 
            this.ChieuCao.Text = "Chiều cao";
            // 
            // MauSac
            // 
            this.MauSac.Text = "Màu sắc";
            // 
            // MoTa
            // 
            this.MoTa.Text = "Mô tả";
            // 
            // SoLuong
            // 
            this.SoLuong.Text = "Số lượng";
            // 
            // GiaBan
            // 
            this.GiaBan.Text = "Giá bán";
            // 
            // LoaiChauCay
            // 
            this.LoaiChauCay.Text = "Loại chậu cây";
            // 
            // txtChieuCao
            // 
            this.txtChieuCao.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.txtChieuCao.Location = new System.Drawing.Point(137, 222);
            this.txtChieuCao.MaxLength = 30;
            this.txtChieuCao.Name = "txtChieuCao";
            this.txtChieuCao.Size = new System.Drawing.Size(250, 23);
            this.txtChieuCao.TabIndex = 8;
            // 
            // lbMessage
            // 
            this.lbMessage.Location = new System.Drawing.Point(42, 512);
            this.lbMessage.Name = "lbMessage";
            this.lbMessage.Size = new System.Drawing.Size(449, 64);
            this.lbMessage.TabIndex = 31;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label3.Location = new System.Drawing.Point(30, 48);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 17);
            this.label3.TabIndex = 12;
            this.label3.Text = "Mã :";
            // 
            // txtTimKiem
            // 
            this.txtTimKiem.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.txtTimKiem.Location = new System.Drawing.Point(121, 72);
            this.txtTimKiem.Name = "txtTimKiem";
            this.txtTimKiem.Size = new System.Drawing.Size(422, 26);
            this.txtTimKiem.TabIndex = 26;
            this.txtTimKiem.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtTimKiem_KeyDown);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label11.Location = new System.Drawing.Point(35, 74);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(79, 20);
            this.label11.TabIndex = 36;
            this.label11.Text = "Tìm kiếm :";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label9.Location = new System.Drawing.Point(30, 223);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(79, 17);
            this.label9.TabIndex = 24;
            this.label9.Text = "Chiều cao :";
            // 
            // btnHuyTimKiem
            // 
            this.btnHuyTimKiem.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btnHuyTimKiem.Location = new System.Drawing.Point(631, 72);
            this.btnHuyTimKiem.Name = "btnHuyTimKiem";
            this.btnHuyTimKiem.Size = new System.Drawing.Size(79, 27);
            this.btnHuyTimKiem.TabIndex = 29;
            this.btnHuyTimKiem.Text = "Hủy";
            this.btnHuyTimKiem.UseVisualStyleBackColor = true;
            this.btnHuyTimKiem.Click += new System.EventHandler(this.btnHuyTimKiem_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label8.Location = new System.Drawing.Point(30, 424);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(66, 17);
            this.label8.TabIndex = 22;
            this.label8.Text = "Giá bán :";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cbLoaiChauCay);
            this.groupBox1.Controls.Add(this.picBox);
            this.groupBox1.Controls.Add(this.bntAddPic);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.txtMoTa);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.txtMauSac);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txtChieuRong);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.txtChieuDai);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.lbMessage);
            this.groupBox1.Controls.Add(this.txtChieuCao);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.txtTen);
            this.groupBox1.Controls.Add(this.txtGiaBan);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.txtMa);
            this.groupBox1.Controls.Add(this.txtSoLuong);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.groupBox1.Location = new System.Drawing.Point(723, 69);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(590, 600);
            this.groupBox1.TabIndex = 34;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thông tin chậu cây";
            // 
            // cbLoaiChauCay
            // 
            this.cbLoaiChauCay.FormattingEnabled = true;
            this.cbLoaiChauCay.Location = new System.Drawing.Point(138, 469);
            this.cbLoaiChauCay.Name = "cbLoaiChauCay";
            this.cbLoaiChauCay.Size = new System.Drawing.Size(250, 28);
            this.cbLoaiChauCay.TabIndex = 42;
            // 
            // picBox
            // 
            this.picBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picBox.Location = new System.Drawing.Point(409, 49);
            this.picBox.Name = "picBox";
            this.picBox.Size = new System.Drawing.Size(150, 150);
            this.picBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picBox.TabIndex = 41;
            this.picBox.TabStop = false;
            // 
            // bntAddPic
            // 
            this.bntAddPic.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.bntAddPic.Location = new System.Drawing.Point(409, 205);
            this.bntAddPic.Name = "bntAddPic";
            this.bntAddPic.Size = new System.Drawing.Size(150, 30);
            this.bntAddPic.TabIndex = 37;
            this.bntAddPic.Text = "Thêm ảnh";
            this.bntAddPic.UseVisualStyleBackColor = true;
            this.bntAddPic.Click += new System.EventHandler(this.bntAddPic_Click);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label12.Location = new System.Drawing.Point(30, 474);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(104, 17);
            this.label12.TabIndex = 40;
            this.label12.Text = "Loại chậu cây :";
            // 
            // txtMoTa
            // 
            this.txtMoTa.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.txtMoTa.Location = new System.Drawing.Point(137, 310);
            this.txtMoTa.MaxLength = 100;
            this.txtMoTa.Multiline = true;
            this.txtMoTa.Name = "txtMoTa";
            this.txtMoTa.Size = new System.Drawing.Size(250, 51);
            this.txtMoTa.TabIndex = 38;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label6.Location = new System.Drawing.Point(30, 311);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(51, 17);
            this.label6.TabIndex = 39;
            this.label6.Text = "Mô tả :";
            // 
            // txtMauSac
            // 
            this.txtMauSac.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.txtMauSac.Location = new System.Drawing.Point(137, 268);
            this.txtMauSac.MaxLength = 30;
            this.txtMauSac.Name = "txtMauSac";
            this.txtMauSac.Size = new System.Drawing.Size(250, 23);
            this.txtMauSac.TabIndex = 36;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label5.Location = new System.Drawing.Point(30, 269);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(69, 17);
            this.label5.TabIndex = 37;
            this.label5.Text = "Màu sắc :";
            // 
            // txtChieuRong
            // 
            this.txtChieuRong.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.txtChieuRong.Location = new System.Drawing.Point(137, 176);
            this.txtChieuRong.MaxLength = 30;
            this.txtChieuRong.Name = "txtChieuRong";
            this.txtChieuRong.Size = new System.Drawing.Size(250, 23);
            this.txtChieuRong.TabIndex = 34;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label10.Location = new System.Drawing.Point(30, 177);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(85, 17);
            this.label10.TabIndex = 35;
            this.label10.Text = "Chiều rộng :";
            // 
            // txtChieuDai
            // 
            this.txtChieuDai.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.txtChieuDai.Location = new System.Drawing.Point(137, 131);
            this.txtChieuDai.MaxLength = 30;
            this.txtChieuDai.Name = "txtChieuDai";
            this.txtChieuDai.Size = new System.Drawing.Size(250, 23);
            this.txtChieuDai.TabIndex = 32;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label4.Location = new System.Drawing.Point(30, 132);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(75, 17);
            this.label4.TabIndex = 33;
            this.label4.Text = "Chiều dài :";
            // 
            // txtTen
            // 
            this.txtTen.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.txtTen.Location = new System.Drawing.Point(137, 89);
            this.txtTen.MaxLength = 30;
            this.txtTen.Name = "txtTen";
            this.txtTen.Size = new System.Drawing.Size(250, 23);
            this.txtTen.TabIndex = 5;
            // 
            // txtGiaBan
            // 
            this.txtGiaBan.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.txtGiaBan.Location = new System.Drawing.Point(137, 423);
            this.txtGiaBan.Name = "txtGiaBan";
            this.txtGiaBan.Size = new System.Drawing.Size(250, 23);
            this.txtGiaBan.TabIndex = 13;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label2.Location = new System.Drawing.Point(30, 90);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 17);
            this.label2.TabIndex = 7;
            this.label2.Text = "Tên :";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label7.Location = new System.Drawing.Point(30, 379);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(72, 17);
            this.label7.TabIndex = 20;
            this.label7.Text = "Số lượng :";
            // 
            // txtMa
            // 
            this.txtMa.Enabled = false;
            this.txtMa.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.txtMa.Location = new System.Drawing.Point(137, 47);
            this.txtMa.MaxLength = 3;
            this.txtMa.Name = "txtMa";
            this.txtMa.Size = new System.Drawing.Size(250, 23);
            this.txtMa.TabIndex = 4;
            // 
            // txtSoLuong
            // 
            this.txtSoLuong.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.txtSoLuong.Location = new System.Drawing.Point(137, 378);
            this.txtSoLuong.MaxLength = 10;
            this.txtSoLuong.Name = "txtSoLuong";
            this.txtSoLuong.Size = new System.Drawing.Size(250, 23);
            this.txtSoLuong.TabIndex = 12;
            // 
            // btnThem
            // 
            this.btnThem.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.btnThem.Location = new System.Drawing.Point(770, 675);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(108, 40);
            this.btnThem.TabIndex = 30;
            this.btnThem.Text = "Thêm";
            this.btnThem.UseVisualStyleBackColor = true;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // btnTimKiem
            // 
            this.btnTimKiem.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btnTimKiem.Location = new System.Drawing.Point(549, 71);
            this.btnTimKiem.Name = "btnTimKiem";
            this.btnTimKiem.Size = new System.Drawing.Size(76, 27);
            this.btnTimKiem.TabIndex = 28;
            this.btnTimKiem.Text = "Tìm";
            this.btnTimKiem.UseVisualStyleBackColor = true;
            this.btnTimKiem.Click += new System.EventHandler(this.btnTimKiem_Click);
            // 
            // btnLuu
            // 
            this.btnLuu.Enabled = false;
            this.btnLuu.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.btnLuu.Location = new System.Drawing.Point(909, 675);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(108, 40);
            this.btnLuu.TabIndex = 31;
            this.btnLuu.Text = "Lưu";
            this.btnLuu.UseVisualStyleBackColor = true;
            this.btnLuu.Click += new System.EventHandler(this.btnLuu_Click);
            // 
            // btnHuy
            // 
            this.btnHuy.Enabled = false;
            this.btnHuy.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.btnHuy.Location = new System.Drawing.Point(1172, 675);
            this.btnHuy.Name = "btnHuy";
            this.btnHuy.Size = new System.Drawing.Size(108, 40);
            this.btnHuy.TabIndex = 33;
            this.btnHuy.Text = "Hủy";
            this.btnHuy.UseVisualStyleBackColor = true;
            this.btnHuy.Click += new System.EventHandler(this.btnHuy_Click);
            // 
            // btnXoa
            // 
            this.btnXoa.Enabled = false;
            this.btnXoa.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.btnXoa.Location = new System.Drawing.Point(1037, 675);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(108, 40);
            this.btnXoa.TabIndex = 32;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.UseVisualStyleBackColor = true;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 21F);
            this.label1.Location = new System.Drawing.Point(29, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(233, 32);
            this.label1.TabIndex = 27;
            this.label1.Text = "Quản lý chậu cây";
            // 
            // openImageDialog
            // 
            this.openImageDialog.FileName = "openFileDialog1";
            // 
            // imageList1
            // 
            this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageList1.ImageSize = new System.Drawing.Size(16, 16);
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // btnBackToMain
            // 
            this.btnBackToMain.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.btnBackToMain.Location = new System.Drawing.Point(1205, 12);
            this.btnBackToMain.Name = "btnBackToMain";
            this.btnBackToMain.Size = new System.Drawing.Size(108, 40);
            this.btnBackToMain.TabIndex = 37;
            this.btnBackToMain.Text = "Quay lại";
            this.btnBackToMain.UseVisualStyleBackColor = true;
            this.btnBackToMain.Click += new System.EventHandler(this.btnBackToMain_Click);
            // 
            // QLChauCayForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1384, 761);
            this.Controls.Add(this.btnBackToMain);
            this.Controls.Add(this.lwChauCay);
            this.Controls.Add(this.txtTimKiem);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.btnHuyTimKiem);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnThem);
            this.Controls.Add(this.btnTimKiem);
            this.Controls.Add(this.btnLuu);
            this.Controls.Add(this.btnHuy);
            this.Controls.Add(this.btnXoa);
            this.Controls.Add(this.label1);
            this.Name = "QLChauCayForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "QLChauCayForm";
            this.Load += new System.EventHandler(this.QLChauCayForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ListView lwChauCay;
        private System.Windows.Forms.ColumnHeader Id;
        private System.Windows.Forms.ColumnHeader Ten;
        private System.Windows.Forms.TextBox txtChieuCao;
        private System.Windows.Forms.Label lbMessage;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtTimKiem;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button btnHuyTimKiem;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtTen;
        private System.Windows.Forms.TextBox txtGiaBan;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtMa;
        private System.Windows.Forms.TextBox txtSoLuong;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Button btnTimKiem;
        private System.Windows.Forms.Button btnLuu;
        private System.Windows.Forms.Button btnHuy;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtMoTa;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtMauSac;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtChieuRong;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtChieuDai;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ColumnHeader ChieuDai;
        private System.Windows.Forms.ColumnHeader ChieuRong;
        private System.Windows.Forms.ColumnHeader ChieuCao;
        private System.Windows.Forms.ColumnHeader MauSac;
        private System.Windows.Forms.ColumnHeader MoTa;
        private System.Windows.Forms.ColumnHeader SoLuong;
        private System.Windows.Forms.ColumnHeader GiaBan;
        private System.Windows.Forms.ColumnHeader LoaiChauCay;
        private System.Windows.Forms.Button bntAddPic;
        private System.Windows.Forms.OpenFileDialog openImageDialog;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.PictureBox picBox;
        private System.Windows.Forms.ComboBox cbLoaiChauCay;
        private System.Windows.Forms.Button btnBackToMain;
    }
}