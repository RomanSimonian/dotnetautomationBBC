using OpenQA.Selenium;


namespace BBC1withLoremIpsum.PageObjects
{
    public class SearchPage: BasePage
    {
        public SearchPage(IWebDriver _webDriver) : base(_webDriver) { }

        public string GetArticleNumber(int number)
        {
            return _webDriver.FindElement(By.XPath($"(//a[contains(@class,'PromoLink')]//p)[{number}]")).GetAttribute("innerText");
        }
       
    }
}
