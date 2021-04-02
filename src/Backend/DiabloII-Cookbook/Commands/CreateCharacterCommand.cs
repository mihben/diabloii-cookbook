using FluentValidation;
using Netension.Request;

namespace DiabloII_Cookbook.Api.Commands
{
    public class CreateCharacterCommand : Command
    {
        public string Class { get; }
        public string Name { get; }
        public int Level { get; }
        public bool IsLadder { get; }
        public bool IsExpansion { get; }

        public CreateCharacterCommand(string @class, string name, int level, bool isLadder, bool isExpansion)
        {
            Class = @class;
            Name = name;
            Level = level;
            IsLadder = isLadder;
            IsExpansion = isExpansion;
        }
    }

    public class CreateCharacterCommandValidator : AbstractValidator<CreateCharacterCommand>
    {
        public CreateCharacterCommandValidator()
        {
            RuleFor(c => c.Class)
                .NotEmpty();
            RuleFor(c => c.Class)
                .NotEmpty();
            RuleFor(c => c.Level)
                .ExclusiveBetween(1, 99);
        }
    }
}
