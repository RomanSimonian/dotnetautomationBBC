using OpenQA.Selenium;


namespace BBC1withLoremIpsum.PageObjects
{
    public class HomePage : BasePage
    {
        private readonly By buttonNews = By.XPath("//nav//li[contains(@class,'news')]");
        public HomePage(IWebDriver _webDriver) : base(_webDriver) { }

        public NewsPage ClickNews()
        {
            _webDriver.FindElement(buttonNews).Click();
            return new NewsPage(_webDriver);
        }
        
    }
}
