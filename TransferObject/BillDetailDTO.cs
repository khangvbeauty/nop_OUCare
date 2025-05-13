using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransferObject
{
    public class BillDetailDTO
    {
        public int ID { get; set; }
        public int? BillID { get; set; }
        public int? MedID { get; set; }
        public string MedName { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal Amount { get; set; }
    }
}
