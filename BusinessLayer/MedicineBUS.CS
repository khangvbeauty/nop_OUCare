using DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransferObject;

namespace BusinessLayer
{
    public class MedicineBUS
    {
        private MedicineDAO medicineDAO = new MedicineDAO();
        LogBL logBL = new LogBL();

        public List<MedicineViewModelDTO> SearchMedicines(string keyword)
        {
            return medicineDAO.SearchMedicines(keyword);
        }
        public Medicine GetMedicineById(int id)
        {
            using (OUCareDBContext db = new OUCareDBContext())
            {
                return db.Medicines.FirstOrDefault(m => m.ID == id);
            }
        }

        public bool AddMedicine(int currentID, MedicineDTO dto)
        {
            // Kiểm tra trùng mã
            using (var db = new OUCareDBContext())
            {
                if (db.Medicines.Any(m => m.medCode == dto.MedCode))
                    throw new Exception("Mã thuốc đã tồn tại!");
            }
            int newMedID = medicineDAO.AddMedicine(dto);
            logBL.LogAddMedicine(currentID, newMedID);
            return true;
        }
        public (int conHan, int hetHan) GetMedicineExpiryStats()
        {
            return medicineDAO.GetMedicineExpiryStats();
        }
        public List<MedicineViewModelDTO> GetAllMedicines()
        {
            return medicineDAO.GetAllMedicines();
        }
        public void DeleteMedicine(int id)
        {
            medicineDAO.DeleteMedicine(id);
        }
        public List<Medicine> GetMedicinesByExpiryStatus(string status)
        {
            return medicineDAO.GetMedicinesByExpiryStatus(status);
        }
        public void ReduceQuantity(int medID, int quantity)
        {
            medicineDAO.UpdateMedicineQuantity(medID, quantity);
        }
    }
}
