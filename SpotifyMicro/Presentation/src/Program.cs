using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace Presentation
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var con = new ConfigurationBuilder().AddEnvironmentVariables().Build();
            var hostUrl = string.Empty;
            if (con["ASPNETCORE_ENVIRONMENT"] == "Development")
            {
                hostUrl = "https://localhost:5112;http://localhost:5111";
                Console.WriteLine(con["ASPNETCORE_ENVIRONMENT"]);
            }
            else
            {
                hostUrl = "https://0.0.0.0:5112;http://0.0.0.0:5111";
                Console.WriteLine(con["ASPNETCORE_ENVIRONMENT"]);
            }
            CreateWebHostBuilder(args).UseUrls(hostUrl).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}
