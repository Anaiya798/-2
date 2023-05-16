using ChemicalShop.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Shop.Data.Interfaces;
using Shop.Data.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

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

        [Route("Reagents/ReagentsList")]
        [Route("Reagents/ReagentsList/{category}")]
        public ViewResult ReagentsList(string category)
        {
            IEnumerable<Reagent> reagents;
            string currCategory = "";
            
            switch(category)
            {
                case "inorganic":
                    reagents = _allReagents.Reagents.Where(reagent => reagent.CategoryId == 1).OrderBy(reagent => reagent.Id);
                    break;
                case "organic":
                    reagents = _allReagents.Reagents.Where(reagent => reagent.CategoryId == 2).OrderBy(reagent => reagent.Id);
                    break;
                case "indicators":
                    reagents = _allReagents.Reagents.Where(reagent => reagent.CategoryId == 3).OrderBy(reagent => reagent.Id);
                    break;
                case "solvents":
                    reagents = _allReagents.Reagents.Where(reagent => reagent.CategoryId == 4).OrderBy(reagent => reagent.Id);
                    break;
                case "bac":
                    reagents = _allReagents.Reagents.Where(reagent => reagent.CategoryId == 5).OrderBy(reagent => reagent.Id);
                    break;
                default:
                    reagents = _allReagents.Reagents.OrderBy(reagent => reagent.Id);
                    break;
            }
            currCategory = category;

            ViewBag.Title = "REAXON";
            var objReagent = new ReagentsListViewModel()
            {
                AllReagents = reagents,
                CurrCategory = currCategory
            };
          
            return View(objReagent);
        }
    }
}
