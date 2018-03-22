using System;
using System.Collections.ObjectModel;
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
        public Cart Cart => cart ?? (cart = new Cart(driver));

        public IWebElement HeaderSignInButton => GetWebElement("//a[@class='login']");
        public IWebElement HeaderSignOutButton => GetWebElement("//a[@class='logout']");
        public IWebElement HeaderMyAccountButton => GetWebElement("//div[@class='header_user_info']/a");

        public IWebElement Logo => GetWebElement("//div[@id='header_logo']/a/img");
        public IWebElement SearchTextInput => GetWebElement("//input[@id='search_query_top']");
        public IWebElement SearchButton => GetWebElement("//button[@name='submit_search']");
        public IWebElement TopMenuLink(string title) => GetWebElement($"//li/a[@title='{title}']");

        public abstract Func<bool> Displayed { get; }

        public PageModelBase(IWebDriver driver) => this.driver = driver;


        public void ClickHeaderSignIn() => ClickWebElement(HeaderSignInButton);
        public void ClickHeaderSignOut() => ClickWebElement(HeaderSignOutButton);
        public void ClickHeaderMyAccount() => ClickWebElement(HeaderMyAccountButton);
        public void ClickTopMenuWomenLink() => ClickWebElement(TopMenuLink("Women"));
        public void ClickTopMenuDressesLink() => ClickWebElement(TopMenuLink("Dresses"));
        public void ClickTopMenuTShirtsLink() => ClickWebElement(TopMenuLink("T-shirts"));

        protected IWebElement GetWebElement(string xpath)
        {
            try
            {
                logger.Info($"Finding element for {xpath}");
                return driver.FindElement(By.XPath(xpath));
            }
            catch (NoSuchElementException e)
            {
                logger.Error(e.Message);
                Service.GetScreenshot();
                return null;
            }
        }

        protected ReadOnlyCollection<IWebElement> GetWebElements(string xpath)
        {
            try
            {
                logger.Info($"Finding element for {xpath}");
                return driver.FindElements(By.XPath(xpath));
            }
            catch (NoSuchElementException e)
            {
                logger.Error(e.Message);
                Service.GetScreenshot();
                return null;
            }
        }

        protected void ClickWebElement(IWebElement webElement)
        {
            try
            {
                webElement.Click();
                logger.Info("Clicked on element");
            }
            catch (Exception)
            {
                logger.Error(new NoSuchElementException("Unable to click on element"));
            }
        }

        protected bool IsAt()
        {
            try
            {
                return Displayed.Invoke();
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}