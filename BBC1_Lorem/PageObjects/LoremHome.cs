using BBC1withLoremIpsum.PageObjects;
using OpenQA.Selenium;

namespace BBC1withLoremIpsum.PageObjects
{
    class LoremHome: BasePage
    {
        private readonly By _generateLorem = By.XPath("//input[@id='generate']");
        private readonly By _rusText = By.XPath("//h2[text()='Что такое Lorem Ipsum?']/following-sibling::p");
        private readonly By _entryField = By.XPath("//input[@id='amount']");
        private readonly By _checkboxBeginWithLorem = By.XPath("//input[@type='checkbox']");
        private readonly By _rusLanguage = By.XPath("//a[@href='http://ru.lipsum.com/']");

        public LoremHome(IWebDriver _webDriver) : base(_webDriver) { }

        public LoremHome ChooseRusLanguage()
        {
            _webDriver.FindElement(_rusLanguage).Click();
            return this;
        }

        public string GetRusTextFirstParagraph()
        {
            return _webDriver.FindElement(_rusText).Text;
        }

        public LoremResult GenerateLorem()
        {
            _webDriver.FindElement(_generateLorem).Click();
            return new LoremResult(_webDriver);
        }

        public LoremHome GetCheckboxBeginWithLorem()
        {
            _webDriver.FindElement(_checkboxBeginWithLorem).Click();
            return this;
        }

        public LoremHome GetInputInEntryField(int count)
        {
            _webDriver.FindElement(_entryField).Click();
            _webDriver.FindElement(_entryField).Clear();
            _webDriver.FindElement(_entryField).SendKeys(count.ToString());
            return this;
        }

        public void GetGenerator(int count, string element)
        {
            GetInputInEntryField(count);
            _webDriver.FindElement(By.XPath($"//label[@for='{element}']")).Click();
            GenerateLorem();
        }
        public int GeneratorInQuantity(int times)
        {
            int result = 0;
            for (int i = 0; i < times; i++)
            {
                result += GenerateLorem().GetCountParagraphWithLorem();
                _webDriver.Navigate().Back();
            }
            return result / times;
        }
    }
}
