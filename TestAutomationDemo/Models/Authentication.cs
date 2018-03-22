using System;
using OpenQA.Selenium;
using TestAutomationDemo.Infrastructure;

namespace TestAutomationDemo.Models
{
    [PageModel(Name = "Authentication")]
    public class Authentication : PageModelBase
    {
        public By Header => By.XPath("//div[@id='center_column']/h1[contains(text(),'Authentication')]");
        public By CreateAnAccountEmailInput => By.XPath("//input[@id='email_create']");
        public By CreateAnAccountButton => By.XPath("//button[@id='SubmitCreate']");
        public By SignInEmailInput => By.XPath("//input[@id='email']");
        public By SignInPwdInput => By.XPath("//input[@id='passwd']");
        public By SignInButton => By.XPath("//button[@id='SubmitLogin']");

        public override Func<bool> IsAtRule => 
            () => driver.FindElement(By.XPath("//div[@id='center_column']/h1[contains(text(),'Authentication')]")).Displayed;

        public Authentication(IWebDriver driver) : base(driver) { }

        public void ClickCreateAnAccountButton() => DriverService.Instance.ClickWebElement(CreateAnAccountButton);
        public void ClickSignInButton() => DriverService.Instance.ClickWebElement(SignInButton);
    }
}
