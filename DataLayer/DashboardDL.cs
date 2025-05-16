using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TransferObject;

namespace DataLayer
{
    public class DashboardDL
    {
        // Trả về thuốc có SL thấp
        public List<MedicineDTO> SLThuocThap()
        {
            using (var context = new OUCareDBContext())
            {
                return context.Medicines
                    .Where(u => u.quantity <= 300)
                    .Select(u => new MedicineDTO
                    {                       
                        Name = u.name,
                        Quantity = u.quantity
                    }).ToList();
            }
        }

        // Trả về SL người dùng
        public int CountUser()
        {
            using (var context = new OUCareDBContext())
            {
                return context.Users.Count();
            }
        }

        // Tổng doanh thu trong khoảng thời gian
        public decimal GetTotalRevenue(DateTime startDate, DateTime endDate)
        {
            using (var context = new OUCareDBContext())
            {
                return context.Bills
                    .Where(b => b.billDate >= startDate && b.billDate <= endDate)
                    .Sum(b => b.total) ?? 0; // ?? cung cấp giá trị mặc định là 0, vì sum trả về kiểu nullable(decimal?) còn hàm thì là non-null(decimal)
            }
        }

        // Tổng số thuốc
        public int GetTotalMedicines()
        {
            using (var context = new OUCareDBContext())
            {
                return context.Medicines.Count();
            }
        }

        // Tổng số giao dịch
        public int TongGiaoDich()
        {
            using (var context = new OUCareDBContext())
            {
                return context.Bills.Count();
            }
        }

        // 5 thuốc bán chạy trong khoảng thời gian
        public List<MedicineDTO> Lay5ThuocBanChay(DateTime startDate, DateTime endDate)
        {
            using (var context = new OUCareDBContext())
            {
                return context.BillDetails
                    .Join(context.Bills,  
                        bd => bd.billID, // Khóa từ BillDetails
                        b => b.ID, // Khóa từ Bills
                        (bd, b) => new { BillDetail = bd, Bill = b }) // Tạo một đối tượng tạm chứa cả thông tin của BillDetail và Bill cho mỗi cặp khớp
                    .Where(joined => joined.Bill.billDate >= startDate && joined.Bill.billDate <= endDate)
                    .GroupBy(joined => joined.BillDetail.medID) // Nhóm các bản ghi theo medID
                    .Select(g => new
                    {
                        MedicineId = g.Key, // Là medID (khóa nhóm từ GroupBy)
                        TotalQuantity = g.Sum(joined => joined.BillDetail.quantity)
                    })
                    .OrderByDescending(x => x.TotalQuantity)
                    .Take(5)
                    // khi Join, duyệt qua từng bản ghi trong tập hợp trước đó và gán mỗi bản ghi đó vào biến top với hai thuộc tính: MedicineId và TotalQuantity
                    .Join(context.Medicines,  
                        top => top.MedicineId, 
                        med => med.ID,  // Khóa từ Medicines
                        (top, med) => new MedicineDTO
                        {
                            Name = med.name,
                            Quantity = top.TotalQuantity
                        })
                    .ToList();
            }
        }
    }
}
