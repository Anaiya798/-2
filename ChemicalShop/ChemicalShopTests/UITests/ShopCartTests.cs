using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace ChemicalShopTests.UITests
{
    [TestFixture]
    internal class ShopCartTests
    {
        private const string URL = "https://localhost:5001/Reagents/ReagentsList";
        private IWebDriver _driver;

        [SetUp]
        public void Setup()
        {
            _driver = new ChromeDriver();
            _driver.Manage().Window.Maximize();
            _driver.Navigate().GoToUrl(URL);
        }

        private bool paymentBtnValid(IWebDriver driver)
        {
            return driver.PageSource.Contains("Оплатить");
        }

        private bool generalSignatures(IWebDriver driver)
        {
            return driver.PageSource.Contains("Наименование") && driver.PageSource.Contains("Описание") && driver.PageSource.Contains("Цена");
        }
        private void pressAddToCartBtn(IWebDriver driver)
        {
            driver.FindElement(By.XPath("/html/body/div/div/div[1]/p[3]/a")).Click();
        }

        [Test]
        public void ShopCartTest()
        {
            _driver.FindElement(By.LinkText("Корзина")).Click();
            Thread.Sleep(1000);

            Assert.IsTrue(paymentBtnValid(_driver));

            _driver.FindElement(By.LinkText("Растворители")).Click();
            Thread.Sleep(1000);

            pressAddToCartBtn(_driver);
            Thread.Sleep(1000);

            
            Assert.IsTrue(generalSignatures(_driver));
            Assert.IsTrue(paymentBtnValid(_driver));
            bool flag = _driver.PageSource.Contains("Этанол");
            Assert.IsTrue(flag);
            flag = _driver.PageSource.Contains("Антисептик, растворитель");
            Assert.IsTrue(flag);
            flag = _driver.PageSource.Contains("15");
            Assert.IsTrue(flag);

            _driver.FindElement(By.LinkText("Индикаторы")).Click();
            Thread.Sleep(1000);

            pressAddToCartBtn(_driver);
            Thread.Sleep(1000);

            Assert.IsTrue(generalSignatures(_driver));
            Assert.IsTrue(paymentBtnValid(_driver));
            flag = _driver.PageSource.Contains("Этанол");
            Assert.IsTrue(flag);
            flag = _driver.PageSource.Contains("Лакмус");
            Assert.IsTrue(flag);
            flag = _driver.PageSource.Contains("Антисептик, растворитель");
            Assert.IsTrue(flag);
            flag = _driver.PageSource.Contains("Кислотно-основный индикатор");
            Assert.IsTrue(flag);
            flag = _driver.PageSource.Contains("15");
            Assert.IsTrue(flag);
            flag = _driver.PageSource.Contains("246");
            Assert.IsTrue(flag);

            _driver.Close();
        }

    }
}
