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
using DiabloII_Cookbook.Client.Options;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System.Collections.Generic;

namespace DiabloII_Cookbook.Client
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);

            builder.Configuration
                .AddInMemoryCollection(new Dictionary<string, string> { ["Backend:BaseAddress"] = "http://localhost:5001/"})
                .AddEnvironmentVariables();
            builder.RootComponents.Add<App>("#app");

            builder.Services.AddSingleton<ILoadingScreenService, LoadingScreenService>();

            builder.Services.AddOptions<HttpClientOptions>()
                .Configure<IConfiguration>((options, configuration) => configuration.GetSection("Backend").Bind(options))
                .ValidateDataAnnotations();

            builder.Services.AddScoped<ICharacterService>((provider) =>
                {
                    if (provider.GetRequiredService<IAuthorizationContext>().IsAuthorized) return provider.GetRequiredService<HttpCharacterService>();
                    else return provider.GetRequiredService<LocalCharacterService>();
                });
            builder.Services.AddScoped<LocalCharacterService>();
            builder.Services.AddHttpClient<HttpCharacterService>((provider, client) =>
            {
                Console.WriteLine(JsonSerializer.Serialize(provider.GetService<IConfiguration>()));
                var options = provider.GetRequiredService<IOptions<HttpClientOptions>>().Value;
                client.BaseAddress = new Uri(options.BaseAddress);
            });
            builder.Services.AddHttpClient<IFilterService, FilterService>((provider, client) =>
            {
                Console.WriteLine(JsonSerializer.Serialize(provider.GetService<IConfiguration>()));
                var options = provider.GetRequiredService<IOptions<HttpClientOptions>>().Value;
                client.BaseAddress = new Uri(options.BaseAddress);
            });
            builder.Services.AddHttpClient<IRuneService, RuneService>((provider, client) =>
            {
                Console.WriteLine(JsonSerializer.Serialize(provider.GetService<IConfiguration>()));
                var options = provider.GetRequiredService<IOptions<HttpClientOptions>>().Value;
                client.BaseAddress = new Uri(options.BaseAddress);
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
