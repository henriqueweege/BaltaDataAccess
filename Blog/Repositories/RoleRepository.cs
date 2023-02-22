using Blog.Models;
using Blog.Repositories.Base;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Repositories
{
    public class RoleRepository : BaseRepository<RoleModel>
    {
        public RoleRepository(SqlConnection connection) : base(connection) { }
    }
}
