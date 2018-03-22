using System;
using OpenQA.Selenium;
using TestAutomationDemo.Infrastructure;
using TestAutomationDemo.Models.Components;

namespace TestAutomationDemo.Models
{
    [PageModel(Name = "Product")]
    public class Product : PageModelBase
    {
        AddToCartPopUp addToCartPopUp;
        public AddToCartPopUp AddToCartPopUp => addToCartPopUp ?? (addToCartPopUp = new AddToCartPopUp(driver));

        public IWebElement AddToCart => GetWebElement("//div[@class='box-cart-bottom']//button[@name='Submit']");

        public override Func<bool> Displayed =>
            () => driver.FindElement(By.XPath("//h3[@class='page-product-heading']")).Displayed;

        public Product(IWebDriver driver) : base(driver) { }

        public void ClickAddToCart() => ClickWebElement(AddToCart);
    }
}
