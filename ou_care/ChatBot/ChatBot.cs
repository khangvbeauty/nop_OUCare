using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChatBotOUC
{
    public partial class ChatBot : Form
    {
        public ChatBot()
        {
            InitializeComponent();
        }
        private SymptomChecker checker;
        // Change lblCanhBao from 'object' to 'Label' to fix the error

        private void ChatBot_Load(object sender, EventArgs e)
        {
            try
            {
                string csvPath = Path.Combine(Application.StartupPath, "ChanDoan.csv");
                if (!File.Exists(csvPath))
                {
                    MessageBox.Show($"Tệp bắt buộc 'ChanDoan.csv' không được tìm thấy tại: {csvPath}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Initialize the SymptomChecker with the CSV file
                checker = new SymptomChecker(csvPath);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Đã xảy ra lỗi khi khởi tạo SymptomChecker: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btSend_Click(object sender, EventArgs e)
        {
            string input = txtInput.Text.Trim();
            if (string.IsNullOrEmpty(input)) return;

            if (checker == null)
            {
                string csvPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "data.csv");
                checker = new SymptomChecker(csvPath);
            }

            var result = checker.FindClosestMatch(input);
            if (result == null)
            {
                txtOutput.Text = "Không nhận diện được triệu chứng nào phù hợp trong dữ liệu.";
                return;
            }

            var (benh, thuoc, goiY) = result.Value;


            // Tự viết logic phản hồi đơn giản
            txtOutput.Text = $"🩺 Dự đoán: {benh}\n💊 Thuốc: {thuoc}\n📝 Gợi ý: {goiY}";

            // Gợi ý triệu chứng nghiêm trọng
            string[] nguyHiem = { "đau ngực", "khó thở", "chảy máu", "mất ý thức", "co giật", "sốt cao", "mất vị giác" };
            lblCanhBao.Text = nguyHiem.Any(t => input.Contains(t))
                ? "⚠️ Triệu chứng nghiêm trọng. Vui lòng đi khám bác sĩ."
                : "";

            // Lưu lịch sử
            string thoiGian = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            string lichSu = $"{thoiGian},\"{input}\",\"{benh}\",\"{thuoc}\"";
            File.AppendAllText("lichsu.csv", lichSu + Environment.NewLine);
        }

    }
}
