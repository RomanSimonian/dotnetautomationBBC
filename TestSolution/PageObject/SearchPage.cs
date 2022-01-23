using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestSolution.PageObject
{
    public class SearchPage : Page
    {
        
        private readonly By _firstTitle = By.XPath("//*[@id='main-content']//ul/li[1]//a/span");

        public SearchPage(IWebDriver driver):base(driver)
        {
        }

        public string GetFirstTitleTextOnSearchPage()
        {
            return driver.FindElement(_firstTitle).Text;
        }
    }
}
