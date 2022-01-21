using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loremipsum_Tests.PageObjects
{
    class ResultPageObject
    {
        private IWebDriver webDriver;

        private readonly By _paragrath1 = By.XPath("//div[@id='lipsum']/p[1]");

        public ResultPageObject(IWebDriver webDriver)
        {
            this.webDriver = webDriver;
        }

        public String GetTextFirstParagraph()
        {
            return webDriver.FindElement(_paragrath1).Text;
        }

        public int GetWordsActualSize()
        {
            return GetTextFirstParagraph().Split(" ").Length;
        }

        public int GetBytesActualSize()
        {
            return GetTextFirstParagraph().ToCharArray().Count();
        }

        public int getCountParagraphWithLorem()
        {
            List<IWebElement> listElements = webDriver.FindElements(By.XPath("//div[@id='lipsum']/p")).ToList();
            int count = 0;
            foreach (IWebElement webElement in listElements)
            {
                if (webElement.Text.Contains("lorem")) { count++; }
            }
            return count;
        }
    }
}
