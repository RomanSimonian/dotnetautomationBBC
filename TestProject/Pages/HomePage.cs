using OpenQA.Selenium;

namespace TestProject.Pages
{
	public class HomePage : BasePage
	{
		private readonly By _newsPage = By.XPath("//div[@id='orb-nav-links']//li[@class='orb-nav-newsdotcom']");

		public HomePage(IWebDriver driver) : base(driver) { }

		public NewsPage GoToNewsPage()
		{
			Driver.FindElement(_newsPage).Click();
			return new NewsPage(Driver);
		}
	}
}