using System;
using OpenQA.Selenium;
using TestAutomationDemo.Infrastructure;

namespace TestAutomationDemo.Models
{
    [PageModel(Name = "CartSummary")]
    public class CartSummary : PageModelBase
    {
        public By Header => By.XPath("//div[@id='center_column']/h1[contains(text(),'Shopping-cart summary')]");
        public By ProceedToCheckout => By.XPath("//div[@id='center_column']//a[@title='Proceed to checkout']");
        public By ProceedToCheckoutAddress => By.XPath("//div[@id='center_column']//button[@name='processAddress']");
        public By ProceedToCheckoutShipping => By.XPath("//div[@id='center_column']//button[@name='processCarrier']");
        public By TermsOfServiceCheckbox => By.XPath("//div[@id='center_column']//input[@name='cgv']");
        public By BankWireLink => By.XPath("//div[@id='HOOK_PAYMENT']//a[@class='bankwire']");
        public By ConfirmMyOrder => By.XPath("//div[@id='center_column']//button[contains(@class,'button')]");
        public By ConfirmationMsg => By.XPath("//div[@class='box']//p/strong[text()[contains(.,'Your order on My Store is complete')]]");

        public override Func<bool> IsAtRule =>
            () => driver.FindElement(By.XPath("//div[@id='center_column']/h1[@id='cart_title']")).Displayed;

        public CartSummary(IWebDriver driver) : base(driver) { }

        public void ClickProceedToCheckout() => DriverService.Instance.ClickWebElement(ProceedToCheckout);
        public void ClickProceedToCheckoutAddress() => DriverService.Instance.ClickWebElement(ProceedToCheckoutAddress);
        public void ClickProceedToCheckoutShipping() => DriverService.Instance.ClickWebElement(ProceedToCheckoutShipping);
        public void ClickTermsOfServiceCheckbox() => DriverService.Instance.ClickWebElement(TermsOfServiceCheckbox);
        public void ClickBankWireLink() => DriverService.Instance.ClickWebElement(BankWireLink);
        public void ClickConfirmMyOrder() => DriverService.Instance.ClickWebElement(ConfirmMyOrder);
    }
}
