using DiabloII_Cookbook.Api.DataTransferObjects;
using DiabloII_Cookbook.Application.Entities;

namespace DiabloII_Cookbook.Application.Mappers
{
    public static class ItemTypeMapper
    {
        public static ItemType ToDto(this ItemTypeEntity entity)
        {
            return new ItemType(entity.Id, entity.Group, entity.Name);
        }
        public static ItemTypeEntity ToEntity(this ItemType dto)
        {
            return new ItemTypeEntity
            {
                Id = dto.Id,
                Group = dto.Group,
                Name = dto.Name
            };
        }
    }
}
