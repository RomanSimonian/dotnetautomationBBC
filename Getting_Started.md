# Getting started

### Requirements (watch/read these before starting)

- Test Automation (TA) definition, purpose;
- TA benefits and drawbacks;
- TA of Web applications with Selenium.


### Actions

- Create new project in Visual Studio of type Unit Test Project – MsTest (or simply Unit Test Project).
- Through NuGet, add the following packages:
  - Selenium.WebDriver
  - Selenium.WebDriver.ChromeDriver. Version of this package MUST match Chrome version on your machine. If it doesn’t and Chrome doesn’t auto-update – just change package version.
  
  
- Add the following code to your default unit test and run it to verify everything works:

```csharp
	IWebDriver driver = new ChromeDriver();  // Creates a new Chrome instance and opens the browser
	driver.Navigate().GoToUrl("https://www.bbc.com");  // Navigates to a page by address
```
