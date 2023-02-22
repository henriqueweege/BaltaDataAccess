using Blog.Factory;
using Blog.Infrastructure;
using Blog.Infrastructure.Exceptions;
using Blog.Models;
using Blog.Repositories;
using Microsoft.Data.SqlClient;

namespace Blog.Handler.Entities
{
    public static class RoleHandler
    {
        public static void Create(string name)
        {
            var roleToAdd = EntitiesFactory.CreateRole(name);

            using (var connection = new SqlConnection(AppSettingsReader.GetConnectionString()))
            {
                connection.Open();
                var repository = new RoleRepository(connection);
                repository.Create(roleToAdd);
                connection.Close();
            }

        }

        public static RoleModel Get(SqlConnection connection, string roleName)
        {

            connection.Open();
            var repository = new RoleRepository(connection);
            var role = repository.GetAll().FirstOrDefault(x => x.Name == roleName);
            connection.Close();


            if (role is not null)
            {
                return role;
            }

            throw new NoRoleException();
        }

        public static IEnumerable<RoleModel> GetAll(SqlConnection connection)
        {

            connection.Open();
            var repository = new RoleRepository(connection);
            var roles = repository.GetAll().ToList();
            connection.Close();


            if (roles.Count > 0)
            {
                return roles;
            }

            throw new NoRoleException();
        }
        public static IEnumerable<RoleModel> GetAll()
        {

            var roles = new List<RoleModel>();

            using (var connection = new SqlConnection(AppSettingsReader.GetConnectionString()))
            {
                connection.Open();
                var repository = new RoleRepository(connection);
                roles = repository.GetAll().ToList();
                connection.Close();
            }

            if (roles.Count > 0)
            {
                return roles;
            }

            throw new NoRoleException();
        }
    }
}
