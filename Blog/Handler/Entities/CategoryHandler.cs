using Blog.Factory;
using Blog.Infrastructure;
using Blog.Infrastructure.Exceptions;
using Blog.Models;
using Blog.Repositories;
using Microsoft.Data.SqlClient;

namespace Blog.Handler.Entities
{
    public static class CategoryHandler
    {
        public static void Create(string name)
        {
            var categoryToAdd = EntitiesFactory.CreateCategory(name);

            using (var connection = new SqlConnection(AppSettingsReader.GetConnectionString()))
            {
                connection.Open();
                var repository = new CategoryRepository(connection);
                repository.Create(categoryToAdd);
                connection.Close();
            }
        }

        public static IEnumerable<CategoryModel> GetAll()
        {
            var categories = new List<CategoryModel>();

            using (var connection = new SqlConnection(AppSettingsReader.GetConnectionString()))
            {
                connection.Open();
                var repository = new CategoryRepository(connection);
                categories = repository.GetAll().ToList();
                connection.Close();
            }

            return categories;
        }

        internal static IEnumerable<CategoryModel> GetAllWithPosts()
        {
            var categories = new List<CategoryModel>();

            using (var connection = new SqlConnection(AppSettingsReader.GetConnectionString()))
            {
                connection.Open();
                var repository = new CategoryRepository(connection);
                categories = repository.GetAllWithPosts().ToList();
                connection.Close();
            }

            if (categories.Any())
                return categories;

            throw new NoObjectException();
        }
    }
}
