using DiabloII_Cookbook.Api.Commands;
using DiabloII_Cookbook.Api.DataTransferObjects;
using System;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace DiabloII_Cookbook.Test.Validators
{
    public class UpdateCharacterValidator_Test
    {
        private UpdateCharacterCommandValidator CreateSUT()
        {
            return new UpdateCharacterCommandValidator();
        }

        [Theory(DisplayName = "[UNT-VAL-UC001][Success] - Validate character")]
        [Trait("Feature", "UC - Update character")]
        [InlineData(1)]
        [InlineData(99)]
        [InlineData(50)]
        public async Task ValidateCharacter(int level)
        {
            // Arrange
            var sut = CreateSUT();

            // Act
            var result = await sut.ValidateAsync(new UpdateCharacterCommand(Guid.NewGuid(), level, Enumerable.Empty<Rune>()), default);

            // Assert
            Assert.True(result.IsValid);
        }

        [Fact(DisplayName = "[UNT-VAL-UC002][Failure] - Empty id")]
        [Trait("Feature", "UC - Update character")]
        public async Task EmptyId()
        {
            // Arrange
            var sut = CreateSUT();

            // Act
            var result = await sut.ValidateAsync(new UpdateCharacterCommand(Guid.Empty, new Random().Next(1, 99), Enumerable.Empty<Rune>()), default);

            // Assert
            Assert.False(result.IsValid);
        }

        [Theory(DisplayName = "[UNT-VAL-UC003][Failure] - Invalid level")]
        [Trait("Feature", "UC - Update character")]
        [InlineData(0)]
        [InlineData(100)]
        public async Task InvalidLevel(int level)
        {
            // Arrange
            var sut = CreateSUT();

            // Act
            var result = await sut.ValidateAsync(new UpdateCharacterCommand(Guid.NewGuid(), level, Enumerable.Empty<Rune>()), default);

            // Assert
            Assert.False(result.IsValid);
        }
    }
}
