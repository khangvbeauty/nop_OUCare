using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TransferObject;

namespace DataLayer
{
    public class RenenueDL
    {
        public RenenueDL()
        {  
        }

        private OUCareDBContext context = new OUCareDBContext();
        public List<RevenueDTO> GetRevenueByDateRange(DateTime fromDate, DateTime toDate)
        {
            var data = context.Bills
      .Where(b => b.billDate != null && b.billDate >= fromDate && b.billDate <= toDate)
      .GroupBy(b => DbFunctions.TruncateTime(b.billDate.Value)) // Sử dụng DbFunctions để lấy ngày
      .Select(g => new RevenueDTO
      {
          Date = g.Key.Value, // g.Key sẽ là DateTime không có giờ
          PatientCount = g.Count(),
          TotalRevenue = g.Sum(b => b.total ?? 0)
      })
      .OrderBy(r => r.Date)
      .ToList();
            return data;

        }
    }
}
