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
    public class TagRepository : BaseRepository<TagModel>
    {
        public SqlConnection Connection { get; set; }
        public TagRepository(SqlConnection connection) : base(connection) 
        {
            Connection = connection;
        }

        public IEnumerable<TagModel> GetAllWithPosts()
        {
            var query = "SELECT " +
                            "[Tag].*, " +
                            "[Post].* " +
                        "FROM " +
                            "[Tag] " +
                        "LEFT JOIN [PostTag] ON [PostTag].[TagId] = [Tag].[Id] " +
                        "LEFT JOIN [Post] ON [PostTag].[PostId] = [Post].[Id]";

            var tags = new List<TagModel>();

            var items = Connection.Query<TagModel, PostModel, TagModel>(
                query,
                (tag, post) =>
                {
                    var t = tags.FirstOrDefault(x => x.Id == tag.Id);

                    if (t is null)
                    {
                        t = tag;

                        if (post is not null)
                            t.Posts.Add(post);

                        tags.Add(t);
                    }
                    else
                    {
                        t.Posts.Add(post);
                    }

                    return tag;

                }, splitOn: "Id");


            return tags.AsEnumerable();
        }

    }
}
