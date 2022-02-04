using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using SpecFlowProject1.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecFlowProject1.LeaguesPages
{
    internal class PremierLeague : BasePage
    {
        [FindsBy(How = How.XPath, Using = "//a[text()='Scores & Fixtures']")]
        private IWebElement goToScoresAndFixtures;

        [FindsBy(How = How.XPath, Using = "//a[@href='/sport/football/premier-league/scores-fixtures/2021-11']")]
        private IWebElement selectNovember;

        [FindsBy(How = How.XPath, Using = "//a[@href='/sport/football/premier-league/scores-fixtures/2021-08']")]
        private IWebElement selectAugust;

        [FindsBy(How = How.XPath, Using = "//button[@aria-label='previous']")]
        private IWebElement goToPrevious;

        public void ClickGoToPrevious() { goToPrevious.Click(); }

        public void ClickSelectAugust() { selectAugust.Click(); }

        public void ClickSelectNovember() { selectNovember.Click(); }

        public void ClickOnGoToScoresAndFixtures() { goToScoresAndFixtures.Click(); }

        public PremierLeague(WebDriver driver) : base(driver) { }
    }
}
