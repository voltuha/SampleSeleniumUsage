using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace SeleniumTests.PageObjects
{
    class CheckoutDeliveryPage
    {
        private readonly IWebDriver _driver;
        public CheckoutDeliveryPage(IWebDriver driver)
        {
            _driver = driver;
        }

        #region Elements
        //TODO: Add other options, perhaps wrap in enum or object
        //DO NOT USE XPATH LIKE THIS
        public IWebElement NovaPoshtaRadioBtn => new WebDriverWait(_driver, TimeSpan.FromSeconds(10))
            .Until(ExpectedConditions.ElementExists(By.XPath("//*[@id=\"orders\"]/div/div/div[2]/div[1]/div[3]/div/div/ul/li[4]/div[2]/div[1]/div[1]/label/div")));

        public IWebElement NovaPoshtaDepartmentDropdown => new WebDriverWait(_driver, TimeSpan.FromSeconds(10))
            .Until(ExpectedConditions.ElementToBeClickable(By.XPath("//*[@id=\"orders\"]/div/div/div[2]/div[1]/div[3]/div/div/ul/li[4]/div[2]/div[2]/div[1]")));
        public IWebElement NovaPoshtaFirstAvailableDepartment => _driver.FindElement(By.XPath("//*[@id=\"orders\"]/div/div/div[2]/div[1]/div[3]/div/div/ul/li[4]/div[2]/div[2]/div[1]/div/div[2]/div/ul/li[1]"));
        public IWebElement GooglePayRadioBtn => new WebDriverWait(_driver, TimeSpan.FromSeconds(10)).
            Until(ExpectedConditions.ElementToBeClickable(By.XPath("//*[@id=\"orders\"]/div/div/div[4]/div/div[2]/div[2]/ul/li[1]/label/div")));
        public IWebElement ReceiverMyself => _driver.FindElement(By.XPath("//*[@id=\"orders\"]/div/div/div[4]/div/div[2]/div[2]/ul/li[1]/label/div"));
        public IWebElement ReceiverPhone => _driver.FindElement(By.XPath("//*[@id=\"orders\"]/div/div/div[4]/div/div[7]/div/div[2]/input"));
        public IWebElement ReceiverLastName => _driver.FindElement(By.XPath("//*[@id=\"orders\"]/div/div/div[4]/div/div[9]/div/div[2]/input"));
        public IWebElement ReceiverFirstName => _driver.FindElement(By.XPath("//*[@id=\"orders\"]/div/div/div[4]/div/div[10]/div/div[2]/input"));
        public IWebElement ReceiverPatronymic => _driver.FindElement(By.XPath("//*[@id=\"orders\"]/div/div/div[4]/div/div[11]/div/div[2]/input"));


        #endregion
        //These methods to be changed after other options added
        public void SelectNovaPoshta()
        {
            NovaPoshtaRadioBtn.Click();
            //It's a little bit hard to use web driver waits here for some reason. API request is sent to google maps and time to get response is kinda big.
            Thread.Sleep(15000);
            NovaPoshtaDepartmentDropdown.Click();
            NovaPoshtaFirstAvailableDepartment.Click();
            Thread.Sleep(15000);

        }

        public void SelectGooglePay()
        {
            GooglePayRadioBtn.Click();
        }

        public void SelectReceiverMyself()
        {
            GooglePayRadioBtn.Click();
        }

        public void FillReceiverInfo(string phoneNumber, string lastName, string firstName, string patronymic)
        {
            ReceiverPhone.SendKeys(phoneNumber);
            ReceiverLastName.SendKeys(lastName);
            ReceiverFirstName.SendKeys(firstName);
            ReceiverPatronymic.SendKeys(patronymic);
        }
    }
}
