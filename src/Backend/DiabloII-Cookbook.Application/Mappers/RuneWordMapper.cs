using DiabloII_Cookbook.Api.DataTransferObjects;
using DiabloII_Cookbook.Application.Entities;
using System.Linq;

namespace DiabloII_Cookbook.Application.Mappers
{
    public static class RuneWordMapper
    {
        public static RuneWord ToDto(this RuneWordEntity entity)
        {
            return new RuneWord(entity.Id, entity.Name, entity.Ingredients.OrderBy(i => i.Order).Select(i => i.ToDto()), entity.Properties.Select(p => p.ToDto()), entity.ItemTypes.Select(it => it.ItemType.ToDto()));
        }

        public static RuneWordIngredient ToDto(this RuneWordIngredientEntity entity)
        {
            return new RuneWordIngredient(entity.Id, entity.Order, entity.Rune.ToDto());
        }

        public static RuneWordProperty ToDto(this RuneWordPropertyEntity entity)
        {
            return new RuneWordProperty(entity.Description, entity.Skill?.ToDto());
        }

        public static Skill ToDto(this SkillEntity entity)
        {
            return new Skill(entity.Name, entity.Class, entity.Description);
        }
    }
}
