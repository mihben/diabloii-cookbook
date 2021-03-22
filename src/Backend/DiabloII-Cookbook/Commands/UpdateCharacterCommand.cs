using DiabloII_Cookbook.Api.DataTransferObjects;
using Netension.Request;
using System;
using System.Collections.Generic;

namespace DiabloII_Cookbook.Api.Commands
{
    public class UpdateCharacterCommand : Command
    {
        public Guid Id { get; }
        public int Level { get; }
        public IEnumerable<Rune> Runes {get;}

        public UpdateCharacterCommand(Guid id, int level, IEnumerable<Rune> runes)
        {
            Id = id;
            Level = level;
            Runes = runes;
        }
    }
}
