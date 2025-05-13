using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransferObject
{
    public class BillDTO
    {
        public int ID { get; set; }
        public int CusID { get; set; }
        public string CustomerName { get; set; }
        public DateTime? BillDate { get; set; }
        public decimal? Total { get; set; }
        public string QrLink { get; set; }
    }
}
