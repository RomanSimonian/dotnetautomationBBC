using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;


namespace BBC1_Project.PageObjects
{

    public class BasePage
    {
        protected readonly IWebDriver _webDriver;
        private readonly int _timeToWait = 30;
        private readonly By _closeWindowRegistration = By.XPath("//button[@class='tp-close tp-active']");

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
