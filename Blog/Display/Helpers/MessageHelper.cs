using Blog.Display.Screens;

namespace Blog.Display.Helpers
{
    public static class MessageHelper
    {
        public static void InvalidInput(string entityName)
        {
            Console.WriteLine($"That is not a valid {entityName}. Please, try again.");
            Thread.Sleep(5000);
        }

        public static void Default()
            => BaseMessage("Invlaid option.");


        public static void NoRole()
            => BaseMessage("There are no roles redistered! Please, add a new role and try again. :)");

        public static void AfterAction()
            => BaseMessage("Action succeeded! ;)");

        public static void NotANumber()
            => BaseMessage("Just numbers are accepted. Please, try again. :)");

        public static void InvalidParameter()
            => BaseMessage("All parameters need to be properly filled in! Please, try again. :)");

        internal static void NoUserRole()
            => BaseMessage("There is no user with roles! Please, check if there are any user registered " +
                           "with the specific role and try again. :)");
        public static void FatalError()
        {
            Console.WriteLine("I am sorry, but I just broke x_x");
            Environment.Exit(1);
        }
        public static void NoUser()
            => BaseMessage("There are no users registered.");

        private static void BaseMessage(string message)
        {
            Console.Clear();
            Console.WriteLine(message);
            Thread.Sleep(3000);
            Console.Clear();
            MainScreen.MainMenu();
        }
    }
}
