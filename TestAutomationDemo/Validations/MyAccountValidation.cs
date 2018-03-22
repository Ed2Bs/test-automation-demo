using NLog;
using NUnit.Framework;
using TestAutomationDemo.Models;

namespace TestAutomationDemo.Validations
{
    public class MyAccountValidation
    {
        private MyAccount myAccount;
        private static Logger logger = LogManager.GetCurrentClassLogger();

        public MyAccountValidation(MyAccount myAccount) => this.myAccount = myAccount;

        public void HeaderIsVisible()
        {
            try
            {
                Assert.IsTrue(myAccount.Header?.Displayed);
                logger.Info("My Account page header text is visible");
            }
            catch (AssertionException)
            {
                logger.Error("My Account page header text is not visible");
                throw;
            }
        }

        public void MyAccountLinkListIsVisible()
        {
            try
            {
                Assert.IsTrue(myAccount.MyAccountLinkList?.Count == 5);
                logger.Info("My Account link list is visible");
            }
            catch (AssertionException)
            {
                logger.Error("My Account link list is not visible");
                throw;
            }
        }

        public void UserNameIsDisplayed()
        {
            try
            {
                Assert.IsTrue(myAccount.UserInfoSpan?.Text == $"{Globals.User.Name} {Globals.User.LastName}");
                logger.Info("User name is displayed");
            }
            catch (AssertionException)
            {
                logger.Error("User name is not displayed");
                throw;
            }
        }
    }
}