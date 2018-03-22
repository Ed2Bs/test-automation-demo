using System;
using System.Collections.ObjectModel;
using System.IO;
using NLog;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using TestAutomationDemo.TestSuites;

namespace TestAutomationDemo
{
    public class DriverService
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();

        //singleton
        private static readonly DriverService instance = new DriverService();
        public static DriverService Instance => instance;

        private IWebDriver driver;
        private WebDriverWait driverWait;

        public IWebDriver Driver => driver ?? throw new InvalidOperationException("Driver is not initialized. Call DriverInit() first!");

        private DriverService() { }

        public void DriverInit()
        {
            driver = new ChromeDriver();

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(Globals.WaitTimeout);
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl(Globals.Url);

            driverWait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            logger.Info("Driver initialized");
        }

        public void QuitDriver()
        {
            Driver.Quit();
        }

        public void GetScreenshot()
        {
            Directory.CreateDirectory(@"C:\temp");
            Screenshot screenshot = ((ITakesScreenshot)Driver).GetScreenshot();
            screenshot.SaveAsFile($@"C:\temp\{TestBase.TestStartTime}_{TestBase.TestName}_screenshot.png", ScreenshotImageFormat.Png);
        }

        public void WaitUntil(Func<IWebDriver, IWebElement> condition) => driverWait?.Until(condition);

        public IWebElement GetWebElement(By by)
        {
            try
            {
                logger.Info($"Finding element for {by.ToString()}");
                return Driver.FindElement(by);
            }
            catch (NoSuchElementException e)
            {
                logger.Error(e.Message);
                GetScreenshot();
                return null;
            }
        }

        public ReadOnlyCollection<IWebElement> GetWebElements(By by)
        {
            try
            {
                logger.Info($"Finding element for {by.ToString()}");
                return Driver.FindElements(by);
            }
            catch (NoSuchElementException e)
            {
                logger.Error(e.Message);
                GetScreenshot();
                return null;
            }
        }

        public void ClickWebElement(By by)
        {
            try
            {
                GetWebElement(by).Click();
                logger.Info("Clicked on element");
            }
            catch (Exception)
            {
                logger.Error(new NoSuchElementException("Unable to click on element"));
            }
        }
    }
}
