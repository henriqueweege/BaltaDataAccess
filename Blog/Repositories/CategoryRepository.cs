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
    public class CategoryRepository :BaseRepository<CategoryModel>
    {

        public SqlConnection Connection { get; set; }
        public CategoryRepository(SqlConnection connection) : base(connection) 
        { 
            Connection = connection;
        }
    
        public IEnumerable<CategoryModel> GetAllWithPosts()
        {
            var query = "SELECT" +
                            "[Category].*," +
                            "[Post].*" +
                        "FROM" +
                            "[Category]" +
                        "LEFT JOIN [Post] ON [Category].[Id] = [Post].[CategoryId]";
            
            var categories = new List<CategoryModel>();

            var items = Connection.Query<CategoryModel, PostModel, CategoryModel>(
                query,
                (category, post) =>
                {
                    var ctg = categories.FirstOrDefault(x => x.Id == category.Id);

                    if (ctg is null)
                    {
                        ctg = category;

                        if (post is not null)
                            ctg.Posts.Add(post);

                        categories.Add(ctg);
                    }
                    else
                    {
                        ctg.Posts.Add(post);
                    }

                    return category;

                }, splitOn: "Id");


            return categories;
        }
    }
}
