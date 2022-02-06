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

        string expectedTenAmountWords = "10 words";
        string expectedMinusOneAmountWords = "-1 words";
        string expectedZeroAmountWords = "0 words";
        string expectedFiveWords = "5 words";
        string expectedTwentyWords = "20 words";
        string expectedThirtyFiveBytes = "35 bytes";
        string expectedZeroBytes = "0 bytes";
        string expectedMinusFiveAmountBytes = "-5 bytes";

        string wordButton = "words";
        string bytesButton = "bytes";
        string paragraphButton = "paras";
        string listsButton = "lists";





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
            GetRadioButton().SetValue(wordButton);
            GetHomePage().EnterAmountOfCharacters("10");
            GetHomePage().ClickOnSubmitGenerate();
           
            Assert.IsTrue(GetGeneratedPages().GetResultGenerated().Contains(expectedTenAmountWords));
        }

        [TestMethod]
        public void GenerateMinusOneAmountWords()
        {
            GetRadioButton().SetValue(wordButton);
            GetHomePage().EnterAmountOfCharacters("-1");
            GetHomePage().ClickOnSubmitGenerate();

            Assert.IsFalse(GetGeneratedPages().GetResultGenerated().Contains(expectedMinusOneAmountWords));
        }
        

        [TestMethod]
        public void GenerateZeroWords()
        {
            GetRadioButton().SetValue(wordButton);
            GetHomePage().EnterAmountOfCharacters("0");
            GetHomePage().ClickOnSubmitGenerate();

            Assert.IsFalse(GetGeneratedPages().GetResultGenerated().Contains(expectedZeroAmountWords));
        }
        
        [TestMethod]
        public void GenerateFiveWords()
        {
            GetRadioButton().SetValue(wordButton);
            GetHomePage().EnterAmountOfCharacters("5");
            GetHomePage().ClickOnSubmitGenerate();

            Assert.IsTrue(GetGeneratedPages().GetResultGenerated().Contains(expectedFiveWords));
        }

        [TestMethod]
        public void GenerateTwentyWords()
        {
            GetRadioButton().SetValue(wordButton);
            GetHomePage().EnterAmountOfCharacters("20");
            GetHomePage().ClickOnSubmitGenerate();

            Assert.IsTrue(GetGeneratedPages().GetResultGenerated().Contains(expectedTwentyWords));
        }

        [TestMethod]
        public void GenerateThirtyFiveBytes()
        {
            GetRadioButton().SetValue(bytesButton);
            GetHomePage().EnterAmountOfCharacters("35");
            GetHomePage().ClickOnSubmitGenerate();

            Assert.IsTrue(GetGeneratedPages().GetResultGenerated().Contains(expectedThirtyFiveBytes));
        }

        [TestMethod]
        public void GenerateZeroBytes()
        {
            GetRadioButton().SetValue(bytesButton);
            GetHomePage().EnterAmountOfCharacters(0"");
            GetHomePage().ClickOnSubmitGenerate();

            Assert.IsFalse(GetGeneratedPages().GetResultGenerated().Contains(expectedZeroBytes));
        }

        [TestMethod]
        public void GenerateMinusFiveBytes()
        {
            GetRadioButton().SetValue(bytesButton);
            GetHomePage().EnterAmountOfCharacters("-5"));
            GetHomePage().ClickOnSubmitGenerate();

            Assert.IsFalse(GetGeneratedPages().GetResultGenerated().Contains(expectedMinusFiveAmountBytes));
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
