using AutoFixture;
using DiabloII_Cookbook.Application.DatabaseContexts;
using DiabloII_Cookbook.Application.Entities;
using DiabloII_Cookbook.IntegrationTest.Extensions;
using DiabloII_Cookbook.IntegrationTest.Factories;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Threading;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace DiabloII_Cookbook.IntegrationTest
{
    public class GetCharacter_Test : IClassFixture<DiabloII_CookbookFactory>, IDisposable
    {
        private readonly DiabloII_CookbookFactory _factory;
        private bool _disposedValue;

        public GetCharacter_Test(DiabloII_CookbookFactory factory, ITestOutputHelper outputHelper)
        {
            factory.SetOutputHelper(outputHelper);

            _factory = factory;
        }

        [Fact(DisplayName = "[INT-GC001][401-Unathorized] - Get characters without authentication")]
        [Trait("Feature", "GC - Get character")]
        public async Task GetCharacterWithoutAuthorization()
        {
            // Arrange
            var correlationId = Guid.NewGuid();
            var client = _factory.CreateClient();

            // Act
            var response = await client.GetAsync("/api/character", correlationId, TimeSpan.FromSeconds(5));

            // Assert
            Assert.Equal(HttpStatusCode.Unauthorized, response.StatusCode);
        }

        [Fact(DisplayName = "[INT-GC002][200-Ok] - Get characters")]
        [Trait("Feature", "GC - Get character")]
        public async Task GetCharacters()
        {
            // Arrange
            var correlationId = Guid.NewGuid();
            var client = _factory.CreateClient();
            var existingCharacter = new Fixture().Build<CharacterEntity>()
                                                     .Without(ce => ce.Runes)
                                                     .With(ce => ce.Account, new AccountEntity { Id = Guid.NewGuid(), BattleTag = "integration_test" })
                                                 .Create();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("IntegrationTestScheme");

            var context = _factory.Services.GetRequiredService<DatabaseContext>();
            await context.Database.EnsureCreatedAsync(new CancellationTokenSource(TimeSpan.FromSeconds(5)).Token);
            await context.AddAsync(existingCharacter, new CancellationTokenSource(TimeSpan.FromSeconds(5)).Token);
            await context.SaveChangesAsync(new CancellationTokenSource(TimeSpan.FromSeconds(5)).Token);

            // Act
            var response = await client.GetAsync("/api/character", correlationId, TimeSpan.FromSeconds(5));

            // Assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            Assert.Collection(await response.Content.ReadFromJsonAsync<IEnumerable<string>>(), s => s.Equals(existingCharacter.Id.ToString()));
        }

        [Fact(DisplayName = "[INT-GC003][204-NoContent] - Get characters from unkown account")]
        [Trait("Feature", "GC - Get character")]
        public async Task GetCharactersFromUnknownAccount()
        {
            // Arrange
            var correlationId = Guid.NewGuid();
            var client = _factory.CreateClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("IntegrationTestScheme");

            await _factory.Services.GetRequiredService<DatabaseContext>().Database.EnsureCreatedAsync(new CancellationTokenSource(TimeSpan.FromSeconds(5)).Token);

            // Act
            var response = await client.GetAsync("/api/character", correlationId, TimeSpan.FromSeconds(5));

            // Assert
            Assert.Equal(HttpStatusCode.NoContent, response.StatusCode);
        }

        [Fact(DisplayName = "[INT-GC004][204-NoContent] - Account do not have character")]
        [Trait("Feature", "GC - Get character")]
        public async Task AccountDoNotHaveCharacter()
        {
            // Arrange
            var correlationId = Guid.NewGuid();
            var client = _factory.CreateClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("IntegrationTestScheme");

            var context = _factory.Services.GetRequiredService<DatabaseContext>();
            await context.Database.EnsureCreatedAsync(new CancellationTokenSource(TimeSpan.FromSeconds(5)).Token);
            await context.Accounts.AddAsync(new AccountEntity { Id = Guid.NewGuid(), BattleTag = "integration_test" }, new CancellationTokenSource(TimeSpan.FromSeconds(5)).Token);
            await context.SaveChangesAsync(new CancellationTokenSource(TimeSpan.FromSeconds(5)).Token);

            // Act
            var response = await client.GetAsync("/api/character", correlationId, TimeSpan.FromSeconds(5));

            // Assert
            Assert.Equal(HttpStatusCode.NoContent, response.StatusCode);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposedValue)
            {
                if (disposing)
                {
                    _factory.Reset();
                }
                _disposedValue = true;
            }
        }

        public void Dispose()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}
