using DiabloII_Cookbook.Api.Commands;
using DiabloII_Cookbook.Application.Entities;

namespace DiabloII_Cookbook.Application.Mappers
{
    public static class FilterMapper
    {
        public static FilterEntity ToEntity(this AddItemTypeFilterCommand command)
        {
            return new FilterEntity
            {
                CharacterId = command.CharacterId,
                ItemTypeId = command.ItemTypeId
            };
        }
    }
}
