using BusinessLayer;
using ou_care.ChucNangNhanVien;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ou_care
{
    public partial class NhanVien : Form
    {
        private UC_NV_TongQuan uC_NV_TongQuan;
        private UC_NV_ThemThuoc uC_NV_ThemThuoc;
        private UC_NV_XemThuoc uC_NV_XemThuoc;
        private UC_NV_SuaThuoc uC_NV_SuaThuoc;
        private UC_NV_BanThuoc uC_NV_BanThuoc;
        private UC_NV_KiemTraThuoc uC_NV_KiemTraThuoc;
        public static string SdtTamThoi = null; // dùng để truyền dữ liệu giữa các UserControl
        public static Action QuayLaiBanThuoc;  // callback để quay về lại bán thuốc
        public static NhanVien Instance;
        private LogBL logBL = new LogBL();

        public NhanVien()
        {
            InitializeComponent();
            Instance = this;

        }
        public void LoadUC(UserControl uc)
        {
            panelMain.Controls.Clear();
            uc.Dock = DockStyle.Fill;
            panelMain.Controls.Add(uc);
        }


        private void btnTongQuan_Click(object sender, EventArgs e)
        {
            LoadUC(new UC_NV_TongQuan());
        }

        private void btnThemThuoc_Click(object sender, EventArgs e)
        {
            LoadUC(new UC_NV_ThemThuoc());
        }

        private void btnKiemTra_Click(object sender, EventArgs e)
        {
            LoadUC(new UC_NV_KiemTraThuoc());

        }

        private void btnSuaThuoc_Click(object sender, EventArgs e)
        {
            LoadUC(new UC_NV_SuaThuoc());
        }

        private void btnBanThuoc_Click(object sender, EventArgs e)
        {
            LoadUC(new UC_NV_BanThuoc());
        }

        private void btnXemThuoc_Click(object sender, EventArgs e)
        {
            LoadUC(new UC_NV_XemThuoc());

        }

        private void btnDangXuat_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc muốn thoát chương trình?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                logBL.LogLogout(Global.CurrentUser.ID, Global.CurrentUser.ID);
                Global.Clear(); // Xóa thông tin người dùng
                Login lg = new Login();
                this.Hide();
                lg.Show();
            }
        }

        private void NhanVien_Load(object sender, EventArgs e)
        {
            btnTongQuan.PerformClick();

        }


        private void btnQuanLy_Click_1(object sender, EventArgs e)
        {
            LoadTabQuanLy();
        }
        private void LoadTabQuanLy()
        {
            tabQuanLy = new TabControl();
            tabKhachHang = new TabPage("Khách hàng");
            tabHoaDon = new TabPage("Hóa đơn");

            UC_NV_QuanLyKH ucKhach = new UC_NV_QuanLyKH();
            ucKhach.Dock = DockStyle.Fill;
            tabKhachHang.Controls.Add(ucKhach);

            UC_NV_QuanLyHoaDon ucHoaDon = new UC_NV_QuanLyHoaDon();
            ucHoaDon.Dock = DockStyle.Fill;
            tabHoaDon.Controls.Add(ucHoaDon);

            tabQuanLy.TabPages.Add(tabKhachHang);
            tabQuanLy.TabPages.Add(tabHoaDon);
            tabQuanLy.Dock = DockStyle.Fill;

            panelMain.Controls.Clear();
            panelMain.Controls.Add(tabQuanLy);
        }

    }
}
