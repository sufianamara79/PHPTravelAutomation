using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using PHPTravelsAutomation.PageObjects;

namespace PHPTravelsAutomation.Tests
{
    [TestFixture()]
    public class HotelSearchTests
    {
        ChromeDriver driver;

        [SetUp()]
        public void TestStart()
        {
            driver = new ChromeDriver();

            driver.Navigate().GoToUrl("https://www.phptravels.net/");
        }

        [Test()]
        public void TestHotelSearchValid()
        {
  
            HomePage page = new HomePage(driver);
            page.SearchForHotel("paris", "5", "6", "3");

            Assert.AreEqual("HOTELS", page.GetActiveService());

            Assert.AreEqual("https://www.phptravels.net/hotels/search/05-12-2018/06-12-2018/3/0", page.GetPageURL());
        }

        [TearDown()]
        public void TestClean()
        {
            driver.Quit();
        }
    }
}
