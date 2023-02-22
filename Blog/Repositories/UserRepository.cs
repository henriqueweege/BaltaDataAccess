using Blog.Models;
using Blog.Repositories.Base;
using Dapper;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Repositories
{
    public class UserRepository:BaseRepository<UserModel>
    {
        private readonly SqlConnection Connection;

        public UserRepository(SqlConnection connection) : base(connection)
            => Connection = connection;


        public List<UserModel> GetWithRoles()
        {
            var query = @"SELECT 
                            [User].*,
                            [Role].* 
                          FROM 
                            [User] 
                            LEFT JOIN [UserRole] ON [UserRole].[USerId] = [User].[Id] 
                            LEFT JOIN [Role] ON [UserRole].[RoleId] = [Role].[Id]";

            var users = new List<UserModel>();

            var items = Connection.Query<UserModel, RoleModel, UserModel>(
                query,
                (user, role) =>
                {
                    var usr = users.FirstOrDefault(x => x.Id == user.Id);

                    if (usr is null)
                    {
                        usr = user;

                        if(role is not null)
                            usr.Roles.Add(role);

                        users.Add(usr);
                    }
                    else
                    {
                        usr.Roles.Add(role);
                    }

                    return user;

                }, splitOn: "Id");

            
            return users;

        }
    }
}
