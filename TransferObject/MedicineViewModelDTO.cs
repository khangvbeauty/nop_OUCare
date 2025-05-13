using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransferObject
{
    public class MedicineViewModelDTO
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public double? Price { get; set; }
        public int? Quantity { get; set; }
        public string MedCode { get; set; }

        public DateTime? ExpiryDate { get; set; }
        public DateTime? CreatedDate { get; set; }
        public double? PriceMua { get; set; }   // Giá mua
        public double? PriceBan { get; set; }   // Giá bán
    }
}
