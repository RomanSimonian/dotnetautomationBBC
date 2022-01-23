using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestSolution.PageObject 
{
    public class HomePage:Page
    {

        private readonly By _NewsButton = By.XPath("//a[text()='News']");

        public HomePage(IWebDriver driver):base(driver)
        {
        }

        public NewsPage GoToNewsPage()
        {
            var news = driver.FindElement(_NewsButton);
            news.Click();
            return new NewsPage(driver);
        }

    }
}
