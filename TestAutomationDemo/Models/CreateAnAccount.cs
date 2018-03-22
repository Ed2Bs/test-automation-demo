using System;
using OpenQA.Selenium;
using TestAutomationDemo.Infrastructure;

namespace TestAutomationDemo.Models
{
    [PageModel(Name = "CreateAnAccount")]
    public class CreateAnAccount : PageModelBase
    {
        public IWebElement Header => GetWebElement("//div[@id='center_column']/div/h1[contains(text(),'Create an account')]");

        public IWebElement FirstNameInput => GetWebElement("//input[@id='customer_firstname']");
        public IWebElement LastNameInput => GetWebElement("//input[@id='customer_lastname']");
        public IWebElement EmailInput => GetWebElement("//input[@id='email']");
        public IWebElement PasswordInput => GetWebElement("//input[@id='passwd']");
        public IWebElement FirstNameAddressInput => GetWebElement("//input[@id='firstname']");
        public IWebElement LastNameAddressInput => GetWebElement("//input[@id='lastname']");
        public IWebElement CompanyInput => GetWebElement("//input[@id='company']");
        public IWebElement AddressInput => GetWebElement("//input[@id='address1']");
        public IWebElement CityInput => GetWebElement("//input[@id='city']");
        public IWebElement StateInput => GetWebElement("//select[@id='id_state']");
        public IWebElement ZipInput => GetWebElement("//input[@id='postcode']");
        public IWebElement CountryInput => GetWebElement("//select[@id='id_country']");
        public IWebElement MobilePhoneInput => GetWebElement("//input[@id='phone_mobile']");


        public IWebElement RegisterButton => GetWebElement("//button[@id='submitAccount']");

        public override Func<bool> Displayed =>
            () => driver.FindElement(By.XPath("//div[@id='center_column']/div/h1[contains(text(),'Create an account')]")).Displayed;

        public CreateAnAccount(IWebDriver driver) : base(driver) { }

        public void ClickRegisterButton() => ClickWebElement(RegisterButton);
    }
}
