using System;
using System.Collections.Generic;
using System.Text;
using BBC1_task_4._1._1.Pages;
using BBC1_task_4._1._1.Definitions;
using OpenQA.Selenium;

namespace BBC1_task_4._1._1.BLL
{
    public class Articles_bll
    {
        private IWebDriver _driver;
        readonly CovidNewsPage covidNews;
        readonly HomePage homePage;

        public Articles_bll(IWebDriver driver)
        {
            _driver = driver;
        }

        public bool CovidSecondaryArticlesCheck(Dictionary<int, string> expectedHearders)
        {
            var covidNews = new CovidNewsPage(_driver);
            return covidNews.AreSecondaryArticlesMatch(expectedHearders);
        }

        public bool HomePageArticlesCheck(string expectedArticle)
        {
            var homePage = new HomePage(_driver);
            return homePage.AreHeadlineArticleNameMach(expectedArticle);
        }
    }
}
