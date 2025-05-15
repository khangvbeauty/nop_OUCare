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
    public partial class UC_NV_BanThuoc : UserControl
    {
        private MedicineBUS medicineBUS = new MedicineBUS();
        private BillBUS billBUS = new BillBUS();
        private BillDetailsBUS billDetailsBUS = new BillDetailsBUS();
        private List<CartItem> cart = new List<CartItem>();
        private double totalAmount = 0;
        private User currentUser;

        public UC_NV_BanThuoc()
        {
            InitializeComponent();
        }

        private void txtTimKiemThuoc_TextChanged(object sender, EventArgs e)
        {
            string searchText = txtTimKiemThuoc.Text;
            var medicines = medicineBUS.SearchMedicines(searchText);
            listBox1.Items.Clear();

            foreach (var medicine in medicines)
            {
                listBox1.Items.Add($"{medicine.ID} - {medicine.Name}");
            }
        }


        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            if (cart.Count == 0)
            {
                MessageBox.Show("Giỏ hàng đang trống.");
                return;
            }
            if (currentCustomer == null)
            {
                MessageBox.Show("Vui lòng kiểm tra và chọn khách hàng trước khi thanh toán.");
                return;
            }


            Bill bill = new Bill
            {
                cusID = currentCustomer.ID,
                //userID = currentUser.ID chưa có Login làm sẵn
                total = (decimal)totalAmount,
                billDate = DateTime.Now,
                qrLink = "link_qr_code"
            };

            int billId = billBUS.AddBill(bill);

            foreach (var item in cart)
            {
                BillDetail billDetail = new BillDetail
                {
                    billID = billId,
                    medID = item.Medicine.ID,
                    quantity = item.Quantity,
                    unitPrice = (decimal)item.Medicine.price.GetValueOrDefault(),
                    amount = (decimal)(item.Medicine.price.GetValueOrDefault() * item.Quantity)
                };

                billDetailsBUS.AddBillDetail(billDetail);

                // Trừ số lượng thuốc đã bán
                medicineBUS.ReduceQuantity(item.Medicine.ID, item.Quantity);
            }


            MessageBox.Show("Thanh toán thành công! Mã hóa đơn: " + billId);

            cart.Clear();
            totalAmount = 0;
            txtTong.Clear();
            textBox1.Clear();
        }

        private void btnThamVaoGioHang_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem != null && !string.IsNullOrWhiteSpace(txtSoLuong.Text))
            {
                int quantity;
                if (!int.TryParse(txtSoLuong.Text, out quantity))
                {
                    MessageBox.Show("Số lượng không hợp lệ.");
                    return;
                }

                string selected = listBox1.SelectedItem.ToString();
                int medicineId = int.Parse(selected.Split('-')[0].Trim());
                Medicine selectedMedicine = medicineBUS.GetMedicineById(medicineId);

                if (selectedMedicine != null && selectedMedicine.quantity >= quantity)
                {
                    // Thêm vào giỏ hàng
                    cart.Add(new CartItem
                    {
                        Medicine = selectedMedicine,
                        Quantity = quantity
                    });

                    double itemTotal = selectedMedicine.priceBan.GetValueOrDefault() * quantity;
                    totalAmount += itemTotal;
                    txtTong.Text = totalAmount.ToString("N0");

                    textBox1.AppendText($"{selectedMedicine.name} - SL: {quantity} - Thành tiền: {itemTotal:N0}\r\n");
                }
                else
                {
                    MessageBox.Show("Không đủ số lượng thuốc.");
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn thuốc và nhập số lượng.");
            }
        }

        private void txtTimKiemThuoc_Enter(object sender, EventArgs e)
        {
            if (txtTimKiemThuoc.Text == "Nhập tên thuốc...")
            {
                txtTimKiemThuoc.Text = "";
                txtTimKiemThuoc.ForeColor = Color.Black;
            }
        }

        private void txtTimKiemThuoc_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTimKiemThuoc.Text))
            {
                txtTimKiemThuoc.Text = "Nhập tên thuốc...";
                txtTimKiemThuoc.ForeColor = Color.Gray;
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem != null)
            {
                string selected = listBox1.SelectedItem.ToString();
                int medicineId = int.Parse(selected.Split('-')[0].Trim());
                Medicine medicine = medicineBUS.GetMedicineById(medicineId);

                if (medicine != null)
                {
                    txtMaThuoc.Text = medicine.ID.ToString();
                    txtTenThuoc.Text = medicine.name;
                    txtDonGia.Text = medicine.priceBan.GetValueOrDefault().ToString("N0");
                    // Gán hạn sử dụng
                    if (medicine.expiryDate.HasValue)
                        dtpHanSuDung.Value = medicine.expiryDate.Value;
                    else
                        dtpHanSuDung.Value = DateTime.Now; // hoặc để trống, tùy yêu cầu
                }
            }
        }
        private CustomerDTO currentCustomer;
        private CustomerBUS customerBUS = new CustomerBUS();
        private void btnKiemTraSDT_Click(object sender, EventArgs e)
        {
            string phone = txtSDT.Text.Trim();
            if (string.IsNullOrEmpty(phone))
            {
                MessageBox.Show("Vui lòng nhập số điện thoại.");
                return;
            }

            var customer = customerBUS.GetByPhone(phone);
            if (customer != null)
            {
                currentCustomer = customer;
                lblTenKH.Text = $"Khách: {customer.Name}";
            }
            else
            {
                DialogResult result = MessageBox.Show("Không tìm thấy khách hàng. Thêm mới?", "Thông báo", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    NhanVien.SdtTamThoi = phone;
                    NhanVien.QuayLaiBanThuoc = () => NhanVien.Instance.LoadUC(new UC_NV_BanThuoc()); // callback về lại bán thuốc
                    NhanVien.Instance.LoadUC(new UC_NV_QuanLyKH());
                }
            }
        }
        //Kiểm tra SĐT
        private void UC_NV_BanThuoc_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(NhanVien.SdtTamThoi))
            {
                txtSDT.Text = NhanVien.SdtTamThoi;
                btnKiemTraSDT.PerformClick(); // Tự động check lại
                NhanVien.SdtTamThoi = null; // Xóa để không bị lặp
            }
        }

        private void btnChatBot_Click(object sender, EventArgs e)
        {
            // Tạo form ChatBot
            ChatBotOUC.ChatBot chatForm = new ChatBotOUC.ChatBot();

            // Hiển thị form dưới dạng cửa sổ con
            chatForm.ShowDialog(); 
        }

    }
}
