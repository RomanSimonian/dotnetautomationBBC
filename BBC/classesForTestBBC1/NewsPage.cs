using System;
using System.Collections.Generic;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace BBC.classesForTest
{
    public class NewsPage : BasePage
    {
        [FindsBy(How = How.XPath, Using = "//ul[contains(@class,'wide-sections')]//span[text()='Coronavirus']")]
        private IWebElement coronavirusNews;

        [FindsBy(How = How.XPath, Using = "//input[@id='orb-search-q']")]
        private IWebElement searchInput;

        [FindsBy(How = How.XPath, Using = "//div[contains(@class,'inline-block@m')]//h3")]
        private IWebElement headlineArticle;

        [FindsBy(How = How.XPath, Using = "//div[contains(@class,'top-stories__secondary-item')]//h3")]
        private IList<IWebElement> secondaryTitleList;


        public NewsPage(WebDriver driver) : base(driver) { }


        public IList<IWebElement> GetSecondaryTitleList()
        {return secondaryTitleList; }

        public string GetTitleText(string titleNumber)
        {
            return driver.FindElement(By.XPath($"//div[contains(@class,'top-stories__secondary-item')][{titleNumber}]//h3")).Text;
        }

        public string GetCategoryLink(string categoryLinkNumber)
        {
            return driver.FindElement(By.XPath($"//div[contains(@class,'top-stories__secondary-item')][{categoryLinkNumber}]//a/span[@aria-hidden]")).Text;
        }

        public string GetHeadlineArticle() { return headlineArticle.Text; }

        public void EnterSearchInput(string search)
        {
            searchInput.Click();
            searchInput.SendKeys(search);
            searchInput.SendKeys(Keys.Enter);
        }

        public void ClickOnCoronavirusNews() { coronavirusNews.Click(); }
    }
}
