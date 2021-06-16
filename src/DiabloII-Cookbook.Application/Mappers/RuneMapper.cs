using DiabloII_Cookbook.Api.DataTransferObjects;
using DiabloII_Cookbook.Application.Entities;

namespace DiabloII_Cookbook.Application.Mappers
{
    public static class RuneMapper
    {
        public static Rune ToDto(this RuneEntity entity)
        {
            return new Rune(entity.Id, entity.Name, entity.Order, entity.Level, entity.InWeapon, entity.InHelm, entity.InArmor, entity.InShield);
        }

        public static RuneEntity ToEntity(this Rune rune)
        {
            return new RuneEntity
            {
                Id = rune.Id,
                Order = rune.Order,
                Name = rune.Name,
                Level = rune.Level,
                InWeapon = rune.InWeapon,
                InArmor = rune.InArmor,
                InHelm = rune.InHelm,
                InShield = rune.InShield
            };
        }
    }
}
