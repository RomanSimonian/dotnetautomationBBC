using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecFlowProject1.Pages
{
    internal class Form : BasePage
    {
        [FindsBy(How = How.XPath, Using = "//div/textarea | //input[@placeholder]")]
        private IList<IWebElement> enterTextInForm;

        [FindsBy(How = How.XPath, Using = "//input[@type='checkbox']")]
        private IWebElement acceptTermsOfServiceButton;

        [FindsBy(How = How.XPath, Using = "//button[text()='Submit']")]
        private IWebElement buttonSubmit;

        public Form(WebDriver driver) : base(driver) { }

        public void FillForm(Dictionary<string, string> values)
        {
            foreach (var element in enterTextInForm)
            {
                var elementValue = values[element.GetAttribute("placeholder")];
                element.SendKeys(elementValue);
            }
        }

        public void ClickOnAcceptTermsOfServiceButton() { acceptTermsOfServiceButton.Click(); }

        public void ClickOnButtonSubmit() { buttonSubmit.Click(); }

    }
}
