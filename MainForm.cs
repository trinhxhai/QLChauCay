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
        

        public MainForm()
        {
            InitializeComponent();
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
            qlNhanVienForm.ShowDialog();
        }

        private void btnQLLoaiChauCay_Click(object sender, EventArgs e)
        {
            if (!CheckLogin())
            {
                return;
            }
            QLLoaiChauCayForm form = new QLLoaiChauCayForm();
            form.ShowDialog();
        }

        private void btnQLChauCay_Click(object sender, EventArgs e)
        {
            if (!CheckLogin())
            {
                return;
            }
            QLChauCayForm form = new QLChauCayForm();
            form.ShowDialog();
        }

        private void btnQLKhachHang_Click(object sender, EventArgs e)
        {
            if (!CheckLogin())
            {
                return;
            }
            QLKhachHangForm form = new QLKhachHangForm();
            form.ShowDialog();
        }

        private void btnQLHoaDon_Click(object sender, EventArgs e)
        {
            if (!CheckLogin())
            {
                return;
            }
            QLHoaDonForm form = new QLHoaDonForm();
            form.ShowDialog();
        }
    }
}
