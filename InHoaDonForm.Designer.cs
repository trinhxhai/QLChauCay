
namespace QuanLyChauCayCanh
{
    partial class InHoaDonForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InHoaDonForm));
            this.btnPrint = new System.Windows.Forms.Button();
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.printPreviewDialog1 = new System.Windows.Forms.PrintPreviewDialog();
            this.lwCTHD = new System.Windows.Forms.ListView();
            this.ma = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tenChau = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.soLuong = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.giaBan = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.khuyenMai = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.thanhTien = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label10 = new System.Windows.Forms.Label();
            this.lbTong = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnPrint
            // 
            this.btnPrint.Location = new System.Drawing.Point(474, 358);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(146, 35);
            this.btnPrint.TabIndex = 1;
            this.btnPrint.Text = "In hóa đơn";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
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
            this.lwCTHD.Location = new System.Drawing.Point(12, 44);
            this.lwCTHD.Name = "lwCTHD";
            this.lwCTHD.Size = new System.Drawing.Size(610, 254);
            this.lwCTHD.TabIndex = 49;
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
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label10.Location = new System.Drawing.Point(588, 314);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(34, 20);
            this.label10.TabIndex = 67;
            this.label10.Text = "vnd";
            // 
            // lbTong
            // 
            this.lbTong.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lbTong.Location = new System.Drawing.Point(425, 314);
            this.lbTong.Name = "lbTong";
            this.lbTong.Size = new System.Drawing.Size(158, 23);
            this.lbTong.TabIndex = 66;
            this.lbTong.Text = "0";
            this.lbTong.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label7.Location = new System.Drawing.Point(366, 314);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 20);
            this.label7.TabIndex = 65;
            this.label7.Text = "Tổng :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 21F);
            this.label1.Location = new System.Drawing.Point(7, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(122, 32);
            this.label1.TabIndex = 68;
            this.label1.Text = "Hóa đơn";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // InHoaDonForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(640, 419);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.lbTong);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.lwCTHD);
            this.Controls.Add(this.btnPrint);
            this.Name = "InHoaDonForm";
            this.Text = "InHoaDonForm";
            this.Load += new System.EventHandler(this.InHoaDonForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnPrint;
        private System.Drawing.Printing.PrintDocument printDocument1;
        private System.Windows.Forms.PrintPreviewDialog printPreviewDialog1;
        private System.Windows.Forms.ListView lwCTHD;
        private System.Windows.Forms.ColumnHeader ma;
        private System.Windows.Forms.ColumnHeader tenChau;
        private System.Windows.Forms.ColumnHeader soLuong;
        public System.Windows.Forms.ColumnHeader giaBan;
        private System.Windows.Forms.ColumnHeader khuyenMai;
        private System.Windows.Forms.ColumnHeader thanhTien;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label lbTong;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label1;
    }
}