using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecFlowProject1.Pages
{
    internal class SportPage : BasePage
    {
        [FindsBy(How = How.XPath, Using = "//div[contains(@class,'sp-c-sport-navigation')]//a[@data-stat-title='Football']")]
        private IWebElement goToFootball;

        public void ClickOnGoToFootball() { goToFootball.Click(); }

        public SportPage(WebDriver driver) : base(driver) { }
    }
}
