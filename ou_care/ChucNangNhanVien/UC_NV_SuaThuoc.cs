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

namespace ou_care.ChucNangNhanVien
{
    public partial class UC_NV_SuaThuoc : UserControl
    {
        private MedicineBUS medicineBUS = new MedicineBUS();
        private LogBL logBL = new LogBL();
        public UC_NV_SuaThuoc()
        {
            InitializeComponent();
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(cbMaThuoc.Text))
            {
                MessageBox.Show("Vui lòng chọn mã thuốc.");
                return;
            }

            string maThuoc = cbMaThuoc.Text.Trim();


            using (var db = new OUCareDBContext())
            {
                var medicine = db.Medicines.FirstOrDefault(m => m.medCode == maThuoc);

                if (medicine != null)
                {
                    txtMedName.Text = medicine.name;
                    txtSLHienTai.Text = medicine.quantity.ToString();
                    dtpHSD.Value = medicine.expiryDate ?? DateTime.Now;
                    dtpNgayNhap.Value = medicine.createdDate ?? DateTime.Now;
                    txtGiaMua.Text = medicine.priceMua.ToString() ?? "0";
                    txtGiaBan.Text = medicine.priceBan.ToString() ?? "0";
                }
                else
                {
                    MessageBox.Show("Không tìm thấy thuốc!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(cbMaThuoc.Text))
            {
                MessageBox.Show("Vui lòng chọn mã thuốc.");
                return;
            }

            try
            {
                string maThuoc = cbMaThuoc.Text.Trim();


                using (var db = new OUCareDBContext())
                {
                    var medicine = db.Medicines.FirstOrDefault(m => m.medCode == maThuoc);

                    if (medicine != null)
                    {
                        int slHienTai = medicine.quantity ?? 0;
                        int slThem = int.Parse(txtSLThem.Text);
                        int slMoi = slHienTai + slThem;
                        medicine.medCode = cbMaThuoc.Text;
                        medicine.name = txtMedName.Text;
                        medicine.quantity = slMoi;
                        medicine.expiryDate = dtpHSD.Value;
                        medicine.createdDate = dtpNgayNhap.Value;
                        medicine.priceMua = double.TryParse(txtGiaMua.Text, out var giaMua) ? giaMua : 0;
                        medicine.priceBan = double.TryParse(txtGiaBan.Text, out var giaBan) ? giaBan : 0;

                        db.SaveChanges();
                        logBL.LogEditMedicine(Global.CurrentUser.ID, medicine.ID);
                        MessageBox.Show("Cập nhật thuốc thành công!");
                        ClearAll();
                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy thuốc cần cập nhật!");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            ClearAll();
        }
        private void ClearAll()
        {
            
            txtMedName.Clear();
            txtSLHienTai.Clear();
            txtSLThem.Text = "0";
            dtpHSD.Value = DateTime.Now;
            dtpNgayNhap.Value = DateTime.Now;
            txtGiaMua.Clear();
            txtGiaBan.Clear();
        }

        private void UC_NV_SuaThuoc_Load(object sender, EventArgs e)
        {
            var danhSachThuoc = medicineBUS.GetAllMedicines(); // Lấy tất cả thuốc
            cbMaThuoc.DataSource = danhSachThuoc;
            cbMaThuoc.DisplayMember = "MedCode"; // Hiển thị mã thuốc
            cbMaThuoc.ValueMember = "ID";        // Giá trị thực dùng để xử lý nếu cần
            cbMaThuoc.SelectedIndex = -1;        // Không chọn gì ban đầu
        }

        private void cbMaThuoc_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbMaThuoc.SelectedItem != null)
            {
                var medCode = cbMaThuoc.Text.Trim();
                var medicine = medicineBUS.GetAllMedicines()
                                          .FirstOrDefault(m => m.MedCode == medCode);
                if (medicine != null)
                {
                    txtMedName.Text = medicine.Name;
                    txtSLHienTai.Text = medicine.Quantity.ToString();
                    dtpHSD.Value = medicine.ExpiryDate ?? DateTime.Now;
                    dtpNgayNhap.Value = medicine.CreatedDate ?? DateTime.Now;
                    txtGiaMua.Text = medicine.PriceMua.ToString();
                    txtGiaBan.Text = medicine.PriceBan.ToString();
                }
            }
        }
    }
}
