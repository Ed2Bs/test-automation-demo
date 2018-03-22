namespace TestAutomationDemo
{
    public static class Globals
    {
        public static string Url => "http://automationpractice.com";
        public static double WaitTimeout => 5;

        private static User user;
        public static User User => user ?? (user = new User());
    }

    public class User
    {
        public string Name { get; set; }
        public string LastName { get; set; }
    }
}
