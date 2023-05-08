using Microsoft.EntityFrameworkCore;
using Shop.Data.Models;

namespace ChemicalShop.Data
{
    public class AppDBContent: DbContext
    {
        public AppDBContent(DbContextOptions<AppDBContent> options): base(options)
        {

        }
        public DbSet<Reagent> Reagent { get; set; }
        public DbSet<Category> Category { get; set; }
    }
}
