using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace ChemicalShopTests.UITests
{
    [TestFixture]
    internal class CategoriesPagesTests
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
        [Test]
        public void AllReagentsPageTest()
        {
            bool flag = _driver.PageSource.Contains("Этанол");
            Assert.IsTrue(flag);

            flag = _driver.PageSource.Contains("Диоксид марганца");
            Assert.IsTrue(flag);

            _driver.Close();

           
        }

        [Test]
        public void PopularReagentsTest()
        {
            _driver.FindElement(By.LinkText("Популярное")).Click();
            Thread.Sleep(1000);

            bool flag = _driver.PageSource.Contains("Этанол");
            Assert.IsTrue(flag);

            flag = _driver.PageSource.Contains("Диоксид марганца");
            Assert.IsFalse(flag);

            _driver.Close();
        }

        [Test]
        public void InorganicReagentsTest()
        {
            _driver.FindElement(By.LinkText("Неорганика")).Click();
            Thread.Sleep(1000);

            bool flag = _driver.PageSource.Contains("Пищевая сода");
            Assert.IsTrue(flag);

            flag = _driver.PageSource.Contains("Азотная кислота");
            Assert.IsTrue(flag);

            _driver.Close();
        }

        [Test]
        public void OrganicReagentsTest()
        {
            _driver.FindElement(By.LinkText("Органика")).Click();
            Thread.Sleep(1000);

            bool flag = _driver.PageSource.Contains("Бутанол");
            Assert.IsTrue(flag);

            flag = _driver.PageSource.Contains("Резорцин");
            Assert.IsTrue(flag);

            _driver.Close();
        }

        [Test]
        public void IndicatorsReagentsTest()
        {
            _driver.FindElement(By.LinkText("Индикаторы")).Click();
            Thread.Sleep(1000);

            bool flag = _driver.PageSource.Contains("Лакмус");
            Assert.IsTrue(flag);

            flag = _driver.PageSource.Contains("Фенолфталеин");
            Assert.IsTrue(flag);

            _driver.Close();
        }

        [Test]
        public void SolventsReagentsTest()
        {
            _driver.FindElement(By.LinkText("Растворители")).Click();
            Thread.Sleep(1000);

            bool flag = _driver.PageSource.Contains("Этанол");
            Assert.IsTrue(flag);

            flag = _driver.PageSource.Contains("Диэтиловый эфир");
            Assert.IsTrue(flag);

            _driver.Close();
        }

        [Test]
        public void BACReagentsTest()
        {
            _driver.FindElement(By.LinkText("БАВ")).Click();
            Thread.Sleep(1000);

            bool flag = _driver.PageSource.Contains("Тетрациклин");
            Assert.IsTrue(flag);

            _driver.Close();
        }



    }
}
