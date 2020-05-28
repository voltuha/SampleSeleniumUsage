using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace SeleniumTests.PageObjects
{
    class ItemDetailsPage
    {
        private readonly IWebDriver _driver;

        public ItemDetailsPage(IWebDriver driver)
        {
            _driver = driver;
        }
       
    }
}
