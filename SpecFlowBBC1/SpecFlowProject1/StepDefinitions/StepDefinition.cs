using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SpecFlowProject1.LeaguesPages;
using SpecFlowProject1.Manager;
using SpecFlowProject1.Pages;

namespace SpecFlowProject1.StepDefinitions
{
    [Binding]
    public sealed class StepDefinition
    {
        WebDriver driver;
        PageFactoryManager pageFactoryManager;
        ChampionLeague championLeague;
        LeagueOne leagueOne;
        PremierLeague premierLeague;
        ScottishLeague scottishLeague;
        CoronavirusPage coronavirusPage;
        FootballPage footballPage;
        Form form;
        HomePage homePage;
        NewsPage newsPage;
        PagesWithCategoryLinkSearch pagesWithCategoryLinkSearch;
        ScoreBoard scoreBoard;
        SportPage sportPage;

        readonly string URL = "https://www.bbc.com/news/";
        private string question = "What questions would you like us to answer?";


        [BeforeScenario]
        public void BeforeScenario()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl(URL);
            pageFactoryManager = new PageFactoryManager(driver);
        }

        [AfterScenario]
        public void AfterScenario()
        {
            driver.Close();
        }

        [Given(@"User opens '([^']*)' page")]
        public void OpensPage(string url)
        {
            homePage = pageFactoryManager.GetHomePage();
            homePage.OpenHomePage(url);
            homePage = pageFactoryManager.GetHomePage();
        }

        [When(@"User checks news page button visibility")]
        public void ChecsNewsPageButtonVisibility()
        {
            homePage.IsButtonNewsVisible();
        }

        [When(@"User clicks news button")]
        public void ClicksNewsButton()
        {
            homePage.ClickOnGoToNews();
            newsPage = pageFactoryManager.GetNewsPage();
            form = pageFactoryManager.GetForm();
            coronavirusPage = pageFactoryManager.GetCoronavirusPage();
        }

        [Then(@"User checks head title include '([^']*)'")]
        public void ThenUserChecksHeadTitleInclude(string words)
        {
            Assert.IsTrue(newsPage.GetHeadlineArticle().Contains(words));
        }

        [Then(@"User checks first title include '([^']*)'")]
        public void ThenUserChecksFirstTitleInclude(string title1)
        {
            newsPage = pageFactoryManager.GetNewsPage();
            newsPage.GetFirstArticle().Contains(title1);
        }

        [Then(@"User checks second title include '([^']*)'")]
        public void ThenUserChecksSecondTitleInclude(string title2)
        {
            newsPage.GetSecondArticle().Contains(title2);
        }

        [Then(@"User checks third title include '([^']*)'")]
        public void ThenUserChecksThirdTitleInclude(string title3)
        {
           newsPage.GetThirdArticle().Contains(title3);
        }

        [Then(@"User checks fourth title include '([^']*)'")]
        public void ThenUserChecksFourthTitleInclude(string title4)
        {
            newsPage.GetFourthArticle().Contains(title4);   
        }

        [Then(@"User checks fifth title include '([^']*)'")]
        public void ThenUserChecksFifthTitleInclude(string title5)
        {
            newsPage.GetFifthArticle().Contains(title5);
        }

        [When(@"User enter category name in search")]
        public void WhenUserEnterCategoryNameInSearch()
        {
            newsPage = pageFactoryManager.GetNewsPage();
            newsPage.EnterSearchInput(newsPage.GetCategoryLink());
            newsPage.WaitForPageLoadComplate(30);
        }

        [When(@"User checks search page visibility")]
        public void WhenUserChecksSearchPageVisibility()
        {
            pagesWithCategoryLinkSearch = pageFactoryManager.GetPagesWithCategoryLinkSearch();
            pagesWithCategoryLinkSearch.IsFirstArticleVisible();
        }

        [Then(@"User checks first search title include '([^']*)'")]
        public void ThenUserChecksFirstSearchTitleInclude(string keyword)
        {
            Assert.IsTrue(pagesWithCategoryLinkSearch.GetFirstNewArticleWithSearch().Contains(keyword));
        }

        [When(@"User clicks coronavirus news")]
        public void WhenUserClicksCoronavirusNews()
        {
            newsPage.ClickOnCoronavirusNews();  
        }

        [When(@"User clicks go to form coronavirus stories")]
        public void WhenUserClicksGoToFormCoronavirusStories()
        {
            newsPage.ClickOnCoronavirusNews();
            newsPage.WaitForPageLoadComplate(30);
            coronavirusPage.ClickOnCoronavirusStories();    
            coronavirusPage.GoToFormStories();
   
            coronavirusPage.WaitForPageLoadComplate(60);
        }

        [When(@"User enter form without question")]
        public void WhenUserEnterFormWithoutQuestion()
        {
            coronavirusPage.WaitForPageLoadComplate(60);
            coronavirusPage.WaitCloseBannerVisible();
            coronavirusPage.ClickCloseBanner(); 
            var userWithoutText = new Dictionary<string, string>()
           {
               {question, "" },
               { "Name", "asfasf" },
               {"Email address", "123" },
               { "Contact number", "1234123123" },
               {"Location ","kyiv" },
               {"Age","22" }
           };

            form.FillForm(userWithoutText);
        }



        [When(@"User enter form without name")]
        public void WhenUserEnterFormWithoutName()
        {
            coronavirusPage.WaitForPageLoadComplate(60);
            coronavirusPage.WaitCloseBannerVisible();
            coronavirusPage.ClickCloseBanner();
            var userWithoutText = new Dictionary<string, string>()
           {
               {question, "asdasd" },
               { "Name", "" },
               {"Email address", "123" },
               { "Contact number", "1234123123" },
               {"Location ","kyiv" },
               {"Age","22" }
           };

            form.FillForm(userWithoutText);
        }
        public void ThenUserChecksError(string massage)
        {
            coronavirusPage.WaitForPageLoadComplate(60);
            coronavirusPage.WaitErrorMassageVisible();
            Assert.IsTrue(coronavirusPage.GetErrorMessageForName().Contains(massage));
        }

        [Then(@"User checks error '([^']*)'t be blank'")]
        public void ChecksErrorMassage(string massage)
        {
            coronavirusPage.WaitForPageLoadComplate(60);
            coronavirusPage.WaitErrorMassageVisible();
            Assert.IsTrue(coronavirusPage.GetErrorMessageForName().Contains(massage));
        }

        [When(@"User enter form data")]
        public void WhenUserEnterFormData()
        {
            coronavirusPage.WaitForPageLoadComplate(60);
            coronavirusPage.WaitCloseBannerVisible();
            coronavirusPage.ClickCloseBanner();
            var userWithoutText = new Dictionary<string, string>()
           {
               {question, "asdasd" },
               { "Name", "124124" },
               {"Email address", "123" },
               { "Contact number", "1234123123" },
               {"Location ","kyiv" },
               {"Age","22" }
           };
            form.ClickOnAcceptTermsOfServices();
            form.FillForm(userWithoutText);
        }

        [Then(@"User checks error '([^']*)'")]
        public void ChecksErorrAccept(string acceptMessage)
        {
            coronavirusPage.WaitForPageLoadComplate(60);
            coronavirusPage.WaitErrorMassageVisible();
            Assert.IsTrue(coronavirusPage.GetErrorMessageForName().Contains(acceptMessage));
        }

    }
}