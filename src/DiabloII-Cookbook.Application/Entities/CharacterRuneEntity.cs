using System;

namespace DiabloII_Cookbook.Application.Entities
{
    public class CharacterRuneEntity
    {
        public Guid CharacterId { get; set; }
        public CharacterEntity Character { get; set; }
        public Guid RuneId { get; set; }
        public RuneEntity Rune { get; set; }
    }
}
