using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransferObject
{
    public class RevenueDTO
    {
        public DateTime? Date { get; set; }
        public int PatientCount { get; set; }
        public decimal TotalRevenue { get; set; }
    }
}
