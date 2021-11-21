using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using QuanLyChauCayCanh.Business;
using QuanLyChauCayCanh.Models;

namespace QuanLyChauCayCanh
{
    public partial class ChiTietHoaDonForm : Form
    {
        public static List<ChauCay> srcLstChauCay;
        public static ChauCay SelectedChauCay;
        public static ChiTietHoaDon SelectedCTHD;
        public string hoaDonId;
        public int total = 0;
        public static List<ChiTietHoaDon> srcChiTietHoaDon;
        public static List<ChiTietHoaDon> originCTHD;
        public static bool IsEditing = false;
        public static bool IsThemThanhCong = false;

        public ChiTietHoaDonForm()
        {
            InitializeComponent();
        }

        private void ChiTietHoaDonForm_Load(object sender, EventArgs e)
        {
            srcLstChauCay = QLChauCay.GetList();
            srcChiTietHoaDon = QLChiTietHoaDon.GetList(hoaDonId);
            originCTHD = new List<ChiTietHoaDon>(srcChiTietHoaDon);
            LoadListCTHD(srcChiTietHoaDon);
            ReLoadList();
            clearInputs();
            ThemMode();
            btnThemHoaDon.Text = QLHoaDonForm.IsThemHoaDon ? "Thêm hóa đơn" : "Lưu hóa đơn";
            IsThemThanhCong = false;
        }

        public void LoadListCTHD(List<ChiTietHoaDon> lst)
        {
            lwCTHD.Items.Clear();
            //lwChauCay.LargeImageList = 
            total = 0;
            for (int i = 0; i < lst.Count; i++)
            {
                var cthd = lst[i];
                ListViewItem item = new ListViewItem(cthd.IdChauCay);
                item.SubItems.Add(cthd.TenChauCay);
                item.SubItems.Add(cthd.SoLuong);
                item.SubItems.Add(cthd.GiaBan);
                item.SubItems.Add(cthd.KhuyenMai);
                string thanhtien = QLChiTietHoaDon.TinhThanhTien(cthd.SoLuong, cthd.GiaBan, cthd.KhuyenMai);
                item.SubItems.Add(thanhtien);
                lwCTHD.Items.Add(item);
                total += int.Parse(thanhtien);
            }
            lbTong.Text = total.ToString();
        }
        public void LoadList(List<ChauCay> lst)
        {
            lwChauCay.Items.Clear();
            //lwChauCay.LargeImageList = 

            for (int i = 0; i < lst.Count; i++)
            {
                var cc = lst[i];

                ListViewItem item = new ListViewItem(cc.Id);
                item.SubItems.Add(cc.Ten);
                item.SubItems.Add(cc.ChieuDai);
                item.SubItems.Add(cc.ChieuRong);
                item.SubItems.Add(cc.ChieuCao);
                item.SubItems.Add(cc.MauSac);
                item.SubItems.Add(cc.MoTa);
                item.SubItems.Add(cc.SoLuong);
                item.SubItems.Add(cc.GiaBan);
                item.SubItems.Add(cc.IdLoaiChauCay);
                lwChauCay.Items.Add(item);

            }

        }
        public void ReLoadList()
        {
            LoadList(srcLstChauCay);
        }

        public ChiTietHoaDon GetEditingData()
        {
            return new ChiTietHoaDon
            {
                IdChauCay = SelectedChauCay.Id,
                IdHoaDon = hoaDonId,
                TenChauCay = SelectedChauCay.Ten,
                GiaBan = SelectedChauCay.GiaBan,
                SoLuong = txtSoLuong.Text,
                KhuyenMai = txtKhuyenMai.Text

            };
        }

        public void clearInputs()
        {
            txtKhuyenMai.Text = "0";
            txtSoLuong.Text = "0";
            UpdateThanhTien();
        }

        public void ThemMode()
        {
            btnThem.Text = "Thêm";
            btnXoaChau.Enabled = false;
            IsEditing = false;
            clearInputs();
        }
        public void SuaMode()
        {
            btnThem.Text = "Lưu";
            btnXoaChau.Enabled = true;
            IsEditing = true;
        }
        
