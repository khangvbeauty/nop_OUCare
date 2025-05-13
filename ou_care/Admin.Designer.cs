namespace ou_care
{
    partial class Admin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Admin));
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnRevenue = new System.Windows.Forms.Button();
            this.btnTheoDoiLog = new System.Windows.Forms.Button();
            this.lb2 = new System.Windows.Forms.Label();
            this.btnLogout = new System.Windows.Forms.Button();
            this.btnProfile = new System.Windows.Forms.Button();
            this.btnViewUser = new System.Windows.Forms.Button();
            this.btnAddUser = new System.Windows.Forms.Button();
            this.btnDashboard = new System.Windows.Forms.Button();
            this.panelMain = new System.Windows.Forms.Panel();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.picLogo39_Khanh = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo39_Khanh)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Navy;
            this.panel1.Controls.Add(this.btnRevenue);
            this.panel1.Controls.Add(this.btnTheoDoiLog);
            this.panel1.Controls.Add(this.lb2);
            this.panel1.Controls.Add(this.picLogo39_Khanh);
            this.panel1.Controls.Add(this.btnLogout);
            this.panel1.Controls.Add(this.btnProfile);
            this.panel1.Controls.Add(this.btnViewUser);
            this.panel1.Controls.Add(this.btnAddUser);
            this.panel1.Controls.Add(this.btnDashboard);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(275, 736);
            this.panel1.TabIndex = 2;
            // 
            // btnRevenue
            // 
            this.btnRevenue.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRevenue.ForeColor = System.Drawing.Color.Navy;
            this.btnRevenue.Location = new System.Drawing.Point(27, 548);
            this.btnRevenue.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnRevenue.Name = "btnRevenue";
            this.btnRevenue.Size = new System.Drawing.Size(220, 46);
            this.btnRevenue.TabIndex = 13;
            this.btnRevenue.Text = "Thống Kê Báo Cáo";
            this.btnRevenue.UseVisualStyleBackColor = true;
            this.btnRevenue.Click += new System.EventHandler(this.btnRevenue_Click);
            // 
            // btnTheoDoiLog
            // 
            this.btnTheoDoiLog.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTheoDoiLog.ForeColor = System.Drawing.Color.Navy;
            this.btnTheoDoiLog.Location = new System.Drawing.Point(27, 484);
            this.btnTheoDoiLog.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnTheoDoiLog.Name = "btnTheoDoiLog";
            this.btnTheoDoiLog.Size = new System.Drawing.Size(220, 46);
            this.btnTheoDoiLog.TabIndex = 12;
            this.btnTheoDoiLog.Text = "Theo Dõi Hoạt Động";
            this.btnTheoDoiLog.UseVisualStyleBackColor = true;
            this.btnTheoDoiLog.Click += new System.EventHandler(this.btnTheoDoiLog_Click);
            // 
            // lb2
            // 
            this.lb2.AutoSize = true;
            this.lb2.BackColor = System.Drawing.Color.Navy;
            this.lb2.Font = new System.Drawing.Font("Impact", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb2.ForeColor = System.Drawing.Color.White;
            this.lb2.Location = new System.Drawing.Point(31, 167);
            this.lb2.Name = "lb2";
            this.lb2.Size = new System.Drawing.Size(202, 35);
            this.lb2.TabIndex = 9;
            this.lb2.Text = "OUCare System";
            // 
            // btnLogout
            // 
            this.btnLogout.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogout.ForeColor = System.Drawing.Color.Navy;
            this.btnLogout.Location = new System.Drawing.Point(27, 650);
            this.btnLogout.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(220, 46);
            this.btnLogout.TabIndex = 6;
            this.btnLogout.Text = "Đăng Xuất";
            this.btnLogout.UseVisualStyleBackColor = true;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // btnProfile
            // 
            this.btnProfile.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnProfile.ForeColor = System.Drawing.Color.Navy;
            this.btnProfile.Location = new System.Drawing.Point(27, 424);
            this.btnProfile.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnProfile.Name = "btnProfile";
            this.btnProfile.Size = new System.Drawing.Size(220, 46);
            this.btnProfile.TabIndex = 5;
            this.btnProfile.Text = "Hồ Sơ";
            this.btnProfile.UseVisualStyleBackColor = true;
            this.btnProfile.Click += new System.EventHandler(this.btnProfile_Click);
            // 
            // btnViewUser
            // 
            this.btnViewUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnViewUser.ForeColor = System.Drawing.Color.Navy;
            this.btnViewUser.Location = new System.Drawing.Point(27, 360);
            this.btnViewUser.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnViewUser.Name = "btnViewUser";
            this.btnViewUser.Size = new System.Drawing.Size(220, 46);
            this.btnViewUser.TabIndex = 4;
            this.btnViewUser.Text = "Xem Thông Tin";
            this.btnViewUser.UseVisualStyleBackColor = true;
            this.btnViewUser.Click += new System.EventHandler(this.btnViewUser_Click);
            // 
            // btnAddUser
            // 
            this.btnAddUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddUser.ForeColor = System.Drawing.Color.Navy;
            this.btnAddUser.Location = new System.Drawing.Point(27, 297);
            this.btnAddUser.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnAddUser.Name = "btnAddUser";
            this.btnAddUser.Size = new System.Drawing.Size(220, 46);
            this.btnAddUser.TabIndex = 3;
            this.btnAddUser.Text = "Thêm Người Dùng";
            this.btnAddUser.UseVisualStyleBackColor = true;
            this.btnAddUser.Click += new System.EventHandler(this.btnAddUser_Click);
            // 
            // btnDashboard
            // 
            this.btnDashboard.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDashboard.ForeColor = System.Drawing.Color.Navy;
            this.btnDashboard.Location = new System.Drawing.Point(28, 233);
            this.btnDashboard.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnDashboard.Name = "btnDashboard";
            this.btnDashboard.Size = new System.Drawing.Size(220, 46);
            this.btnDashboard.TabIndex = 2;
            this.btnDashboard.Text = "Bảng Điều Khiển";
            this.btnDashboard.UseVisualStyleBackColor = true;
            this.btnDashboard.Click += new System.EventHandler(this.btnDashboard_Click);
            // 
            // panelMain
            // 
            this.panelMain.BackColor = System.Drawing.Color.White;
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelMain.Location = new System.Drawing.Point(273, 0);
            this.panelMain.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new System.Drawing.Size(947, 736);
            this.panelMain.TabIndex = 3;
            // 
            // picLogo39_Khanh
            // 
            this.picLogo39_Khanh.Image = ((System.Drawing.Image)(resources.GetObject("picLogo39_Khanh.Image")));
            this.picLogo39_Khanh.Location = new System.Drawing.Point(37, 12);
            this.picLogo39_Khanh.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.picLogo39_Khanh.Name = "picLogo39_Khanh";
            this.picLogo39_Khanh.Size = new System.Drawing.Size(195, 135);
            this.picLogo39_Khanh.TabIndex = 11;
            this.picLogo39_Khanh.TabStop = false;
            // 
            // Admin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1220, 736);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panelMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Admin";
            this.Text = "Admin";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo39_Khanh)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnRevenue;
        private System.Windows.Forms.Button btnTheoDoiLog;
        private System.Windows.Forms.Label lb2;
        private System.Windows.Forms.PictureBox picLogo39_Khanh;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Button btnProfile;
        private System.Windows.Forms.Button btnViewUser;
        private System.Windows.Forms.Button btnAddUser;
        private System.Windows.Forms.Button btnDashboard;
        private System.Windows.Forms.Panel panelMain;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
    }
}