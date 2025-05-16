using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransferObject
{
    // Các thuộc tính như kiểu int không cho phép null (nhưng trong database, các giá trị có thể null)
    public class UsersDTO
    {
        public int ID { get; set; }
        public string userName { get; set; }      
        public string passWord { get; set; }
        public string name { get; set; }
        public string email { get; set; }
        public int? roleID { get; set; }
        public DateTime? CreateDate { get; set; }
        public int? IsActive { get; set; } // int?: Cho phép null
       
    }
}
