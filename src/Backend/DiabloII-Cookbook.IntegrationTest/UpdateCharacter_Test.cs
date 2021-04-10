using AutoFixture;
using DiabloII_Cookbook.IntegrationTest.Factories;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System;
using Xunit;
using DiabloII_Cookbook.Api.DataTransferObjects;
using DiabloII_Cookbook.IntegrationTest.Extensions;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Threading;
using Netension.Request.NetCore.Asp.ValueObjects;
using Xunit.Abstractions;
using DiabloII_Cookbook.Application.Entities;
using System.Xml.Linq;
using DiabloII_Cookbook.Application.DatabaseContexts;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using DiabloII_Cookbook.Application.Mappers;
using System.Collections.Generic;

namespace DiabloII_Cookbook.IntegrationTest
{
    public class UpdateCharacter_Test : IClassFixture<DiabloII_CookbookFactory>
    {
        private readonly DiabloII_CookbookFactory _factory;

        public UpdateCharacter_Test(DiabloII_CookbookFactory factory, ITestOutputHelper outputHelper)
        {
            factory.SetOutputHelper(outputHelper);
            _factory = factory;
        }

        [Fact(DisplayName = "[INT-UC001][401-Unathorized] - Update character without authentication")]
        [Trait("Feature", "UC - Update character")]
        public async Task UpdateCharacterWithoutAuthentication()
        {
            // Arrange
            var correlationId = Guid.NewGuid();
            var client = _factory.CreateClient();
            var fixture = new Fixture();
            var content = new
            {
                Level = fixture.Create<int>(),
                IsExpansion = fixture.Create<bool>(),
                IsLadder = fixture.Create<bool>(),
                Runes = Enumerable.Empty<Rune>()
            };

            // Call /api/character/{id} PUT endpoint without authentication
            var response = await client.PutAsync($"/api/character/{fixture.Create<Guid>()}", content, correlationId, TimeSpan.FromSeconds(5));

            // Response with 403 - Unathorized
            Assert.Equal(HttpStatusCode.Unauthorized, response.StatusCode);
        }

        [Fact(DisplayName = "[INT-UC002][400-BadRequest] - Update not existed character")]
        [Trait("Feature", "UC - Update character")]
        public async Task UpdateNotExistedCharacter()
        {
            // Arrange
            var correlationId = Guid.NewGuid();
            var client = _factory.CreateClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("IntegrationTest");

            var content = new
            {
                Level = new Random().Next(1, 99),
                Runes = Enumerable.Empty<Rune>()
            };

            // Call /api/character/<Id> PUT endpoint
            var response = await client.PutAsync($"/api/character/{Guid.NewGuid()}", content, correlationId, TimeSpan.FromSeconds(5));

            // Response with 400 - Bad Request
            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);

            var error = await response.Content.ReadFromJsonAsync<Error>(cancellationToken: new CancellationTokenSource(TimeSpan.FromSeconds(5)).Token);

            // Error code - 204
            Assert.Equal(204, error.Code);

            // Error code - Character not exists
            Assert.Equal("Character does not exist", error.Message);
        }

        [Fact(DisplayName = "[INT-UC003][400-BadRequest] - Update other account's character")]
        [Trait("Feature", "UC - Update character")]
        public async Task UpdateOtherAccountsCharacter()
        {
            // Arrange
            var correlationId = Guid.NewGuid();
            var name = new Fixture().Create<string>();
            var id = Guid.NewGuid();
            var existingCharacter = new Fixture().Build<CharacterEntity>()
                                                    .With(ce => ce.Id, id)
                                                    .Without(ce => ce.Runes)
                                                    .With(ce => ce.Name, name)
                                                    .With(ce => ce.Account, new AccountEntity { Id = Guid.NewGuid(), BattleTag = "TestAccount" })
                                                .Create();

            var context = _factory.Services.GetRequiredService<DatabaseContext>();
            await context.Database.EnsureCreatedAsync(new CancellationTokenSource(TimeSpan.FromSeconds(5)).Token);
            await context.AddAsync(existingCharacter, new CancellationTokenSource(TimeSpan.FromSeconds(5)).Token);
            await context.SaveChangesAsync(new CancellationTokenSource(TimeSpan.FromSeconds(5)).Token);

            var client = _factory.CreateClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("IntegrationTest");

            var content = new
            {
                Level = new Random().Next(1, 99),
                Runes = Enumerable.Empty<Rune>()
            };

            // Call /api/character/<Id> PUT endpoint
            var response = await client.PutAsync($"/api/character/{id}", content, correlationId, TimeSpan.FromSeconds(5));

            // Response with 400 - Bad Request
            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);

