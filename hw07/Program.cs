using System;
using System.Collections.Generic;
using System.Data.Entity;

namespace EF
{
    
    public class WorkingContext : DbContext
    {
        public WorkingContext(): base("ChemStat")
        { }

        public DbSet<Reagent> Reagents { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Producer> Producers { get; set; }
        public DbSet<Producer_Category> ProducerCategory { get; set; }
        public DbSet<Expertise> Expertises { get; set; }


    }
    class Program
    {
        public static void Main(string[] args)
        {
            Category category1 = new Category { Name = "Inorganic", NumberOfReagents = 0 };
            CategoryFunctions.DeleteCategory(1);
           
            //CategoryFunctions.AddCategory(category1);
            /*using (WorkingContext db = new WorkingContext())
            {
                // создаем два объекта User
                Category category1 = new Category { Name = "Inorganic" , NumberOfReagents = 0};
                

                // добавляем их в бд
                db.Categories.Add(category1);
                db.SaveChanges();
                Console.WriteLine("Объекты успешно сохранены");

                // получаем объекты из бд и выводим на консоль
                var categories = db.Categories;
                Console.WriteLine("Список объектов:");
                foreach (Category u in categories)
                {
                    Console.WriteLine("{0}:{1}", u.Id, u.Name);
                }
            }*/
            Console.Read();
        }
    }
}