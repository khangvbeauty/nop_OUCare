﻿using System;
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

                    if (user.roleID == 1)
                    {
                        errorMessage = "Email không hợp lệ.";
                        return false;
                    }

                    // Tạo mật khẩu mới
                    string newPassword = GenerateRandomPassword();
                 

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
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789"; // Chuỗi chứa tập ký tự cho phép dùng trong mật khẩu
            Random random = new Random();
            return new string(Enumerable.Repeat(chars, length) //  // Tạo một danh sách gồm 8 phần tử giống nhau là chars
                .Select(s => s[random.Next(s.Length)]).ToArray()); // với mỗi chars gán 1 ký tự ngẫu nhiên -> chuyển thành arr -> ghép lại
              // s.length = 62, random.Next trả về từ 0-61
        }

        private void SendResetPasswordEmail(string toEmail, string userName, string newPassword)
        {
            try
            {
                MailMessage mail = new MailMessage();
                SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 587); // Khởi tạo SMTP client, dùng máy chủ Gmail

                mail.From = new MailAddress("nqk99991@gmail.com","OUCare System"); //email gửi

                mail.To.Add(toEmail);
                mail.Subject = "Đặt Lại Mật Khẩu - OUCare";
                mail.Body = $"Chào {userName},\n\n" +
                            $"Mật khẩu mới của bạn là: {newPassword}\n" +
                            $"Vui lòng đăng nhập và đổi mật khẩu ngay sau khi nhận được email này.\n\n" +
                            $"Trân trọng,\nOUCare Team";

                smtpClient.Credentials = new NetworkCredential("nqk99991@gmail.com", "wwww jslw esah fmlq"); //  thông tin xác thực App Password
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
