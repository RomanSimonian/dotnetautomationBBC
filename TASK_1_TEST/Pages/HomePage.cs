using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;

namespace TASK_1_TEST.Pages
{
    class HomePage
    {
        private IWebDriver driver;

        private readonly By _newsButton = By.XPath("//div[@id='orb-nav-links']//li[@class='orb-nav-newsdotcom']");
        public HomePage(IWebDriver driver)
        {
            this.driver=driver;
        }
        public void GoToNews() {
            driver.FindElement(_newsButton).Click();
        }

        public By GetNewsButton() {
            return _newsButton;
        }
    }
}
