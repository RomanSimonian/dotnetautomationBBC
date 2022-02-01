using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;

namespace TestProject.Pages
{
	public class CoronavirusStoryPage : BasePage
	{
		[FindsBy(How = How.XPath, Using = @"//a[@href='/news/52143212']")]
		private IWebElement _myCoronavirusStoryPage;

		public CoronavirusStoryPage(IWebDriver driver) : base(driver) { }

		public MyCoronavirusStoryPage GoToMyCoronavirusStoryPage()
		{
			base.ImplicitlyWait(30);
			_myCoronavirusStoryPage.Click();
			return new MyCoronavirusStoryPage(Driver);
		}
	}
}