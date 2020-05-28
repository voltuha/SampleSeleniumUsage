using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace SeleniumTests.PageObjects
{
    class SearchPage
    {
        private readonly IWebDriver _driver;

        public SearchPage(IWebDriver driver)
        {
            _driver = driver;
        }

        IList<IWebElement> searchItems => _driver.FindElements(By.CssSelector(".goods-tile__heading"));

        public ItemDetailsPage GoToItemDetails(int index)
        {
            if (searchItems != null && searchItems.Count <= index)
            {
                throw new Exception();
            }
            searchItems[index].Click();
            return new ItemDetailsPage(_driver);
        }

        public ReadOnlyCollection<IWebElement> GetBuyItemBtns()
        {
            if (searchItems != null && searchItems.Count > 1)
            {
                return _driver.FindElements(By.CssSelector(".buy-button.goods-tile__buy-button"));
            }
            else
            {
                return null;
            }
        }

    }
}
