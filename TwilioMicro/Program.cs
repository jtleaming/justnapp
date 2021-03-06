﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace TwilioMicro
{
    public class Program
    {
        public static void Main(string[] args)
        {
            BuildWebHost(args).Run();
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseKestrel()
                .ConfigureAppConfiguration((context, builder) =>
                {
                    builder.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
                    builder.AddJsonFile($"appsettings.{context.HostingEnvironment}.json", optional: true);
                }
                )
                .ConfigureLogging((builderContext, loggingBuidler) =>
                {
                    loggingBuidler.AddConfiguration(builderContext.Configuration.GetSection("Logging"));
                    loggingBuidler.AddConsole();
                    loggingBuidler.AddDebug();
                })
                .UseStartup<Startup>()
                .UseUrls("http://localhost:5002")
                .Build();
    }
}
