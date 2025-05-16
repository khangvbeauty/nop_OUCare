namespace ou_care.ChucNangAdmin
{
    partial class Revenue
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
            this.label3 = new System.Windows.Forms.Label();
            this.btnLoc = new System.Windows.Forms.Button();
            this.lbTongDoanhThu = new System.Windows.Forms.Label();
            this.dgvDoanhThu = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dptEndDate = new System.Windows.Forms.DateTimePicker();
            this.dtpStartDate = new System.Windows.Forms.DateTimePicker();
            this.btnExportPDF = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDoanhThu)).BeginInit();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Impact", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Navy;
            this.label3.Location = new System.Drawing.Point(33, 28);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(200, 28);
            this.label3.TabIndex = 28;
            this.label3.Text = "BÁO CÁO DOANH THU";
            // 
            // btnLoc
            // 
            this.btnLoc.BackColor = System.Drawing.Color.Navy;
            this.btnLoc.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLoc.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnLoc.Location = new System.Drawing.Point(420, 178);
            this.btnLoc.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnLoc.Name = "btnLoc";
            this.btnLoc.Size = new System.Drawing.Size(134, 46);
            this.btnLoc.TabIndex = 27;
            this.btnLoc.Text = "Áp dụng";
            this.btnLoc.UseVisualStyleBackColor = false;
            this.btnLoc.Click += new System.EventHandler(this.btnLoc_Click);
            // 
            // lbTongDoanhThu
            // 
            this.lbTongDoanhThu.AutoSize = true;
            this.lbTongDoanhThu.BackColor = System.Drawing.Color.Transparent;
            this.lbTongDoanhThu.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTongDoanhThu.ForeColor = System.Drawing.Color.Navy;
            this.lbTongDoanhThu.Location = new System.Drawing.Point(21, 689);
            this.lbTongDoanhThu.Name = "lbTongDoanhThu";
            this.lbTongDoanhThu.Size = new System.Drawing.Size(144, 20);
            this.lbTongDoanhThu.TabIndex = 26;
            this.lbTongDoanhThu.Text = "Tổng doanh thu:";
            // 
            // dgvDoanhThu
            // 
            this.dgvDoanhThu.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDoanhThu.Location = new System.Drawing.Point(25, 277);
            this.dgvDoanhThu.Name = "dgvDoanhThu";
            this.dgvDoanhThu.RowHeadersWidth = 51;
            this.dgvDoanhThu.RowTemplate.Height = 24;
            this.dgvDoanhThu.Size = new System.Drawing.Size(901, 388);
            this.dgvDoanhThu.TabIndex = 25;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Navy;
            this.label2.Location = new System.Drawing.Point(507, 84);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(93, 20);
            this.label2.TabIndex = 24;
            this.label2.Text = "Đến ngày:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Navy;
            this.label1.Location = new System.Drawing.Point(188, 84);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 20);
            this.label1.TabIndex = 23;
            this.label1.Text = "Từ ngày:";
            // 
            // dptEndDate
            // 
            this.dptEndDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dptEndDate.Location = new System.Drawing.Point(511, 117);
            this.dptEndDate.Name = "dptEndDate";
            this.dptEndDate.Size = new System.Drawing.Size(279, 27);
            this.dptEndDate.TabIndex = 22;
            // 
            // dtpStartDate
            // 
            this.dtpStartDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpStartDate.Location = new System.Drawing.Point(192, 117);
            this.dtpStartDate.Name = "dtpStartDate";
            this.dtpStartDate.Size = new System.Drawing.Size(289, 27);
            this.dtpStartDate.TabIndex = 21;
            this.dtpStartDate.Value = new System.DateTime(2024, 1, 1, 0, 0, 0, 0);
            // 
            // btnExportPDF
            // 
            this.btnExportPDF.BackColor = System.Drawing.Color.Navy;
            this.btnExportPDF.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExportPDF.ForeColor = System.Drawing.Color.White;
            this.btnExportPDF.Location = new System.Drawing.Point(25, 233);
            this.btnExportPDF.Margin = new System.Windows.Forms.Padding(4);
            this.btnExportPDF.Name = "btnExportPDF";
            this.btnExportPDF.Size = new System.Drawing.Size(124, 37);
            this.btnExportPDF.TabIndex = 61;
            this.btnExportPDF.Text = "Xuất PDF";
            this.btnExportPDF.UseVisualStyleBackColor = false;
            this.btnExportPDF.Click += new System.EventHandler(this.btnExportPDF_Click);
            // 
            // Revenue
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnExportPDF);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnLoc);
            this.Controls.Add(this.lbTongDoanhThu);
            this.Controls.Add(this.dgvDoanhThu);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dptEndDate);
            this.Controls.Add(this.dtpStartDate);
            this.Name = "Revenue";
            this.Size = new System.Drawing.Size(946, 736);
            this.Load += new System.EventHandler(this.Revenue_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDoanhThu)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnLoc;
        private System.Windows.Forms.Label lbTongDoanhThu;
        private System.Windows.Forms.DataGridView dgvDoanhThu;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dptEndDate;
        private System.Windows.Forms.DateTimePicker dtpStartDate;
        private System.Windows.Forms.Button btnExportPDF;
    }
}
