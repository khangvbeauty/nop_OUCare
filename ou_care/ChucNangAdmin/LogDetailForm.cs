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
    public partial class LogDetailForm : Form
    {
        private LogDTO log;
        public LogDetailForm(LogDTO log)
        {
            InitializeComponent();
            this.log = log;
            LoadLogDetail();
            this.SuspendLayout();

            // Close Button
            var btnClose = new Button
            {
                Text = "Đóng",
                Dock = DockStyle.Bottom,
                Height = 40
            };
            btnClose.Click += btnClose_Click;

            this.Controls.Add(btnClose);
            this.Text = "Chi tiết log";
            this.StartPosition = FormStartPosition.CenterParent;
            this.AutoSize = true;
            this.ResumeLayout(false);
        }
        private void LoadLogDetail()
        {
            this.Text = $"Chi tiết hoạt động - {log.ID}";

            lblTime.Text = log.logDateFormatted;
            lblUser.Text = log.userName;
            lblAction.Text = log.action;
            lblEntityType.Text = log.entityType;
            lblEntityID.Text = log.entityID?.ToString() ?? "N/A";

        
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }


    }
}
