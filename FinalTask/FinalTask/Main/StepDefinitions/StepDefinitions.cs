using System;
using TechTalk.SpecFlow;

namespace FinalTask.Main.StepDefinitions
{
    [Binding]
    public class BBC1TaskTestSteps : BaseStepDefinitions
    {
        [Given]
        public void Given_User_opens_homepage_page_BBC()
        {
            Home_Page = new FinalTask.Main.Pages.HomePage(Driver);
        }
        
        [When]
        public void When_User_clicks_on_News_tab()
        {
            News_Page = Home_Page.GoToNewsPage();
        }
        
        [When]
        public void When_User_clicks_on_Coronavirus_tab()
        {
            Coronavirus_Page = News_Page.GoToCoronavirusPage();
        }
        
        [When]
        public void When_User_clicks_on_Your_Coronavirus_Stories_tab()
        {
            CoronavirusStory_Page = Coronavirus_Page.GoToCoronavirusStoryPage();
        }
        
        [When]
        public void When_User_clicks_on_question_field()
        {
            ScenarioContext.Current.Pending();
        }
        
        [When]
        public void When_User_fills_question_field()
        {
            ScenarioContext.Current.Pending();
        }
        
        [When]
        public void When_User_fills_name_field()
        {
            ScenarioContext.Current.Pending();
        }
        
        [When]
        public void When_User_fills_email_field()
        {
            ScenarioContext.Current.Pending();
        }
        
        [When]
        public void When_User_fills_number_field()
        {
            ScenarioContext.Current.Pending();
        }
        
        [When]
        public void When_User_fills_location_field()
        {
            ScenarioContext.Current.Pending();
        }
        
        [When]
        public void When_User_fills_age_field()
        {
            ScenarioContext.Current.Pending();
        }
        
        [When]
        public void When_User_click_on_checkbox()
        {
            ScenarioContext.Current.Pending();
        }
        
        [When]
        public void When_User_pushes_submit_button()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then]
        public void Then_User_checks_result()
        {
            ScenarioContext.Current.Pending();
        }
    }
}
