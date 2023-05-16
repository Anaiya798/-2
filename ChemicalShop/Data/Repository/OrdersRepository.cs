using Shop.Data.Interfaces;
using Shop.Data.Models;
using System;

namespace ChemicalShop.Data.Repository
{
    public class OrdersRepository: IAllOrders
    {
        private readonly AppDbContent _appDbContent;
        private readonly ShopCart _shopCart;

        public OrdersRepository(AppDbContent appDbContent, ShopCart shopCart)
        {
            _appDbContent = appDbContent;
            _shopCart = shopCart;
        }

        public void createOrder(Order order)
        {
            order.OrderTime = DateTime.Now;
            _appDbContent.Order.Add(order);
            _appDbContent.SaveChanges();

            var items = _shopCart.ListShopItems;
            foreach(var item in items)
            {
                var orderDetail = new OrderDetail() {
                    ReagentId = item.ReagentItemId,
                    OrderId = order.Id,
                    Price = item.Price,
                };
                _appDbContent.OrderDetail.Add(orderDetail);
                _appDbContent.SaveChanges();
                

                
            }
        }
    }
}
