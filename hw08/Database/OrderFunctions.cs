using System;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Xml.Linq;

namespace dbfirst
{
    public static class OrderFunctions
    {
        public static void AddOrder()
        {
            using (var db = new OrdersEntities())
            {
                
                 db.ClientOrder.Add(new ClientOrder{ OrderDate = DateTime.Now });
                 db.SaveChanges();
                 Console.WriteLine("AddOrder successful");
            }
        }
        
        public static void AddOrderItem(int orderId, Product product)
        {
            using (var db = new OrdersEntities())
            {
                var orderItem = new OrderItem
                {
                    OrderId = orderId,
                    ProductId = product.Id,
                    Amount = 1,
                    Price = product.Price,
                };
                db.OrderItem.Add(orderItem);
                db.SaveChanges();
                Console.WriteLine("AddOrderItem successful");
            }
        }
        public static void IncreaseProductAmount(int orderId, int productId)
        {
            using (var db = new OrdersEntities())
            {
                db.Database.ExecuteSqlCommand("Update OrderItem set Amount=Amount+1 where OrderId=@orderId and ProductId=@productId",
                   new SqlParameter("@orderId", orderId), new SqlParameter("@productId", productId));
                db.SaveChanges();
                Console.WriteLine("IncreaseProductAmount successful");
            }
        }

        public static void DecreaseProductAmount(int orderId, int productId)
        {
            using (var db = new OrdersEntities())
            {
                db.Database.ExecuteSqlCommand("Update OrderItem set Amount=Amount-1 where OrderId=@orderId and ProductId=@productId",
                   new SqlParameter("@orderId", orderId), new SqlParameter("@productId", productId));
                db.SaveChanges();
                Console.WriteLine("DecreaseProductAmount successful");
            }
        }
        public static void DeleteOrderItem(int orderId, int productId)
        {
            using (var db = new OrdersEntities())
            {

                db.Database.ExecuteSqlCommand("Delete from OrderItem where OrderId=@orderId and ProductId=@productId", 
                    new SqlParameter("@orderId", orderId), new SqlParameter("@productId", productId));
                db.SaveChanges();
                Console.WriteLine("DeleteOrderItem successful");
            }
        }
        public static void DeleteOrder(int orderId)
        {
            using (var db = new OrdersEntities())
            {
                using (var transaction = db.Database.BeginTransaction())
                {
                    try
                    {
                        db.Database.ExecuteSqlCommand("Delete from OrderItem where OrderId=@id", new SqlParameter("@id", orderId));
                        db.Database.ExecuteSqlCommand("Delete from ClientOrder where Id=@id", new SqlParameter("@id", orderId));
                        db.SaveChanges();

                        transaction.Commit();
                        Console.WriteLine("DeleteOrder successful");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                        transaction.Rollback();
                    }
                }
            }
        }
    }
}
