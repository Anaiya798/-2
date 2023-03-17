using Shop.Data.Abstractions;
using Shop.Data.Models;
using Shop.Models;

namespace Shop.Database
{
    public class OrdersRepository : AllOrders
    {
        private AppDBContent _appDbContent;
        private ShopCart _shopCart;

        public AppDBContent AppDbContent {
            get
            {
                return _appDbContent;
            }
            private set
            {
                _appDbContent = value;
            }
         }

        public ShopCart ShopCart
        {
            get
            {
                return _shopCart;
            }
            private set
            {
                _shopCart = value;
            }
        }
        public OrdersRepository(AppDBContent appDbContent, ShopCart shopCart)
        {
            AppDbContent = appDbContent;
            ShopCart = shopCart;
        }

        public override void createOrder(Order order)
        {
            AppDbContent.Order.Add(order);

            var items = ShopCart.Items;
            foreach (var item in items)
            {
                var orderDetail = new OrderDetail()
                {
                    OrderId = order.Id,
                    ReagentId = item.ReagentId,
                    Price = item.Price,
                };
                AppDbContent.OrderDetail.Add(orderDetail);
            }
            AppDbContent.SaveChanges();
        }
    }
}
