using System;
using OpenQA.Selenium;
using TestAutomationDemo.Infrastructure;

namespace TestAutomationDemo.Models
{
    [PageModel(Name = "Homepage")]
    public class Homepage : PageModelBase
    {
        public override Func<bool> Displayed =>
            () => driver.FindElement(By.XPath("//ul[@id='homeslider']")).Displayed;

        public Homepage(IWebDriver driver) : base(driver) { }
    }
}
