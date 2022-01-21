using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecFlowProject1.Pages
{
    internal class HomePage : BasePage
    {
        [FindsBy(How = How.XPath, Using = "//a[@href='https://www.bbc.com/news']")]
        private IWebElement goToNews;

        [FindsBy(How = How.XPath, Using = "//a[@href='https://www.bbc.com/sport']")]
        private IWebElement goToSport;

        public void OpenHomePage(String url)
        {
            driver.Navigate().GoToUrl(url);
        }

        public bool IsButtonNewsVisible() { return goToNews.Displayed; }

        public void ClickOnGoToNews() { goToNews.Click(); }

        public void ClickOnGoToSport() { goToSport.Click(); }

        public HomePage(WebDriver driver) : base(driver) { }

    }
}
