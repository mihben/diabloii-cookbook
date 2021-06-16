using DiabloII_Cookbook.Api.Commands;
using System.Threading.Tasks;
using Xunit;

namespace DiabloII_Cookbook.Test.Validators
{
    public class CreateCharacterValidator_Test
    {

        private CreateCharacterCommandValidator CreateSUT()
        {
            return new CreateCharacterCommandValidator();
        }

        [Theory(DisplayName = "[UNT-VAL-CC001][Success] - Validate character")]
        [Trait("Feature", "CC - Create character")]
        [InlineData("Amazon")]
        [InlineData("Assassin")]
        [InlineData("Barbarian")]
        [InlineData("Druid")]
        [InlineData("Necromancer")]
        [InlineData("Sorceress")]
        [InlineData("Paladin")]
        public async Task Validate(string @class)
        {
            // Arrange
            var sut = CreateSUT();

            // Act
            var result = await sut.ValidateAsync(new CreateCharacterCommand("BattleTag", @class, "TestName", 1, false, false), default);

            // Assert
            Assert.True(result.IsValid);
        }

        [Theory(DisplayName = "[UNT-VAL-CC002][Failure] - Missing name")]
        [Trait("Feature", "CC - Create character")]
        [InlineData(null)]
        [InlineData("        ")]
        [InlineData("")]
        public async Task MissingName(string name)
        {
            // Arrange
            var sut = CreateSUT();

            // Act
            var result = await sut.ValidateAsync(new CreateCharacterCommand("BattleTag", "Amazon", name, 1, false, false), default);

            // Assert
            Assert.False(result.IsValid);
        }

        [Theory(DisplayName = "[UNT-VAL-CC003][Failure] - Invalid level")]
        [Trait("Feature", "CC - Create character")]
        [InlineData(0)]
        [InlineData(100)]
        public async Task InvalidLevel(int level)
        {
            // Arrange
            var sut = CreateSUT();

            // Act
            var result = await sut.ValidateAsync(new CreateCharacterCommand("BattleTag", "Amazon", "TestName", level, false, false), default);

            // Assert
            Assert.False(result.IsValid);
        }

        [Theory(DisplayName = "[UNT-VAL-CC004][Failure] - Invalid class")]
        [Trait("Feature", "CC - Create character")]
        [InlineData(null)]
        [InlineData("   ")]
        [InlineData("")]
        [InlineData("InvalidClass")]
        public async Task InvalidClass(string @class)
        {
            // Arrange
            var sut = CreateSUT();

            // Act
            var result = await sut.ValidateAsync(new CreateCharacterCommand("BattleTag", @class, "TestName", 1, false, false), default);

            // Assert
            Assert.False(result.IsValid);
        }
    }
}
