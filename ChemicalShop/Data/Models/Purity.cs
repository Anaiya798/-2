using System.Collections.Generic;

namespace Shop.Data.Models
{
    public class Purity
    {
        public int Id { get; set; }
        public string PurityDegree { get; set; }   
        public List<Reagent> Reagents { get; set; } 
    }
}
