using Microsoft.EntityFrameworkCore;
using Shop.Data.Models;
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
        public DbSet<Order> Order { get; set; }
        public DbSet<OrderDetail> OrderDetail { get; set; }

    }
}
