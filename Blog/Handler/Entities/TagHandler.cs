using Blog.Factory;
using Blog.Infrastructure;
using Blog.Infrastructure.Exceptions;
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
    public static class TagHandler
    {
        public static void Create(string name)
        {
            var tagToAdd = EntitiesFactory.CreateTag(name);

            using (var connection = new SqlConnection(AppSettingsReader.GetConnectionString()))
            {
                connection.Open();
                var repository = new TagRepository(connection);
                repository.Create(tagToAdd);
                connection.Close();
            }
        }

        internal static IEnumerable<TagModel> GetAll()
        {
            IEnumerable<TagModel> tags;
            using (var connection = new SqlConnection(AppSettingsReader.GetConnectionString()))
            {
                connection.Open();
                var repository = new TagRepository(connection);
                tags = repository.GetAll();
                connection.Close();
            }
            
            if (tags.Any())
            {
                return tags;
            }

            throw new NoTagException();
        }

        internal static IEnumerable<TagModel> GetAllWithPosts()
        {
            IEnumerable<TagModel> tags;
            using (var connection = new SqlConnection(AppSettingsReader.GetConnectionString()))
            {
                connection.Open();
                var repository = new TagRepository(connection);
                tags = repository.GetAllWithPosts();
                connection.Close();
            }

            if (tags.Any())
            {
                return tags;
            }

            throw new NoTagException();
        }
    }
}
