using DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransferObject;

namespace BusinessLayer
{
    public class CustomerBUS
    {
        private CustomerDAO dao = new CustomerDAO();

        public List<CustomerDTO> LayDanhSach() => dao.GetAll();

        public void Them(CustomerDTO dto) => dao.Add(dto);

        public void CapNhat(CustomerDTO dto) => dao.Update(dto);

        public void Xoa(int id) => dao.Delete(id);

        public List<CustomerDTO> TimKiem(string tuKhoa) => dao.Search(tuKhoa);
        public CustomerDTO GetByPhone(string phone)
        {
            return dao.GetByPhone(phone);
        }
        public CustomerDTO GetByID(int id)
        {
            return dao.GetByID(id);
        }
    }
}
