using Shop.Data.Models;

namespace Shop.Data.Models
{
    public class ShopCartItem
    {
        public int Id { get; set; }
        public int ReagentItemId { get; set; }
        public ushort Price { get; set; }
        public string ShopCartId { get; set; }  
    }
}
