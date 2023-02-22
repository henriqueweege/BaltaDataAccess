using Blog.Display.Helpers;
using Blog.Handler.Entities;
using Blog.Infrastructure.Exceptions;
using Blog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Display.Screens
{
    public static class PostScreens
    {

        public static void DisplayAllPostWithCategory()
        {
            IEnumerable<CategoryModel> categories = CategoryHandler.GetAllWithPosts();
            PrintHelper.PrintAllPostWithCategory(categories.ToList());
            UserActionHelper.PressKeyToContinue();

        }

        public static void CreatePost()
        {
            Console.Clear();
            List<UserModel> authors = UserHandler.GetUserByRole("Author").ToList();

            if (!authors.Any())
            {
                throw new NoAuthorException();
            }

            var authorHelper = new ObjectHelper<UserModel>();
            var idAuthor = authorHelper.Choose(authors, "author");

            List<CategoryModel> categories = CategoryHandler.GetAll().ToList();

            var categoryHelper = new ObjectHelper<CategoryModel>();
            var idCategory = categoryHelper.Choose(categories, "category");


            var title = InputHelper.Get("title", "post");
            var summary = InputHelper.Get("summary", "post");
            var body = InputHelper.Get("body", "post");

            var idPost = PostHandler.Create(idAuthor, idCategory, title, summary, body);


            AddTags(idPost);
        }
        private static void AddTags(long idPost)
        {

            var tags = TagHandler.GetAll();
            bool addTag = true;

            while (addTag)
            {
                var helper = new ObjectHelper<TagModel>();
                var idTag = helper.Choose(tags.ToList(), "tag");
                PostTagHandler.Create((int)idPost, idTag);


                addTag = UserActionHelper.Break("Do you want to add more tags?Y/N");
            }
        }
        public static void DisplayAllPostWithTags()
        {
            IEnumerable<PostModel> posts = PostHandler.GetAllWithTags();
            PrintHelper.PrintAllPostWithTags(posts.ToList());
            UserActionHelper.PressKeyToContinue();
        }

        public static void DisplayAllPostOfACategory()
        {
            Console.Clear();
            var helper = new ObjectHelper<CategoryModel>();
            var categories = CategoryHandler.GetAll();
            var idCategory = helper.Choose(categories.ToList(), "category");

            IEnumerable<PostModel> posts = PostHandler.GetByCategory(idCategory);

            if (posts.Any())
            {
                Console.Clear();

                foreach (var post in posts)
                {
                    Console.WriteLine($"Post Title: {post.Title}");
                }

                UserActionHelper.PressKeyToContinue();
            }
            else
            {
                Console.WriteLine("There is no post in the selected category.");
            }

        }
    }
}
