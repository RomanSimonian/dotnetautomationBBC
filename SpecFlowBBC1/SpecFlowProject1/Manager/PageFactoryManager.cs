using OpenQA.Selenium;
using SpecFlowProject1.LeaguesPages;
using SpecFlowProject1.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecFlowProject1.Manager
{
    internal class PageFactoryManager
    {
        readonly WebDriver driver;

        public PageFactoryManager(WebDriver driver)
        {
            this.driver = driver;
        }

        public HomePage GetHomePage() { return new HomePage(driver); }

        public ChampionLeague GetChampionLeague() { return new ChampionLeague(driver); }

        public LeagueOne GetLeagueOne() { return new LeagueOne(driver); }

        public PremierLeague GetPremierLeague() { return new PremierLeague(driver); }

        public ScottishLeague GetScottishLeague() { return new ScottishLeague(driver); }

        public CoronavirusPage GetCoronavirusPage() { return new CoronavirusPage(driver); }

        public FootballPage GetFootballPage() { return new FootballPage(driver); }

        public Form GetForm() { return new Form(driver); }

        public NewsPage GetNewsPage() { return new NewsPage(driver); }

        public PagesWithCategoryLinkSearch GetPagesWithCategoryLinkSearch() { return new PagesWithCategoryLinkSearch(driver); }

        public SportPage GetSportPagee() { return new SportPage(driver); }

        public ScoreBoard GetScoreBoarde() { return new ScoreBoard(driver); }
    }
}
