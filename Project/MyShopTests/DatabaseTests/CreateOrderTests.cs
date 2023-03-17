using Shop.Data.Models;
using Shop.Database;
using Shop.Models;

namespace MyShopTests.DatabaseTests
{
    [TestFixture]
    public class CreateOrderTests
    {
        private AppDBContent _dbStub;
        private ShopCart _shopCart;
        private OrdersRepository _ordersRepository;
        private List<OrderDetail> _orderDetails;

        [SetUp]
        public void Setup()
        {
            _dbStub = new AppDBContent();
            _shopCart = new ShopCart();
            _shopCart.Items = new List<ShopCartItem>() {
                new ShopCartItem() {ReagentId = 1, ShopCartId = 1, Price = 50000},
                new ShopCartItem() {ReagentId = 2, ShopCartId = 1, Price = 500},
             };
            _orderDetails = new List<OrderDetail>()
            {
                new OrderDetail() {ReagentId = 1, OrderId = 1, Price = 50000},
                new OrderDetail() {ReagentId = 2, OrderId = 1, Price = 500},
            };
            _ordersRepository = new OrdersRepository(_dbStub, _shopCart);
        }

        [Test]
        public void EmptyOrderTest()
        {
            _ordersRepository.createOrder(null);

            var orders = _ordersRepository.AppDbContent.Order.ToList();
            var orderDetails = _ordersRepository.AppDbContent.OrderDetail.ToList();

            Assert.That(orders.Count, Is.EqualTo(0));
            Assert.IsTrue(orderDetails.Contains(_orderDetails[0]));
            Assert.IsTrue(orderDetails.Contains(_orderDetails[1]));
            Assert.That(orders.Count, Is.EqualTo(2));


        }

        [Test]
        public void RealOrderTest()
        {
            _ordersRepository.AppDbContent.OrderDetail.RemoveRange(_orderDetails);
            _ordersRepository.AppDbContent.SaveChanges();

            var order = new Order() { Id = 1, Name = "", Phone = "+79110000000", Email = "a@gmail.com", CreditCardNumber = "0000000000000000" };
            _ordersRepository.createOrder(order);

            var orders = _ordersRepository.AppDbContent.Order.ToList();
            var orderDetails = _ordersRepository.AppDbContent.OrderDetail.ToList();

            Assert.That(orders.Count, Is.EqualTo(1));
            Assert.IsTrue(orders.Contains(order));
            Assert.IsTrue(orderDetails.Contains(_orderDetails[0]));
            Assert.IsTrue(orderDetails.Contains(_orderDetails[1]));
            Assert.That(orders.Count, Is.EqualTo(2));


        }

    }
    
}
