using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransferObject;

namespace DataLayer
{
    public class MedicineDAO
    {
        public List<MedicineViewModelDTO> GetAllMedicines()
        {
            using (var db = new OUCareDBContext())
            {
                return db.Medicines
                        .Where(m => m.Status != "Inactive") // chỉ lấy thuốc chưa bị ẩn
                        .Select(m => new MedicineViewModelDTO
         {
                    ID = m.ID,
                    Name = m.name,
                    Price = m.price,
                    Quantity = m.quantity,
                    ExpiryDate = m.expiryDate,
                    MedCode = m.medCode,
                    CreatedDate = m.createdDate,
                    PriceMua = m.priceMua ,
                    PriceBan = m.priceBan
                }).ToList();
            }
        }
        public List<MedicineViewModelDTO> SearchMedicines(string keyword)
        {
            using (var db = new OUCareDBContext())
            {
                return db.Medicines
                         .Where(m => m.name.Contains(keyword) && m.Status != "Inactive")
                         .Select(m => new MedicineViewModelDTO
                         {
                             ID = m.ID,
                             Name = m.name,
                             Price = m.price,
                             Quantity = m.quantity,
                             ExpiryDate = m.expiryDate.Value,
                             MedCode = m.medCode
                         })
                         .ToList();
            }
        }
        public int AddMedicine(MedicineDTO dto)
        {
            using (var db = new OUCareDBContext())
            {
                Medicine med = new Medicine
                {
                    medCode = dto.MedCode,
                    name = dto.Name,
                    quantity = dto.Quantity,
                    expiryDate = dto.ExpiryDate,
                    createdDate = dto.CreatedDate,
                    priceMua = dto.PriceMua,
                    priceBan = dto.PriceBan,
                    groupID = dto.GroupID,
                    Status = "Active"
                };

                db.Medicines.Add(med);
                db.SaveChanges();
                return med.ID;
            }
        }
        public (int conHan, int hetHan) GetMedicineExpiryStats()
        {
            using (var db = new OUCareDBContext()) 
            {
                DateTime now = DateTime.Now;
                int conHan = db.Medicines.Count(m => m.expiryDate >= now);
                int hetHan = db.Medicines.Count(m => m.expiryDate < now);
                return (conHan, hetHan);
            }
        }

        public void DeleteMedicine(int id)
        {
            using (var db = new OUCareDBContext())
            {
                var medicine = db.Medicines.Find(id);
                if (medicine != null)
                {
                    medicine.Status = "Inactive"; 
                    db.SaveChanges();
                }
            }
        }
        public List<Medicine> GetMedicinesByExpiryStatus(string status)
        {
            using (var db = new OUCareDBContext())
            {
                if (status == "Valid")
                    return db.Medicines.Where(m => m.expiryDate >= DateTime.Now).ToList();
                else if (status == "Expired")
                    return db.Medicines.Where(m => m.expiryDate < DateTime.Now).ToList();
                else
                    return db.Medicines.ToList();
            }
        }
        public void UpdateMedicineQuantity(int medID, int soldQuantity)
        {
            using (var db = new OUCareDBContext())
            {
                var medicine = db.Medicines.Find(medID);
                if (medicine != null)
                {
                    medicine.quantity -= soldQuantity;
                    db.SaveChanges();
                }
            }
        }
    }

}
