using OpenQA.Selenium;

namespace TestProject.Pages
{
	public class CoronavirusPage : BasePage
	{
		private readonly By _coronavirusStoryPage = By.XPath("//div[@class='gs-u-display-none gs-u-display-block@m']//a[@href='/news/have_your_say']");

		public CoronavirusPage(IWebDriver driver) : base(driver) { }

		public CoronavirusStoryPage GoToCoronavirusStoryPage()
		{
			Driver.FindElement(_coronavirusStoryPage).Click();
			return new CoronavirusStoryPage(Driver);
		}
	}
}