using AutoFixture;
using DiabloII_Cookbook.Api.Commands;
using DiabloII_Cookbook.IntegrationTest.Extensions;
using DiabloII_Cookbook.IntegrationTest.Factories;
using Microsoft.AspNetCore.Http;
using System;
using System.Net;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;
using Microsoft.Extensions.DependencyInjection;
using DiabloII_Cookbook.Application.DatabaseContexts;
using System.Net.Http.Headers;
using DiabloII_Cookbook.Application.Entities;
using System.Xml.Linq;
using System.Threading;
using DiabloII_Cookbook.IntegrationTest.Builders;
using Microsoft.EntityFrameworkCore;

namespace DiabloII_Cookbook.IntegrationTest
{
    public class Filter_Test : IClassFixture<DiabloII_CookbookFactory>
    {
        private readonly DiabloII_CookbookFactory _factory;

        public Filter_Test(DiabloII_CookbookFactory factory, ITestOutputHelper outputHelper)
        {
            factory.SetOutputHelper(outputHelper);
            _factory = factory;
        }

        [Fact(DisplayName = "[INT-STF001][401-Unathorized]: Save filters without authorization")]
        [Trait("Feature", "STF - Store filters")]
        public async Task SaveFilterWithoutAuthorization()
        {
            // Arrange
            var correlationId = Guid.NewGuid();
            var client = _factory.CreateClient();

            // Act
            var response = await client.PostAsync("/api/filter", new Fixture().Create<AddItemTypeFilterCommand>(), correlationId, TimeSpan.FromSeconds(5));

            // Assert
            Assert.Equal(HttpStatusCode.Unauthorized, response.StatusCode);
        }

        [Fact(DisplayName = "[INT-STF002][202-Accepted]: Save item type filter")]
        [Trait("Feature", "STF - Store filters")]
        public async Task SaveItemTypeFilter()
        {
            // Arrange
            var correlationId = Guid.NewGuid();
            var client = _factory.CreateClient();
            var command = new Fixture().Create<AddItemTypeFilterCommand>();
            var existingCharacter = new Fixture().CreateCharacterEntity(id: command.CharacterId);

            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("IntegrationTestScheme");

            var context = _factory.Services.GetService<DatabaseContext>();
            await context.Database.EnsureCreatedAsync(new CancellationTokenSource(TimeSpan.FromSeconds(5)).Token);
            await context.AddAsync(existingCharacter, new CancellationTokenSource(TimeSpan.FromSeconds(5)).Token);
            await context.AddAsync(new Fixture().CreateItemTypeEntity(command.ItemTypeId), new CancellationTokenSource(TimeSpan.FromSeconds(5)).Token);
            await context.SaveChangesAsync(new CancellationTokenSource(TimeSpan.FromSeconds(5)).Token);

            // Act
            var response = await client.PostAsync("/api/filter", command, correlationId, TimeSpan.FromSeconds(5));

            // Assert
            Assert.Equal(HttpStatusCode.Accepted, response.StatusCode);

            context.ChangeTracker.Clear();
            var entity = await context.Characters.Include(c => c.Filters).FirstAsync(c => c.Id.Equals(existingCharacter.Id), new CancellationTokenSource(TimeSpan.FromSeconds(5)).Token);
            Assert.Collection(entity.Filters, f => f.ItemTypeId.Equals(command.ItemTypeId));
        }
    }
}
