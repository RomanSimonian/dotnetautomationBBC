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

        [FindsBy(How = How.XPath, Using = "//div[contains(@class,'gs-c-promo-body')]//a[@href='/news/world-59798682']")]
        private IWebElement headlineArticle;

        [FindsBy(How = How.XPath, Using = "//div[contains(@class,'gs-c-promo-body')]//a[@href='/news/world-africa-59796716']")]
        private IWebElement firstArticle;

        [FindsBy(How = How.XPath, Using = "//div[contains(@class,'gs-c-promo-body')]//a[@href='/news/world-asia-59800113']")]
        private IWebElement secondArticle;

        [FindsBy(How = How.XPath, Using = "//div[contains(@class,'gs-c-promo-body')]//a[@href='/news/world-us-canada-59800032']")]
        private IWebElement thirdArticle;

        [FindsBy(How = How.XPath, Using = "//div[contains(@class,'gs-c-promo-body')]//a[@href='/news/entertainment-arts-59800777']")]
        private IWebElement fourthArticle;

        [FindsBy(How = How.XPath, Using = "//div[contains(@class,'gs-c-promo-body')]//a[@href='/news/world-australia-59802233']")]
        private IWebElement fifthArticle;

        [FindsBy(How = How.XPath, Using = "//div[@data-entityid='container-top-stories#6']//a/span")]
        private IWebElement categoryLink;




        public string GetCategoryLink()
        {
            return categoryLink.GetAttribute("textContent");
        }

        public string GetFirstArticle() { return firstArticle.Text; }

        public string GetSecondArticle() { return secondArticle.Text; }

        public string GetThirdArticle() { return thirdArticle.Text; }

        public string GetFourthArticle() { return fourthArticle.Text; }

        public string GetFifthArticle() { return fifthArticle.Text; }

        public string GetHeadlineArticle() { return headlineArticle.Text; }


        public void EnterSearchInput(string search)
        {
            searchInput.Click();
            searchInput.SendKeys(search);
            searchInput.SendKeys(Keys.Enter);
        }

        public void ClickOnCoronavirusNews() { coronavirusNews.Click(); }

        public NewsPage(WebDriver driver) : base(driver) { }
    }
}
