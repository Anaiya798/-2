using Microsoft.EntityFrameworkCore;
using Shop.Models;

namespace Shop.Database
{
    public class AppDBContent : DbContext
    {
        //соединение с БД
        /*public AppDBContent(DbContextOptions<AppDBContent> options): base(options)
        {

        }*/

        public DbSet<Reagent> Reagent { get; set; }
        public DbSet<Category> Category { get; set; }
    }
}
