using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;

namespace FinalTask.Main.Pages
{
	public class MyCoronavirusStoryPage : BasePage
	{
		[FindsBy(How = How.XPath, Using = @"//textarea[@class='text-input--long']")]
		private IWebElement _myQuestion;
		[FindsBy(How = How.XPath, Using = @"//input[@placeholder='Name']")]
		private IWebElement _myName;
		[FindsBy(How = How.XPath, Using = @"//input[@placeholder='Email address']")]
		private IWebElement _myEmail;
		[FindsBy(How = How.XPath, Using = @"//input[@placeholder='Contact number']")]
		private IWebElement _myNumber;
		[FindsBy(How = How.XPath, Using = @"//input[@placeholder='Age']")]
		private IWebElement _myAge;
		[FindsBy(How = How.XPath, Using = @"//input[@placeholder='Location ']")]
		private IWebElement _myLocation;
		[FindsBy(How = How.XPath, Using = @"//input[@type='checkbox']")]
		private IWebElement _checkBox;
		[FindsBy(How = How.XPath, Using = @"//button[@class='button']")]
		private IWebElement _submitButton;

		public MyCoronavirusStoryPage(IWebDriver driver) : base(driver)	{}

		public MyCoronavirusStoryPage ClickCheckBox()
		{
			_checkBox.Click();
			return new MyCoronavirusStoryPage(Driver);
		}

		public MyCoronavirusStoryPage ClickSubmitButton()
		{
			_submitButton.Click();
			return new MyCoronavirusStoryPage(Driver);
		}
	}
}