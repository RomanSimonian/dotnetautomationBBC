using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;


namespace TASK_1_TEST
{
    public static class Waiter
    {
        public static void ImplicitWait(IWebDriver webDriver, int time = 60) {
            webDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(time);
        }

        public static void WaitElement(IWebDriver webDriver, By path, int time = 60) {
            new WebDriverWait(webDriver, TimeSpan.FromSeconds(time)).Until(ExpectedConditions.ElementIsVisible(path));
            new WebDriverWait(webDriver, TimeSpan.FromSeconds(time)).Until(ExpectedConditions.ElementToBeClickable(path));
        }
    }
}
