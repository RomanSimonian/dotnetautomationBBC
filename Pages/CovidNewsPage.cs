﻿using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using SeleniumExtras.PageObjects;
namespace BBC1_task_4._1._1.Pages
{
    public class CovidNewsPage : BasePage
    {
        private IWebDriver driver;

        [FindsBy(How = How.XPath, Using = "//div[@class='no-mpu']//div[@class='gel-layout gel-layout--equal']//h3[contains(@class,'gel-pica-bold nw-o-link-split__text')]")]
        private IList<IWebElement> listOfHeaders;

        public CovidNewsPage(IWebDriver driver) : base(driver) {
            this.driver = driver;
        }

        public bool AreSecondaryArticlesMatch(Dictionary<int,string> expectedlistOfHearders) //принимать коллекцию. дикшинари 
        {
            foreach (var header in expectedlistOfHearders)
            {
                if (!listOfHeaders[header.Key].Text.Equals(expectedlistOfHearders[header.Key])) 
                    throw new Exception(listOfHeaders[header.Key].Text);       
            }

            return true;
        }
    }
}
