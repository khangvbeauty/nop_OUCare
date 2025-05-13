using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransferObject;

using DataLayer;

namespace BusinessLayer
{
    public class RevenueBL
    {
        RenenueDL dl = new RenenueDL();
        public List<RevenueDTO> GetRevenueByDateRange(DateTime fromDate, DateTime toDate) =>
            dl.GetRevenueByDateRange(fromDate, toDate);
    }
}
