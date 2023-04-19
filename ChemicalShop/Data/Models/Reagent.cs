namespace Shop.Data.Models
{
    public class Reagent
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Desc { get; set; }
        public int CategoryId  { get; set; }
        public int PurityId { get; set; }   
        public ushort Price { get; set; }   
        public string Img { get; set; } 
        public bool isFavourite { get; set; }   
        public bool Available { get; set; } 
        public virtual Category Category { get; set; }
        public virtual Purity Purity { get; set; }
    }
}
