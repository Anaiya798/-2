using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace MyShopTests.UITests
{
    [TestFixture]
    public class GoodsPageTests
    {
        [SetUp]

        public void Setup()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl("http://localhost/REAXON");
        }

        [Test]
        public virtual void CorrectPageTest()
        {
            //проверяем, что попали на нужную страницу 

        }

        [Test]
        public virtual void CorrectReagentsTest()
        {
            //проверяем, что на странице в качестве товаров отображаются нужные реактивы
        }

        [Test]
        public void CorrectLinksTest()
        {
            //проверяем, что можем переходить с текущей на другие страницы магазина
        }
    }
}
