using System;
using System.Collections.Generic;

namespace DiabloII_Cookbook.Application.Entities
{
    public class ItemTypeEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Group { get; set; }
        public ICollection<RuneWordItemTypeEntity> RuneWords { get; set; }
    }
}
