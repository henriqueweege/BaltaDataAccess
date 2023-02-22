using Blog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Display.Helpers
{
    public static class PrintHelper
    {
        public static void PrintUsers(IEnumerable<UserModel> users)
        {
            Console.Clear();
            foreach (UserModel user in users)
            {
                Console.WriteLine($"Name: {user.Name}, Email: {user.Email}");
                if (user.Roles.Any())
                {
                    Console.Write("Roles:");
                    for (var i = 0; i < user.Roles.Count; i++)
                    {
                        Console.Write($"{user.Roles[i].Name}");

                        if (i < user.Roles.Count - 2)
                            Console.Write(", ");
                    }
                    Console.WriteLine();
                }
            }

        }

        public static void PrintCategoryWithNumberOfPosts(IEnumerable<CategoryModel> categories)
        {
            Console.Clear();
            foreach (var category in categories)
            {
                Console.WriteLine($"Name: {category.Name}, Quantity of posts: {category.Posts.Count()}");
            }
        }

        public static void PrintAllPostWithCategory(List<CategoryModel> categories)
        {
            Console.Clear();
            foreach (var category in categories)
            {
                if (category.Posts.Any())
                {
                    Console.WriteLine($"The category {category.Name} has the following posts:");
                    foreach (var post in category.Posts)
                    {
                        Console.WriteLine(post.Title);
                    }
                }
            }
        }
        public static void PrintTagsWithNumberOfPosts(IEnumerable<TagModel> tags)
        {
            Console.Clear();
            foreach (var tag in tags)
            {
                Console.WriteLine($"Name: {tag.Name}, Quantity of posts: {tag.Posts.Count()}");
            }
        }

        public static void PrintAllPostWithTags(List<PostModel> posts)
        {
            foreach (var post in posts)
            {
                if (post.Tags.Any())
                {
                    Console.WriteLine($"The post {post.Title} has the following tags:");
                    for (var i = 0; i < post.Tags.Count; i++)
                    {
                        Console.Write($"{post.Tags[i].Name}");

                        if (i < post.Tags.Count - 1)
                            Console.Write(", ");
                    }
                    Console.WriteLine();
                }
                else
                {
                    Console.WriteLine($"The post {post.Title} doesn't have any tags.");
                }


            }
        }
    }
}
