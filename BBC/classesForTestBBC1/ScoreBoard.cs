using System;
using BBC.classesForTest;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;



namespace BBC.classesForTestBBC1
{
    public class ScoreBoard : BasePage
    {
        


        //public Score GetScore(string team1, string team2)
        //{

            
            
        //}



        public ScoreBoard(WebDriver driver) : base(driver) { }

    }

    public class Score
    {
        public string firstNumber { get; set; }
        public string secondNumber { get; set; }




        public Score(string first, string second)
        {
            this.firstNumber = first;
            this.secondNumber = second;
        }
    }
}
