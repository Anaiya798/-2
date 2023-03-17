using System.Collections.Generic;

namespace Shop.Models
{
    public class ShopCart
    {
        public uint Id { get; set; }
        public List<ShopCartItem> Items { get; set; }
    }
}
