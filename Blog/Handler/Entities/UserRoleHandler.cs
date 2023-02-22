using Blog.Infrastructure.Exceptions;
using Blog.Models;
using Blog.Repositories;
using Microsoft.Data.SqlClient;

namespace Blog.Handler.Entities
{
    public static class UserRoleHandler
    {
        public static IEnumerable<UserRoleModel> GetAll(SqlConnection connection)
        {
            var respository = new UserRoleRepository(connection);
            var userRoles = respository.GetAll();
            if (userRoles.Count() > 0)
            {
                return userRoles;
            }

            throw new NoUserRoleException();
        }

        public static void Create(int idRole, long idUser, SqlConnection connection)
        {
            var userRoleToCreate = new UserRoleModel()
            {
                UserId = idUser,
                RoleId = idRole
            };
            var repository = new UserRoleRepository(connection);
            repository.Create(userRoleToCreate);
        }
    }
}