        private void btnThem_Click(object sender, EventArgs e)
        {
            //ClearErrorMsg
            //ClearErrorMessage();
            if (SelectedChauCay == null) return; // *****************
            var newCTHD = GetEditingData();
            // các validtion có thể dùng chung

            // Không có lỗi gì thì thêm vào db
            if (!IsEditing)
            {
                bool IsSuccess = true;
                string CreateMsg = "";
                // (IsSuccess, CreateMsg) = QLChiTietHoaDon.Add(newCTHD);

                if (IsSuccess)
                {

                    ListViewItem item = new ListViewItem(newCTHD.IdChauCay);
                    item.SubItems.Add(newCTHD.TenChauCay);
                    item.SubItems.Add(newCTHD.SoLuong);
                    item.SubItems.Add(newCTHD.GiaBan);
                    item.SubItems.Add(newCTHD.KhuyenMai);
                    item.SubItems.Add(QLChiTietHoaDon.TinhThanhTien(newCTHD.SoLuong, newCTHD.GiaBan, newCTHD.KhuyenMai));
                    //item.SubItems.Add(nv.Sdt);
                    lwCTHD.Items.Add(item);
                    srcChiTietHoaDon.Add(newCTHD);
                    ThemMode();

                    total += int.Parse(QLChiTietHoaDon.TinhThanhTien(newCTHD.SoLuong, newCTHD.GiaBan, newCTHD.KhuyenMai));
                    lbTong.Text = total.ToString();
                    MessageBox.Show("Thêm chậu cây vào hóa đơn thành công");

                }
                else
                {
                    MessageBox.Show(CreateMsg);
                }
            }
            else
            {

                bool IsSuccess = true;
                string EditMsg = "";
                //(IsSuccess, EditMsg) = QLChiTietHoaDon.Edit(newCTHD);

                if (IsSuccess)
                {
                    //srcChiTietHoaDon = QLChiTietHoaDon.GetList(hoaDonId);
                    //LoadListCTHD(srcChiTietHoaDon);
                    var editingCTHD = srcChiTietHoaDon.FirstOrDefault(cthd => cthd.IdChauCay == newCTHD.IdChauCay);
                    editingCTHD.GiaBan = newCTHD.GiaBan;
                    editingCTHD.SoLuong = newCTHD.SoLuong;
                    editingCTHD.TenChauCay = newCTHD.TenChauCay;
                    editingCTHD.KhuyenMai = newCTHD.KhuyenMai;
                    LoadListCTHD(srcChiTietHoaDon);
                    MessageBox.Show("Sửa loại chậu cây thành công");
                    ThemMode();
                }
                else
                {
                    MessageBox.Show(EditMsg);
                }
            }
            

        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtKhuyenMai_TextChanged(object sender, EventArgs e)
        {
            string txt = txtKhuyenMai.Text;
            int km = -1;
            if ( int.TryParse(txt, out km))
            {
                if(0 <= km && km <= 100)
                {
                    //txtKhuyenMai.Text = km.ToString() + "%";
                    UpdateThanhTien();
                    return;
                }
            }
            txtKhuyenMai.Text = "";
            UpdateThanhTien();
        }

        private void txtSoLuong_TextChanged(object sender, EventArgs e)
        {
            string txt = txtSoLuong.Text;
            int sl = -1;
            if (int.TryParse(txt, out sl))
            {
                if (0 > sl)
                {
                    txtSoLuong.Text = "";
                    UpdateThanhTien();
                    return;
                }

                if (SelectedChauCay != null)
                {
                    int avaiable = int.Parse(SelectedChauCay.SoLuong);
                    if(avaiable < sl)
                    {
                        txtSoLuong.Text = avaiable.ToString();
                        UpdateThanhTien();
                        return;
                    }
                }

                UpdateThanhTien();
                return;
            }
            txtSoLuong.Text = "";
            UpdateThanhTien();
        }

        private void lwChauCay_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {

            if (e.IsSelected)
            {
                SelectedChauCay = srcLstChauCay.FirstOrDefault(cc => cc.Id == e.Item.Text);
                SelectedCTHD = srcChiTietHoaDon.FirstOrDefault(cc => cc.IdChauCay == e.Item.Text);
                if (srcChiTietHoaDon.Any(item => item.IdChauCay == SelectedChauCay.Id))
                {
                    SuaMode();
                    FillInputField(SelectedCTHD);
                }
                else
                {
                    ThemMode();
                    txtSoLuong_TextChanged(sender, e);
                }
            }
            else
            {
                SelectedChauCay = null;
            }

        }

        public void UpdateThanhTien()
        {
            int soLuong, khuyenMai;

            if(!int.TryParse(txtSoLuong.Text, out soLuong) || !int.TryParse(txtKhuyenMai.Text, out khuyenMai))
            {
                txtThanhTien.Text = "0";
                return;
            }
            if(lwChauCay.SelectedItems.Count == 0)
            {
                txtThanhTien.Text = "0";
                return;
            }
            txtThanhTien.Text = QLChiTietHoaDon.TinhThanhTien(txtSoLuong.Text, SelectedChauCay.GiaBan, txtKhuyenMai.Text);

        }

        public void FillInputField(ChiTietHoaDon cthd)
        {
            txtKhuyenMai.Text = cthd.KhuyenMai;
            txtSoLuong.Text = cthd.SoLuong;
            txtThanhTien.Text = QLChiTietHoaDon.TinhThanhTien(cthd.SoLuong, cthd.GiaBan, cthd.KhuyenMai);
        }

        private void lwCTHD_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            if (e.IsSelected)
            {
                SelectedChauCay = srcLstChauCay.FirstOrDefault(cc => cc.Id == e.Item.Text);
                SelectedCTHD = srcChiTietHoaDon.FirstOrDefault(cc => cc.IdChauCay == e.Item.Text);
                SuaMode();
                FillInputField(SelectedCTHD);
            }
            else
            {
                ThemMode();
            }
        }

