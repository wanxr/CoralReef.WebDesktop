using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoralReef.WebEnd
{
    public class Program
    {
        public static void Main(string[] args)
        {
            ChromelyHelper.CreateHostBuilder(args);
        }
    }
}
