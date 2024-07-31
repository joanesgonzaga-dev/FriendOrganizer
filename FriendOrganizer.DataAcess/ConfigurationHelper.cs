using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FriendOrganizer.DataAcess
{
    public class ConfigurationHelper
    {
        public IConfigurationRoot Configuration { get; }

        public ConfigurationHelper()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

            Configuration = builder.Build();
        }

        public string? GetConnectionString(string name)
        {
            return Configuration.GetConnectionString(name);
        }
    }
}
