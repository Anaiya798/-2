using ChemicalShop.Data.Repository;
using ChemicalShop.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Shop.Data.Interfaces;
using Shop.Data.Models;
using System.Linq;

namespace ChemicalShop.Controllers
{
    public class ShopCartController: Controller
    {
        private readonly IAllReagents _reagentsRepository;
        private readonly ShopCart _shopCart;

        public ShopCartController(IAllReagents reagentsRepository, ShopCart shopCart)
        {
            _reagentsRepository = reagentsRepository;
            _shopCart = shopCart;
        }

        public ViewResult Index()
        {
            ViewBag.Title = "REAXON";
            var items = _shopCart.GetShopItems();
            _shopCart.ListShopItems = items;

            ShopCartViewModel obj = new ShopCartViewModel
            {
                UserShopCart = _shopCart,
            };

            return View(obj);
        }

        public RedirectToActionResult AddToShopCart(int id)
        {
            var item = _reagentsRepository.Reagents.FirstOrDefault(reagent => reagent.Id == id);
            if (item != null)
            {
                _shopCart.AddToCart(item);
            }
            return RedirectToAction("Index");
        }
    }
}
