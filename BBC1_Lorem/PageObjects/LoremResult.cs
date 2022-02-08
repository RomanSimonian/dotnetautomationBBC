using BBC1withLoremIpsum.PageObjects;
using OpenQA.Selenium;
using System.Collections.Generic;
using System.Linq;

namespace BBC1withLoremIpsum.PageObjects
{
    class LoremResult: BasePage
    {
        private readonly string _allParagraphsXpath = "//div[@id='lipsum']/p";

        public LoremResult(IWebDriver _webDriver) : base(_webDriver) { }

        public string GetTextParagraph(int number)
        {
            return _webDriver.FindElement(By.XPath(_allParagraphsXpath + $"[{number}]")).Text;
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
            if (element == "words")
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
