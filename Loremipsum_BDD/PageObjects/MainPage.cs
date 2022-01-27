using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loremipsum_BDD.PageObjects
{
    public class MainPage
    {
        private readonly IWebDriver _webDriver;
        
        private readonly By _rusLanguage = By.XPath("//a[@href='http://ru.lipsum.com/']");
        private readonly By _generateLorem = By.XPath("//input[@id='generate']");
        private readonly By _rusText = By.XPath("//h2[text()='Что такое Lorem Ipsum?']/following-sibling::p");
        private readonly By _entryField = By.XPath("//input[@id='amount']");
        private readonly By _checkboxBeginWithLorem = By.XPath("//input[@type='checkbox']");

        public MainPage(IWebDriver webDriver)
        {
            _webDriver = webDriver;
        }

        public MainPage ChooseRusLanguage()
        {
            _webDriver.FindElement(_rusLanguage).Click();
            return this;
        }

        public string GetRusText()
        {
            return _webDriver.FindElement(_rusText).Text;
        }

        public ResultPage GenerateLorem()
        {
            _webDriver.FindElement(_generateLorem).Click();
            return new ResultPage(_webDriver);
        }

        public MainPage GetCheckboxBeginWithLorem()
        {
            _webDriver.FindElement(_checkboxBeginWithLorem).Click();
            return this;
        }

        public MainPage GetInputInEntryField(int count)
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
            int actualResult = 0;
            for (int i = 0; i < times; i++)
            {
                GenerateLorem();
                var resultPage = new ResultPage(_webDriver);
                actualResult += resultPage.GetCountParagraphWithLorem();
                _webDriver.Navigate().Back();
            }
            return actualResult;
        }

    }
}
