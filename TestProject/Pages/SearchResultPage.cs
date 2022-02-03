using OpenQA.Selenium;
using System.Collections.Generic;

namespace TestProject.Pages
{
	public class SearchResultPage : BasePage
	{
		private readonly By _coronavirusPage = By.XPath("//ul[@class='gs-o-list-ui--top-no-border nw-c-nav__wide-sections']//a[@href='/news/coronavirus']");
		private readonly By _searchResultElements = By.XPath("//ul[@spacing='responsive']");

		public SearchResultPage(IWebDriver driver) : base(driver) { }

		public CoronavirusPage GoToCoronavirusPage()
		{
		Driver.FindElement(_coronavirusPage).Click();
		return new CoronavirusPage(Driver);
		}

		public string GetTextOfSearchResultElement(int numberOfElement)
		{
			IList<IWebElement> ListOfSearchResults = Driver.FindElements(_searchResultElements);
			return ListOfSearchResults[numberOfElement].Text;
		}
	}
}