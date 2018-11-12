using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using PHPTravelsAutomation.PageObjects;
using System;
namespace PHPTravelsAutomation
{
    [TestFixture()]
    public class NUnitTestClass
    {
        ChromeDriver driver = new ChromeDriver();

        [Test()]
        public void TestCase()
        {
       
            driver.Navigate().GoToUrl("https://www.phptravels.net/");


            HomePage page = new HomePage(driver);
            page.SearchForHotel("paris", "21","12","3");
            driver.Quit();

        }
          
        [TearDown()]
        public void TestClean()
        {
            driver.Quit();
        }
    }
}
