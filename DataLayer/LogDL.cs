using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransferObject;

namespace DataLayer
{
    public class LogDL
    {
        // lấy danh sách các bản ghi log từ cơ sở dữ liệu dựa trên các tiêu chí lọc 
        public List<LogDTO> GetFilteredLogs(DateTime startDate, DateTime endDate, string action = null, int? userID = null, string entityType = null)
        {
            using (var context = new OUCareDBContext())
            {
                var query = from l in context.Logs
                            join u in context.Users on l.userID equals u.ID
                            where l.logDate >= startDate && l.logDate <= endDate
                            select new LogDTO
                            {
                                ID = l.ID,
                                userID = l.userID,
                                action = l.action,
                                entityID = l.entityID,
                                entityType = l.entityType,
                                logDate = l.logDate,
                                userName = u.name,
                                logDateFormatted = l.logDate.ToString()
                            };

                // Nếu action không rỗng hoặc không null, truy vấn sẽ được lọc để chỉ lấy các log có giá trị action khớp với tham số
                if (!string.IsNullOrEmpty(action))
                    query = query.Where(l => l.action == action);

                if (userID.HasValue)
                    query = query.Where(l => l.userID == userID.Value);

                if (!string.IsNullOrEmpty(entityType))
                    query = query.Where(l => l.entityType == entityType);

                return query.OrderByDescending(l => l.logDate).ToList();
            }
        }

        // thêm một bản ghi log mới
        public void AddLog(LogDTO log)
        {
            using (var context = new OUCareDBContext())
            {
                var newLog = new Log // Log là một entity
                {
                    userID = log.userID,
                    action = log.action,
                    entityID = log.entityID,
                    entityType = log.entityType,
                    logDate = log.logDate
                };

                context.Logs.Add(newLog);
                context.SaveChanges();
            }
        }

        // Dùng trong xem chi tiết Log
        public LogDTO GetLogByID(int logID)
        {
            using (var context = new OUCareDBContext())
            {
                return (from l in context.Logs
                        join u in context.Users on l.userID equals u.ID
                        where l.ID == logID
                        select new LogDTO
                        {
                            ID = l.ID,
                            userID = l.userID,
                            action = l.action,
                            entityID = l.entityID,
                            entityType = l.entityType,
                            logDate = l.logDate,
                            userName = u.name,
                            logDateFormatted = l.logDate.ToString()
                            //("dd/MM/yyyy HH:mm:ss")
                        }).FirstOrDefault();
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
    }
}
