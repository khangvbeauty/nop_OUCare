using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class BillDetailsDAO
    {
        public void AddBillDetail(BillDetail billDetail)
        {
            using (OUCareDBContext db = new OUCareDBContext()) 
            {
                db.BillDetails.Add(billDetail);
                db.SaveChanges();
            }
        }
    }
}
