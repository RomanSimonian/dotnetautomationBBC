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
        public void ClickOnGoToCategory(string category)
        {
            driver.FindElement(By.XPath($"//div[@id='orb-nav-links']/ul/li/a[text()='{category}']")).Click();
        }

        public void OpenHomePage(String url)
        {
            driver.Navigate().GoToUrl(url);
        }

        public bool IsButtonNewsVisible() { return goToNews.Displayed; }

        public HomePage(WebDriver driver) : base(driver) { }

    }
}
