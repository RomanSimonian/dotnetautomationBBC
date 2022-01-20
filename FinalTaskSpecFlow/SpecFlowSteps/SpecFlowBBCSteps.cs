using FinalTask_BBC2_Bogdanov.SpecFlowSteps;
using NUnit.Framework;
using System;
using TechTalk.SpecFlow;

namespace FinalTaskSpecFlow.SpecFlowSteps
{
    [Binding]
    public class SpecFlowBBCSteps : BaseStepDefinitions
    {
        [Given(@"User goes to bbc main page")]
        public void GivenUserGoesToBbc_Com()
        {
            Home_Page = new FinalTask_BBC2_Bogdanov.Pages.HomePage(Driver);
        }

        [When(@"User clicks news button")]
        public void WhenUserClicksNewsButton()
        {
            News_Page = Home_Page.GoToNewsPage();
        }

        [Then(@"User can see main news equals (.*)")]
        public void ThenUserCanSeeMainNewsEquals(string mainArticleName)
        {
            Assert.IsTrue(News_Page.GetMainArticlString().ToLower().Contains(mainArticleName.ToLower()));
        }

        [Given(@"User goes to sport page")]
        public void GivenUserGoesToSportPage()
        {
            Sport_Page = Home_Page.goToSportPage();
        }

        [Given(@"User navigates to Football")]
        public void GivenUserNavigatesToFootball()
        {
            Sport_Page.GetFottballButton().Click();
        }

        [Given(@"User navigates to Scores & Fixtures page")]
        public void GivenUserNavigatesToScoresFixturesPage()
        {
            Score_Page = Sport_Page.GoToScorePage();
        }


        [Given(@"User enter the name of the ""(.*)"" in searchInput")]
        public void GivenEnterTheNameOfTheInSearchInput(string championship)
        {
            Score_Page.EnterChempionshipInput(championship);
            Score_Page.GetSearchInputForClick().Click();
        }

        [When(@"User click on the date  ""(.*)"" and ""(.*)""")]
        public void WhenIClickOnTheDateAnd(string year, string month)
        {
            Score_Page.GetYearMonthElementToClick(month, year).Click();
        }

        [Then(@"User can see scores of the ""(.*)"" - ""(.*)"" and ""(.*)"" - ""(.*)""")]
        public void ThenICanSeeScoresOfThe_And_(string team1, string score1, string team2, string score2)
        {
            Assert.IsTrue(Score_Page.GetScoreTeamElement(team1 + " " + score1 + " : " + score2 + " " + team2));
        }

        [Given(@"User click on the date  ""(.*)"" and ""(.*)""")]
        public void GivenUserClickOnTheDateAnd(string month, string year)
        {
            Score_Page.GetYearMonthElementToClick(year, month).Click();
        }

        [When(@"User click on the scores of the ""(.*)"" - ""(.*)"" and ""(.*)"" - ""(.*)""")]
        public void WhenUserClickOnTheScoresOfThe_And_(string team1, int score1, string team2, int score2)
        {
            TeamScore_Page = Score_Page.ToGoTeamScorePage(Score_Page.GetScoreTeamElement(team1 + " " + score1 + " : " + score2 + " " + team2, true));
        }

        [Then(@"User can see the same scores of the ""(.*)"" - ""(.*)"" and ""(.*)"" - ""(.*)""")]
        public void ThenUserCanSeeTheSameScoresOfThe_And_(string team1, int score1, string team2, int score2)
        {
            Assert.AreEqual(TeamScore_Page.GetTeamScoreStringToCheck(), team1 + " " + score1 + " : " + score2 + " " + team2);
        }

        [Then(@"User can see the seconds articls name is")]
        public void ThenUserCanSeeTheSecondsArticlsNameIs(Table tableOfValues)
        {
            News_Page.ShowSecondArticls();
            Assert.IsTrue(News_Page.IsTrueSecond(News_Page.TableToList(tableOfValues)));
        }


    }
}
