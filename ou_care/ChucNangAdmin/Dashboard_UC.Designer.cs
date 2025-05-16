namespace ou_care.ChucNangAdmin
{
    partial class Dashboard_UC
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title1 = new System.Windows.Forms.DataVisualization.Charting.Title();
            this.label3 = new System.Windows.Forms.Label();
            this.btn7days = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.dtpEndDate = new System.Windows.Forms.DateTimePicker();
            this.dtpStartDate = new System.Windows.Forms.DateTimePicker();
            this.btnLast30Days = new System.Windows.Forms.Button();
            this.lbTongUser = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lbTongThuoc = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.lbDoanhThu = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.dgvThuocThap = new System.Windows.Forms.DataGridView();
            this.panel5 = new System.Windows.Forms.Panel();
            this.bieuDo = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.label2 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.lbTongGiaoDich = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvThuocThap)).BeginInit();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bieuDo)).BeginInit();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Impact", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Navy;
            this.label3.Location = new System.Drawing.Point(9, 13);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(148, 35);
            this.label3.TabIndex = 50;
            this.label3.Text = "DASHBOARD";
            // 
            // btn7days
            // 
            this.btn7days.BackColor = System.Drawing.Color.Navy;
            this.btn7days.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn7days.ForeColor = System.Drawing.Color.White;
            this.btn7days.Location = new System.Drawing.Point(623, 48);
            this.btn7days.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.btn7days.Name = "btn7days";
            this.btn7days.Size = new System.Drawing.Size(151, 43);
            this.btn7days.TabIndex = 49;
            this.btn7days.Text = "Last 7 days";
            this.btn7days.UseVisualStyleBackColor = false;
            this.btn7days.Click += new System.EventHandler(this.btn7days_Click);
            // 
            // btnOK
            // 
            this.btnOK.BackColor = System.Drawing.Color.DarkBlue;
            this.btnOK.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOK.ForeColor = System.Drawing.Color.AliceBlue;
            this.btnOK.Location = new System.Drawing.Point(529, 48);
            this.btnOK.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(80, 43);
            this.btnOK.TabIndex = 48;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = false;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // dtpEndDate
            // 
            this.dtpEndDate.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpEndDate.CustomFormat = "MMM dd, yyyy";
            this.dtpEndDate.Enabled = false;
            this.dtpEndDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpEndDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpEndDate.Location = new System.Drawing.Point(725, 13);
            this.dtpEndDate.Margin = new System.Windows.Forms.Padding(4);
            this.dtpEndDate.Name = "dtpEndDate";
            this.dtpEndDate.Size = new System.Drawing.Size(203, 23);
            this.dtpEndDate.TabIndex = 47;
            // 
            // dtpStartDate
            // 
            this.dtpStartDate.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpStartDate.CustomFormat = "MMM dd, yyyy";
            this.dtpStartDate.Enabled = false;
            this.dtpStartDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpStartDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpStartDate.Location = new System.Drawing.Point(529, 13);
            this.dtpStartDate.Margin = new System.Windows.Forms.Padding(4);
            this.dtpStartDate.Name = "dtpStartDate";
            this.dtpStartDate.Size = new System.Drawing.Size(187, 23);
            this.dtpStartDate.TabIndex = 46;
            this.dtpStartDate.Value = new System.DateTime(2024, 1, 1, 0, 0, 0, 0);
            // 
            // btnLast30Days
            // 
            this.btnLast30Days.BackColor = System.Drawing.Color.Navy;
            this.btnLast30Days.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLast30Days.ForeColor = System.Drawing.Color.White;
            this.btnLast30Days.Location = new System.Drawing.Point(788, 48);
            this.btnLast30Days.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.btnLast30Days.Name = "btnLast30Days";
            this.btnLast30Days.Size = new System.Drawing.Size(140, 43);
            this.btnLast30Days.TabIndex = 45;
            this.btnLast30Days.Text = "Last 30 days";
            this.btnLast30Days.UseVisualStyleBackColor = false;
            this.btnLast30Days.Click += new System.EventHandler(this.btnLast30Days_Click);
            // 
            // lbTongUser
            // 
            this.lbTongUser.AutoSize = true;
            this.lbTongUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTongUser.Location = new System.Drawing.Point(680, 57);
            this.lbTongUser.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbTongUser.Name = "lbTongUser";
            this.lbTongUser.Size = new System.Drawing.Size(97, 29);
            this.lbTongUser.TabIndex = 1;
            this.lbTongUser.Text = "100000";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(124)))), ((int)(((byte)(141)))), ((int)(((byte)(181)))));
            this.label5.Location = new System.Drawing.Point(681, 21);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(142, 25);
            this.label5.TabIndex = 0;
            this.label5.Text = "SL Người dùng";
            // 
            // lbTongThuoc
            // 
            this.lbTongThuoc.AutoSize = true;
            this.lbTongThuoc.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTongThuoc.Location = new System.Drawing.Point(449, 57);
            this.lbTongThuoc.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbTongThuoc.Name = "lbTongThuoc";
            this.lbTongThuoc.Size = new System.Drawing.Size(97, 29);
            this.lbTongThuoc.TabIndex = 1;
            this.lbTongThuoc.Text = "100000";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.Color.Navy;
            this.label13.Location = new System.Drawing.Point(4, 25);
            this.label13.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(167, 20);
            this.label13.TabIndex = 2;
            this.label13.Text = "Thuốc còn SL thấp";
            // 
            // lbDoanhThu
            // 
            this.lbDoanhThu.AutoSize = true;
            this.lbDoanhThu.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbDoanhThu.Location = new System.Drawing.Point(56, 57);
            this.lbDoanhThu.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbDoanhThu.Name = "lbDoanhThu";
            this.lbDoanhThu.Size = new System.Drawing.Size(97, 29);
            this.lbDoanhThu.TabIndex = 1;
            this.lbDoanhThu.Text = "100000";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(124)))), ((int)(((byte)(141)))), ((int)(((byte)(181)))));
            this.label11.Location = new System.Drawing.Point(245, 21);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(124, 25);
            this.label11.TabIndex = 0;
            this.label11.Text = "SL Giao dịch";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(124)))), ((int)(((byte)(141)))), ((int)(((byte)(181)))));
            this.label8.Location = new System.Drawing.Point(57, 21);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(102, 25);
            this.label8.TabIndex = 0;
            this.label8.Text = "Doanh thu";
            // 
            // dgvThuocThap
            // 
            this.dgvThuocThap.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvThuocThap.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvThuocThap.Location = new System.Drawing.Point(4, 64);
            this.dgvThuocThap.Margin = new System.Windows.Forms.Padding(4);
            this.dgvThuocThap.Name = "dgvThuocThap";
            this.dgvThuocThap.RowHeadersWidth = 51;
            this.dgvThuocThap.Size = new System.Drawing.Size(460, 410);
            this.dgvThuocThap.TabIndex = 3;
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.White;
            this.panel5.Controls.Add(this.dgvThuocThap);
            this.panel5.Controls.Add(this.label13);
            this.panel5.Location = new System.Drawing.Point(7, 233);
            this.panel5.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(475, 490);
            this.panel5.TabIndex = 44;
            // 
            // bieuDo
            // 
            chartArea1.Name = "ChartArea1";
            this.bieuDo.ChartAreas.Add(chartArea1);
            legend1.Docking = System.Windows.Forms.DataVisualization.Charting.Docking.Bottom;
            legend1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            legend1.IsTextAutoFit = false;
            legend1.Name = "Legend1";
            this.bieuDo.Legends.Add(legend1);
            this.bieuDo.Location = new System.Drawing.Point(485, 233);
            this.bieuDo.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.bieuDo.Name = "bieuDo";
            this.bieuDo.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Pastel;
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Doughnut;
            series1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            series1.IsValueShownAsLabel = true;
            series1.LabelForeColor = System.Drawing.Color.White;
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.bieuDo.Series.Add(series1);
            this.bieuDo.Size = new System.Drawing.Size(455, 490);
            this.bieuDo.TabIndex = 43;
            this.bieuDo.Text = "chartTopProducts";
            title1.Alignment = System.Drawing.ContentAlignment.TopLeft;
            title1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            title1.Name = "Title1";
            title1.Text = "5 Thuốc bán chạy";
            this.bieuDo.Titles.Add(title1);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(124)))), ((int)(((byte)(141)))), ((int)(((byte)(181)))));
            this.label2.Location = new System.Drawing.Point(451, 21);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(196, 25);
            this.label2.TabIndex = 0;
            this.label2.Text = "SL Thuốc Trong Kho";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.White;
            this.panel3.Controls.Add(this.lbTongUser);
            this.panel3.Controls.Add(this.label5);
            this.panel3.Controls.Add(this.lbTongThuoc);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Controls.Add(this.lbTongGiaoDich);
            this.panel3.Controls.Add(this.lbDoanhThu);
            this.panel3.Controls.Add(this.label11);
            this.panel3.Controls.Add(this.label8);
            this.panel3.Location = new System.Drawing.Point(7, 116);
            this.panel3.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(933, 105);
            this.panel3.TabIndex = 42;
            // 
            // lbTongGiaoDich
            // 
            this.lbTongGiaoDich.AutoSize = true;
            this.lbTongGiaoDich.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTongGiaoDich.Location = new System.Drawing.Point(244, 57);
            this.lbTongGiaoDich.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbTongGiaoDich.Name = "lbTongGiaoDich";
            this.lbTongGiaoDich.Size = new System.Drawing.Size(97, 29);
            this.lbTongGiaoDich.TabIndex = 1;
            this.lbTongGiaoDich.Text = "100000";
            // 
            // Dashboard_UC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btn7days);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.dtpEndDate);
            this.Controls.Add(this.dtpStartDate);
            this.Controls.Add(this.btnLast30Days);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.bieuDo);
            this.Controls.Add(this.panel3);
            this.Name = "Dashboard_UC";
            this.Size = new System.Drawing.Size(947, 736);
            this.Load += new System.EventHandler(this.Dashboard_UC_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvThuocThap)).EndInit();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bieuDo)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btn7days;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.DateTimePicker dtpEndDate;
        private System.Windows.Forms.DateTimePicker dtpStartDate;
        private System.Windows.Forms.Button btnLast30Days;
        private System.Windows.Forms.Label lbTongUser;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lbTongThuoc;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label lbDoanhThu;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DataGridView dgvThuocThap;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.DataVisualization.Charting.Chart bieuDo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label lbTongGiaoDich;
    }
}
