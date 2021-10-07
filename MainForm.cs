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
        public static ApplicationState appState;

        public MainForm()
        {
            InitializeComponent();
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
                    return;
                }
            }

            btnOpenDangNhap.Show();
            btnDangXuat.Hide();
        }

        private void btnQLNhanVien_Click(object sender, EventArgs e)
        {
            QLNhanVienForm qlNhanVienForm = new QLNhanVienForm();
            qlNhanVienForm.ShowDialog();
        }

        private void btnDangXuat_Click(object sender, EventArgs e)
        {
            LoginForm.LoginUserId = "";

            lbLoginUser.Hide();
            btnOpenDangNhap.Show();
            btnDangXuat.Hide();
        }

        private void btnQLLoaiChauCay_Click(object sender, EventArgs e)
        {
            QLLoaiChauCayForm qlNhanVienForm = new QLLoaiChauCayForm();
            qlNhanVienForm.ShowDialog();
        }

        private void btnQLChauCay_Click(object sender, EventArgs e)
        {
            QLChauCayForm qlNhanVienForm = new QLChauCayForm();
            qlNhanVienForm.ShowDialog();
        }
    }
}
