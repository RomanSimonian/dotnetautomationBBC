using OpenQA.Selenium;


namespace BBC1_Project.PageObjects
{
    public class CoronavirusPage : BasePage
    {
        private readonly By _coronavirusStoriesButton = By.XPath("//li[contains(@class,'left nw-c-nav__secondary')]");
        private readonly By _coronavirusQuestion = By.XPath("//a[@href='/news/52143212']");
        private readonly By _inputQuestion = By.XPath("//div[@class='long-text-input-container']/child::textarea");
        private readonly By _inputName = By.XPath("//input[@placeholder='Name']");
        private readonly By _inputEmailAdress = By.XPath("//input[@placeholder='Email address']");
        private readonly By _inputContactNumber = By.XPath("//input[@placeholder='Contact number']");
        private readonly By _inputLocation = By.XPath("//input[@placeholder='Location ']");
        private readonly By _inputAge = By.XPath("//input[@placeholder='Age']");
        private readonly By _checkboxIaccept = By.XPath("//input[@type='checkbox']");
        private readonly By _submitButton = By.XPath("//button[text()='Submit']");
        private readonly By _errorMessage = By.XPath("//div[@class='input-error-message']");

        public CoronavirusPage(IWebDriver _webDriver) : base(_webDriver) { }

        public CoronavirusPage GoToCoronavirusStories()
        {
            _webDriver.FindElement(_coronavirusStoriesButton).Click();
            WaitForPageLoad();
            return this;
        }
        public CoronavirusPage GoToAskAQuestion()
        {
            ((IJavaScriptExecutor)_webDriver).ExecuteScript("javascript:window.scrollBy(0,500)");
            WaitForPageLoad();
            WaitForElement(_webDriver.FindElement(_coronavirusQuestion));
            CloseWindowRegistration();
            _webDriver.FindElement(_coronavirusQuestion).Click();
            return this;
        }
        public string FillTheFormWithInformationNotQuestion()
        {
            ((IJavaScriptExecutor)_webDriver).ExecuteScript("javascript:window.scrollBy(0,1200)");
            _webDriver.FindElement(_inputName).SendKeys("Alex");
            _webDriver.FindElement(_inputEmailAdress).SendKeys("Alex@ukr.net");
            _webDriver.FindElement(_inputContactNumber).SendKeys("12345678");
            _webDriver.FindElement(_inputLocation).SendKeys("USA");
            _webDriver.FindElement(_inputAge).SendKeys("100");
            _webDriver.FindElement(_checkboxIaccept).Click();
            _webDriver.FindElement(_submitButton).Click();
            return _webDriver.FindElement(_errorMessage).Text;
        }
        public string FillTheFormWithInformationNotAccept()
        {
            ((IJavaScriptExecutor)_webDriver).ExecuteScript("javascript:window.scrollBy(0,1200)");
            _webDriver.FindElement(_inputQuestion).SendKeys("OK");
            _webDriver.FindElement(_inputName).SendKeys("Alex");
            _webDriver.FindElement(_inputEmailAdress).SendKeys("Alex@ukr.net");
            _webDriver.FindElement(_inputContactNumber).SendKeys("12345678");
            _webDriver.FindElement(_inputLocation).SendKeys("USA");
            _webDriver.FindElement(_inputAge).SendKeys("100");
            _webDriver.FindElement(_submitButton).Click();
            return _webDriver.FindElement(_errorMessage).Text;
        }

        public string FillTheFormWithInformationNotEmail()
        {
            ((IJavaScriptExecutor)_webDriver).ExecuteScript("javascript:window.scrollBy(0,1200)");
            _webDriver.FindElement(_inputQuestion).SendKeys("OK");
            _webDriver.FindElement(_inputName).SendKeys("Alex");
            _webDriver.FindElement(_inputContactNumber).SendKeys("12345678");
            _webDriver.FindElement(_inputLocation).SendKeys("USA");
            _webDriver.FindElement(_inputAge).SendKeys("100");
            _webDriver.FindElement(_checkboxIaccept).Click();
            _webDriver.FindElement(_submitButton).Click();
            return _webDriver.FindElement(_errorMessage).Text;
        }



    }
}

