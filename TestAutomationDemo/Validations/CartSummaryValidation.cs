using NLog;
using NUnit.Framework;
using System;
using TestAutomationDemo.Models;

namespace TestAutomationDemo.Validations
{
    public class CartSummaryValidation
    {
        private CartSummary cartSummary;
        private static Logger logger = LogManager.GetCurrentClassLogger();

        public CartSummaryValidation(CartSummary cartSummary) => this.cartSummary = cartSummary;

        public void ConfirmationIsDisplayed()
        {
            try
            {
                Assert.IsTrue(DriverService.Instance.GetWebElement(cartSummary.ConfirmationMsg)?.Displayed);
                logger.Info("Confirmation is visible");
            }
            catch (AssertionException)
            {
                logger.Error("Confirmation is not visible");
                throw;
            }
        }

        public void HeaderIsVisible()
        {
            try
            {
                Assert.IsTrue(DriverService.Instance.GetWebElement(cartSummary.Header)?.Displayed);
                logger.Info("Cart Summary page header text is visible");
            }
            catch (AssertionException)
            {
                logger.Error("Cart Summary page header text is not visible");
                throw;
            }
        }
    }
}