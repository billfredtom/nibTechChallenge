using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using nib.TechChallenge.BillThomas;

namespace nib.TechChallenge.BillThomas.tests
{
    [TestClass]
    public class ProductTests
    {
        [TestMethod]
        public void SelectExistingProductById()
        {
            //
            List<Product> pList = new List<Product>();
           
            for(int i = 1; i < 4; i++)
            {
                Product pNew = new Product();
                pNew.ProductId = i;
                pNew.Description = "description " + i;
                pNew.DeliveryLeadTime = 8;
                pNew.QuantityOnHand = 8;
                pNew.ReorderThreshold = 8;
                pNew.ReorderAmount = 8;

                pList.Add(pNew);
            }

            Product pSelectTest = new Product();
            pSelectTest.SelectByProductId(2, pList); 
        }
    }
}
