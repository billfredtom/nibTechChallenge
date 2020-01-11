using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nib.TechChallenge.BillThomas
{
    /// <summary>
    /// assist with JSON deserialisation
    /// </summary>
    class Data
    {
        public List<Product> Products { get; set; }
        public List<Order> Orders { get; set; }
    }
}
