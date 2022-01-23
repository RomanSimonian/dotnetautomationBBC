using Loremipsum_BDD.PageObjects;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using TechTalk.SpecFlow;

namespace Loremipsum_BDD.SpecFlowTests
{
    [Binding]
    public class LoremipsumSteps
    {
        private  WebDriver _webDriver;

        [Before]
        public void SetUp()
        {
            _webDriver = new OpenQA.Selenium.Chrome.ChromeDriver();
            _webDriver.Manage().Window.Maximize();
            _webDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
        }
        [After]
        public void TearDown()
        {
            _webDriver.Quit();
        }

        [Given(@"User opens '(.*)' page")]
        public void GivenUserOpensPage(string page)
        {
            _webDriver.Navigate().GoToUrl(page);
        }
        
        [When(@"User chooses Russian language")]
        public void WhenUserChoosesRussianLanguage()
        {
            var mainPage = new MainPage(_webDriver);
            mainPage.ChooseRusLanguage();
        }
        
        [Then(@"User checks that text first paragraph contains word '(.*)'")]
        public void ThenUserChecksThatTextFirstParagraphContainsWord(string word)
        {
            var mainPage = new MainPage(_webDriver);
            Assert.True(mainPage.GetRusTextFirstParagraph().Contains(word));
        }
        [When(@"User generates a new lorem")]
        public void WhenUserGeneratesANewLorem()
        {
            var mainPage = new MainPage(_webDriver);
            mainPage.GenerateLorem();
        }

        [Then(@"User checks that the created Lorem starts with text '(.*)'")]
        public void ThenUserChecksThatTheCreatedLoremStartsWithText(string text)
        {
            var resultPage = new ResultPage(_webDriver);
            Assert.True(resultPage.GetTextParagraph(1).StartsWith(text));
        }

        [When(@"User input an element '(.*)' and count (.*)")]
        public void WhenUserInputAnElementAndCount(string element, int count)
        {
            var mainPage = new MainPage(_webDriver);
            mainPage.GetGenerator(count, element);
        }

        [Then(@"User Checking created '(.*)' lorem is the (.*)")]
        public void ThenUserCheckingCreatedLoremIsThe(string element, int expected_result)
        {
            var resultPage = new ResultPage(_webDriver);
            Assert.IsTrue(resultPage.GetActualSize(element).Equals(expected_result));
        }

        [When(@"User disables checkbox begin with lorem")]
        public void WhenUserDisablesCheckboxBeginWithLorem()
        {
            var mainPage = new MainPage(_webDriver);
            mainPage.GetCheckboxBeginWithLorem();
        }

        [Then(@"User checking created lorem not start with '(.*)'")]
        public void ThenUserCheckingCreatedLoremNotStartWith(string text)
        {
            var resultPage = new ResultPage(_webDriver);
            Assert.IsFalse(resultPage.GetTextParagraph(1).StartsWith(text));
        }
        [Then(@"User generates (.*) text with lorem compares the average number of lorem words with (.*)")]
        public void ThenUserGeneratesTextWithLoremComparesTheAverageNumberOfLoremWordsWith(int times, int expected_result)
        {
            var mainPage = new MainPage(_webDriver);
            Assert.IsTrue(mainPage.GeneratorInQuantity(times) / times >= expected_result);
        }

    }
}
