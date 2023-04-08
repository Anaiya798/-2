using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Data.SqlClient;

namespace EF
{
    [Table("Category")]
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public int NumberOfReagents { get; set; }   
    }

    public static class CategoryFunctions
    {
        public static void AddCategory(Category category)
        {
            using (WorkingContext db = new WorkingContext())
            {
                db.Categories.Add(category);
                db.SaveChanges();
                Console.WriteLine("AddCategory successful");
            }
            
        }

        public static void AddCategories(List<Category> categories)
        {
            using (WorkingContext db = new WorkingContext())
            {
                db.Categories.AddRange(categories);
                db.SaveChanges();
                Console.WriteLine("AddCategories successful");
            }

        }

        public static void DeleteCategory(int categoryID)
        {
            using (WorkingContext db = new WorkingContext())
            {
                var numberOfReagents = db.Database
                .SqlQuery<int>("Select NumberOfReagents from Category where Id=@id", new SqlParameter("@id", categoryID))
                .FirstOrDefault();
                
                if (numberOfReagents != 0)
                {
                    Console.WriteLine("Cannot delete category: {0} reagents of this type", numberOfReagents);
                }
                else
                {
                    using (var transaction = db.Database.BeginTransaction())
                    {
                        try
                        {
                            db.Database.ExecuteSqlCommand("Delete from Producer_Category where CategoryID=@id", new SqlParameter("@id", categoryID));
                            db.Database.ExecuteSqlCommand("Delete from Category where Id=@id", new SqlParameter("@id", categoryID));
                            db.SaveChanges();

                            transaction.Commit();
                            Console.WriteLine("DeleteCategory successful");

                        }
                        catch (Exception ex)
                        {
                            transaction.Rollback();
                        }
                    }
                   
                }
                
            }

        }
    }
}
