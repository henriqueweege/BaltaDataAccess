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
    public static class TagScreen
    {
        public static void DisplayAllTagsWithPostsNumbers()
        {
            IEnumerable<TagModel> tags = TagHandler.GetAllWithPosts();
            PrintHelper.PrintTagsWithNumberOfPosts(tags);
            UserActionHelper.PressKeyToContinue();
        }
        public static void CreateTag()
            => TagHandler.Create(InputHelper.Get("name", "tag"));
    }
}
