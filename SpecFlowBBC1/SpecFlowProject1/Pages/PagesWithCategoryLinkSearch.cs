using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecFlowProject1.Pages
{
    internal class PagesWithCategoryLinkSearch : BasePage
    {
        [FindsBy(How = How.XPath, Using = "//a[@href='https://www.bbc.co.uk/programmes/p00fqcb2']//span/p/span")]
        private IWebElement firstNewArticleWirhSearch;


        public bool IsFirstArticleVisible() { return firstNewArticleWirhSearch.Displayed; }
        public string GetFirstNewArticleWithSearch() { return firstNewArticleWirhSearch.Text; }

        public PagesWithCategoryLinkSearch(WebDriver driver) : base(driver) { }
    }
}
