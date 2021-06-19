using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using Blazored.Modal;
using DiabloII_Cookbook.Client.Services;
using Blazored.LocalStorage;
using System.Text.Json;
using DiabloII_Cookbook.Client.Contexts;

namespace DiabloII_Cookbook.Client
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");

            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("http://localhost:5001/") });

            builder.Services.AddSingleton<ILoadingScreenService, LoadingScreenService>();

            builder.Services.AddScoped<IRuneService, RuneService>();
            builder.Services.AddScoped<IFilterService, FilterService>();
            builder.Services.AddScoped<HttpCharacterService>();
            builder.Services.AddScoped<LocalCharacterService>();
            builder.Services.AddScoped<ICharacterService>((provider) =>
            {
                if (provider.GetRequiredService<IAuthorizationContext>().IsAuthorized) return provider.GetRequiredService<HttpCharacterService>();
                else return provider.GetRequiredService<LocalCharacterService>();
            });
            builder.Services.AddScoped<IAuthorizationContext, AuthorizationContext>();

            builder.Services.AddBlazoredModal();
            builder.Services.AddBlazoredLocalStorage(options =>
            {
                options.JsonSerializerOptions.ReadCommentHandling = JsonCommentHandling.Skip;
                options.JsonSerializerOptions.WriteIndented = false;
                options.JsonSerializerOptions.PropertyNameCaseInsensitive = true;
            });

            await builder.Build().RunAsync();
        }
    }
}
