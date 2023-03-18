using Shop.CustomerDataProcessing;
using Shop.Data.Models;
namespace ShopTests.OrderProcessingTests

{
    [TestFixture]
    public class PhoneVerificationTests
    {
        private PhoneChecker _phoneChecker;
        private Order _order;
        [SetUp]

        public void Setup()
        {
            _phoneChecker = new PhoneChecker();
            _order = new Order();
        }

        [Test]
        public void IncorrectPhoneTest()
        {
            _order.Phone = "";
            Assert.IsFalse(_phoneChecker.Check(_order));
            _order.Phone = "9999999999999999999999";
            Assert.IsFalse(_phoneChecker.Check(_order));
        }

        [Test]
        public void ÑorrectPhoneTest()
        {
            _order.Phone = "+79117000000";
            Assert.IsTrue(_phoneChecker.Check(_order));
            _order.Phone = "+ 374 91 972459";
            Assert.IsTrue(_phoneChecker.Check(_order));
        }
    }
}