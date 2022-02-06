using System;
using FinalProlect.Classes_for_test;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace FinalProlect.main
{
    public class BaseTest
    {
        private WebDriver driver;
        private static readonly String url = "https://lipsum.com/";

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

        public GeneratedPages GetGeneratedPages() { return new GeneratedPages(GetDriver()); }

        public HomePage GetHomePage() { return new HomePage(GetDriver()); }

        public RadioButton GetRadioButton() { return new RadioButton(GetDriver()); }
    }
}
