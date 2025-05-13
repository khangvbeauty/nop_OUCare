using BusinessLayer;
using DataLayer;
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
    public partial class UC_NV_ThemThuoc : UserControl
    {
        private LogBL logBL = new LogBL();
        public UC_NV_ThemThuoc()
        {
            InitializeComponent();
        }

        private void UC_NV_ThemThuoc_Load(object sender, EventArgs e)
        {
            using (var db = new OUCareDBContext())
            {
                var groups = db.MedicineGroups.ToList();
                cbNhomThuoc.DataSource = groups;
                cbNhomThuoc.DisplayMember = "groupName";
                cbNhomThuoc.ValueMember = "ID";
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                var dto = new MedicineDTO
                {
                    MedCode = txtMedCode.Text,
                    Name = txtMedName.Text,
                    Quantity = int.Parse(txtSL.Text),
                    ExpiryDate = dtpHSD.Value,
                    CreatedDate = dtpNgayNhap.Value,
                    PriceMua = double.Parse(txtGiaMua.Text),
                    PriceBan = double.Parse(txtGiaBan.Text),
                    GroupID = (int)cbNhomThuoc.SelectedValue
                };

                var bus = new MedicineBUS();
                bus.AddMedicine(Global.CurrentUser.ID,dto);
                MessageBox.Show("Thêm thuốc thành công!");

                ClearFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }
        private void ClearFields()
        {
            txtMedCode.Clear();
            txtMedName.Clear();
            txtSL.Clear();
            txtGiaMua.Clear();
            txtGiaBan.Clear();
            dtpHSD.Value = DateTime.Now;
            dtpNgayNhap.Value = DateTime.Now;
        }

        private void btnTroLai_Click(object sender, EventArgs e)
        {
                this.Parent.Controls.Remove(this);
        }
    }
}
