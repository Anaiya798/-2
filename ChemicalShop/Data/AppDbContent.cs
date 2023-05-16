using Microsoft.EntityFrameworkCore;
using Shop.Data.Models;

namespace ChemicalShop.Data
{
    public class AppDbContent: DbContext
    {
        public AppDbContent(DbContextOptions<AppDbContent> options): base(options)
        {

        }
        public DbSet<Reagent> Reagent { get; set; }
        public DbSet<Category> Category { get; set; } 
        public DbSet<Order> Order { get; set; }
        public DbSet<OrderDetail> OrderDetail { get; set; }
        public DbSet<ShopCartItem> ShopCartItem { get; set; }
    }
}
