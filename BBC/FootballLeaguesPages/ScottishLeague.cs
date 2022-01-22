using BBC.classesForTest;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace BBC.FootballLeaguesPages
{
    public class ScottishLeague : BasePage
    {
        [FindsBy(How = How.XPath, Using = "//a[text()='Scores & Fixtures']")]
        private IWebElement goToScoresAndFixtures;

        [FindsBy(How = How.XPath, Using = "//button[@aria-label='previous']")]
        private IWebElement goToPrevious;

        [FindsBy(How = How.XPath, Using = "//a[@href='/sport/football/scottish-league-cup/scores-fixtures/2021-07']")]
        private IWebElement selectJuly;

       

        public void ClickSelectJuly() { selectJuly.Click(); }

        public void ClickGoToPrevious() { goToPrevious.Click(); }

        public void ClickOnGoToScoresAndFixtures() { goToScoresAndFixtures.Click(); }

        public ScottishLeague(WebDriver driver) : base(driver) { }
    }
}
