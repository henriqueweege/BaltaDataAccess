using Blog.Models;
using Blog.Repositories.Base;
using Dapper.Contrib.Extensions;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Repositories
{
    public class PostTagRepository
    {
        public SqlConnection Connection { get; set; }
        public PostTagRepository(SqlConnection connection)
        {
            Connection= connection;
        }


        public IEnumerable<PostTagModel> GetAll()
            => Connection.GetAll<PostTagModel>().AsEnumerable();

        public PostTagModel Get(int id)
            => Connection.Get<PostTagModel>(id);

        public long Create(PostTagModel model)
            => Connection.Insert(model);

        public void Update(PostTagModel model)
        {
            if (model.Id != 0)
            {
                Connection.Update(model);
            }
        }

        public void Remove(PostTagModel model)
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
