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
    public static class CategoryScreen
    {
        public static void DisplayAllCategoriesWithPostsNumbers()
        {
            IEnumerable<CategoryModel> categories = CategoryHandler.GetAllWithPosts();
            PrintHelper.PrintCategoryWithNumberOfPosts(categories);
            UserActionHelper.PressKeyToContinue();

        }

        public static void CreateCategory()
            => CategoryHandler.Create(InputHelper.Get("name", "category"));
    }
}
