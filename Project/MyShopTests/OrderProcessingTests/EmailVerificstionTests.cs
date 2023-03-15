using System;
using Shop.CustomerDataProcessing;
using Shop.Data.Models;
namespace ShopTests.OrderProcessingTests

{
    [TestFixture]
    public class EmailVerificationTests
    {
        private EmailChecker _emailChecker;
        private Order _order;
        [SetUp]

        public void Setup()
        {
            _emailChecker = new EmailChecker();
            _order = new Order();
        }

        [Test]
        public void IncorrectEmailTest()
        {
            _order.Email = "";
            Assert.IsFalse(_emailChecker.Check(_order));
            _order.Email = "hello.Everyone";
            Assert.IsFalse(_emailChecker.Check(_order));
            _order.Email = "hello@Everyone@gmail.com";
            Assert.IsFalse(_emailChecker.Check(_order));
            _order.Email = "@";
            Assert.IsFalse(_emailChecker.Check(_order));
            _order.Email =".@.com";
            Assert.IsFalse(_emailChecker.Check(_order));
        }

        [Test]
        public void СorrectEmailTest()
        {
            _order.Email = "ananasik@gmail.com";
            Assert.IsTrue(_emailChecker.Check(_order));
            _order.Email = "a_@yandex.ru";
            Assert.IsTrue(_emailChecker.Check(_order));
            _order.Email = "AAAAAaaaaaaaaaaaaaaa@goethe.de";
            Assert.IsTrue(_emailChecker.Check(_order));
            _order.Email = "123456@yandex.ru";
            Assert.IsTrue(_emailChecker.Check(_order));
            _order.Email = "!#?~@list.ru";
            Assert.IsTrue(_emailChecker.Check(_order));
        }
    }
}