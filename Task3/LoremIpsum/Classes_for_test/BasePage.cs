using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using SeleniumExtras.WaitHelpers;

namespace FinalProlect
{

    public class BasePage
    {
        protected WebDriver driver;

        public BasePage(WebDriver driver) 
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        public void WaitForPageLoadComplate(long timeToWait)
        {
            new WebDriverWait(driver, TimeSpan.FromSeconds(timeToWait)).Until(WebDriver => ((IJavaScriptExecutor)driver)).ExecuteScript("return window.jQuery != undefined && jQuery.active <=2;");
        }

        public void WaitVisibilityOfElement(long timeToWait, IWebElement element)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeToWait));
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(element));
        }

    }
}
