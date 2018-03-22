using NLog;
using NUnit.Framework;
using TestAutomationDemo.Models;

namespace TestAutomationDemo.Validations
{
    public class AuthenticationValidation
    {
        private Authentication authentication;
        private static Logger logger = LogManager.GetCurrentClassLogger();

        public AuthenticationValidation(Authentication authentication) => this.authentication = authentication;

        public void HeaderIsVisible()
        {
            try
            {
                Assert.IsTrue(DriverService.Instance.GetWebElement(authentication.Header)?.Displayed);
                logger.Info("Authentication page header text is visible");
            }
            catch (AssertionException)
            {
                logger.Error("Authentication page header text is not visible");
                throw;
            }
        }
    }
}