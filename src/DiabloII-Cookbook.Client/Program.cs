using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using Blazored.Modal;
using DiabloII_Cookbook.Client.Services;

namespace DiabloII_Cookbook.Client
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");

            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("http://localhost:5001/") });

            builder.Services.AddScoped<IRuneService, RuneService>();
            builder.Services.AddScoped<IFilterService, FilterService>();
            builder.Services.AddScoped<ICharacterService, CharacterService>();

            builder.Services.AddBlazoredModal();

            await builder.Build().RunAsync();
        }
    }
}
