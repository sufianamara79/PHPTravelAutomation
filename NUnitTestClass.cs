using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using System;
namespace PHPTravelsAutomation
{
    [TestFixture()]
    public class NUnitTestClass
    {
        [Test()]
        public void TestCase()
        {
            ChromeDriver driver = new ChromeDriver();

            driver.Navigate().GoToUrl("https://www.phptravels.net/");
            driver.Quit();

        }
    }
}
