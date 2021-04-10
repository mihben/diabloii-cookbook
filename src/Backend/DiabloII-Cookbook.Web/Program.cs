using DiabloII_Cookbook.Api.Queries;
using DiabloII_Cookbook.Application.QueryHandlers;
using DiabloII_Cookbook.Application.Wireup;
using DiabloII_Cookbook.Web.Middlewares;
using LightInject.Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Logging;
using Netension;
using Netension.Request.Hosting.LightInject.Builders;
using Serilog;

namespace DiabloII_Cookbook.Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .UseLightInject()
                .UseSerilog((context, configuration) =>
                {
                    configuration.ReadFrom.Configuration(context.Configuration);
                })
                .UseRequesting((builder) =>
                {
                    builder.RegistrateHandlers<GetRunesQueryHandler>();
                    builder.RegistrateValidators<GetRunesQuery>();

                    builder.RegistrateCorrelation();

                    builder.RegistrateRequestReceivers((register) =>
                    {
                        register.RegistrateLoopbackRequestReceiver((builder) => builder.UseCorrelation());
                        register.RegistrateHttpRequestReceiver((builder) => builder.UseCorrelation());
                    });
                })
                .ConfigureServices((context, services) =>
                {
                    services.AddControllers()
                        .AddRequestReceiverController();

                    services.AddDatabase();

                    services.AddCors();

                    IdentityModelEventSource.ShowPII = true;

                    services.AddAuthorization(options =>
                    {
                        options.AddPolicy("battle-tag", builder => builder.RequireClaim("battle_tag"));
                    });
                    services.AddAuthentication("blizzard")
                        .AddJwtBearer("blizzard", options => context.Configuration.GetSection("Authentication:Blizzard").Bind(options));
                })
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.Configure((app) =>
                    {
                        app.UseErrorHandling();

                        app.UseCors((builder) =>
                        {
                            builder.AllowAnyOrigin();
                            builder.AllowAnyHeader();
                            builder.AllowAnyMethod();
                        });

                        app.UseRouting();

                        app.UseAuthentication();
                        app.UseAuthorization();

                        app.UseMiddleware<AccountContextMiddleware>();

                        app.UseEndpoints(endpoints =>
                        {
                            endpoints.MapControllers();
                            endpoints.MapRequestReceiver("/api")
                                .RequireAuthorization("battle-tag");
                        });
                    });
                });
    }
}
