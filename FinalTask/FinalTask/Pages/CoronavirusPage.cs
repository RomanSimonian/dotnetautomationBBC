using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;

namespace FinalTask.Pages
{
	public class CoronavirusPage : BasePage
	{
		[FindsBy(How = How.XPath, Using = @"//div[@class='gs-u-display-none gs-u-display-block@m']//a[@href='/news/have_your_say']")]
		private IWebElement _coronavirusStoryPage;
 
		public CoronavirusPage(IWebDriver driver) : base(driver) {}

		public CoronavirusStoryPage GoToCoronavirusStoryPage()
		{
			_coronavirusStoryPage.Click();
			return new CoronavirusStoryPage(Driver);
		}
	}
}