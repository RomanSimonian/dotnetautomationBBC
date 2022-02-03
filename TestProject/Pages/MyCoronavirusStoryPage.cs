using OpenQA.Selenium;
using System.Threading;

namespace TestProject.Pages
{
	public class MyCoronavirusStoryPage : BasePage
	{
		private readonly By _myQuestion = By.XPath("//textarea[@class='text-input--long']");
		private readonly By _myName = By.XPath("//input[@placeholder='Name']");
		private readonly By _myEmail = By.XPath("//input[@placeholder='Email address']");
		private readonly By _myNumber = By.XPath("//input[@placeholder='Contact number']");
		private readonly By _myAge = By.XPath("//input[@placeholder='Age']");
		private readonly By _myLocation = By.XPath("//input[@placeholder='Location ']");
		private readonly By _checkBox = By.XPath("//input[@type='checkbox']");
		private readonly By _submitButton = By.XPath("//button[@class='button']");
		private readonly By _errorMessage = By.XPath("//div[@class='input-error-message']");

		public MyCoronavirusStoryPage(IWebDriver driver) : base(driver) { }

		public MyCoronavirusStoryPage FillTheForm(string question, string name, string email, string number, string location, string age)
		{
			WaitForPageLoadComplete();
			Thread.Sleep(3000);
			CloseWindowRegistration();
			Driver.FindElement(_myQuestion).SendKeys(question);
			Driver.FindElement(_myName).SendKeys(name);
			Driver.FindElement(_myEmail).SendKeys(email);
			Driver.FindElement(_myNumber).SendKeys(number);
			Driver.FindElement(_myAge).SendKeys(location);
			Driver.FindElement(_myLocation).SendKeys(age);
			return this;
		}

		public MyCoronavirusStoryPage ClickCheckBox()
		{
			Driver.FindElement(_checkBox).Click();
			return this;
		}

		public MyCoronavirusStoryPage ClickSubmitButton()
		{
			Driver.FindElement(_submitButton).Click();
			Thread.Sleep(2000);
			return this;
		}

		public string GetErrorMessage()
        {
			return Driver.FindElement(_errorMessage).Text;
		}
	}
}