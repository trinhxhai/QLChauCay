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
    public partial class QLNhanVienForm : Form
    {
        public static List<NhanVien> srcLstNhanVien;

        public static DateTime DefaultTime = DateTime.Now;
        public static string PrefixMessageLabel = "Error: ";
        
        public QLNhanVienForm()
        {
            InitializeComponent();
        }

        private void QLNhanVienForm_Load(object sender, EventArgs e)
        {
            srcLstNhanVien = QLNhanVien.GetList();
            ReLoadList();
            ThemMode();
        }

        public void ReLoadList()
        {
            LoadList(srcLstNhanVien);
        }

        public void LoadList(List<NhanVien> lst)
        {
            lwNhanVien.Items.Clear();

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
                lwNhanVien.Items.Add(item);
            }

        }

        public NhanVien GetEditingNhanVien()
        {
            return new NhanVien()
            {
                Id = txtMa.Text,
                Ten = txtTen.Text,
                TenTaiKhoan = txtTenTaiKhoan.Text,
                MatKhau = txtMatKhau.Text,
                GioiTinh = (rbNam.Checked) ? "Nam" : "Nữ",
                NgaySinh = dNgaySinh.Value,
                DiaChi = txtDiaChi.Text,
                Sdt = txtSdt.Text
            };
        }


        public (bool,string) validateInputs(NhanVien nv)
        {

            // các validtion có thể dùng chung
            bool IsValid;
            string ErrorMsg = "";

            (IsValid, ErrorMsg) = QLNhanVien.IsValid(nv);

            if (!IsValid)
            {
                return (IsValid, ErrorMsg);
            }

            // các validation riêng biệt
            if (txtMatKhau.Text != txtReMatKhau.Text)
            {
                IsValid = false;
                ErrorMsg = "Mật khẩu không khớp !";
                return (IsValid, ErrorMsg);
            }
            return (true, "");
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            ClearErrorMessage();
            var newNV = GetEditingNhanVien();

            // các validtion có thể dùng chung
            bool IsValid;
            string ErrorMsg = "";
            (IsValid,ErrorMsg) = validateInputs(newNV);

            if (!IsValid)
            {
                SetErrorMessage(ErrorMsg);
                return;
            }

            // Không có lỗi gì thì thêm vào db

            bool IsSuccess = true;
            string CreateMsg = "";
            (IsSuccess, CreateMsg) = QLNhanVien.Add(newNV);

            if (IsSuccess)
            {
                ListViewItem item = new ListViewItem(newNV.Id);
                item.SubItems.Add(newNV.Ten);
                item.SubItems.Add(newNV.GioiTinh);
                item.SubItems.Add(newNV.NgaySinh.ToString("dd/MM/yyyy"));
                item.SubItems.Add(newNV.Sdt);
                item.SubItems.Add(newNV.DiaChi);
                item.SubItems.Add(newNV.ThoiGianTao.ToString("dd/MM/yyyy"));
                item.SubItems.Add(newNV.ThoiGianSua.ToString("dd/MM/yyyy"));
                //item.SubItems.Add(nv.Sdt);
                lwNhanVien.Items.Add(item);
                srcLstNhanVien.Add(newNV);
                ThemMode();
                MessageBox.Show("Thêm nhân viên thành công");

            }
            else
            {
                MessageBox.Show(CreateMsg);
            }
            
        }
        public void SetErrorMessage(string msg)
        {
            lbMessage.Text = PrefixMessageLabel + msg;
        }
        public void ClearErrorMessage()
        {
            lbMessage.Text = "";
        }

        public void clearInputs()
        {
            if (srcLstNhanVien.Count == 0)
            {
                txtMa.Text = "001";
            }
            else
            {
                txtMa.Text = CommonTask.NextId(srcLstNhanVien[srcLstNhanVien.Count - 1].Id);
            }

            txtTenTaiKhoan.Clear();
            txtMatKhau.Clear();
            txtReMatKhau.Clear();
            txtTen.Clear();
            dNgaySinh.Value = DefaultTime;
            //tx.Clear();
            rbNam.Checked = true;
            txtSdt.Clear();
            txtDiaChi.Clear();
            
        }
        public void FillInfo(NhanVien nv)
        {
            txtMa.Text = nv.Id.Trim();
            txtTenTaiKhoan.Text = nv.TenTaiKhoan.Trim();
            txtMatKhau.Text = nv.MatKhau.Trim();
            txtReMatKhau.Text = nv.MatKhau.Trim();
            txtTen.Text = nv.Ten.Trim();
            dNgaySinh.Value = nv.NgaySinh;
            dNgaySinh.Update();
            //tx.Clear();
            if (nv.GioiTinh == "Nam")
            {
                rbNam.Checked = true;
            }
            else
            {
                rbNu.Checked = true;
            }

            txtSdt.Text = nv.Sdt.Trim();
            txtDiaChi.Text = nv.DiaChi.Trim();
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

        private void lwNhanVien_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            var selectNV = srcLstNhanVien.FirstOrDefault(nv => nv.Id == e.Item.Text);
            FillInfo(selectNV);
            SuaMode();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            var nv = GetEditingNhanVien();

            bool IsValid;
            string ErrorMsg = "";
            (IsValid, ErrorMsg) = validateInputs(nv);

            if (!IsValid)
            {
                SetErrorMessage(ErrorMsg);
                return;
            }

            bool IsSuccess;
            string EditMsg = "";
            (IsSuccess,EditMsg) = QLNhanVien.Edit(nv);

            if (IsSuccess)
            {
                var selectItem = lwNhanVien.SelectedItems[0];
                var selectNV = srcLstNhanVien.FirstOrDefault(el => el.Id == selectItem.Text);

                selectNV.TenTaiKhoan = nv.TenTaiKhoan;
                selectNV.MatKhau = nv.MatKhau;
                selectNV.Ten = nv.Ten;
                selectNV.GioiTinh = nv.GioiTinh;
                selectNV.NgaySinh = nv.NgaySinh;
                selectNV.DiaChi = nv.DiaChi;
                selectNV.ThoiGianTao = nv.ThoiGianTao;
                selectNV.ThoiGianSua = nv.ThoiGianSua;


                selectItem.SubItems[1].Text = nv.Ten;
                selectItem.SubItems[2].Text = nv.GioiTinh;
                selectItem.SubItems[3].Text = nv.NgaySinh.ToString("dd/MM/yyyy");
                selectItem.SubItems[4].Text = nv.Sdt;
                selectItem.SubItems[5].Text = nv.DiaChi;
                selectItem.SubItems[6].Text = nv.ThoiGianTao.ToString("dd/MM/yyyy");
                selectItem.SubItems[7].Text = nv.ThoiGianSua.ToString("dd/MM/yyyy");

                MessageBox.Show("Sửa nhân viên thành công");

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
            var selectNV = srcLstNhanVien.FirstOrDefault(nv => nv.Id == lwNhanVien.SelectedItems[0].Text);
            QLNhanVien.Delete(selectNV);

            var item = lwNhanVien.Items.Cast<ListViewItem>().FirstOrDefault(it => it.Text == selectNV.Id);

            lwNhanVien.Items.Remove(item);
            srcLstNhanVien.Remove(selectNV);
            btnTimKiem_Click(sender, e);
            ThemMode();

            MessageBox.Show("Xóa nhân viên thành công");

        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            ThemMode();
            string searchText = txtTimKiem.Text;
            var filterList = srcLstNhanVien.Where(s => s.Ten.ToLower().Contains(searchText.ToLower())).ToList();
            if (String.IsNullOrEmpty(searchText.Trim()))
            {
                filterList = srcLstNhanVien;
            }

            LoadList(filterList);
        }

        private void txtTimKiem_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                btnTimKiem_Click(sender, e);
            }
        }

        private void btnHuyTimKiem_Click(object sender, EventArgs e)
        {
            txtTimKiem.Text = String.Empty;
            ReLoadList();
        }
    }
}
