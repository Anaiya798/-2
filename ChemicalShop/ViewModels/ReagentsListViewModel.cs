using Shop.Data.Models;
using System.Collections.Generic;

namespace ChemicalShop.ViewModels
{
	public class ReagentsListViewModel
	{
		public IEnumerable<Reagent> AllReagents { get; set; }
		public string CurrCategory { get; set; }	
	}
}
