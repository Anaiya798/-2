using Microsoft.AspNetCore.Mvc;
using Shop.Data.Abstractions;
using Shop.Data.Models;
using Shop.Models;

namespace Shop.Controllers
{
    public class OrderController : Controller
    {
        OrderController(AllOrders orders, ShopCart shopCart)
        {
        }
        //возвращает представление страницы  оформления заказа в виде html
         
        public IActionResult Checkout()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Checkout(Order order)
        {
            return View(order);
        }
       
    }
}
