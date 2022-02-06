using System.Collections.Generic;
using System.Collections.ObjectModel;
using FinalProlect.Classes_for_test;
using FinalProlect.main;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace FinalProlect
{

    [TestClass]
    public class Ipsum : BaseTest
    {
        string expectedWord = "рыба";

        string expectedStartWithWords = "Lorem ipsum dolor sit amet, consectetur adipiscing elit";

        [TestMethod]
        public void SearchFishWord()
        {
            GetHomePage().ClickOnSelectLanguage("Pyccкий");

            Assert.IsTrue( GetHomePage().GetTextFromParagraph(1).Contains(expectedWord));
        }
        
        [TestMethod]
        public void VerifyFirstWords()
        {
            GetHomePage().ClickOnSubmitGenerate();

            Assert.IsTrue(GetHomePage().GetTextFromParagraph(1).StartsWith(expectedStartWithWords));
        }

        //Part2//TASK 1
        [TestMethod]
        public void GenerateTenWords()
        {
            GetRadioButton().SetValue("words");
            GetHomePage().EnterAmountOfCharacters("10");
            GetHomePage().ClickOnSubmitGenerate();
           
            Assert.IsTrue(GetGeneratedPages().GetResultGenerated().Contains("10 words"));
        }

        [TestMethod]
        public void GenerateMinusOneAmountWords()
        {
            GetRadioButton().SetValue("words");
            GetHomePage().EnterAmountOfCharacters("-1");
            GetHomePage().ClickOnSubmitGenerate();

            Assert.IsFalse(GetGeneratedPages().GetResultGenerated().Contains("-1 words"));
        }
        

        [TestMethod]
        public void GenerateZeroWords()
        {
            GetRadioButton().SetValue("words");
            GetHomePage().EnterAmountOfCharacters("0");
            GetHomePage().ClickOnSubmitGenerate();

            Assert.IsFalse(GetGeneratedPages().GetResultGenerated().Contains("0 words"));
        }
        
        [TestMethod]
        public void GenerateFiveWords()
        {
            GetRadioButton().SetValue("words");
            GetHomePage().EnterAmountOfCharacters("5");
            GetHomePage().ClickOnSubmitGenerate();

            Assert.IsTrue(GetGeneratedPages().GetResultGenerated().Contains("5 words"));
        }

        [TestMethod]
        public void GenerateTwentyWords()
        {
            GetRadioButton().SetValue("words");
            GetHomePage().EnterAmountOfCharacters("20");
            GetHomePage().ClickOnSubmitGenerate();

            Assert.IsTrue(GetGeneratedPages().GetResultGenerated().Contains("20 words"));
        }

        [TestMethod]
        public void GenerateThirtyFiveBytes()
        {
            GetRadioButton().SetValue("bytes");
            GetHomePage().EnterAmountOfCharacters("35");
            GetHomePage().ClickOnSubmitGenerate();

            Assert.IsTrue(GetGeneratedPages().GetResultGenerated().Contains("35 bytes"));
        }

        [TestMethod]
        public void GenerateZeroBytes()
        {
            GetRadioButton().SetValue("bytes");
            GetHomePage().EnterAmountOfCharacters("0");
            GetHomePage().ClickOnSubmitGenerate();

            Assert.IsFalse(GetGeneratedPages().GetResultGenerated().Contains("0 bytes"));
        }

        [TestMethod]
        public void GenerateMinusFiveBytes()
        {
            GetRadioButton().SetValue("bytes");
            GetHomePage().EnterAmountOfCharacters("-5");
            GetHomePage().ClickOnSubmitGenerate();

            Assert.IsFalse(GetGeneratedPages().GetResultGenerated().Contains("-5 bytes"));
        }
        
        //TASK 2
        [TestMethod]
        public void VerifyCheckBoxAndStartFromWords()
        {
            GetHomePage().ClickOnBoxStartWithLorem();

            Assert.IsFalse(GetHomePage().GetTextFromParagraph(1).StartsWith("Lorem ipsum"));
        }
       
        //TASK 3
        [TestMethod]
        public void ProbabilityLoremWordInParagraph()
        {
            int totatcount = 0;
            for (int i = 0; i < 10; i++)
            {
                GetHomePage().ClickOnSubmitGenerate();

                int count = 0;

                foreach (WebElement webElement in GetGeneratedPages().GetListFromParagraphs())
                {
                    if (webElement.Text.Contains("lorem")) { count++; }
                }
                if (count >= 3) { totatcount++; }

                GetGeneratedPages().ClickGoHome();
            }
            Assert.IsTrue(totatcount > 4);        
        }  
    }
}
