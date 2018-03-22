using NUnit.Framework;

namespace TestAutomationDemo.TestSuites
{
    [TestFixture]
    public class TSCheckout : TestBase
    {
        [Test]
        public void TC003CheckoutUserSignedIn()
        {
            Pages.Homepage.ClickHeaderSignIn();
            Validation.Authentication.HeaderIsVisible();
            TestData.SetData(TestName);
            Pages.Authentication.ClickCreateAnAccountButton();
            Validation.CreateAnAccount.HeaderIsVisible();
            TestData.SetData(TestName);
            Pages.CreateAnAccount.ClickRegisterButton();
            Validation.MyAccount.HeaderIsVisible();
            Pages.MyAccount.ClickTopMenuWomenLink();
            Pages.Catalog.ClickFirstInCatalog();
            Pages.Product.ClickAddToCart();
            Validation.Product.AddToCartPopUpIsVisible();
            Pages.Product.AddToCartPopUp.ClickProceedToCheckout();
            Validation.CartSummary.HeaderIsVisible();
            Pages.CartSummary.ClickProceedToCheckout();
            Pages.CartSummary.ClickProceedToCheckoutAddress();
            Pages.CartSummary.ClickTermsOfServiceCheckbox();
            Pages.CartSummary.ClickProceedToCheckoutShipping();
            Pages.CartSummary.ClickBankWireLink();
            Pages.CartSummary.ClickConfirmMyOrder();
            Validation.CartSummary.ConfirmationIsDisplayed();

        }

        [Test]
        public void TC004CheckoutUserNotSignedIn()
        {
            Pages.Homepage.ClickHeaderSignIn();
            Validation.Authentication.HeaderIsVisible();
            TestData.SetData(TestName);
            Pages.Authentication.ClickCreateAnAccountButton();
            Validation.CreateAnAccount.HeaderIsVisible();
            TestData.SetData(TestName);
            Pages.CreateAnAccount.ClickRegisterButton();
            Validation.MyAccount.HeaderIsVisible();
            Pages.MyAccount.ClickHeaderSignOut();
            Pages.MyAccount.ClickTopMenuWomenLink();
            Pages.Catalog.ClickFirstInCatalog();
            Pages.Product.ClickAddToCart();
            Validation.Product.AddToCartPopUpIsVisible();
            Pages.Product.AddToCartPopUp.ClickProceedToCheckout();
            Validation.CartSummary.HeaderIsVisible();
            Pages.CartSummary.ClickProceedToCheckout();
            TestData.SetData(TestName, 2);
            Pages.Authentication.ClickSignInButton();
            Pages.CartSummary.ClickProceedToCheckoutAddress();
            Pages.CartSummary.ClickTermsOfServiceCheckbox();
            Pages.CartSummary.ClickProceedToCheckoutShipping();
            Pages.CartSummary.ClickBankWireLink();
            Pages.CartSummary.ClickConfirmMyOrder();
            Validation.CartSummary.ConfirmationIsDisplayed();
        }
    }
}
