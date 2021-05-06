using System;

namespace DiabloII_Cookbook.Application.Entities
{
    public class FilterEntity
    {
        public Guid Id { get; set; }
        public CharacterEntity Character { get; set; }
        public Guid CharacterId { get; set; }
        public ItemTypeEntity ItemType { get; set; }
        public Guid ItemTypeId { get; set; }
    }
}
