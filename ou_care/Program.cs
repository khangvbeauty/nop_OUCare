using DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ou_care
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            User currentUser = new User
            {
                ID = 1, // Hoặc lấy từ login
                userName = "admin" // Tùy bạn có gì muốn truyền
            };
            Application.Run(new Login());
        }
    }
}
