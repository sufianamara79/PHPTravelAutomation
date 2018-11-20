using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using PHPTravelsAutomation.PageObjects;
using PHPTravelsAutomation.Products;
using System.Collections.Generic;

namespace PHPTravelsAutomation.Tests
{
    [TestFixture()]
    public class FlightsTests
    {
        ChromeDriver driver;

        [SetUp()]
        public void TestStart()
        {
            driver = new ChromeDriver();

            driver.Navigate().GoToUrl("https://www.phptravels.net/");
        }

        [Test()]
        public void TestFlightsSearch()
        {
            HomePage page = new HomePage(driver);

            page.ChooseService("FLIGHTS");

            page.SearchForFlight("LUX", "DUB", "2018-12-05", "2");

            FlightsSearchPage flightsSearchPage = new FlightsSearchPage(driver);

            IList<Flight> flights = flightsSearchPage.GetFlightsDetails();

            Assert.AreEqual(20, flights.Count);

            foreach (Flight flight in flights)
            {
                Assert.AreEqual("LUX", flight.travelFrom, "travel from location is not as expected");
                Assert.AreEqual("DUB", flight.travelTo, "travel to location is not as expected");

                // Insert dates checks here

            }

            // Insert steps to check page 2 flights here
        }

        [Test()]
        public void TestFlightsSearchWithFilters()
        {
            HomePage page = new HomePage(driver);

            page.ChooseService("FLIGHTS");

            page.SearchForFlight("LUX", "DUB", "2018-12-05", "2");

            FlightsSearchPage flightsSearchPage = new FlightsSearchPage(driver);

            IList<Flight> flights = flightsSearchPage.GetFlightsDetails();

            Assert.AreEqual(20, flights.Count);

            // Insert steps to check flights with zero stops here
        }

        [Test()]
        public void TestFlightsBooking()
        {

            // Add test steps here


        }

        [TearDown()]
        public void TestClean()
        {
            driver.Quit();
        }
    }
}
