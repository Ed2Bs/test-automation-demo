using System;
using NLog;
using OpenQA.Selenium;
using TestAutomationDemo.Models.Components;

namespace TestAutomationDemo.Models
{
    public abstract class PageModelBase
    {
        protected IWebDriver driver;
        protected static Logger logger = LogManager.GetCurrentClassLogger();

        Cart cart;
        public Cart Cart => cart ?? (cart = new Cart());

        public By HeaderSignInButton => By.XPath("//a[@class='login']");
        public By HeaderSignOutButton => By.XPath("//a[@class='logout']");
        public By HeaderMyAccountButton => By.XPath("//div[@class='header_user_info']/a");
        public By Logo => By.XPath("//div[@id='header_logo']/a/img");
        public By SearchTextInput => By.XPath("//input[@id='search_query_top']");
        public By SearchButton => By.XPath("//button[@name='submit_search']");
        public By TopMenuLink(string title) => By.XPath($"//li/a[@title='{title}']");

        public abstract Func<bool> IsAtRule { get; }

        public PageModelBase(IWebDriver driver) => this.driver = driver;

        public void ClickHeaderSignIn() => DriverService.Instance.ClickWebElement(HeaderSignInButton);
        public void ClickHeaderSignOut() => DriverService.Instance.ClickWebElement(HeaderSignOutButton);
        public void ClickHeaderMyAccount() => DriverService.Instance.ClickWebElement(HeaderMyAccountButton);
        public void ClickTopMenuWomenLink() => DriverService.Instance.ClickWebElement(TopMenuLink("Women"));
        public void ClickTopMenuDressesLink() => DriverService.Instance.ClickWebElement(TopMenuLink("Dresses"));
        public void ClickTopMenuTShirtsLink() => DriverService.Instance.ClickWebElement(TopMenuLink("T-shirts"));

        protected bool IsAt()
        {
            try
            {
                return IsAtRule.Invoke();
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}