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
                    //txtUserRole.Text = userProfile.roleID.HasValue ? userProfile.roleID.ToString() : "N/A";

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

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                // Lấy thông tin từ các TextBox
                string name = txtName.Text.Trim();
                string email = txtEmail.Text.Trim();
                string oldPassword = txtOldPass.Text.Trim();
                string newPassword = txtNewPass.Text.Trim();

                // Lấy vai trò từ ComboBox
                int newRole = int.Parse(cmbUserRole.SelectedItem.ToString());

                // Gọi phương thức UpdateProfile
                bool success = userService.UpdateProfile(username, name, email, oldPassword, newPassword, newRole);
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
