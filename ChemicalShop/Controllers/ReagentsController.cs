using ChemicalShop.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Shop.Data.Interfaces;

namespace ChemicalShop.Controllers
{
    public class ReagentsController : Controller
    {
        private readonly IAllReagents _allReagents;
        private readonly IReagentsCategory _allCategories;

        public ReagentsController(IAllReagents allReagents, IReagentsCategory allCategories)
        {
            _allReagents = allReagents;
            _allCategories = allCategories;
        }
        public IActionResult ReagentsList()
        {
            ViewBag.Title = "REAXON";
            var obj = new ReagentsListViewModel();
            obj.AllReagents = _allReagents.Reagents;
           
            //var reagents = _allReagents.Reagents;
            return View(obj);
        }
    }
}
