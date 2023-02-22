using Blog.Models.Base;
using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Models
{
    [Table("[User]")]
    public class UserModel: BaseModel
    {

        public UserModel()
            => Roles = new List<RoleModel>();
        
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public string Bio { get; set; }
        public string Image { get; set; }

        [Write(false)]
        public List<RoleModel> Roles { get; set; }
    }
}
