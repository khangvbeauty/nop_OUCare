using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransferObject
{
    public class MedicineDTO
    {
        public string MedCode { get; set; }
        public string Name { get; set; }
        public int? Quantity { get; set; }
        public DateTime ExpiryDate { get; set; }
        public DateTime CreatedDate { get; set; }
        public double PriceMua { get; set; }
        public double PriceBan { get; set; }
        public int GroupID { get; set; }
    }
}
