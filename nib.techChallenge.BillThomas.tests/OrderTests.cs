using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using nib.TechChallenge.BillThomas;

namespace nib.TechChallenge.BillThomas.tests
{
    [TestClass]
    public class OrderTests
    {
        [TestMethod]
        public void UnfulfilledOrders()
        {
            List<Order> oList = new List<Order>();

            for (int i = 1; i < 4; i++)
            {
                Order oNew = new Order();
                oNew.OrderId = i;
                oNew.Status = "pending";
                oNew.DateCreated = System.DateTime.Now;

                oList.Add(oNew);
            }

            Order orderReport = new Order();
            string x = orderReport.unforfilledReport(oList);

     
        }
    }
}
