using DiabloII_Cookbook.IntegrationTest.Extensions;
using DiabloII_Cookbook.IntegrationTest.Factories;
using System;
using System.Net;
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
            //var existingCharacter = new Fixture().Build<CharacterEntity>()
            //                                        .Without(ce => ce.Runes)
            //                                        .With(ce => ce.Account, new AccountEntity { Id = Guid.NewGuid(), BattleTag = "integration_test" })
            //                                    .Create();

            //var context = _factory.Services.GetRequiredService<DatabaseContext>();
            //await context.Characters.AddAsync(existingCharacter, new CancellationTokenSource(TimeSpan.FromSeconds(5)).Token);

            // Call /api/character/{id} DELETE endpoint without authentication
            var response = await client.DeleteAsync($"/api/character/{Guid.NewGuid()}", correlationId, TimeSpan.FromSeconds(5)).ConfigureAwait(false);

            // Response with 403 - Unathorized
            Assert.Equal(HttpStatusCode.Unauthorized, response.StatusCode);
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
