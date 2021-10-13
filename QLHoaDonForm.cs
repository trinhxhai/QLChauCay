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
        public static List<HoaDon> srcLstHoaDon;
        public static List<ChiTietHoaDon> srcChiTietHoaDon;
        public static ChiTietHoaDon AddingChiTietHoaDon;
        public static HoaDon SelectedHoaDon;
        public static int total = 0;
        public static string PrefixMessageLabel = "Error: ";
        Bitmap bmp;
        public QLHoaDonForm()
        {
            InitializeComponent();
        }

        private void QLHoaDonForm_Load(object sender, EventArgs e)
        {

            cbKhachHang.DataSource = QLKhachHang.GetList();
            cbKhachHang.DisplayMember = "Ten";
            cbKhachHang.ValueMember = "Id";

            srcLstHoaDon = QLHoaDon.GetList();
            ReLoadList();
            ThemMode();
            btnSuaChau.Enabled = false;

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
        }
        public void SuaMode()
        {
            btnThemHD.Enabled = false;
            btnLuuHD.Enabled = true;
            btnHuyHD.Enabled = true;
            btnXoaHD.Enabled = true;
            btnPrintHD.Enabled = true;
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
                SuaMode();
                btnSuaChau.Enabled = true;
            }
            else
            {
                clearInputs();
                ThemMode();
                btnSuaChau.Enabled = false;
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

            MessageBox.Show("Xóa loại chậu cây thành công");
        }
        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            ThemMode();
            string searchText = txtTimKiem.Text;
            var filterList = srcLstHoaDon.Where(s => s.TenKhachHang.ToLower().Contains(searchText.ToLower())).ToList();
            if (String.IsNullOrEmpty(searchText.Trim()))
            {
                filterList = srcLstHoaDon;
            }

            LoadList(filterList);
        }

        public void ReLoadList()
        {
            LoadList(srcLstHoaDon);
        }

        public void LoadList(List<HoaDon> lst)
        {
            lwHoaDon.Items.Clear();

            for (int i = 0; i < lst.Count; i++)
            {
                var lcl = lst[i];

                ListViewItem item = new ListViewItem(lcl.Id);
                item.SubItems.Add(lcl.TenKhachHang);
                item.SubItems.Add(lcl.TenNhanVien);
                item.SubItems.Add(lcl.NgayMua.ToString());
                item.SubItems.Add(lcl.ThoiGianTao.ToString("dd/MM/yyyy"));
                item.SubItems.Add(lcl.ThoiGianSua.ToString("dd/MM/yyyy"));
                //item.SubItems.Add(nv.Sdt);
                lwHoaDon.Items.Add(item);
            }

        }
        private void btnHuy_Click(object sender, EventArgs e)
        {
            clearInputs();
            ThemMode();
        }

        private void btnHuyTimKiem_Click(object sender, EventArgs e)
        {
            txtTimKiem.Text = String.Empty;
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
            form.hoaDonId = SelectedHoaDon.Id;
            form.FormClosed += ReloadAfterEditListCTHD;
            form.ShowDialog();
        }
        public void ReloadAfterEditListCTHD(object sender, EventArgs e)
        {
            srcChiTietHoaDon = QLChiTietHoaDon.GetList(SelectedHoaDon.Id);
            lwCTHD.Items.Clear();
            total = 0;
            foreach (var cthd in srcChiTietHoaDon)
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

        private void btnPrintHD_Click(object sender, EventArgs e)
        {
            Graphics g = this.CreateGraphics();
            bmp = new Bitmap(this.Size.Width + 55, this.Size.Height);
            Graphics mg = Graphics.FromImage(bmp);
            int Offset = 0;

            string leftPadding = new string(' ', 15);
            int paddingTop = 60;
            
            // Tiêu đề
            var str = leftPadding + String.Format("{0,50} \n","HÓA ĐƠN");
            mg.DrawString(str, new Font("Arial Bold", 16),
                  new SolidBrush(Color.Black), 0, paddingTop + Offset);
            Offset += 60;

            // Header
            str = leftPadding + String.Format("{0,15} {1,30} {2, 15} {3, 15} {4, 15} {5, 15} \n",
                    "Mã chậu","Tên chậu", "Số lượng","Đơn giá","Khuyến mại","Thành tiền");
            mg.DrawString(str, new Font("Arial", 13),
                  new SolidBrush(Color.Black), 0, paddingTop + Offset);
            var test2 = str;
            leftPadding = new string(' ', 20);
            Offset += 40;

            for (int i = 0; i < lwCTHD.Items.Count; i++)
            {
                var test = lwCTHD.Items[i].SubItems[0].Text.Trim();
                // Draw the row details for ? receipt 
                str = leftPadding + String.Format("{0,15} {1,30} {2, 15} {3, 15} {4, 15} {5, 15} \n", 
                    lwCTHD.Items[i].SubItems[0].Text.Trim() , lwCTHD.Items[i].SubItems[1].Text.Trim(), lwCTHD.Items[i].SubItems[2].Text.Trim()
                    , lwCTHD.Items[i].SubItems[3].Text.Trim(), lwCTHD.Items[i].SubItems[4].Text.Trim(), lwCTHD.Items[i].SubItems[5].Text.Trim());

                mg.DrawString(str, new Font("Arial", 13),
                  new SolidBrush(Color.Black), 0, paddingTop + Offset);

                // Move the next print position 'down the page' ie, y axis increases from top to bottom
                Offset = Offset + 20;
            }

            printPreviewDialog1.ShowDialog();

        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawImage(bmp, 0, 0);
        }
    }
}
