using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace FinalProlect.Classes_for_test
{
    public class GeneratedPages : BasePage
    {
        [FindsBy(How = How.XPath, Using = "//div[@id='generated']")]
        private IWebElement resultGenerated;

        [FindsBy(How = How.XPath, Using = "//div[@id='lipsum']//p")]
        private IList<IWebElement> listFromParagraphs;

        [FindsBy(How = How.XPath, Using = "//a[@href='https://www.lipsum.com/']")]
        private IWebElement goHome;


        public GeneratedPages(WebDriver driver) : base(driver) { }

        public String GetResultGenerated()
        {
            return resultGenerated.Text;
        }

        public IList<IWebElement> GetListFromParagraphs()
        {
            return listFromParagraphs;
        }

        public void ClickGoHome() { goHome.Click(); }
    }
}
