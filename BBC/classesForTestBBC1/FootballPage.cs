using System;
using BBC.classesForTest;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace BBC.classesForTestBBC1
{
    public class FootballPage : BasePage
    {
        public void ClickOnSelectLeague(string league)
        {
            driver.FindElement(By.XPath($"//span[text()='{league}']")).Click();
        }

        public FootballPage(WebDriver driver) : base(driver){  }
        
    }
}
