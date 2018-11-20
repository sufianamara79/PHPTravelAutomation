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
            page.SearchForHotel("paris", "23", "24", "3");

            Assert.AreEqual("HOTELS", page.GetActiveService());

            Assert.AreEqual("https://www.phptravels.net/hotels/search/23-11-2018/24-11-2018/3/0", page.GetPageURL());
        }

        [TearDown()]
        public void TestClean()
        {
            driver.Quit();
        }
    }
}
