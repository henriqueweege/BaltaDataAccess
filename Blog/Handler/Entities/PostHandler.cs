using Blog.Factory;
using Blog.Infrastructure;
using Blog.Models;
using Blog.Repositories;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Handler.Entities
{
    public static class PostHandler
    {
        internal static long Create(int idAuthor, int idCategory, string title, string summary, string body)
        {
            var postToAdd = EntitiesFactory.CreatePost(idAuthor, idCategory, title, summary, body);
            long id;
            using (var connection = new SqlConnection(AppSettingsReader.GetConnectionString()))
            {
                connection.Open();
                var repository = new PostRepository(connection);
                id = repository.Create(postToAdd);
                connection.Close();
            }
            return id;
        }

        internal static IEnumerable<PostModel> GetAllWithTags()
        {
            IEnumerable<PostModel> posts;
            using (var connection = new SqlConnection(AppSettingsReader.GetConnectionString()))
            {
                connection.Open();
                var repository = new PostRepository(connection);
                posts = repository.GetAllWithTags();
                connection.Close();
            }

            return posts;
        }

        internal static IEnumerable<PostModel> GetByCategory(int idCategory)
        {
            IEnumerable<PostModel> posts;
            using (var connection = new SqlConnection(AppSettingsReader.GetConnectionString()))
            {
                connection.Open();
                var repository = new PostRepository(connection);
                posts = repository.GetByCategory(idCategory);
                connection.Close();
            }

            return posts;
        }
    }
}
