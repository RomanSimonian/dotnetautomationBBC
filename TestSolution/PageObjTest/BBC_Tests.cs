using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TestSolution.PageObject;

namespace TestSolution.PageObjTest
{
    
    class BBC_Tests
    {
        protected IWebDriver driver;

        [SetUp]
        public void Setup()

        {
            driver = new OpenQA.Selenium.Chrome.ChromeDriver();
            driver.Navigate().GoToUrl("https://www.bbc.com");
            driver.Manage().Window.Maximize();
        }

        [Test]
        public void CheckFirstTitleText()
        {
            string expectedTitle1 = "UK warns of plot to install Russia ally in Ukraine";

            HomePage homePage = new HomePage(driver);

            string actualTitle = homePage.GoToNewsPage()
                .GetFirstTitleText();
           
            Assert.AreEqual(actualTitle, expectedTitle1);
        }

        [Test]
        public void CheckSecondTitleText()
        {
            string [] expectedTitle2 = new string[2]
            { "German navy chief resigns over Ukraine comments", "q" };

            HomePage homePage = new HomePage(driver);

            string actualTitle = homePage.GoToNewsPage()
                .GetSecondaryTitleText();

            Assert.Contains(actualTitle, expectedTitle2);
        }

        [Test]
        public void CheckSearchByFirstTitleCategory()
        {
            string expectedTitle = "UK";

            HomePage homePage = new HomePage(driver);

            var firstTitleText = homePage.GoToNewsPage()
                .SearchByFirstTitleCategory()
                .GetFirstTitleTextOnSearchPage();

            Assert.AreEqual(firstTitleText, expectedTitle);
        }
        [TearDown]
        public void TearDown()
        {
            driver.Quit();
        }
    }
}
