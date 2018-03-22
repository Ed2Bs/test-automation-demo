using System;
using NLog;
using OpenQA.Selenium;

namespace TestAutomationDemo.Models.Components
{
    public class AddToCartPopUp
    {
        private IWebDriver driver;
        private static Logger logger = LogManager.GetCurrentClassLogger();

        public IWebElement AddToCartPopUpTitle => GetWebElement("//div[@id='layer_cart']//h2[text()[contains(.,'successfully added')]]");
        public IWebElement AddToCartPopUpProceed => GetWebElement("//div[@id='layer_cart']//a[@title='Proceed to checkout']");

        public AddToCartPopUp(IWebDriver driver) => this.driver = driver;

        public void ClickProceedToCheckout() => ClickWebElement(AddToCartPopUpProceed);

        private IWebElement GetWebElement(string xpath)
        {
            try
            {
                logger.Info($"Finding element for {xpath}");
                return driver.FindElement(By.XPath(xpath));
            }
            catch (NoSuchElementException e)
            {
                logger.Error(e.Message);
                Service.GetScreenshot();
                return null;
            }
        }

        private void ClickWebElement(IWebElement webElement)
        {
            try
            {
                webElement.Click();
                logger.Info("Clicked on element");
            }
            catch (Exception)
            {
                logger.Error(new NoSuchElementException("Unable to click on element"));
            }
        }
    }
}
