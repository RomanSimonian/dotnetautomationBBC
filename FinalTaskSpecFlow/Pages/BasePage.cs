using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using System;

namespace FinalTask_BBC2_Bogdanov.Pages
{

    public class BasePage
    {
        protected IWebDriver Driver;
        public double TimeToWait = 30;

        public BasePage(IWebDriver driver)
        {
            this.Driver = driver;
            PageFactory.InitElements(driver, this);
        }

        public void ImplisityWait(double timeToWait)
        {
            WebDriverWait Wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(timeToWait));
        }
        public IWebElement WaitAndReturmElementExist(double timeToWait, string xpathElement)
        {
            WebDriverWait Wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(timeToWait));
            Wait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            var element = Wait.Until(x => x.FindElement(By.XPath(xpathElement)));
            return element;
        }

        public void WaitUntilEnable(double timeToWait, IWebElement element)
        {
            WebDriverWait Wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(timeToWait));
            Wait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            Wait.Until<bool>(x => element.Enabled);
        }


    }
}
