using BusinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TransferObject;

namespace ou_care
{
    public partial class Login : Form
    {
        private UserServiceBL userService; // Khai báo UserService
        LogBL logBL = new LogBL();
        public Login()
        {
            InitializeComponent();
            userService = new UserServiceBL(); // Khởi tạo UserService
        }
        private bool isUserLogin(Acccount account)
        {
            try
            {
                return userService.IsUserLogin_ORM(account);
            }
            catch (Exception ex)
            {
                // Hiển thị chi tiết lỗi bao gồm inner exception
                string errorMessage = ex.Message;
                if (ex.InnerException != null)
                {
                    errorMessage += "\nInner Exception: " + ex.InnerException.Message;
                }
                MessageBox.Show("Lỗi khi đăng nhập: " + errorMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            //string user, pass;
            //// Lấy dữ liệu từ người dùng
            //user = txtUsername.Text;
            //pass = txtPw.Text;

            //Acccount account = new Acccount(user, pass);
            //if(string.IsNullOrEmpty(txtUsername.Text) || string.IsNullOrEmpty(txtPw.Text)) 
            //{
            //    MessageBox.Show("Vui lòng nhập đầy đủ thông tin username và password.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    return; 
            //}

            //if (isUserLogin(account))
            //{
            //    // Lấy thông tin người dùng và lưu vào Global
            //    UsersDTO userProfile = userService.GetUserProfile(user);
            //    if (userProfile != null)
            //    {
            //        Global.CurrentUser = userProfile;
            //        logBL.LogLogin(Global.CurrentUser.ID, Global.CurrentUser.ID);
            //        if(Global.CurrentUser.ID == 1)
            //        {
            //            Admin adminForm = new Admin(account); // Không cần truyền Acccount nữa
            //            this.Hide();
            //            adminForm.Show();
            //        }
            //        else
            //        {
            //            NhanVien nv = new NhanVien(); // Không cần truyền Acccount nữa
            //            this.Hide();
            //            nv.Show();
            //        }

            //    }
            //    else
            //    {
            //        MessageBox.Show("Không thể tải thông tin người dùng.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    }
            //}
            //else
            //{
            //    MessageBox.Show("Sai tài khoản hoặc mật khẩu", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}

            string user = txtUsername.Text;
            string pass = txtPw.Text;

            if (string.IsNullOrEmpty(user) || string.IsNullOrEmpty(pass))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin username và password.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            UsersDTO userProfile = userService.GetUserProfile(user);

            if (userProfile == null)
            {
                MessageBox.Show("Sai tài khoản hoặc mật khẩu", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (userProfile.IsActive != 1)
            {
                MessageBox.Show("Tài khoản của bạn đã bị vô hiệu hóa, vui lòng liên hệ quản trị viên để được hỗ trợ.", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Acccount account = new Acccount(user, pass);
            if (isUserLogin(account))
            {
                Global.CurrentUser = userProfile;
                logBL.LogLogin(Global.CurrentUser.ID, Global.CurrentUser.ID);

                if (Global.CurrentUser.roleID == 1) 
                {
                    Admin adminForm = new Admin(account);
                    this.Hide();
                    adminForm.Show();
                }
                else
                {
                    NhanVien nv = new NhanVien();
                    this.Hide();
                    nv.Show();
                }
            }
            else
            {
                MessageBox.Show("Sai tài khoản hoặc mật khẩu", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void checkPw_CheckedChanged(object sender, EventArgs e)
        {
            if (checkPw.Checked)
                txtPw.UseSystemPasswordChar = true;
            else
                txtPw.UseSystemPasswordChar = false;
        }

        private void btExit_Click(object sender, EventArgs e)
        {
            Application.Exit();

        }

        private void Login_Load(object sender, EventArgs e)
        {
            txtUsername.Text = "Admin01";
            txtPw.Text = "Admin123";
        }

        private void lbQuenMK_Click(object sender, EventArgs e)
        {
            QuenMK qmk = new QuenMK();
            qmk.Show();
        }

        private void txtUsername_TextChanged(object sender, EventArgs e)
        {

        }

    }
}
