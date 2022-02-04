using System;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;






namespace BBC.classesForTest
{
    public class PagesWithCategoryLinkSearch : BasePage
    {
        public PagesWithCategoryLinkSearch(WebDriver driver) : base(driver) { }

        public string GetTextFromTitle(int titleNumber)
        {
            return driver.FindElement(By.XPath($"//li[{titleNumber}]//span[@aria-hidden]")).Text;
        }
    }
}
