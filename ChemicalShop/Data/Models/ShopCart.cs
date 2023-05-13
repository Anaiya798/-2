using ChemicalShop.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Shop.Data.Models
{
    public class ShopCart
    {
        private readonly AppDbContent _appDbContent;

        public ShopCart(AppDbContent appDbContent)
        {
            _appDbContent = appDbContent;
        }
        public string ShopCartId { get; set; }
        public List<ShopCartItem> ListShopItems { get; set; }
        
        public static ShopCart GetCart(IServiceProvider services)
        {
            ISession session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;
            var context = services.GetService<AppDbContent>();
            string shopCartId = session.GetString("CartId") ?? Guid.NewGuid().ToString();

            session.SetString("CartId", shopCartId);

            return new ShopCart(context) { ShopCartId = shopCartId };
        }

        public void AddToCart(Reagent reagent)
        {
            _appDbContent.ShopCartItem.Add(new ShopCartItem
            {
                ShopCartId = ShopCartId,
                ReagentItem = reagent,
                Price = reagent.Price
            });
            _appDbContent.SaveChanges();
        }

        public List<ShopCartItem> GetShopItems()
        {
            return _appDbContent.ShopCartItem.Where(item => item.ShopCartId == ShopCartId).Include(item => item.ReagentItem).ToList();
        }

    }
}
