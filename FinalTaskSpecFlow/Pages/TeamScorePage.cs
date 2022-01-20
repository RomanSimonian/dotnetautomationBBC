using FinalTask_BBC2_Bogdanov.Pages;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace FinalTaskSpecFlow.Pages
{
    public class TeamScorePage : BasePage
    {
        [FindsBy(How = How.XPath, Using = @"//div[contains(@class,'sp-c-fixture__wrapper')]//span[contains(@class,'sp-c-fixture__block')]")]
        private IList<IWebElement> _listScores;
        [FindsBy(How = How.XPath, Using = @"//div[contains(@class,'sp-c-fixture__wrapper')]//span[contains(@class,'gs-u-display-none')]")]
        private IList<IWebElement> _listTeams;
        
        public TeamScorePage(IWebDriver driver) : base(driver)
        {
        }

       public string GetTeamScoreStringToCheck()
        {
            return _listTeams[0].Text + " " + _listScores[0].Text + " : " + _listScores[1].Text + " " + _listTeams[1].Text;
        }
    }
}
