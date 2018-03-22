using System;
using System.IO;
using NLog;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using TestAutomationDemo.TestSuites;

namespace TestAutomationDemo
{
    public class Service
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();

        //singleton
        private static readonly Service instance = new Service();
        public static Service Instance => instance;

        private IWebDriver driver;
        public IWebDriver Driver => driver ?? throw new InvalidOperationException("Driver is not initialized. Call DriverInit() first!");

        private Service() { }

        public void DriverInit()
        {
            driver = new ChromeDriver();

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(Globals.WaitTimeout);
            driver.Manage().Window.Maximize();

            driver.Url = Globals.Url;

            logger.Info("Driver initialized");
        }

        public void QuitDriver()
        {
            Driver.Quit();
        }

        public static void GetScreenshot()
        {
            Directory.CreateDirectory(@"C:\temp");
            Screenshot screenshot = ((ITakesScreenshot)Instance.Driver).GetScreenshot();
            screenshot.SaveAsFile($@"C:\temp\{TestBase.TestStartTime}_{TestBase.TestName}_screenshot.png", ScreenshotImageFormat.Png);
        }

        public static void WaitFor(Func<IWebDriver, IWebElement> condition)
        {
            WebDriverWait driverWait = new WebDriverWait(Instance.Driver, TimeSpan.FromSeconds(5));
            driverWait.Until(condition);
        }
    }
}
