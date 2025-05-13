using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransferObject
{
    public class Acccount
    {
        public string Username { get; set; }

        public string Password { get; set; }

        public Acccount(string user, string pass)
        {
            this.Username = user;
            this.Password = pass;
        }
    }
}
