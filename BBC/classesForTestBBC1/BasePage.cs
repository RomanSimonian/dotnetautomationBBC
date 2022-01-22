using System;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace BBC.classesForTest
{
    public class BasePage
    {
        WebDriver driver;

        public BasePage(WebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        public void ImplicitWat(long timeToWait)
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(timeToWait);
        }
    }
}
