using OpenQA.Selenium;

namespace TestProject.Pages
{
	public class NewsPage : BasePage
	{
		private readonly By _coronavirusPage = By.XPath("//ul[@class='gs-o-list-ui--top-no-border nw-c-nav__wide-sections']//a[@href='/news/coronavirus']");
		private readonly By _searchInput = By.XPath("//input[@placeholder='Search']");
		
		public NewsPage(IWebDriver driver) : base(driver) { }

		public CoronavirusPage GoToCoronavirusPage()
		{
		Driver.FindElement(_coronavirusPage).Click();
		return new CoronavirusPage(Driver);
		}

		public SearchResultPage SearchByWord(string word)
		{
			Driver.FindElement(_searchInput).SendKeys(word);
			return new SearchResultPage(Driver);
		}
	}
}