<<<<<<< HEAD
﻿using Microsoft.AspNetCore.Mvc;
using Shop.Data.Abstractions;
using Shop.Data.Models;
using Shop.Models;
using Shop.OrderProcessing;

namespace Shop.Controllers
{
    public class OrderController : Controller
    {
        private readonly AllOrders _allOrders;
        private readonly ShopCart _shopCart;
        OrderController(AllOrders orders, ShopCart shopCart)
        {
            _allOrders = orders;
            _shopCart = shopCart;   
        }
        //возвращает представление страницы  оформления заказа в виде html
         
        public IActionResult Checkout()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Checkout(Order order)
        {
            _allOrders.createOrder(order);
            //...
            IPaymentReport paymentReport;

            switch (billFormat)
            {
                case "xlsx":
                    paymentReport = new XlsxReport();
                    break;
                default:
                    paymentReport = new PdfReport();
                    break;

                    paymentReport.SaveReport(order);
            }
            //...
            return View(order);
        }
       
    }
}
=======
﻿using Microsoft.AspNetCore.Mvc;
using Shop.Data.Abstractions;
using Shop.Data.Models;
using Shop.Models;
using Shop.OrderProcessing;

namespace Shop.Controllers
{
    public class OrderController : Controller
    {
        private readonly AllOrders _allOrders;
        private readonly ShopCart _shopCart;
        OrderController(AllOrders orders, ShopCart shopCart)
        {
            _allOrders = orders;
            _shopCart = shopCart;   
        }
        //возвращает представление страницы  оформления заказа в виде html
         
        public IActionResult Checkout()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Checkout(Order order)
        {
            _allOrders.createOrder(order);
            //...
            IPaymentReport paymentReport;

            switch (billFormat)
            {
                case "xlsx":
                    paymentReport = new XlsxReport();
                    break;
                default:
                    paymentReport = new PdfReport();
                    break;

                    paymentReport.SaveReport(order);
            }
            //...
            return View(order);
        }
       
    }
}
>>>>>>> 8b6b47e3c89a8b35f0c2c026b35485af92703192
