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
    public partial class Dashboard_UC : UserControl
    {
        DashboardBL bl = new DashboardBL();
        public Dashboard_UC()
        {
            InitializeComponent();
            dtpStartDate.Enabled = true;
            dtpEndDate.Enabled = true;
        }
        private void LoadData()
        {
            List<MedicineDTO> medicines = medicines = bl.SLThuocThap();
            // Tắt tự động tạo cột
            dgvThuocThap.AutoGenerateColumns = false;
            dgvThuocThap.Columns.Clear();

            // Thêm cột Name
            dgvThuocThap.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Tên thuốc",
                DataPropertyName = "name",
                Name = "name"
            });

            // Thêm cột Quantity
            dgvThuocThap.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Số lượng",
                DataPropertyName = "quantity",
                Name = "quantity"
            });

            // Gán datasource
            dgvThuocThap.DataSource = medicines;

            // Tổng user
            lbTongUser.Text = bl.CountUser().ToString();

            // Tổng doanh thu
            lbDoanhThu.Text = bl.GetTotalRevenue(dtpStartDate.Value, dtpEndDate.Value).ToString();

            // Tổng số thuốc
            lbTongThuoc.Text = bl.GetTotalMedicines().ToString();

            // Tổng giao dịch
            lbTongGiaoDich.Text = bl.TongGiaoDich().ToString();

            // 5 thuốc bán chạy
            LoadBestSellerChart();
        }
        // Thêm phương thức LoadBestSellerChart 
        private void LoadBestSellerChart()
        {
            // Lấy dữ liệu 5 thuốc bán chạy từ Business Layer
            List<MedicineDTO> topMedicines = bl.Lay5ThuocBanChay(dtpStartDate.Value, dtpEndDate.Value);

            // Xóa series hiện tại (nếu có)
            chartBestSeller.Series.Clear();

            // Tạo series mới cho biểu đồ
            var series = chartBestSeller.Series.Add("TopMedicines");
            series.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Doughnut;

            // Thêm dữ liệu vào series
            foreach (var med in topMedicines)
            {
                int pointIndex = series.Points.AddY(med.Quantity);
                series.Points[pointIndex].LegendText = med.Name;
                series.Points[pointIndex].Label = med.Quantity.ToString();
            }

            // Cấu hình thêm cho biểu đồ
            chartBestSeller.Titles.Clear();
            chartBestSeller.Titles.Add("5 Thuốc bán chạy");
            chartBestSeller.Legends[0].Enabled = true;
            chartBestSeller.Legends[0].Docking = System.Windows.Forms.DataVisualization.Charting.Docking.Bottom;
        }

        private void Dashboard_UC_Load(object sender, EventArgs e)
        {
            LoadData();

        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btnLast30Days_Click(object sender, EventArgs e)
        {
            dtpStartDate.Value = DateTime.Now.AddDays(-30);
            dtpEndDate.Value = DateTime.Now;
            LoadData();
        }

        private void btn7days_Click(object sender, EventArgs e)
        {
            dtpStartDate.Value = DateTime.Now.AddDays(-7);
            dtpEndDate.Value = DateTime.Now;
            LoadData();
        }
    }
}
