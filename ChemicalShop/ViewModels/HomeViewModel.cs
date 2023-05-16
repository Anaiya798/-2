using Shop.Data.Models;
using System.Collections.Generic;

namespace ChemicalShop.ViewModels
{
    public class HomeViewModel
    {
        public IEnumerable<Reagent> FavReagents {get; set;}
    }
}
