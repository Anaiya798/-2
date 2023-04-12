using System;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Xml.Linq;

namespace dbfirst
{
    public static class OrderFunctions
    {
        public static void AddOrder(Product product)
        {
            using (var db = new OrdersEntities())
            {
                using (var transaction = db.Database.BeginTransaction())
                {
                    try
                    {
                        db.ClientOrder.Add(new ClientOrder{ OrderDate = DateTime.Now });
                        db.SaveChanges();

                        int orderId = db.Database
                                .SqlQuery<int>("Select top 1 (Id) from ClientOrder order by Id desc")
                                .FirstOrDefault();

                        var orderItem = new OrderItem
                        {
                            OrderId = orderId,
                            ProductId = product.Id,
                            Amount = 1,
                            Price = product.Price,
                        };
                        db.OrderItem.Add(orderItem);
                        db.SaveChanges();

                        transaction.Commit();
                        Console.WriteLine("AddOrder successful");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                        transaction.Rollback();
                    }
                }
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
