using DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class ForgotPassBL
    {
        private readonly ForgotPassDL dl = new ForgotPassDL();
        public bool ResetPassword(string email, out string errorMessage)
        {
            return dl.ResetPassword(email, out errorMessage);
        }
    }
}
