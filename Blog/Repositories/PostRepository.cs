using Blog.Models;
using Blog.Repositories.Base;
using Dapper;
using Dapper.Contrib.Extensions;
using Microsoft.Data.SqlClient;

namespace Blog.Repositories
{
    public class PostRepository
    {
        public SqlConnection Connection { get; set; }
        public PostRepository(SqlConnection connection)
            => Connection = connection;

        public IEnumerable<PostModel> GetAllWithTags()
        {
            var query = 
                "SELECT" +
                    "[Post].*," +
                    "[Tag].*" +
                "FROM    " +
                    "[Post]" +
                "LEFT JOIN [PostTag] ON [PostTag].[PostId] = [Post].[Id]" +
                "LEFT JOIN [Tag] ON [PostTag].[TagId] = [Tag].[Id]";
                
            var posts = new List<PostModel>();

            var items = Connection.Query<PostModel, TagModel, PostModel>(
                query,
                (post, tag) =>
                {
                    var p = posts.FirstOrDefault(x => x.Id == post.Id);

                    if (p is null)
                    {
                        p = post;

                        if (tag is not null)
                            p.Tags.Add(tag);

                        posts.Add(p);
                    }
                    else
                    {
                        p.Tags.Add(tag);
                    }

                    return post;

                }, splitOn: "Id");


            return posts.AsEnumerable();
        }
        public void Update(PostModel model)
        {
            if (model.Id != 0)
            {
                model.LastUpdateDate = DateTime.UtcNow;
                Connection.Update(model);
            }
        }
        public IEnumerable<PostModel> GetAll()
            => Connection.GetAll<PostModel>().AsEnumerable();

        public PostModel Get(int id)
            => Connection.Get<PostModel>(id);

        public long Create(PostModel model)
            => Connection.Insert(model);


        public void Remove(PostModel model)
        {
            if (model.Id != 0)
            {
                Connection.Delete(model);
            }
        }

        public void Remove(int id)
            => Connection.Delete(Get(id));

        internal IEnumerable<PostModel> GetByCategory(int idCategory)
        {
            var query = "SELECT" +
                            "*" +
                        "FROM" +
                            "[Post]" +
                        "WHERE" +
                        "[Post].[CategoryId] = @idCategory";

            return Connection.Query<PostModel>(query, new{idCategory});
        }
    }
}
