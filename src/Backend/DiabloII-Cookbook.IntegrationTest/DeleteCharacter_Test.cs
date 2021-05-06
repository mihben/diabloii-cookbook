using AutoFixture;
using DiabloII_Cookbook.Application.DatabaseContexts;
using DiabloII_Cookbook.Application.Entities;
using DiabloII_Cookbook.IntegrationTest.Builders;
using DiabloII_Cookbook.IntegrationTest.Extensions;
using DiabloII_Cookbook.IntegrationTest.Factories;
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
    public class DeleteCharacter_Test : IClassFixture<DiabloII_CookbookFactory>, IDisposable
    {
        private bool _disposedValue;
        private readonly DiabloII_CookbookFactory _factory;

        public DeleteCharacter_Test(DiabloII_CookbookFactory factory, ITestOutputHelper outputHelper)
        {
            factory.SetOutputHelper(outputHelper);
            _factory = factory;
        }

        [Fact(DisplayName = "[INT-DC001][401-Unathorized] - Delete character without authentication")]
        [Trait("Feature", "DC - Delete character")]
        public async Task DeleteCharacterWithoutAuthentication()
        {
            // Arrange
            var correlationId = Guid.NewGuid();
            var client = _factory.CreateClient();

            // Act
            var response = await client.DeleteAsync($"/api/character/{Guid.NewGuid()}", correlationId, TimeSpan.FromSeconds(5));

            // Assert
            Assert.Equal(HttpStatusCode.Unauthorized, response.StatusCode);
        }

        [Fact(DisplayName = "[INT-DC002][400-BadRequest] - Delete not existed character")]
        [Trait("Feature", "DC - Delete character")]
        public async Task DeleteNotExistedCharacter()
        {
            // Arrange
            var correlationId = Guid.NewGuid();
            var client = _factory.CreateClient();

            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("IntegrationTestScheme");

            // Act
            var response = await client.DeleteAsync($"/api/character/{Guid.NewGuid()}", correlationId, TimeSpan.FromSeconds(100));

            // Assert
            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }

        [Fact(DisplayName = "[INT-DC003][202-Accepted] - Delete character")]
        [Trait("Feature", "DC - Delete character")]
        public async Task DeleteCharacter()
        {
            // Arrange
            var correlationId = Guid.NewGuid();
            var existingCharacter = new Fixture().CreateCharacterEntity();

            var context = _factory.Services.GetService<DatabaseContext>();
            await context.Database.EnsureCreatedAsync(new CancellationTokenSource(TimeSpan.FromSeconds(5)).Token);
            await context.Characters.AddAsync(existingCharacter, new CancellationTokenSource(TimeSpan.FromSeconds(5)).Token);
            await context.SaveChangesAsync(new CancellationTokenSource(TimeSpan.FromSeconds(5)).Token);

            var client = _factory.CreateClient();

            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("IntegrationTestScheme");

            // Act
            var response = await client.DeleteAsync($"/api/character/{existingCharacter.Id}", correlationId, TimeSpan.FromSeconds(100));

            // Assert
            Assert.Equal(HttpStatusCode.Accepted, response.StatusCode);

            context.ChangeTracker.Clear();
            Assert.Null(await context.FindAsync<CharacterEntity>(new object[] { existingCharacter.Id }, cancellationToken: new CancellationTokenSource(TimeSpan.FromSeconds(5)).Token));
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
