using System.Configuration;
using System;
namespace DAL
{
    public class Database
    {
        public static string GetConnectionString()
        {
            return System.Configuration.ConfigurationManager.ConnectionStrings["RemoteConnection"].ConnectionString;
        }
    }
}
