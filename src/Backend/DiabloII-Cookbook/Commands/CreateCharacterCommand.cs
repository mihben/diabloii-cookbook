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
}
