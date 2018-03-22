using NLog;
using NUnit.Framework;
using System.Diagnostics;

namespace TestAutomationDemo.TestSuites
{
    [TestFixture]
    public abstract class TestBase
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();

        Pages pages;
        protected Pages Pages => pages;

        Validation validation;
        protected Validation Validation => validation;

        TestData testData;
        protected TestData TestData => testData;

        public static string TestStartTime { get; private set; }
        public static string TestName { get; private set; }

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            logger.Info("Starting test fixture");
        }

        [SetUp]
        public void SetUp()
        {
            TestStartTime = System.DateTime.Now.ToString("yyyy-MM-dd-HHmmss");
            TestName = TestContext.CurrentContext.Test.MethodName;
            logger.Info($"Starting test: {TestName}");

            DriverService.Instance.DriverInit();

            pages = new Pages();
            validation = new Validation(pages);
            testData = new TestData();
        }


        [TearDown]
        public void TearDown()
        {
            DriverService.Instance.QuitDriver();
            logger.Info("Browser closed, webdriver disposed");
        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            logger.Info("Stopping test fixture");

            //clean up leftovers
            foreach (var p in Process.GetProcessesByName("chromedriver"))
                if (!p.HasExited) p?.Kill();
        }
    }
}
