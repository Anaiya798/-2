using System;
using System.Linq;

namespace dbfirst
{
    public class Program
    {
        static void Main(string[] args)
        {
            using (var db = new OrdersEntities())
            {


                var order = new ClientOrder { OrderDate = DateTime.Now };
                db.ClientOrder.Add(order);
                var product = new Product { Name = "Milk", Price = 25 };
                db.Product.Add(product);
                db.SaveChanges();

                 var orderItem = new OrderItem
                 {
                     OrderId = 1,
                     ProductId = 1,
                     Amount = 1,
                     Price = 25

                 };
                 db.OrderItem.Add(orderItem);    
                 db.SaveChanges();
               // Console.WriteLine(OrderFunctions.GetOrderId(order.OrderDate:d));
                Console.WriteLine("Successful");


            }
            Console.Read();

        }

    }
}
