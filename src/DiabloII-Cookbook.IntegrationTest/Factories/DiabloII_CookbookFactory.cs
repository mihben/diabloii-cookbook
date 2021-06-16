using DiabloII_Cookbook.Application.DatabaseContexts;
using DiabloII_Cookbook.IntegrationTest.Mocks;
using DiabloII_Cookbook.Web;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Serilog;
using System.Linq;
using Xunit.Abstractions;

namespace DiabloII_Cookbook.IntegrationTest.Factories
{
    public class DiabloII_CookbookFactory : WebApplicationFactory<Program>
    {
        private ITestOutputHelper _outputHelper;
        private SqliteConnection _connection;

        public void SetOutputHelper(ITestOutputHelper outputHelper)
        {
            _outputHelper = outputHelper;
        }

        public void Reset()
        {
            _connection.Close();
            _connection.Open();
        }

        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {

            builder.ConfigureTestServices(services =>
            {
                services.AddMvc().AddApplicationPart(typeof(Program).Assembly);
                services.Remove(services.SingleOrDefault(sd => sd.ServiceType == typeof(DbContextOptions<DatabaseContext>)));

                _connection = new SqliteConnection("DataSource=:memory:");
                _connection.Open();
                services.AddDbContext<DatabaseContext>(options => options.UseSqlite(_connection));

                services.AddAuthentication("IntegrationTestScheme")
                    .AddScheme<MockAuthenticationSchemeOptions, TestAuthenticationHandler>("IntegrationTestScheme", options => options.BattleTag = "integration_test");
            })
            .UseSerilog((context, configuration) => configuration.WriteTo.TestOutput(_outputHelper).MinimumLevel.Debug());

            base.ConfigureWebHost(builder);
        }
    }
}
