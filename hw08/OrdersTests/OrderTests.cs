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

        protected Tuple<int, Product> InsertOrder(Product product)
        {
            using (var db = new OrdersEntities())
            {
                OrderFunctions.AddOrder();
                int orderId = db.Database
                                .SqlQuery<int>("Select top 1 (Id) from ClientOrder order by Id desc")
                                .FirstOrDefault();
                int productId = ProductFunctions.GetProductId(product.Name, product.Price);
                product = db.Product.Where(p => p.Id == productId).FirstOrDefault<Product>();
                return Tuple.Create(orderId, product);
            }
        }

        protected int GetProductAmount(int orderId, int productId)
        {
            using (var db = new OrdersEntities())
            {
                return Decimal.ToInt32(db.Database
                                    .SqlQuery<decimal>("Select Amount from OrderItem where OrderId=@orderId and ProductId=@productId",
                                     new SqlParameter("@orderId", orderId), new SqlParameter("@productId", productId))
                                    .FirstOrDefault());
            }
        }
        [Test]
        public void AddOrderItemTest()
        {
            using (var db = new OrdersEntities())
            {
                var product = new Product { Name = "AddOrderItemTest", Price = rnd.Next(0, int.MaxValue) };
                ProductFunctions.AddProduct(product);

                var insertedTuple = InsertOrder(product);
                int orderId = insertedTuple.Item1;
                product = insertedTuple.Item2;
                OrderFunctions.AddOrderItem(orderId, product);

                var addedItem = db.OrderItem.Where(oi => oi.OrderId == orderId).FirstOrDefault<OrderItem>();

                Assert.AreEqual(addedItem.ProductId, product.Id);
                Assert.AreEqual(addedItem.Price, product.Price);
                Assert.AreEqual(addedItem.Amount, 1);
            }

         }
        [Test]
        public void IncreaseProductAmountTest()
        {
            using (var db = new OrdersEntities())
            {
                var product = new Product { Name = "IncreaseProductAmountTest", Price = rnd.Next(0, int.MaxValue) };
                ProductFunctions.AddProduct(product);

                var insertedTuple = InsertOrder(product);
                int orderId = insertedTuple.Item1;
                product = insertedTuple.Item2;
                OrderFunctions.AddOrderItem(orderId, product);

                int initialAmount = GetProductAmount(orderId, product.Id);
                OrderFunctions.IncreaseProductAmount(orderId, product.Id);
                int newAmount = GetProductAmount(orderId, product.Id);

                Assert.AreEqual(initialAmount + 1, newAmount);

            }
        }
        [Test]
        public void DecreaseProductAmountTest()
        {
            using (var db = new OrdersEntities())
            {
                var product = new Product { Name = "DecreaseProductAmountTest", Price = rnd.Next(0, int.MaxValue) };
                ProductFunctions.AddProduct(product);

                var insertedTuple = InsertOrder(product);
                int orderId = insertedTuple.Item1;
                product = insertedTuple.Item2;
                OrderFunctions.AddOrderItem(orderId, product);

                int initialAmount = GetProductAmount(orderId, product.Id);
                OrderFunctions.DecreaseProductAmount(orderId, product.Id);
                int newAmount = GetProductAmount(orderId, product.Id);

                Assert.AreEqual(initialAmount - 1, newAmount);

            }
        }
        [Test]
        public void DeleteOrderItemTest()
        {
            using (var db = new OrdersEntities())
            {
                var product = new Product { Name = "DeleteOrderItemTest", Price = rnd.Next(0, int.MaxValue) };
                ProductFunctions.AddProduct(product);

                var insertedTuple = InsertOrder(product);
                int orderId = insertedTuple.Item1;
                product = insertedTuple.Item2;
                OrderFunctions.AddOrderItem(orderId, product);

                OrderFunctions.DeleteOrderItem(orderId, product.Id);
                var deletedItem = db.OrderItem.Where(oi => oi.OrderId == orderId && oi.ProductId == product.Id).FirstOrDefault<OrderItem>();

                Assert.IsNull(deletedItem);
            }
        }
        [Test]
        public void DeleteOrderTest()
        {
            using (var db = new OrdersEntities())
            {
                var product1 = new Product { Name = "DeleteOrderTest", Price = rnd.Next(0, int.MaxValue) };
                var product2 = new Product { Name = "DeleteOrderTest2", Price = rnd.Next(0, int.MaxValue) };
                ProductFunctions.AddProduct(product1);
                ProductFunctions.AddProduct(product2);

                var insertedTuple1 = InsertOrder(product1);
                var insertedTuple2 = InsertOrder(product2);
                int orderId1 = insertedTuple1.Item1;
                var orderId2 = insertedTuple2.Item1;    
                product1 = insertedTuple1.Item2;
                product2 = insertedTuple2.Item2;
                OrderFunctions.AddOrderItem(orderId1, product1);
                OrderFunctions.AddOrderItem(orderId2, product2);
              
                OrderFunctions.DeleteOrder(orderId1);
                OrderFunctions.DeleteOrder(orderId2);
                var deletedOrder1 = db.ClientOrder.Where(o => o.Id == orderId1).FirstOrDefault<ClientOrder>();
                var deletedOrder2 = db.ClientOrder.Where(o => o.Id == orderId2).FirstOrDefault<ClientOrder>();
                var deletedItem1 = db.OrderItem.Where(oi => oi.OrderId == orderId1).FirstOrDefault<OrderItem>();
                var deletedItem2 = db.OrderItem.Where(oi => oi.OrderId == orderId2).FirstOrDefault<OrderItem>();

                Assert.IsNull(deletedItem1);
                Assert.IsNull(deletedItem2);
                Assert.IsNull(deletedOrder1);
                Assert.IsNull(deletedOrder2);       

            }
        }
       }  
}