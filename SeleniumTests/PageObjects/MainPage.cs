using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using SeleniumTests.Helpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace SeleniumTests.PageObjects
{
    class MainPage : ICartElementContainable
    {
        private readonly IWebDriver _driver;

        public MainPage(IWebDriver driver)
        {
            _driver = driver;          
        }

        public IWebElement SearchField => _driver.FindElement(By.CssSelector(".search-form__input.ng-untouched.ng-pristine.ng-valid"));
        public IWebElement SearchBtn => _driver.FindElement(By.CssSelector(".button.button_color_green.button_size_medium.search-form__submit"));
        public IWebElement Cart => _driver.FindElement(By.CssSelector(".header-actions__button.header-actions__button_type_basket"));

        public CartPage OpenCart()
        {
            Cart.Click();
            return new CartPage(_driver);
        }

        public SearchPage SearchFor(string text)
        {
            SearchField.Clear();
            SearchField.SendKeys(text);
            SearchBtn.Click();           

            return new SearchPage(_driver);
        }
    }
}
