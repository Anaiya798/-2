using System;
using NUnit.Framework;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Diagnostics;
using System.Xml.Linq;

namespace dbfirst
{
    [TestFixture]
    public class OrderTests
    {
        Random rnd = new Random();

        [Test]
        public void AddOrderTest()
        {
            using (var db = new OrdersEntities())
            {
                var product = new Product { Name = "AddOrderTest", Price = rnd.Next(0, int.MaxValue) };
                ProductFunctions.AddProduct(product);
                OrderFunctions.AddOrder(product);

                int orderId = db.Database
                                .SqlQuery<int>("Select top 1 (Id) from ClientOrder order by Id desc")
                                .FirstOrDefault();
                int productId = ProductFunctions.GetProductId(product.Name, product.Price);

                var addedItem = db.OrderItem.Where(oi => oi.OrderId == orderId).FirstOrDefault<OrderItem>();

                Assert.AreEqual(addedItem.ProductId, productId);
                Assert.AreEqual(addedItem.Price, product.Price);
                Assert.AreEqual(addedItem.Amount, 1);
            }

         }
        [Test]
        public void DeleteOrderTest()
        {
            using (var db = new OrdersEntities())
            {
                var product = new Product { Name = "DeleteOrderTest", Price = rnd.Next(0, int.MaxValue) };
                ProductFunctions.AddProduct(product);
                OrderFunctions.AddOrder(product);
              

                int orderId = db.Database
                                .SqlQuery<int>("Select top 1 (Id) from ClientOrder order by Id desc")
                                .FirstOrDefault();

                OrderFunctions.DeleteOrder(orderId);
                var deletedOrder = db.ClientOrder.Where(o => o.Id == orderId).FirstOrDefault<ClientOrder>();
                var deletedItem = db.OrderItem.Where(oi => oi.OrderId == orderId).FirstOrDefault<OrderItem>();

                Assert.IsNull(deletedOrder);
                Assert.IsNull(deletedItem);



            }
        }
       }  
}