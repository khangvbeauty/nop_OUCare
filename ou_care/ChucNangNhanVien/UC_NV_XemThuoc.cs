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
using AForge.Video;
using AForge.Video.DirectShow;
using ZXing;
using System.Windows.Media.Media3D;


namespace ou_care.ChucNangNhanVien
{

    public partial class UC_NV_XemThuoc : UserControl
    {
        private MedicineBUS medicineBUS = new MedicineBUS();
        private LogBL logBL = new LogBL();
        private int selectedMedicineId = 0;
        FilterInfoCollection filterInfoCollection;
        VideoCaptureDevice videoCaptureDevice;

        public UC_NV_XemThuoc()
        {
            InitializeComponent();
        }

        private void UC_NV_XemThuoc_Load(object sender, EventArgs e)
        {
            LoadMedicines();
            StyleDataGridView();

            filterInfoCollection = new FilterInfoCollection(FilterCategory.VideoInputDevice); //tải danh sách webcam
            foreach (FilterInfo device in filterInfoCollection)
                cbCamera.Items.Add(device.Name);

            if (cbCamera.Items.Count > 0)
                cbCamera.SelectedIndex = 0;

            // Load sẵn danh sách thuốc
            dgvMedicines.DataSource = medicineBUS.GetAllMedicines();

        }
        private void LoadMedicines()
        {
            var medicines = medicineBUS.GetAllMedicines();
            dgvMedicines.DataSource = medicines;
            lblCount.Text = $"Tổng số thuốc: {medicines.Count}";
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string keyword = txtSearch.Text.Trim().ToLower();

            var medicines = medicineBUS.GetAllMedicines()
                .Where(m =>
                    (!string.IsNullOrEmpty(m.Name) && m.Name.ToLower().Contains(keyword)) || //Check chuỗi không phân biết chữ hoa thường
                    (!string.IsNullOrEmpty(m.MedCode) && m.MedCode.ToLower().Contains(keyword)))
                .ToList();

            dgvMedicines.DataSource = medicines;
            lblCount.Text = $"Kết quả: {medicines.Count}";
        }

        private void dgvMedicines_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dgvMedicines.Rows[e.RowIndex].Cells["ID"].Value != null)
            {
                selectedMedicineId = Convert.ToInt32(dgvMedicines.Rows[e.RowIndex].Cells["ID"].Value);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (selectedMedicineId != 0)
            {
                var result = MessageBox.Show("Bạn chắc chắn muốn xóa thuốc này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    medicineBUS.DeleteMedicine(selectedMedicineId);
                    logBL.LogDeleteditMedicine(Global.CurrentUser.ID, selectedMedicineId);
                    MessageBox.Show("Xóa thành công!");

                    selectedMedicineId = 0;
                    LoadMedicines();
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn thuốc để xóa!");
            }
        }

        private void btnReload_Click(object sender, EventArgs e)
        {
            txtSearch.Clear();
            LoadMedicines();
        }
        private void StyleDataGridView()
        {
            dgvMedicines.EnableHeadersVisualStyles = false;
            dgvMedicines.ColumnHeadersDefaultCellStyle.BackColor = Color.MediumSlateBlue;
            dgvMedicines.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvMedicines.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);

            dgvMedicines.ColumnHeadersHeight = 30;
            dgvMedicines.DefaultCellStyle.SelectionBackColor = Color.LightSkyBlue;
            dgvMedicines.DefaultCellStyle.SelectionForeColor = Color.Black;

            dgvMedicines.RowsDefaultCellStyle.BackColor = Color.White;
            dgvMedicines.AlternatingRowsDefaultCellStyle.BackColor = Color.AliceBlue;
                
            dgvMedicines. AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvMedicines.ReadOnly = true;
            dgvMedicines.AllowUserToAddRows = false;
            dgvMedicines.AllowUserToResizeRows = false;
            dgvMedicines.RowHeadersVisible = false;
        }

        private void btnStartQR_Click(object sender, EventArgs e)
        {
            videoCaptureDevice = new VideoCaptureDevice(filterInfoCollection[cbCamera.SelectedIndex].MonikerString); //chọn webcam từ cbox
            videoCaptureDevice.NewFrame += VideoCaptureDevice_NewFrame; //gán sự kiện newframe
            videoCaptureDevice.Start();
        }
        private void VideoCaptureDevice_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            Bitmap originalBitmap = (Bitmap)eventArgs.Frame.Clone(); //lấy frame từ webcam

            // hiển thị ra picturebox (dùng một bản clone)
            picWebcam.Image = (Bitmap)originalBitmap.Clone();

            // tạo bản bitmap riêng biệt chỉ để decode từ thư viện Zxing
            using (Bitmap qrBitmap = new Bitmap(originalBitmap))
            {
                BarcodeReader reader = new BarcodeReader
                {
                    AutoRotate = true,
                    TryInverted = true //thử nền trắng chữ đen
                };

                var result = reader.Decode(qrBitmap);

                if (result != null)
                {
                    txtSearch.Invoke(new MethodInvoker(delegate () //Webcam dùng trên thread khác cần chuyển về thread giao diện tránh lỗi, MI là delegate không tham số trả void
                    {
                        txtSearch.Text = result.ToString();
                    }));
                    string code = result.Text.Trim();

                    var list = medicineBUS.GetAllMedicines()
                                          .Where(m => m.MedCode == code) //lọc theo code
                                          .ToList();

                    if (list.Count > 0)
                    {
                        dgvMedicines.Invoke(new MethodInvoker(() =>
                        {
                            dgvMedicines.DataSource = list;
                        })); //hiện thị kết quả tìm kiếm lên dgv

                        videoCaptureDevice.SignalToStop(); //tự động dừng webcam khi thấy mã
                    }
                }
            }

        }

        private void btnStopQR_Click(object sender, EventArgs e)
        {
            if (videoCaptureDevice != null && videoCaptureDevice.IsRunning)
            {
                videoCaptureDevice.SignalToStop();
            }
        }

        private void dgvMedicines_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvMedicines.SelectedRows.Count > 0)
            {
                var selectedRow = dgvMedicines.SelectedRows[0];
                if (selectedRow.Cells["ID"].Value != null)
                {
                    selectedMedicineId = Convert.ToInt32(selectedRow.Cells["ID"].Value);
                }
            }
        }
    }
}
