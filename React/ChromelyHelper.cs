using Chromely;
using Chromely.Browser;
using Chromely.Core;
using Chromely.Core.Configuration;
using Chromely.Core.Host;
using Chromely.NativeHost;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;

namespace CoralReef.WebEnd
{
    public class ChromelyHelper
    {

        public static void CreateHostBuilder(string[] args)
        {
            var appUrls = GetAppUrl();
            string isChromely = Environment.GetEnvironmentVariable("ASPNETCORE_CHROMELY");
            isChromely = "true";
            if (isChromely != "false")
            {
                var proctype = ClientAppUtils.GetProcessType(args);
                if (proctype == ProcessType.Browser)
                {
                    CreateWebHostBuilder(args).UseUrls(appUrls).Build().Start();
                }
                ChromelyBootstrap(args, appUrls);
                //NativeHostBase.NativeInstance.SetWindowState(WindowState.Maximize);
            }
            else
            {
                CreateWebHostBuilder(args).UseUrls(appUrls).Build().Run();
            }
        }

        private static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args).UseStartup<Startup>();

        private static void ChromelyBootstrap(string[] args, string[] appUrls)
        {
            var config = DefaultConfiguration.CreateForRuntimePlatform();
            config.WindowOptions.Title = "Title Window";
            config.StartUrl = appUrls.First();
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

        private static string[] GetAppUrl()
        {
            // Default urls to use
            var appUrls = new[] { $"http://localhost:{FreeTcpPort()}" };
            // Check to see if the url to use has been specified in the launchSettings.json
            var envUrls = Environment.GetEnvironmentVariable("ASPNETCORE_URLS");
            if (envUrls != null)
            {
                appUrls = envUrls.Split(";");
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
