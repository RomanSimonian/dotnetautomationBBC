using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecFlowProject1.Pages
{
    internal class FootballPage : BasePage
    {
        public FootballPage(WebDriver driver) : base(driver) { }

        public void ClickOnSelectLeague(string league)
        {
            driver.FindElement(By.XPath($"//span[text()='{league}']")).Click();

        }
    }
}
