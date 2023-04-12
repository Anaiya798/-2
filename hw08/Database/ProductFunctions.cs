using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace dbfirst
{
    public static class ProductFunctions
    {
        public static void AddProduct(Product product)
        {
            using (var db = new OrdersEntities())
            {
                int productId = GetProductId(product.Name, product.Price);

                if (productId != 0)
                {
                    Console.WriteLine("Product already exists");
                }
                else
                {
                    db.Product.Add(product);
                    db.SaveChanges();
                    Console.WriteLine("AddProduct successful");
                }

            }
        }

        public static int GetProductId(string name, decimal price)
        {
            using (var db = new OrdersEntities())
            {
                return db.Database
                      .SqlQuery<int>("Select Id from Product where Name=@name and Price=@price", new SqlParameter("@name", name), new SqlParameter("@price", price))
                      .FirstOrDefault();
            }

        }

        public static void DeleteProduct(Product product)
        {
            using (var db = new OrdersEntities())
            {
                using (var transaction = db.Database.BeginTransaction())
                {
                    try
                    {
                        db.Database.ExecuteSqlCommand("Delete from OrderItem where ProductId=@id", new SqlParameter("@id", product.Id));
                        db.Database.ExecuteSqlCommand("Delete from Product where Id=@id", new SqlParameter("@id", product.Id));
                        db.SaveChanges();

                        transaction.Commit();
                        Console.WriteLine("Delete Product successfull");
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
