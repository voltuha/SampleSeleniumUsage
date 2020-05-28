using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SeleniumTests.Helpers;
using SeleniumTests.PageObjects;
using System;
using System.Threading;

namespace SeleniumTests.ChromeTests
{
    [TestFixture]
    public class CartTests
    {
        private IWebDriver _driver;
        [SetUp]
        public void Setup()
        {
            _driver = new ChromeDriver();
            _driver.Url = AppSettings.BASE_URL;
            _driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(10);
            _driver.Manage().Window.Maximize();

        }

        [TearDown]
        public void TearDown()
        {
            _driver.Quit();
        }

        [Test]
        public void CartIsEmptyByDefault()
        {
            new MainPage(_driver).OpenCart();
            var cartItem = _driver.FindElementIfExists(By.CssSelector(".cart-modal__list"));
            Thread.Sleep(5000);
            var cartIsEmptyTitle = _driver.FindElementIfExists(By.CssSelector(".cart-modal__dummy")).Text;
            var emptyCartText = "Корзина пуста";

            Assert.IsNull(cartItem);
            Assert.AreEqual(emptyCartText, cartIsEmptyTitle);
        }

        [Test]
        public void ItemCountIncrementingAfterAddingItemToCart()
        {
            var mainPage = new MainPage(_driver);
            var cartPage = mainPage.OpenCart();
            cartPage.ClearCart().CloseCart();
            var searchPage = mainPage.SearchFor("Asus rog");
            var buyBtns = searchPage.GetBuyItemBtns();

            if (buyBtns != null)
            {
                buyBtns[0].Click();
            }

            Thread.Sleep(5000);

            var itemCount = cartPage.ItemsCounts[0].GetAttribute("value");

            Assert.AreEqual("1", itemCount);
        }

        //This is just automated steps for checkout. No real tests yet since i don't really want to buy anything on production now :)
        [Test]
        public void ExecuteCheckout()
        {
            var searchPage = new MainPage(_driver).SearchFor("Asus ROG");
            var buyBtns = searchPage.GetBuyItemBtns();
            //yikes
            new WebDriverWait(_driver, TimeSpan.FromSeconds(15));
            buyBtns[0].Click();
            var checkoutPersonalInfoPage = new CartPage(_driver).CheckoutOrder();
            checkoutPersonalInfoPage.EnterPersonalInfo("Игорь Коломойский", "Киев", "0662039938", "example@google.com");
            //I am really sorry about this and other sleeps...
            Thread.Sleep(13000);
            var checkoutDeliveryPage = checkoutPersonalInfoPage.ContinueToCheckoutDeliveryPage();
            checkoutDeliveryPage.SelectNovaPoshta();
            checkoutDeliveryPage.SelectGooglePay();
            checkoutDeliveryPage.SelectReceiverMyself();
            checkoutDeliveryPage.FillReceiverInfo("0662039938", "Коломойский", "Игорь", "Валерьевич");
            //TODO: use confirm btn and create assertions
        }
    }
}