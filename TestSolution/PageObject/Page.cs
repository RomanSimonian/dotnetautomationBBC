using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace TestSolution.PageObject
{
    public class Page
    {
        protected IWebDriver driver;
        public Page(IWebDriver driver)
        {
            this.driver = driver;
        }
    }
}

