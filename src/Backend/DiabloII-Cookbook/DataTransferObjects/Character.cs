using System;
using System.Collections;
using System.Collections.Generic;

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
        public IEnumerable<Rune> Runes { get; }

        public static Character Empty => new Character();

        private Character() { }


        public Character(Guid id, string @class, string name, int level, bool isLadder, bool isExpansion, IEnumerable<Rune> runes)
        {
            Id = id;
            Class = @class;
            Name = name;
            Level = level;
            IsLadder = isLadder;
            IsExpansion = isExpansion;
            Runes = runes;
        }
    }
}
