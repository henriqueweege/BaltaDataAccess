using Blog.Models.Base;
using Dapper.Contrib.Extensions;

namespace Blog.Models
{
    [Table("[Category]")]
    public class CategoryModel:BaseModel
    {
        public CategoryModel()
            => Posts = new List<PostModel>();

        [Write(false)]
        public List<PostModel> Posts { get; set; }
    }
}
