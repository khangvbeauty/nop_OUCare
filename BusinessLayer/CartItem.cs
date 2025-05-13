using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer;

namespace BusinessLayer
{
    public class CartItem
    {
        public Medicine Medicine { get; set; }
        public int Quantity { get; set; }
    }
}
