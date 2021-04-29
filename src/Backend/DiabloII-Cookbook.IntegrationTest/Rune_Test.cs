using AutoFixture;
using DiabloII_Cookbook.Api.DataTransferObjects;
using DiabloII_Cookbook.Application.DatabaseContexts;
using DiabloII_Cookbook.Application.Entities;
using DiabloII_Cookbook.IntegrationTest.Extensions;
using DiabloII_Cookbook.IntegrationTest.Factories;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Threading;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace DiabloII_Cookbook.IntegrationTest
{
    public class Rune_Test : IClassFixture<DiabloII_CookbookFactory>
    {
        private readonly DiabloII_CookbookFactory _factory;

        public Rune_Test(DiabloII_CookbookFactory factory, ITestOutputHelper outputHelper)
        {
            factory.SetOutputHelper(outputHelper);
            _factory = factory;
        }

        [Fact(DisplayName = "[INT-RU001][401-Unathorized]: Get runes without authentication")]
        [Trait("Feature", "RU - Runes")]
        public async Task GetRunesWithoutAuthentication()
        {
            // Arrange
            var correlationId = Guid.NewGuid();
            var client = _factory.CreateClient();

            // Act
            var response = await client.GetAsync("/api/rune", correlationId, TimeSpan.FromSeconds(5));

            // Assert
            Assert.Equal(HttpStatusCode.Unauthorized, response.StatusCode);
        }

        [Fact(DisplayName = "[INT-RU002][200-OK]: Get runes")]
        [Trait("Feature", "RU - Runes")]
        public async Task GetRunes()
        {
            // Arrange
            var correlationId = Guid.NewGuid();
            var client = _factory.CreateClient();
            var runes = new Fixture()
                            .Build<RuneEntity>()
                                .Without(re => re.RuneWords)
                                .Without(re => re.Characters)
                            .CreateMany(2);

            var context = _factory.Services.GetService<DatabaseContext>();
            await context.Database.EnsureCreatedAsync(new CancellationTokenSource(TimeSpan.FromSeconds(5)).Token);
            await context.Runes.AddRangeAsync(runes, new CancellationTokenSource(TimeSpan.FromSeconds(5)).Token);
            await context.SaveChangesAsync(new CancellationTokenSource(TimeSpan.FromSeconds(5)).Token);

            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("IntegrationTestScheme");

            // Act
            var response = await client.GetAsync("/api/rune", correlationId, TimeSpan.FromSeconds(5));

            // Assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);

            Assert.Collection(await response.Content.ReadFromJsonAsync<IEnumerable<Rune>>(), r => r.Id.Equals(runes.ElementAt(0).Id), r => r.Id.Equals(runes.ElementAt(1).Id));
        }
    }
}
