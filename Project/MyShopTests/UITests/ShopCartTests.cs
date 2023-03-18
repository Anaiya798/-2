using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;

namespace MyShopTests.UITests
{
    public class ShopCartTests
    {
        [SetUp]
        public void Setup()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl("http://localhost/REAXON/ShopCart");
        }

        [Test]
        public void EmptyCartTest()
        {

            //корректно отрабатывает случай пустой корзины
        }

        [Test]
        public void NonEmptyCartTest()
        {
            //корректно отрабатывает случай непустой корзины 
        }

    }
}
}
