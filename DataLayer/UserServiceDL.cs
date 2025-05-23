﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransferObject;

namespace DataLayer
{
    public class UserServiceDL
    {
        //private readonly DataProvider dataProvider = new DataProvider();

        //public object IsUserLogin(string username, string password)
        //{
        //    string sql = "SELECT COUNT(*) FROM [User] WHERE Username = @Username AND Password = @Password";
        //    var parameters = new[]
        //    {
        //        new SqlParameter("@Username", username),
        //        new SqlParameter("@Password", password)
        //    };
        //    return dataProvider.MyExcuteScalar(sql, CommandType.Text, parameters);
        //}

        public bool IsUserLogin_ORM(string username, string password)
        {
            using (var context = new OUCareDBContext())
            {                
                return context.Users
                    .Where(u => u.isActive == 1)
                    // toàn bộ kết quả của câu lệnh trước đó được tải về bộ nhớ C# dưới dạng IEnumerable
                    .AsEnumerable() // chuyển sang xử lý phía client
                    .Any(u =>
                        string.Equals(u.userName, username, StringComparison.Ordinal) && // so sánh nhị phân (phân biệt hoa thường)
                        string.Equals(u.passWord, password, StringComparison.Ordinal));
            }
        }

        public List<UsersDTO> GetAllUsers()
        {
            using (var context = new OUCareDBContext())
            {
                return context.Users.Select(u => new UsersDTO
                {
                    ID = u.ID,
                    userName = u.userName,
                    name = u.name,
                    email = u.email,
                    roleID = u.roleID,
                    CreateDate = u.createDate,
                    IsActive = u.isActive
                }).ToList();
            }
        }

        public List<UsersDTO> SearchUsers(string username)
        {
            using (var context = new OUCareDBContext())
            {
                return context.Users
                    .Where(u => u.userName.Contains(username))
                    .Select(u => new UsersDTO
                    {
                        ID = u.ID,
                        userName = u.userName,
                        name = u.name,
                        email = u.email,
                        roleID = u.roleID,
                        CreateDate = u.createDate,
                        IsActive = u.isActive
                    }).ToList();
            }
        }

        public bool DeleteUser(int userID)
        {
            using (var context = new OUCareDBContext())
            {
                var user = context.Users.Find(userID);
                if (user != null)
                {
                    context.Users.Remove(user);
                    return context.SaveChanges() > 0;
                }
                return false;
            }
        }

        public UsersDTO GetUserProfile(string username)
        {
            using (var context = new OUCareDBContext())
            {
                return context.Users
                    .Where(u => u.userName == username)
                    .Select(u => new UsersDTO
                    {
                        ID = u.ID,
                        userName = u.userName,
                        passWord = u.passWord,
                        name = u.name,
                        email = u.email,
                        roleID = u.roleID,
                        CreateDate = u.createDate,
                        IsActive = u.isActive
                    }).FirstOrDefault();
            }
        }

        public bool UpdateProfile(string username, string name, string email, string newPw, int roleID, int statusValue)
        {
            using (var context = new OUCareDBContext())
            {
                var user = context.Users.FirstOrDefault(u => u.userName == username);
                if (user != null)
                {
                    user.name = name;
                    user.email = email;
                    if (!string.IsNullOrEmpty(newPw)) // Nếu newPw không trống, cập nhật mật khẩu
                    {
                        user.passWord = newPw;
                    }
                    user.roleID = roleID;
                    user.isActive = statusValue;
                    context.SaveChanges();

                    return true;
                }
                return false;
            }
        }

        public int AddUser(string username, string name, string email, string password, int userRole)
        {
            using (var context = new OUCareDBContext())
            {
                if (context.Users.Any(u => u.userName == username))
                    return -1; // Username đã tồn tại

                var newUser = new User
                {
                    userName = username,
                    name = name,
                    email = email,
                    passWord = password,
                    roleID = userRole,
                    createDate = DateTime.Now,
                    isActive = 1
                };

                context.Users.Add(newUser);
                context.SaveChanges();
                return newUser.ID; // Trả về ID của người dùng mới
            }
        }
    }
}
