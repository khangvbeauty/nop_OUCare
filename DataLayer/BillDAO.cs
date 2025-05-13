using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransferObject;

namespace DataLayer
{
    public class BillDAO
    {
        public int AddBill(Bill bill)
        {
            using (OUCareDBContext db = new OUCareDBContext())
            {
                db.Bills.Add(bill);
                db.SaveChanges(); // tự động thêm bill và gán ID
                return bill.ID; // trả về ID vừa được tạo

            }
        }
        private OUCareDBContext db = new OUCareDBContext();

        public List<BillDTO> GetAll()
        {
            return db.Bills.Include("Customer").Select(b => new BillDTO
            {
                ID = b.ID,
                CusID = b.cusID ?? 0,
                CustomerName = b.Customer.name,
                BillDate = b.billDate ?? DateTime.MinValue,
                Total = b.total ?? 0,
                QrLink = b.qrLink
            }).ToList();
        }

        public List<BillDetailDTO> GetDetails(int billID)
        {
            return db.BillDetails
                .Where(d => d.billID == billID)
                .Select(d => new BillDetailDTO
                {
                    ID = d.ID,
                    BillID = d.billID,
                    MedID = d.medID,
                    MedName = d.Medicine.name,
                    Quantity = d.quantity,
                    UnitPrice = d.unitPrice,
                    Amount = d.amount
                }).ToList();
        }


        public void Delete(int id)
        {
            var details = db.BillDetails.Where(d => d.billID == id).ToList();
            db.BillDetails.RemoveRange(details);

            var bill = db.Bills.Find(id);
            if (bill != null)
            {
                db.Bills.Remove(bill);
                db.SaveChanges();
            }
        }
        public BillDTO GetBillByID(int id)
        {
            using (var db = new OUCareDBContext())
            {
                var b = db.Bills.Find(id);
                if (b == null) return null;

                return new BillDTO
                {
                    ID = b.ID,
                    CusID = b.cusID ?? 0,
                    BillDate = b.billDate,
                    Total = b.total,
                    QrLink = b.qrLink
                };
            }
        }

    }
}
