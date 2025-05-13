using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransferObject
{
    public class LogDTO
    {
        public int ID { get; set; }
        public int? userID { get; set; }
        public string action { get; set; }
        public int? entityID { get; set; }
        public string entityType { get; set; }
        public DateTime? logDate { get; set; }

        // Thuộc tính bổ sung cho hiển thị
        public string userName { get; set; }
        public string logDateFormatted { get; set; }

        // Chi tiết liên quan đến đối tượng (có thể mở rộng)
        public string entityDetail { get; set; }
    }
}
