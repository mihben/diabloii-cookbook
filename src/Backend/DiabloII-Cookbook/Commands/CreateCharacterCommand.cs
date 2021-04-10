using DiabloII_Cookbook.Api.Enumerations;
using DiabloII_Cookbook.Api.Extensions;
using FluentValidation;
using Netension.Core;
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
            RuleFor(c => c.Class).NotEmpty().IsValueOf(Enumeration.GetAll<ClassEnumeration>());
            RuleFor(c => c.Name).NotEmpty();
            RuleFor(c => c.Level).InclusiveBetween(1, 99);
        }
    }
}
