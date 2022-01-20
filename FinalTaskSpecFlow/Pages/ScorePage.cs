using FinalTaskSpecFlow.Pages;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FinalTask_BBC2_Bogdanov.Pages
{
    public class ScorePage : BasePage
    {

        private string _aInDivWithYearAndMounth = @"//a[contains(@class,'sp-c-date-picker-timeline__item-inner  false')]";
        private string _searchInputForClick = @"//a//mark";

        [FindsBy(How = How.XPath, Using = @"//input[contains(@name,'search')]")]
        private IWebElement _searchChempionshipInput;
        [FindsBy(How = How.XPath, Using = @"//div[@class = 'sp-c-date-picker-timeline__lists']")]
        private IWebElement _divWithYearAndMounth;
        [FindsBy(How = How.XPath, Using = @"//span[contains(@class,'gel-long-primer-bold gs-u-display-block')]")]
        private IList<IWebElement> _listOfMounth;
        [FindsBy(How = How.XPath, Using = @"//span[@class='gel-long-primer gs-u-display-block']")]
        private IList<IWebElement> _listOfYears;
        [FindsBy(How = How.XPath, Using = @"//li[@class='gs-o-list-ui__item gs-u-pb-']")]
        private IList<IWebElement> _listScoresAndTeams;
        [FindsBy(How = How.XPath, Using = @"//li[@class='gs-o-list-ui__item gs-u-pb-']//div/span/span/span")]
        private IList<IWebElement> _listTeams;
        string listScoresAndTeams1 = @"//li[@class='gs-o-list-ui__item gs-u-pb-'][1]";

        private IWebElement YearMonthElement(string year, string mounth, IWebElement divWithYearAndMounth, string aInDivWithYearAndMounth)
        {

            IList<IWebElement> listOfAElementYearsMonth = divWithYearAndMounth.FindElements(By.XPath(aInDivWithYearAndMounth));
            foreach (var element in listOfAElementYearsMonth)
            {
                if ((element.Text.Contains(year)) && (element.Text.Contains(mounth)))
                {
                    return element;
                }
            }
            return null;
        }

        public ScorePage(IWebDriver driver) : base(driver)
        {            
        }


        public void EnterChempionshipInput(string championShip)
        {
            _searchChempionshipInput.SendKeys(championShip);
        }

        public IWebElement GetSearchInputForClick()
        {
            return WaitAndReturmElementExist(TimeToWait, _searchInputForClick);
        }

        public IWebElement GetYearMonthElementToClick(string yearChempionShip, string mounthChempionShip)
        {
            return YearMonthElement(yearChempionShip, mounthChempionShip,_divWithYearAndMounth, _aInDivWithYearAndMounth);
        }

        public bool GetScoreTeamsToCheck(String stringTeamsScores, string team1, string team2)
        {
            WaitAndReturmElementExist(TimeToWait, listScoresAndTeams1);
            IList<IWebElement> listOfTeams = _listScoresAndTeams[0].FindElements(By.XPath("//li[@class='gs-o-list-ui__item gs-u-pb-']//div/span/span/span"));
            GetScoreTeamElement(stringTeamsScores);
            for (var i = 0; i < listOfTeams.Count; i++)
            {
                if (listOfTeams[i].Text.ToLower().Contains(team1.ToLower()))
                {
                    if (listOfTeams[i+2].Text.ToLower().Contains(team2.ToLower()))
                    {
                        if ((listOfTeams[i].Text + " " + listOfTeams[i + 1].Text + " : " + listOfTeams[i + 3].Text + " " + listOfTeams[i + 2].Text) == stringTeamsScores) return true;
                    }
                }
            }
            return false;
        }

        public bool GetScoreTeamElement(string stringTeamsScores)
        {
            WaitAndReturmElementExist(TimeToWait, listScoresAndTeams1);
            for (var i = 0; i < _listTeams.Count(); i+=4)
            {
                string resultString = _listTeams[i + 0].Text + " " + _listTeams[i + 1].Text + " : " + _listTeams[i + 3].Text + " " + _listTeams[i + 2].Text;
                Console.WriteLine(resultString);
                if (resultString == stringTeamsScores)
                {
                    return true;
                }
            }
            return false;
        }
        public IWebElement GetScoreTeamElement(string stringTeamsScores, bool returnWebElement)
        {
            WaitAndReturmElementExist(TimeToWait, listScoresAndTeams1);
            for (var i = 0; i < _listTeams.Count(); i += 4)
            {
                string resultString = _listTeams[i + 0].Text + " " + _listTeams[i + 1].Text + " : " + _listTeams[i + 3].Text + " " + _listTeams[i + 2].Text;
                Console.WriteLine(resultString);
                if (resultString == stringTeamsScores)
                {
                    return _listTeams[i];
                }
            }
            return null;
        }

        public TeamScorePage ToGoTeamScorePage(IWebElement element)
        {
            element.Click();
            return new TeamScorePage(Driver);
        }

    }
}
