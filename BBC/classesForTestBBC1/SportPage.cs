using System;
using BBC.classesForTest;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace BBC.classesForTestBBC1
{
    public class SportPage : BasePage
    {
        public SportPage(WebDriver driver) : base(driver) { }

        public void ClickOnCategoryButton(string category)
        {
            driver.FindElement(By.XPath($"//div[contains(@class,'sp-c-sport-navigation')]//a[@data-stat-title='{category}']")).Click();
        }
    }
}
