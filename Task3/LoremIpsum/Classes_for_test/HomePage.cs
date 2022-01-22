using System;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;


namespace FinalProlect.Classes_for_test
{
    public class HomePage : BasePage
    {
        [FindsBy(How = How.XPath, Using = "//a[contains(text(),'Pyccкий')]")] //a[contains(text(),'Русский')]
        private IWebElement selectRussianButton;

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

        public bool IsIconAmountVisible() { return iconAmount.Displayed; }

        public bool IsSubmitButtonGenerateVisible() { return submitButtonGenerate.Displayed; }

        public bool IsFirstParagraphVisible() { return textFromFirstParagraph.Displayed; }

        public bool IsSelectRussianButtonVisible() { return selectRussianButton.Displayed; }

        public void ClickOnSelectRussian(string language)
        {
            var button = driver.FindElement(By.XPath($"//a[contains(text(),'{language}')]"));
            button.Click();
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
