using System;
using OpenQA.Selenium;
using TestAutomationDemo.Infrastructure;

namespace TestAutomationDemo.Models
{
    [PageModel(Name = "CartSummary")]
    public class CartSummary : PageModelBase
    {
        public IWebElement Header => GetWebElement("//div[@id='center_column']/h1[contains(text(),'Shopping-cart summary')]");
        public IWebElement ProceedToCheckout => GetWebElement("//div[@id='center_column']//a[@title='Proceed to checkout']");
        public IWebElement ProceedToCheckoutAddress => GetWebElement("//div[@id='center_column']//button[@name='processAddress']");
        public IWebElement ProceedToCheckoutShipping => GetWebElement("//div[@id='center_column']//button[@name='processCarrier']");
        public IWebElement TermsOfServiceCheckbox => GetWebElement("//div[@id='center_column']//input[@name='cgv']");
        public IWebElement BankWireLink => GetWebElement("//div[@id='HOOK_PAYMENT']//a[@class='bankwire']");
        public IWebElement ConfirmMyOrder => GetWebElement("//div[@id='center_column']//button[contains(@class,'button')]");
        public IWebElement ConfirmationMsg => GetWebElement("//div[@class='box']//p/strong[text()[contains(.,'Your order on My Store is complete')]]");

        public override Func<bool> Displayed =>
            () => driver.FindElement(By.XPath("//div[@id='center_column']/h1[@id='cart_title']")).Displayed;

        public CartSummary(IWebDriver driver) : base(driver) { }

        public void ClickProceedToCheckout() => ClickWebElement(ProceedToCheckout);
        public void ClickProceedToCheckoutAddress() => ClickWebElement(ProceedToCheckoutAddress);
        public void ClickProceedToCheckoutShipping() => ClickWebElement(ProceedToCheckoutShipping);
        public void ClickTermsOfServiceCheckbox() => ClickWebElement(TermsOfServiceCheckbox);
        public void ClickBankWireLink() => ClickWebElement(BankWireLink);
        public void ClickConfirmMyOrder() => ClickWebElement(ConfirmMyOrder);
    }
}
