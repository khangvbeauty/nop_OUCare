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

namespace ou_care.ChucNangAdmin
{
    public partial class Revenue : UserControl
    {
        RevenueBL bl = new RevenueBL();
        public Revenue()
        {
            InitializeComponent();
        }
        private void LoadData()
        {
            DateTime from = dtpStartDate.Value.Date;
            DateTime to = dptEndDate.Value.Date;

            var report = bl.GetRevenueByDateRange(from, to);

            // Thêm cột STT bằng cách tạo DataTable
            DataTable dt = new DataTable();
            dt.Columns.Add("STT", typeof(int));
            dt.Columns.Add("Ngày", typeof(DateTime));
            dt.Columns.Add("Số lượt mua", typeof(int));
            dt.Columns.Add("Doanh thu", typeof(decimal));

            // Thêm dữ liệu vào DataTable với STT
            for (int i = 0; i < report.Count; i++)
            {
                dt.Rows.Add(i + 1, report[i].Date, report[i].PatientCount, report[i].TotalRevenue);
            }

            dgvDoanhThu.DataSource = dt;

            // Format grid
            dgvDoanhThu.Columns["STT"].Width = 50;
            dgvDoanhThu.Columns["Ngày"].Width = 100;
            dgvDoanhThu.Columns["Ngày"].DefaultCellStyle.Format = "dd/MM/yyyy";
            dgvDoanhThu.Columns["Số lượt mua"].Width = 100;
            dgvDoanhThu.Columns["Doanh thu"].Width = 150;
            dgvDoanhThu.Columns["Doanh thu"].DefaultCellStyle.Format = "N0";

            // Tổng doanh thu toàn bộ
            decimal tong = report.Sum(r => r.TotalRevenue);
            lbTongDoanhThu.Text = $"Tổng doanh thu: {tong:N0} VNĐ"; // N0 Số có dấu phân cách hàng nghìn
        }

        private void Revenue_Load(object sender, EventArgs e)
        {
            LoadData();
            // Giao diện đẹp hơn cho DataGridView
            dgvDoanhThu.BorderStyle = BorderStyle.None;
            dgvDoanhThu.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(240, 240, 240);
            dgvDoanhThu.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvDoanhThu.DefaultCellStyle.SelectionBackColor = Color.FromArgb(51, 153, 255);
            dgvDoanhThu.DefaultCellStyle.SelectionForeColor = Color.White;
            dgvDoanhThu.BackgroundColor = Color.White;
            dgvDoanhThu.EnableHeadersVisualStyles = false;
            dgvDoanhThu.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgvDoanhThu.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(0, 70, 160);
            dgvDoanhThu.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvDoanhThu.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 10, FontStyle.Bold);
            dgvDoanhThu.DefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 10);
            dgvDoanhThu.RowTemplate.Height = 30;
            dgvDoanhThu.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
            dgvDoanhThu.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvDoanhThu.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        private void btnLoc_Click(object sender, EventArgs e)
        {
            DateTime from = dtpStartDate.Value.Date;
            DateTime to = dptEndDate.Value.Date;
            LoadData();
        }

