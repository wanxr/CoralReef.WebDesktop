using Microsoft.Extensions.Configuration;

namespace CoralReef.WebEnd
{
    public class Program
    {
        public static void Main(string[] args)
        {
            IConfiguration configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
            var isShowDesktopUI = configuration.GetSection("ShowDesktopUI").Get<bool>();
            ChromelyHelper.CreateHostBuilder(args, isShowDesktopUI);
        }
    }
}