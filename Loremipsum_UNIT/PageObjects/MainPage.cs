using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loremipsum_Tests.PageObjects
{
    class MainPage
    {
        private readonly IWebDriver webDriver;

        private readonly By _rusLanguage = By.XPath("//a[@href='http://ru.lipsum.com/']");
        private readonly By _generatelorem = By.XPath("//input[@id='generate']");
        private readonly By _rusParagraph1 = By.XPath("//h2[text()='Что такое Lorem Ipsum?']/following-sibling::p");
        private readonly By _entryfield = By.XPath("//input[@id='amount']");
        private readonly By _checkboxBeginWithLorem = By.XPath("//input[@type='checkbox']");

        public MainPage(IWebDriver webDriver)
        {
            this.webDriver = webDriver;
        }

        public MainPage ChooseRusLanguage()
        {
            webDriver.FindElement(_rusLanguage).Click();
            return this;
        }

        public string GetRusTextFirstParagraph()
        {
            return webDriver.FindElement(_rusParagraph1).Text;
        }

        public ResultPage GenerateLorem()
        {
            webDriver.FindElement(_generatelorem).Click();
            return new ResultPage(webDriver);
        }

        public MainPage GetCheckboxBeginWithLorem()
        {
            webDriver.FindElement(_checkboxBeginWithLorem).Click();
            return this;
        }

        public MainPage GetInputInEntryField(int count)
        {
            webDriver.FindElement(_entryfield).Click();
            webDriver.FindElement(_entryfield).Clear();
            webDriver.FindElement(_entryfield).SendKeys(count.ToString());
            return this;
        }

        public void GetGenerator(int count, string element)
        {
            GetInputInEntryField(count);
            webDriver.FindElement(By.XPath($"//label[@for='{element}']")).Click();
            GenerateLorem();
        }
    }
}
