using NLog;
using NUnit.Framework;
using System;
using TestAutomationDemo.Models;

namespace TestAutomationDemo.Validations
{
    public class ProductValidation
    {
        private Product product;
        private static Logger logger = LogManager.GetCurrentClassLogger();

        public ProductValidation(Product product) => this.product = product;

        public void AddToCartPopUpIsVisible()
        {
            try
            {
                DriverService.Instance.WaitUntil((d) =>
                {
                    var el = d.FindElement(product.AddToCartPopUp.AddToCartPopUpTitle);
                    if (el != null && el.Displayed) return el;

                    return null;
                });

                Assert.IsTrue(DriverService.Instance.GetWebElement(product.AddToCartPopUp.AddToCartPopUpTitle)?.Displayed);
                logger.Info("Add To Cart PopUp is visible");
            }
            catch (Exception)
            {
                logger.Error("Add To Cart PopUp is not visible");
                throw;
            }
        }
    }
}