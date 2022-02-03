using NUnit.Framework;
using TechTalk.SpecFlow;

namespace TestProject.StepDefinitions
{
	[Binding]
	public class Steps : BaseSteps
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

		[Then(@"User fills: '(.*)', '(.*)', '(.*)', '(.*)', '(.*)', '(.*)' fields")]
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

		[Then(@"User checks result with expected '(.*)'t be blank' message")]
		public void ThenUserChecksResultWithExpectedTBeBlankMessage(string error)
		{
			Assert.IsTrue(MyCoronavirusStory_Page.GetErrorMessage().Contains(error));
		}



		[When(@"User enter the text of the Category link of headline article")]
		public void WhenUserEnterTheTextOfTheCategoryLinkOfHeadlineArticle()
		{
			News_Page.SearchByWord(News_Page.GetTextOfHeadline(0));
		}

		[Then(@"User check the name of the first article against a text of headline article")]
		public void ThenUserCheckTheNameOfTheFirstArticleAgainstATextOfHeadlineArticle()
		{
			string notExcepted = SearchResult_Page.GetTextOfSearchResultElement(0);
			string excepted = News_Page.GetTextOfHeadline(0);
			Assert.IsTrue(notExcepted.Equals(excepted));
		}
	}
}