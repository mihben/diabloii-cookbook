using AutoFixture;
using DiabloII_Cookbook.Api.Commands;
using DiabloII_Cookbook.Application.DatabaseContexts;
using DiabloII_Cookbook.IntegrationTest.Extensions;
using DiabloII_Cookbook.IntegrationTest.Factories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Net;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace DiabloII_Cookbook.IntegrationTest
{
    public class Character_Test : IClassFixture<DiabloII_CookbookFactory>
    {
        private readonly DiabloII_CookbookFactory _factory;

        public Character_Test(DiabloII_CookbookFactory factory, ITestOutputHelper outputHelper)
        {
            factory.SetOutputHelper(outputHelper);
            _factory = factory;
        }

        [Fact(DisplayName = "[INT-CH001][401-Unathorized] - Create character without authentication")]
        public async Task Character_CreateCharacterWithoutAuthentication()
        {
            // Arrange
            var correlationId = Guid.NewGuid();
            var client = _factory.CreateClient();

            // Call /api/character POST endpoint without authentication
            var response = await client.PostAsync("/api/character", new Fixture().Build<CreateCharacterCommand>().Create(), correlationId);

            // Response with 401 - Unathorized
            Assert.Equal(HttpStatusCode.Unauthorized, response.StatusCode);
        }

        [Fact(DisplayName = "[INT-CH002][202-Accepted] - Create account if not exists")]
        public async Task Character_CreateAccount()
        {
            // Arrange
            var correlationId = Guid.NewGuid();

            var client = _factory.CreateClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("IntegrationTestScheme");

            // Call /api/character POST endpoint with not existing character
            var response = await client.PostAsync("/api/character", new Fixture().Build<CreateCharacterCommand>().Create(), correlationId);

            // Response with 202 - Accepted
            Assert.Equal(HttpStatusCode.Accepted, response.StatusCode);

            // Character is inserted to the database
            var context = _factory.Services.GetRequiredService<DatabaseContext>();
            var entity = await context.Accounts.FirstOrDefaultAsync(ae => ae.BattleTag == "integration_test", new CancellationTokenSource(TimeSpan.FromSeconds(5)).Token);

            Assert.NotNull(entity);
            Assert.NotEqual(Guid.Empty, entity.Id);
            Assert.Equal("integration_test", entity.BattleTag);
        }

        [Fact(DisplayName = "[INT-CH003][202-Accepted] - Create character")]
        public async Task Character_CreateCharacter()
        {
            // Arrange
            var correlationId = Guid.NewGuid();
            var command = new Fixture().Build<CreateCharacterCommand>().Create();
            var client = _factory.CreateClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("IntegrationTestScheme");

            // Call /api/character POST endpoint with not existing character
            var response = await client.PostAsync("/api/character", command, correlationId);

            // Response with 202 - Accepted
            Assert.Equal(HttpStatusCode.Accepted, response.StatusCode);

            // Character is inserted to the database
            var context = _factory.Services.GetRequiredService<DatabaseContext>();
            var entity = await context.Accounts
                                .Include(ae => ae.Characters)
                                .FirstOrDefaultAsync(ae => ae.BattleTag == "integration_test", new CancellationTokenSource(TimeSpan.FromSeconds(5)).Token);

            Assert.NotNull(entity);
            Assert.Contains(entity.Characters, ce => ce.Name == command.Name &&
                                                    ce.Level == command.Level &&
                                                    ce.IsExpansion == command.IsExpansion &&
                                                    ce.IsLadder == command.IsLadder &&
                                                    ce.Class == command.Class);
        }
    }
}
