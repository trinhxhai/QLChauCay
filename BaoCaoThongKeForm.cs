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
    public partial class BaoCaoThongKeForm : Form
    {
        // General

        public static string currentTab = "ChauCay";
        public static object currentList = "";
        public static int currentTotal = 0;
        public BaoCaoThongKeForm()
        {
            InitializeComponent();
        }

        private void BaoCaoThongKeForm_Load(object sender, EventArgs e)
        {
            LoadBCTKChauCay();
        }


        public void Reload()
        {
            switch (currentTab)
            {
                case "ChauCay":
                    LoadBCTKChauCay();
                    break;
                case "LoaiChauCay":
                    LoadBCTKLoaiChauCay();
                    break;
                case "KhachHang":
                    LoadBCTKKhachHang();
                    break;

                case "NhanVien":
                    LoadBCTKNhanVien();
                    break;
            }
        }
        public void LoadBCTKChauCay()
        {
            currentTab = "ChauCay";
            lwChauCay.Show();
            lwLoaiChauCay.Hide();
            lwKhachHang.Hide();
            lwNhanVien.Hide();

            lbTitle.Text = "Báo cáo thống kê theo Chậu cây";
            List<BCTK_ChauCay> srcChauCay = BaoCaoThongKe.GetBCTKChauCay(dpFrom.Value, dpTo.Value);
            if (srcChauCay == null) return;
            currentList = srcChauCay;

            int total = 0;
            lwChauCay.Items.Clear();
            foreach(var data in srcChauCay)
            {
                ListViewItem item = new ListViewItem(data.Id);
                item.SubItems.Add(data.Ten);
                item.SubItems.Add(data.SoLuong.ToString());
                item.SubItems.Add(data.TongThanhTien.ToString());
                lwChauCay.Items.Add(item);
                total += data.TongThanhTien;
            }
            currentTotal = total;
            lbTongTien.Text = total.ToString();

        }
        public void LoadBCTKLoaiChauCay()
        {
            currentTab = "LoaiChauCay";
            lwLoaiChauCay.Show();
            lwChauCay.Hide();
            lwKhachHang.Hide();
            lwNhanVien.Hide();

            lbTitle.Text = "Báo cáo thống kê theo Loại chậu cây";
            List<BCTK_LoaiChauCay> srcLoaiChauCay = BaoCaoThongKe.GetBCTKLoaiChauCay(dpFrom.Value, dpTo.Value);
            if (srcLoaiChauCay == null) return;
            currentList = srcLoaiChauCay;
            int total = 0;
            lwLoaiChauCay.Items.Clear();
            foreach (var data in srcLoaiChauCay)
            {
                ListViewItem item = new ListViewItem(data.Id);
                item.SubItems.Add(data.Ten);
                item.SubItems.Add(data.SoLuong.ToString());
                item.SubItems.Add(data.TongThanhTien.ToString());
                lwLoaiChauCay.Items.Add(item);
                total += data.TongThanhTien;
            }

            currentTotal = total;
            lbTongTien.Text = total.ToString();

        }
        public void LoadBCTKKhachHang()
        {
            currentTab = "KhachHang";
            lwKhachHang.Show();
            lwChauCay.Hide();
            lwLoaiChauCay.Hide();
            lwNhanVien.Hide();

            lbTitle.Text = "Báo cáo thống kê theo Khách hàng";
            List<BCTK_KhachHang> srcKhachHang = BaoCaoThongKe.GetBCTKKhachHang(dpFrom.Value, dpTo.Value);
            if (srcKhachHang == null) return;
            currentList = srcKhachHang;
            int total = 0;
            lwKhachHang.Items.Clear();
            foreach (var data in srcKhachHang)
            {
                ListViewItem item = new ListViewItem(data.Id);
                item.SubItems.Add(data.Ten);
                item.SubItems.Add(data.NgaySinh.ToString("dd/MM/yyyy"));
                item.SubItems.Add(data.Sdt);
                item.SubItems.Add(data.SoLanMua.ToString());
                item.SubItems.Add(data.SoLuong.ToString());
                item.SubItems.Add(data.TongThanhTien.ToString());
                lwKhachHang.Items.Add(item);
                total += data.TongThanhTien;
            }
            currentTotal = total;
            lbTongTien.Text = total.ToString();

        }
        public void LoadBCTKNhanVien()
        {
            currentTab = "NhanVien";
            lwNhanVien.Show();
            lwChauCay.Hide();
            lwLoaiChauCay.Hide();
            lwKhachHang.Hide();

            lbTitle.Text = "Báo cáo thống kê theo Nhân viên";
            List<BCTK_NhanVien> srcNhanVien = BaoCaoThongKe.GetBCTKNhanVien(dpFrom.Value, dpTo.Value);
            if (srcNhanVien == null) return;
            currentList = srcNhanVien;
            int total = 0;
            lwNhanVien.Items.Clear();
            foreach (var data in srcNhanVien)
            {
                ListViewItem item = new ListViewItem(data.Id);
                item.SubItems.Add(data.Ten);
                item.SubItems.Add(data.TenTaiKhoan);
                item.SubItems.Add(data.SoLuongHD.ToString());
                item.SubItems.Add(data.SoLuong.ToString());
                item.SubItems.Add(data.TongThanhTien.ToString());
                lwNhanVien.Items.Add(item);
                total += data.TongThanhTien;
            }
            currentTotal = total;
            lbTongTien.Text = total.ToString();

        }

        private void bntTKChauCay_Click(object sender, EventArgs e)
        {
            LoadBCTKChauCay();
        }

        private void bntTKLoaiChauCay_Click(object sender, EventArgs e)
        {
            LoadBCTKLoaiChauCay();
        }

        private void bntTKKhachHang_Click(object sender, EventArgs e)
        {
            LoadBCTKKhachHang();
        }

        private void bntTKNhanVien_Click(object sender, EventArgs e)
        {
            LoadBCTKNhanVien();
        }


        private void dpTo_ValueChanged(object sender, EventArgs e)
        {
            if(dpFrom.Value > dpTo.Value)
            {
                dpTo.Value = dpFrom.Value;
                MessageBox.Show("Khoảng thời gian không hợp lệ, mời chọn lại!");
                return;
            }
            Reload();
        }

        private void dpFrom_ValueChanged(object sender, EventArgs e)
        {
            if (dpFrom.Value > dpTo.Value)
            {
                dpFrom.Value = dpTo.Value;
                MessageBox.Show("Khoảng thời gian không hợp lệ, mời chọn lại!");
                return;
            }
            Reload();
        }


        private void btnBackToMain_Click(object sender, EventArgs e)
        {
            MainForm.mainform.Show();
            MainForm.mainform.NeedToClosed = false;
            this.Close();
        }

        private void btnPrintStatic_Click(object sender, EventArgs e)
        {
            using (PrintReportForm prf = new PrintReportForm(currentTab, currentList, dpFrom.Value, dpTo.Value, currentTotal))
            {
                prf.ShowDialog();
            }
        }
    }
}
