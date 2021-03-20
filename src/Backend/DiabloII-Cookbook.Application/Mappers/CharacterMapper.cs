using DiabloII_Cookbook.Api.DataTransferObjects;
using DiabloII_Cookbook.Application.Entities;

namespace DiabloII_Cookbook.Application.Mappers
{
    public static class CharacterMapper
    {
        public static Character ToDto(this CharacterEntity entity)
        {
            return new Character(entity.Id, entity.Class, entity.Name, entity.Level, entity.IsLadder, entity.IsExpansion);
        }
    }
}
