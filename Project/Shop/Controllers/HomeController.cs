using Microsoft.AspNetCore.Mvc;
using Shop.Data.Abstractions;
using Shop.ViewModels;

namespace Shop.Controllers
{
    public class HomeController : Controller
    {
        HomeController(AllReagents reagentsRep){
        }
        //возвращает представление главной страницы в виде html
        HomeViewModel obj = new HomeViewModel();
        return View(obj);
    }
}
