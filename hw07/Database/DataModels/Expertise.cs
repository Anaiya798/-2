using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.SqlClient;

namespace EF
{
    [Table("Expertise")]
    public class Expertise
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int ReagentId { get; set; }
        [StringLength(20)]
        [Required]
        public string Toxicity { get; set; }
        [StringLength(20)]
        [Required]
        public string WaterSolubility { get; set; }
    }

    public static class ExpertiseFunctions
    {
        public static void AddExpertise(Expertise expertise)
        {
            using (WorkingContext db = new WorkingContext())
            {
                int existingExpertise = GetExpertiseId(expertise.ReagentId);
                if (existingExpertise != 0)
                {
                    Console.WriteLine("Cannot add expertise: another expertise exists");
                }
                else
                {
                    using (var transaction = db.Database.BeginTransaction())
                    {
                        try
                        {
                            db.Expertises.Add(expertise);
                            db.SaveChanges();
                            int expertiseId = GetExpertiseId(expertise.ReagentId);
                            Console.WriteLine(expertiseId);
                            db.Database.ExecuteSqlCommand("Update Reagent set ExpertiseId=@expertiseId where Id=@reagentId",
                                new SqlParameter("@reagentId", expertise.ReagentId), new SqlParameter("@expertiseId", expertiseId));
                            db.SaveChanges();

                            transaction.Commit();
                            Console.WriteLine("AddExpertise successful");
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

        public static int GetExpertiseId(int reagentId)
        {
            using (WorkingContext db = new WorkingContext())
            {
                return db.Database
                     .SqlQuery<int>("Select Id from Expertise where ReagentId=@id", new SqlParameter("@id", reagentId))
                     .FirstOrDefault();
            }

        }

        public static void DeleteExpertise(int expertiseId)
        {
            using (WorkingContext db = new WorkingContext())
            {
                using (var transaction = db.Database.BeginTransaction())
                {
                    try
                    {
                        int reagentId = db.Database
                                          .SqlQuery<int>("Select ReagentId from Expertise where Id=@id", new SqlParameter("@id", expertiseId))
                                           .FirstOrDefault();
                        db.Database.ExecuteSqlCommand("Update Reagent set ExpertiseId=0 where Id=@reagentId",
                               new SqlParameter("@reagentId", reagentId));
                        db.Database.ExecuteSqlCommand("Delete from Expertise where Id=@id",
                               new SqlParameter("@id", expertiseId));
                        db.SaveChanges();

                        transaction.Commit();
                        Console.WriteLine("DeleteExpertise successful");
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
