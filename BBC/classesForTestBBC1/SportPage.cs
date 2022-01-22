using System;
using BBC.classesForTest;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace BBC.classesForTestBBC1
{
    public class SportPage : BasePage
    {
        [FindsBy(How = How.XPath, Using = "//div[contains(@class,'sp-c-sport-navigation')]//a[@data-stat-title='Football']")]
        private IWebElement goToFootball;

        public void ClickOnGoToFootball() { goToFootball.Click(); }

        public SportPage(WebDriver driver) : base(driver) { }
    }
}
