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
    public partial class QLHoaDonForm : Form
    {
        public static List<HoaDon> srcLstHoaDon = new List<HoaDon>();
        public static List<ChiTietHoaDon> srcChiTietHoaDon = new List<ChiTietHoaDon>();
        
        public static ChiTietHoaDon AddingChiTietHoaDon;
        
        public static bool IsThemHoaDon = true;
        public static HoaDon SelectedHoaDon;

        public static HoaDon AddingHoaDon;
        public static int total = 0;
        public static string PrefixMessageLabel = "Error: ";
        public static DateTime DefaultTimeTo = DateTime.Now;
        public static DateTime DefaultTimeFrom = DateTime.Now.Subtract(new System.TimeSpan(30, 0, 0, 0));
        public QLHoaDonForm()
        {
            InitializeComponent();
        }

        private void QLHoaDonForm_Load(object sender, EventArgs e)
        {

            cbKhachHang.DataSource = QLKhachHang.GetList();
            cbKhachHang.DisplayMember = "Ten";
            cbKhachHang.ValueMember = "Id";

            dBuyTimeFrom.Value = DefaultTimeFrom;
            dBuyTimeTo.Value = DefaultTimeTo;
            dCreateTimeFrom.Value = DefaultTimeFrom;
            dCreateTimeTo.Value = DefaultTimeTo;

            srcLstHoaDon = QLHoaDon.GetList();
            ReLoadList();
            ThemMode();
        }

        public void clearInputs()
        {
            if (srcLstHoaDon.Count == 0)
            {
                txtMa.Text = "001";
            }
            else
            {
                txtMa.Text = CommonTask.NextId(srcLstHoaDon[srcLstHoaDon.Count - 1].Id);
            }
            dBuyTimeFrom.Value = DefaultTimeFrom;
            dBuyTimeTo.Value = DefaultTimeTo;
            dCreateTimeFrom.Value = DefaultTimeFrom;
            dCreateTimeTo.Value = DefaultTimeTo;
            cbKhachHang.Refresh();
        }

        public void ThemMode()
        {
            clearInputs();
            btnLuuHD.Enabled = false;
            btnHuyHD.Enabled = false;
            btnXoaHD.Enabled = false;
            btnThemHD.Enabled = true;
            btnPrintHD.Enabled = false;
            IsThemHoaDon = true;
            btnSuaChau.Enabled = true;
            lwCTHD.Items.Clear();
        }
        public void SuaMode()
        {
            btnThemHD.Enabled = false;
            btnLuuHD.Enabled = true;
            btnHuyHD.Enabled = true;
            btnXoaHD.Enabled = true;
            btnPrintHD.Enabled = true;

            if (SelectedHoaDon.DaIn)
            {
                btnLuuHD.Enabled = false;
                btnXoaHD.Enabled = false;
                btnSuaChau.Enabled = false;
            }

            IsThemHoaDon = false;
        }

        public HoaDon GetEditingLoaiChauCay()
        {
            return new HoaDon()
            {
                Id = txtMa.Text,
                IdKhachHang = cbKhachHang.SelectedValue.ToString(),
                TenKhachHang = cbKhachHang.Text,
                IdNhanVien = ApplicationState.loginUser.Id,
                TenNhanVien = ApplicationState.loginUser.Ten,
        };
        }
        public (bool, string) validateInputs(HoaDon hoaDon)
        {

            // các validtion có thể dùng chung
            bool IsValid;
            string ErrorMsg = "";

            (IsValid, ErrorMsg) = QLHoaDon.IsValid(hoaDon);

            if (!IsValid)
            {
                return (IsValid, ErrorMsg);
            }

            // các validation riêng biệt

            return (true, "");
        }
        public void SetErrorMessage(string msg)
        {
            lbMessage.Text = PrefixMessageLabel + msg;
        }
        public void ClearErrorMessage()
        {
            lbMessage.Text = "";
        }

        private void btnThemHD_Click(object sender, EventArgs e)
        {
            ClearErrorMessage();
            var newHoaDon = GetEditingLoaiChauCay();
            // các validtion có thể dùng chung
            bool IsValid;
            string ErrorMsg = "";
            (IsValid, ErrorMsg) = validateInputs(newHoaDon);

            if (!IsValid)
            {
                SetErrorMessage(ErrorMsg);
                return;
            }

            // Không có lỗi gì thì thêm vào db

            bool IsSuccess = true;
            string CreateMsg = "";
            (IsSuccess, CreateMsg) = QLHoaDon.Add(newHoaDon);

            newHoaDon.NgayMua = DateTime.Now;
            newHoaDon.ThoiGianSua = DateTime.Now;
            newHoaDon.ThoiGianTao = DateTime.Now;

            if (IsSuccess)
            {

                ListViewItem item = new ListViewItem(newHoaDon.Id);
                item.SubItems.Add(newHoaDon.TenKhachHang);
                item.SubItems.Add(newHoaDon.TenNhanVien);
                item.SubItems.Add(newHoaDon.NgayMua.ToString("dd/MM/yyyy"));
                item.SubItems.Add(newHoaDon.ThoiGianSua.ToString("dd/MM/yyyy"));
                item.SubItems.Add(newHoaDon.ThoiGianTao.ToString("dd/MM/yyyy"));
                //item.SubItems.Add(nv.Sdt);
                lwHoaDon.Items.Add(item);
                srcLstHoaDon.Add(newHoaDon);
                ThemMode();
                MessageBox.Show("Thêm hóa đơn thành công");

            }
            else
            {
                MessageBox.Show(CreateMsg);
            }
        }

        private void lwLoaiChauCay_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            SelectedHoaDon = srcLstHoaDon.FirstOrDefault(nv => nv.Id == e.Item.Text);
            if (e.IsSelected)
            {
                FillInfo(SelectedHoaDon);
                btnSuaChau.Enabled = true;
                SuaMode();
            }
            else
            {
                clearInputs();
                ThemMode();
            }
        }
        public void FillInfo(HoaDon hoaDon)
        {
            txtMa.Text = hoaDon.Id.Trim();
            cbKhachHang.SelectedValue = hoaDon.IdKhachHang;
            srcChiTietHoaDon = QLChiTietHoaDon.GetList(hoaDon.Id);
            lwCTHD.Items.Clear();
            total = 0;
            foreach (var cthd in srcChiTietHoaDon)
            {
                ListViewItem item = new ListViewItem(cthd.IdChauCay);
                item.SubItems.Add(cthd.TenChauCay);
                item.SubItems.Add(cthd.GiaBan);
                item.SubItems.Add(cthd.SoLuong);
                item.SubItems.Add(cthd.KhuyenMai);
                string thanhtien = QLChiTietHoaDon.TinhThanhTien(cthd.SoLuong, cthd.GiaBan, cthd.KhuyenMai);
                item.SubItems.Add(thanhtien);
                total += int.Parse(thanhtien);
                //item.SubItems.Add(nv.Sdt);
                lwCTHD.Items.Add(item);
            }
            lbTong.Text = total.ToString();
        }
        

        private void btnLuuHD_Click(object sender, EventArgs e)
        {
            var hoaDon = GetEditingLoaiChauCay();
            hoaDon.ThoiGianSua = DateTime.Now;
            bool IsValid;
            string ErrorMsg = "";
            (IsValid, ErrorMsg) = validateInputs(hoaDon);

            if (!IsValid)
            {
                SetErrorMessage(ErrorMsg);
                return;
            }

            bool IsSuccess;
            string EditMsg = "";
            (IsSuccess, EditMsg) = QLHoaDon.Edit(hoaDon);

            if (IsSuccess)
            {
                var selectItem = lwHoaDon.SelectedItems[0];
                var selectHD = srcLstHoaDon.FirstOrDefault(el => el.Id == selectItem.Text);


                selectHD.IdKhachHang = hoaDon.IdKhachHang;
                selectHD.IdNhanVien = hoaDon.IdNhanVien;
                selectHD.ThoiGianTao = hoaDon.ThoiGianTao;
                selectHD.ThoiGianSua = hoaDon.ThoiGianSua;


                selectItem.SubItems[1].Text = hoaDon.TenKhachHang;
                selectItem.SubItems[2].Text = hoaDon.TenNhanVien;
                selectItem.SubItems[3].Text = hoaDon.ThoiGianTao.ToString("dd/MM/yyyy");
                selectItem.SubItems[4].Text = hoaDon.ThoiGianSua.ToString("dd/MM/yyyy");

                MessageBox.Show("Sửa hóa đơn thành công");

                ThemMode();

            }
            else
            {
                MessageBox.Show(EditMsg);
            }
        }

        private void btnXoaHD_Click(object sender, EventArgs e)
        {
            var selectHD = srcLstHoaDon.FirstOrDefault(nv => nv.Id == lwHoaDon.SelectedItems[0].Text);
            QLHoaDon.Delete(selectHD);

            var item = lwHoaDon.Items.Cast<ListViewItem>().FirstOrDefault(it => it.Text == selectHD.Id);

            lwHoaDon.Items.Remove(item);
            srcLstHoaDon.Remove(selectHD);
            btnTimKiem_Click(sender, e);
            ThemMode();

            MessageBox.Show("Xóa hóa đơn thành công");
        }
        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            ThemMode();
            string searchText = txtTimKiem.Text;
            var filterList = srcLstHoaDon.Where(s => 
                (s.TenKhachHang.ToLower().Contains(searchText.ToLower())
                || s.TenNhanVien.ToLower().Contains(searchText.ToLower())
                || s.Id.ToLower().Contains(searchText.ToLower()))
                && (dCreateTimeFrom.Value <= s.ThoiGianTao && s.ThoiGianTao <= dCreateTimeTo.Value)
                && (dBuyTimeFrom.Value <= s.NgayMua && s.NgayMua <= dBuyTimeTo.Value)
                ).ToList();
            if (String.IsNullOrEmpty(searchText.Trim()))
            {
                filterList = srcLstHoaDon;
            }

            LoadListHD(filterList);
        }

        public void ReLoadList()
        {
            LoadListHD(srcLstHoaDon);
            LoadListCTHD(srcChiTietHoaDon);
        }

        public void LoadListHD(List<HoaDon> lst)
        {
            lwHoaDon.Items.Clear();

            for (int i = 0; i < lst.Count; i++)
            {
                var lcl = lst[i];

                ListViewItem item = new ListViewItem(lcl.Id);
                item.SubItems.Add(lcl.TenKhachHang);
                item.SubItems.Add(lcl.TenNhanVien);
                item.SubItems.Add(lcl.NgayMua.ToString("dd/MM/yyyy"));
                item.SubItems.Add(lcl.ThoiGianTao.ToString("dd/MM/yyyy"));
                item.SubItems.Add(lcl.ThoiGianSua.ToString("dd/MM/yyyy"));
                //item.SubItems.Add(nv.Sdt);
                lwHoaDon.Items.Add(item);
            }
            

        }
        public void LoadListCTHD(List<ChiTietHoaDon> lst)
        {
            lwCTHD.Items.Clear();
            total = 0;
            foreach (var cthd in srcChiTietHoaDon)
            {
                ListViewItem item = new ListViewItem(cthd.IdChauCay);
                item.SubItems.Add(cthd.TenChauCay);
                item.SubItems.Add(cthd.SoLuong);
                item.SubItems.Add(cthd.GiaBan);
                item.SubItems.Add(cthd.KhuyenMai);
                var thanhtien = QLChiTietHoaDon.TinhThanhTien(cthd.SoLuong, cthd.GiaBan, cthd.KhuyenMai);
                item.SubItems.Add(thanhtien);
                total += int.Parse(thanhtien);
                //item.SubItems.Add(nv.Sdt);
                lwCTHD.Items.Add(item);
            }
            lbTong.Text = total.ToString();

        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            clearInputs();
            ThemMode();
        }

        private void btnHuyTimKiem_Click(object sender, EventArgs e)
        {
            txtTimKiem.Text = String.Empty;
            dBuyTimeFrom.Value = DefaultTimeTo;
            dBuyTimeTo.Value = DefaultTimeTo;
            dCreateTimeFrom.Value = DefaultTimeTo;
            dCreateTimeTo.Value = DefaultTimeTo;
            txtTimKiem.Text = "";
            ReLoadList();
        }

        private void txtTimKiem_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnTimKiem_Click(sender, e);
            }
        }


        // Chi tiết hóa đơn

        private void btnSuaChau_Click(object sender, EventArgs e)
        {
            ChiTietHoaDonForm form = new ChiTietHoaDonForm();
            AddingHoaDon = GetEditingLoaiChauCay();
            form.hoaDonId = AddingHoaDon.Id;
            form.FormClosed += ReloadAfterEditListCTHD;
            form.ShowDialog();
        }
        public void ReloadAfterEditListCTHD(object sender, EventArgs e)
        {
            if (ChiTietHoaDonForm.IsThemThanhCong)
            {

                if (IsThemHoaDon)
                {
                    MessageBox.Show("Thêm thành công");
                }
                else
                {
                    MessageBox.Show("Lưu thành công");
                }

                srcLstHoaDon = QLHoaDon.GetList();
                ReLoadList();
                //srcChiTietHoaDon = QLChiTietHoaDon.GetList(AddingHoaDon.Id);
                //LoadListCTHD(srcChiTietHoaDon);

                srcChiTietHoaDon = new List<ChiTietHoaDon>();
                LoadListCTHD(srcChiTietHoaDon);
                ThemMode();

            }
            else
            {
                //MessageBox.Show("Lỗi vui lòng thử lại!");
            }

        }

        private void btnPrintHD_Click(object sender, EventArgs e)
        {
            InHoaDonForm form = new InHoaDonForm();
            QLHoaDon.InHoaDon(SelectedHoaDon.Id);
            ThemMode();
            form.HoaDonId = SelectedHoaDon.Id;
            form.TenKhachHang = cbKhachHang.Text;
            form.ShowDialog();
            var hoaDon = srcLstHoaDon.FirstOrDefault(hd => hd.Id == SelectedHoaDon.Id);
            hoaDon.DaIn = true;

        }

        private void btnBackToMain_Click(object sender, EventArgs e)
        {
            MainForm.mainform.Show();
            MainForm.mainform.NeedToClosed = false;
            this.Close();
        }


    }
}
