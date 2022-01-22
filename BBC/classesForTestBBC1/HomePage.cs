using System;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace BBC.classesForTest
{
    public class HomePage : BasePage
    {
        [FindsBy(How = How.XPath, Using = "//a[@href='https://www.bbc.com/news']")]
        private IWebElement goToNews;
       
        [FindsBy(How = How.XPath, Using = "//a[@href='https://www.bbc.com/sport']")]
        private IWebElement goToSport;

        public void ClickOnGoToNews() { goToNews.Click(); }

        public void ClickOnGoToSport() { goToSport.Click(); }

        public HomePage(WebDriver driver) : base(driver) { }
    }
}
