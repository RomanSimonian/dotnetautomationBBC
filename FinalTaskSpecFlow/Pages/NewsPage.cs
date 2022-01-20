using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;

namespace FinalTask_BBC2_Bogdanov.Pages
{
    public class NewsPage : BasePage
    {
        [FindsBy(How = How.XPath, Using = @"//h3")]
        private IList<IWebElement> _mainArticl;
        [FindsBy(How = How.XPath, Using = @"//div[contains(@class,'top-stories')]//a[contains(@class,'gs-c-promo-heading')]//h3")]
        private IList<IWebElement> _secondArticls;

        public NewsPage(IWebDriver driver) : base(driver)
        {
        }

        public IList<IWebElement> GetSecondsArticls()
        {
            return _secondArticls;
        }

        public string GetMainArticlString()
        {
            return _mainArticl[0].Text;
        }
        //only for test
        public void ShowSecondArticls()
        {
            foreach (var a in _secondArticls)
            {
                if (a.Text.Length != 0) Console.WriteLine("|" + a.Text + "|");
            }
        }

        public bool IsTrueSecond(List<string> secondaryArticlesName)
        {
            for (int i = 0; i < _secondArticls.Count; i++)
            {
                if (_secondArticls[i].Text.Trim() == "") continue;
                if (!secondaryArticlesName.Contains(_secondArticls[i].Text))
                {
                    Console.WriteLine(_secondArticls[i].Text + " - " + secondaryArticlesName[i]);
                    return false;
                }
            }
            return true;
        }

        public List<string> TableToList(Table table)
        {
            List<string> result = new List<string>();
            for (int i = 0; i < table.RowCount; i++)
            {
                result.Add(table.Rows[i]["Value"]);
            }
            return result;
        }
    }
}
