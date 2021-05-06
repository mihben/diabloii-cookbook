using DiabloII_Cookbook.Api.DataTransferObjects;
using DiabloII_Cookbook.Application.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DiabloII_Cookbook.Application.Mappers
{
    public static class CharacterMapper
    {
        public static Character ToDto(this CharacterEntity entity)
        {
            if (entity == null) return Character.Empty;

            return new Character(entity.Id, entity.Class, entity.Name, entity.Level, entity.IsLadder, entity.IsExpansion, entity.Runes.Select(r => r.Rune.ToDto()), entity.Filters.ToDto());
        }

        public static Filter ToDto(this IEnumerable<FilterEntity> filters)
        {
            var result = new List<Guid>();
            foreach (var filter in filters)
            {
                result.Add(filter.ItemTypeId);
            }

            return new Filter(result);
        }
    }
}
