using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;

namespace BBC1_Project.PageObjects
{

    public class BasePage
    {
        protected readonly IWebDriver _webDriver;
        private readonly int _timeToWait = 30;
        private readonly By _closeWindowRegistration = By.XPath("//button[@class='tp-close tp-active']");
        private readonly Dictionary<string, string> form = new Dictionary<string, string>()
        {
            {"Question","My question" },
            {"Name", "Alex" },
            {"Email","Alex@ukr.net" },
            {"Number","12345678" },
            {"Location","USA" },
            {"Age","40" }
        };
        public string Question => form["Question"];
        public string Name => form["Name"];
        public string Email => form["Email"];
        public string Number => form["Number"];
        public string Location => form["Location"];
        public string Age => form["Age"];

        public BasePage(IWebDriver webDriver)
        {
            _webDriver = webDriver;
        }
        public void WaitForPageLoad()
        {
            _webDriver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(_timeToWait);
        }
       
        public void WaitForElement(IWebElement element)
        {
            WebDriverWait wait = new WebDriverWait(_webDriver, TimeSpan.FromMinutes(_timeToWait));
            wait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            wait.IgnoreExceptionTypes(typeof(StaleElementReferenceException));
        }
        public void CloseWindowRegistration()
        {
            if (_webDriver.FindElement(_closeWindowRegistration).Displayed)
            {
                _webDriver.FindElement(_closeWindowRegistration).Click();

            }
        }
    }
}
