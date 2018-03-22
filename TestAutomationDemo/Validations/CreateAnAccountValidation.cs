using NLog;
using NUnit.Framework;
using TestAutomationDemo.Models;

namespace TestAutomationDemo.Validations
{
    public class CreateAnAccountValidation
    {
        private CreateAnAccount createAnAccount;
        private static Logger logger = LogManager.GetCurrentClassLogger();

        public CreateAnAccountValidation(CreateAnAccount createAnAccount) => this.createAnAccount = createAnAccount;

        public void HeaderIsVisible()
        {
            try
            {
                Assert.IsTrue(createAnAccount.Header?.Displayed);
                logger.Info("Create an Account page header text is visible");
            }
            catch (AssertionException)
            {
                logger.Error("Create an Account page header text is not visible");
                throw;
            }
        }
    }
}