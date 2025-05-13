using DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransferObject;

namespace BusinessLayer
{
    public class BillBUS
    {
        private BillDAO billDAO = new BillDAO();

        public int AddBill(Bill bill)
        {
            return billDAO.AddBill(bill);
        }
        public List<BillDTO> GetAllBills() => billDAO.GetAll();

        public List<BillDetailDTO> GetBillDetails(int billID) => billDAO.GetDetails(billID);

        public void DeleteBill(int id) => billDAO.Delete(id);
        public BillDTO GetBillByID(int id)
        {
            return billDAO.GetBillByID(id);
        }


    }
}
