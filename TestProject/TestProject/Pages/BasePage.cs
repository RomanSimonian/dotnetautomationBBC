using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;

namespace TestProject.Pages
{
	public class BasePage
	{
		protected IWebDriver Driver;
		public double defaultTime = 30;

		public BasePage(IWebDriver driver)
		{
			this.Driver = driver;
			PageFactory.InitElements(driver, this);
		}

		public void ImplicitlyWait(double defaultTime)
		{
			WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(defaultTime));
		}

		public IWebElement WaitForElementExist(double defaultTime, string xpathElement)
		{
			WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(defaultTime));
			wait.IgnoreExceptionTypes(typeof(NoSuchElementException));
			var element = wait.Until(x => x.FindElement(By.XPath(xpathElement)));
			return element;
		}

		public void WaitUntilEnable(double defaultTime, IWebElement element)
		{
			WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(defaultTime));
			wait.IgnoreExceptionTypes(typeof(NoSuchElementException));
			wait.Until<bool>(x => element.Enabled);
		}
	}
}