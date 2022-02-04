using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecFlowProject1.Pages
{
    internal class NewsPage : BasePage
    {
        [FindsBy(How = How.XPath, Using = "//ul[contains(@class,'wide-sections')]//span[text()='Coronavirus']")]
        private IWebElement coronavirusNews;

        [FindsBy(How = How.XPath, Using = "//input[@id='orb-search-q']")]
        private IWebElement searchInput;

        [FindsBy(How = How.XPath, Using = "//div[contains(@class,'inline-block@m')]//h3")]
        private IWebElement headlineArticle;


        public NewsPage(WebDriver driver) : base(driver) { }


        public string GetTitleText(string titleNumber)
        {
            var titleText = driver.FindElement(By.XPath($"//div[contains(@class,'top-stories__secondary-item')][{titleNumber}]//h3"));
            return titleText.Text;
        }

        public string GetCategoryLink(string categoryLinkNumber)
        {
            var textCategoryLink = driver.FindElement(By.XPath($"//div[contains(@class,'top-stories__secondary-item')][{categoryLinkNumber}]//a/span[@aria-hidden]"));
            return textCategoryLink.Text;
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
