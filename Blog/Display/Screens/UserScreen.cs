using Blog.Display.Helpers;
using Blog.Handler.Entities;
using Blog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Display.Screens
{
    public static class UserScreen
    {
        public static void CreateUser()
        {
            Console.Clear();

            var name = InputHelper.Get("name", "user");
            var email = InputHelper.Get("email", "user");
            var bio = InputHelper.Get("bio", "user");
            var image = InputHelper.Get("image", "user");
            var password = InputHelper.Get("password", "user");

            int idRole = ChooseRole();
            InputHelper.Check(idRole);

            UserHandler.CreateUser(email, bio, password, image, name, idRole);
        }

        private static int ChooseRole()
            => new ObjectHelper<RoleModel>().Choose(RoleHandler.GetAll().ToList(), "role");
        public static void DisplayAllUsers()
        {
            IEnumerable<UserModel> users = UserHandler.GetAllWithRoles();
            PrintHelper.PrintUsers(users);
            UserActionHelper.PressKeyToContinue();

        }
    }
}
