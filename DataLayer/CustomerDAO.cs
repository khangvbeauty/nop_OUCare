using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransferObject;

namespace DataLayer
{
    public class CustomerDAO
    {
        private OUCareDBContext db = new OUCareDBContext();

        public List<CustomerDTO> GetAll()
        {
            return db.Customers.Select(c => new CustomerDTO
            {
                ID = c.ID,
                Name = c.name,
                Phone = c.phone,
                Email = c.email,
                CreatedDate = c.createdDate
            }).ToList();
        }

        public int Add(CustomerDTO dto)
        {
            var existing = db.Customers.FirstOrDefault(c => c.phone == dto.Phone);
            if (existing != null)
                throw new Exception("Số điện thoại này đã tồn tại!");

            var customer = new Customer
            {
                ID = dto.ID,
                name = dto.Name,
                phone = dto.Phone,
                email = dto.Email,
                createdDate = dto.CreatedDate
            };
            db.Customers.Add(customer);
            db.SaveChanges();
            return customer.ID;
        }


        public void Update(CustomerDTO dto)
        {
            var customer = db.Customers.Find(dto.ID);
            if (customer != null)
            {
                customer.name = dto.Name;
                customer.phone = dto.Phone;
                customer.email = dto.Email;
                db.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            var customer = db.Customers.Find(id);
            if (customer != null)
            {
                // Xóa Notification liên quan
                var notiList = db.Notifications.Where(n => n.cusID == id);
                db.Notifications.RemoveRange(notiList);

                // Xóa Bill liên quan (và có thể là BillDetails nếu cần thiết)
                var bills = db.Bills.Where(b => b.cusID == id).ToList();
                foreach (var bill in bills)
                {
                    var billDetails = db.BillDetails.Where(d => d.billID == bill.ID);
                    db.BillDetails.RemoveRange(billDetails);

                    db.Bills.Remove(bill);
                }

                db.Customers.Remove(customer);
                db.SaveChanges();
            }
        }

        public List<CustomerDTO> Search(string keyword)
        {
            return db.Customers
                .Where(c => c.name.Contains(keyword) || c.phone.Contains(keyword))
                .Select(c => new CustomerDTO
                {
                    ID = c.ID,
                    Name = c.name,
                    Phone = c.phone,
                    Email = c.email,
                    CreatedDate = c.createdDate
                }).ToList();
        }
        public CustomerDTO GetByPhone(string phone)
        {
            return db.Customers
                     .Where(c => c.phone == phone)
                     .Select(c => new CustomerDTO
                     {
                         ID = c.ID,
                         Name = c.name,
                         Phone = c.phone,
                         Email = c.email,
                         CreatedDate = c.createdDate
                     }).FirstOrDefault();
        }
        public CustomerDTO GetByID(int id)
        {
            using (var db = new OUCareDBContext())
            {
                var c = db.Customers.Find(id);
                if (c == null) return null;

                return new CustomerDTO
                {
                    ID = c.ID,
                    Name = c.name,
                    Phone = c.phone,
                    Email = c.email,
                    CreatedDate = c.createdDate
                };
            }
        }

    }
}
