using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace ChemicalShopTests.UITests
{
    [TestFixture]
    internal class PaymentFormTests
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
        private bool addressInvalid(IWebDriver driver)
        {
            return driver.PageSource.Contains("Длина адреса не менее 10 символов");
            
        }

        private bool phoneInvalid(IWebDriver driver)
        {
            return driver.PageSource.Contains("Длина номера телефона не менее 10 символов");

        }

        private bool emailInvalid(IWebDriver driver)
        {
            return driver.PageSource.Contains("Длина email не менее 10 символов");

        }

        private bool successfulSignature(IWebDriver driver)
        {
            return driver.PageSource.Contains("Заказ успешно обработан");
        }

        private void pressFinalButton(IWebDriver driver)
        {
            driver.FindElement(By.XPath("/html/body/div/div/form/input[1]")).Click();
        }

        private IWebElement getAddressInput(IWebDriver driver)
        {
            return driver.FindElement(By.Name("CustomerAddress"));
        }

        private IWebElement getPhoneInput(IWebDriver driver)
        {
            return driver.FindElement(By.Name("CustomerPhone"));
        }

        private IWebElement getEmailInput(IWebDriver driver)
        {
            return driver.FindElement(By.Name("CustomerEmail"));
        }

        [Test]
        public void PaymentFormTest()
        {

            _driver.FindElement(By.LinkText("Неорганика")).Click();
            Thread.Sleep(1000);

            _driver.FindElement(By.XPath("/html/body/div/div/div[2]/p[3]/a")).Click();
            Thread.Sleep(1000);

            _driver.FindElement(By.LinkText("Оплатить")).Click();
            Thread.Sleep(1000);

            pressFinalButton(_driver);
            Thread.Sleep(1000);
            Assert.IsTrue(addressInvalid(_driver));
            Assert.IsTrue(phoneInvalid(_driver));
            Assert.IsTrue(emailInvalid(_driver));

            var addressInput = getAddressInput(_driver);
            addressInput.SendKeys("a");
            pressFinalButton(_driver);
            Thread.Sleep(1000);
            Assert.IsTrue(addressInvalid(_driver));
            Assert.IsTrue(phoneInvalid(_driver));
            Assert.IsTrue(emailInvalid(_driver));

            addressInput = getAddressInput(_driver);
            addressInput.SendKeys("aaaaaaaaaaaa");
            pressFinalButton(_driver);
            Thread.Sleep(1000);
            Assert.IsTrue(phoneInvalid(_driver));
            Assert.IsTrue(emailInvalid(_driver));

            var phoneInput = getPhoneInput(_driver);
            phoneInput.SendKeys("921");
            pressFinalButton(_driver);
            Thread.Sleep(1000);
            Assert.IsTrue(phoneInvalid(_driver));
            Assert.IsTrue(emailInvalid(_driver));

            phoneInput = getPhoneInput(_driver);
            phoneInput.SendKeys("6141414");
            pressFinalButton(_driver);
            Thread.Sleep(1000);
            Assert.IsTrue(emailInvalid(_driver));

            var emailInput = getEmailInput(_driver);
            emailInput.SendKeys("a");
            pressFinalButton(_driver);
            Thread.Sleep(1000);
            Assert.IsTrue(emailInvalid(_driver));

            emailInput = getEmailInput(_driver);
            emailInput.SendKeys("bcdefghijklmn");
            pressFinalButton(_driver);
            Thread.Sleep(1000);
            Assert.IsTrue(emailInvalid(_driver));

            emailInput = getEmailInput(_driver);
            emailInput.SendKeys("@gmail.com");
            pressFinalButton(_driver);
            Thread.Sleep(1000);
            Assert.IsTrue(successfulSignature(_driver));


            _driver.Close();
        }

    }
}
