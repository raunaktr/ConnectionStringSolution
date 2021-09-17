using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConnectionStringAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();

        }

        public static IHostBuilder CreateHostBuilder(string[] args)
        {
            return Host.CreateDefaultBuilder(args)
.ConfigureWebHostDefaults(webBuilder =>
webBuilder.ConfigureAppConfiguration(config =>
{
    var settings = config.Build();
    config.AddAzureAppConfiguration(options =>
    options.Connect("Endpoint=https://myfirstappconfigurationraunaktr.azconfig.io;Id=1whz-lh-s0:/nZaiIxfW6T8tWZwGUp2;Secret=/tLAc0gsmysQ7tCEDTH/ZcvxS7x8Noi9vOOqeQjQ3P8="));



}).UseStartup<Startup>());
        }
    }
}
