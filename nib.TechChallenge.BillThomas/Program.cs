using Nancy;
using Nancy.Extensions;
using Nancy.Hosting.Self;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace nib.TechChallenge.BillThomas
{
    class Program
    {
        static void Main(string[] args)
        {
            var ui = new Task(( ) => 
            {
                //allow use of localhost to avoid DNS setup. 
                HostConfiguration hostConfigs = new HostConfiguration()
                {
                    UrlReservations = new UrlReservations() { CreateAutomatically = true }
                };

                var host = new NancyHost(hostConfigs, new Uri("http://localhost:2020"));
                host.Start();
            });

            ui.Start();

            System.Diagnostics.Process.Start("http://localhost:2020/content/home.html");

            Console.WriteLine("NOMSS Self hosting running. Press any key to exit.");
            Console.ReadLine();
        }
    }

    
    public class Api : NancyModule
    {
        public Api() : base("/api/v1")
        {
            Post("/warehouse/fulfilment", parameters =>          
            {
                // Assumptions
                // - data from JSON is of correct type for all fields. 

                try
                {
                    //determine post body contents
                    var body = Nancy.IO.RequestStream.FromStream(Request.Body).AsString();
                    JObject oIds = JObject.Parse(body);
                    JArray ordersToProcess = (JArray)oIds["orderIds"];
                    List<int> ordersQueried = ordersToProcess.Select(c => (int)c).ToList();

                    //setup some stats for info/debug purposes in response. 
                    int totalOrderCount = ordersQueried.Count;
                    int fulfilledOrderCount = 0;
                    int unfulfilledOrderCount = 0;
                    List<Order> unfillableOrders = new List<Order>();

                    //access data
                    string json;
                    using (StreamReader r = new StreamReader("content/data.json"))
                    {
                        json = r.ReadToEnd();
                    }
                    var jsData = JsonConvert.DeserializeObject<Data>(json);
                  
                    //fulfillment logic
                    foreach(var o in jsData.Orders)
                    {
                        if(ordersQueried.Contains(o.OrderId))
                        {
                            //process order. Compare order quantity against product quantityonhand
                            List<OrderItem> orderlines = o.items;

                            bool fulfilled = false; //reset for order

                            foreach(var item in orderlines)
                            {
                                Product p = new Product();
                                p = p.SelectByProductId(item.ProductId, jsData.Products);

                                if ((p.QuantityOnHand >= item.Quantity))
                                {
                                    fulfilled = true;
                                    //place logic to reduce quantityOnHand here (does not save data for persistence)
                                }
                                else
                                {
                                    //partial order fulfillment out of scope. if qty not met for any lines, order is unfulfilled. 
                                    fulfilled = false;
                                    unfillableOrders.Add(o);
                                    break;  
                                }
                            }

                            if (fulfilled)
                                fulfilledOrderCount++;           
                        }  
                    }

                    //report on unfulfilled orders
                    unfulfilledOrderCount = unfillableOrders.Count;
                    Order oUnfulfilled = new Order();
                    string unfillableOrderReport = oUnfulfilled.unfulfilledReport(unfillableOrders);

                    return "{ \"orderCount\": " + totalOrderCount + ", \"fulfilledOrderCount\": " + fulfilledOrderCount + ", \"attemptedOrders\": " + ordersToProcess + ", \"unfulfilledOrderCount\": " + unfulfilledOrderCount + unfillableOrderReport + " }";
                }
                catch (Exception ex)
                {
                    return "{ \"error\": \"" + ex.ToString() + "\" }";
                }
            });
        }

    }

}