            var error = await response.Content.ReadFromJsonAsync<Error>(cancellationToken: new CancellationTokenSource(TimeSpan.FromSeconds(5)).Token);

            // Error code - 204
            Assert.Equal(204, error.Code);

            // Error code - Character not exists
            Assert.Equal("Character does not exist", error.Message);
        }

        [Fact(DisplayName = "[INT-UC004][202-Accepted] - Update character level")]
        [Trait("Feature", "UC - Update character")]
        public async Task UpdateCharacterLevel()
        {
            // Arrange
            var correlationId = Guid.NewGuid();
            var name = new Fixture().Create<string>();
            var id = Guid.NewGuid();
            var existingCharacter = new Fixture().Build<CharacterEntity>()
                                                    .With(ce => ce.Id, id)
                                                    .With(ce => ce.Level, 1)
                                                    .Without(ce => ce.Runes)
                                                    .With(ce => ce.Name, name)
                                                    .With(ce => ce.Account, new AccountEntity { Id = Guid.NewGuid(), BattleTag = "integration_test" })
                                                .Create();

            var context = _factory.Services.GetRequiredService<DatabaseContext>();
            await context.Database.EnsureCreatedAsync(new CancellationTokenSource(TimeSpan.FromSeconds(5)).Token);
            await context.AddAsync(existingCharacter, new CancellationTokenSource(TimeSpan.FromSeconds(5)).Token);
            await context.SaveChangesAsync(new CancellationTokenSource(TimeSpan.FromSeconds(5)).Token);

            var client = _factory.CreateClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("IntegrationTest");

            var content = new
            {
                Level = 2,
                Runes = Enumerable.Empty<Rune>()
            };

            // Call /api/character/<Id> PUT endpoint
            var response = await client.PutAsync($"/api/character/{id}", content, correlationId, TimeSpan.FromSeconds(5));

            // Response with 202 - Accepted
            Assert.Equal(HttpStatusCode.Accepted, response.StatusCode);

            context.ChangeTracker.Clear();
            var entity = await context.Characters.FindAsync(id);

            // Level update to 2
            Assert.Equal(2, entity.Level);
        }

        [Fact(DisplayName = "[INT-UC005][202-Accepted] - Update character runes")]
        [Trait("Feature", "UC - Update character")]
        public async Task UpdateCharacterRunes()
        {
            // Arrange
            var correlationId = Guid.NewGuid();
            var name = new Fixture().Create<string>();
            var runeEntity = new Fixture().Build<RuneEntity>().Without(re => re.Characters).Without(re => re.RuneWords).Create();
            var id = Guid.NewGuid();
            var existingCharacter = new Fixture().Build<CharacterEntity>()
                                                    .With(ce => ce.Id, id)
                                                    .With(ce => ce.Level, 1)
                                                    .Without(ce => ce.Runes)
                                                    .With(ce => ce.Name, name)
                                                    .With(ce => ce.Account, new AccountEntity { Id = Guid.NewGuid(), BattleTag = "integration_test" })
                                                .Create();

            var context = _factory.Services.GetRequiredService<DatabaseContext>();
            await context.Database.EnsureCreatedAsync(new CancellationTokenSource(TimeSpan.FromSeconds(5)).Token);
            await context.Characters.AddAsync(existingCharacter, new CancellationTokenSource(TimeSpan.FromSeconds(5)).Token);
            await context.Runes.AddAsync(runeEntity, new CancellationTokenSource(TimeSpan.FromSeconds(5)).Token);
            await context.SaveChangesAsync(new CancellationTokenSource(TimeSpan.FromSeconds(5)).Token);

            var client = _factory.CreateClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("IntegrationTest");

            var content = new
            {
                Level = 1,
                Runes = new List<Rune> { runeEntity.ToDto() }
            };

            // Call /api/character/<Id> PUT endpoint
            var response = await client.PutAsync($"/api/character/{id}", content, correlationId, TimeSpan.FromSeconds(5));

            // Response with 202 - Accepted
            Assert.Equal(HttpStatusCode.Accepted, response.StatusCode);

            context.ChangeTracker.Clear();
            var entity = await context.Characters.Include(ce => ce.Runes).ThenInclude(cre => cre.Rune).FirstAsync(ce => ce.Id == id);

            // Level update to 2
            Assert.Collection(entity.Runes, r => Assert.Equal(runeEntity.Id, r.Rune.Id));
        }
    }
}
