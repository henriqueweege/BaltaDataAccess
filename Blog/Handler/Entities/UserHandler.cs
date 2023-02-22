using Blog.Factory;
using Blog.Infrastructure;
using Blog.Infrastructure.Exceptions;
using Blog.Models;
using Blog.Repositories;
using Blog.Service.OAuth;
using Microsoft.Data.SqlClient;

namespace Blog.Handler.Entities
{
    public static class UserHandler
    {

        public static IEnumerable<UserModel> GetAllWithRoles()
        {
            var users = new List<UserModel>();
            using (var connection = new SqlConnection(AppSettingsReader.GetConnectionString()))
            {
                var repository = new UserRepository(connection);
                users = repository.GetWithRoles();
            }

            if (users.Any())
                return users;

            throw new NoObjectException();
        }

        public static IEnumerable<UserModel> GetAll(SqlConnection connection)
        {
            var repository = new UserRepository(connection);
            return repository.GetAll();
        }
        public static long CreateUser(string email,
                               string password,
                               string bio,
                               string image,
                               string name,
                               int idRole)
        {
            var passwordHash = OAuthService.HashPassword(password);

            var userToAdd = EntitiesFactory.CreateUser(email, passwordHash, bio, image, name);

            long idUser;

            using (var connection = new SqlConnection(AppSettingsReader.GetConnectionString()))
            {
                connection.Open();
                var repository = new UserRepository(connection);
                idUser = repository.Create(userToAdd);
                UserRoleHandler.Create(idRole, idUser, connection);
                connection.Close();
            }

            return idUser;
        }

        public static IEnumerable<UserModel> GetUserByRole(string roleName)
        {
            var authors = new List<UserModel>();

            using (var connection = new SqlConnection(AppSettingsReader.GetConnectionString()))
            {
                var role = RoleHandler.Get(connection, roleName);
                var userRoles = UserRoleHandler.GetAll(connection).Where(x => x.RoleId == role.Id);

                foreach (var uR in userRoles)
                {
                    var users = GetAll(connection).Where(x => x.Id == uR.UserId);

                    if (users.Any())
                    {
                        authors.AddRange(users);
                    }
                }
            }

            return authors.AsEnumerable();
        }
    }
}
