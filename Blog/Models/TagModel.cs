using Blog.Models.Base;
using Dapper.Contrib.Extensions;


namespace Blog.Models
{
    [Table("[Tag]")]
    public class TagModel: BaseModel
    {
        public TagModel()
            => Posts = new List<PostModel>();

        [Write(false)]
        public List<PostModel> Posts { get; set; }
    }
}
