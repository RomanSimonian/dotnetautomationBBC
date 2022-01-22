using System;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;






namespace BBC.classesForTest
{
    public class PagesWithCategoryLinkSearch : BasePage
    {
        [FindsBy(How = How.XPath, Using = "//a[@href='https://www.bbc.co.uk/programmes/p02cfn9y']")]
        private IWebElement firstNewArticleWirhSearch;

        public string GetFirstNewArticleWirhSearch() { return firstNewArticleWirhSearch.Text; }

        public PagesWithCategoryLinkSearch(WebDriver driver) : base(driver) { }
    }
}
