using System;
using System.Collections.Generic;

namespace DiabloII_Cookbook.Application.Entities
{
    public class AccountEntity
    {
        public Guid Id { get; set; }
        public string BattleTag { get; set; }
        public ICollection<CharacterEntity> Characters { get; set; }
    }
}
