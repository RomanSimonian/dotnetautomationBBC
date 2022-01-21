using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecFlowProject1.Pages
{
    internal class CoronavirusPage : BasePage
    {
        [FindsBy(How = How.XPath, Using = "//div[@class='gs-u-display-none gs-u-display-block@m']//a[@href='/news/have_your_say']")]
        private IWebElement coronavirusStories;

        [FindsBy(How = How.XPath, Using = "//a[@href='/news/52143212']")]
        private IWebElement formForStories;

        [FindsBy(How = How.XPath, Using = "//button[@aria-label='Close']")]
        public IWebElement closeBanner;

        [FindsBy(How = How.XPath, Using = "//div[@class='input-error-message']")]
        private IWebElement errorMessageForText;

        [FindsBy(How = How.XPath, Using = "//div[@class='input-error-message']")]
        private IWebElement errorMessageForName;

        [FindsBy(How = How.XPath, Using = "//div[@class='input-error-message']")]
        private IWebElement errorMessageForEmail;

        [FindsBy(How = How.XPath, Using = "//div[@class='input-error-message']")]
        private IWebElement errorMessageForAccept;



        public void WaitCloseBannerVisible()
        {
            WaitVisibilityOfElement(90, "//button[@aria-label='Close']");
        }

        public void WaitErrorMassageVisible() { WaitVisibilityOfElement(90, "//div[@class='input-error-message']"); }
        public string GetErrorMessageForText() { return errorMessageForText.Text; }
        public string GetErrorMessageForName() { return errorMessageForName.Text; }
        public string GetErrorMessageForEmail() { return errorMessageForEmail.Text; }
        public string GetErrorMessageForAccept() { return errorMessageForAccept.Text; }

        public void ClickCloseBanner() { closeBanner.Click(); }

        public void GoToFormStories() { formForStories.Click(); }

        public void ClickOnCoronavirusStories() { coronavirusStories.Click(); }

        public CoronavirusPage(WebDriver driver) : base(driver) { }
    }
}
