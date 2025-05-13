namespace ou_care
{
    partial class NhanVien
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NhanVien));
            this.panelMain = new System.Windows.Forms.Panel();
            this.tabQuanLy = new System.Windows.Forms.TabControl();
            this.tabKhachHang = new System.Windows.Forms.TabPage();
            this.tabHoaDon = new System.Windows.Forms.TabPage();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnQuanLy = new System.Windows.Forms.Button();
            this.btnDangXuat = new System.Windows.Forms.Button();
            this.btnXemThuoc = new System.Windows.Forms.Button();
            this.btnBanThuoc = new System.Windows.Forms.Button();
            this.btnSuaThuoc = new System.Windows.Forms.Button();
            this.btnKiemTra = new System.Windows.Forms.Button();
            this.btnThemThuoc = new System.Windows.Forms.Button();
            this.btnTongQuan = new System.Windows.Forms.Button();
            this.panelMain.SuspendLayout();
            this.tabQuanLy.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelMain
            // 
            this.panelMain.Controls.Add(this.tabQuanLy);
            this.panelMain.Location = new System.Drawing.Point(342, 0);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new System.Drawing.Size(911, 705);
            this.panelMain.TabIndex = 3;
            // 
            // tabQuanLy
            // 
            this.tabQuanLy.Controls.Add(this.tabKhachHang);
            this.tabQuanLy.Controls.Add(this.tabHoaDon);
            this.tabQuanLy.Location = new System.Drawing.Point(0, 0);
            this.tabQuanLy.Name = "tabQuanLy";
            this.tabQuanLy.SelectedIndex = 0;
            this.tabQuanLy.Size = new System.Drawing.Size(898, 705);
            this.tabQuanLy.TabIndex = 0;
            this.tabQuanLy.Visible = false;
            // 
            // tabKhachHang
            // 
            this.tabKhachHang.BackColor = System.Drawing.Color.Transparent;
            this.tabKhachHang.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabKhachHang.Location = new System.Drawing.Point(4, 25);
            this.tabKhachHang.Name = "tabKhachHang";
            this.tabKhachHang.Padding = new System.Windows.Forms.Padding(3);
            this.tabKhachHang.Size = new System.Drawing.Size(890, 676);
            this.tabKhachHang.TabIndex = 0;
            this.tabKhachHang.Text = "Khách Hàng";
            // 
            // tabHoaDon
            // 
            this.tabHoaDon.Location = new System.Drawing.Point(4, 25);
            this.tabHoaDon.Name = "tabHoaDon";
            this.tabHoaDon.Padding = new System.Windows.Forms.Padding(3);
            this.tabHoaDon.Size = new System.Drawing.Size(890, 676);
            this.tabHoaDon.TabIndex = 1;
            this.tabHoaDon.Text = "Hóa Đơn";
            this.tabHoaDon.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Impact", 28.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(56, 199);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(233, 59);
            this.label1.TabIndex = 5;
            this.label1.Text = "NHÂN VIÊN ";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(66, 46);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(212, 150);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Navy;
            this.panel1.Controls.Add(this.btnQuanLy);
            this.panel1.Controls.Add(this.btnDangXuat);
            this.panel1.Controls.Add(this.btnXemThuoc);
            this.panel1.Controls.Add(this.btnBanThuoc);
            this.panel1.Controls.Add(this.btnSuaThuoc);
            this.panel1.Controls.Add(this.btnKiemTra);
            this.panel1.Controls.Add(this.btnThemThuoc);
            this.panel1.Controls.Add(this.btnTongQuan);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(342, 705);
            this.panel1.TabIndex = 2;
            // 
            // btnQuanLy
            // 
            this.btnQuanLy.BackColor = System.Drawing.Color.AliceBlue;
            this.btnQuanLy.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnQuanLy.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.btnQuanLy.Location = new System.Drawing.Point(66, 599);
            this.btnQuanLy.Name = "btnQuanLy";
            this.btnQuanLy.Size = new System.Drawing.Size(212, 39);
            this.btnQuanLy.TabIndex = 69;
            this.btnQuanLy.Text = "Quản lý ";
            this.btnQuanLy.UseVisualStyleBackColor = false;
            this.btnQuanLy.Click += new System.EventHandler(this.btnQuanLy_Click_1);
            // 
            // btnDangXuat
            // 
            this.btnDangXuat.BackColor = System.Drawing.Color.AliceBlue;
            this.btnDangXuat.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDangXuat.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.btnDangXuat.Location = new System.Drawing.Point(66, 651);
            this.btnDangXuat.Name = "btnDangXuat";
            this.btnDangXuat.Size = new System.Drawing.Size(212, 39);
            this.btnDangXuat.TabIndex = 68;
            this.btnDangXuat.Text = "Đăng xuất";
            this.btnDangXuat.UseVisualStyleBackColor = false;
            this.btnDangXuat.Click += new System.EventHandler(this.btnDangXuat_Click);
            // 
            // btnXemThuoc
            // 
            this.btnXemThuoc.BackColor = System.Drawing.Color.AliceBlue;
            this.btnXemThuoc.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXemThuoc.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.btnXemThuoc.Location = new System.Drawing.Point(66, 547);
            this.btnXemThuoc.Name = "btnXemThuoc";
            this.btnXemThuoc.Size = new System.Drawing.Size(212, 39);
            this.btnXemThuoc.TabIndex = 68;
            this.btnXemThuoc.Text = "Xem thuốc";
            this.btnXemThuoc.UseVisualStyleBackColor = false;
            this.btnXemThuoc.Click += new System.EventHandler(this.btnXemThuoc_Click);
            // 
            // btnBanThuoc
            // 
            this.btnBanThuoc.BackColor = System.Drawing.Color.AliceBlue;
            this.btnBanThuoc.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBanThuoc.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.btnBanThuoc.Location = new System.Drawing.Point(66, 495);
            this.btnBanThuoc.Name = "btnBanThuoc";
            this.btnBanThuoc.Size = new System.Drawing.Size(212, 39);
            this.btnBanThuoc.TabIndex = 68;
            this.btnBanThuoc.Text = "Bán thuốc";
            this.btnBanThuoc.UseVisualStyleBackColor = false;
            this.btnBanThuoc.Click += new System.EventHandler(this.btnBanThuoc_Click);
            // 
            // btnSuaThuoc
            // 
            this.btnSuaThuoc.BackColor = System.Drawing.Color.AliceBlue;
            this.btnSuaThuoc.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSuaThuoc.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.btnSuaThuoc.Location = new System.Drawing.Point(66, 443);
            this.btnSuaThuoc.Name = "btnSuaThuoc";
            this.btnSuaThuoc.Size = new System.Drawing.Size(212, 39);
            this.btnSuaThuoc.TabIndex = 68;
            this.btnSuaThuoc.Text = "Sửa thuốc";
            this.btnSuaThuoc.UseVisualStyleBackColor = false;
            this.btnSuaThuoc.Click += new System.EventHandler(this.btnSuaThuoc_Click);
            // 
            // btnKiemTra
            // 
            this.btnKiemTra.BackColor = System.Drawing.Color.AliceBlue;
            this.btnKiemTra.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnKiemTra.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.btnKiemTra.Location = new System.Drawing.Point(66, 391);
            this.btnKiemTra.Name = "btnKiemTra";
            this.btnKiemTra.Size = new System.Drawing.Size(212, 39);
            this.btnKiemTra.TabIndex = 68;
            this.btnKiemTra.Text = "Kiểm tra thuốc";
            this.btnKiemTra.UseVisualStyleBackColor = false;
            this.btnKiemTra.Click += new System.EventHandler(this.btnKiemTra_Click);
            // 
            // btnThemThuoc
            // 
            this.btnThemThuoc.BackColor = System.Drawing.Color.AliceBlue;
            this.btnThemThuoc.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThemThuoc.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.btnThemThuoc.Location = new System.Drawing.Point(66, 339);
            this.btnThemThuoc.Name = "btnThemThuoc";
            this.btnThemThuoc.Size = new System.Drawing.Size(212, 39);
            this.btnThemThuoc.TabIndex = 68;
            this.btnThemThuoc.Text = "Thêm thuốc";
            this.btnThemThuoc.UseVisualStyleBackColor = false;
            this.btnThemThuoc.Click += new System.EventHandler(this.btnThemThuoc_Click);
            // 
            // btnTongQuan
            // 
            this.btnTongQuan.BackColor = System.Drawing.Color.AliceBlue;
            this.btnTongQuan.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTongQuan.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.btnTongQuan.Location = new System.Drawing.Point(66, 287);
            this.btnTongQuan.Name = "btnTongQuan";
            this.btnTongQuan.Size = new System.Drawing.Size(212, 39);
            this.btnTongQuan.TabIndex = 68;
            this.btnTongQuan.Text = "Tổng quan";
            this.btnTongQuan.UseVisualStyleBackColor = false;
            this.btnTongQuan.Click += new System.EventHandler(this.btnTongQuan_Click);
            // 
            // NhanVien
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1252, 705);
            this.Controls.Add(this.panelMain);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "NhanVien";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "NhanVien";
            this.Load += new System.EventHandler(this.NhanVien_Load);
            this.panelMain.ResumeLayout(false);
            this.tabQuanLy.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelMain;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnTongQuan;
        private System.Windows.Forms.Button btnDangXuat;
        private System.Windows.Forms.Button btnXemThuoc;
        private System.Windows.Forms.Button btnBanThuoc;
        private System.Windows.Forms.Button btnSuaThuoc;
        private System.Windows.Forms.Button btnKiemTra;
        private System.Windows.Forms.Button btnThemThuoc;
        private System.Windows.Forms.Button btnQuanLy;
        private System.Windows.Forms.TabControl tabQuanLy;
        private System.Windows.Forms.TabPage tabKhachHang;
        private System.Windows.Forms.TabPage tabHoaDon;
    }
}