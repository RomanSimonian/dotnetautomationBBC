using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TASK_1_TEST.Pages;

namespace TASK_1_TEST.Tests
{
    class BaseTest
    {
        private IWebDriver driver;
        private string TEST_URL = "https://www.bbc.com/";

        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl(TEST_URL);
            driver.Manage().Window.Maximize();
        }

        [TearDown]
        public void TearDown()
        {
            driver.Close();
        }

        public IWebDriver GetDriver() { return driver;}
        public HomePage GetHomePage() { return new HomePage(GetDriver()); }
        public NewsPage GetNewsPage() { return new NewsPage(GetDriver()); }
        public SearchResultPage GetSearchResultPage() { return new SearchResultPage(GetDriver()); }

    }
}
