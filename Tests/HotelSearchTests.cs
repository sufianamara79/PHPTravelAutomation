using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using PHPTravelsAutomation.PageObjects;

namespace PHPTravelsAutomation.Tests
{
    [TestFixture()]
    public class HotelSearchTests
    {
        ChromeDriver driver = new ChromeDriver();

        [Test()]
        public void TestHotelSearchValid()
        {

            driver.Navigate().GoToUrl("https://www.phptravels.net/");


            HomePage page = new HomePage(driver);
            page.SearchForHotel("paris", "21", "12", "3");

            Assert.AreEqual("HOTELS", page.GetActiveService());

           

        }

        [TearDown()]
        public void TestClean()
        {
            driver.Quit();
        }
    }
}
