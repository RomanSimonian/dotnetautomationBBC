using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestSolution.PageObject
{
    public class NewsPage:Page
    {
        private readonly By _firstTitle = By.XPath("//a[@class='gs-c-promo-heading gs-o-faux-block-link__overlay-link gel-paragon-bold nw-o-link-split__anchor']");
        private readonly By _secondTitle = By.XPath("//h3[@class='gs-c-promo-heading__title gel-pica-bold nw-o-link-split__text']");
        private readonly By _firstTitleCategory = By.XPath("//div[@class='gs-c-promo-body gs-u-display-none gs-u-display-inline-block@m gs-u-mt@xs gs-u-mt0@m gel-1/3@m']/ul/li/a[@class='gs-c-section-link gs-c-section-link--truncate nw-c-section-link nw-o-link nw-o-link--no-visited-state']");
        private readonly By _inputBar = By.XPath("//input[@id='orb-search-q']");
        private readonly By _serchButton = By.XPath("//button[@id='orb-search-button']");
        public NewsPage(IWebDriver driver):base(driver)
        {
        }

        public string GetFirstTitleText()
        {
            return driver.FindElement(_firstTitle).Text;
        }

        public string GetSecondaryTitleText()
        {
            return driver.FindElement(_secondTitle).Text;
        }

        public SearchPage SearchByFirstTitleCategory()
        {
            var categoryText = driver.FindElement(_firstTitleCategory).Text;
            var searchBar = driver.FindElement(_inputBar);

            searchBar.SendKeys(categoryText);
            driver.FindElement(_serchButton).Click();

            return new SearchPage(driver);


        }
    }
}
