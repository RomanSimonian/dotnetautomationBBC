using OpenQA.Selenium;
using SpecFlowLoremIpsum.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecFlowLoremIpsum.Manager
{
    internal class PageFacrtoryManager
    {
        public class PageFactoryManager
        {
            readonly WebDriver driver;

            public PageFactoryManager(WebDriver driver)
            {
                this.driver = driver;
            }

            public HomePage GetHomePage() { return new HomePage(driver); }

            public GeneratePage GetGeneratePages() { return new GeneratePage(driver); }

            public RadioButton GetRadioButton() { return new RadioButton(driver); }

        }

    }
}
