namespace ou_care.ChucNangNhanVien
{
    partial class UC_NV_XemThuoc
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblCount = new System.Windows.Forms.Label();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnReload = new System.Windows.Forms.Button();
            this.dgvMedicines = new System.Windows.Forms.DataGridView();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cbCamera = new System.Windows.Forms.ComboBox();
            this.picWebcam = new System.Windows.Forms.PictureBox();
            this.btnStartQR = new System.Windows.Forms.Button();
            this.btnStopQR = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMedicines)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picWebcam)).BeginInit();
            this.SuspendLayout();
            // 
            // lblCount
            // 
            this.lblCount.AutoSize = true;
            this.lblCount.Location = new System.Drawing.Point(14, 210);
            this.lblCount.Name = "lblCount";
            this.lblCount.Size = new System.Drawing.Size(0, 16);
            this.lblCount.TabIndex = 68;
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.Color.Crimson;
            this.btnDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnDelete.Location = new System.Drawing.Point(561, 639);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(118, 42);
            this.btnDelete.TabIndex = 66;
            this.btnDelete.Text = "Xóa";
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnReload
            // 
            this.btnReload.BackColor = System.Drawing.Color.RoyalBlue;
            this.btnReload.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReload.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnReload.Location = new System.Drawing.Point(723, 639);
            this.btnReload.Name = "btnReload";
            this.btnReload.Size = new System.Drawing.Size(118, 42);
            this.btnReload.TabIndex = 67;
            this.btnReload.Text = "Tải lại";
            this.btnReload.UseVisualStyleBackColor = false;
            this.btnReload.Click += new System.EventHandler(this.btnReload_Click);
            // 
            // dgvMedicines
            // 
            this.dgvMedicines.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMedicines.Location = new System.Drawing.Point(0, 358);
            this.dgvMedicines.Name = "dgvMedicines";
            this.dgvMedicines.RowHeadersWidth = 51;
            this.dgvMedicines.RowTemplate.Height = 24;
            this.dgvMedicines.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvMedicines.Size = new System.Drawing.Size(910, 259);
            this.dgvMedicines.TabIndex = 65;
            this.dgvMedicines.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvMedicines_CellContentClick);
            this.dgvMedicines.SelectionChanged += new System.EventHandler(this.dgvMedicines_SelectionChanged);
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(26, 87);
            this.txtSearch.Multiline = true;
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(190, 39);
            this.txtSearch.TabIndex = 64;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(22, 58);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(87, 23);
            this.label3.TabIndex = 63;
            this.label3.Text = "Tìm thuốc";
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Font = new System.Drawing.Font("Segoe UI Black", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.MediumBlue;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(910, 81);
            this.label1.TabIndex = 62;
            this.label1.Text = "XEM THUỐC";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // cbCamera
            // 
            this.cbCamera.FormattingEnabled = true;
            this.cbCamera.Location = new System.Drawing.Point(26, 150);
            this.cbCamera.Name = "cbCamera";
            this.cbCamera.Size = new System.Drawing.Size(121, 24);
            this.cbCamera.TabIndex = 69;
            // 
            // picWebcam
            // 
            this.picWebcam.Location = new System.Drawing.Point(237, 77);
            this.picWebcam.Name = "picWebcam";
            this.picWebcam.Size = new System.Drawing.Size(646, 259);
            this.picWebcam.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picWebcam.TabIndex = 70;
            this.picWebcam.TabStop = false;
            // 
            // btnStartQR
            // 
            this.btnStartQR.Location = new System.Drawing.Point(141, 286);
            this.btnStartQR.Name = "btnStartQR";
            this.btnStartQR.Size = new System.Drawing.Size(75, 23);
            this.btnStartQR.TabIndex = 71;
            this.btnStartQR.Text = "Bật";
            this.btnStartQR.UseVisualStyleBackColor = true;
            this.btnStartQR.Click += new System.EventHandler(this.btnStartQR_Click);
            // 
            // btnStopQR
            // 
            this.btnStopQR.Location = new System.Drawing.Point(26, 286);
            this.btnStopQR.Name = "btnStopQR";
            this.btnStopQR.Size = new System.Drawing.Size(75, 23);
            this.btnStopQR.TabIndex = 71;
            this.btnStopQR.Text = "Tắt";
            this.btnStopQR.UseVisualStyleBackColor = true;
            this.btnStopQR.Click += new System.EventHandler(this.btnStopQR_Click);
            // 
            // UC_NV_XemThuoc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnStopQR);
            this.Controls.Add(this.btnStartQR);
            this.Controls.Add(this.picWebcam);
            this.Controls.Add(this.cbCamera);
            this.Controls.Add(this.lblCount);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnReload);
            this.Controls.Add(this.dgvMedicines);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Name = "UC_NV_XemThuoc";
            this.Size = new System.Drawing.Size(910, 705);
            this.Load += new System.EventHandler(this.UC_NV_XemThuoc_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMedicines)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picWebcam)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblCount;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnReload;
        private System.Windows.Forms.DataGridView dgvMedicines;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbCamera;
        private System.Windows.Forms.PictureBox picWebcam;
        private System.Windows.Forms.Button btnStartQR;
        private System.Windows.Forms.Button btnStopQR;
    }
}
