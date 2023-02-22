using Blog.Display.Helpers;
using Blog.Infrastructure.Exceptions;

namespace Blog.Display.Screens
{
    public static class MainScreen
    {

        public static void MainMenu()
        {
            try
            {
                Console.WriteLine("Please, choose what you would like to do following the menu below.");
                Console.WriteLine("1- Create.");
                Console.WriteLine("2- Display.");
                Console.WriteLine("0- Exit.");

                var opt = Console.ReadLine();
                opt = InputHelper.Check(opt);

                switch (int.Parse(opt))
                {
                    case 0:
                        {
                            Console.WriteLine("That is all, then. Thank you! ^-^");
                            Thread.Sleep(5000);
                            Environment.Exit(0);
                        }; break;
                    case 1: CreateMenu(); break;
                    case 2: DisplayMenu(); break;
                    default: MainMenu(); break;

                }

            }
            catch (NotANumberException)
            {
                MessageHelper.NotANumber();
            }
        }

        private static void DisplayMenu()
        {
            try
            {

                Console.Clear();
                Console.WriteLine("Please, choose what you would like to do following the menu below.");
                Console.WriteLine("1- Display all users.");
                Console.WriteLine("2- Display categories with number of posts.");
                Console.WriteLine("3- Display tags with number of posts.");
                Console.WriteLine("4- Display posts of a category.");
                Console.WriteLine("5- Display all posts with their category.");
                Console.WriteLine("6- Display all posts with their tags.");
                Console.WriteLine("0- Exit.");

                var opt = Console.ReadLine();
                opt = InputHelper.Check(opt);


                switch (int.Parse(opt))
                {
                    case 0: MainMenu(); break;

                    case 1:
                        {

                            try
                            {
                                UserScreen.DisplayAllUsers();
                                MessageHelper.AfterAction();
                            }
                            catch (NoObjectException)
                            {
                                MessageHelper.NoUser();
                            }

                        }
                        break;

                    case 2:
                        {

                            try
                            {
                                CategoryScreen.DisplayAllCategoriesWithPostsNumbers();
                                MessageHelper.AfterAction();
                            }
                            catch (NoObjectException)
                            {
                                MessageHelper.NoUser();
                            }

                        }
                        break;

                    case 3:
                        {

                            try
                            {
                                TagScreen.DisplayAllTagsWithPostsNumbers();
                                MessageHelper.AfterAction();
                            }
                            catch (NoObjectException)
                            {
                                MessageHelper.NoUser();
                            }

                        }

                        break;
                    case 4:
                        {

                            try
                            {
                                PostScreens.DisplayAllPostOfACategory();
                                MessageHelper.AfterAction();
                            }
                            catch (NoObjectException)
                            {
                                MessageHelper.NoUser();
                            }

                        }

                        break;
                    case 5:
                        {
                            try
                            {
                                PostScreens.DisplayAllPostWithCategory();
                                MessageHelper.AfterAction();
                            }
                            catch (NoObjectException)
                            {
                                MessageHelper.NoUser();
                            }
                        }
                        break;
                    case 6:
                        {
                            try
                            {
                                PostScreens.DisplayAllPostWithTags();
                                MessageHelper.AfterAction();
                            }
                            catch (NoObjectException)
                            {
                                MessageHelper.NoUser();
                            }
                        }
                        break;
                }
            }
            catch (NotANumberException)
            {
                MessageHelper.NotANumber();
            }
        }

        private static void CreateMenu()
        {
            try
            {
                Console.Clear();
                Console.WriteLine("Please, choose what you would like to do following the menu below.");
                Console.WriteLine("1- Create new user.");
                Console.WriteLine("2- Create new role.");
                Console.WriteLine("3- Create new category.");
                Console.WriteLine("4- Create new tag.");
                Console.WriteLine("5- Create new post.");
                Console.WriteLine("0- Exit.");

                var opt = Console.ReadLine();
                opt = InputHelper.Check(opt);


                switch (int.Parse(opt))
                {
                    case 0: MainMenu(); break;


                    case 1:
                        {

                            try
                            {
                                UserScreen.CreateUser();
                                MessageHelper.AfterAction();
                            }
                            catch (NoRoleException ex)
                            {
                                MessageHelper.NoRole();
                            }
                            catch (ArgumentException ex)
                            {
                                MessageHelper.InvalidParameter();
                            }
                            catch
                            {
                                MessageHelper.FatalError();
                            }

                        }
                        break;


                    case 2:
                        {

                            try
                            {
                                RoleScreen.CreateRole();
                                MessageHelper.AfterAction();
                            }
                            catch (ArgumentException ex)
                            {
                                MessageHelper.InvalidParameter();
                            }
                            catch
                            {
                                MessageHelper.FatalError();
                            }

                        }
                        break;


                    case 3:
                        {

                            try
                            {
                                CategoryScreen.CreateCategory();
                                MessageHelper.AfterAction();
                            }
                            catch (ArgumentException ex)
                            {
                                MessageHelper.InvalidParameter();
                            }
                            catch
                            {
                                MessageHelper.FatalError();
                            }

                        }
                        break;


                    case 4:
                        {

                            try
                            {
                                TagScreen.CreateTag();
                                MessageHelper.AfterAction();
                            }
                            catch (ArgumentException ex)
                            {
                                MessageHelper.InvalidParameter();
                            }
                            catch
                            {
                                MessageHelper.FatalError();
                            }

                        }
                        break;

                    case 5:
                        {

                            try
                            {
                                PostScreens.CreatePost();
                                MessageHelper.AfterAction();
                            }
                            catch (NoUserRoleException)
                            {
                                MessageHelper.NoUserRole();
                            }
                            catch (NoRoleException)
                            {
                                MessageHelper.NoRole();
                            }
                            catch (ArgumentException)
                            {
                                MessageHelper.InvalidParameter();
                            }
                            catch (Exception ex)
                            {
                                MessageHelper.FatalError();
                            }

                        }
                        break;


                    default:
                        {
                            MessageHelper.Default();
                        }
                        break;
                }
            }
            catch (NotANumberException)
            {
                MessageHelper.NotANumber();
            }
            catch (ArgumentException)
            {
                MessageHelper.InvalidParameter();
            }
        }
    }
}
