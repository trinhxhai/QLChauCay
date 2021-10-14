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
    public partial class MainForm : Form
    {

        public static MainForm mainform;
        public bool NeedToClosed = true;
        public MainForm()
        {
            InitializeComponent();
            mainform = this;
        }

        private bool CheckLogin()
        {
            if (String.IsNullOrEmpty(LoginForm.LoginUserId))
            {
                MessageBox.Show("Đăng nhập để có thể sử dụng chức năng");
                return false;
            }
            return true;
        }

        private void btnOpenDangNhap_Click(object sender, EventArgs e)
        {
            LoginForm loginForm = new LoginForm();
            loginForm.FormClosed += ShowSuccessMsg;

            loginForm.ShowDialog();
            
        }

        public void ShowSuccessMsg(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(LoginForm.LoginUserId))
            {
                var nv = QLNhanVien.GetById(LoginForm.LoginUserId);

                if(nv != null)
                {
                    MessageBox.Show("Đăng nhập thành công");
                    btnDangXuat.Show();
                    btnOpenDangNhap.Hide();
                    lbLoginUser.Text = "Xin chào, " + nv.Ten;
                    lbLoginUser.Show();
                    ApplicationState.loginUser = nv;
                    return;
                }
            }

            btnOpenDangNhap.Show();
            btnDangXuat.Hide();
        }

        public void CloseMain(object sender, EventArgs e)
        {
            if (NeedToClosed)
            {
                this.Close();
            }
        }

        private void btnDangXuat_Click(object sender, EventArgs e)
        {
            LoginForm.LoginUserId = "";
            lbLoginUser.Hide();
            btnOpenDangNhap.Show();
            btnDangXuat.Hide();
        }

        private void btnQLNhanVien_Click(object sender, EventArgs e)
        {
            if (!CheckLogin())
            {
                return;
            }
            QLNhanVienForm qlNhanVienForm = new QLNhanVienForm();
            mainform.Hide();
            NeedToClosed = true;
            qlNhanVienForm.Closed += CloseMain;
            qlNhanVienForm.ShowDialog();
        }

        private void btnQLLoaiChauCay_Click(object sender, EventArgs e)
        {
            if (!CheckLogin())
            {
                return;
            }
            QLLoaiChauCayForm form = new QLLoaiChauCayForm();
            NeedToClosed = true;
            mainform.Hide();
            form.Closed += CloseMain;
            form.ShowDialog();
        }

        private void btnQLChauCay_Click(object sender, EventArgs e)
        {
            if (!CheckLogin())
            {
                return;
            }
            QLChauCayForm form = new QLChauCayForm();
            NeedToClosed = true;
            mainform.Hide();
            form.Closed += CloseMain;
            form.ShowDialog();
        }

        private void btnQLKhachHang_Click(object sender, EventArgs e)
        {
            if (!CheckLogin())
            {
                return;
            }
            QLKhachHangForm form = new QLKhachHangForm();
            NeedToClosed = true;
            mainform.Hide();
            form.Closed += CloseMain;
            form.ShowDialog();
        }

        private void btnQLHoaDon_Click(object sender, EventArgs e)
        {
            if (!CheckLogin())
            {
                return;
            }
            QLHoaDonForm form = new QLHoaDonForm();
            NeedToClosed = true;
            mainform.Hide();
            form.Closed += CloseMain;
            form.ShowDialog();
        }

        private void btnBCTK_Click(object sender, EventArgs e)
        {
            if (!CheckLogin())
            {
                return;
            }
            BaoCaoThongKeForm form = new BaoCaoThongKeForm();
            NeedToClosed = true;
            mainform.Hide();
            form.Closed += CloseMain;
            form.ShowDialog();
        }
    }
}
