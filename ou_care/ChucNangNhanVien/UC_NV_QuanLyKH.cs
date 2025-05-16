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

namespace ou_care.ChucNangNhanVien
{
    public partial class UC_NV_QuanLyKH : UserControl
    {
        private CustomerBUS bus = new CustomerBUS();
        private LogBL logBL = new LogBL();

        public UC_NV_QuanLyKH()
        {
            InitializeComponent();
            LoadData();
        }
        private void LoadData()
        {
            dgvCustomer.DataSource = bus.LayDanhSach();
            dgvCustomer.Columns["ID"].Visible = false;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            string name = txtName.Text.Trim();
            string phone = txtPhone.Text.Trim();
            string email = txtEmail.Text.Trim();
            // Kiểm tra bỏ trống
            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(phone))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ tên và số điện thoại.", "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            CustomerDTO dto = new CustomerDTO
            {
                Name = name,
                Phone = phone,
                Email = email,
                CreatedDate = DateTime.Now
            };

            try
            {
                // Thêm khách hàng
                int id = bus.Them(dto);
                logBL.LogAddCustomer(Global.CurrentUser.ID, id);
                MessageBox.Show("Thêm khách hàng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Quay lại giao diện bán thuốc nếu có
                if (NhanVien.QuayLaiBanThuoc != null)
                {
                    NhanVien.QuayLaiBanThuoc.Invoke();
                    NhanVien.SdtTamThoi = null;
                    NhanVien.QuayLaiBanThuoc = null;
                }

                LoadData();
            }
            catch (Exception ex)
            {
                // Hiển thị thông báo lỗi nếu trùng số điện thoại
                MessageBox.Show("Không thể thêm khách hàng.\n" + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            if (int.TryParse(txtID.Text, out int id))
            {
                CustomerDTO dto = new CustomerDTO
                {
                    ID = id,
                    Name = txtName.Text.Trim(),
                    Phone = txtPhone.Text.Trim(),
                    Email = txtEmail.Text.Trim()
                };
                bus.CapNhat(dto);
                logBL.LogUpdateCustomer(Global.CurrentUser.ID, id);
                LoadData();
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (int.TryParse(txtID.Text, out int id))
            {
                bus.Xoa(id);
                LoadData();
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string keyword = txtSearch.Text.Trim();
            dgvCustomer.DataSource = bus.TimKiem(keyword);
        }

        private void btnTaiLai_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void dgvCustomer_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvCustomer.CurrentRow != null)
            {
                txtID.Text = dgvCustomer.CurrentRow.Cells["ID"].Value.ToString();
                txtName.Text = dgvCustomer.CurrentRow.Cells["Name"].Value.ToString();
                txtPhone.Text = dgvCustomer.CurrentRow.Cells["Phone"].Value.ToString();
                txtEmail.Text = dgvCustomer.CurrentRow.Cells["Email"].Value.ToString();

            }
        }

        private void UC_NV_QuanLyKH_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(NhanVien.SdtTamThoi))
            {
                txtPhone.Text = NhanVien.SdtTamThoi;
                txtName.Focus();
            }
        }
    }
}
