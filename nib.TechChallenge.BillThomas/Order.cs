using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nib.TechChallenge.BillThomas
{
    public class Order
    {
        public int OrderId { get; set; }
        public string Status { get; set; }
        public DateTime DateCreated { get; set; }
        public List<OrderItem> items {get; set; }

        public Order() { }

        public Order(int oId, string oStatus, DateTime oDateCreated, List<OrderItem> oItems)
        {
            OrderId = oId;
            Status = oStatus;
            DateCreated = oDateCreated;
            items = oItems;
        }

        public string unfulfilledReport(List<Order> unfulfilledOrders)
        {
            string report = "";
         
            foreach (var uO in unfulfilledOrders)
            {
                report += uO.OrderId + ",";
            }
            if (report.Length > 0)
                report = " , \"unfulfillable\": [" + report.TrimEnd(',') + "]";

            return report;
        }
    }

}
