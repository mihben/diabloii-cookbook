using AutoFixture;
using DiabloII_Cookbook.Api.Commands;
using DiabloII_Cookbook.IntegrationTest.Builders;

namespace DiabloII_Cookbook.IntegrationTest.Extensions
{
    public static class FixtureExtensions
    {
        public static CreateCharacterCommand GenerateCreateCharacter(this Fixture fixture)
        {
            return fixture.Build<CreateCharacterCommand>().FromFactory(DataFactories.Create).Create();
        }
    }
}
