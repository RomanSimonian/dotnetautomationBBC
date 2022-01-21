using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecFlowProject1.Pages
{
    internal class FootballPage : BasePage
    {
        [FindsBy(How = How.XPath, Using = "//a[@href='/sport/football/leagues-cups']")]
        private IWebElement goToLeagues;

        [FindsBy(How = How.XPath, Using = "//a[@href='https://www.bbc.co.uk/sport/football/premier-league']")]
        private IWebElement goToPremierLeague;

        [FindsBy(How = How.XPath, Using = "//a[@href='https://www.bbc.co.uk/sport/football/scottish-league-cup']")]
        private IWebElement goToScottishLeague;

        [FindsBy(How = How.XPath, Using = "//span[text()='Champions League']")]
        private IWebElement goToChampionsLeague;

        [FindsBy(How = How.XPath, Using = "//span[text()='League One']")]
        private IWebElement goToLeagueOne;

        public void ClickOnGoToLeagueOne() { goToLeagueOne.Click(); }

        public void ClickOnGoToChampionsLeague() { goToChampionsLeague.Click(); }

        public void ClickOnGoToScottishLeague() { goToScottishLeague.Click(); }

        public void ClickOnGoToPremierLeague() { goToPremierLeague.Click(); }

        public void ClickOnGoToLeagues() { goToLeagues.Click(); }

        public FootballPage(WebDriver driver) : base(driver) { }
    }
}
