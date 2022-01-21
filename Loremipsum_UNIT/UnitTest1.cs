using Loremipsum_Tests.PageObjects;
using NUnit.Framework;
using OpenQA.Selenium;
using System;

namespace Loremipsum_Tests
{
    public class Tests
    {
        private IWebDriver webDriver;
        private const string searchWord = "рыба";
        private const string searchText = "Lorem ipsum dolor sit amet, consectetur adipiscing elit";
        private const int numberOfChecks = 10;

        [SetUp]
        public void Setup()
        {
            webDriver = new OpenQA.Selenium.Chrome.ChromeDriver();
            webDriver.Navigate().GoToUrl("https://lipsum.com/");
            webDriver.Manage().Window.Maximize();
            webDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
        }

        [Test]
        public void CheckTextContainsWord()
        {
            var mainMenu = new MainPage(webDriver);
            mainMenu.ChooseRusLanguage();
            Assert.True(mainMenu.GetRusTextFirstParagraph().Contains(searchWord));
        }

        [Test]
        public void CheckCreateLoremStartWithText()
        {
            var mainMenu = new MainPage(webDriver);
            mainMenu.GenerateLorem();
            var resultPage = new ResultPage(webDriver);
            Assert.True(resultPage.GetTextParagraph(1).StartsWith(searchText));
        }

        [Test]
        public void CheckCreateWordsIsActual()
        {
            var mainMenu = new MainPage(webDriver);
            var resultPage = new ResultPage(webDriver);

            mainMenu.GetGenerator(10, "words");
            Assert.IsTrue(resultPage.GetWordsActualSize().Equals(10));
            webDriver.Navigate().Back();
            mainMenu.GetGenerator(0, "words");
            Assert.IsTrue(resultPage.GetWordsActualSize().Equals(5));
            webDriver.Navigate().Back();
            mainMenu.GetGenerator(-1, "words");
            Assert.IsTrue(resultPage.GetWordsActualSize().Equals(5));
            webDriver.Navigate().Back();
            mainMenu.GetGenerator(20, "words");
            Assert.IsTrue(resultPage.GetWordsActualSize().Equals(20));
            webDriver.Navigate().Back();
            mainMenu.GetGenerator(5, "words");
            Assert.IsTrue(resultPage.GetWordsActualSize().Equals(5));
        }

        [Test]
        public void CheckCreateCharsIsActual()
        {
            var mainMenu = new MainPage(webDriver);
            var resultPage = new ResultPage(webDriver);

            mainMenu.GetGenerator(10, "bytes");
            Assert.IsTrue(resultPage.GetBytesActualSize().Equals(10));
            webDriver.Navigate().Back();
            mainMenu.GetGenerator(-10, "bytes");
            Assert.IsTrue(resultPage.GetBytesActualSize().Equals(5));
            webDriver.Navigate().Back();
            mainMenu.GetGenerator(0, "bytes");
            Assert.IsTrue(resultPage.GetBytesActualSize().Equals(5));
        }

        [Test]
        public void CheckCreateLoremNotStartWithText()
        {
            var mainMenu = new MainPage(webDriver);
            var resultPage = new ResultPage(webDriver);

            mainMenu.GetCheckboxBeginWithLorem();
            mainMenu.GenerateLorem();
            Assert.IsFalse(resultPage.GetTextParagraph(1).StartsWith(searchText));

        }

        [Test]
        public void CheckProbabilityContainsWordLorem()
        {
            var mainPage = new MainPage(webDriver);
            var resultPage = new ResultPage(webDriver);
            int actualResult = 0;

            for (int i = 0; i < numberOfChecks; i++)
            {
                mainPage.GenerateLorem();
                actualResult += resultPage.GetCountParagraphWithLorem();
                webDriver.Navigate().Back();
            }
            Assert.IsTrue(actualResult / numberOfChecks >= 2);
        }

        [TearDown]
        public void TearDown()
        {
            webDriver.Quit();
        }
    }
}

