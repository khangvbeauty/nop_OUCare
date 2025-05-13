using DataLayer;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransferObject;

namespace BusinessLayer
{
    public class DashboardBL
    {
        DashboardDL dl = new DashboardDL();

        // Hiển thị số thuốc thấp
        public List<MedicineDTO> SLThuocThap()
        {
            try
            {
                return dl.SLThuocThap();
            }
            catch(SqlException ex)
            {
                throw ex;
            }
        }

        // Tổng người dùng
        public int CountUser() => dl.CountUser();

        // Tổng doanh thu
        public decimal GetTotalRevenue(DateTime startDate, DateTime endDate)
            => dl.GetTotalRevenue(startDate, endDate);

        // Tổng số thuốc
        public int GetTotalMedicines() => dl.GetTotalMedicines();

        // Tổng giao dịch
        public int TongGiaoDich() => dl.TongGiaoDich();

        // 5 thuốc bán chạy trong khoảng thời gian
        public List<MedicineDTO> Lay5ThuocBanChay(DateTime startDate, DateTime endDate)
            => dl.Lay5ThuocBanChay(startDate, endDate);
    }
}
