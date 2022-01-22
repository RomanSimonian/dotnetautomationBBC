using System;
using BBC.classesForTest;
using BBC.classesForTestBBC1;
using BBC.FootballLeaguesPages;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace BBC.main
{
    public class BaseTest
    {
        private WebDriver driver;
        private static readonly String url = "https://www.bbc.com/";

        [TestInitialize()]
        public void StartChrome()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl(url);
        }
        
       [TestCleanup()]
        public void CloseChrome()
        {
            driver.Close();
        }
        
        public WebDriver GetDriver() { return driver; }
        
        public CoronavirusPage GetCoronavirusPage() { return new CoronavirusPage(GetDriver()); }

        public Form GetForm() { return new Form(GetDriver()); }

        public HomePage GetHomePage() { return new HomePage(GetDriver()); }

        public NewsPage GetNewsPage() { return new NewsPage(GetDriver()); }

        public SportPage GetSportPage() { return new SportPage(GetDriver()); }

        public PagesWithCategoryLinkSearch GetPagesWithCategoryLinkSearch() { return new PagesWithCategoryLinkSearch(GetDriver()); }

        public FootballPage GetFootballPage() { return new FootballPage(GetDriver()); }

        public ScoreBoard GetScoreBoard() { return new ScoreBoard(GetDriver()); }

        public ChampionsLeague GetChampionsLeague() { return new ChampionsLeague(GetDriver()); }

        public LeagueOne GetLeagueOne() { return new LeagueOne(GetDriver()); }

        public PremierLeague GetPremierLeague() { return new PremierLeague(GetDriver()); }

        public ScottishLeague GetScottishLeague() { return new ScottishLeague(GetDriver()); }

    }
}
