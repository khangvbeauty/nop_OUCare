using BusinessLayer;
using iTextSharp.text.pdf;
using iTextSharp.text;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QRCoder;
using System.Net.Mail;
using System.Net;
using TransferObject;

namespace ou_care.ChucNangNhanVien
{
    public partial class UC_NV_QuanLyHoaDon : UserControl
    {
        private BillBUS billBUS = new BillBUS();
        private MedicineBUS medicineBUS = new MedicineBUS();
        private CustomerBUS customerBUS = new CustomerBUS();
        private LogBL logBL = new LogBL();


        public UC_NV_QuanLyHoaDon()
        {
            InitializeComponent();
            LoadBills();
        }
        private void LoadBills()
        {
            dgvHoaDon.DataSource = billBUS.GetAllBills();
            dgvChiTiet.DataSource = null;
        }

        private void dgvHoaDon_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                int billID = Convert.ToInt32(dgvHoaDon.Rows[e.RowIndex].Cells["ID"].Value);
                dgvChiTiet.DataSource = billBUS.GetBillDetails(billID);
            }
        }

        private void btnReload_Click(object sender, EventArgs e)
        {
            LoadBills() ;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string keyword = txtSearch.Text.Trim().ToLower();
            var bills = billBUS.GetAllBills();
            var filtered = bills.Where(b => b.ID.ToString().Contains(keyword) ||
                                            (b.CustomerName != null && b.CustomerName.ToLower().Contains(keyword)))
                                .ToList();
            dgvHoaDon.DataSource = filtered;
            dgvChiTiet.DataSource = null;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dgvHoaDon.SelectedRows.Count > 0)
            {
                int billID = Convert.ToInt32(dgvHoaDon.SelectedRows[0].Cells["ID"].Value);

                var result = MessageBox.Show("Bạn có chắc chắn muốn xóa hóa đơn này không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    billBUS.DeleteBill(billID);
                    LoadBills();
                }
            }
        }

        public System.Drawing.Image GenerateQrCode(string qrText) //Hàm dùng tạo qr
        {
            QRCodeGenerator qrGenerator = new QRCodeGenerator();
            QRCodeData qrCodeData = qrGenerator.CreateQrCode(qrText, QRCodeGenerator.ECCLevel.Q);
            QRCode qrCode = new QRCode(qrCodeData);
            return qrCode.GetGraphic(20); // Đây là System.Drawing.Image (Bitmap)
        }
        
        //Thiết lập Mail
        private void SendEmailToCustomer(string pdfPath, BillDTO bill, CustomerDTO customer, List<BillDetailDTO> details)
        {
            try
            {
                // Gửi từ đâu (cấu hình)
                string fromEmail = "nguyenkhangtisungsg@gmail.com";
                string fromPassword = "phqt vful qezw fshj"; // Mật khẩu ứng dụng 

                // Gửi đến đâu
                string toEmail = customer.Email;

                // Tạo nội dung email
                var sb = new StringBuilder();
                sb.AppendLine($"Xin chào {customer.Name},");
                sb.AppendLine();
                sb.AppendLine($"Cảm ơn bạn đã mua thuốc tại hệ thống OUCare.");
                sb.AppendLine("Thông tin đơn thuốc của bạn như sau:");
                sb.AppendLine();

                foreach (var item in details)
                {
                    sb.AppendLine($"- {item.MedName}: SL {item.Quantity} x {item.UnitPrice:N0} = {item.Amount:N0} VND");
                }

                sb.AppendLine();
                sb.AppendLine($"🧾 Tổng tiền: {bill.Total:N0} VND");
                sb.AppendLine();
                sb.AppendLine("📌 File PDF đính kèm chứa mã QR với hướng dẫn sử dụng thuốc, ngày tái khám và các ghi chú của bác sĩ.");
                sb.AppendLine();
                sb.AppendLine("Trân trọng,\nOUCare Pharmacy");

                // Tạo mail
                MailMessage mail = new MailMessage();
                mail.From = new MailAddress(fromEmail, "OUCare Pharmacy");
                mail.To.Add(toEmail);
                mail.Subject = $"Hóa đơn thuốc #{bill.ID} từ OUCare";
                mail.Body = sb.ToString();

                // Đính kèm file PDF
                mail.Attachments.Add(new Attachment(pdfPath));

                // SMTP client
                SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
                smtp.Credentials = new NetworkCredential(fromEmail, fromPassword);
                smtp.EnableSsl = true;

                smtp.Send(mail);

                MessageBox.Show("Email đã được gửi thành công cho khách hàng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi gửi email: " + ex.Message);
            }
        }

        private void btnXuatPDF_Click(object sender, EventArgs e)
        {
            if (dgvHoaDon.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn hóa đơn để xuất PDF.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            int billID = Convert.ToInt32(dgvHoaDon.SelectedRows[0].Cells["ID"].Value);
            var details = billBUS.GetBillDetails(billID);

            using (SaveFileDialog sfd = new SaveFileDialog()
            {
                Filter = "PDF files (*.pdf)|*.pdf",
                FileName = $"HoaDon_{billID}_{DateTime.Now:yyyyMMdd_HHmm}.pdf"
            })
            {
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    using (FileStream stream = new FileStream(sfd.FileName, FileMode.Create))
                    {
                        Document doc = new Document(PageSize.A4);
                        PdfWriter.GetInstance(doc, stream);
                        doc.Open();
                        string fontPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Fonts), "arial.ttf");
                        BaseFont baseFont = BaseFont.CreateFont(fontPath, BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
                        iTextSharp.text.Font titleFont = new iTextSharp.text.Font(baseFont, 16, iTextSharp.text.Font.BOLD);
                        iTextSharp.text.Font normalFont = new iTextSharp.text.Font(baseFont, 12);
                        doc.Add(new Paragraph($"HÓA ĐƠN #{billID}", titleFont));
                        doc.Add(new Paragraph("Ngày xuất: " + DateTime.Now.ToString("dd/MM/yyyy HH:mm"), normalFont));
                        doc.Add(new Paragraph(" "));
                        var bill = billBUS.GetBillByID(billID);
                        var customer = customerBUS.GetByID(bill.CusID);


                        doc.Add(new Paragraph($"Khách hàng: {customer.Name}", normalFont));
                        doc.Add(new Paragraph($"SĐT: {customer.Phone}", normalFont));
                        doc.Add(new Paragraph(" "));

                        PdfPCell Cell(string text) => new PdfPCell(new Phrase(text, normalFont)); //Chỉnh font
                        PdfPTable table = new PdfPTable(4) { WidthPercentage = 100 };
                        table.AddCell(Cell("Tên thuốc"));
                        table.AddCell(Cell("Số lượng"));
                        table.AddCell(Cell("Đơn giá"));
                        table.AddCell(Cell("Thành tiền"));

                        foreach (var d in details)
                        {
                            table.AddCell(Cell(d.MedName));
                            table.AddCell(Cell(d.Quantity.ToString()));
                            table.AddCell(Cell(d.UnitPrice.ToString("N0")));
                            table.AddCell(Cell(d.Amount.ToString("N0")));
                        }

                        doc.Add(table);
                        // Tổng tiền cuối bảng
                        doc.Add(new Paragraph($"Tổng tiền: {(bill.Total.HasValue ? bill.Total.Value.ToString("N0") : "0")} VND", normalFont));



                        // Lấy danh sách chi tiết thuốc
                        var qrContent = new StringBuilder();
                        foreach (var item in details)
                        {
                            var med = medicineBUS.GetMedicineById(item.MedID ?? 0);
                            qrContent.AppendLine($"Thuốc: {med.name}");
                            qrContent.AppendLine($"- HDSD: {med.instruction}");
                            qrContent.AppendLine($"- Bảo quản: {med.preserveInfo}");
                            if (!string.IsNullOrEmpty(med.note))
                                qrContent.AppendLine($"- Ghi chú: {med.note}");
                            if (med.nextCheckupDate.HasValue)
                                qrContent.AppendLine($"- Tái khám: {med.nextCheckupDate.Value:dd/MM/yyyy}");
                            qrContent.AppendLine();
                        }

                        // Sinh mã QR
                        System.Drawing.Image qrImage = GenerateQrCode(qrContent.ToString());

                        // Chuyển sang iTextSharp image
                        var ms = new MemoryStream();
                        qrImage.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                        iTextSharp.text.Image qr = iTextSharp.text.Image.GetInstance(ms.ToArray());
                        qr.ScaleToFit(120f, 120f);
                        qr.Alignment = Element.ALIGN_RIGHT;

                        // Thêm vào cuối file
                        doc.Add(new Paragraph(" "));
                        doc.Add(new Paragraph("📌 Mã QR hướng dẫn sử dụng:", normalFont));
                        doc.Add(qr);
                        doc.Close();
                        SendEmailToCustomer(sfd.FileName, bill, customer, details);


                    }
                    logBL.LogCreateBill(Global.CurrentUser.ID, billID);
                    MessageBox.Show("Xuất PDF thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            
        }
    }
}

