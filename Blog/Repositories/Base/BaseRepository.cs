using Blog.Models;
using Blog.Models.Base;
using Dapper.Contrib.Extensions;
using Microsoft.Data.SqlClient;

namespace Blog.Repositories.Base
{
    public class BaseRepository<TModel> where TModel : BaseModel
    {
        private readonly SqlConnection Connection;

        public BaseRepository(SqlConnection connection)
            => Connection = connection;

        public IEnumerable<TModel> GetAll()
            => Connection.GetAll<TModel>().AsEnumerable();

        public TModel Get(int id)
            => Connection.Get<TModel>(id);

        public long Create(TModel model)
            => Connection.Insert(model);

        public void Update(TModel model)
        {
            if (model.Id != 0)
            {
                Connection.Update(model);
            }
        }

        public void Remove(TModel model)
        {
            if (model.Id != 0)
            {
                Connection.Delete(model);
            }
        }

        public void Remove(int id)
            => Connection.Delete(Get(id));
    }
}
