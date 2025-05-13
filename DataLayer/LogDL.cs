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
                                //.ToString("dd/MM/yyyy HH:mm:ss")
                            };

                if (!string.IsNullOrEmpty(action))
                    query = query.Where(l => l.action == action);

                if (userID.HasValue)
                    query = query.Where(l => l.userID == userID.Value);

                if (!string.IsNullOrEmpty(entityType))
                    query = query.Where(l => l.entityType == entityType);

                return query.OrderByDescending(l => l.logDate).ToList();
            }
        }

        public void AddLog(LogDTO log)
        {
            using (var context = new OUCareDBContext())
            {
                var newLog = new Log
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
