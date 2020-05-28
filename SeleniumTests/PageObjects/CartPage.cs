using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumTests.Helpers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace SeleniumTests.PageObjects
{
    class CartPage
    {
        private readonly IWebDriver _driver;
        public CartPage(IWebDriver driver)
        {
            _driver = driver;
        }


        public IWebElement CloseCartBtn => new WebDriverWait(_driver, TimeSpan.FromSeconds(10)).
            Until(ExpectedConditions.ElementToBeClickable(By.CssSelector(".modal__close.js-modal-close ")));
        public ReadOnlyCollection<IWebElement> ItemsCounts => _driver.FindElementsIfExist(By.CssSelector(".cart-modal__calc-input"));
        public IWebElement CheckoutBtn => new WebDriverWait(_driver, TimeSpan.FromSeconds(15))
            .Until(ExpectedConditions.ElementToBeClickable(By.CssSelector(".button.button_color_green.cart-modal__check-button")));

        public void CloseCart()
        {
            CloseCartBtn.Click();
        }

        public CartPage ClearCart()
        {
            var removeBtns = _driver.FindElementsIfExist(By.CssSelector(".cart-modal__list"));
            if (removeBtns != null)
            {
                foreach(var b in removeBtns)
                {
                    b.Click();
                    var confirmDeleteBtn = _driver.FindElement(By.CssSelector(".cart-modal__actions-control.cart-modal__actions-control_type_remove"));
                    confirmDeleteBtn.Click();
                }   
            }
            return new CartPage(_driver);
        }

        public CheckoutPersonalInfoPage CheckoutOrder()
        {
            CheckoutBtn.Click();
            return new CheckoutPersonalInfoPage(_driver);
        }
        
    }
}
