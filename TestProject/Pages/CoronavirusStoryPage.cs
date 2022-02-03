using OpenQA.Selenium;

namespace TestProject.Pages
{
	public class CoronavirusStoryPage : BasePage
	{
		private readonly By _myCoronavirusStoryPage = By.XPath("//a[@href='/news/52143212']");

		public CoronavirusStoryPage(IWebDriver driver) : base(driver) { }

		public MyCoronavirusStoryPage GoToMyCoronavirusStoryPage()
		{
			Driver.FindElement(_myCoronavirusStoryPage).Click();
			return new MyCoronavirusStoryPage(Driver);
		}
	}
}