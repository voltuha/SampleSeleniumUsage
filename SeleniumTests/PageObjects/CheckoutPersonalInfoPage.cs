using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;

namespace SeleniumTests.PageObjects
{
    class CheckoutPersonalInfoPage
    {
        private readonly IWebDriver _driver;

        public CheckoutPersonalInfoPage(IWebDriver driver)
        {
            _driver = driver;
        }
        #region Elements        
        public IWebElement FullName => new WebDriverWait(_driver, TimeSpan.FromSeconds(60))
            .Until(ExpectedConditions.ElementExists(By.Id("reciever_name")));
        public IWebElement City => _driver.FindElement(By.Id("suggest_locality"));
        public IWebElement Phone => _driver.FindElement(By.Id("reciever_phone"));
        public IWebElement Email => _driver.FindElement(By.Id("reciever_email"));
        public IWebElement NextBtn => new WebDriverWait(_driver, TimeSpan.FromSeconds(30))
            .Until(ExpectedConditions.ElementToBeClickable(By.CssSelector(".btn-link.btn-link-green.check-step-btn-link.opaque")));
        public IWebElement CitiesDropdown => _driver.FindElement(By.ClassName("suggestions"));
        public IWebElement SuggestedCity => new WebDriverWait(_driver, TimeSpan.FromSeconds(10))
            .Until(ExpectedConditions.ElementExists(By.CssSelector(".lightblue.xhr")));
        #endregion

        public CheckoutDeliveryPage EnterPersonalInfo(string name, string city, string phoneNumber, string email)
        {
            FullName.SendKeys(name);         
            SuggestedCity.Click();           
            Phone.SendKeys(phoneNumber);
            Email.SendKeys(email);
            return new CheckoutDeliveryPage(_driver);
        }

        public CheckoutDeliveryPage ContinueToCheckoutDeliveryPage()
        {
            NextBtn.Click();
            return new CheckoutDeliveryPage(_driver);
        }
    }
}
