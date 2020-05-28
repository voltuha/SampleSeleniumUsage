using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace SeleniumTests.Helpers
{
    public static class SeleniumExtensions
    {
        public static IWebElement FindElementIfExists(this IWebDriver driver, By by)
        {
            var elements = driver.FindElements(by);
            return (elements.Count >= 1) ? elements.First() : null;
        }

        public static ReadOnlyCollection<IWebElement> FindElementsIfExist(this IWebDriver driver, By by)
        {
            var elements = driver.FindElements(by);
            return (elements.Count >= 1) ? elements : null;
        }
    }
}
