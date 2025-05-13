using DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransferObject;

namespace BusinessLayer
{
    public class LogBL
    {
        private LogDL logDL = new LogDL();
        //private UsersDTO userDAL = new UsersDTO();

        public List<LogDTO> GetFilteredLogs(DateTime startDate, DateTime endDate, string action = null, int? userID = null, string entityType = null)
        {
            return logDL.GetFilteredLogs(startDate, endDate, action, userID, entityType);
        }

        public List<UsersDTO> GetAllUsers()
        {
            //return userDAL.GetAllUsers();
            return logDL.GetAllUsers();
        }

        // Người thêm - hành động gì - ID Đối tượng bị tác động - Tên đối tượng bị tác động
        public void AddLog(int userID, string action, int? entityID, string entityType)
        {
            LogDTO log = new LogDTO
            {
                userID = userID,
                action = action,
                entityID = entityID,
                entityType = entityType,
                logDate = DateTime.Now
            };

            logDL.AddLog(log);
        }

        public LogDTO GetLogDetail(int logID)
        {
            return logDL.GetLogByID(logID);
        }

        // Phương thức tiện ích: Ghi log thêm thuốc
        public void LogAddMedicine(int userID, int medicineID)
        {
            AddLog(userID, "Thêm thuốc", medicineID, "Medicine");
        }

        // Phương thức tiện ích: Ghi log sửa thuốc
        public void LogEditMedicine(int userID, int medicineID)
        {
            AddLog(userID, "Sửa thuốc", medicineID, "Medicine");
        }

        // Phương thức tiện ích: Ghi log xóa thuốc
        public void LogDeleteditMedicine(int userID, int medicineID)
        {
            AddLog(userID, "Xóa thuốc", medicineID, "Medicine");
        }
        // Phương thức tiện ích: Ghi log tạo hóa đơn
        public void LogCreateBill(int userID, int billID)
        {
            AddLog(userID, "Tạo hóa đơn", billID, "Bill");
        }

        // Phương thức tiện ích: Ghi log thêm người dùng
        public void LogAddUser(int userID, int newUserID)
        {
            AddLog(userID, "Thêm người dùng", newUserID, "User");
        }

        // Ghi log update người dùng
        public void LogUpdateUser(int userID, int updatedUserID)
        {
            AddLog(userID, "Sửa người dùng", updatedUserID, "User");
        }

        // Ghi log Xóa người dùng
        public void LogDeleteUser(int userID, int deletedUserID)
        {
            AddLog(userID, "Xóa người dùng", deletedUserID, "User");
        }
        // Ghi log đăng nhập
        public void LogLogin(int userID, int loginUserID)
        {
            AddLog(userID, "Đăng nhập", loginUserID, "User");
        }
        // Ghi log đăng xuất
        public void LogLogout(int userID, int logoutUserID)
        {
            AddLog(userID, "Đăng xuất", logoutUserID, "User");
        }
    }
}
