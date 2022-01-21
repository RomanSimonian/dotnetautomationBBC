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
    internal class LeagueOne : BasePage
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
