using Blog.Display.Helpers;
using Blog.Handler.Entities;

namespace Blog.Display.Screens
{
    public static class RoleScreen
    {
        public static void CreateRole()
           => RoleHandler.Create(InputHelper.Get("name", "role"));

    }
}
