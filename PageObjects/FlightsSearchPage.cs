using System;
using System.Collections.Generic;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using PHPTravelsAutomation.Products;
using SeleniumExtras.PageObjects;

namespace PHPTravelsAutomation.PageObjects
{
    public class FlightsSearchPage: BasePage
    {
        IList<Flight> flights = new List<Flight>();

        public FlightsSearchPage(IWebDriver driver)
        {
            base.driver = driver;

            this.IsPageLoaded();

            PageFactory.InitElements(driver, this);
        }

        public void IsPageLoaded()
        {
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
        }

        public void SetFilter()
        {
            // implementation goes here
        }

        public IList<Flight> GetFlightsDetails()
        {

            IWebElement flightTable = driver.FindElement(By.Id("load_data"));

            IList<IWebElement> flightElements = flightTable.FindElements(By.TagName("td"));

            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;

            IWebElement flightInfo;
            IWebElement flightFrom;
            IWebElement flightTo;
            Flight flight;

            foreach (IWebElement element in flightElements)
            {
                js.ExecuteScript("arguments[0].style = 'visibility: visible; animation-name: fadeIn;'", element);

                flight = new Flight();

                flightInfo = element.FindElement(By.CssSelector("div div:nth-of-type(2)"));

                flightFrom = flightInfo.FindElement(By.CssSelector("p strong span:nth-of-type(1)"));

                flightTo = flightInfo.FindElement(By.CssSelector("p strong span:nth-of-type(2)"));

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
