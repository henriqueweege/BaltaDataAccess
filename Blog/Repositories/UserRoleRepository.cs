using Blog.Models;
using Dapper.Contrib.Extensions;
using Microsoft.Data.SqlClient;

namespace Blog.Repositories
{
    public class UserRoleRepository
    {
        private readonly SqlConnection Connection;

        public UserRoleRepository(SqlConnection connection)
        {
            this.Connection = connection;
        }

        public IEnumerable<UserRoleModel> GetAll()
            => Connection.GetAll<UserRoleModel>().AsEnumerable();

        public UserRoleModel Get(int id)
            => Connection.Get<UserRoleModel>(id);

        public long Create(UserRoleModel model)
            => Connection.Insert(model);

        public void Remove(int id)
            => Connection.Delete(Get(id));
    }
}
