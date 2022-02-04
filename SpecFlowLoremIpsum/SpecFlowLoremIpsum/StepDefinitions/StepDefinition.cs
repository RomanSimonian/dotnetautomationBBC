using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SpecFlowLoremIpsum.Pages;
using System.Linq;
using TechTalk.SpecFlow;
using static SpecFlowLoremIpsum.Manager.PageFacrtoryManager;

namespace SpecFlowLoremIpsum.StepDefinitions
{
    [Binding]
    public sealed class StepDefinition
    {
        WebDriver driver;
        PageFactoryManager pageFactoryManager;
        HomePage homePage;
        GeneratePage generatePage;
        RadioButton radioButton;

        readonly String URL = "https://www.bbc.com/";

        [BeforeScenario]
        public void BeforeScenario()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl(URL);
            pageFactoryManager = new PageFactoryManager(driver);
        }

        [AfterScenario]
        public void AfterScenario()
        {
            driver.Close();
        }

        [Given(@"User opens '([^']*)' page")]
        public void OpensPage(string url)
        {
            
            homePage = pageFactoryManager.GetHomePage();
            homePage.OpenHomePage(url);
            homePage = pageFactoryManager.GetHomePage();
        }

        [Given(@"User checks buttons language visibility")]
        public bool ChecksButonSelectLanguageVisibility()
        {
            homePage = pageFactoryManager.GetHomePage();

            return homePage.IsSelectLanguageButtonVisible;
        }

        [When(@"User clicks on button '([^']*)'")]
        public void ClickOnButtonSelectRussiannLanguage(string language)
        {
            homePage.ClickOnSelectLanguage(language);
        }

        [When(@"User checks text vidibiluty")]
        public void ChecksTextVidibility()
        {
            throw new PendingStepException();
        }

        [When(@"User checks text visibility")]
        public bool CheckTextVisibility()
        {
           return homePage.IsFirstParagraphVisible;
        }

        [Then(@"User checks (.*) include '([^']*)'")]
        public void ThenUserChecksInclude(int numberOfParagraph, string word)
        {
            Assert.IsTrue(homePage.GetTextFromParagraph(numberOfParagraph).Contains(word));
        }


        [Then(@"User checks (.*) starts with '([^']*)'")]
        public void ThenUserChecksStartsWith(int numberOfParagraph, string words)
        {
            Assert.IsTrue(homePage.GetTextFromParagraph(numberOfParagraph).Contains(words));
        }


        [When(@"User clicks submit button")]
        public void ClickSubmitButton()
        {
            homePage.ClickOnSubmitGenerate();
        }

        [Given(@"User checks button generate visibility")]
        public bool CheckButtonGenerateVisibility()
        {
            return homePage.IsSubmitButtonGenerateVisible;
        }

        [Given(@"User checks count field visibility")]
        public bool CheckCountFieldVisibility()
        {
           return homePage.IsIconAmountVisible;
        }

        [Given(@"User checks button '([^']*)' visibility")]
        public void CheckButtonVisibility(string value)
        {
            radioButton = pageFactoryManager.GetRadioButton();
            radioButton.IsButtoncharacterVisible(value);    
        }

        [When(@"User clicks button '([^']*)'")]
        public void ClickButtonValue(string value)
        {
            radioButton.SetValue(value);
        }

        [When(@"User enters '([^']*)' number")]
        public void EnterAmount(string amount)
        {
            homePage.EnterAmountOfCharacters(amount);
        }

        [Then(@"User checks generate page include '([^']*)' '([^']*)'")]
        public void CheckGeneratePageInclude(string amount, string value)
        {
            generatePage = pageFactoryManager.GetGeneratePages();
            Assert.IsTrue(generatePage.GetResultGenerated().Contains(amount));
            Assert.IsTrue(generatePage.GetResultGenerated().Contains(value));
        }

        [When(@"User checks checkbox start with lorem ipsum visibility")]
        public bool CheckCheckboxStartWithLoremIpsumVisibility()
        {
           return homePage.IsCheckBoxStartWithLoremVisible;
        }

        [When(@"User clicks checkbox start with lorem ipsum visibility")]
        public void ClickCheckboxStartWithLoremIpsumVisibility()
        {
            homePage.ClickOnBoxStartWithLorem();
        }

        [Then(@"User checks (.*) not starts from '([^']*)'")]
        public void ThenUserChecksNotStartsFrom(int numberOfParagraph, string words)
        {
            Assert.IsTrue(homePage.GetTextFromParagraph(numberOfParagraph).Contains(words));
        }


        [Then(@"User clicks submit button and count paragraps include word lorem and checks probability lorem word")]
        public void ClickSubmitButtonAndCountParagrapsIncludeWordLorem()
        {
            int totalcount = 0;
            for (int i = 0; i < 10; i++)
            {
                homePage.ClickOnSubmitGenerate();

                int count = 0;

                generatePage = pageFactoryManager.GetGeneratePages();
                foreach (WebElement webElement in generatePage.GetListFromParagraphs())
                {
                    if (webElement.Text.Contains("lorem")) { count++; }
                }
                if (count >= 3) { totalcount++; }

                generatePage.ClickGoHome();
            }

            Assert.IsTrue(totalcount > 3);
        }
    }
}