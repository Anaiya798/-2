using Microsoft.AspNetCore.Mvc;
using Shop.Data.Abstractions;
using Shop.ViewModels;

namespace Shop.Controllers
{
    public class ReagentsController : Controller
    {
        ReagentsController(AllReagents reagentsRep, ReagentsCategory categoryRep) {

         }
        //возвращает представление товаров магазина в виде html-страницы
        ReagentsListViewModel obj = new ReagentsListViewModel();
        return View(obj);
    }
}
