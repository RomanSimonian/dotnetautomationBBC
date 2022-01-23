using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loremipsum_BDD.PageObjects
{
    public class ResultPage
    {
        private readonly IWebDriver _webDriver;

        private readonly string _allParagraphsXpath = "//div[@id='lipsum']/p";

        public ResultPage(IWebDriver webDriver)
        {
            _webDriver = webDriver;
        }

        public string GetTextParagraph(int number)
        {
            return _webDriver.FindElement(By.XPath(_allParagraphsXpath+$"[{number}]")).Text;
        }

        public int GetWordsActualSize()
        {
            return GetTextParagraph(1).Split(" ").Length;
        }

        public int GetBytesActualSize()
        {
            return GetTextParagraph(1).ToCharArray().Count();
        }

        public int GetActualSize(string element)
        {
            if(element=="words")
            {
                return GetWordsActualSize();
            }
            else
            {
                return GetBytesActualSize();
            }
        }

        public int GetCountParagraphWithLorem()
        {
            List<IWebElement> listElements = _webDriver.FindElements(By.XPath(_allParagraphsXpath)).ToList();
            int count = 0;
            foreach (IWebElement webElement in listElements)
            {
                if (webElement.Text.Contains("lorem")) { count++; }
            }
            return count;
        }
    }
}