        private void btnXoaChau_Click(object sender, EventArgs e)
        {
            //QLChiTietHoaDon.Delete(new ChiTietHoaDon {IdChauCay = SelectedChauCay.Id , IdHoaDon = hoaDonId });

            var lwitem = lwCTHD.Items.Cast<ListViewItem>().FirstOrDefault(it => it.Text == SelectedChauCay.Id);
            
            var selectedCTHD = srcChiTietHoaDon.FirstOrDefault(item => item.IdChauCay == SelectedChauCay.Id);
            total -= int.Parse(QLChiTietHoaDon.TinhThanhTien(selectedCTHD.SoLuong, selectedCTHD.GiaBan, selectedCTHD.KhuyenMai));
            lbTong.Text = total.ToString();
            lwCTHD.Items.Remove(lwitem);
            srcChiTietHoaDon.Remove(selectedCTHD);
            ThemMode();

            MessageBox.Show("Xóa chi tiết hóa đơn thành công");
        }


        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            ThemMode();
            string searchText = txtTimKiem.Text;
            var filterList = srcLstChauCay.Where(s => s.Ten.ToLower().Contains(searchText.ToLower())
            || s.Id.ToLower().Contains(searchText.ToLower())).ToList();
            if (String.IsNullOrEmpty(searchText.Trim()))
            {
                filterList = srcLstChauCay;
            }

            LoadList(filterList);
        }

        private void txtTimKiem_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnTimKiem_Click(sender, e);
            }
        }

        private void btnHuyTimKiem_Click(object sender, EventArgs e)
        {
            txtTimKiem.Text = String.Empty;
            ReLoadList();
        }

        private void btnThemHoaDon_Click(object sender, EventArgs e)
        {
            var newHoaDon = QLHoaDonForm.AddingHoaDon;
            bool IsSuccess = true;
            string CreateMsg ="";
            if(QLHoaDonForm.IsThemHoaDon)
                (IsSuccess, CreateMsg) = QLHoaDon.Add(newHoaDon);

            foreach(var ct in srcChiTietHoaDon)
            {
                if(originCTHD.FirstOrDefault(cthd => cthd.IdChauCay == ct.IdChauCay) != null) {
                    QLChiTietHoaDon.Edit(ct);
                }
                else
                {
                    QLChiTietHoaDon.Add(ct);
                }
            }

            foreach (var ct in originCTHD)
            {
                if (srcChiTietHoaDon.FirstOrDefault(cthd => cthd.IdChauCay == ct.IdChauCay) == null)
                {
                    QLChiTietHoaDon.Delete(ct);
                }
            }
            
            IsThemThanhCong = true;
            this.Close();
        }
    }
}
