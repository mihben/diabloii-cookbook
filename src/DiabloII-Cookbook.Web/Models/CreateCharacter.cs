namespace DiabloII_Cookbook.Web.Models
{
    public class CreateCharacter
    {
        public string Class { get; }
        public string Name { get; }
        public int Level { get; }
        public bool IsLadder { get; }
        public bool IsExpansion { get; }

        public CreateCharacter(string @class, string name, int level, bool isLadder, bool isExpansion)
        {
            Class = @class;
            Name = name;
            Level = level;
            IsLadder = isLadder;
            IsExpansion = isExpansion;
        }
    }
}
