using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;

namespace TASK_1_TEST.Pages
{
    class SearchResultPage
    {
        private IWebDriver driver;
        private readonly By _firstArticleAfterSearch = By.XPath("//p[@class='ssrcss-6arcww-PromoHeadline e1f5wbog4']");
        public SearchResultPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public string GetTextFirstArticleAfterSearch() {
            return driver.FindElement(_firstArticleAfterSearch).Text;
        }
    }
}
