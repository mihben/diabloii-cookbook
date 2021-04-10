﻿using AutoFixture;
using DiabloII_Cookbook.Api.Commands;
using DiabloII_Cookbook.Application.DatabaseContexts;
using DiabloII_Cookbook.Application.Entities;
using DiabloII_Cookbook.IntegrationTest.Builders;
using DiabloII_Cookbook.IntegrationTest.Extensions;
using DiabloII_Cookbook.IntegrationTest.Factories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Netension.Request.NetCore.Asp.ValueObjects;
using System;
using System.Linq;
using System.Net;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
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

        [Fact(DisplayName = "[INT-CC001][401-Unathorized] - Create character without authentication")]
        [Trait("Feature", "CC - Create character")]
        public async Task CreateCharacterWithoutAuthentication()
        {
            // Arrange
            var correlationId = Guid.NewGuid();
            var client = _factory.CreateClient();

            // Call /api/character POST endpoint without authentication
            var response = await client.PostAsync("/api/character", new Fixture().Build<CreateCharacterCommand>().Create(), correlationId, TimeSpan.FromSeconds(5));

            // Response with 401 - Unathorized
            Assert.Equal(HttpStatusCode.Unauthorized, response.StatusCode);
        }

        [Fact(DisplayName = "[INT-CC002][202-Accepted] - Create account if not exists")]
        [Trait("Feature", "CC - Create character")]
        public async Task CreateAccount()
        {
            // Arrange
            var correlationId = Guid.NewGuid();

            var client = _factory.CreateClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("IntegrationTestScheme");

            // Call /api/character POST endpoint with not existing character
            var response = await client.PostAsync("/api/character", new Fixture().GenerateCreateCharacter(), correlationId, TimeSpan.FromSeconds(5));

            // Response with 202 - Accepted
            Assert.Equal(HttpStatusCode.Accepted, response.StatusCode);

            // Character is inserted to the database
            var context = _factory.Services.GetRequiredService<DatabaseContext>();
            var entity = await context.Accounts.FirstOrDefaultAsync(ae => ae.BattleTag == "integration_test", new CancellationTokenSource(TimeSpan.FromSeconds(5)).Token);

            Assert.NotNull(entity);
            Assert.NotEqual(Guid.Empty, entity.Id);
            Assert.Equal("integration_test", entity.BattleTag);
        }

        [Fact(DisplayName = "[INT-CC003][202-Accepted] - Create character")]
        [Trait("Feature", "CC - Create character")]
        public async Task CreateCharacter()
        {
            // Arrange
            var correlationId = Guid.NewGuid();
            var command = new Fixture().GenerateCreateCharacter();
            var client = _factory.CreateClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("IntegrationTestScheme");

            // Call /api/character POST endpoint with not existing character
            var response = await client.PostAsync("/api/character", command, correlationId, TimeSpan.FromSeconds(5));

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

        [Fact(DisplayName = "[INT-CC004][202-Accepter] - Create existing character for different account")]
        [Trait("Feature", "CC - Create character")]
        public async Task CreateExistingCharacterForDifferentAccount()
        {
            // Arrange
            var correlationId = Guid.NewGuid();
            var name = new Fixture().Create<string>();
            var existingCharacter = new Fixture().Build<CharacterEntity>()
                                                    .Without(ce => ce.Runes)
                                                    .With(ce => ce.Name, name)
                                                    .With(ce => ce.Account,  new AccountEntity { Id = Guid.NewGuid(), BattleTag = "TestAccount" })
                                                .Create();
            var command = new Fixture().Build<CreateCharacterCommand>().FromFactory(() => DataFactories.Create(name)).Create();

            var context = _factory.Services.GetRequiredService<DatabaseContext>();
            await context.Database.EnsureCreatedAsync(new CancellationTokenSource(TimeSpan.FromSeconds(5)).Token);
            await context.AddAsync(existingCharacter, new CancellationTokenSource(TimeSpan.FromSeconds(5)).Token);
            await context.SaveChangesAsync(new CancellationTokenSource(TimeSpan.FromSeconds(5)).Token);

            var client = _factory.CreateClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("IntegrationTestScheme");

            // Call /api/character POST endpoint with not existing character
            var response = await client.PostAsync("/api/character", command, correlationId, TimeSpan.FromSeconds(5));

            // Response with 202 - Accepted
            Assert.Equal(HttpStatusCode.Accepted, response.StatusCode);

            // Character is inserted to the database
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

        [Fact(DisplayName = "[INT-CC005][400-Bad Request] - Create existing character")]
        [Trait("Feature", "CC - Create character")]
        public async Task CreateExistingCharacter()
        {
            // Arrange
            var correlationId = Guid.NewGuid();
            var name = new Fixture().Create<string>();
            var existingCharacter = new Fixture().Build<CharacterEntity>()
                                                    .Without(ce => ce.Runes)
                                                    .With(ce => ce.Name, name)
                                                    .With(ce => ce.Account, new AccountEntity { Id = Guid.NewGuid(), BattleTag = "integration_test" })
                                                .Create();
            var command = new Fixture().Build<CreateCharacterCommand>().FromFactory(() => DataFactories.Create(name)).Create();

            var context = _factory.Services.GetRequiredService<DatabaseContext>();
            await context.Database.EnsureCreatedAsync(new CancellationTokenSource(TimeSpan.FromSeconds(5)).Token);
            await context.AddAsync(existingCharacter, new CancellationTokenSource(TimeSpan.FromSeconds(5)).Token);
            await context.SaveChangesAsync(new CancellationTokenSource(TimeSpan.FromSeconds(5)).Token);

            var client = _factory.CreateClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("IntegrationTestScheme");

            // Call /api/character POST endpoint with not existing character
            var response = await client.PostAsync("/api/character", command, correlationId, TimeSpan.FromSeconds(5));

            // Response with 400 - Bad Request
            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);

            var error = await response.Content.ReadFromJsonAsync<Error>(cancellationToken: new CancellationTokenSource(TimeSpan.FromSeconds(5)).Token);
            // Error code - 402
            Assert.Equal(402, error.Code);

            // Message - 'TestCharacter has been already created'
            Assert.Equal($"{name} has been already created", error.Message);
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
    }
}
