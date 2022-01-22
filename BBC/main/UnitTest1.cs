using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using BBC.main;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace BBC
{
    [TestClass]
    public class UnitTest1 : BaseTest
    {
        string firstArticle = "'A dark day': South Africans remember Desmond Tutu";
        string secondArticle = "Taliban ban long road trips for solo women";
        string thirdArticke = "US west coast battered by heavy snowstorms";
        string fourthArticle = "Canadian filmmaker Jean-Marc Vallée dies aged 58";
        string fifthArticle = "Amber Heard names new dog after feud minister";


        string question = "What questions would you like us to answer?";


        [TestMethod]
        public void checkHeadlineArticle()
        {
            GetHomePage().ClickOnGoToNews();
            Assert.IsTrue(GetNewsPage().GetHeadlineArticle().Contains("Covid-related travel chaos spills into new week"));
        }


       
        [TestMethod]
        public void ChecTitlesNameskNews()
        {
            #region
            /*
            driver.FindElement(By.XPath("//a[@href='https://www.bbc.com/news']")).Click();

            string news = driver.FindElement(By.XPath("//div[contains(@class,'gs-c-promo-body')]//a[@href='/news/uk-59688186']")).Text;
            Assert.IsTrue(news.Contains("Covid cases hit record as booster drive continues"));

            // TASK 2
            string news1 = driver.FindElement(By.XPath("//div[contains(@class,'gs-c-promo-body')]//a[@href='/news/world-africa-59689060']")).Text;
            Assert.IsTrue(news1.Contains("Haiti kidnappers release remaining missionaries"));

            string news2 = driver.FindElement(By.XPath("//div[contains(@class,'gs-c-promo-body')]//a[@href='/news/uk-59615769']")).Text;
            Assert.IsTrue(news2.Contains("RAF jet shoots down 'small hostile drone' in Syria"));

            string news3 = driver.FindElement(By.XPath("//div[contains(@class,'gs-c-promo-body')]//a[@href='/news/world-us-canada-59688787']")).Text;
            Assert.IsTrue(news3.Contains("Defence begins argument as Maxwell trial resumes"));

            string news4 = driver.FindElement(By.XPath("//div[contains(@class,'gs-c-promo-body')]//a[@href='/news/world-us-canada-59688404']")).Text;
            Assert.IsTrue(news4.Contains("Civil rights pioneer has criminal record cleared"));

            string news5 = driver.FindElement(By.XPath("//div[contains(@class,'gs-c-promo-body')]//a[@href='/news/world-latin-america-59683538']")).Text;
            Assert.IsTrue(news5.Contains("Forget Elf on a Shelf, here's Santa on a ladder..."));
           */
            #endregion
            GetHomePage().ClickOnGoToNews();
            Assert.IsTrue(GetNewsPage().GetFirstArticle().Contains(firstArticle));
            Assert.IsTrue(GetNewsPage().GetSecondArticle().Contains(secondArticle));
            Assert.IsTrue(GetNewsPage().GetThirhArticle().Contains(thirdArticke));
            Assert.IsTrue(GetNewsPage().GetFourthArticle().Contains(fourthArticle));
            Assert.IsTrue(GetNewsPage().GetFifthArticle().Contains(fifthArticle));
        }
        
        //TASK 3
        [TestMethod]
        public void CheckSearchWithTextCategoryLink()
        {
            #region
            /*
            driver.FindElement(By.XPath("//a[@href='https://www.bbc.com/news']")).Click();
            var element = driver.FindElement(By.XPath("//li//a[@href='/news/world/europe']"));
            string link = element.GetAttribute("href");


            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            driver.FindElement(By.XPath("//input[@id='orb-search-q']")).SendKeys(link);
            driver.FindElement(By.XPath("//input[@id='orb-search-q']")).SendKeys(Keys.Enter);
            string word = "Europ";


            ReadOnlyCollection<IWebElement> elementList = driver.FindElements(By.XPath("//span[@aria-hidden]"));
            for (int i = 0; i < 11; i++)
            {
                string title = elementList.ToString();
                Assert.IsTrue(title.Contains(word));
            }
            */
            #endregion
            GetHomePage().ClickOnGoToNews();
            GetNewsPage().EnterSearchInput(GetNewsPage().GetCategoryLink());
            Assert.IsTrue(GetPagesWithCategoryLinkSearch().GetFirstNewArticleWirhSearch().Contains("World"));
        }
        

       //PART 2
       [TestMethod]
       public void FillFormWithoutText()
       {
           GetHomePage().ClickOnGoToNews();
           GetNewsPage().ClickOnCoronavirusNews();

           GetCoronavirusPage().ClickOnCoronavirusStories();
           GetCoronavirusPage().GoToFormStories();
           GetHomePage().ImplicitWat(30);

           GetCoronavirusPage().ClickCloseBanner();
           GetHomePage().ImplicitWat(30);
           var userWithoutText = new Dictionary<string, string>()
           {
               {question, "" },
               { "Name", "asfasf" },
               {"Email address", "123" },
               { "Contact number", "1234123123" },
               {"Location ","kyiv" },
               {"Age","22" }
           };
           GetForm().FillForm(userWithoutText);
           Assert.IsTrue(GetCoronavirusPage().GetErrorMessageForText().Contains("can't be blank"));
            #region
            /*
           driver.FindElement(By.XPath("//a[@href='https://www.bbc.com/news']")).Click();
           driver.FindElement(By.XPath("//ul[contains(@class,'wide-sections')]//span[text()='Coronavirus']")).Click();
           driver.FindElement(By.XPath("//nav[contains(@class,'nw-c-nav__wide-secondary')]//span[text()='Your Coronavirus Stories']")).Click();
           WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
           driver.FindElement(By.XPath("//a[@href='/news/52143212']")).Click();
           driver.FindElement(By.XPath("//button[@aria-label='Close']")).Click();

           string text = "aaopjfpo,a;c,asc,afkmaskfmaksf";
           string name = "olek";

           string contactnumber = "111111111";
           string location = "Kyiv";
           string age = "twenty";
           driver.FindElement(By.XPath("//textarea[@class='text-input--long']")).SendKeys(text);
           driver.FindElement(By.XPath("//div//input[@placeholder='Name']")).SendKeys(name);

           driver.FindElement(By.XPath("//div//input[@placeholder='Contact number']")).SendKeys(contactnumber);
           driver.FindElement(By.XPath("//div//input[@placeholder='Location ']")).SendKeys(location);
           driver.FindElement(By.XPath("//div//input[@placeholder='Age']")).SendKeys(age);

           driver.FindElement(By.XPath("//input[@type='checkbox']")).Click();
           driver.FindElement(By.XPath("//button[text()='Submit']")).Click();
           driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
           WebDriverWait wait2 = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
           string error = driver.FindElement(By.XPath("//div[@class='input-error-message']")).ToString();
           if (error == "Email address can't be blank")
           {}
            */

            #endregion
        }

       [TestMethod]
       public void withoutName()
        {
            GetHomePage().ClickOnGoToNews();
            GetNewsPage().ClickOnCoronavirusNews();

            GetCoronavirusPage().ClickOnCoronavirusStories();
            GetCoronavirusPage().GoToFormStories();
            GetHomePage().ImplicitWat(30);

            GetCoronavirusPage().ClickCloseBanner();
            GetHomePage().ImplicitWat(30);
            var userWithoutName = new Dictionary<string, string>()
            {
               {question, "asokaslcpalxc" },
               { "Name", "" },
               {"Email address", "123" },
               { "Contact number", "1234123123" },
               {"Location ","kyiv" },
               {"Age","22" }
            };

            GetForm().FillForm(userWithoutName);
            Assert.IsTrue(GetCoronavirusPage().GetErrorMessageForName().Contains("Name can't be blank"));
            #region
            /*
            driver.FindElement(By.XPath("//a[@href='https://www.bbc.com/news']")).Click();
           driver.FindElement(By.XPath("//ul[contains(@class,'wide-sections')]//span[text()='Coronavirus']")).Click();
           driver.FindElement(By.XPath("//nav[contains(@class,'nw-c-nav__wide-secondary')]//span[text()='Your Coronavirus Stories']")).Click();
           WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
           driver.FindElement(By.XPath("//a[@href='/news/52143212']")).Click();
           driver.FindElement(By.XPath("//button[@aria-label='Close']")).Click();

           string text = "asasfasfaxsacsASD";
           string email = "oleksandrkarpenk@afarl";
           string contactnumber = "111111111";
           string location = "Kyiv";
           string age = "twenty";

           driver.FindElement(By.XPath("//textarea[@class='text-input--long']")).SendKeys(text);
           driver.FindElement(By.XPath("//div//input[@placeholder='Email address']")).SendKeys(email);
           driver.FindElement(By.XPath("//div//input[@placeholder='Contact number']")).SendKeys(contactnumber);
           driver.FindElement(By.XPath("//div//input[@placeholder='Location ']")).SendKeys(location);
           driver.FindElement(By.XPath("//div//input[@placeholder='Age']")).SendKeys(age);

           driver.FindElement(By.XPath("//input[@type='checkbox']")).Click();
           driver.FindElement(By.XPath("//button[text()='Submit']")).Click();

           driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
           WebDriverWait wait2 = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

           string error = driver.FindElement(By.XPath("//div[@class='input-error-message']")).ToString();
           if (error == "Name can't be blank")
           {


            }
            */
            #endregion
        }

        
       [TestMethod]
       public void notAccepted()
        {
            GetHomePage().ClickOnGoToNews();
            GetNewsPage().ClickOnCoronavirusNews();

            GetCoronavirusPage().ClickOnCoronavirusStories();
            GetCoronavirusPage().GoToFormStories();
            GetHomePage().ImplicitWat(30);

            GetCoronavirusPage().ClickCloseBanner();
            GetHomePage().ImplicitWat(30);
            var userWithoutAcceptTerms = new Dictionary<string, string>()
            {
               {question, "asclamsd;kamasd" },
               { "Name", "12aljsfnasljn" },
               {"Email address", "123" },
               { "Contact number", "1234123123" },
               {"Location ","kyiv" },
               {"Age","22" }
            };

            GetForm().FillForm(userWithoutAcceptTerms);
            GetForm().ClickOnAcceptTermsOfServices();
            Assert.IsTrue(GetCoronavirusPage().GetErrorMessageForAccept().Contains("must be accepted"));

            #region
            /*
           driver.FindElement(By.XPath("//a[@href='https://www.bbc.com/news']")).Click();
           driver.FindElement(By.XPath("//ul[contains(@class,'wide-sections')]//span[text()='Coronavirus']")).Click();
           driver.FindElement(By.XPath("//nav[contains(@class,'nw-c-nav__wide-secondary')]//span[text()='Your Coronavirus Stories']")).Click();
           WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
           driver.FindElement(By.XPath("//a[@href='/news/52143212']")).Click();
           driver.FindElement(By.XPath("//button[@aria-label='Close']")).Click();

           string text = "asasfasfaxsacsASD";
           string email = "oleksandrkarpenk@afarl";
           string name = "olek";
           string contactnumber = "111111111";
           string location = "Kyiv";
           string age = "twenty";

           driver.FindElement(By.XPath("//div//input[@placeholder='Name']")).SendKeys(name);
           driver.FindElement(By.XPath("//textarea[@class='text-input--long']")).SendKeys(text);
           driver.FindElement(By.XPath("//div//input[@placeholder='Email address']")).SendKeys(email);
           driver.FindElement(By.XPath("//div//input[@placeholder='Contact number']")).SendKeys(contactnumber);
           driver.FindElement(By.XPath("//div//input[@placeholder='Location ']")).SendKeys(location);
           driver.FindElement(By.XPath("//div//input[@placeholder='Age']")).SendKeys(age);

           driver.FindElement(By.XPath("//button[text()='Submit']")).Click();
           driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
           WebDriverWait wait2 = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
           string error = driver.FindElement(By.XPath("//div[@class='input-error-message']")).ToString();
           if (error == "must be accepted")
           {

           }
            */
            #endregion
        }


        //BBC2

        [TestMethod]
       public void BBC2_1()
       {
           GetHomePage().ClickOnGoToSport();
           GetSportPage().ClickOnGoToFootball();
            GetFootballPage().ClickOnGoToLeagues();
            GetHomePage().ImplicitWat(30);
            GetFootballPage().ClickOnGoToPremierLeague();
            GetPremierLeague().ClickOnGoToScoresAndFixtures();
            

            #region
            /*
           driver.FindElement(By.XPath("//a[@href='https://www.bbc.com/sport']")).Click();
           driver.FindElement(By.XPath("//ul[contains(@class,'sp-c-sport-navigation__inner gs-o-list-inline')]//a[@href='/sport/football']")).Click();
           driver.FindElement(By.XPath("//a[@href='/sport/football/leagues-cups']")).Click();
           driver.FindElement(By.XPath("//a[@href='https://www.bbc.co.uk/sport/football/premier-league']")).Click();
           driver.FindElement(By.XPath("//a[text()='Scores & Fixtures']")).Click();
           driver.FindElement(By.XPath("//a[@href='/sport/football/premier-league/scores-fixtures/2021-11']")).Click();

           driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

           //article[@data-event-id='EFBO2210408']//span[text()=Newcastle United'] //Newcastle United
           string firstTeam = driver.FindElement(By.XPath("//article[@data-event-id='EFBO2210408']//span[text()='Newcastle United']")).Text;
           Assert.IsTrue(firstTeam.Contains(expectedFirstTeam));
           //article[@data-event-id='EFBO2210408']//span[text()='Norwich City'] //Norwich City
           string secondTeam = driver.FindElement(By.XPath("//article[@data-event-id='EFBO2210408']//span[text()='Norwich City']")).Text;
           Assert.IsTrue(secondTeam.Contains(expectedSecondTeam));

           //span[@data-reactid='.2df5p6v3fqk.2.0.0.2.0.$0Premier LeagueTuesday-30th-November.2.$EFBO2210408-wrapper.0.0.0.0.1.0'] //goal 1
           string firstGoal = driver.FindElement(By.XPath("//span[contains(@data-reactid,'$EFBO2210408-wrapper.0.0.0.0.1.0')]")).Text;
           Assert.IsTrue(firstGoal.Contains(expectedFirstNumber));
           //span[@data-reactid='.2df5p6v3fqk.2.0.0.2.0.$0Premier LeagueTuesday-30th-November.2.$EFBO2210408-wrapper.0.0.0.2.1.0'] //goal 2
           string secondGoal = driver.FindElement(By.XPath("//span[contains(@data-reactid,'$EFBO2210408-wrapper.0.0.0.2.1.0')]")).Text;
           Assert.IsTrue(secondGoal.Contains(expectedSecondNumber));
           //li[@data-reactid='.2df5p6v3fqk.2.0.0.2.0.$0Premier LeagueTuesday-30th-November.2.$EFBO2210408-wrapper'] //go to match 
           driver.FindElement(By.XPath("//article[@data-event-id='EFBO2210408']//span[text()='Newcastle United']")).Click();

           driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

           string firstTeam2 = driver.FindElement(By.XPath("//span[@class='sp-c-fixture__team-name sp-c-fixture__team-name--home']//span[@class='gs-u-display-none gs-u-display-block@m qa-full-team-name sp-c-fixture__team-name-trunc']")).Text;

           Assert.IsTrue(firstTeam2 == expectedFirstTeam);

           string secondTeam2 = driver.FindElement(By.XPath("//span[@class='sp-c-fixture__team sp-c-fixture__team--away']//span[@class='gs-u-display-none gs-u-display-block@m qa-full-team-name sp-c-fixture__team-name-trunc']")).Text;

           Assert.IsTrue(secondTeam2 == expectedSecondTeam);

           string firstCount = driver.FindElement(By.XPath("//section[@class='sp-c-fixture sp-c-fixture--live-session-header gel-wrap']//span[@class='sp-c-fixture__number sp-c-fixture__number--home sp-c-fixture__number--ft']")).Text;

           Assert.IsTrue(firstCount == expectedFirstNumber);

           string secondCount = driver.FindElement(By.XPath("//section[@class='sp-c-fixture sp-c-fixture--live-session-header gel-wrap']//span[@class='sp-c-fixture__number sp-c-fixture__number--away sp-c-fixture__number--ft']")).Text;

           Assert.IsTrue(secondCount == expectedSecondNumber);
            */
            #endregion
        }

        
       [TestMethod]
       public void BBC2_2()
       {
            #region
            /*
               String expectedFirstTeam = "Arsenal";
               String expectedSecondTeam = "Chelsea";

               String expectedFirstNumber = "0";
               String expectedSecondNumber = "2";

               driver.FindElement(By.XPath("//a[@href='https://www.bbc.com/sport']")).Click();
               driver.FindElement(By.XPath("//ul[contains(@class,'sp-c-sport-navigation__inner gs-o-list-inline')]//a[@href='/sport/football']")).Click();
               driver.FindElement(By.XPath("//a[@href='/sport/football/leagues-cups']")).Click();
               driver.FindElement(By.XPath("//a[@href='https://www.bbc.co.uk/sport/football/premier-league']")).Click();
               driver.FindElement(By.XPath("//a[text()='Scores & Fixtures']")).Click();
               driver.FindElement(By.XPath("//button[@aria-label='previous']")).Click();
               driver.FindElement(By.XPath("//a[@href='/sport/football/premier-league/scores-fixtures/2021-08']")).Click();

               driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);


               string firstTeam = driver.FindElement(By.XPath("//span[contains(@data-reactid,'$EFBO2210281-wrapper.0.0.0.0.0.0.1')]")).Text;
               Assert.IsTrue(firstTeam.Contains(expectedFirstTeam));

               string secondTeam = driver.FindElement(By.XPath("//span[contains(@data-reactid,'$EFBO2210281-wrapper.0.0.0.2.0.0.1')]")).Text;
               Assert.IsTrue(secondTeam.Contains(expectedSecondTeam));


               string firstNumber = driver.FindElement(By.XPath("//span[contains(@data-reactid,'$EFBO2210281-wrapper.0.0.0.0.1.0')]")).Text;
               Assert.IsTrue(firstNumber.Contains(expectedFirstNumber));

               string secondNumber = driver.FindElement(By.XPath("//span[contains(@data-reactid,'$EFBO2210281-wrapper.0.0.0.2.1.0')]")).Text;
               Assert.IsTrue(secondNumber.Contains(expectedSecondNumber));

               driver.FindElement(By.XPath("//span[contains(@data-reactid,'$EFBO2210281-wrapper.0.0.0.0.0.0.1')]")).Click();
               driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

               string firstTeam2 = driver.FindElement(By.XPath("//span[@class='sp-c-fixture__team-name sp-c-fixture__team-name--home']//span[@class='gs-u-display-none gs-u-display-block@m qa-full-team-name sp-c-fixture__team-name-trunc']")).Text;
               Assert.IsTrue(firstTeam2 == expectedFirstTeam);

               string secondTeam2 = driver.FindElement(By.XPath("//span[@class='sp-c-fixture__team sp-c-fixture__team--away']//span[@class='gs-u-display-none gs-u-display-block@m qa-full-team-name sp-c-fixture__team-name-trunc']")).Text;
               Assert.IsTrue(secondTeam2 == expectedSecondTeam);

               string firstCount = driver.FindElement(By.XPath("//section[@class='sp-c-fixture sp-c-fixture--live-session-header gel-wrap']//span[@class='sp-c-fixture__number sp-c-fixture__number--home sp-c-fixture__number--ft']")).Text;
               Assert.IsTrue(firstCount == expectedFirstNumber);

               string secondCount = driver.FindElement(By.XPath("//section[@class='sp-c-fixture sp-c-fixture--live-session-header gel-wrap']//span[@class='sp-c-fixture__number sp-c-fixture__number--away sp-c-fixture__number--ft']")).Text;
               Assert.IsTrue(secondCount == expectedSecondNumber);
            */
            #endregion
       }

       [TestMethod]
       public void BBC2_3()
       {
            #region
            /*
           String expectedFirstTeam = "Dundee";
           String expectedSecondTeam = "Forfar Athletic";

           String expectedFirstNumber = "5";
           String expectedSecondNumber = "2";

           driver.FindElement(By.XPath("//a[@href='https://www.bbc.com/sport']")).Click();
           driver.FindElement(By.XPath("//ul[contains(@class,'sp-c-sport-navigation__inner gs-o-list-inline')]//a[@href='/sport/football']")).Click();
           driver.FindElement(By.XPath("//a[@href='/sport/football/leagues-cups']")).Click();
           driver.FindElement(By.XPath("//a[@href='https://www.bbc.co.uk/sport/football/scottish-league-cup']")).Click();
           driver.FindElement(By.XPath("//span[text()='Scores & Fixtures']")).Click();
           driver.FindElement(By.XPath("//button[@aria-label='previous']")).Click();
           driver.FindElement(By.XPath("//a[@href='/sport/football/scottish-league-cup/scores-fixtures/2021-07']")).Click();

           driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);


           string firstTeam = driver.FindElement(By.XPath("//span[contains(@data-reactid,'$EFBO2206456-wrapper.0.0.0.0.0.0.1')]")).Text;
           Assert.IsTrue(firstTeam.Contains(expectedFirstTeam));

           string secondTeam = driver.FindElement(By.XPath("//span[contains(@data-reactid,'$EFBO2206456-wrapper.0.0.0.2.0.0.1')]")).Text;
           Assert.IsTrue(secondTeam.Contains(expectedSecondTeam));


           string firstNumber = driver.FindElement(By.XPath("//span[contains(@data-reactid,'$EFBO2206456-wrapper.0.0.0.0.1.0')]")).Text;
           Assert.IsTrue(firstNumber.Contains(expectedFirstNumber));

           string secondNumber = driver.FindElement(By.XPath("//span[contains(@data-reactid,'$EFBO2206456-wrapper.0.0.0.2.1.0')]")).Text;
           Assert.IsTrue(secondNumber.Contains(expectedSecondNumber));

           driver.FindElement(By.XPath("//span[contains(@data-reactid,'$EFBO2206456-wrapper.0.0.0.2.1.0')]")).Click();
           driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

           string firstTeam2 = driver.FindElement(By.XPath("//span[@class='sp-c-fixture__team-name sp-c-fixture__team-name--home']//span[@class='gs-u-display-none gs-u-display-block@m qa-full-team-name sp-c-fixture__team-name-trunc']")).Text;
           Assert.IsTrue(firstTeam2 == expectedFirstTeam);

           string secondTeam2 = driver.FindElement(By.XPath("//span[@class='sp-c-fixture__team sp-c-fixture__team--away']//span[@class='gs-u-display-none gs-u-display-block@m qa-full-team-name sp-c-fixture__team-name-trunc']")).Text;
           Assert.IsTrue(secondTeam2 == expectedSecondTeam);

           string firstCount = driver.FindElement(By.XPath("//section[@class='sp-c-fixture sp-c-fixture--live-session-header gel-wrap']//span[@class='sp-c-fixture__number sp-c-fixture__number--home sp-c-fixture__number--ft']")).Text;
           Assert.IsTrue(firstCount == expectedFirstNumber);

           string secondCount = driver.FindElement(By.XPath("//section[@class='sp-c-fixture sp-c-fixture--live-session-header gel-wrap']//span[@class='sp-c-fixture__number sp-c-fixture__number--away sp-c-fixture__number--ft']")).Text;
           Assert.IsTrue(secondCount == expectedSecondNumber);
             */
            #endregion
       }

       [TestMethod]
       public void BBC2_4()
       {
            #region
            /*
           String expectedFirstTeam = "Manchester City";
           String expectedSecondTeam = "RB Leipzig";

           String expectedFirstNumber = "6";
           String expectedSecondNumber = "3";

           driver.FindElement(By.XPath("//a[@href='https://www.bbc.com/sport']")).Click();
           driver.FindElement(By.XPath("//ul[contains(@class,'sp-c-sport-navigation__inner gs-o-list-inline')]//a[@href='/sport/football']")).Click();
           driver.FindElement(By.XPath("//a[@href='/sport/football/leagues-cups']")).Click();
           driver.FindElement(By.XPath("//span[text()='Champions League']")).Click();

           driver.FindElement(By.XPath("//span[text()='Scores & Fixtures']")).Click();
           driver.FindElement(By.XPath("//a[@href='/sport/football/champions-league/scores-fixtures/2021-09']")).Click();

           driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);


           string firstTeam = driver.FindElement(By.XPath("//span[contains(@data-reactid,'.$EFBO2244579-wrapper.0.0.0.0.0.0.1')]")).Text;
           Assert.IsTrue(firstTeam.Contains(expectedFirstTeam));

           string secondTeam = driver.FindElement(By.XPath("//span[contains(@data-reactid,'$EFBO2244579-wrapper.0.0.0.2.0.0.1')]")).Text;
           Assert.IsTrue(secondTeam.Contains(expectedSecondTeam));


           string firstNumber = driver.FindElement(By.XPath("//span[contains(@data-reactid,'$EFBO2244579-wrapper.0.0.0.0.1.0')]")).Text;
           Assert.IsTrue(firstNumber.Contains(expectedFirstNumber));

           string secondNumber = driver.FindElement(By.XPath("//span[contains(@data-reactid,'$EFBO2244579-wrapper.0.0.0.2.1.0')]")).Text;
           Assert.IsTrue(secondNumber.Contains(expectedSecondNumber));

           driver.FindElement(By.XPath("//span[contains(@data-reactid,'$EFBO2244579-wrapper.0.0.0.2.1.0')]")).Click();
           driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

           string firstTeam2 = driver.FindElement(By.XPath("//span[@class='sp-c-fixture__team-name sp-c-fixture__team-name--home']//span[@class='gs-u-display-none gs-u-display-block@m qa-full-team-name sp-c-fixture__team-name-trunc']")).Text;
           Assert.IsTrue(firstTeam2 == expectedFirstTeam);

           string secondTeam2 = driver.FindElement(By.XPath("//span[@class='sp-c-fixture__team sp-c-fixture__team--away']//span[@class='gs-u-display-none gs-u-display-block@m qa-full-team-name sp-c-fixture__team-name-trunc']")).Text;
           Assert.IsTrue(secondTeam2 == expectedSecondTeam);

           string firstCount = driver.FindElement(By.XPath("//section[@class='sp-c-fixture sp-c-fixture--live-session-header gel-wrap']//span[@class='sp-c-fixture__number sp-c-fixture__number--home sp-c-fixture__number--ft']")).Text;
           Assert.IsTrue(firstCount == expectedFirstNumber);

           string secondCount = driver.FindElement(By.XPath("//section[@class='sp-c-fixture sp-c-fixture--live-session-header gel-wrap']//span[@class='sp-c-fixture__number sp-c-fixture__number--away sp-c-fixture__number--ft']")).Text;
           Assert.IsTrue(secondCount == expectedSecondNumber);
            */
            #endregion
       }

       [TestMethod]
       public void BBC2_5()
       {
            #region
            /*
           String expectedFirstTeam = "Rotherham United";
           String expectedSecondTeam = "Burton Albion";

           String expectedFirstNumber = "3";
           String expectedSecondNumber = "1";

           driver.FindElement(By.XPath("//a[@href='https://www.bbc.com/sport']")).Click();
           driver.FindElement(By.XPath("//ul[contains(@class,'sp-c-sport-navigation__inner gs-o-list-inline')]//a[@href='/sport/football']")).Click();
           driver.FindElement(By.XPath("//a[@href='/sport/football/leagues-cups']")).Click();
           driver.FindElement(By.XPath("//span[text()='League One']")).Click();

           driver.FindElement(By.XPath("//span[text()='Scores & Fixtures']")).Click();
           driver.FindElement(By.XPath("//a[@href='/sport/football/league-one/scores-fixtures/2021-12?filter=results']")).Click();

           driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);


           string firstTeam = driver.FindElement(By.XPath("//span[contains(@data-reactid,'$EFBO2213688-wrapper.0.0.0.0.0.0.1')]")).Text;
           Assert.IsTrue(firstTeam.Contains(expectedFirstTeam));

           string secondTeam = driver.FindElement(By.XPath("//span[contains(@data-reactid,'$EFBO2213688-wrapper.0.0.0.2.0.0.1')]")).Text;
           Assert.IsTrue(secondTeam.Contains(expectedSecondTeam));


           string firstNumber = driver.FindElement(By.XPath("//span[contains(@data-reactid,'$EFBO2213688-wrapper.0.0.0.0.1.0')]")).Text;
           Assert.IsTrue(firstNumber.Contains(expectedFirstNumber));

           string secondNumber = driver.FindElement(By.XPath("//span[contains(@data-reactid,'$EFBO2213688-wrapper.0.0.0.2.1.0')]")).Text;
           Assert.IsTrue(secondNumber.Contains(expectedSecondNumber));

           driver.FindElement(By.XPath("//span[contains(@data-reactid,'$EFBO2213688-wrapper.0.0.0.2.1.0')]")).Click();
           driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

           string firstTeam2 = driver.FindElement(By.XPath("//span[@class='sp-c-fixture__team-name sp-c-fixture__team-name--home']//span[@class='gs-u-display-none gs-u-display-block@m qa-full-team-name sp-c-fixture__team-name-trunc']")).Text;
           Assert.IsTrue(firstTeam2 == expectedFirstTeam);

           string secondTeam2 = driver.FindElement(By.XPath("//span[@class='sp-c-fixture__team sp-c-fixture__team--away']//span[@class='gs-u-display-none gs-u-display-block@m qa-full-team-name sp-c-fixture__team-name-trunc']")).Text;
           Assert.IsTrue(secondTeam2 == expectedSecondTeam);

           string firstCount = driver.FindElement(By.XPath("//section[@class='sp-c-fixture sp-c-fixture--live-session-header gel-wrap']//span[@class='sp-c-fixture__number sp-c-fixture__number--home sp-c-fixture__number--ft']")).Text;
           Assert.IsTrue(firstCount == expectedFirstNumber);

           string secondCount = driver.FindElement(By.XPath("//section[@class='sp-c-fixture sp-c-fixture--live-session-header gel-wrap']//span[@class='sp-c-fixture__number sp-c-fixture__number--away sp-c-fixture__number--ft']")).Text;
           Assert.IsTrue(secondCount == expectedSecondNumber);
            */
            #endregion
       }
    }
}
