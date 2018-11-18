using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using PHPTravelsAutomation.PageObjects;
using PHPTravelsAutomation.Products;
using System;
using System.Collections.Generic;

namespace PHPTravelsAutomation.Tests
{
    [TestFixture()]
    public class FlightsTests
    {
        ChromeDriver driver;

         [Test()]
        public void TestCase()
        {
            ChromeOptions options = new ChromeOptions();
            options.AddArgument("--start-maximized");

            driver = new ChromeDriver(options);

            driver.Navigate().GoToUrl("https://www.phptravels.net/");

            HomePage page = new HomePage(driver);

            page.ChooseService("FLIGHTS");

            page.SearchForFlight("LUX", "DXB", "19", "2");

            FlightsSearchPage flightsSearchPage = new FlightsSearchPage(driver);

            IList<Flights> flights = flightsSearchPage.GetFlightsDetails();

            Assert.AreEqual(12, flights.Count);
        }

        [TearDown()]
        public void TestClean()
        {
            driver.Quit();
        }
    }
}
