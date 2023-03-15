using System;
using Shop.CustomerDataProcessing;
using Shop.Data.Models;
namespace ShopTests.OrderProcessingTests

{
    [TestFixture]
    public class CreditCardVerificationTests
    {
        private CreditCardChecker _creditCardChecker;
        private Order _order;
        [SetUp]

        public void Setup()
        {
            _creditCardChecker = new CreditCardChecker();
            _order = new Order();
        }

        [Test]
        public void IncorrectCreditCardTest()
        {
            _order.CreditCardNumber = "";
            Assert.IsFalse(_creditCardChecker.Check(_order));
            _order.CreditCardNumber = "#!@80asa";
            Assert.IsFalse(_creditCardChecker.Check(_order));
            _order.CreditCardNumber = "45612612123454679900";
            Assert.IsFalse(_creditCardChecker.Check(_order));
            _order.CreditCardNumber = "456126121";
            Assert.IsFalse(_creditCardChecker.Check(_order));
            _order.CreditCardNumber = "4561261212345464";
            Assert.IsFalse(_creditCardChecker.Check(_order));
        }

        [Test]
        public void СorrectCreditCardTest()
        {
            _order.CreditCardNumber = "4561261212345467";
            Assert.IsTrue(_creditCardChecker.Check(_order));
            _order.CreditCardNumber = "0531261212345464";
            Assert.IsTrue(_creditCardChecker.Check(_order));
            _order.CreditCardNumber = "0000000000000000";
            Assert.IsTrue(_creditCardChecker.Check(_order));
            _order.CreditCardNumber = "0100000000000009";
            Assert.IsTrue(_creditCardChecker.Check(_order));
        }
    }
}