        private void btnExportPDF_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog sfd = new SaveFileDialog()
            {
                Filter = "PDF files (.pdf)|.pdf",
                Title = "Lưu báo cáo doanh thu",
                FileName = "BaoCaoDoanhThu.pdf"
            })
            {
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    ExportToPDF(sfd.FileName);
                }
            }
        }
        private void ExportToPDF(string outputPath)
        {
            try
            {
                if (dgvDoanhThu.Rows.Count == 0)
                {
                    MessageBox.Show("Không có dữ liệu để xuất!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                using (FileStream fs = new FileStream(outputPath, FileMode.Create)) // tạo mới file hoặc ghi đè nếu file đã tồn tại
                {
                    Document document = new Document(PageSize.A4, 25, 25, 30, 30); // trái phải trên dưới
                    PdfWriter.GetInstance(document, fs); // Liên kết tài liệu với luồng file để ghi nội dung PDF
                    document.Open();

                    // Font tiếng Việt (Arial)
                    string fontPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Fonts), "arial.ttf"); // Lấy đường dẫn đến file font Arial
                    BaseFont baseFont = BaseFont.CreateFont(fontPath, BaseFont.IDENTITY_H, BaseFont.EMBEDDED); // tạo font cơ sở: mã hóa unicode BaseFont.IDENTITY_H
                    var titleFont = new iTextSharp.text.Font(baseFont, 16, iTextSharp.text.Font.BOLD); 
                    var headerFont = new iTextSharp.text.Font(baseFont, 12, iTextSharp.text.Font.BOLD);
                    var bodyFont = new iTextSharp.text.Font(baseFont, 10, iTextSharp.text.Font.NORMAL);

                    // Tiêu đề
                    Paragraph title = new Paragraph("BÁO CÁO DOANH THU", titleFont)
                    {
                        Alignment = Element.ALIGN_CENTER,
                        SpacingAfter = 10f // Thêm Khoảng cách 10 point dưới tiêu đề
                    };
                    document.Add(title);

                    Paragraph dateRange = new Paragraph($"Từ ngày: {dtpStartDate.Value:dd/MM/yyyy}   Đến ngày: {dptEndDate.Value:dd/MM/yyyy}", headerFont)
                    {
                        Alignment = Element.ALIGN_CENTER,
                        SpacingAfter = 20f // Khoảng cách 20 point dưới dòng này.
                    };
                    document.Add(dateRange);

                    // Bảng
                    PdfPTable table = new PdfPTable(4)
                    {
                        WidthPercentage = 100 // Bảng chiếm 100% chiều rộng trang
                    };
                    float[] widths = new float[] { 10f, 25f, 30f, 35f }; // Đặt chiều rộng tương đối cho các cột
                    table.SetWidths(widths); // Áp dụng chiều rộng cho bảng.

                    string[] headers = { "STT", "Ngày", "Số lượt mua", "Doanh thu (VNĐ)" };
                    foreach (var header in headers)
                    {
                        PdfPCell cell = new PdfPCell(new Phrase(header, headerFont))  // Tạo ô (cell) với nội dung là tiêu đề
                        {
                            BackgroundColor = BaseColor.LIGHT_GRAY, // Đặt nền xám nhạt cho ô tiêu đề.
                            HorizontalAlignment = Element.ALIGN_CENTER // Căn giữa nội dung ô
                        };
                        table.AddCell(cell);
                    }

                    // Thêm dữ liệu từ DataGridView
                    foreach (DataGridViewRow row in dgvDoanhThu.Rows)
                    {
                        if (!row.IsNewRow) // bỏ qua dòng mới (dòng trống cuối dgv nếu có)
                        {
                            table.AddCell(new PdfPCell(new Phrase(row.Cells["STT"].Value?.ToString() ?? "", bodyFont)) { HorizontalAlignment = Element.ALIGN_CENTER });
                            table.AddCell(new PdfPCell(new Phrase(Convert.ToDateTime(row.Cells["Ngày"].Value).ToString("dd/MM/yyyy"), bodyFont)) { HorizontalAlignment = Element.ALIGN_CENTER });
                            table.AddCell(new PdfPCell(new Phrase(row.Cells["Số lượt mua"].Value?.ToString() ?? "", bodyFont)) { HorizontalAlignment = Element.ALIGN_CENTER });
                            table.AddCell(new PdfPCell(new Phrase(string.Format("{0:N0}", row.Cells["Doanh thu"].Value), bodyFont)) { HorizontalAlignment = Element.ALIGN_RIGHT });
                        }
                    }

                    document.Add(table);

                    // Tổng doanh thu
                    Paragraph totalRevenue = new Paragraph(lbTongDoanhThu.Text, headerFont)
                    {
                        Alignment = Element.ALIGN_RIGHT,
                        SpacingBefore = 15f // Khoảng cách 15 point trên dòng này
                    };
                    document.Add(totalRevenue);

                    document.Close();
                }

                MessageBox.Show("Xuất PDF thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xuất PDF: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
    }
}
