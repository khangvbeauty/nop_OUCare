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
using System.Windows.Forms.DataVisualization.Charting;

namespace ou_care.ChucNangNhanVien
{
    public partial class UC_NV_TongQuan : UserControl
    {
        private MedicineBUS medicineBUS = new MedicineBUS();

        public UC_NV_TongQuan()
        {
            InitializeComponent();
        }

        private void UC_NV_TongQuan_Load(object sender, EventArgs e)
        {
            LoadChart();
        }
        private void LoadChart()
        {
            var stats = medicineBUS.GetMedicineExpiryStats();

            Series series = new Series();
            series.ChartType = SeriesChartType.Column;
            series.Points.AddXY("Còn hạn", stats.conHan);
            series.Points[0].Color = Color.DeepSkyBlue;

            series.Points.AddXY("Hết hạn", stats.hetHan);
            series.Points[1].Color = Color.Yellow;

            chartThuoc.Series.Add(series);
        }

        private void btnReload_Click(object sender, EventArgs e)
        {
            LoadChart();
        }
    }
}
