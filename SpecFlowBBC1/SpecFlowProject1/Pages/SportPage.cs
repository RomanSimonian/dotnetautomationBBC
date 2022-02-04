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
        public SportPage(WebDriver driver) : base(driver) { }

        public void ClickOnCategoryButton(string category)
        {
            var button = driver.FindElement(By.XPath($"//div[contains(@class,'sp-c-sport-navigation')]//a[@data-stat-title='{category}']"));
        }
    }
}
