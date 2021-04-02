using DiabloII_Cookbook.Api.Queries;
using DiabloII_Cookbook.Application.QueryHandlers;
using DiabloII_Cookbook.Application.Wireup;
using LightInject.Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
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
                .ConfigureServices((services) =>
                {
                    services.AddControllers()
                        .AddRequestReceiverController(); ;

                    services.AddDatabase();

                    services.AddCors();
                })
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.Configure((app) =>
                    {
                        app.UseCors((builder) =>
                        {
                            builder.AllowAnyOrigin();
                            builder.AllowAnyHeader();
                            builder.AllowAnyMethod();
                        });

                        app.UseRouting();

                        app.UseEndpoints(endpoints =>
                        {
                            endpoints.MapControllers();
                            endpoints.MapRequestReceiver("/api");
                        });
                    });
                });
    }
}
