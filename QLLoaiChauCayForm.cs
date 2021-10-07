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
    public partial class QLLoaiChauCayForm : Form
    {
        public static List<LoaiChauCay> srcLstLoaiChauCay;
        public static string PrefixMessageLabel = "Error: ";
        public QLLoaiChauCayForm()
        {
            InitializeComponent();
        }

        private void QLLoaiChauCayForm_Load(object sender, EventArgs e)
        {
            srcLstLoaiChauCay = QLLoaiChauCay.GetList();
            ReLoadList();
            ThemMode();
        }

        public void clearInputs()
        {
            if (srcLstLoaiChauCay.Count == 0)
            {
                txtMa.Text = "001";
            }
            else
            {
                txtMa.Text = CommonTask.NextId(srcLstLoaiChauCay[srcLstLoaiChauCay.Count - 1].Id);
            }
            txtTen.Clear();
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

        public LoaiChauCay GetEditingLoaiChauCay()
        {
            return new LoaiChauCay()
            {
                Id = txtMa.Text,
                Ten = txtTen.Text,
            };
        }
        public (bool, string) validateInputs(LoaiChauCay loaiChauCay)
        {

            // các validtion có thể dùng chung
            bool IsValid;
            string ErrorMsg = "";

            (IsValid, ErrorMsg) = QLLoaiChauCay.IsValid(loaiChauCay);

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

        private void btnThem_Click(object sender, EventArgs e)
        {
            ClearErrorMessage();
            var newCLCay = GetEditingLoaiChauCay();
            // các validtion có thể dùng chung
            bool IsValid;
            string ErrorMsg = "";
            (IsValid, ErrorMsg) = validateInputs(newCLCay);

            if (!IsValid)
            {
                SetErrorMessage(ErrorMsg);
                return;
            }

            // Không có lỗi gì thì thêm vào db

            bool IsSuccess = true;
            string CreateMsg = "";
            (IsSuccess, CreateMsg) = QLLoaiChauCay.Add(newCLCay);

            if (IsSuccess)
            {
                ListViewItem item = new ListViewItem(newCLCay.Id);
                item.SubItems.Add(newCLCay.Ten);
                item.SubItems.Add(DateTime.Now.ToString("dd/MM/yyyy"));
                item.SubItems.Add(DateTime.Now.ToString("dd/MM/yyyy"));
                //item.SubItems.Add(nv.Sdt);
                lwLoaiChauCay.Items.Add(item);
                srcLstLoaiChauCay.Add(newCLCay);
                ThemMode();
                MessageBox.Show("Thêm loại chậu cây thành công");

            }
            else
            {
                MessageBox.Show(CreateMsg);
            }

        }

        private void lwLoaiChauCay_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            var loaiChauCay = srcLstLoaiChauCay.FirstOrDefault(nv => nv.Id == e.Item.Text);
            FillInfo(loaiChauCay);
            SuaMode();
        }

        public void FillInfo(LoaiChauCay loaiChauCay)
        {
            txtMa.Text = loaiChauCay.Id.Trim();
            txtTen.Text = loaiChauCay.Ten.Trim();
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
            (IsSuccess, EditMsg) = QLLoaiChauCay.Edit(loaiChauCay);

            if (IsSuccess)
            {
                var selectItem = lwLoaiChauCay.SelectedItems[0];
                var selectNV = srcLstLoaiChauCay.FirstOrDefault(el => el.Id == selectItem.Text);

                selectNV.Ten = loaiChauCay.Ten;
                selectNV.ThoiGianTao = loaiChauCay.ThoiGianTao;
                selectNV.ThoiGianSua = loaiChauCay.ThoiGianSua;


                selectItem.SubItems[1].Text = loaiChauCay.Ten;
                selectItem.SubItems[2].Text = loaiChauCay.ThoiGianTao.ToString("dd/MM/yyyy");
                selectItem.SubItems[3].Text = loaiChauCay.ThoiGianSua.ToString("dd/MM/yyyy");

                MessageBox.Show("Sửa loại chậu cây thành công");

                ThemMode();

            }
            else
            {
                MessageBox.Show(EditMsg);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            var selectLCL = srcLstLoaiChauCay.FirstOrDefault(nv => nv.Id == lwLoaiChauCay.SelectedItems[0].Text);
            QLLoaiChauCay.Delete(selectLCL);

            var item = lwLoaiChauCay.Items.Cast<ListViewItem>().FirstOrDefault(it => it.Text == selectLCL.Id);

            lwLoaiChauCay.Items.Remove(item);
            srcLstLoaiChauCay.Remove(selectLCL);
            btnTimKiem_Click(sender, e);
            ThemMode();

            MessageBox.Show("Xóa nhân viên thành công");
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            ThemMode();
            string searchText = txtTimKiem.Text;
            var filterList = srcLstLoaiChauCay.Where(s => s.Ten.ToLower().Contains(searchText.ToLower())).ToList();
            if (String.IsNullOrEmpty(searchText.Trim()))
            {
                filterList = srcLstLoaiChauCay;
            }

            LoadList(filterList);
        }

        public void ReLoadList()
        {
            LoadList(srcLstLoaiChauCay);
        }

        public void LoadList(List<LoaiChauCay> lst)
        {
            lwLoaiChauCay.Items.Clear();

            for (int i = 0; i < lst.Count; i++)
            {
                var lcl = lst[i];

                ListViewItem item = new ListViewItem(lcl.Id);
                item.SubItems.Add(lcl.Ten);
                item.SubItems.Add(lcl.ThoiGianTao.ToString("dd/MM/yyyy"));
                item.SubItems.Add(lcl.ThoiGianSua.ToString("dd/MM/yyyy"));
                //item.SubItems.Add(nv.Sdt);
                lwLoaiChauCay.Items.Add(item);
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


    }
}
