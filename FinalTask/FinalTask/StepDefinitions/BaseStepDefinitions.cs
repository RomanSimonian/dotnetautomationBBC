using FinalTask.Pages;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using TechTalk.SpecFlow;

namespace FinalTask.StepDefinitions
{
    public class BaseStepDefinitions
    {
        protected IWebDriver Driver;
        protected HomePage Home_Page = null;
        protected NewsPage News_Page = null;
        protected CoronavirusPage Coronavirus_Page = null;
        protected CoronavirusStoryPage CoronavirusStory_Page = null;
        protected MyCoronavirusStoryPage MyCoronavirusStory_Page = null;

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
            Driver.Quit();
        }
    }
}
