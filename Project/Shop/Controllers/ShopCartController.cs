using Microsoft.AspNetCore.Mvc;
using Shop.Data.Abstractions;
using Shop.Models;
using Shop.ViewModels;

namespace Shop.Controllers
{
    public class ShopCartController : Controller
    {
        ShopCartController(AllReagents reagentsRep, ShopCart shopCart){

        }
        //возвращает представление корзины покупателя в виде html-страницы
        ShopCartViewModel obj = new ShopCartViewModel();
        return View(obj);
    }
}
