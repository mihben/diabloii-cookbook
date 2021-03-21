using Netension.Request;
using System;

namespace DiabloII_Cookbook.Api.Commands
{
    public class UpdateCharacterCommand : Command
    {
        public Guid Id {get;set;}
        public int Level { get; set; }

        public UpdateCharacterCommand(Guid id, int level)
        {
            Id = id;
            Level = level;
        }
    }
}
