using System.Data.Entity;

namespace EF
{
    public class WorkingContext: DbContext
    {
        public WorkingContext() : base("ChemStat")
        { }
        public DbSet<Reagent> Reagents { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Producer> Producers { get; set; }
        public DbSet<Producer_Category> ProducerCategory { get; set; }
        public DbSet<Expertise> Expertises { get; set; }
    }
}
