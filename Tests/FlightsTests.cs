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
        public void TestFlightsSearch()
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

            Assert.AreEqual(20, flights.Count);

            foreach (Flights flight in flights)
            {
                Assert.AreEqual("LUX", flight.travelFrom, "travel from location is not as expected");
                Assert.AreEqual("DUB", flight.travelTo, "travel to location is not as expected");

                // Insert dates checks here

                // Insert stops checks here

            }
        }

        [TearDown()]
        public void TestClean()
        {
            driver.Quit();
        }
    }
}
