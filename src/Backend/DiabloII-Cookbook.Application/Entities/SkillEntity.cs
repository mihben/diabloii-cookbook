using System;
using System.Collections.Generic;

namespace DiabloII_Cookbook.Application.Entities
{
    public class SkillEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Class { get; set; }
        public string Description { get; set; }
        public ICollection<RuneWordPropertyEntity> Properties { get; set; }

    }
}
