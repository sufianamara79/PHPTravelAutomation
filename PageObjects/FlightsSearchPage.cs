using System;
using System.Collections.Generic;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using PHPTravelsAutomation.Products;
using SeleniumExtras.PageObjects;

namespace PHPTravelsAutomation.PageObjects
{
    public class FlightsSearchPage: BasePage
    {
        IList<Flights> flights = new List<Flights>();

        public FlightsSearchPage(IWebDriver driver)
        {
            base.driver = driver;

            try
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(120));
                wait.Until<Boolean>((d) =>
                 {
                     string activeService = driver.FindElement(By.CssSelector(".active.text-center.go-right a span")).Text;

                     if (activeService == "FLIGHTS")
                     {
                         return true;
                     }
                     else
                     {
                         return false;
                     }

                 });
            }
            catch (WebDriverTimeoutException)
            {
                throw new WebDriverTimeoutException("Flights results page could not open");
            }

            PageFactory.InitElements(driver, this);
        }

        public IList<Flights> GetFlightsDetails()
        {
            IWebElement flightTable = driver.FindElement(By.Id("load_data"));

            IList<IWebElement> flightElements = flightTable.FindElements(By.TagName("tr"));
           

            foreach(IWebElement element in flightElements)
            {
                Flights flight = new Flights();

                IWebElement flightInfo = element.FindElement(By.CssSelector("td div div:nth-of-type(2)"));

                IWebElement flightFrom = flightInfo.FindElement(By.CssSelector("p strong span:nth-of-type(1)"));

                IWebElement flightTo = flightInfo.FindElement(By.CssSelector("p strong span:nth-of-type(2)"));

                //parse flights dates here

                //parse flights stops here

                flight.travelFrom = flightFrom.Text;
                flight.travelTo = flightTo.Text;

                flights.Add(flight);
            }

            return flights;
        }
    }
}
