using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class ForgotPassDL
    {
        public bool ResetPassword(string email, out string errorMessage)
        {
            errorMessage = "";
            try
            {
                using (var context = new OUCareDBContext())
                {
                    // Kiểm tra email
                    var user = context.Users
                        .FirstOrDefault(u => u.email == email && u.isActive == 1);

                    if (user == null)
                    {
                        errorMessage = "Email không tồn tại hoặc tài khoản không hoạt động!";
                        return false;
                    }

                    // Kiểm tra tần suất yêu cầu
                    //var lastReset = context.Logs
                    //    .Where(l => l.userID == user.ID && l.action == "Đặt lại mật khẩu")
                    //    .OrderByDescending(l => l.logDate)
                    //    .FirstOrDefault();
                    //if (lastReset != null && (DateTime.Now - lastReset.logDate).TotalMinutes < 5)
                    //{
                    //    errorMessage = "Vui lòng thử lại sau 5 phút!";
                    //    return false;
                    //}

                    // Tạo mật khẩu mới
                    string newPassword = GenerateRandomPassword();
                    user.passWord = HashPassword(newPassword); // Mã hóa nếu cần

                    // Cập nhật mật khẩu
                    context.SaveChanges();

                    // Ghi log
                    var log = new Log
                    {
                        userID = user.ID,
                        action = "Đặt lại mật khẩu",
                        entityID = user.ID,
                        entityType = "User",
                        logDate = DateTime.Now
                    };
                    context.Logs.Add(log);
                    context.SaveChanges();

                    // Gửi email
                    SendResetPasswordEmail(user.email, user.userName, newPassword);
                    return true;
                }
            }
            catch (Exception ex)
            {
                errorMessage = "Lỗi: " + ex.Message;
                return false;
            }
        }

        private string GenerateRandomPassword(int length = 8)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            Random random = new Random();
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        private string HashPassword(string password)
        {
            return password; // Thay bằng BCrypt nếu cần
            // Ví dụ: return BCrypt.Net.BCrypt.HashPassword(password);
        }

        private void SendResetPasswordEmail(string toEmail, string userName, string newPassword)
        {
            try
            {
                MailMessage mail = new MailMessage();
                SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 587);

                mail.From = new MailAddress("nqk99991@gmail.com","OUCare System"); // Thay bằng email của bạn

                mail.To.Add(toEmail);
                mail.Subject = "Đặt Lại Mật Khẩu - OUCare";
                mail.Body = $"Chào {userName},\n\n" +
                            $"Mật khẩu mới của bạn là: {newPassword}\n" +
                            $"Vui lòng đăng nhập và đổi mật khẩu ngay sau khi nhận được email này.\n\n" +
                            $"Trân trọng,\nOUCare Team";

                smtpClient.Credentials = new NetworkCredential("nqk99991@gmail.com", "wwww jslw esah fmlq"); // Thay bằng App Password
                smtpClient.EnableSsl = true;

                smtpClient.Send(mail);
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi gửi email: " + ex.Message);
            }
        }    
}
}
