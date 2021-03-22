using System;
using System.Collections.Generic;

namespace DiabloII_Cookbook.Application.Entities
{
    public class CharacterEntity
    {
        public Guid Id { get; set; }
        public string Class { get; set; }
        public string Name { get; set; }
        public int Level { get; set; }
        public bool IsLadder { get; set; }
        public bool IsExpansion { get; set; }
        public ICollection<CharacterRuneEntity> Runes { get; set; }
    }
}
