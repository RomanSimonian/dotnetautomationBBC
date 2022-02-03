using OpenQA.Selenium;
using System.Collections.Generic;

namespace TestProject.Pages
{
	public class NewsPage : BasePage
	{
		private readonly By _coronavirusPage = By.XPath("//ul[@class='gs-o-list-ui--top-no-border nw-c-nav__wide-sections']//a[@href='/news/coronavirus']");
		private readonly By _searchInput = By.XPath("//input[@placeholder='Search']");
		private readonly By _headlines = By.XPath("//p[@class='gs-c-promo-summary gel-long-primer gs-u-mt nw-c-promo-summary']");

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

		public string GetTextOfHeadline(int numberOfElement)
		{
			IList<IWebElement> ListOfHeadlines = Driver.FindElements(_headlines);
			return ListOfHeadlines[numberOfElement].Text;
		}
	}
}