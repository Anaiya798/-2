using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;

namespace MyShopTests.UITests
{
    [TestFixture]
    public class AnalyticalReagentsPageTests: GoodsPageTests
    {
        [SetUp]
        new public void Setup()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl("http://localhost/REAXON/AnalyticalReagents");
        }

        [Test]
        public override void CorrectPageTest()
        {


        }

        [Test]
        public override void CorrectReagentsTest()
        {

        }

    }
}
}
