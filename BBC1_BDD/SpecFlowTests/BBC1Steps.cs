using BBC1_Project.PageObjects;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using NUnit.Framework;
using System;
using TechTalk.SpecFlow;
using FluentAssertions;
using System.Collections.Generic;
using System.Data;

namespace BBC1_BDD.SpecFlowTests
{
    [Binding]
    public class BBC1Steps
    {
        private WebDriver _webDriver;

        [Before]
        public void SetUp()
        {
            _webDriver = new ChromeDriver();
            _webDriver.Manage().Window.Maximize();
            _webDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
        }
        [After]
        public void TearDown()
        {
            _webDriver.Quit();
        }
        [Given(@"User opens '(.*)'")]
        public void GivenUserOpens(string url)
        {
            _webDriver.Navigate().GoToUrl(url);
        }

        [When(@"User click to the News")]
        public void WhenUserClickToTheNews()
        {
            var homePage = new HomePage(_webDriver);
            homePage.ClickNews();
        }

        [Then(@"User checks the title of the main article with '(.*)'")]
        public void ThenUserChecksTheTitleOfTheMainArticleWith(string text)
        {
            var newsPage = new NewsPage(_webDriver);
            newsPage.GetTextHeadlineArticles().Should().ContainEquivalentOf(text);
        }
        [Then(@"User checks actual list secondary article titles with expected \[""(.*)"", ""(.*)"",""(.*)"", ""(.*)"", ""(.*)""]")]
        public void ThenUserChecksActualListSecondaryArticleTitlesWithExpected(string art1, string art2, string art3, string art4, string art5)
        {
            var newsPage = new NewsPage(_webDriver);
            newsPage.GetAllSecondaryArticleTitles().Should().Equal(new List<String>() {art1, art2, art3, art4, art5 });
        }
        [Then(@"User checks the name of the first article with '(.*)'")]
        public void ThenUserChecksTheNameOfTheFirstArticleWith(string firstArticle)
        {
            var newsPage = new NewsPage(_webDriver);
            newsPage.SearchByWord(newsPage.GetCategoryHeadlineArticle()).
                GetArticleNumber(1).Should().ContainEquivalentOf(firstArticle);
        }
        [When(@"User chooses Coronavirus news")]
        public void WhenUserChoosesCoronavirusNews()
        {
            var newsPage = new NewsPage(_webDriver);
            newsPage.GoToCoronavirusNews();
        }

        [When(@"User choses Coronavirus stories")]
        public void WhenUserChosesCoronavirusStories()
        {
            var coronavirusPage = new CoronavirusPage(_webDriver);
            coronavirusPage.GoToCoronavirusStories();
        }

        [When(@"User choses ask questions")]
        public void WhenUserChosesAskQuestions()
        {
            var coronavirusPage = new CoronavirusPage(_webDriver);
            coronavirusPage.GoToAskAQuestion();
        }

        [Then(@"Filled out the form without question and corrected the error '(.*)'t be blank'")]
        public void ThenFilledOutTheFormWithoutQuestionAndCorrectedTheErrorTBeBlank(string errorMessage)
        {
            var coronavirusPage = new CoronavirusPage(_webDriver);
            coronavirusPage.FillTheFormWithInformationNotQuestion().Should().ContainEquivalentOf(errorMessage);
        }


    }
}
