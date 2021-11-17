using Microsoft.Extensions.Configuration;
using Vue3_Vite.Helper;

namespace Vue3_Vite
{
    public class Program
    {
        public static void Main(string[] args)
        {
            IConfiguration configuration = ConfigurationHelper.GetConfiguration();
            var isShowDesktopUI = configuration.GetSection("ShowDesktopUI").Get<bool>();
            var isDeployAsWebapi = configuration.GetSection("DeployAsWebApi").Get<bool>();
            if (isDeployAsWebapi)
            {
                isShowDesktopUI = false;
            }
            ChromelyHelper.CreateHostBuilder(args, isShowDesktopUI);
        }
    }
}