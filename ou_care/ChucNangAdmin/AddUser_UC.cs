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

namespace ou_care.ChucNangAdmin
{
    public partial class AddUser_UC : UserControl
    {
        UserServiceBL userServiceBL;

        public AddUser_UC()
        {
            InitializeComponent();
            userServiceBL = new UserServiceBL();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            txtEmail.Text = "";
            txtName.Text = "";
            txtPassword.Text = "";
            txtUsername.Text = "";
        }

        private void AddUser_UC_Load(object sender, EventArgs e)
        {
            cbbUserRole.Items.Add(1);
            cbbUserRole.Items.Add(2);
        }

        private void btnSignUp_Click(object sender, EventArgs e)
        {
            if (Global.CurrentUser == null)
            {
                MessageBox.Show("Vui lòng đăng nhập lại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            int currentUserID = Global.CurrentUser.ID;
            // Chuẩn hóa dữ liệu lấy trên giao diện
            string username = txtUsername.Text.Trim();
            string name = txtName.Text.Trim();
            string email = txtEmail.Text.Trim();
            string password = txtPassword.Text.Trim();
            int userRole = Convert.ToInt32(cbbUserRole.SelectedItem);

            // Bắt buộc nhập đầy đủ thông tin
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(name) ||
                string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin.");
                return;
            }

            try
            {
                bool success = userServiceBL.AddUser(currentUserID, username, name, email, password, userRole);

                if (success)
                {
                    MessageBox.Show("Đăng ký thành công!");
                    btnReset_Click(null, null); // Reset form
                }
                else
                {
                    MessageBox.Show("Tên đăng nhập đã tồn tại.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thêm người dùng: " + ex.Message);
            }
        }
    }
}
