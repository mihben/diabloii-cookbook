using Netension.Request;
using System;

namespace DiabloII_Cookbook.Api.Commands
{
    public class AddItemTypeFilterCommand : Command
    {
        public Guid CharacterId { get; }
        public Guid ItemTypeId { get; }

        public AddItemTypeFilterCommand(Guid characterId, Guid itemTypeId)
        {
            CharacterId = characterId;
            ItemTypeId = itemTypeId;
        }
    }
}
