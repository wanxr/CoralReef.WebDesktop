using Chromely;
using Chromely.Browser;
using Chromely.Core;
using Chromely.Core.Configuration;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using System;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using Vue3_Vite.Helper;

namespace Vue3_Vite
{
    public class ChromelyHelper
    {
        public static void CreateHostBuilder(string[] args, bool showDesktopUI = false)
        {
            string[] appUrls = GetAppUrls();

            if (args != null)
            {
                int index = args.ToList().IndexOf("--urls");
                if (index != -1 && index + 1 < args.Length)
                {
                    appUrls = args[index + 1].Split(';');
                }
            }

            if (showDesktopUI)
            {
                var proctype = ClientAppUtils.GetProcessType(args);
                if (proctype == ProcessType.Browser)
                {
                    CreateWebHostBuilder(args).UseUrls(appUrls).Build().Start();
                }
                ChromelyBootstrap(args, appUrls.First());
            }
            else
            {
                CreateWebHostBuilder(args).UseUrls(appUrls).Build().Run();
            }
        }

        private static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args).UseStartup<Startup>();

        private static void ChromelyBootstrap(string[] args, string startUrl)
        {
            var config = DefaultConfiguration.CreateForRuntimePlatform();
            config.WindowOptions = new WindowOptions()
            {
                Title = "Window Title",
                //DisableResizing = true,
                //Size = new WindowSize(1000, 600)
            };
            config.StartUrl = startUrl;
            config.CefDownloadOptions = new CefDownloadOptions()
            {
                AutoDownloadWhenMissing = false,
                DownloadSilently = true
            };
            AppBuilder
                .Create()
                .UseConfig<DefaultConfiguration>(config)
                .UseApp<ChromelyBasicApp>()
                .Build()
                .Run(args);
        }

        private static string[] GetAppUrls()
        {
            IConfiguration configuration = ConfigurationHelper.GetConfiguration();
            var isRandomPort = configuration.GetSection("RandomPort").Get<bool>();
            string[] appUrls = null;
            if (isRandomPort)
            {
                appUrls = new[] { $"http://localhost:{FreeTcpPort()}" };
            }
            // Default urls to use
            // Check to see if the url to use has been specified in the launchSettings.json
            var envUrls = Environment.GetEnvironmentVariable("ASPNETCORE_URLS");
            if (envUrls != null)
            {
                appUrls = envUrls.Split(";");
            }
            var settingsUrls = configuration.GetSection("StartUrls").Get<string>();
            if (settingsUrls != null)
            {
                appUrls = settingsUrls.Split(";");
            }
            return appUrls;
        }

        private static int FreeTcpPort()
        {
            var listener = new TcpListener(IPAddress.Loopback, 0);
            listener.Start();
            try
            {
                return ((IPEndPoint)listener.LocalEndpoint).Port;
            }
            finally
            {
                listener.Stop();
            }
        }
    }
}