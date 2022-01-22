using BBC.classesForTest;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace BBC.FootballLeaguesPages
{
    public class PremierLeague : BasePage
    {
        [FindsBy(How = How.XPath, Using = "//a[text()='Scores & Fixtures']")]
        private IWebElement goToScoresAndFixtures;

        [FindsBy(How = How.XPath, Using = "//a[@href='/sport/football/premier-league/scores-fixtures/2021-11']")]
        private IWebElement selectNovember;

        [FindsBy(How = How.XPath, Using = "//a[@href='/sport/football/premier-league/scores-fixtures/2021-08']")]
        private IWebElement selectAugust;

        [FindsBy(How = How.XPath, Using = "//button[@aria-label='previous']")]
        private IWebElement goToPrevious;

        //span[contains(@data-reactid,'08-wrapper.0.0.0.0.1.0')] | //span[contains(@data-reactid,'08-wrapper.0.0.0.2.1.0')] for 1 play goals
        //span[contains(@data-reactid,'0281-wrapper.0.0.0.0.1.0')] | //span[contains(@data-reactid,'0281-wrapper.0.0.0.2.1.0')] for 2 play goals
        public void ClickGoToPrevious() { goToPrevious.Click(); }

        public void ClickSelectAugust() { selectAugust.Click(); }

        public void ClickSelectNovember() { selectNovember.Click(); }

        public void ClickOnGoToScoresAndFixtures() { goToScoresAndFixtures.Click(); }

        public PremierLeague(WebDriver driver) : base(driver) { }
    }
}
