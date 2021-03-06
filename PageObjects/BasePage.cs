﻿using System; using System.Collections.Generic; using OpenQA.Selenium; using SeleniumExtras.PageObjects;  namespace PHPTravelsAutomation.PageObjects {     public class BasePage     {         protected IWebDriver driver;          [FindsBy(How = How.ClassName, Using = "container")]         protected IWebElement mainMenu { get; set; }          [FindsBy(How = How.ClassName, Using = "open")]         protected IWebElement lblMyAccount { get; set; }
          public void OpenLefftMenuItem(string menuItem)         {             IList<IWebElement> leftMenuElements = driver.FindElements(By.CssSelector(".nav.navbar-nav.go-right a"));              foreach (IWebElement element in leftMenuElements)             {                 if (element.Text == menuItem)                 {                     element.Click();                     element.Clear();                     break;                 }             }         }

        public string GetActiveService()         {             string activeService = driver.FindElement(By.CssSelector(".active.text-center.go-right a span")).Text;              return activeService;          }

        public string GetPageURL()         {             return driver.Url;          }

    } } 