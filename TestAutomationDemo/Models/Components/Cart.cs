using System;
using NLog;
using OpenQA.Selenium;

namespace TestAutomationDemo.Models.Components
{
    public class Cart
    {
        private IWebDriver driver;
        private static Logger logger = LogManager.GetCurrentClassLogger();

        public IWebElement ViewCart => GetWebElement("//div[@class='shopping_cart']/a[@title='View my shopping cart']");

        public Cart(IWebDriver driver) => this.driver = driver;


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
