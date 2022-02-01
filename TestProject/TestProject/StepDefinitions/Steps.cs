using System;
using TechTalk.SpecFlow;

namespace TestProject.StepDefinitions
{
    [Binding]
    public class BBC1TaskTestSteps : BaseStepDefinitions
    {
        [Given(@"User opens homepage page BBC")]
        public void GivenUserOpensHomepagePageBBC()
        {
            Home_Page = new Pages.HomePage(Driver);
        }

        [When(@"User clicks on News tab")]
        public void WhenUserClicksOnNewsTab()
        {
            News_Page = Home_Page.GoToNewsPage();
        }

        [When(@"User clicks on Coronavirus tab")]
        public void WhenUserClicksOnCoronavirusTab()
        {
            Coronavirus_Page = News_Page.GoToCoronavirusPage();
        }

        [When(@"User clicks on Your Coronavirus Stories tab")]
        public void WhenUserClicksOnYourCoronavirusStoriesTab()
        {
            CoronavirusStory_Page = Coronavirus_Page.GoToCoronavirusStoryPage();
        }

        [When(@"User clicks on question field")]
        public void WhenUserClicksOnQuestionField()
        {
            MyCoronavirusStory_Page = CoronavirusStory_Page.GoToMyCoronavirusStoryPage();
        }

        [Then(@"User fills: (.*), (.*), (.*), (.*), (.*), (.*) fields")]
        public void ThenUserFillsFields(string question, string name, string email, string number, string location, string age)
        {
            MyCoronavirusStory_Page.FillTheForm(question, name, email, number, location, age);
        }

        [Then(@"User click on checkbox")]
        public void ThenUserClickOnCheckbox()
        {
            MyCoronavirusStory_Page.ClickCheckBox();
        }
        
        [Then(@"User pushes submit button")]
        public void ThenUserPushesSubmitButton()
        {
            MyCoronavirusStory_Page.ClickSubmitButton();
        }

        [Then(@"User checks result")]
        public void ThenUserChecksResult()
        {
            MyCoronavirusStory_Page.ClickSubmitButton();
        }
    }
}
