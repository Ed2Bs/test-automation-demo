using System;
using OpenQA.Selenium;
using TestAutomationDemo.Infrastructure;

namespace TestAutomationDemo.Models
{
    [PageModel(Name = "MyAccount")]
    public class MyAccount : PageModelBase
    {
        public By Header => By.XPath("//div[@id='center_column']/h1[contains(text(),'My account')]");
        public By UserInfoSpan => By.XPath("//div[@class='header_user_info']/a/span");
        public By MyAccountLinkList => By.XPath("//ul[@class='myaccount-link-list']/li");

        public override Func<bool> IsAtRule =>
            () => driver.FindElement(By.XPath("//div[@id='center_column']/h1[contains(text(),'My account')]")).Displayed;

        public MyAccount(IWebDriver driver) : base(driver) { }

    }
}
