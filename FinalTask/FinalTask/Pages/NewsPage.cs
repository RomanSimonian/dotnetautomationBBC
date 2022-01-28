using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;

namespace FinalTask.Pages
{
    public class NewsPage : BasePage
    {
        [FindsBy(How = How.XPath, Using = @"//ul[@class='gs-o-list-ui--top-no-border nw-c-nav__wide-sections']//a[@href='/news/coronavirus']")]
        private IWebElement _coronavirusPage;

        public NewsPage(IWebDriver driver) : base(driver) {}

        public CoronavirusPage GoToCoronavirusPage()
        {
            _coronavirusPage.Click();
            return new CoronavirusPage(Driver);
        }
    }
}