﻿using TechTalk.SpecFlow;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using TestProject.Pages;

namespace TestProject.StepDefinitions
{
	public class BaseSteps
	{
		protected IWebDriver Driver;
		protected HomePage Home_Page = null;
		protected NewsPage News_Page = null;
		protected CoronavirusPage Coronavirus_Page = null;
		protected CoronavirusStoryPage CoronavirusStory_Page = null;
		protected MyCoronavirusStoryPage MyCoronavirusStory_Page = null;
		protected SearchResultPage SearchResult_Page = null;

		[Before]
		public void SetUp()
		{
			Driver = new ChromeDriver();
			Driver.Navigate().GoToUrl("https://www.bbc.com");
			Driver.Manage().Window.Maximize();
		}

		[After]
		public void Finish()
		{
			Driver.Quit();
		}
	}
}