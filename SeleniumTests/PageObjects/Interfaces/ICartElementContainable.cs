using OpenQA.Selenium;

namespace SeleniumTests.PageObjects
{
    //We will use this interface for each page which contains cart. Probably selectors will not be equal for different pages.
    interface ICartElementContainable
    {
        IWebElement Cart { get; }
        CartPage OpenCart();
    }
}