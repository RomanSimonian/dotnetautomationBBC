using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecFlowLoremIpsum.Pages
{
    public class BasePage
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
    }
}
