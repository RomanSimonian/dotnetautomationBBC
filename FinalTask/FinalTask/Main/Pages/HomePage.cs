using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;

namespace FinalTask.Main.Pages
{
    public class HomePage : BasePage
    {
        [FindsBy(How = How.XPath, Using = @"//div[@id='orb-nav-links']//li[@class='orb-nav-newsdotcom']")]
        private IWebElement _newsPage;

        public HomePage(IWebDriver driver) : base(driver)
        {
        }

        public NewsPage GoToNewsPage()
        {
            _newsPage.Click();
            return new NewsPage(Driver);
        }
    }
}
