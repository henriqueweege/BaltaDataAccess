using Blog.Models.Base;
using Dapper.Contrib.Extensions;

namespace Blog.Models
{
    [Table("[UserRole]")]
    public class UserRoleModel
    {
        public int Id { get; set; }
        public long UserId { get; set; }
        public int RoleId { get; set; }
    }
}
