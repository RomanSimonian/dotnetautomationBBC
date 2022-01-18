# Adding SpecFlow to your project


### Steps 

In order to use BDT (test scenarios as business-oriented text), we need to add SpecFlow to our project. 
SpecFlow installation is often difficult with many problems. Good news is, once it's installed, you almost never have problems again.
Use Google to find relevant installation steps. This is not the only annoying software you will need to install in your career. :)

Below is the sequence of steps that worked for me in 2019. These could be very outdated, so it's only provided as something else you can try if nothing works. 

1.	Download SpecFlow extension: in Visual Studio, go to Extensions, find SpecFlow, press Download, then close VS, wait for automatic installation, then reopen VS;
2.	Install NuGet packages: SpecFlow, SpecFlow.Tools.MsBuild.Generation, SpecFlow.MsTest (all of the same version). You also need to install and target .NET framework 4.7.2;
3.	Create a feature file, through right click on a folder, Add->New Item, then selecting SpecFlow->SpecFlow Feature File;
4.	Right click on your Feature File -> Properties. If Custom Tool field in Properties is not empty, delete it (needs to be done for every file). 
5.	Right-click on a step in your Feature File, choose Generate Step Definitions.
6.	Your test should appear in Test Explorer.


### Troubleshooting:

If you get the following error: 
“Version conflict - SpecFlow Visual Studio extension attempted to use SpecFlow code-behind generator 1.9, but project 'SeleniumQuickSetupTest' references SpecFlow 3.0.”, 
follow steps in https://specflow.org/documentation/Generate-Tests-from-MsBuild/ to solve it.
