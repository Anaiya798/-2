using Shop.Data.Models;
using System.Collections.Generic;

namespace ChemicalShop.ViewModels
{
    public class ShopCartViewModel
    {
        public ShopCart UserShopCart { get; set; }
        public List<Reagent> ShopCartReagents { get; set; }
    }
}
