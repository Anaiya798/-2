using Shop.Data.Models;
namespace Shop.Data.Abstractions
{
    public abstract class AllOrders
    {
        public abstract void createOrder(Order order);
    }
}
