using System;
using System.Collections.Generic;

namespace DiabloII_Cookbook.Api.DataTransferObjects
{
    public class RuneWord
    {
        public Guid Id { get; }
        public string Name { get; }
        public int Level { get; }
        public bool IsLadder { get; }
        public IEnumerable<RuneWordIngredient> Ingredients { get; }
        public IEnumerable<RuneWordProperty> Properties { get; }
        public IEnumerable<ItemType> ItemTypes { get; }

        public RuneWord(Guid id, string name, int level, bool isLadder, IEnumerable<RuneWordIngredient> ingredients, IEnumerable<RuneWordProperty> properties, IEnumerable<ItemType> itemTypes)
        {
            Id = id;
            Name = name;
            Ingredients = ingredients;
            Properties = properties;
            ItemTypes = itemTypes;
            Level = level;
            IsLadder = isLadder;
        }
    }
}
