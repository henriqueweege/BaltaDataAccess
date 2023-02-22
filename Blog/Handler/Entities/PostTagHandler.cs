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
    public static class PostTagHandler
    {
        public static void Create(int idPost, int idTag)
        {
            var postTagToAdd = EntitiesFactory.CreatePostTag(idPost, idTag);

            using (var connection = new SqlConnection(AppSettingsReader.GetConnectionString()))
            {
                connection.Open();
                var repository = new PostTagRepository(connection);
                repository.Create(postTagToAdd);
                connection.Close();
            }

        }
    }
}
