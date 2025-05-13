using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

using DataLayer; // BusinessLayer có thể tham chiếu đến DataLayer
using TransferObject; // Để sử dụng Acccount
using System.Data.SqlClient; // Tạo SqlParameter để tránh Data injection
using System.Linq;
using System.Security.Principal; // Thêm dòng này vào đầu file


namespace BusinessLayer
{
    public class UserServiceBL
    {
        private readonly UserServiceDL userDL = new UserServiceDL();
        private readonly LogBL logBL = new LogBL();

        //public bool IsUserLogin(Acccount account)
        //{
        //    try
        //    {
        //        object result = userDL.IsUserLogin(account.Username, account.Password);
        //        return Convert.ToInt32(result) > 0;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception("Lỗi khi kiểm tra đăng nhập: " + ex.Message);
        //    }
        //}

        public bool IsUserLogin_ORM(Acccount account)
        {
            try
            {
                return userDL.IsUserLogin_ORM(account.Username, account.Password);
            }
            catch (Exception ex)
            {
                throw new Exception("Error: " + ex.Message);
            }
        }

        public List<UsersDTO> GetAllUsers()
        {
            return userDL.GetAllUsers();
        }

        public List<UsersDTO> SearchUsers(string username)
        {
            return userDL.SearchUsers(username);
        }

        // currentUID là người đang thực hiện xóa, userID là người bị xóa
        public bool DeleteUser(int userID)
        {
            try
            {
                return userDL.DeleteUser(userID);
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi xóa người dùng: " + ex.Message);
            }
        }

        public UsersDTO GetUserProfile(string username)
        {
            try
            {
                return userDL.GetUserProfile(username);
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi tải thông tin profile: " + ex.Message);
            }
        }

        public bool UpdateProfile2(string username, string name, string email, string oldPw, string newPw)
        {
            try
            {
                return userDL.UpdateProfile(username, name, email, oldPw, newPw);
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi thay đổi thông tin: " + ex.Message);
            }
        }

        public bool UpdateProfile(string username, string name, string email, string oldPw, string newPw, int roleID)
        {
            try
            {
                bool result = userDL.UpdateProfile(username, name, email, newPw, roleID);
                if (result)
                {
                   
                    return true;
                }
                else
                    return false;
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi cập nhật thông tin: " + ex.Message);
            }
        }

        public bool AddUser(int currentUserID, string username, string name, string email, string password, int userRole)
        {
            try
            {
                int newUserID = userDL.AddUser(username, name, email, password, userRole);
                if (newUserID > 0)
                {
                    logBL.LogAddUser(currentUserID, newUserID);
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi thêm người dùng: " + ex.Message);
            }
        }


    }
}