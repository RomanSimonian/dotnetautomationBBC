
using System.Collections.Generic;
using BBC.classesForTest;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace BBC.classesForTestBBC1
{
    public class Form : BasePage
    {

        [FindsBy(How = How.XPath, Using = "//div/textarea | //input[@placeholder]")]
        private IList<IWebElement> textBoxForm;

        [FindsBy(How = How.XPath, Using = "//input[@type='checkbox']")]
        private IWebElement acceptTermsOfService;

        [FindsBy(How = How.XPath, Using = "//button[text()='Submit']")]
        private IWebElement buttonSubmit;

        public void FillForm(Dictionary<string, string> values)
        {
            foreach (var element in textBoxForm)
            {
                var elementValue = values[element.GetAttribute("placeholder")];
                element.SendKeys(elementValue);
            }
            acceptTermsOfService.Click();
            buttonSubmit.Click();
        }

        public void ClickOnAcceptTermsOfServices() { acceptTermsOfService.Click(); }
        
        public Form(WebDriver driver) : base(driver) { }
    }
}
