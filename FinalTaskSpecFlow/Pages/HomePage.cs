using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace FinalTask_BBC2_Bogdanov.Pages
{
    public class HomePage : BasePage
    {
        [FindsBy(How = How.XPath, Using = @"//a[@rev='hero1|headline']")]
        private IWebElement _mainArtictText;
        [FindsBy(How = How.XPath, Using = @"//div[contains(@class,'orb-nav-pri-container')]//a[text() = 'News']")]
        private IWebElement _newsRef;
        [FindsBy(How = How.XPath, Using = @"//nav[@role='navigation']//a[contains(text(),'Sport')]")]
        private IWebElement _sportButton;


        public HomePage(IWebDriver driver) : base(driver)
        {
        }
        
        public NewsPage GoToNewsPage()
        {
            _newsRef.Click();
            return new NewsPage(Driver);
        }
        public SportPage goToSportPage()
        {
            _sportButton.Click();
            return new SportPage(Driver);
        }


    }
}
