using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.SqlClient;


namespace EF
{
    [Table("Producer")]
    public class Producer
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }

        public int NumberOfReagents { get; set; }

    }

    public static class ProducerFunctions
    {
        public static void AddProducer(Producer producer, List<int> categoryIds)
        {
            using (WorkingContext db = new WorkingContext())
            {
                using (var transaction = db.Database.BeginTransaction())
                {
                    try
                    {
                        producer.NumberOfReagents = 0;
                        db.Producers.Add(producer);
                        db.SaveChanges();
                        int producerId = GetProducerId(producer.Name);

                        foreach (int categoryId in categoryIds)
                        {
                            var producer_category = new Producer_Category { ProducerId = producerId, CategoryId = categoryId };
                            db.ProducerCategory.Add(producer_category);
                        }
                        db.SaveChanges();

                        transaction.Commit();
                        Console.WriteLine("AddProducer successfull");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                        transaction.Rollback();
                    }
                }
            }
        }

        public static int GetProducerId(string producerName)
        {
            using (WorkingContext db = new WorkingContext())
            {
                return db.Database
                     .SqlQuery<int>("Select Id from Producer where Name=@name", new SqlParameter("@name", producerName))
                     .FirstOrDefault();
            }

        }

        public static void DeleteProducer(int producerId)
        {
            using (WorkingContext db = new WorkingContext())
            {
                var numberOfReagents = db.Database
                .SqlQuery<int>("Select NumberOfReagents from Producer where Id=@id", new SqlParameter("@id", producerId))
                .FirstOrDefault();

                if (numberOfReagents != 0)
                {
                    Console.WriteLine("Cannot delete producer: {0} reagents from it", numberOfReagents);
                }
                else
                {
                    using (var transaction = db.Database.BeginTransaction())
                    {
                        try
                        {
                            db.Database.ExecuteSqlCommand("Delete from Producer_Category where ProducerId=@id", new SqlParameter("@id", producerId));
                            db.Database.ExecuteSqlCommand("Delete from Producer where Id=@id", new SqlParameter("@id", producerId));
                            db.SaveChanges();

                            transaction.Commit();
                            Console.WriteLine("DeleteProducer successful");

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
}
