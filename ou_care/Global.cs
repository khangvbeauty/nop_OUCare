using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransferObject;

namespace ou_care
{
    public static class Global
    {
        public static UsersDTO CurrentUser { get; set; }

        // Xóa thông tin người dùng khi đăng xuất
        public static void Clear()
        {
            CurrentUser = null;
        }
    }
}
