using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;

namespace MyShopTests.UITests
{
    public class OrderPaymentTests
    {
        [SetUp]
        public void Setup()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl("http://localhost/REAXON/OrderPayment");
        }

        [Test]
        public void IncorrectPhoneTest()
        {
            //заказ не проходит, если некорректный номер телефона

        }

        [Test]
        public void IncorrectEmailTest()
        {
            //заказ не проходит, если некорректный номер email
        }

        [Test]
        public void IncorrectCreditCardTest()
        {
            //заказ не проходит, если некорректный номер банковской карты
        }

        [Test]
        public void AllCorrectTest()
        {
            //если все данные корректны, заказ проходит
        }

    }
}

