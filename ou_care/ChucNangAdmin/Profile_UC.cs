using BusinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using TransferObject;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;


namespace ou_care.ChucNangAdmin
{
    public partial class Profile_UC : UserControl
    {
        private UserServiceBL userService;
        private Acccount currentAccount;
        UsersDTO currentUser = Global.CurrentUser;
        public Profile_UC(Acccount account)
        {
            InitializeComponent();
            userService = new UserServiceBL();
            currentAccount = account;
        }

        private void Profile_UC_Load(object sender, EventArgs e)
        {
            if(currentAccount != null)
            {
                string username = currentAccount.Username;
                LoadProfile(username);
            }
            else
            {
                MessageBox.Show("Không tìm thấy thông tin người đăng nhập.");
            }


        }
        // Hàm tải thông tin profile
        public void LoadProfile(string username)
        {
            try
            {
                // Lấy thông tin người dùng từ UserService
                UsersDTO userProfile = userService.GetUserProfile(username);

                if (userProfile != null)
                {
                    // Gán thông tin vào các TextBox hoặc Label
                    txtUserRole.Text = userProfile.ID.ToString();
                    lbUsername.Text = userProfile.userName;
                    txtName.Text = userProfile.name;
                    txtEmail.Text = userProfile.email;
                    txtUserRole.Text = userProfile.roleID.ToString();
                }
                else
                {
                    MessageBox.Show("Không tìm thấy thông tin người dùng.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải thông tin profile: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private bool IsValidEmail(string email)
        {
            string pattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            return Regex.IsMatch(email, pattern);
        }
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                var userProfile = userService.GetUserProfile(currentAccount.Username);
                // Kiểm tra nếu có sự thay đổi (khác nội dung trên txt)
                bool hasChanges = txtName.Text != userProfile.name ||
                                  txtEmail.Text != userProfile.email ||
                                  (!string.IsNullOrEmpty(txtOldPass.Text) && !string.IsNullOrEmpty(txtNewPass.Text));

                if (!hasChanges)
                {
                    MessageBox.Show("Không có thay đổi nào được thực hiện.");
                    return;
                }

                if (string.IsNullOrEmpty(txtName.Text) || string.IsNullOrEmpty(txtEmail.Text))
                {
                    MessageBox.Show("Vui lòng điền đầy đủ thông tin.");
                    return;
                }

                // Kiểm tra email
                if (!IsValidEmail(txtEmail.Text))
                {
                    MessageBox.Show("Email không đúng định dạng!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                bool updated = userService.UpdateProfile(
                    currentAccount.Username,
                    txtName.Text,
                    txtEmail.Text,
                    txtOldPass.Text,
                    txtNewPass.Text,
                    1, // mặc định profile của admin vô được tới chức năng này thì nó phải là 1
                    Convert.ToInt32(txtUserRole.Text)
                );

                if (updated)
                {
                    MessageBox.Show("Cập nhật thành công.");
                    LoadProfile(currentAccount.Username);
                }
                else
                {
                    MessageBox.Show("Không có gì để cập nhật.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            txtEmail.Text = "";
            txtName.Text = "";
            txtOldPass.Text = "";
        }

    }
}
