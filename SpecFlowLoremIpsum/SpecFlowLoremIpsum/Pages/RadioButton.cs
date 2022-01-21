using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecFlowLoremIpsum.Pages
{
    public class RadioButton : BasePage
    {
        [FindsBy(How = How.XPath, Using = "//table[@style='text-align:left']//tbody")]
        private IWebElement buttonGroup;

        public void SetValue(string value)
        {
            buttonGroup.FindElement(By.Id(value)).Click();
        }

        public bool IsButtoncharacterVisible(string value)
        {
            return buttonGroup.FindElement(By.Id(value)).Displayed;
        }

        public RadioButton(WebDriver driver) : base(driver) { }
    }

}

