using BBC1_Project.PageObjects;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;

namespace BBC1_Project.Tests
{
    public class UnitTest
    {
        private IWebDriver _webDriver;
        private readonly string _urlBBC = "https://www.bbc.com/";

        private readonly string _headlineArticle = "Invasion of Ukraine would be 'horrific', US warns";
        private readonly List<string> _secondaryArticles = new List<string> 
        {
            "'Bombogenesis' snowstorm sweeping US East coast",
            "Parties report to be delivered to UK PM shortly",
            "Peru tsunami oil spill worse than first thought", 
            "Gun used by Kyle Rittenhouse to be destroyed", 
            "Joni Mitchell wants songs off Spotify in Covid row"
        };
        private readonly string _storiesArticle = "World";
        private readonly string _errorMessageNotQuestion = "can't be blank";
        private readonly string _errorMessageNotAccept = "must be accepted";
        private readonly string _errorMessageNotEmail = "Email address can't be blank";

        [SetUp]
        public void Setup()
        {
            _webDriver = new ChromeDriver();
            _webDriver.Manage().Cookies.DeleteAllCookies();
            _webDriver.Navigate().GoToUrl(_urlBBC);
            _webDriver.Manage().Window.Maximize();
            _webDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
        }

        [Test]
        public void ChecksTheNameOfTheHeadlineArticle()
        {
            var homePage = new HomePage(_webDriver);
            Assert.True(homePage.ClickNews().
                GetTextHeadlineArticles().Contains(_headlineArticle));
        }

        [Test]
        public void ChecksSecondaryArticleTitles()
        {
            var homePage = new HomePage(_webDriver);
            Assert.AreEqual(homePage.ClickNews().
                GetAllSecondaryArticleTitles(), _secondaryArticles);

        }

        [Test]
        public void ChecksTheNameOfTheFirstArticle()
        {
            var homePage = new HomePage(_webDriver);
            var newsPage = new NewsPage(_webDriver);
            Assert.AreEqual(homePage.ClickNews().
                SearchByWord(newsPage.GetCategoryHeadlineArticle()).
                GetArticleNumber(1), _storiesArticle);
        }

        [Test]
        public void ChecksThatUserCanSubmitQuestionWithoutQuestion()
        {
            var homePage = new HomePage(_webDriver);
            Assert.AreEqual(homePage.ClickNews().
                GoToCoronavirusNews().
                GoToCoronavirusStories().
                GoToAskAQuestion().
                FillTheFormWithInformationNotQuestion(), _errorMessageNotQuestion);
        }
        [Test]
        public void ChecksThatUserCanSubmitQuestionWithoutAccept()
        {
            var homePage = new HomePage(_webDriver);
            Assert.AreEqual(homePage.ClickNews().
                GoToCoronavirusNews().
                GoToCoronavirusStories().
                GoToAskAQuestion().
                FillTheFormWithInformationNotAccept(), _errorMessageNotAccept);
        }
        [Test]
        public void ChecksThatUserCanSubmitQuestionWithoutEmail()
        {
            var homePage = new HomePage(_webDriver);
            Assert.AreEqual(homePage.ClickNews().
                GoToCoronavirusNews().
                GoToCoronavirusStories().
                GoToAskAQuestion().
                FillTheFormWithInformationNotEmail(), _errorMessageNotEmail);
        }

        [TearDown]
        public void TearDown()
        {
            _webDriver.Quit();
        }
    }
}