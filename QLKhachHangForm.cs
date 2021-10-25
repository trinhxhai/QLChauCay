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
    public partial class QLKhachHangForm : Form
    {
        public static List<KhachHang> srcLstKhachHang;
        public static string PrefixMessageLabel = "Error: ";

        public static DateTime DefaultTime = DateTime.Now;
        public QLKhachHangForm()
        {
            InitializeComponent();
        }


        private void QLKhachHangForm_Load(object sender, EventArgs e)
        {
            srcLstKhachHang = QLKhachHang.GetList();
            ReLoadList();
            ThemMode();
        }

        public void clearInputs()
        {
            if (srcLstKhachHang.Count == 0)
            {
                txtMa.Text = "001";
            }
            else
            {
                txtMa.Text = CommonTask.NextId(srcLstKhachHang[srcLstKhachHang.Count - 1].Id);
            }
            txtTen.Clear();
            txtSDT.Clear();
            txtDiaChi.Clear();
            
            dNgaySinh.Value = DefaultTime;
        }

        public void ThemMode()
        {
            lwKhachHang.SelectedItems.Clear();
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

        public KhachHang GetEditingLoaiChauCay()
        {
            return new KhachHang()
            {
                Id = txtMa.Text,
                Ten = txtTen.Text,
                NgaySinh = dNgaySinh.Value,
                DiaChi = txtDiaChi.Text,
                SDT = txtSDT.Text
            };
        }
        public void FillInfo(KhachHang khachHang)
        {
            txtMa.Text = khachHang.Id.Trim();
            txtTen.Text = khachHang.Ten.Trim();
            txtSDT.Text = khachHang.SDT;
            txtDiaChi.Text = khachHang.DiaChi;
            dNgaySinh.Value = khachHang.NgaySinh;
            dNgaySinh.Update();
        }


        public (bool, string) validateInputs(KhachHang khachHang)
        {

            // các validtion có thể dùng chung
            bool IsValid;
            string ErrorMsg = "";

            (IsValid, ErrorMsg) = QLKhachHang.IsValid(khachHang);

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

        public void ReLoadList()
        {
            LoadList(srcLstKhachHang);
        }

        public void LoadList(List<KhachHang> lst)
        {
            lwKhachHang.Items.Clear();

            for (int i = 0; i < lst.Count; i++)
            {
                var kh = lst[i];

                ListViewItem item = new ListViewItem(kh.Id);
                item.SubItems.Add(kh.Ten);
                item.SubItems.Add(kh.NgaySinh.ToString());
                item.SubItems.Add(kh.SDT);
                item.SubItems.Add(kh.DiaChi);
                item.SubItems.Add(kh.ThoiGianTao.ToString("dd/MM/yyyy"));
                item.SubItems.Add(kh.ThoiGianSua.ToString("dd/MM/yyyy"));
                //item.SubItems.Add(nv.Sdt);
                lwKhachHang.Items.Add(item);
            }

        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            ClearErrorMessage();
            var newKH = GetEditingLoaiChauCay();
            // các validtion có thể dùng chung
            bool IsValid;
            string ErrorMsg = "";
            (IsValid, ErrorMsg) = validateInputs(newKH);

            if (!IsValid)
            {
                SetErrorMessage(ErrorMsg);
                return;
            }

            // Không có lỗi gì thì thêm vào db

            bool IsSuccess = true;
            string CreateMsg = "";
            (IsSuccess, CreateMsg) = QLKhachHang.Add(newKH);

            if (IsSuccess)
            {
                ListViewItem item = new ListViewItem(newKH.Id);
                item.SubItems.Add(newKH.Ten);
                item.SubItems.Add(newKH.NgaySinh.ToString());
                item.SubItems.Add(newKH.SDT);
                item.SubItems.Add(newKH.DiaChi);
                item.SubItems.Add(DateTime.Now.ToString("dd/MM/yyyy"));
                item.SubItems.Add(DateTime.Now.ToString("dd/MM/yyyy"));
                //item.SubItems.Add(nv.Sdt);
                lwKhachHang.Items.Add(item);
                srcLstKhachHang.Add(newKH);
                ThemMode();
                MessageBox.Show("Thêm loại khách hàng thành công");

            }
            else
            {
                MessageBox.Show(CreateMsg);
            }

        }
        private void lwLoaiChauCay_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            var loaiChauCay = srcLstKhachHang.FirstOrDefault(nv => nv.Id == e.Item.Text);
            if (e.IsSelected)
            {
                FillInfo(loaiChauCay);
                SuaMode();
            }
            else
            {
                clearInputs();
                ThemMode();
            }

        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            var loaiChauCay = GetEditingLoaiChauCay();
            loaiChauCay.ThoiGianSua = DateTime.Now;
            bool IsValid;
            string ErrorMsg = "";
            (IsValid, ErrorMsg) = validateInputs(loaiChauCay);

            if (!IsValid)
            {
                SetErrorMessage(ErrorMsg);
                return;
            }

            bool IsSuccess;
            string EditMsg = "";
            (IsSuccess, EditMsg) = QLKhachHang.Edit(loaiChauCay);

            if (IsSuccess)
            {
                var selectItem = lwKhachHang.SelectedItems[0];
                var selectNV = srcLstKhachHang.FirstOrDefault(el => el.Id == selectItem.Text);

                selectNV.Ten = loaiChauCay.Ten;
                selectNV.NgaySinh = loaiChauCay.NgaySinh;
                selectNV.SDT = loaiChauCay.SDT;
                selectNV.DiaChi = loaiChauCay.DiaChi;
                selectNV.ThoiGianTao = loaiChauCay.ThoiGianTao;
                selectNV.ThoiGianSua = loaiChauCay.ThoiGianSua;


                selectItem.SubItems[1].Text = loaiChauCay.Ten;
                selectItem.SubItems[2].Text = loaiChauCay.NgaySinh.ToString();
                selectItem.SubItems[3].Text = loaiChauCay.SDT;
                selectItem.SubItems[4].Text = loaiChauCay.DiaChi;
                selectItem.SubItems[5].Text = loaiChauCay.ThoiGianTao.ToString("dd/MM/yyyy");
                selectItem.SubItems[6].Text = loaiChauCay.ThoiGianSua.ToString("dd/MM/yyyy");

                MessageBox.Show("Sửa khách hàng thành công");

                ThemMode();
                

            }
            else
            {
                MessageBox.Show(EditMsg);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            var selectLCL = srcLstKhachHang.FirstOrDefault(nv => nv.Id == lwKhachHang.SelectedItems[0].Text);
            QLKhachHang.Delete(selectLCL);

            var item = lwKhachHang.Items.Cast<ListViewItem>().FirstOrDefault(it => it.Text == selectLCL.Id);

            

            var confirmResult = MessageBox.Show("Bạn có chắc muốn xóa khách hàng " + selectLCL.Ten + " ?",
                                     "Xác nhận xóa !",
                                     MessageBoxButtons.YesNo);
            if (confirmResult == DialogResult.Yes)
            {
                lwKhachHang.Items.Remove(item);
                srcLstKhachHang.Remove(selectLCL);
                btnTimKiem_Click(sender, e);
                ThemMode();

                MessageBox.Show("Xóa khách hàng thành công !");
            }
            else
            {
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            ThemMode();
            string searchText = txtTimKiem.Text;
            var filterList = srcLstKhachHang.Where(s => 
                s.Ten.ToLower().Contains(searchText.ToLower())
                || s.SDT.ToLower().Contains(searchText.ToLower())
                || s.Id.ToLower().Contains(searchText.ToLower())
            ).ToList();
            if (String.IsNullOrEmpty(searchText.Trim()))
            {
                filterList = srcLstKhachHang;
            }

            LoadList(filterList);
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

        private void btnBackToMain_Click(object sender, EventArgs e)
        {
            MainForm.mainform.Show();
            MainForm.mainform.NeedToClosed = false;
            this.Close();
        }

        private void txtSDT_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
            if (!e.Handled)
            {
                var khachHang = srcLstKhachHang.FirstOrDefault(kh => kh.SDT == txtSDT.Text + e.KeyChar);
                if(khachHang != null)
                {
                    FillInfo(khachHang);
                    SuaMode();
                }
            }
        }
    }
}
