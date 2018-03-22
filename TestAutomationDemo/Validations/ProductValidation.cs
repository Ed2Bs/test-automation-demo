using NLog;
using NUnit.Framework;
using OpenQA.Selenium;
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
                Service.WaitFor((d) => {
                    var el = product.AddToCartPopUp.AddToCartPopUpTitle;
                    if (el.Displayed)
                        return el;
                    return null;
                });

                Assert.IsTrue(product.AddToCartPopUp.AddToCartPopUpTitle?.Displayed);
                logger.Info("Add To Cart PopUp is visible");
            }
            catch (AssertionException)
            {
                logger.Error("Add To Cart PopUp is not visible");
                throw;
            }
        }
    }
}