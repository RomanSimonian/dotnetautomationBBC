using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;

namespace TASK_1_TEST.Pages
{
    class NewsPage
    {
        private IWebDriver driver;

        private readonly By _closePopUpButton = By.XPath("//button[@class='tp-close tp-active']");
        private readonly By _headLineArticle = By.XPath("//h3[@class='gs-c-promo-heading__title gel-paragon-bold nw-o-link-split__text']");
        private readonly By _secondaryArticles = By.XPath("//span[@class='nw-o-link-split__text gs-u-align-bottom']");
        private readonly By _categoryOfMainArticle = By.XPath("//a[contains(@class,'nw-o-link--no-visited-state')]");
        private readonly By _inputSearchField = By.XPath("//input[@id='orb-search-q']");
        private readonly By _searchButton = By.XPath("//button[@id='orb-search-button']");
        public NewsPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void ClosePopUp() {
            Waiter.WaitElement(driver, _closePopUpButton);
            driver.FindElement(_closePopUpButton).Click();
        }
        public string GetTextMainArticle() {
            return driver.FindElement(_headLineArticle).Text;
        }

        public IReadOnlyList<IWebElement> GetSecondaryArticles() {
            return driver.FindElements(_secondaryArticles);
        }

        public string GetTextCategoryOfMain() {
            return driver.FindElement(_categoryOfMainArticle).Text;
        }

        public void SearchByKeyWord(string key) {
            driver.FindElement(_inputSearchField).SendKeys(key);
            driver.FindElement(_searchButton).Click();
        }
    }
}
