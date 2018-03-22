using OpenQA.Selenium;
using TestAutomationDemo.Models;

namespace TestAutomationDemo
{
    public class Pages
    {
        IWebDriver driver;

        Homepage homepage;
        Authentication authentication;
        CreateAnAccount createAnAccount;
        Catalog catalog;
        Product product;
        CartSummary cartSummary;
        MyAccount myAccount;

        public Pages() => this.driver = DriverService.Instance.Driver;

        public Homepage Homepage => homepage ?? (homepage = new Homepage(driver));
        public Authentication Authentication => authentication ?? (authentication = new Authentication(driver));
        public CreateAnAccount CreateAnAccount => createAnAccount ?? (createAnAccount = new CreateAnAccount(driver));
        public Catalog Catalog => catalog ?? (catalog = new Catalog(driver));
        public Product Product => product ?? (product = new Product(driver));
        public CartSummary CartSummary => cartSummary ?? (cartSummary = new CartSummary(driver));
        public MyAccount MyAccount => myAccount ?? (myAccount = new MyAccount(driver));
    }
}
