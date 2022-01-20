using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace FinalTask_BBC2_Bogdanov.Pages
{
    public class SportPage : BasePage
    {
        [FindsBy(How = How.XPath, Using = @"//ul[contains(@class,'list')]//a[contains(@data-stat-title,'Football')]")]
        private IWebElement _fottballButton;
        [FindsBy(How = How.XPath, Using = @"//ul[contains(@id,'sp-nav-secondary')]//a[contains(@href,'scores-fi')]")]
        private IWebElement _scoresAdnFixtures;

        public SportPage(IWebDriver driver) : base(driver)
        {
        }

        public IWebElement GetFottballButton()
        {
            return _fottballButton;
        }
        public ScorePage GoToScorePage()
        {
            WaitUntilEnable(TimeToWait, _scoresAdnFixtures);
            _scoresAdnFixtures.Click();
            return new ScorePage(Driver);
        }
    }
}
