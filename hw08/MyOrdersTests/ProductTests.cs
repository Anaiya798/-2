using System;
using NUnit.Framework;
using EFDBFirst;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Diagnostics;
using System.Xml.Linq;

namespace MyOrdersTests
{
    [TestFixture]
    public class ProductTests
    {
        Random rnd = new Random();

        [Test]
        public void AddTest()
        {
            using (var db = new ShopOrdersEntities())
            {
                var product = new Product { Name = "AddTest", Price = rnd.Next(0, int.MaxValue) };
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
            using (var db = new ShopOrdersEntities())
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
            using (var db = new ShopOrdersEntities())
            {
                var product = new Product { Name = "DeleteTest", Price = rnd.Next(0, int.MaxValue) };
                ProductFunctions.AddProduct(product);
                int productId = ProductFunctions.GetProductId(product.Name, product.Price);

                var order = new Order { OrderDate = DateTime.Now };
                db.Order.Add(order);
                db.SaveChanges();
                int orderId = db.Database
                                .SqlQuery<int>("Select top 1 (Id) from Product order by Id desc")
                                .FirstOrDefault();

                var orderItem = new OrderItem
                {
                    OrderId = 1,
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