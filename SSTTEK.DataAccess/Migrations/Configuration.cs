using Microsoft.Extensions.Configuration;
using System;

namespace SSTTEK.DataAccess.Migrations
{
    public static class Configuration
    {
        public static string ConnectionString(string connectionString)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
            .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
            .AddJsonFile("appsettings.json")
            .Build();

            return configuration.GetConnectionString(connectionString);
        }
    }
}
