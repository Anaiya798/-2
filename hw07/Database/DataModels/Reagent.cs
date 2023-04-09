using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.SqlClient;

namespace EF
{
    [Table("Reagent")]
    public class Reagent
    {
        [Key]
        public int ID { get; set; }

        [StringLength(200)]
        [Required]
        public string Name { get; set; }
        [Required]
        public int CategoryID { get; set; }
        [Required]
        public int ProducerID { get; set; }

        public int ExpertiseID { get; set; }

    }

    public static class ReagentFunctions
    {
        public static void AddReagent(Reagent reagent)
        {
            using (WorkingContext db = new WorkingContext())
            {
                using (var transaction = db.Database.BeginTransaction())
                {
                    try
                    {
                        db.Reagents.Add(reagent);
                        Console.WriteLine("Hey");
                        db.Database.ExecuteSqlCommand("Update Category set NumberOfReagents=NumberOfReagents+1 where Id=@id",
                            new SqlParameter("@id", reagent.CategoryID));
                        db.Database.ExecuteSqlCommand("Update Producer set NumberOfReagents=NumberOfReagents+1 where Id=@id",
                            new SqlParameter("@id", reagent.ProducerID));
                        db.SaveChanges();

                        transaction.Commit();
                        Console.WriteLine("AddReagent successful");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                        transaction.Rollback();
                    }
                }

            }
        }
        public static int GetReagentId(string reagentName)
        {
            using (WorkingContext db = new WorkingContext())
            {
                return db.Database
                     .SqlQuery<int>("Select Id from Reagent where Name=@name", new SqlParameter("@name", reagentName))
                     .FirstOrDefault();
            }
        }

        public static void DeleteReagent(int reagentId)
        {
            using (WorkingContext db = new WorkingContext())
            {
                using (var transaction = db.Database.BeginTransaction())
                {
                    try
                    {
                        int categoryId = db.Database
                                           .SqlQuery<int>("Select CategoryID from Reagent where Id=@id", new SqlParameter("@id", reagentId))
                                           .FirstOrDefault();
                        int producerId = db.Database
                                          .SqlQuery<int>("Select ProducerID from Reagent where Id=@id", new SqlParameter("@id", reagentId))
                                          .FirstOrDefault();
                        db.Database.ExecuteSqlCommand("Update Category set NumberOfReagents=NumberOfReagents-1 where Id=@id",
                            new SqlParameter("@id", categoryId));
                        db.Database.ExecuteSqlCommand("Update Producer set NumberOfReagents=NumberOfReagents-1 where Id=@id",
                            new SqlParameter("@id", producerId));
                        db.Database.ExecuteSqlCommand("Delete from Reagent where Id=@id", new SqlParameter("@id", reagentId));

                        db.SaveChanges();

                        transaction.Commit();
                        Console.WriteLine("DeleteReagent successful");

                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                        transaction.Rollback();
                    }
                }
            }
        }

        public static void GetReagentsInCategory(int categoryID)
        {
            using (WorkingContext db = new WorkingContext())
            {
                SqlParameter param = new SqlParameter("@categoryId", categoryID);
                var reagents = db.Database.SqlQuery<Reagent>("GetReagentsInCategory @categoryId", param);
                foreach (Reagent reagent in reagents)
                {
                    Console.WriteLine(reagent.Name);
                }
            }
        }

    }
}
