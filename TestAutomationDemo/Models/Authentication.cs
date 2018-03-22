using System;
using OpenQA.Selenium;
using TestAutomationDemo.Infrastructure;

namespace TestAutomationDemo.Models
{
    [PageModel(Name = "Authentication")]
    public class Authentication : PageModelBase
    {
        public IWebElement Header => GetWebElement("//div[@id='center_column']/h1[contains(text(),'Authentication')]");

        public IWebElement CreateAnAccountEmailInput => GetWebElement("//input[@id='email_create']");
        public IWebElement CreateAnAccountButton => GetWebElement("//button[@id='SubmitCreate']");

        public IWebElement SignInEmailInput => GetWebElement("//input[@id='email']");
        public IWebElement SignInPwdInput => GetWebElement("//input[@id='passwd']");
        public IWebElement SignInButton => GetWebElement("//button[@id='SubmitLogin']");

        public override Func<bool> Displayed => 
            () => driver.FindElement(By.XPath("//div[@id='center_column']/h1[contains(text(),'Authentication')]")).Displayed;

        public Authentication(IWebDriver driver) : base(driver) { }

        public void ClickCreateAnAccountButton() => ClickWebElement(CreateAnAccountButton);
        public void ClickSignInButton() => ClickWebElement(SignInButton);
    }
}
