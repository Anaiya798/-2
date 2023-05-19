using System.Data.Entity;
using Shop.Data.Models;

namespace ChemicalShopTests.DbTests
{
        class MockDbContent : DbContext
        {
            public MockDbContent()
                : base("MockDbConnection")
            { }

            public DbSet<Category> Category { get; set; }
            public DbSet<Reagent> Reagent { get; set; }
        }
    
}
