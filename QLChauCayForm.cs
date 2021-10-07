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
    public partial class QLChauCayForm : Form
    {
        public static List<ChauCay> srcLstChauCay;
        public static List<LoaiChauCay> lsLoaiChauCay;
        public static string PrefixMessageLabel = "Error: ";
        public QLChauCayForm()
        {
            InitializeComponent();
        }

        private void QLChauCayForm_Load(object sender, EventArgs e)
        {


            lsLoaiChauCay = QLLoaiChauCay.GetList();
            lsBxLoaiChauCay.DisplayMember = "Ten";
            lsBxLoaiChauCay.ValueMember = "Id";

            foreach (var lcc in lsLoaiChauCay)
            {
                lsBxLoaiChauCay.Items.Add(lcc);
            }

            srcLstChauCay = QLChauCay.GetList();
            ReLoadList();
            ThemMode();

        }
        public void LoadList(List<ChauCay> lst)
        {
            lwChauCay.Items.Clear();

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
        public void ThemMode()
        {
            clearInputs();
            btnLuu.Enabled = false;
            btnHuy.Enabled = false;
            btnXoa.Enabled = false;
            btnThem.Enabled = true;
        }
        public void SuaMode()
        {
            btnThem.Enabled = false;
            btnLuu.Enabled = true;
            btnHuy.Enabled = true;
            btnXoa.Enabled = true;
        }
        public void clearInputs()
        {
            if (srcLstChauCay.Count == 0)
            {
                txtMa.Text = "001";
            }
            else
            {
                txtMa.Text = CommonTask.NextId(srcLstChauCay[srcLstChauCay.Count - 1].Id);
            }

            txtTen.Clear();
            txtChieuCao.Clear();
            txtChieuDai.Clear();
            txtChieuRong.Clear();
            txtMauSac.Clear();
            txtMoTa.Clear();
            txtSoLuong.Clear();
            txtGiaBan.Clear();

        }

        public void SetErrorMessage(string msg)
        {
            lbMessage.Text = PrefixMessageLabel + msg;
        }
        public void ClearErrorMessage()
        {
            lbMessage.Text = "";
        }

        public void LoadList(List<NhanVien> lst)
        {
            lwChauCay.Items.Clear();

            for (int i = 0; i < lst.Count; i++)
            {
                var nv = lst[i];

                ListViewItem item = new ListViewItem(nv.Id);
                item.SubItems.Add(nv.Ten);
                item.SubItems.Add(nv.GioiTinh);
                item.SubItems.Add(nv.NgaySinh.ToString("dd/MM/yyyy"));
                item.SubItems.Add(nv.Sdt);
                item.SubItems.Add(nv.DiaChi);
                item.SubItems.Add(nv.ThoiGianTao.ToString("dd/MM/yyyy"));
                item.SubItems.Add(nv.ThoiGianSua.ToString("dd/MM/yyyy"));
                //item.SubItems.Add(nv.Sdt);
                lwChauCay.Items.Add(item);
            }

        }

        public ChauCay GetEditingChauCay()
        {
            return new ChauCay()
            {
                Id = txtMa.Text,
                Ten = txtTen.Text,
                ChieuDai = txtChieuDai.Text,
                ChieuRong = txtChieuRong.Text,
                ChieuCao = txtChieuCao.Text,
                MauSac = txtMauSac.Text,
                MoTa = txtMoTa.Text,
                SoLuong = txtSoLuong.Text,
                GiaBan = txtGiaBan.Text,
                IdLoaiChauCay = ((LoaiChauCay)lsBxLoaiChauCay.SelectedItem)?.Id
            };
        }
        public (bool, string) validateInputs(ChauCay chauCay)
        {

            // các validtion có thể dùng chung
            bool IsValid;
            string ErrorMsg = "";

            (IsValid, ErrorMsg) = QLChauCay.IsValid(chauCay);

            if (!IsValid)
            {
                return (IsValid, ErrorMsg);
            }

            return (true, "");
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            ClearErrorMessage();
            var newCC = GetEditingChauCay();

            // các validtion có thể dùng chung
            bool IsValid;
            string ErrorMsg = "";
            (IsValid, ErrorMsg) = validateInputs(newCC);

            if (!IsValid)
            {
                SetErrorMessage(ErrorMsg);
                return;
            }

            // Không có lỗi gì thì thêm vào db

            bool IsSuccess = true;
            string CreateMsg = "";
            (IsSuccess, CreateMsg) = QLChauCay.Add(newCC);

            if (IsSuccess)
            {
                ListViewItem item = new ListViewItem(newCC.Id);
                item.SubItems.Add(newCC.Ten);
                item.SubItems.Add(newCC.ChieuDai);
                item.SubItems.Add(newCC.ChieuRong);
                item.SubItems.Add(newCC.ChieuCao);
                item.SubItems.Add(newCC.MauSac);
                item.SubItems.Add(newCC.MoTa);
                item.SubItems.Add(newCC.SoLuong);
                item.SubItems.Add(newCC.GiaBan);
                item.SubItems.Add(newCC.IdLoaiChauCay);
                item.SubItems.Add(newCC.ChieuDai);

                //item.SubItems.Add(nv.Sdt);
                lwChauCay.Items.Add(item);
                srcLstChauCay.Add(newCC);
                ThemMode();
                MessageBox.Show("Thêm chậu cây thành công");

            }
            else
            {
                MessageBox.Show(CreateMsg);
            }
        }
        public void FillInfo(ChauCay chauCay)
        {
            txtMa.Text = chauCay.Id.Trim();
            txtTen.Text = chauCay.Ten.Trim();
            txtChieuDai.Text = chauCay.ChieuDai.Trim();
            txtChieuRong.Text = chauCay.ChieuRong.Trim();
            txtChieuCao.Text = chauCay.ChieuCao.Trim();
            txtMauSac.Text = chauCay.MauSac.Trim();
            txtMoTa.Text = chauCay.MoTa.Trim();
            txtSoLuong.Text = chauCay.SoLuong.Trim();
            txtGiaBan.Text = chauCay.GiaBan.Trim();
            lsBxLoaiChauCay.SelectedItem = lsLoaiChauCay.FirstOrDefault(e => e.Id == chauCay.IdLoaiChauCay);
        }

        private void lwChauCay_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            var selectCC = srcLstChauCay.FirstOrDefault(cc => cc.Id == e.Item.Text);
            FillInfo(selectCC);
            SuaMode();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            var chauCay = GetEditingChauCay();

            bool IsValid;
            string ErrorMsg = "";
            (IsValid, ErrorMsg) = validateInputs(chauCay);

            if (!IsValid)
            {
                SetErrorMessage(ErrorMsg);
                return;
            }

            bool IsSuccess;
            string EditMsg = "";
            (IsSuccess, EditMsg) = QLChauCay.Edit(chauCay);

            if (IsSuccess)
            {
                var selectItem = lwChauCay.SelectedItems[0];
                var selectNV = srcLstChauCay.FirstOrDefault(el => el.Id == selectItem.Text);

                selectNV.Ten = chauCay.Ten;
                selectNV.ChieuDai = chauCay.ChieuDai;
                selectNV.ChieuRong = chauCay.ChieuRong;
                selectNV.ChieuCao = chauCay.ChieuCao;
                selectNV.MoTa = chauCay.MoTa;
                selectNV.MauSac = chauCay.MauSac;
                selectNV.SoLuong = chauCay.SoLuong;
                selectNV.GiaBan = chauCay.GiaBan;
                selectNV.IdLoaiChauCay = chauCay.IdLoaiChauCay;
                selectNV.ThoiGianSua = DateTime.Now;



                selectItem.SubItems[1].Text = chauCay.Ten;
                selectItem.SubItems[2].Text = chauCay.ChieuDai;
                selectItem.SubItems[3].Text = chauCay.ChieuRong;
                selectItem.SubItems[4].Text = chauCay.ChieuCao;
                selectItem.SubItems[5].Text = chauCay.MoTa;
                selectItem.SubItems[5].Text = chauCay.MauSac;
                selectItem.SubItems[6].Text = chauCay.SoLuong;
                selectItem.SubItems[7].Text = chauCay.GiaBan;
                selectItem.SubItems[8].Text = chauCay.IdLoaiChauCay;

                MessageBox.Show("Sửa chậu cây thành công");

                ThemMode();

            }
            else
            {
                MessageBox.Show(EditMsg);
            }

        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            clearInputs();
            ThemMode();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            var selectCC = srcLstChauCay.FirstOrDefault(nv => nv.Id == lwChauCay.SelectedItems[0].Text);
            QLChauCay.Delete(selectCC);

            var item = lwChauCay.Items.Cast<ListViewItem>().FirstOrDefault(it => it.Text == selectCC.Id);

            lwChauCay.Items.Remove(item);
            srcLstChauCay.Remove(selectCC);
            btnTimKiem_Click(sender, e);
            ThemMode();

            MessageBox.Show("Xóa nhân viên thành công");
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            ThemMode();
            string searchText = txtTimKiem.Text;
            var filterList = srcLstChauCay.Where(s => s.Ten.ToLower().Contains(searchText.ToLower())).ToList();
            if (String.IsNullOrEmpty(searchText.Trim()))
            {
                filterList = srcLstChauCay;
            }

            LoadList(filterList);
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
    }
}
