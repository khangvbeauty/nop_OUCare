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
            CustomerDTO dto = new CustomerDTO
            {
                Name = txtName.Text.Trim(),
                Phone = txtPhone.Text.Trim(),
                Email = txtEmail.Text.Trim(),
                CreatedDate = DateTime.Now
            };
            bus.Them(dto);
            MessageBox.Show("Thêm khách thành công");

            // nếu quay lại bán thuốc
            if (NhanVien.QuayLaiBanThuoc != null)
            {
                NhanVien.QuayLaiBanThuoc.Invoke();
                NhanVien.SdtTamThoi = null;
                NhanVien.QuayLaiBanThuoc = null;
            }
            LoadData();
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
            //txtID.Visible = false;
            if (!string.IsNullOrEmpty(NhanVien.SdtTamThoi))
            {
                txtPhone.Text = NhanVien.SdtTamThoi;
                txtName.Focus();
            }
        }
    }
}
