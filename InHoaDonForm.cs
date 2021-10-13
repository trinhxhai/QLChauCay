using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using QuanLyChauCayCanh.Models;
using QuanLyChauCayCanh.Business;

namespace QuanLyChauCayCanh
{
    public partial class InHoaDonForm : Form
    {
        Bitmap bmp;

        public string HoaDonId = "001";
        public List<ChiTietHoaDon> srcLstCTHD;
        public int total = 0;
        public InHoaDonForm()
        {
            InitializeComponent();
            

        }

        private void InHoaDonForm_Load(object sender, EventArgs e)
        {
            srcLstCTHD = QLChiTietHoaDon.GetList(HoaDonId);

            lwCTHD.Items.Clear();
            total = 0;
            foreach (var cthd in srcLstCTHD)
            {
                ListViewItem item = new ListViewItem(cthd.IdChauCay);
                item.SubItems.Add(cthd.TenChauCay);
                item.SubItems.Add(cthd.GiaBan);
                item.SubItems.Add(cthd.SoLuong);
                item.SubItems.Add(cthd.KhuyenMai);
                var thanhtien = QLChiTietHoaDon.TinhThanhTien(cthd.SoLuong, cthd.GiaBan, cthd.KhuyenMai);
                item.SubItems.Add(thanhtien);
                total += int.Parse(thanhtien);
                //item.SubItems.Add(nv.Sdt);
                lwCTHD.Items.Add(item);
            }
            lbTong.Text = total.ToString();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            Graphics g = this.CreateGraphics();
            bmp = new Bitmap(this.Size.Width+55, this.Size.Height);
            Graphics mg = Graphics.FromImage(bmp);
            Size sz = new Size() { Height = this.Size.Height - 120, Width = this.Width + 55 };
            mg.CopyFromScreen(this.Location.X+18, this.Location.Y + 36, 100, 80, sz);
            printPreviewDialog1.ShowDialog();
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawImage(bmp, 0, 0);
        }

        
    }
}
