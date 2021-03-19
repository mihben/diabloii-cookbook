using DiabloII_Cookbook.Application.Options;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace DiabloII_Cookbook.Application.Wireup
{
    public static class DatabaseWireup
    {
        public static void AddDatabase(this IServiceCollection services)
        {
            services.AddOptions<DatabaseOptions>()
                .Configure<IConfiguration>((options, configuration) => configuration.GetSection("Database").Bind(options))
                .ValidateDataAnnotations();

            services.AddDbContext<DatabaseContext>((provider, builder) =>
            {
                var options = provider.GetRequiredService<IOptions<DatabaseOptions>>().Value;
                builder.UseNpgsql($"Server={options.Host}; Port={options.Port}; Database={options.Database}; User Id={options.UserName}; Password={options.Password}");
            });

        }
    }
}
