using System;
using System.Collections.ObjectModel;
using OpenQA.Selenium;
using TestAutomationDemo.Infrastructure;

namespace TestAutomationDemo.Models
{
    [PageModel(Name = "MyAccount")]
    public class MyAccount : PageModelBase
    {
        public IWebElement Header => GetWebElement("//div[@id='center_column']/h1[contains(text(),'My account')]");

        public IWebElement UserInfoSpan => GetWebElement("//div[@class='header_user_info']/a/span");
        public ReadOnlyCollection<IWebElement> MyAccountLinkList => GetWebElements("//ul[@class='myaccount-link-list']/li");

        public override Func<bool> Displayed =>
            () => driver.FindElement(By.XPath("//div[@id='center_column']/h1[contains(text(),'My account')]")).Displayed;

        public MyAccount(IWebDriver driver) : base(driver) { }

    }
}
