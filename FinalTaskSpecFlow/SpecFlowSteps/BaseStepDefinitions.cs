using FinalTask_BBC2_Bogdanov.Pages;
using FinalTaskSpecFlow.Pages;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using TechTalk.SpecFlow;

namespace FinalTask_BBC2_Bogdanov.SpecFlowSteps
{
    public class BaseStepDefinitions
    {
        protected IWebDriver Driver;
        protected HomePage Home_Page = null;
        protected NewsPage News_Page = null;
        protected SportPage Sport_Page = null;
        protected ScorePage Score_Page = null;
        protected TeamScorePage TeamScore_Page = null;



        [Before]
        public void SetUp()
        {
            Driver = new ChromeDriver();
            Driver.Navigate().GoToUrl("https://www.bbc.com");
            Driver.Manage().Window.Maximize();
        }

        [After]
        public void Finish()
        {
            Driver.Close();
        }
    }
}
