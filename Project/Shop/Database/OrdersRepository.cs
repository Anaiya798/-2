using Shop.Data.Abstractions;
using Shop.Data.Models;

namespace Shop.Database
{
    public class OrdersRepository : AllOrders
    {
       

        public override void createOrder(Order order)
        {
            //запись данных о заказах в базу
        }
    }
}
