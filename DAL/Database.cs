using System.Configuration;
using System;
namespace DAL
{
    public class Database
    {
        
#if (DEBUG)
        // Use local DB for testing purposes
        public static string GetConnectionString()
        {
            return System.Configuration.ConfigurationManager.ConnectionStrings["RemoteConnection"].ConnectionString;
        }
#elif (RELEASE)
        // Use remote DB for release builds
            
        public static string GetConnectionString()
        {
            return System.Configuration.ConfigurationManager.ConnectionStrings["RemoteConnection"].ConnectionString;
        }
#endif
    }
}
