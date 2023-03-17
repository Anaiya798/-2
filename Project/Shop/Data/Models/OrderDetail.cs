using System;

namespace Shop.Models
{
    public class OrderDetail
    {
        public uint Id { get; set; }
        public uint OrderId { get; set; }  
        public uint ReagentId { get; set; }
        public uint Price { get; set; }

       /* public override bool Equals(Object obj)
        {
            //сравниваем объекты типа OrderDetail
        }*/
    }
}
