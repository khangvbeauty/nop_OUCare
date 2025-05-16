using BusinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using TransferObject;

namespace ou_care.ChucNangAdmin
{
    public partial class Edit_UC : UserControl
    {
        private UserServiceBL userService;
        private string username; // Lưu username của người dùng được chọn
        private int ID; // Lưu id của người dùng được chọn
        UsersDTO currentUser = Global.CurrentUser;
        LogBL logBL = new LogBL();

        public Edit_UC(string username, int ID)
        {
            InitializeComponent();
            userService = new UserServiceBL();
            this.username = username;
            this.ID = ID;
        }

        private void Edit_UC_Load(object sender, EventArgs e)
        {
            LoadUserProfile();
            int newRole = int.Parse(cmbUserRole.SelectedItem.ToString());

            UsersDTO userProfile = userService.GetUserProfile(username);

            // tài khoản đang hoạt động thì check
            if (userProfile.IsActive == 1)
                checkboxStt.Checked = true;
            else
                checkboxStt.Checked = false;
            // nếu là tài khoản admin đang đăng nhập bấm vào thì ko cho tắt HĐ
            if (Global.CurrentUser.ID == userProfile.ID)
            {
                checkboxStt.Enabled = false;
            }
            // ko cho hạ role
            if (Global.CurrentUser.userName == username)
            {
                cmbUserRole.Enabled = false;
            }

        }
        private void LoadUserProfile()
        {
            try
            {
                // Lấy thông tin người dùng từ UserService
                UsersDTO userProfile = userService.GetUserProfile(username);

                if (userProfile != null)
                {
                    // Gán thông tin vào các TextBox
                    txtUsername.Text = userProfile.userName;
                    txtName.Text = userProfile.name;
                    txtEmail.Text = userProfile.email;
                    txtOldPass.Text = userProfile.passWord;

                    // Gán giá trị cho ComboBox vai trò
                    cmbUserRole.SelectedItem = userProfile.roleID.HasValue ? userProfile.roleID.ToString() : null;
                }
                else
                {
                    MessageBox.Show("Không tìm thấy thông tin người dùng.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải thông tin người dùng: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private bool IsValidEmail(string email)
        {
            string pattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            return Regex.IsMatch(email, pattern);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                // Lấy thông tin từ các TextBox
                string name = txtName.Text.Trim();
                string email = txtEmail.Text.Trim();
                string oldPassword = txtOldPass.Text.Trim();
                string newPassword = txtNewPass.Text.Trim();
                int statusValue = checkboxStt.Checked ? 1 : 0;

                // Lấy vai trò từ ComboBox
                int newRole = int.Parse(cmbUserRole.SelectedItem.ToString());

                UsersDTO userProfile = userService.GetUserProfile(username); 

                bool hasChanges = txtName.Text != userProfile.name ||
                  txtEmail.Text != userProfile.email ||
                  checkboxStt.Checked != (userProfile.IsActive == 1) ||
                  cmbUserRole.SelectedItem.ToString() != userProfile.roleID.ToString() ||
                  (!string.IsNullOrEmpty(txtOldPass.Text) && !string.IsNullOrEmpty(txtNewPass.Text));

                if (!hasChanges)
                {
                    MessageBox.Show("Không có thay đổi nào được thực hiện.");
                    return;
                }

                if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(email))
                {
                    MessageBox.Show("Vui lòng điền đầy đủ thông tin.");
                    return;
                }

                // Kiểm tra email
                if (!IsValidEmail(email))
                {
                    MessageBox.Show("Email không đúng định dạng!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Gọi phương thức UpdateProfile
                bool success = userService.UpdateProfile(username, name, email, oldPassword, newPassword, newRole, statusValue);
                if (success)
                    // Nếu thành công thì ghi log currentUser.ID -> update 
                    logBL.LogUpdateUser(currentUser.ID, this.ID);

                if (success)
                {
                    MessageBox.Show("Cập nhật thông tin thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Cập nhật thông tin thất bại. Vui lòng kiểm tra lại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi cập nhật thông tin: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
