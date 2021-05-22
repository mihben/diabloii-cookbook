using DiabloII_Cookbook.Api.Queries;
using DiabloII_Cookbook.Application.QueryHandlers;
using DiabloII_Cookbook.Application.Wireup;
using LightInject.Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Netension;
using Netension.Request.Hosting.LightInject.Builders;
using Netension.Request.NetCore.Asp.Middlewares;
using Serilog;
using Serilog.Sinks.Grafana.Loki;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

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

                        app.UseEndpoints(endpoints =>
                        {
                            endpoints.MapControllers();
                            endpoints.MapRequestReceiver("/api")
                                .RequireAuthorization("battle-tag");
                        });
                    });
                })
                .UseSerilog((context, configuration) =>
                {
                    configuration.ReadFrom.Configuration(context.Configuration);

                    configuration.WriteTo.GrafanaLoki("https://loki.mihben.work", labels: new List<LokiLabel>
                    {
                        new LokiLabel { Key = "application", Value = "DiabloII_Cookbook" },
                        new LokiLabel { Key = "environment", Value = "Development" },
                        new LokiLabel { Key = "timestamp", Value = DateTime.UtcNow.ToString() }
                    });
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

                        register.UseCorrelationLogger();
                    });

                    builder.RegistrateRequestSenders(register =>
                    {
                        register.RegistrateLoopbackSender(builder => builder.UseCorrelation(), request => true);
                    });
                })
                .ConfigureServices((context, services) =>
                {
                    services.AddMvc().AddControllersAsServices();

                    services.AddControllers()
                        .AddApplicationPart(typeof(Program).Assembly)
                        .AddRequestReceiverController();

                    services.AddDatabase();

                    services.AddCors();

                    services.AddAuthorization(options =>
                    {
                        options.AddPolicy("battle-tag", builder => builder.RequireClaim("battle_tag"));
                    });
                    services.AddAuthentication("blizzard")
                        .AddJwtBearer("blizzard", options => context.Configuration.GetSection("Authentication:Blizzard").Bind(options));
                });
    }
}
