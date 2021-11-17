using Microsoft.Extensions.Configuration;

namespace Vue3_Vite.Helper
{
    public class ConfigurationHelper
    {
        private static readonly IConfiguration _configuration;

        static ConfigurationHelper()
        {
            _configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
        }

        public static IConfiguration GetConfiguration()
        {
            return _configuration;
        }
    }
}