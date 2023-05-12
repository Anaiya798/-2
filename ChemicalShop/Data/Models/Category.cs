using System.Collections.Generic;

namespace Shop.Data.Models
{
    public class Category
    {
        public int Id { get; set; } 
        public string Name { get; set; }
        public List<Reagent> Reagents { get; set; }
    }
}
