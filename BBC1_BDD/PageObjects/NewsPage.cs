using OpenQA.Selenium;
using System;
using System.Collections.Generic;


namespace BBC1_Project.PageObjects
{
    public class NewsPage : BasePage
    {
        private readonly List<String> articles = new List<string>();

        private readonly By _headlineArticle = By.XPath("//div[@data-entityid='container-top-stories#1']");
        private readonly By _secondaryArticles = By.XPath("//div[contains(@class,'stories__secondary')]//a[contains(@class,'heading')]//h3");
        private readonly By _categoryHeadlineArticle = By.XPath("(//a[contains(@class,'section-link')])[1]");
        private readonly By _searchField = By.Id("orb-search-q");
        private readonly By _coronavirusButton = By.XPath("//li[contains(@class,'flush gel')]//span[text()='Coronavirus']");

        public NewsPage(IWebDriver _webDriver) : base(_webDriver) { }

        public string GetTextHeadlineArticles()
        {
            return _webDriver.FindElement(_headlineArticle).GetAttribute("outerText").Split("\n")[0];
        }

        public List<String> GetAllSecondaryArticleTitles()
        {
        foreach (var item in _webDriver.FindElements(_secondaryArticles))
        {
            articles.Add(item.GetAttribute("innerText"));
        }
        Console.WriteLine(articles);
        return articles;
        }
        public string GetCategoryHeadlineArticle()
        {
            return _webDriver.FindElement(_categoryHeadlineArticle).Text;
        }

        public SearchPage SearchByWord(string word)
        {
            _webDriver.FindElement(_searchField).Clear();
            _webDriver.FindElement(_searchField).SendKeys(word);
            _webDriver.FindElement(_searchField).SendKeys(Keys.Enter);
            WaitForPageLoad();
            return new SearchPage(_webDriver);
        }
        public CoronavirusPage GoToCoronavirusNews()
        {
            _webDriver.FindElement(_coronavirusButton).Click();
            return new CoronavirusPage(_webDriver);
        }
       
    }
}
