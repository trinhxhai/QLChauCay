using System;
using System.Collections.Generic;

using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuanLyChauCayCanh.Business;

namespace QuanLyChauCayCanh
{
    public partial class LoginForm : Form
    {
        public static string LoginUserId;
        public LoginForm()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtTenTaiKhoan.Text;
            string password = txtMatKhau.Text;
            
            bool IsSuccess;
            string LoginMsg = "";
            (IsSuccess, LoginMsg) = QLHeThong.DangNhapTaiKhoan(username, password);
            
            if (!IsSuccess)
            {
                MessageBox.Show(LoginMsg);
                LoginUserId = "";
                return;
            }

            LoginUserId = LoginMsg;

            this.Close();
            
        }
    }
}
