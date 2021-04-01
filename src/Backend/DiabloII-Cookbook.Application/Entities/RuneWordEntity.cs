using System;
using System.Collections.Generic;

namespace DiabloII_Cookbook.Application.Entities
{
    public class RuneWordEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Class { get; set; }
        public int Level { get; set; }
        public bool IsLadder { get; set; }
        public ICollection<RuneWordIngredientEntity> Ingredients { get; set; } = new List<RuneWordIngredientEntity>();
        public ICollection<RuneWordPropertyEntity> Properties { get; set; } = new List<RuneWordPropertyEntity>();
        public ICollection<RuneWordItemTypeEntity> ItemTypes { get; set; } = new List<RuneWordItemTypeEntity>();
    }

    public class RuneWordIngredientEntity
    {
        public Guid Id { get; set; }
        public int Order { get; set; }
        public Guid RuneWordId { get; set; }
        public RuneWordEntity RuneWord { get; set; }
        public Guid RuneId { get; set; }
        public RuneEntity Rune { get; set; }
    }

    public class RuneWordPropertyEntity
    {
        public Guid Id { get; set; }
        public string Description { get; set; }
        public Guid? SkillId { get; set; }
        public SkillEntity Skill { get; set; }
        public Guid RuneWordId { get; set; }
        public RuneWordEntity RuneWord { get; set; }
    }

    public class RuneWordItemTypeEntity
    {
        public Guid Id { get; set; }
        public Guid RuneWordId { get; set; }
        public RuneWordEntity RuneWord { get; set; }
        public Guid ItemTypeId { get; set; }
        public ItemTypeEntity ItemType { get; set; }
    }
}
