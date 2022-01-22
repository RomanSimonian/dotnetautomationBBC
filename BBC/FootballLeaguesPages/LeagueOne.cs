using BBC.classesForTest;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace BBC.FootballLeaguesPages
{
    public class LeagueOne : BasePage
    {
        [FindsBy(How = How.XPath, Using = "//a[text()='Scores & Fixtures']")]
        private IWebElement goToScoresAndFixtures;

        [FindsBy(How = How.XPath, Using = "//button[@aria-label='previous']")]
        private IWebElement goToPrevious;

        [FindsBy(How = How.XPath, Using = "//a[@href='/sport/football/league-one/scores-fixtures/2021-12?filter=results']")]
        private IWebElement selectDecember;




        public void ClickSelectJuly() { selectDecember.Click(); }

        public void ClickGoToPrevious() { goToPrevious.Click(); }

        public void ClickOnGoToScoresAndFixtures() { goToScoresAndFixtures.Click(); }

        public LeagueOne(WebDriver driver) : base(driver) { }
    }
}
