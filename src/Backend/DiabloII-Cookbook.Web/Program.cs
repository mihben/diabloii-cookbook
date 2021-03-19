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
                .ConfigureServices((services) =>
                {
                    services.AddControllers();
                })
                .UseRequesting((builder) =>
                {
                    builder.RegistrateCorrelation();

                    builder.RegistrateRequestReceivers((builder) =>
                    {
                        builder.RegistrateLoopbackRequestReceiver((builder) => builder.UseCorrelation());
                        builder.RegistrateHttpRequestReceiver((builder) => builder.UseCorrelation());
                    });
                })
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.Configure((app) =>
                    {
                        app.UseRouting();

                        app.UseEndpoints(endpoints =>
                        {
                            endpoints.MapRequestReceiver();
                        });
                    });
                });
    }
}
