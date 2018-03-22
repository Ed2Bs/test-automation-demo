using System;
using System.Linq;
using OpenQA.Selenium;
using TestAutomationDemo.Infrastructure;

namespace TestAutomationDemo.Models
{
    [PageModel(Name = "Catalog")]
    public class Catalog : PageModelBase
    {
        public By FirstProduct => By.XPath("//div[@id='center_column']/ul/li//div[@class='right-block']/h5/a");

        public override Func<bool> IsAtRule =>
            () => driver.FindElements(By.XPath("//div[@id='left_column']/div/p")).Any(x => x.Text == "Catalog");

        public Catalog(IWebDriver driver) : base(driver) { }

        public void ClickFirstInCatalog() => DriverService.Instance.ClickWebElement(FirstProduct);
    }
}
