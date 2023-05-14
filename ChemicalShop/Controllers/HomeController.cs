using ChemicalShop.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Shop.Data.Interfaces;
using Shop.Data.Models;

namespace ChemicalShop.Controllers
{
    public class HomeController: Controller
    {
        private readonly IAllReagents _reagentsRepository;

        public HomeController(IAllReagents reagentsRepository, ShopCart shopCart)
        {
            _reagentsRepository = reagentsRepository;
            
        }
        
        public ViewResult Index()
        {
            var homeReagents = new HomeViewModel
            {
                FavReagents = _reagentsRepository.FavReagents
            };
            return View(homeReagents);
        }
    }
}
