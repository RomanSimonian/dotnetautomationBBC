using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loremipsum_Tests.PageObjects
{
    class MainMenuPageObject
    {
        private IWebDriver webDriver;

        private readonly By _rusLanguage = By.XPath("//a[@href='http://ru.lipsum.com/']");
        private readonly By _generatelorem = By.XPath("//input[@id='generate']");
        private readonly By _rusParagraph1 = By.XPath("//h2[text()='Что такое Lorem Ipsum?']/following-sibling::p");
        private readonly By _entryfield = By.XPath("//input[@id='amount']");
        private readonly By _checkboxBeginWithLorem = By.XPath("//input[@type='checkbox']");

        public MainMenuPageObject(IWebDriver webDriver)
        {
            this.webDriver = webDriver;
        }

        public void ChooseRusLanguage()
        {
            webDriver.FindElement(_rusLanguage).Click();
        }

        public string GetRusTextFirstParagraph()
        {
            return webDriver.FindElement(_rusParagraph1).Text;
        }

        public ResultPageObject GenerateLorem()
        {
            webDriver.FindElement(_generatelorem).Click();
            return new ResultPageObject(webDriver);
        }

        public void GetCheckboxBeginWithLorem()
        {
            webDriver.FindElement(_checkboxBeginWithLorem).Click();
        }

        public void GetInputInEntryField(int count)
        {
            webDriver.FindElement(_entryfield).Click();
            webDriver.FindElement(_entryfield).Clear();
            webDriver.FindElement(_entryfield).SendKeys(count.ToString());
        }

        public void GetGenerator(int count, string element)
        {
            GetInputInEntryField(count);
            webDriver.FindElement(By.XPath("//label[@for='" + element + "']")).Click();
            GenerateLorem();
        }



    }
}
