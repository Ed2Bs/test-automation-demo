using System;
using OpenQA.Selenium;
using TestAutomationDemo.Infrastructure;

namespace TestAutomationDemo.Models
{
    [PageModel(Name = "CreateAnAccount")]
    public class CreateAnAccount : PageModelBase
    {
        public By Header => By.XPath("//div[@id='center_column']/div/h1[contains(text(),'Create an account')]");
        public By FirstNameInput => By.XPath("//input[@id='customer_firstname']");
        public By LastNameInput => By.XPath("//input[@id='customer_lastname']");
        public By EmailInput => By.XPath("//input[@id='email']");
        public By PasswordInput => By.XPath("//input[@id='passwd']");
        public By FirstNameAddressInput => By.XPath("//input[@id='firstname']");
        public By LastNameAddressInput => By.XPath("//input[@id='lastname']");
        public By CompanyInput => By.XPath("//input[@id='company']");
        public By AddressInput => By.XPath("//input[@id='address1']");
        public By CityInput => By.XPath("//input[@id='city']");
        public By StateInput => By.XPath("//select[@id='id_state']");
        public By ZipInput => By.XPath("//input[@id='postcode']");
        public By CountryInput => By.XPath("//select[@id='id_country']");
        public By MobilePhoneInput => By.XPath("//input[@id='phone_mobile']");
        public By RegisterButton => By.XPath("//button[@id='submitAccount']");

        public override Func<bool> IsAtRule =>
            () => driver.FindElement(By.XPath("//div[@id='center_column']/div/h1[contains(text(),'Create an account')]")).Displayed;

        public CreateAnAccount(IWebDriver driver) : base(driver) { }

        public void ClickRegisterButton() => DriverService.Instance.ClickWebElement(RegisterButton);
    }
}
