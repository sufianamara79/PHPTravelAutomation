using System;
using System.Collections.Generic;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;


namespace PHPTravelsAutomation.PageObjects
{
    public class HomePage: BasePage
    {
        [FindsBy(How = How.CssSelector, Using = ".nav.nav-tabs.RTL.nav-justified")]
        protected IWebElement serviceMenu { get; set; }

        [FindsBy(How = How.Id, Using = "s2id_autogen8")]
        protected IWebElement contHotelName { get; set; }

        [FindsBy(How = How.Id, Using = "dpd1")]
        protected IWebElement FieldCheckInFrom { get; set; }

        [FindsBy(How = How.Id, Using = "dpd2")]
        protected IWebElement FieldCheckInTo { get; set; }

        [FindsBy(How = How.CssSelector, Using = ".search-button")]
        protected IWebElement divSearch { get; set; }

        [FindsBy(How = How.Name, Using = "flightmanualSearch")]
        protected IWebElement formFlights { get; set; }

        public HomePage(IWebDriver driver)
        {
            base.driver = driver;

            PageFactory.InitElements(driver, this);
        }

        public void ChooseService(string service)
        {
            IList<IWebElement> serviceElements = serviceMenu.FindElements(By.TagName("a"));

            foreach (IWebElement element in serviceElements)
            {
                if (element.Text == service)
                {
                    element.Click();
                    break;
                }
            }
        }

        public void SearchForHotel(string hotelName, string fromDay, string toDay,string adults)
        {
            IWebElement elementName = contHotelName.FindElement(By.ClassName("select2-chosen"));

            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            string title = (string)js.ExecuteScript("arguments[0].innerText = '" + hotelName + "'", elementName);

            FieldCheckInFrom.Click();

            PickDayIn(fromDay);
            PickDayOut(toDay);

            IWebElement elementTraveller = driver.FindElement(By.Id("travellersInput"));

            elementTraveller.Click();

            IWebElement txtNumberofAdults = driver.FindElement(By.Id("adultInput"));

            js.ExecuteScript("arguments[0].value = '" + adults + "'", txtNumberofAdults);

            divSearch.Click();


        }

        public void SearchForFlight(string cityFrom, string cityTo, string depart, string adults)
        {
            IWebElement divFrom = formFlights.FindElement(By.Id("s2id_location_from"));

            IWebElement elementName = divFrom.FindElement(By.ClassName("select2-chosen"));

            IWebElement elementCode = formFlights.FindElement(By.Id("location_from_code"));

            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            string title = (string)js.ExecuteScript("arguments[0].innerText = '" + cityFrom + "'", elementName);
            js.ExecuteScript("arguments[0].value = '{\"code\":\"" + cityFrom + "\",\"location\":\"\"}'", elementCode);

            IWebElement divTo = formFlights.FindElement(By.Id("s2id_location_to"));

            elementName = divTo.FindElement(By.ClassName("select2-chosen"));

            elementCode = formFlights.FindElement(By.Id("location_to_code"));

            js = (IJavaScriptExecutor)driver;
            title = (string)js.ExecuteScript("arguments[0].innerText = '" + cityTo + "'", elementName);
            js.ExecuteScript("arguments[0].value = '{\"code\":\"" + cityTo + "\",\"location\":\"\"}'", elementCode);

            IWebElement elementDeparture = driver.FindElement(By.Name("departure"));

            js.ExecuteScript("arguments[0].value = '" + depart + "'", elementDeparture);


            IWebElement txtNumberofPassengers = formFlights.FindElement(By.Name("totalManualPassenger"));

            js.ExecuteScript("arguments[0].value = '" + adults + "'", txtNumberofPassengers);

            formFlights.Submit();


        }

        public void PickDayIn(string day)
        {
            IWebElement daysTable = driver.FindElement(By.CssSelector("div.datepicker"));

            IList<IWebElement> dayElements = daysTable.FindElements(By.CssSelector("td.day"));

            foreach(IWebElement element in dayElements)
            {
                if (element.Text == day)
                {
                    element.Click();
                    break;
                }
            }
        }

        public void PickDayOut(string day)
        {
            IWebElement daysTable = driver.FindElement(By.XPath("//div[contains(@class, 'datepicker dropdown-menu')][2]"));

            IList<IWebElement> dayElements = daysTable.FindElements(By.CssSelector("td.day"));

            foreach (IWebElement element in dayElements)
            {
                if (element.Text == day)
                {
                    element.Click();
                    break;
                }
            }
        }
    }
}
