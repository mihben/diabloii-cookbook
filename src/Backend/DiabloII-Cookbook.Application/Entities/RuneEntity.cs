using System;
using System.Collections.Generic;

namespace DiabloII_Cookbook.Application.Entities
{
    public class RuneEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Level { get; set; }
        public int Order { get; set; }
        public string InWeapon { get; set; }
        public string InHelm { get; set; }
        public string InArmor { get; set; }
        public string InShield { get; set; }
        public ICollection<CharacterRuneEntity> Characters { get; set; }
    }
}
