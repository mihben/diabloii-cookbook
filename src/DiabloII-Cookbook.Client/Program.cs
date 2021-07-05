using Blazored.LocalStorage;
using Blazored.Modal;
using DiabloII_Cookbook.Client.Contexts;
using DiabloII_Cookbook.Client.Options;
using DiabloII_Cookbook.Client.Services;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Netension.Request.Blazor.Hosting.LightInject;
using Serilog;
using System;
using System.Text.Json;
using System.Threading.Tasks;

namespace DiabloII_Cookbook.Client
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = NetensionWebAssemblyHostBuilder.CreateDefaultHostBuilder<ApplicationWireup, App>(args);
            await builder.Build().RunAsync().ConfigureAwait(false);
        }
    }
}
