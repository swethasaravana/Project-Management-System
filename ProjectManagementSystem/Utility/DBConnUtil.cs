using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace ProjectManagementSystem.Utility
{
    internal static class DBConnUtil
    {
        private static IConfiguration _iconfiguration;

        static DBConnUtil()
        {
            GetAppSettingsFile();
        }

        private static void GetAppSettingsFile()
        {
            var builder = new ConfigurationBuilder()
                        .SetBasePath(Directory.GetCurrentDirectory())
                        .AddJsonFile("appsettings.json");
            _iconfiguration = builder.Build();
        }

        public static string GetConnectionString()
        {
            return _iconfiguration.GetConnectionString("LocalConnectionString");
        }

        internal static SqlConnection GetConnection()
        {
            string connectionString = GetConnectionString();
            return new SqlConnection(connectionString);

        }
    }
}

