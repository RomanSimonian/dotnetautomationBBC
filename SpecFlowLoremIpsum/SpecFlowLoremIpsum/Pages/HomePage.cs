using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecFlowLoremIpsum.Pages
{
    public class HomePage : BasePage
    {
        [FindsBy(How = How.XPath, Using = "//a[contains(text(),'Pyccкий')]")]
        private readonly IWebElement selectLanguage;

        [FindsBy(How = How.XPath, Using = "//div[1]/p")]
        private IWebElement textFromFirstParagraph;

        [FindsBy(How = How.XPath, Using = "//input[@type='submit']")]
        private IWebElement submitButtonGenerate;

        [FindsBy(How = How.XPath, Using = "//input[@id='amount']")]
        private IWebElement iconAmount;

        [FindsBy(How = How.XPath, Using = "//input[@id='start']")]
        private IWebElement boxStartWithLorem;


        public HomePage(WebDriver driver) : base(driver) { }


        public void OpenHomePage(String url)
        {
            driver.Navigate().GoToUrl(url);
        }

        public bool IsCheckBoxStartWithLoremVisible() { return boxStartWithLorem.Displayed; }

        public bool IsIconAmountVisible() { return iconAmount.Displayed; }

        public bool IsSubmitButtonGenerateVisible() { return submitButtonGenerate.Displayed; }

        public bool IsFirstParagraphVisible() { return textFromFirstParagraph.Displayed; }

        public bool IsSelectLanguageButtonVisible() { return selectLanguage.Displayed; }

        public void ClickOnLanguage(string language) 
        {
            driver.FindElement(By.XPath($"//a[contains(text(),'{language}')]")).Click();
        }

        public String GetTextFromFirstParagraph() { return textFromFirstParagraph.Text; }

        public void ClickOnSubmitGenerate() { submitButtonGenerate.Click(); }

        public void EnterAmountOfCharacters(string amount)
        {
            iconAmount.Clear();
            iconAmount.SendKeys(amount);
        }

        public void ClickOnBoxStartWithLorem() { boxStartWithLorem.Click(); }
    }
}
