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
    public class ProductTests
    {
        Random rnd = new Random();

        [Test]
        public void AddProductTest()
        {
            using (var db = new OrdersEntities())
            {
                var product = new Product { Name = "AddProductTest", Price = rnd.Next(0, int.MaxValue) };
                ProductFunctions.AddProduct(product);

                int id = ProductFunctions.GetProductId(product.Name, product.Price);
                var addedProduct = db.Product.Where(p => p.Id == id).FirstOrDefault<Product>();
                Assert.AreEqual(product.Name, addedProduct.Name);
                Assert.AreEqual(product.Price, addedProduct.Price);

                ProductFunctions.AddProduct(product);
                int newId = db.Database
                           .SqlQuery<int>("Select top 1 (Id) from Product order by Id desc")
                           .FirstOrDefault();
                Assert.AreEqual(id, newId);

            }

        }
        [Test]
        public void GetProductIdTest()
        {
            using (var db = new OrdersEntities())
            {
                var product = new Product { Name = "GetProductIdTest", Price = rnd.Next(0, int.MaxValue) };
                ProductFunctions.AddProduct(product);
                int lastId = db.Database
                                .SqlQuery<int>("Select top 1 (Id) from Product order by Id desc")
                                .FirstOrDefault();
                int productId = ProductFunctions.GetProductId(product.Name, product.Price);
                Assert.AreEqual(lastId, productId);
            }
        }

        [Test]
        public void DeleteProductTest()
        {
            using (var db = new OrdersEntities())
            {
                var product = new Product { Name = "DeleteProductTest", Price = rnd.Next(0, int.MaxValue) };
                ProductFunctions.AddProduct(product);
                int productId = ProductFunctions.GetProductId(product.Name, product.Price);

                var order = new ClientOrder { OrderDate = DateTime.Now };
                db.ClientOrder.Add(order);
                db.SaveChanges();
                int orderId = db.Database
                                .SqlQuery<int>("Select top 1 (Id) from ClientOrder order by Id desc")
                                .FirstOrDefault();
                Console.WriteLine($"OrderId: {orderId}");

                var orderItem = new OrderItem
                {
                    OrderId = orderId,
                    ProductId = productId,
                    Amount = 1,
                    Price = product.Price,
                    Total = product.Price
                };
                db.OrderItem.Add(orderItem);
                db.SaveChanges();

                ProductFunctions.DeleteProduct(product);
                var deletedProduct = db.Product.Where(p => p.Id == productId).FirstOrDefault<Product>();
                var deletedOrderItem = db.OrderItem.Where(oi => oi.ProductId == productId).FirstOrDefault<OrderItem>();

                Assert.IsNull(deletedOrderItem);
                Assert.IsNull(deletedProduct);
            }
        }
    }
}