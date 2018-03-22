using System;
using NLog;
using OpenQA.Selenium;

namespace TestAutomationDemo.Models.Components
{
    public class AddToCartPopUp
    {
        public By AddToCartPopUpTitle => By.XPath("//div[@id='layer_cart']//h2[text()[contains(.,'successfully added')]]");
        public By AddToCartPopUpProceed => By.XPath("//div[@id='layer_cart']//a[@title='Proceed to checkout']");

        public void ClickProceedToCheckout() => DriverService.Instance.ClickWebElement(AddToCartPopUpProceed);
    }
}
