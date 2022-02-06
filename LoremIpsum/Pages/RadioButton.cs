using System;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace FinalProlect.Classes_for_test
{
    public class RadioButton : BasePage
    {
        [FindsBy(How = How.XPath, Using = "//table[@style='text-align:left']//tbody")]
        private IWebElement buttonGroup;

        public void SetValue(string value)
        {
            buttonGroup.FindElement(By.Id(value)).Click();
        }

        public RadioButton(WebDriver driver) : base(driver) { }
    }
}
