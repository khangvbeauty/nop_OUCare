using DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class BillDetailsBUS
    {
        private BillDetailsDAO billDetailsDAO = new BillDetailsDAO();

        public void AddBillDetail(BillDetail billDetail)
        {
            billDetailsDAO.AddBillDetail(billDetail);
        }
    }
}
