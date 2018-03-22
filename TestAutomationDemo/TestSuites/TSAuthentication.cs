using NUnit.Framework;

namespace TestAutomationDemo.TestSuites
{
    [TestFixture]
    public class TSAuthentication : TestBase
    {
        [Test]
        public void TC001CreateAccount()
        {
            Pages.Homepage.ClickHeaderSignIn();
            Validation.Authentication.HeaderIsVisible();
            TestData.SetData(TestName);
            Pages.Authentication.ClickCreateAnAccountButton();
            Validation.CreateAnAccount.HeaderIsVisible();
            TestData.SetData(TestName);
            Pages.CreateAnAccount.ClickRegisterButton();
            Validation.MyAccount.HeaderIsVisible();
            Validation.MyAccount.MyAccountLinkListIsVisible();
            Validation.MyAccount.UserNameIsDisplayed();
        }

        [Test]
        public void TC002LogIn()
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
            TestData.SetData(TestName, 2);
            Pages.Authentication.ClickSignInButton();
            Validation.MyAccount.HeaderIsVisible();

        }
    }
}
