using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nib.TechChallenge.BillThomas
{
    public class Product
    {
        public int ProductId { get; set; }
        public string Description { get; set; }
        public int QuantityOnHand { get; set; }
        public int ReorderThreshold { get; set; }
        public int ReorderAmount { get; set; }
        public int DeliveryLeadTime { get; set; }

        public Product() {  }

        /// <summary>
        /// initialise a product object with passed data
        /// </summary>
        /// <param name="pId"></param>
        /// <param name="pDesc"></param>
        /// <param name="qty"></param>
        /// <param name="reorderT"></param>
        /// <param name="reorderA"></param>
        /// <param name="dLeadtime"></param>
        public Product(int pId, string pDesc, int qty, int reorderT, int reorderA, int dLeadtime)
        {
            ProductId = pId;
            Description = pDesc;
            QuantityOnHand = qty;
            ReorderThreshold = reorderT;
            ReorderAmount = reorderA;
            DeliveryLeadTime = dLeadtime;
        }

        public Product SelectByProductId(int pId, List<Product> pList)
        {
            Product selectedProduct = pList.First(p => p.ProductId == pId);
            return selectedProduct; 
        }

        //For further extension: other product specific methods here
    }
}
