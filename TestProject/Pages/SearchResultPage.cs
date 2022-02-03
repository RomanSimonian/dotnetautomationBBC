using OpenQA.Selenium;

namespace TestProject.Pages
{
	public class SearchResultPage : BasePage
	{
		private readonly By _coronavirusPage = By.XPath("//ul[@class='gs-o-list-ui--top-no-border nw-c-nav__wide-sections']//a[@href='/news/coronavirus']");

		public SearchResultPage(IWebDriver driver) : base(driver) { }

		public CoronavirusPage GoToCoronavirusPage()
		{
		Driver.FindElement(_coronavirusPage).Click();
		return new CoronavirusPage(Driver);
		}
	}
}