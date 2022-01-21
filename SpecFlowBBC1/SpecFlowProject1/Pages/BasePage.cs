using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecFlowProject1.Pages
{
    internal class BasePage
    {
        protected readonly WebDriver driver;

        public BasePage(WebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        public void WaitForPageLoadComplate(long timeToWait)
        {
            new WebDriverWait(driver, TimeSpan.FromSeconds(timeToWait)).Until(WebDriver => ((IJavaScriptExecutor)driver)).ExecuteScript("return window.jQuery != undefined && jQuery.active <=2;");
        }

        public void WaitVisibilityOfElement(long timeToWait, string element)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeToWait));
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(element)));
        }
    }
}
