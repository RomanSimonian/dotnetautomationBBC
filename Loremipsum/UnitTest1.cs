using Loremipsum_Tests.PageObjects;
using NUnit.Framework;
using OpenQA.Selenium;
using System;

namespace Loremipsum_Tests
{
    public class Tests
    {
        private IWebDriver driver; // объявляем нашу переменную вебдрайвера
        private readonly string searchWord = "рыба";
        private readonly string searchText = "Lorem ipsum dolor sit amet, consectetur adipiscing elit";
        private readonly int numberOfChecks = 10;

        [SetUp]
        public void Setup()
        {
            driver = new OpenQA.Selenium.Chrome.ChromeDriver(); // вызываем экземпляр
            driver.Navigate().GoToUrl("https://lipsum.com/"); // вводим тестируемый url
            driver.Manage().Window.Maximize(); // увеличиваем окно браузера
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30); // неявное ожидание
        }

        [Test]
        public void CheckTextContainsWord()
        {
            var mainMenu = new MainMenuPageObject(driver);
            mainMenu.ChooseRusLanguage();
            Assert.True(mainMenu.GetRusTextFirstParagraph().Contains(searchWord));
        }

        [Test]
        public void CheckCreateLoremStartWithText()
        {
            var mainMenu = new MainMenuPageObject(driver);
            mainMenu.GenerateLorem();
            var resultPage = new ResultPageObject(driver);
            Assert.True(resultPage.GetTextFirstParagraph().StartsWith(searchText));
        }

        [Test]
        public void CheckCreateWordsIsActual()
        {
            var mainMenu = new MainMenuPageObject(driver);
            var resultPage = new ResultPageObject(driver);

            mainMenu.GetGenerator(10, "words");
            Assert.IsTrue(resultPage.GetWordsActualSize().Equals(10));
            driver.Navigate().Back();
            mainMenu.GetGenerator(0, "words");
            Assert.IsTrue(resultPage.GetWordsActualSize().Equals(5));
            driver.Navigate().Back();
            mainMenu.GetGenerator(-1, "words");
            Assert.IsTrue(resultPage.GetWordsActualSize().Equals(5));
            driver.Navigate().Back();
            mainMenu.GetGenerator(20, "words");
            Assert.IsTrue(resultPage.GetWordsActualSize().Equals(20));
            driver.Navigate().Back();
            mainMenu.GetGenerator(5, "words");
            Assert.IsTrue(resultPage.GetWordsActualSize().Equals(5));
        }

        [Test]
        public void CheckCreateCharsIsActual()
        {
            var mainMenu = new MainMenuPageObject(driver);
            var resultPage = new ResultPageObject(driver);

            mainMenu.GetGenerator(10, "bytes");
            Assert.IsTrue(resultPage.GetBytesActualSize().Equals(10));
            driver.Navigate().Back();
            mainMenu.GetGenerator(-10, "bytes");
            Assert.IsTrue(resultPage.GetBytesActualSize().Equals(5));
            driver.Navigate().Back();
            mainMenu.GetGenerator(0, "bytes");
            Assert.IsTrue(resultPage.GetBytesActualSize().Equals(5));
        }

        [Test]
        public void CheckCreateLoremNotStartWithText()
        {
            var mainMenu = new MainMenuPageObject(driver);
            var resultPage = new ResultPageObject(driver);

            mainMenu.GetCheckboxBeginWithLorem();
            mainMenu.GenerateLorem();
            Assert.IsFalse(resultPage.GetTextFirstParagraph().StartsWith(searchText));

        }

        [Test]
        public void CheckProbabilityContainsWordLorem()
        {
            var mainMenu = new MainMenuPageObject(driver);
            var resultPage = new ResultPageObject(driver);
            int actualResult = 0;

            for (int i = 0; i < numberOfChecks; i++)
            {
                mainMenu.GenerateLorem();
                actualResult += resultPage.getCountParagraphWithLorem();
                driver.Navigate().Back();
            }
            Assert.IsTrue(actualResult / numberOfChecks >= 2);
        }

        [TearDown]
        public void TearDown()
        {
            driver.Quit();

        }
    }
}
//1. Выбираем при создании проэкта NUnit.Test
//2. Проэкт-управление пакетами-подключаем Selenium.WebDriver
//3. Проэкт-управление пакетами-подключаем Selenium.WebDriver.ChromeDriver!!!
