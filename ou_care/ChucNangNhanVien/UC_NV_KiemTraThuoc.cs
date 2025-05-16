using BusinessLayer;
using iTextSharp.text.pdf;
using iTextSharp.text;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ou_care.ChucNangNhanVien
{
    public partial class UC_NV_KiemTraThuoc : UserControl
    {
        private MedicineBUS medicineBUS = new MedicineBUS();

        public UC_NV_KiemTraThuoc()
        {
            InitializeComponent();
            StyleDataGridView();
        }

        private void UC_NV_KiemTraThuoc_Load(object sender, EventArgs e)
        {
            cbTrangThai.SelectedIndex = 2; // Mặc định hiển thị thuốc tất cả
            LoadData();
        }
        private void LoadData()
        {
            string selected = cbTrangThai.SelectedItem.ToString().Trim();

            string status = selected == "Tất cả thuốc" ? "All" :
                selected == "Thuốc hết hạn" ? "Expired" :
                "Valid";


            var medicines = medicineBUS.GetMedicinesByExpiryStatus(status);

            dgvThuoc.DataSource = medicines.Select(m => new
            {
                m.ID,
                m.medCode,
                m.name,
                m.quantity,
                price = m.priceBan ?? 0,
                m.expiryDate,
                m.createdDate
            }).ToList();

            lblTitle.Text = $"📌 {selected}";
            lblTitle.ForeColor = (selected == "Thuốc hết hạn") ? Color.Red : Color.DarkGreen;
        }

        private void btnReload_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btnExportExcel_Click(object sender, EventArgs e)
        {
            if (dgvThuoc.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu để xuất!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (SaveFileDialog sfd = new SaveFileDialog()
            {
                Filter = "PDF files (*.pdf)|*.pdf",
                FileName = "DanhSachThuoc_" + DateTime.Now.ToString("yyyyMMdd_HHmm") + ".pdf"
            })
            {
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        using (FileStream stream = new FileStream(sfd.FileName, FileMode.Create))
                        {
                            Document doc = new Document(PageSize.A4.Rotate(), 10f, 10f, 20f, 10f);
                            PdfWriter.GetInstance(doc, stream);
                            doc.Open();

                            //Chỉnh font
                            string fontPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Fonts), "arial.ttf");
                            BaseFont baseFont = BaseFont.CreateFont(fontPath, BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
                            iTextSharp.text.Font titleFont = new iTextSharp.text.Font(baseFont, 16, iTextSharp.text.Font.BOLD);
                            iTextSharp.text.Font normalFont = new iTextSharp.text.Font(baseFont, 12);
                            doc.Add(new Paragraph("DANH SÁCH THUỐC", titleFont));
                            doc.Add(new Paragraph("Ngày xuất: " + DateTime.Now.ToString("dd/MM/yyyy HH:mm"), normalFont));
                            doc.Add(new Paragraph(" ")); // dòng trống

                            // Tạo bảng PDF với số cột như DataGridView
                            PdfPTable table = new PdfPTable(dgvThuoc.Columns.Count);
                            table.WidthPercentage = 100;


                            // Header
                            foreach (DataGridViewColumn col in dgvThuoc.Columns)
                            {
                                PdfPCell headerCell = new PdfPCell(new Phrase(col.HeaderText))
                                {
                                    BackgroundColor = new BaseColor(230, 230, 230),
                                    HorizontalAlignment = Element.ALIGN_CENTER
                                };
                                table.AddCell(headerCell);
                            }

                            // Dữ liệu
                            foreach (DataGridViewRow row in dgvThuoc.Rows)
                            {
                                if (row.IsNewRow) continue;

                                bool isExpired = false;
                                DateTime expiry;

                                // Kiểm tra hết hạn (nếu có cột expiryDate)
                                if (row.Cells["expiryDate"]?.Value != null &&
                                    DateTime.TryParse(row.Cells["expiryDate"].Value.ToString(), out expiry))
                                {
                                    isExpired = expiry < DateTime.Now;
                                }

                                foreach (DataGridViewCell cell in row.Cells)
                                {
                                    var value = cell.Value?.ToString() ?? "";
                                    PdfPCell dataCell = new PdfPCell(new Phrase(value));

                                    if (isExpired)
                                        dataCell.BackgroundColor = new BaseColor(255, 192, 203); // hồng nhạt

                                    table.AddCell(dataCell);
                                }
                            }

                            doc.Add(table);
                            doc.Close();
                        }

                        MessageBox.Show("Xuất PDF thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Process.Start(new ProcessStartInfo(sfd.FileName) { UseShellExecute = true });
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi khi xuất PDF: " + ex.Message);
                    }
                }
            }
        }

        private void cbTrangThai_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadData();

        }
        private void StyleDataGridView()
        {
            dgvThuoc.EnableHeadersVisualStyles = false;
            dgvThuoc.ColumnHeadersDefaultCellStyle.BackColor = Color.MediumSlateBlue;
            dgvThuoc.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvThuoc.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 10, FontStyle.Bold);

            dgvThuoc.ColumnHeadersHeight = 30;
            dgvThuoc.DefaultCellStyle.SelectionBackColor = Color.LightSkyBlue;
            dgvThuoc.DefaultCellStyle.SelectionForeColor = Color.Black;

            dgvThuoc.RowsDefaultCellStyle.BackColor = Color.White;
            dgvThuoc.AlternatingRowsDefaultCellStyle.BackColor = Color.AliceBlue;

            dgvThuoc.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvThuoc.ReadOnly = true;
            dgvThuoc.AllowUserToAddRows = false;
            dgvThuoc.AllowUserToResizeRows = false;
            dgvThuoc.RowHeadersVisible = false;
        }
    }
}
