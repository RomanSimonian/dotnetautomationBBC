using BBC.classesForTest;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;


namespace BBC.classesForTestBBC1
{
    public class CoronavirusPage : BasePage
    {
        [FindsBy(How = How.XPath, Using = "//div[@class='gs-u-display-none gs-u-display-block@m']//a[@href='/news/have_your_say']")]
        private IWebElement coronavirusStories;

        [FindsBy(How = How.XPath, Using = "//a[@href='/news/52143212']")]
        private IWebElement formForStories;

        [FindsBy(How = How.XPath, Using = "//button[@aria-label='Close']")]
        public IWebElement closeBanner;

        [FindsBy(How = How.XPath, Using = "//div[@class='input-error-message']")]
        private IWebElement errorMessage;

        public string GetErrorMessage() { return errorMessage.Text; }

        public void ClickCloseBanner() { closeBanner.Click(); }

        public void GoToFormStories() { formForStories.Click(); }

        public void ClickOnCoronavirusStories() { coronavirusStories.Click(); }

        public CoronavirusPage(WebDriver driver) : base(driver) { }
    }
}
