using System;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace BBC.classesForTest
{
    public class HomePage : BasePage
    {
        public void ClickOnGoToCategory(string category)
        {
            driver.FindElement(By.XPath($"//div[@id='orb-nav-links']/ul/li/a[text()='{category}']")).Click();
        }

        public HomePage(WebDriver driver) : base(driver) { }
    }
}
