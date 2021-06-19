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
using Serilog;
using Serilog.Sinks.Grafana.Loki;
using Serilog.Sinks.Grafana.Loki.HttpClients;
using System;
using System.Text.Json;
using System.Threading.Tasks;

namespace DiabloII_Cookbook.Client
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);

            builder.RootComponents.Add<App>("#app");

            builder.Configuration.AddEnvironmentVariables();

            builder.Logging
                .ClearProviders()
                .AddSerilog(new LoggerConfiguration()
                            .ReadFrom.Configuration(builder.Configuration.Build())
                            .CreateLogger());

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
