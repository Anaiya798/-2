using System;

namespace Shop.Data.Models
{
    public class OrderDetail
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int ReagentId { get; set; }
        public ushort Price { get; set; }   
        public virtual Reagent RelatedReagent { get; set; }  
        public virtual Order RelatedOrder { get; set; } 

    }
}
