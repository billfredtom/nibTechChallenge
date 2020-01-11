using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nib.TechChallenge.BillThomas
{
    class OrderItem
    {
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal CostPerItem { get; set; }
        

        public OrderItem() { }
        
    }
}
