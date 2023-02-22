using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Infrastructure
{
    public static class AppSettingsReader
    {

        public static string GetConnectionString()
        {
            IConfiguration config = new ConfigurationBuilder()
                                        .AddJsonFile("appsettings.json")
                                        .AddEnvironmentVariables()
                                        .Build();


            return config.GetRequiredSection("ConnectionString").Value;
        }
    }
}
