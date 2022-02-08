using BBC1withLoremIpsum.PageObjects;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using TechTalk.SpecFlow;
using FluentAssertions;
using NUnit.Framework;

namespace BBC1withLoremIpsum.SpecFlowTests
{
    [Binding]
    public class BBC1withLoremipsumSteps
    {
        private WebDriver _webDriver;
        private string _question;
        private int _averageNumberLorem;

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
        [Given(@"User opens '(.*)' page")]
        public void GivenUserOpensPage(string page)
        {
            _webDriver.Navigate().GoToUrl(page);
        }

        [When(@"User chooses Russian language")]
        public void WhenUserChoosesRussianLanguage()
        {
            var loremHome = new LoremHome(_webDriver);
            loremHome.ChooseRusLanguage();
        }

        [Then(@"User checks that text first paragraph contains word '(.*)'")]
        public void ThenUserChecksThatTextFirstParagraphContainsWord(string word)
        {
            var loremHome = new LoremHome(_webDriver);
            Assert.True(loremHome.GetRusTextFirstParagraph().Contains(word));
        }
        [When(@"User generates a new lorem")]
        public void WhenUserGeneratesANewLorem()
        {
            var loremHome = new LoremHome(_webDriver);
            loremHome.GenerateLorem();
        }

        [Then(@"User checks that the created Lorem starts with text '(.*)'")]
        public void ThenUserChecksThatTheCreatedLoremStartsWithText(string text)
        {
            var loremResult = new LoremResult(_webDriver);
            Assert.True(loremResult.GetTextParagraph(1).StartsWith(text));
        }

        [When(@"User input an element '(.*)' and count (.*)")]
        public void WhenUserInputAnElementAndCount(string element, int count)
        {
            var loremHome = new LoremHome(_webDriver);
            loremHome.GetGenerator(count, element);
        }

        [Then(@"User Checking created '(.*)' lorem is the (.*)")]
        public void ThenUserCheckingCreatedLoremIsThe(string element, int expected_result)
        {
            var loremResult = new LoremResult(_webDriver);
            Assert.IsTrue(loremResult.GetActualSize(element).Equals(expected_result));
        }

        [When(@"User disables checkbox begin with lorem")]
        public void WhenUserDisablesCheckboxBeginWithLorem()
        {
            var loremHome = new LoremHome(_webDriver);
            loremHome.GetCheckboxBeginWithLorem();
        }

        [Then(@"User checking created lorem not start with '(.*)'")]
        public void ThenUserCheckingCreatedLoremNotStartWith(string text)
        {
            var loremResult = new LoremResult(_webDriver);
            Assert.IsFalse(loremResult.GetTextParagraph(1).StartsWith(text));
        }
        [When(@"User generates (.*) text with lorem")]
        public int WhenUserGeneratesTextWithLorem(int times)
        {
            var loremHome = new LoremHome(_webDriver);
            _averageNumberLorem = loremHome.GeneratorInQuantity(times);
            return _averageNumberLorem;
        }
        [Then(@"Compares that the average number is greater than (.*)")]
        public void ThenComparesThatTheAverageNumberIsGreaterThan(int number)
        {
            Assert.IsTrue(_averageNumberLorem >= number);
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

        [Then(@"User checks actual list secondary article titles with expected list")]
        public void ThenUserChecksActualListSecondaryArticleTitlesWithExpectedList(Table table)
        {
            var newsPage = new NewsPage(_webDriver);
            newsPage.GetAllSecondaryArticleTitles()
                .Should().BeEquivalentTo(newsPage.ToListSecondaryArticles(table));
        }

        [Then(@"User checks the name of the first article with '(.*)'")]
        public void ThenUserChecksTheNameOfTheFirstArticleWith(string firstArticle)
        {
            var newsPage = new NewsPage(_webDriver);
            newsPage.SearchByWord(newsPage.GetCategoryHeadlineArticle())
                .GetArticleNumber(1).Should().ContainEquivalentOf(firstArticle);
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

        [Then(@"Filled out the form witout '(.*)' and corrected the error '(.*)'")]
        public void ThenFilledOutTheFormWitoutAndCorrectedTheError(string field, string message)
        {
            var coronavirusPage = new CoronavirusPage(_webDriver);
            coronavirusPage.FillOutTheFormWithout(field,_question).Should().BeEquivalentTo(message);
        }
        [Given(@"User generates the text of the question")]
        public void GivenUserGeneratesTheTextOfTheQuestion()
        {
            var basePage = new BasePage(_webDriver);
            _question =  basePage.GenerateLoremQuestion();
        }
    }
}
