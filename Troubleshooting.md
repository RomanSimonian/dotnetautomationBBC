# Common issues and solutions

1. Simply adding Chromedriver package on a Mac does not work. Trying to launch the test shows error, that says that chrome driver is not found. 
Solution: add direct path to chromedriver to constructor in this format (but substituting correct path folders):
 new ChromeDriver(“/x/y/z/directoryWithChromedriver/”)
2. Chromedriver does not launch Chrome. Error says that this driver only works with Chrome version X. 
Solution: upgrade Chrome, upgrade ChromeDriver, or downgrade Chromedriver (older version can be obtained through NuGet or Googling). Each Chromedriver version only works for one Chrome version.
3. Xpath copied from Chrome doesn`t let your code compile when pasted into it. 
Solution: Xpath copied from Chrome contains double quotes(“). You can escape them (Google how) or replace with single quotes (‘);
4. Xpath copied from Chrome simply does not work – returns NoSuchElementException.
Solution: this sometimes happens on BBC site. The following sequence usually helps, and not just on BBC:
   - Copy your Xpath from exception text and test it in Dev Tools in Chrome;
   - Make sure your test is on the correct page when it executes the Xpath;
   - Check your page for “frame” or “iframe” elements (BBC page has none, but you may run into them in the future. Google how to work with them);
   - If all else fails, open Dev Tools in Chrome. Go upwards from your target element, and mouse over different elements. You will notice that the selected element covers more and more area as you go up (while still covering your target element). You need to find the smallest element you can select directly with Xpath, and then try different ways to get from there to your target element.
It's very preferable to use this as an opportunity to try and create your own Xpaths. 


