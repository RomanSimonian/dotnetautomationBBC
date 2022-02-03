using System;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace TestProject.Pages
{
	public class BasePage
	{
		protected IWebDriver Driver;
		private readonly int _defaultTime = 30;
		private readonly By _windowRegistration = By.XPath("//button[@class='tp-close tp-active']");

		public BasePage(IWebDriver driver)
		{
			Driver = driver;
		}

		public void WaitForPageLoadComplete()
		{
			Driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(_defaultTime);
		}

		public void WaitForElement(IWebElement element)
		{
			WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromMinutes(_defaultTime));
			wait.IgnoreExceptionTypes(typeof(NoSuchElementException));
			wait.IgnoreExceptionTypes(typeof(StaleElementReferenceException));
		}

		public void CloseWindowRegistration()
		{
			if (Driver.FindElement(_windowRegistration).Displayed)
			{
				Driver.FindElement(_windowRegistration).Click();
			}
		}
	}
}
