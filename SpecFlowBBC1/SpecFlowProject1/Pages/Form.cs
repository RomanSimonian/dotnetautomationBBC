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
