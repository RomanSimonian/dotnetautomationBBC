using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using OpenQA.Selenium.Support.UI;

namespace TASK_1_TEST
{
    public class Tests
    {
        private IWebDriver driver;
        private string TEST_URL = "https://www.bbc.com/";
        private readonly string _EXPECTED_ARTICULE = "UK's Johnson says he won't resign in angry exchanges";
        private readonly string _EXPECTED_ARTICLE_FROM_SEARCH = "Politics UK Archive";
        private readonly List<string> _EXPECTED_LIST_OF_ARTICLES= new List<string>() {"Party report won't be easy reading - Kuenssberg",
                                                                                      "How did it come to this?",
                                                                                      "What action could police take?"};

        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl(TEST_URL);
            driver.Manage().Window.Maximize();
        }

        #region TASK1
        private readonly By _newsButton= By.XPath("//div[@id='orb-nav-links']//li[@class='orb-nav-newsdotcom']");
        private readonly By _closePopUpButton= By.XPath("//button[@class='tp-close tp-active']");
        private readonly By _headLineArticle= By.XPath("//h3[@class='gs-c-promo-heading__title gel-paragon-bold nw-o-link-split__text']");
        private readonly By _secondaryArticles = By.XPath("//span[@class='nw-o-link-split__text gs-u-align-bottom']");
        private readonly By _categoryOfMainArticle = By.XPath("//a[contains(@class,'nw-o-link--no-visited-state')]");
        private readonly By _inputSearchField = By.XPath("//input[@id='orb-search-q']");
        private readonly By _searchButton = By.XPath("//button[@id='orb-search-button']");
        private readonly By _firstArticleAfterSearch = By.XPath("//p[@class='ssrcss-6arcww-PromoHeadline e1f5wbog4']");

        [Test]
        public void CheckTheNameMainArticle()
        {
            driver.FindElement(_newsButton).Click();
            Waiter.WaitElement(driver, _closePopUpButton);
            driver.FindElement(_closePopUpButton).Click();
            var HeadlineArticle = driver.FindElement(_headLineArticle);
            Assert.AreEqual(_EXPECTED_ARTICULE, HeadlineArticle.Text);
        }

        [Test]
        public void CheckTheNameSecondaryArticles()
        {
            driver.FindElement(_newsButton).Click();
            Waiter.WaitElement(driver, _closePopUpButton);
            driver.FindElement(_closePopUpButton).Click();
            var ListSecondaryArticles =driver.FindElements(_secondaryArticles);
            for (int i = 0; i < ListSecondaryArticles.Count; i++) {
                Assert.AreEqual(_EXPECTED_LIST_OF_ARTICLES[i], ListSecondaryArticles[i].Text);
                    }
        }


        [Test]
        public void CheckTheNameFirstArticleAfterSearch()
        {
            driver.FindElement(_newsButton).Click();
            Waiter.WaitElement(driver, _closePopUpButton);
            driver.FindElement(_closePopUpButton).Click();
            var CategoryOfMainNews = driver.FindElement(_categoryOfMainArticle).Text;
            driver.FindElement(_inputSearchField).SendKeys(CategoryOfMainNews);
            driver.FindElement(_searchButton).Click();
            Waiter.WaitElement(driver, _firstArticleAfterSearch);
            var FirstArticle = driver.FindElement(_firstArticleAfterSearch);
            Assert.AreEqual(FirstArticle.Text, _EXPECTED_ARTICLE_FROM_SEARCH);
            //vdhgfvhgvfehgvh
        }
        #endregion

    /*#region TASK2

        private readonly string XPTextAreaFromStory ="//textarea[@placeholder='Tell us your story. ']";
        private readonly string XPInputName = "//input[@placeholder='Name']";
        private readonly string XPInputEmail = "//input[@placeholder='Email address']";
        private readonly string XPInputNumber = "//input[@placeholder='Contact number ']";
        private readonly string XPInputLocation = "//input[@placeholder='Location ']";
        private readonly string XPSubmitButton = "//button[@class='button']";
        private readonly string XPErrorMessage = "//div[@class='input-error-message']";

        [Test]
        public void FillTheFormEmptyData()
        {
            driver.FindElement(By.XPath("//div[@id='orb-nav-links']//li[@class='orb-nav-newsdotcom']")).Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(15);
            driver.FindElement(By.XPath("//button[@class='tp-close tp-active']")).Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            driver.FindElement(By.XPath("//li[contains(@class,'nw-c-nav__wide-menuitem-container')]//span[contains(text(),'Coronavirus')]")).Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            driver.FindElement(By.XPath("//span[contains(text(),'Contact BBC News')]")).Click();
            driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(15);
            driver.Manage().Timeouts().ImplicitWait=TimeSpan.FromSeconds(20);
            driver.FindElement(By.XPath("//a[contains(text(),'send us a story')]")).Click();
            
            var TextAreaFromStory = driver.FindElement(By.XPath(XPTextAreaFromStory));
            var InputName = driver.FindElement(By.XPath(XPInputName));
            var SubmitButton = driver.FindElement(By.XPath(XPSubmitButton));

            InputName.SendKeys("xcvbn");

            driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(15);
            SubmitButton.Click();
            var ErrorMessage = driver.FindElement(By.XPath(XPErrorMessage));
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(15);
            Assert.AreEqual("can't be blank", ErrorMessage.Text);
        }
        [Test]
        public void FillTheFormEmptyData2()
        {
            driver.FindElement(By.XPath("//div[@id='orb-nav-links']//li[@class='orb-nav-newsdotcom']")).Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(15);
            driver.FindElement(By.XPath("//button[@class='tp-close tp-active']")).Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            driver.FindElement(By.XPath("//li[contains(@class,'nw-c-nav__wide-menuitem-container')]//span[contains(text(),'Coronavirus')]")).Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            driver.FindElement(By.XPath("//span[contains(text(),'Contact BBC News')]")).Click();
            driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(15);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
            driver.FindElement(By.XPath("//a[contains(text(),'send us a story')]")).Click();

            var TextAreaFromStory = driver.FindElement(By.XPath(XPTextAreaFromStory));
            var InputName = driver.FindElement(By.XPath(XPInputName));
            var InputEmail = driver.FindElement(By.XPath(XPInputEmail));
            var InputNumber = driver.FindElement(By.XPath(XPInputNumber));
            var InputLocation = driver.FindElement(By.XPath(XPInputLocation));
            var SubmitButton = driver.FindElement(By.XPath(XPSubmitButton));

            TextAreaFromStory.SendKeys("xcvbnvhgfvghfvghg");

            driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(15);
            SubmitButton.Click();
            var ErrorMessage = driver.FindElement(By.XPath(XPErrorMessage));
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(15);
            Assert.AreEqual("Name can't be blank", ErrorMessage.Text);
            //Name can't be blank
            //must be accepted
        }
        #endregion*/


        [TearDown]
        public void TearDown() {
            driver.Close();
        }
    }
}