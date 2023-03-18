using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace MyShopTests.UITests
{
    public class InorganicChemistryPageTests: GoodsPageTests
    {
        [SetUp]
        new public void Setup()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl("http://localhost/REAXON/InorganicChemistry");
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
