using System;

namespace DiabloII_Cookbook.Api.DataTransferObjects
{
    public class Character
    {
        public Guid Id { get; }
        public string Class { get; }
        public string Name { get; }
        public int Level { get; }
        public bool IsLadder { get; }
        public bool IsExpansion { get; }

        public Character(Guid id, string @class, string name, int level, bool isLadder, bool isExpansion)
        {
            Id = id;
            Class = @class;
            Name = name;
            Level = level;
            IsLadder = isLadder;
            IsExpansion = isExpansion;
        }
    }
}
