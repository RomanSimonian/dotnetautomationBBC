using System;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;


namespace FinalProlect.Classes_for_test
{
    public class HomePage : BasePage
    {
        [FindsBy(How = How.XPath, Using = "//input[@type='submit']")]
        private IWebElement submitButtonGenerate;

        [FindsBy(How = How.XPath, Using = "//input[@id='amount']")]
        private IWebElement iconAmount;

        [FindsBy(How = How.XPath, Using = "//input[@id='start']")]
        private IWebElement boxStartWithLorem;


        public HomePage(WebDriver driver) : base(driver) { }


        public void OpenPage(String url)
        {
            driver.Navigate().GoToUrl(url);
        }

        public bool IsIconAmountVisible => iconAmount.Displayed; 

        public bool IsSubmitButtonGenerateVisible => submitButtonGenerate.Displayed; 

        public bool IsFirstParagraphVisible => textFromFirstParagraph.Displayed; 

        public bool IsSelectRussianButtonVisible => selectRussianButton.Displayed; 

        public void ClickOnSelectLanguage(string language)
        {
            var button = driver.FindElement(By.XPath($"//a[contains(text(),'{language}')]"));
            button.Click();
        }

        public string GetTextFromParagraph(int number)
        {
            return textFromParagraph = driver.FindElement(By.XPath($"//div[{number}]/p")).Text;
        }

        public void ClickOnSubmitGenerate() { submitButtonGenerate.Click(); }

        public void EnterAmountOfCharacters(string amount)
        {
            iconAmount.Clear();
            iconAmount.SendKeys(amount);
        }

        public void ClickOnBoxStartWithLorem() { boxStartWithLorem.Click(); }
    }
}
