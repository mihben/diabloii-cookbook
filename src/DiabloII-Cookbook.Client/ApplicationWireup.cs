using Blazored.LocalStorage;
using Blazored.Modal;
using DiabloII_Cookbook.Client.Contexts;
using DiabloII_Cookbook.Client.Services;
using LightInject;
using Microsoft.Extensions.DependencyInjection;
using Netension.Request.Blazor.Hosting.LightInject;
using Netension.Request.Blazor.Hosting.LightInject.Contexts;
using System.Text.Json;

namespace DiabloII_Cookbook.Client
{
    public class ApplicationWireup : Wireup
    {
        protected override void ConfigureContainer(HostContext context, IServiceRegistry registry)
        {
            registry.RegisterSingleton<ILoadingScreenService, LoadingScreenService>();

            registry.RegisterScoped<LocalCharacterService>();
            registry.RegisterScoped<HttpCharacterService>();
            registry.RegisterScoped<ICharacterService>(factory =>
            {
                if (factory.GetInstance<IAuthorizationContext>().IsAuthorized) return factory.GetInstance<HttpCharacterService>();
                else return factory.GetInstance<LocalCharacterService>();
            });

            registry.RegisterScoped<IFilterService, FilterService>();
            registry.RegisterScoped<IRuneService, RuneService>();

            registry.RegisterScoped<IAuthorizationContext, AuthorizationContext>();
        }

        protected override void ConfigureServices(HostContext context, IServiceCollection services)
        {
            services.AddSingleton<ILoadingScreenService, LoadingScreenService>();

            services.AddBlazoredModal();
            services.AddBlazoredLocalStorage(options =>
            {
                options.JsonSerializerOptions.ReadCommentHandling = JsonCommentHandling.Skip;
                options.JsonSerializerOptions.WriteIndented = false;
                options.JsonSerializerOptions.PropertyNameCaseInsensitive = true;
            });
        }
    }
}
