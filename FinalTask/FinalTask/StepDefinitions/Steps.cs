using System;
using TechTalk.SpecFlow;

namespace FinalTask.StepDefinitions
{
    [Binding]
    public class BBC1TaskTestSteps : BaseStepDefinitions
    {
        [Given(@"User opens homepage page BBC(.*)")]
        public void GivenUserOpensHomepagePageBBC(int p0)
        {
            Home_Page = new FinalTask.Pages.HomePage(Driver);
        }
        
        [When(@"User clicks on News tab(.*)")]
        public void WhenUserClicksOnNewsTab(int p0)
        {
            News_Page = Home_Page.GoToNewsPage();
        }
        
        [When(@"User clicks on Coronavirus tab(.*)")]
        public void WhenUserClicksOnCoronavirusTab(int p0)
        {
            Coronavirus_Page = News_Page.GoToCoronavirusPage();
        }
        
        [When(@"User clicks on Your Coronavirus Stories tab(.*)")]
        public void WhenUserClicksOnYourCoronavirusStoriesTab(int p0)
        {
            CoronavirusStory_Page = Coronavirus_Page.GoToCoronavirusStoryPage();
        }
        
        [When(@"User clicks on question field(.*)")]
        public void WhenUserClicksOnQuestionField(int p0)
        {
            ScenarioContext.Current.Pending();
        }
        
        [When(@"User fills question field(.*)")]
        public void WhenUserFillsQuestionField(int p0)
        {
            ScenarioContext.Current.Pending();
        }
        
        [When(@"User fills name field(.*)")]
        public void WhenUserFillsNameField(int p0)
        {
            ScenarioContext.Current.Pending();
        }
        
        [When(@"User fills email field(.*)")]
        public void WhenUserFillsEmailField(int p0)
        {
            ScenarioContext.Current.Pending();
        }
        
        [When(@"User fills number field(.*)")]
        public void WhenUserFillsNumberField(int p0)
        {
            ScenarioContext.Current.Pending();
        }
        
        [When(@"User fills location field(.*)")]
        public void WhenUserFillsLocationField(int p0)
        {
            ScenarioContext.Current.Pending();
        }
        
        [When(@"User fills age field(.*)")]
        public void WhenUserFillsAgeField(int p0)
        {
            ScenarioContext.Current.Pending();
        }
        
        [When(@"User click on checkbox(.*)")]
        public void WhenUserClickOnCheckbox(int p0)
        {
            ScenarioContext.Current.Pending();
        }
        
        [When(@"User pushes submit button(.*)")]
        public void WhenUserPushesSubmitButton(int p0)
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"User checks result(.*)")]
        public void ThenUserChecksResult(int p0)
        {
            ScenarioContext.Current.Pending();
        }
    }
}
